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

namespace ProtocolTester
{
	public delegate void UpdateControl(string text);
	public partial class Form1 : Form
	{
		PortObjects commObj;
		public Form1()
		{
			InitializeComponent();
			commObj = new PortObjects();
			commObj.OnRecvMsg += PortMsg_Received;
			btnSend.Enabled = false;
		}

		private void btnSend_Click(object sender, EventArgs e)
		{
			if((commObj != null) && (commObj.IsOpen))
			{
				commObj.SendData(txtSendMsg.Text, MsgFormat.MSG_STRING);
				rtbLog.AppendText(txtSendMsg.Text);
				txtSendMsg.Clear();
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
					btnSend.Enabled = true;
					btnConnect.Text = "Close";
				}
			}
			else
			{
				if ((commObj != null) && (commObj.IsOpen))
				{
					commObj.ClosePort();
				}
				btnSend.Enabled = false;
				btnConnect.Text = "Connect";
			}
		}

		private void cbFormat_CheckedChanged(object sender, EventArgs e)
		{
			if(cbFormat.Checked)
			{
				string text = txtSendMsg.Text;
				string toHex = "";
				foreach(char item in text)
				{
					byte integer = Convert.ToByte(item);
					toHex += integer.ToString("X") + " ";
				}
				txtSendMsg.Text = toHex;
			}
			else
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
		}

		private bool PortMsg_Received(string rxMsg)
		{
			if(rtbLog.InvokeRequired)
			{
				UpdateControl uc = delegate(string text) { rtbLog.AppendText(text); };
				Invoke(uc, new object[] { "In => " + rxMsg });
				return true;
			}
			else
			{
				rtbLog.AppendText("In => " + rxMsg);
			}
			return true;
		}
	}
}
