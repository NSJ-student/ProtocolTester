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
using System.IO;
using System.Xml.Linq;

namespace ProtocolTester
{
	public delegate void HandleControl();
	public partial class CommScheduler : Form
	{
		private BackgroundWorker ScheduleWork;
		private bool TerminateScheduleThread;
		private Thread ScheduleTask;

		public SendMsg SendstrMsg;
		public enum TypeNum
		{
			TYPE_SEND,
			TYPE_DELAY
		}
		public CommScheduler(SendMsg SendEvent)
		{
			InitializeComponent();
			SendstrMsg = SendEvent;
			ScheduleWork = new BackgroundWorker();
			ScheduleWork.WorkerReportsProgress = true;
			//			ScheduleWork.RunWorkerCompleted += new RunWorkerCompletedEventHandler(MakeComponentsComplete);
			//			ScheduleWork.DoWork += new DoWorkEventHandler();
			//			ScheduleWork.ProgressChanged += new ProgressChangedEventHandler();
		}

		/// <summary>
		/// 테이블 스케줄 실행/정지
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStart_Click(object sender, EventArgs e)
		{
			TerminateScheduleThread = false;
			ScheduleTask = new Thread(new ThreadStart(PlaySchedule));
			ScheduleTask.Start();
			btnStart.Enabled = false;
			btnStop.Enabled = true;
		}
		private void btnStop_Click(object sender, EventArgs e)
		{
			btnStart.Enabled = true;
			btnStop.Enabled = false;
			TerminateScheduleThread = true;
			ScheduleTask.Join(100);
			if (ScheduleTask.IsAlive)
			{
				ScheduleTask.Abort();
				Text = "Schedule - Aborted";
			}
			else
			{
				Text = "Schedule - Stopped";
			}
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
			if (dgvSchedule.SelectedRows.Count > 0)
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
			if (ScheduleTask != null && ScheduleTask.IsAlive)
			{
				TerminateScheduleThread = true;
				ScheduleTask.Join(100);
				if (ScheduleTask.IsAlive)
				{
					ScheduleTask.Abort();
					Text = "Schedule - Aborted";
				}
				else
				{
					Text = "Schedule - Stopped";
				}
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
			if (e.ColumnIndex == dgvSchedule.Columns["cSend"].Index)
			{
				if (e.RowIndex >= 0)
				{
					TerminateScheduleThread = false;
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
				if (e.RowIndex >= 0)
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
					Text = "Schedule";
				}));

				foreach (DataGridViewRow row in dgvSchedule.Rows)
				{
					Invoke(new HandleControl(delegate {
						dgvSchedule.CurrentCell = row.Cells[0];
					}));

					if ((bool)row.Cells["cEnable"].Value)
					{
						if (!ExecuteRow(row))
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
			catch (Exception es)
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
					Text = "Schedule";
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
				Invoke(new Action(delegate () {
					lblCycle.Text = "0";
				}));

				for (int i = 0; i < cycle; i++)
				{
					System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
					if (!SendstrMsg((string)row.Cells["cValue"].Value, (bool)row.Cells["cFormat"].Value))
					{
						watch.Stop();
						return false;
					}
					try
					{
						int delay = Convert.ToInt32((string)row.Cells["cDelayMs"].Value);
						Invoke(new Action(delegate () {
							lblCycle.Text = (i + 1).ToString();
						}));
						watch.Stop();
						if (delay > 0)
							Delay(delay, watch.ElapsedMilliseconds);
					}
					catch
					{
						watch.Stop();
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

		private void Delay(long MS)
		{
			System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
			long prev = watch.ElapsedMilliseconds;
			long period = 10;

			while (MS > watch.ElapsedMilliseconds)
			{
				Application.DoEvents();
				if (TerminateScheduleThread)
				{
					throw new Exception("Terminate Thread");
				}

				long now = watch.ElapsedMilliseconds;
				if ((now - prev >= period) &&
					(now < MS - 30))
				{
					prev = now;
					SendMsg sm = delegate (string state, bool hex)
					{
						lblTime.Text = state.Remove(state.Length - 4, 4);
						return hex;
					};
					Invoke(sm, new object[] { TimeSpan.FromMilliseconds(now).ToString(), false });
				}
			}

			watch.Stop();
			var elapsedMs = watch.ElapsedMilliseconds;

			return;
		}

		private void Delay(long MS, long ElapsedMs)
		{
			System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
			long target = MS - ElapsedMs;
			long prev = watch.ElapsedMilliseconds;
			long period = 10;

			while (target > watch.ElapsedMilliseconds)
			{
				Application.DoEvents();
				if (TerminateScheduleThread)
				{
					throw new Exception("Terminate Thread");
				}

				long now = watch.ElapsedMilliseconds;
				if ((now - prev >= period) &&
					(now < target - 30))
				{
					prev = now;
					SendMsg sm = delegate (string state, bool hex)
					{
						lblTime.Text = state.Remove(state.Length - 4, 4);
						//Text = "Scheculer - Delay " + state;
						return hex;
					};
					Invoke(sm, new object[] { TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds).ToString(), false });
				}
			}

			watch.Stop();
			var elapsedMs = watch.ElapsedMilliseconds;

			return;
		}

		/// <summary>
		/// 스케줄 표 저장/불러오기
		/// </summary>
		public void LoadInit()
		{
			try
			{
				if (File.Exists(".\\schedule.xml"))
				{
					var xdoc = XDocument.Load("schedule.xml");
					var xelements = xdoc.Root.Elements("element");

					foreach(var xList in xelements)
					{
						int index = dgvSchedule.Rows.Add();
						DataGridViewRow row = dgvSchedule.Rows[index];
						XElement element;

						element = xList.Element("type");
						if (element != null) row.Cells["cType"].Value = element.Value;

						element = xList.Element("format");
						if (element != null) row.Cells["cFormat"].Value = Convert.ToBoolean(element.Value);

						element = xList.Element("name");
						if (element != null) row.Cells["cName"].Value = element.Value;

						element = xList.Element("value");
						if (element != null) row.Cells["cValue"].Value = element.Value;

						element = xList.Element("cycle");
						if (element != null) row.Cells["cCycle"].Value = element.Value;

						element = xList.Element("delay_ms");
						if (element != null) row.Cells["cDelayMs"].Value = element.Value;

						element = xList.Element("enable");
						if (element != null) row.Cells["cEnable"].Value = Convert.ToBoolean(element.Value);

						element = xList.Element("send");
						if (element != null) row.Cells["cSend"].Value = element.Value;
					}
				}
			}
			catch
			{

			}
		}
		public void SaveInit()
		{
			try
			{
				var root = new XElement("list");
				
				foreach (DataGridViewRow row in dgvSchedule.Rows)
				{
					var elements = new XElement("element",
						new XElement("type", row.Cells["cType"].Value.ToString()),
						new XElement("format", row.Cells["cFormat"].Value.ToString()),
						new XElement("name", row.Cells["cName"].Value.ToString()),
						new XElement("value", row.Cells["cValue"].Value.ToString()),
						new XElement("cycle", row.Cells["cCycle"].Value.ToString()),
						new XElement("delay_ms", row.Cells["cDelayMs"].Value.ToString()),
						new XElement("enable", row.Cells["cEnable"].Value.ToString()),
						new XElement("send", row.Cells["cSend"].Value.ToString())
					);
					root.Add(elements);
				}
				root.Save("schedule.xml");
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
	}
}
