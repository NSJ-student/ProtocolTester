using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProtocolTester
{
	public delegate void HandleControl();
	public partial class CommScheduler : Form
	{
		public SendMsg SendstrMsg;
		Thread ScheduleTask;
		public enum TypeNum
		{
			TYPE_SEND,
			TYPE_DELAY
		}
		public CommScheduler(SendMsg SendEvent)
		{
			InitializeComponent();
			SendstrMsg = SendEvent;
		}

		/// <summary>
		/// 테이블 스케줄 실행/정지
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStart_Click(object sender, EventArgs e)
		{
			ScheduleTask = new Thread(new ThreadStart(PlaySchedule));
			ScheduleTask.Start();
			btnStart.Enabled = false;
			btnStop.Enabled = true;
		}
		private void btnStop_Click(object sender, EventArgs e)
		{
			ScheduleTask.Abort();
			btnStart.Enabled = true;
			btnStop.Enabled = false;
		}

		/// <summary>
		/// 테이블에 새 아이템 추가
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnNewItem_Click(object sender, EventArgs e)
		{
			int index = dgvSchedule.Rows.Add();
			DataGridViewRow row = dgvSchedule.Rows[index];

			row.Cells["cType"].Value = "SEND";
			row.Cells["cFormat"].Value = false;
			row.Cells["cName"].Value = "TEST" + dgvSchedule.Rows.Count.ToString();
			row.Cells["cValue"].Value = "";
			row.Cells["cCycle"].Value = "1";
			row.Cells["cDelayMs"].Value = "0";
			row.Cells["cEnable"].Value = true;
			row.Cells["cSend"].Value = "Send";
		}

		/// <summary>
		/// 테이블 선택 항목 삭제
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvSchedule.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgvSchedule.SelectedRows[0];

				dgvSchedule.Rows.Remove(row);
			}
		}
		
		/// <summary>
		/// 테이블 선택 항목 위치 이동
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUp_Click(object sender, EventArgs e)
		{
			if(dgvSchedule.SelectedRows.Count > 0)
			{
				int prevIndex = dgvSchedule.SelectedRows[0].Index;
				if (prevIndex == 0)
					return;
				DataGridViewRow row = dgvSchedule.SelectedRows[0];

				dgvSchedule.Rows.Remove(row);
				dgvSchedule.Rows.Insert(prevIndex - 1, row);
				dgvSchedule.CurrentCell = row.Cells[0];
			}
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			if (dgvSchedule.SelectedRows.Count > 0)
			{
				int prevIndex = dgvSchedule.SelectedRows[0].Index;
				if (prevIndex == dgvSchedule.Rows.Count - 1)
					return;
				DataGridViewRow row = dgvSchedule.SelectedRows[0];

				dgvSchedule.Rows.Remove(row);
				dgvSchedule.Rows.Insert(prevIndex + 1, row);
				dgvSchedule.CurrentCell = row.Cells[0];
			}
		}
		
		/// <summary>
		/// 폼 close를 hide로 치환
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CommScheduler_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			if(ScheduleTask != null && ScheduleTask.IsAlive)
			{
				ScheduleTask.Abort();
			}
			Hide();
		}

		/// <summary>
		/// Send 버튼 클릭 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if(e.ColumnIndex == dgvSchedule.Columns["cSend"].Index)
			{
				if(e.RowIndex >= 0)
				{
					ThreadStart ts = new ThreadStart(ExecuteSingleRow);
					ScheduleTask = new Thread(ts);
					ScheduleTask.Start();
				}
			}
		}

		/// <summary>
		/// Type 값 선택 루틴
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvSchedule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			// Type값이 선택됨
			if (e.ColumnIndex == 0)
			{
				if(e.RowIndex >= 0)
				{
					DataGridViewRow row = dgvSchedule.Rows[e.RowIndex];
					string value = (string)row.Cells["cType"].Value;
					if (value.Equals("SEND"))
					{
						row.Cells["cFormat"].ReadOnly = false;
					}
					if (value.Equals("DELAY"))
					{
						row.Cells["cFormat"].ReadOnly = true;
					}
				}
			}
		}
		
		/// <summary>
		/// 테이블의 스케줄을 실행하는 테스크
		/// </summary>
		private void PlaySchedule()
		{
			try
			{
				Invoke(new HandleControl(delegate {
					dgvSchedule.Enabled = false;
					dgvSchedule.BackgroundColor = SystemColors.ActiveCaption;
					btnStart.Enabled = false;
					btnStop.Enabled = true;
				}));
				
				foreach (DataGridViewRow row in dgvSchedule.Rows)
				{
					Invoke(new HandleControl(delegate {
						dgvSchedule.CurrentCell = row.Cells[0];
					}));
					
					if ((bool)row.Cells["cEnable"].Value)
					{
						if(!ExecuteRow(row))
						{
							Invoke(new HandleControl(delegate
							{
								dgvSchedule.Enabled = true;
								dgvSchedule.BackgroundColor = Color.LightPink;
								btnStart.Enabled = true;
								btnStop.Enabled = false;
								Text = "Schedule - Port Closed";
							}));
							return;
						}
					}
				}
				Invoke(new HandleControl(delegate {
					dgvSchedule.BackgroundColor = SystemColors.AppWorkspace;
				}));
			}
			catch(Exception es)
			{
				if(!IsDisposed)
					Invoke(new HandleControl(delegate {
						dgvSchedule.BackgroundColor = Color.IndianRed;
					}));
			}
			finally
			{
				if (!IsDisposed)
					Invoke(new HandleControl(delegate
					{
						dgvSchedule.Enabled = true;
						btnStart.Enabled = true;
						btnStop.Enabled = false;
					}));
			}
		}

		/// <summary>
		/// 단일 row를 실행하는 테스크
		/// </summary>
		private void ExecuteSingleRow()
		{
			DataGridViewRow row = dgvSchedule.SelectedRows[0];
			
			try
			{
				Invoke(new HandleControl(delegate {
					dgvSchedule.Enabled = false;
					dgvSchedule.BackgroundColor = SystemColors.ActiveCaption;
					btnStart.Enabled = false;
					btnStop.Enabled = true;
				}));
				if (!ExecuteRow(row))
				{
					Invoke(new HandleControl(delegate {
						dgvSchedule.Enabled = true;
						dgvSchedule.BackgroundColor = Color.LightPink;
						btnStart.Enabled = true;
						btnStop.Enabled = false;
						Text = "Schedule - Port Closed";
					}));
					return;
				}
				Invoke(new HandleControl(delegate {
					dgvSchedule.BackgroundColor = SystemColors.AppWorkspace;
				}));
			}
			catch
			{
				if (!IsDisposed)
					Invoke(new HandleControl(delegate {
						dgvSchedule.BackgroundColor = Color.IndianRed;
					}));
			}
			finally
			{
				if (!IsDisposed)
					Invoke(new HandleControl(delegate
					{
						dgvSchedule.Enabled = true;
						btnStart.Enabled = true;
						btnStop.Enabled = false;
					}));
			}
		}

		/// <summary>
		/// 단일 row 처리
		/// </summary>
		private bool ExecuteRow(DataGridViewRow row)
		{
			if (row.Cells["cType"].Value.Equals("SEND"))
			{
				int cycle = Convert.ToInt32((string)row.Cells["cCycle"].Value);
				for (int i = 0; i < cycle; i++)
				{
					if (!SendstrMsg((string)row.Cells["cValue"].Value, (bool)row.Cells["cFormat"].Value))
					{
						return false;
					}
					try
					{
						int delay = Convert.ToInt32((string)row.Cells["cDelayMs"].Value);
						if (delay > 0)
							Delay(delay);
					}
					catch
					{
						return false;
					}
				}
			}
			else if (row.Cells["cType"].Value.Equals("DELAY"))
			{
				int cycle = Convert.ToInt32((string)row.Cells["cCycle"].Value);
				for (int i = 0; i < cycle; i++)
				{
					try
					{
						int delay = Convert.ToInt32((string)row.Cells["cDelayMs"].Value);
						if (delay > 0)
							Delay(delay);
					}
					catch
					{
						return false;
					}
				}
			}
			return true;
		}

		private DateTime Delay(int MS)
		{
			DateTime StartMoment = DateTime.Now;
			DateTime ThisMoment = DateTime.Now;
			DateTime PrevMoment = DateTime.Now;
			TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
			TimeSpan period = new TimeSpan(0, 0, 0, 0, 1);
			DateTime AfterWards = ThisMoment.Add(duration);

			while (AfterWards >= ThisMoment)
			{
				Application.DoEvents();
				ThisMoment = DateTime.Now;
				if(ThisMoment.Subtract(PrevMoment) >= period)
				{
					SendMsg sm = delegate (string state, bool hex)
					{
						lblTime.Text = state.Remove(state.Length-4, 4);
						//Text = "Scheculer - Delay " + state;
						return hex;
					};
					Invoke(sm, new object[] { ThisMoment.Subtract(StartMoment).ToString(), false });
					PrevMoment = DateTime.Now;
				}
			}

			return DateTime.Now;
		}
	}
}
