using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace ProtocolTester
{
	public delegate bool SendMsg(string msg, bool ishex);
	public delegate void UpdateMsg(byte[] msg);
	public delegate void UpdateLog(object obj, string text);
	public delegate void UpdateButton(bool open);
	public partial class Form1 : Form
	{
		DateTime AppStartTime;
		PortObjects commObj;
		CommSettings commSettings;
		CommScheduler commSchedule;
		public Form1()
		{
			InitializeComponent();

			AppStartTime = DateTime.Now;

			commSchedule = new CommScheduler(Port_Send);
			commSchedule.LoadInit();

			commSettings = new CommSettings();
			commSettings.LoadInit();

			commObj = new PortObjects();
			commObj.OnRecvMsg += UpdateUI_Receive;
			commObj.OnOpenClose += UpdateUI_OpenClose;
			commObj.OnLogAdded += UpdateUI_Log;
			commObj.LoadInit();

			btnSend.Enabled = false;
		}
		
		/// <summary>
		/// UI의 메시지 전송 명령 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSend_Click(object sender, EventArgs e)
		{
			string SendMsg = txtStartMsg.Text + txtSendMsg.Text + txtEndMsg.Text;
			Port_Send(SendMsg, rbSendHex.Checked);
			txtSendMsg.Clear();
		}
		private void txtSendMsg_KeyUp(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode == Keys.Enter) &&
				(btnSend.Enabled == true))
			{
				string SendMsg = txtStartMsg.Text + txtSendMsg.Text + txtEndMsg.Text;
				Port_Send(SendMsg, rbSendHex.Checked);
				txtSendMsg.Clear();
			}
		}

		/// <summary>
		/// 통신 내용을 표시하는 로그창 클리어
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnLogClear_Click(object sender, EventArgs e)
		{
			rtbLog.Clear();
		}

		/// <summary>
		/// 통신 연결
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConnect_Click(object sender, EventArgs e)
		{
			if (btnConnect.Text.Equals("Connect"))
			{
				ConnectForm form = new ConnectForm(commObj);
				if(form.ShowDialog() == DialogResult.OK)
				{
					btnConnect.Text = "Close";
				}
			}
			else
			{
				if ((commObj != null) && (commObj.IsOpen))
				{
					commObj.ClosePort();
				}
				btnConnect.Text = "Connect";
			}
		}
		
		/// <summary>
		/// 통신 포트 open/close/rx/tx에 대한 UI 처리
		/// </summary>
		/// <param name="rxMsg"></param>
		/// <returns></returns>
		private bool UpdateUI_Receive(byte[] rxMsg)
		{
			UpdateMsg uc = delegate (byte[] text)
			{
				string TotalMsg = "";
				string SendMsg = "";
				if (rbRxMsgASCII.Checked)
				{
					SendMsg = Encoding.Default.GetString(text);
				}
				else
				{
					SendMsg = KeyParser.AnyByteToHexString(text);
					if (SendMsg == null)
						return;
				}

				if (commSettings.ShowTxRxTime != 0)
				{
					if (commSettings.ShowTxRxTime == 5)
					{
						TotalMsg += "[" + DateTime.Now.Subtract(AppStartTime).TotalMilliseconds.ToString("F0") + "]";
					}
					else
					{
						TotalMsg += "[" + DateTime.Now.ToString(CommSettings.TimeType[commSettings.ShowTxRxTime]) + "]";
					}
				}

				if (commSettings.ShowTxRxSymbol)
				{
					TotalMsg += commSettings.RxSymbol;
				}

				TotalMsg += SendMsg;

				if (commSettings.LineFeedOnEnd)
				{
					TotalMsg += "\n";
				}

				rtbLog.AppendText(TotalMsg);

				if (commSettings.AutoScroll)
				{
					rtbLog.ScrollToCaret();
				}
			};

			if (rtbLog.InvokeRequired)
			{
				Invoke(uc, new object[] { rxMsg });
				return true;
			}
			else
			{
				uc(rxMsg);
			}
			return true;
		}
		private void UpdateUI_OpenClose(bool IsOpen)
		{
			UpdateButton uc = delegate (bool IsTrue) {
				if (IsTrue)
				{
					btnSend.Enabled = true;
					btnConnect.Text = "Close";
				}
				else
				{
					btnSend.Enabled = false;
					if ((commObj != null) && (!commObj.IsOpen))
					{
						btnConnect.Text = "Connect";
					}
				}
			};
			Invoke(uc, new object[] { IsOpen });
		}
		private void UpdateUI_Log(object Obj, string log)
		{
			try
			{
				UpdateLog uc = delegate (object obj, string text) {
					File.AppendAllText(".\\Log.txt", Obj.ToString() + ">>\t" + log + "\r\n");
				};
				Invoke(uc, new object[] { Obj, log });
			}
			catch
			{

			}
		}
		private void UpdateUI_Send(byte[] TxMsg)
		{
			UpdateMsg uc = delegate (byte[] text)
			{
				string TotalMsg = "";
				string SendMsg = "";
				if (rbRxMsgASCII.Checked)
				{
					SendMsg = Encoding.Default.GetString(text);
					if (SendMsg == null)
					{
						if (txtSendMsg.BackColor != Color.LightPink)
							txtSendMsg.BackColor = Color.LightPink;
						return;
					}
				}
				else
				{
					SendMsg = KeyParser.AnyByteToHexString(text);
					if (SendMsg == null)
					{
						if (txtSendMsg.BackColor != Color.LightPink)
							txtSendMsg.BackColor = Color.LightPink;
						return;
					}
				}

				if (commSettings.ShowTxRxTime != 0)
				{
					if (commSettings.ShowTxRxTime == 5)
					{
						TotalMsg += "[" + DateTime.Now.Subtract(AppStartTime).TotalMilliseconds.ToString("F0") + "]";
					}
					else
					{
						TotalMsg += "[" + DateTime.Now.ToString(CommSettings.TimeType[commSettings.ShowTxRxTime]) + "]";
					}
				}

				if (commSettings.ShowTxRxSymbol)
				{
					TotalMsg += commSettings.TxSymbol;
				}

				TotalMsg += SendMsg;

				if (commSettings.LineFeedOnEnd)
				{
					TotalMsg += "\n";
				}

				rtbLog.AppendText(TotalMsg);

				if (commSettings.AutoScroll)
				{
					rtbLog.ScrollToCaret();
				}
			};

			if (rtbLog.InvokeRequired)
			{
				Invoke(uc, new object[] { TxMsg });
			}
			else
			{
				uc(TxMsg);
			}

			if (txtSendMsg.BackColor != SystemColors.Window)
				txtSendMsg.BackColor = SystemColors.Window;
		}

		/// <summary>
		/// 열린 통신 포트로 메시지 송신
		/// </summary>
		/// <param name="TxMsg"></param>
		/// <param name="ishex"></param>
		/// <returns></returns>
		private bool Port_Send(string TxMsg, bool ishex)
		{
			if ((commObj != null) && (commObj.IsOpen))
			{
				byte[] Msg;
				if (!ishex)
				{
					Msg = KeyParser.AsciiStringToHexByte(TxMsg);
					if (Msg == null)
					{
						if(txtSendMsg.BackColor != Color.LightPink)
							txtSendMsg.BackColor = Color.LightPink;
						return false;
					}
				}
				else
				{
					Msg = KeyParser.HexStringToHexByte(TxMsg);
					if (Msg == null)
					{
						if (txtSendMsg.BackColor != Color.LightPink)
							txtSendMsg.BackColor = Color.LightPink;
						return false;
					}
				}

				commObj.SendData(Msg, MsgFormat.MSG_STRING);

				UpdateUI_Send(Msg);
				return true;
			}
			return false;
		}

		/// <summary>
		/// 송신 포맷이 바뀔 때 송신 메시지 창의 포맷이 바뀌도록 설정
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbSendHex_CheckedChanged(object sender, EventArgs e)
		{
			if(rbSendASCII.Checked)
			{
				txtSendMsg.Text = KeyParser.HexStringToAsciiString(txtSendMsg.Text);
				txtStartMsg.Text = KeyParser.HexStringToAsciiString(txtStartMsg.Text);
				txtEndMsg.Text = KeyParser.HexStringToAsciiString(txtEndMsg.Text);
			}
			else
			{
				txtSendMsg.Text = KeyParser.AsciiStringToHexString(txtSendMsg.Text);
				txtStartMsg.Text = KeyParser.AsciiStringToHexString(txtStartMsg.Text);
				txtEndMsg.Text = KeyParser.AsciiStringToHexString(txtEndMsg.Text);
			}
		}

		/// <summary>
		/// 프로그램 세팅 적용
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSettings_Click(object sender, EventArgs e)
		{
			SettingControl control = new SettingControl(commSettings, UpdateSettings);
			if(control.ShowDialog() == DialogResult.OK)
			{

			}
			else
			{

			}
		}
		private void UpdateSettings(CommSettings setting)
		{
			commSettings = setting;
		}

		/// <summary>
		/// radio button에 따라 송신 메시지 입력창에 HEX 입력만 가능하도록 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtSendMsg_KeyPress(object sender, KeyPressEventArgs e)
		{
			if(rbSendHex.Checked)
			{
				if(!KeyParser.IsHex(e.KeyChar))
				{
					e.Handled = true;
				}
			}
		}
		private void txtStartMsg_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (rbSendHex.Checked)
			{
				if (!KeyParser.IsHex(e.KeyChar))
				{
					e.Handled = true;
				}
			}
		}
		private void txtEndMsg_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (rbSendHex.Checked)
			{
				if (!KeyParser.IsHex(e.KeyChar))
				{
					e.Handled = true;
				}
			}
		}

		/// <summary>
		/// 창을 닫을 때 통신 스레드 종료
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			File.Create(".\\Init.txt").Close();
			commSchedule.SaveInit();
			commSettings.SaveInit();
			commObj.SaveInit();
			if (btnConnect.Text.Equals("Close"))
			{
				if ((commObj != null) && (commObj.IsOpen))
				{
					commObj.ClosePort();
				}
			}
		}

		/// <summary>
		/// 송신 스케줄러 창 띄우기
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnShortKey_Click(object sender, EventArgs e)
		{
			commSchedule.Show();
		}

		/// <summary>
		/// 수신 메시지 로그 출력 포맷 변경
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbRxMsgHex_CheckedChanged(object sender, EventArgs e)
		{
			if(rbRxMsgASCII.Checked)
			{
				Color oldColor = rtbLog.SelectionColor;
				rtbLog.SelectionColor = Color.Red;
				rtbLog.AppendText("\n** To ASCII **\n");
				rtbLog.SelectionColor = oldColor;
			}
			else
			{
				Color oldColor = rtbLog.SelectionColor;
				rtbLog.SelectionColor = Color.Red;
				rtbLog.AppendText("\n** To Hex **\n");
				rtbLog.SelectionColor = oldColor;
			}
		}

	}
}
