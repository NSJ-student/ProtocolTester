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
	public delegate void DoDock(bool on_show);
	public partial class CommScheduler : Form
	{
		private bool TerminateScheduleThread;
		private Thread ScheduleTask;
		private DoDock WindowDock;
		private SendMsg SendstrMsg;

		public enum TypeNum
		{
			TYPE_SEND,
			TYPE_DELAY
		}
		public bool Docking
		{
			get
			{
				return dockingToolStripMenuItem.Checked;
			}
		}
		public CommScheduler(SendMsg SendEvent, bool dock, DoDock DoDock)
		{
			InitializeComponent();
			SendstrMsg = SendEvent;
			dockingToolStripMenuItem.Checked = dock;
			WindowDock = DoDock;
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
				foreach(DataGridViewRow row in dgvSchedule.SelectedRows)
				{
					dgvSchedule.Rows.Remove(row);
				}
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
				DataGridViewRow[] rows = new DataGridViewRow[dgvSchedule.Rows.Count];
				
				int minIdx = dgvSchedule.SelectedRows[0].Index;
				foreach (DataGridViewRow row in dgvSchedule.SelectedRows)
				{
					if(minIdx > row.Index) minIdx = row.Index;
					rows[row.Index] = row;
				}
				foreach (DataGridViewRow row in dgvSchedule.SelectedRows)
				{
					dgvSchedule.Rows.Remove(row);
				}

				var selected = from n in rows
							   where n != null
							   select n;
				dgvSchedule.ClearSelection();
				if (minIdx > 0)
				{
					dgvSchedule.Rows.InsertRange(minIdx - 1, selected.ToArray<DataGridViewRow>());
				}
				else
				{
					dgvSchedule.Rows.InsertRange(0, selected.ToArray<DataGridViewRow>());
				}
				DataGridViewRow temp = null;
				if (dgvSchedule.SelectedRows.Count > 0)
					temp = dgvSchedule.SelectedRows[0];
				foreach (DataGridViewRow row in selected)
				{
					row.Selected = true;
				}
				if (temp != null)
					temp.Selected = false;
			}
		}

		private void btnDown_Click(object sender, EventArgs e)
		{
			if (dgvSchedule.SelectedRows.Count > 0)
			{
				DataGridViewRow[] rows = new DataGridViewRow[dgvSchedule.Rows.Count];

				int maxIdx = dgvSchedule.SelectedRows[0].Index;
				int total = dgvSchedule.Rows.Count;
				foreach (DataGridViewRow row in dgvSchedule.SelectedRows)
				{
					if (maxIdx < row.Index) maxIdx = row.Index;
					rows[row.Index] = row;
				}
				DataGridViewRow last = null;
				if (maxIdx < total - 1)
					last = dgvSchedule.Rows[maxIdx + 1];
				foreach (DataGridViewRow row in dgvSchedule.SelectedRows)
				{
					dgvSchedule.Rows.Remove(row);
				}

				var selected = from n in rows
							   where n != null
							   select n;
				dgvSchedule.ClearSelection();
				if (last == null)
				{
					dgvSchedule.Rows.AddRange(selected.ToArray<DataGridViewRow>());
				}
				else
				{
					dgvSchedule.Rows.InsertRange(last.Index + 1, selected.ToArray<DataGridViewRow>());
				}
				DataGridViewRow temp = null;
				if (dgvSchedule.SelectedRows.Count > 0)
					temp = dgvSchedule.SelectedRows[0];
				foreach (DataGridViewRow row in selected)
				{
					row.Selected = true;
				}
				if(temp != null)
					temp.Selected = false;
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
			else if((dgvSchedule.Columns["cName"].Index <= e.ColumnIndex) &&
					(e.ColumnIndex <= dgvSchedule.Columns["cDelayMs"].Index))
			{
				if(dgvSchedule.CurrentCell.RowIndex == e.RowIndex)
				{
					dgvSchedule.BeginEdit(true);
				}
//				dgvSchedule.CurrentCell = dgvSchedule[e.ColumnIndex, e.RowIndex];

			}
		}

		/// <summary>
		/// Type 값 선택, 문자열 format 변경
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgvSchedule_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			// Type값이 선택됨
			if (e.ColumnIndex == 1)
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
			if (e.ColumnIndex == 2)
			{
				if (e.RowIndex >= 0)
				{
					DataGridViewRow row = dgvSchedule.Rows[e.RowIndex];
					bool check = (bool)row.Cells["cFormat"].Value;
					string str = (string)row.Cells["cValue"].Value;
					if (str == null) return;

					if (check)
					{
						row.Cells["cValue"].Value =
							KeyParser.AsciiStringToHexString(str);
					}
					else
					{
						row.Cells["cValue"].Value =
							KeyParser.HexStringToAsciiString(str);
					}
				}
			}
		}
		
		private void dgvSchedule_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			dgvSchedule.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}

		private void dgvSchedule_CurrentCellDirtyStateChanged(object sender, EventArgs e)
		{
			if (dgvSchedule.CurrentCell is DataGridViewCheckBoxCell)
			{
				dgvSchedule.CommitEdit(DataGridViewDataErrorContexts.Commit);
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
		
		/// <summary>
		/// 우클릭 메뉴 - parent 윈도우에 docking
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dockingToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			WindowDock(true);
		}

	}
}
