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
	public delegate void UpdateMsg(byte[] msg);
	public delegate void UpdateLog(object obj, string text);
	public delegate void UpdateButton(bool open);
	public partial class Form1 : Form
	{
		PortObjects commObj;
		CommSettings commSettings;
		public Form1()
		{
			InitializeComponent();
			commSettings = new CommSettings();
			commObj = new PortObjects();
			commObj.OnRecvMsg += PortMsg_Received;
			commObj.OnOpenClose += Port_OpenClose;
			commObj.OnLogAdded += Port_Log;
			btnSend.Enabled = false;
		}
		
		private void btnSend_Click(object sender, EventArgs e)
		{
			if((commObj != null) && (commObj.IsOpen))
			{
				commObj.SendData(txtSendMsg.Text, MsgFormat.MSG_STRING);
				string SendMsg = txtSendMsg.Text;
				if (commSettings.ShowTxRxSymbol)
				{
					SendMsg = commSettings.TxSymbol + SendMsg;
				}
				if (commSettings.LineFeedOnEnd)
				{
					SendMsg += "\n";
				}
				rtbLog.AppendText(SendMsg);
				txtSendMsg.Clear();
			}
		}
		private void txtSendMsg_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if ((commObj != null) && (commObj.IsOpen))
				{
					commObj.SendData(txtSendMsg.Text, MsgFormat.MSG_STRING);
					string SendMsg = txtSendMsg.Text;
					if (commSettings.ShowTxRxSymbol)
					{
						SendMsg = commSettings.TxSymbol + SendMsg;
					}
					if (commSettings.LineFeedOnEnd)
					{
						SendMsg += "\n";
					}
					rtbLog.AppendText(SendMsg);
					txtSendMsg.Clear();
				}
			}
		}
		private void btnLogClear_Click(object sender, EventArgs e)
		{
			rtbLog.Clear();
		}

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
		
		private bool PortMsg_Received(byte[] rxMsg)
		{
			if (rtbLog.InvokeRequired)
			{
				UpdateMsg uc = delegate(byte[] text)
				{
					string msg = Encoding.Default.GetString(text);
					if (commSettings.ShowTxRxSymbol)
					{
						msg = commSettings.RxSymbol + msg;
					}
					if (commSettings.LineFeedOnEnd)
					{
						msg += "\n";
					}
					rtbLog.AppendText(msg);
				};
				Invoke(uc, new object[] { rxMsg });
				return true;
			}
			else
			{
				string msg = Encoding.Default.GetString(rxMsg);
				rtbLog.AppendText(msg);
			}
			return true;
		}
		private void Port_OpenClose(bool IsOpen)
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
				}
			};
			Invoke(uc, new object[] { IsOpen });
		}
		private void Port_Log(object Obj, string log)
		{
			UpdateLog uc = delegate (object obj, string text) {
				File.AppendAllText(".\\Log.txt", Obj.ToString() + ">>\t" + log + "\r\n");
			};
			Invoke(uc, new object[] { Obj, log });
		}
		

		private void rbRxMsgASCII_Click(object sender, EventArgs e)
		{

		}
		private void rbRxMsgHex_Click(object sender, EventArgs e)
		{

		}

		private void rbSendASCII_Click(object sender, EventArgs e)
		{
			string[] chars = txtSendMsg.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			string toAscii = "";
			foreach (string item in chars)
			{
				int integer = Convert.ToInt32(item, 16);
				char character = Convert.ToChar(integer);
				toAscii += character;
			}
			txtSendMsg.Text = toAscii;
		}
		private void rbSendHex_Click(object sender, EventArgs e)
		{
			string text = txtSendMsg.Text;
			string toHex = "";
			foreach (char item in text)
			{
				byte integer = Convert.ToByte(item);
				toHex += integer.ToString("X") + " ";
			}
			txtSendMsg.Text = toHex;
		}

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
	}
}
