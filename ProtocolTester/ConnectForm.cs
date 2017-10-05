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
using System.Net;
using System.Net.Sockets;

namespace ProtocolTester
{
	public partial class ConnectForm : Form
	{
		PortObjects portObj;
		public ConnectForm(IComm ComInfo)
		{
			InitializeComponent();
			portObj = ComInfo as PortObjects;
			switch(portObj.Type)
			{
				case CommType.COMM_SERIAL:
					tabConnect.SelectedIndex = 0;
					break;
				case CommType.COMM_TCP_CLIENT:
					rbTcpClient.Checked = true;
					rbTcpServer.Checked = false;
					tabConnect.SelectedIndex = 1;
					break;
				case CommType.COMM_TCP_SERVER:
					rbTcpServer.Checked = true;
					rbTcpClient.Checked = false;
					tabConnect.SelectedIndex = 1;
					break;
				default:
					tabConnect.SelectedIndex = 0;
					break;
			}
			UpdateControls();
		}

		/// <summary>
		/// 이전 통신 포트 설정에 따라 설정 컨트롤 업데이트
		/// </summary>
		private void UpdateControls()
		{
			// Update Serial Tab
			cbPort.Items.Clear();
			string[] ports = SerialPort.GetPortNames();
			foreach (string item in ports)
			{
				cbPort.Items.Add(item);
			}

			SerialPort port = portObj.GetPort(CommType.COMM_SERIAL) as SerialPort;
			if (port != null)
			{
				cbPort.Text = port.PortName;
				cbSpeed.Text = port.BaudRate.ToString();
				cbParity.SelectedIndex = (int)port.Parity;
				switch (port.StopBits)
				{
					case StopBits.One:
						cbStopBit.SelectedIndex = 0;
						break;
					case StopBits.OnePointFive:
						cbStopBit.SelectedIndex = 1;
						break;
					case StopBits.Two:
						cbStopBit.SelectedIndex = 2;
						break;
					default:
						cbStopBit.SelectedIndex = 0;
						break;
				}
				cbDataBit.Text = port.DataBits.ToString();
			}
			else
			{
				cbSpeed.Text = "115200";
				cbParity.SelectedIndex = 0;
				cbStopBit.SelectedIndex = 0;
				cbDataBit.SelectedIndex = 3;
			}
			cbFlowControl.SelectedIndex = 0;

			// Update Tcp Tab - Server
			cbServerIP.SelectedIndex = 0;
			IPEndPoint serverport = portObj.GetPort(CommType.COMM_TCP_SERVER) as IPEndPoint;
			if (serverport != null)
			{
				cbServerIP.Text = serverport.Address.ToString();
				if (rbTcpServer.Checked)
					txtPort.Text = serverport.Port.ToString();
			}
			// Update Tcp Tab - Client
			IPEndPoint clientport = portObj.GetPort(CommType.COMM_TCP_CLIENT) as IPEndPoint;
			if (clientport != null)
			{
				txtClientIP.Text = clientport.Address.ToString();
				if (rbTcpClient.Checked || txtPort.Text.Equals(""))
					txtPort.Text = clientport.Port.ToString();
			}

			if (rbTcpServer.Checked)
			{
				txtClientIP.Enabled = false;
				cbServerIP.Enabled = true;
			}
			else
			{
				txtClientIP.Enabled = true;
				cbServerIP.Enabled = false;
			}
		}

		/// <summary>
		/// Serial connect 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSerialConnect_Click(object sender, EventArgs e)
		{
			SerialPort port = portObj.GetPort(CommType.COMM_SERIAL) as SerialPort;
			if(port == null)
			{
				port = new SerialPort();
			}

			try
			{
				port.PortName = cbPort.Text;
				port.BaudRate = Convert.ToInt32(cbSpeed.Text);
				port.DataBits = Convert.ToInt32(cbDataBit.Text);
				port.Parity = (Parity)cbParity.SelectedIndex;
				switch (cbStopBit.SelectedIndex)
				{
					case 0: port.StopBits = StopBits.One; break;
					case 1: port.StopBits = StopBits.OnePointFive; break;
					case 2: port.StopBits = StopBits.Two; break;
					default: port.StopBits = StopBits.One; break;
				}
				port.RtsEnable = false;

				portObj.SelectPort(CommType.COMM_SERIAL);
				if (portObj.OpenPort(port))
				{
					DialogResult = DialogResult.OK;
				}
				else
				{
					DialogResult = DialogResult.Abort;
					Visible = false;
					MessageBox.Show("Can't Open [ " + cbPort.Text + " ]");
				}

				Close();
			}
			catch(Exception en)
			{
				MessageBox.Show(en.Message);
				DialogResult = DialogResult.Abort;
				Close();
			}
		}

		/// <summary>
		/// TCP connect 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnTcpConnect_Click(object sender, EventArgs e)
		{
			if (rbTcpServer.Checked)
			{
				string[] split = cbServerIP.Text.Split(new char[] { ' ' });
				try
				{
					IPAddress ip = IPAddress.Parse(split[0]);
					int port = Convert.ToInt32(txtPort.Text);

					portObj.SelectPort(CommType.COMM_TCP_SERVER);
					IPEndPoint iep = new IPEndPoint(ip, port);
					if (portObj.OpenPort(iep))
					{
						DialogResult = DialogResult.OK;
					}
					else
					{
						DialogResult = DialogResult.Abort;
						Visible = false;
						MessageBox.Show("Can't Open [ Port: " + txtPort.Text + " ]");
					}

					Close();
				}
				catch (Exception en)
				{
					MessageBox.Show(en.Message);
					DialogResult = DialogResult.Abort;
					Close();
				}
			}
			if (rbTcpClient.Checked)
			{
				string[] split = txtClientIP.Text.Split(new char[] { ' ' });
				try
				{
					IPAddress ip = IPAddress.Parse(split[0]);
					int port = Convert.ToInt32(txtPort.Text);

					portObj.SelectPort(CommType.COMM_TCP_CLIENT);
					IPEndPoint iep = new IPEndPoint(ip, port);
					if (portObj.OpenPort(iep))
					{
						DialogResult = DialogResult.OK;
					}
					else
					{
						DialogResult = DialogResult.Abort;
						Visible = false;
						MessageBox.Show("Can't Open [ Port: " + txtPort.Text + " ]");
					}

					Close();
				}
				catch (Exception en)
				{
					MessageBox.Show(en.Message);
					DialogResult = DialogResult.Abort;
					Close();
				}
			}
		}

		private void txtPort_KeyUp(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
				btnTcpConnect_Click(null, null);
		}

		private void txtClientIP_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				btnTcpConnect_Click(null, null);
		}

		/// <summary>
		/// TCP 서버/클라이언트 선택에 따라 활성화되는 컨트롤 변경
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbTcpServer_Click(object sender, EventArgs e)
		{
			txtClientIP.Enabled = false;
			cbServerIP.Enabled = true;
		}

		private void rbTcpClient_Click(object sender, EventArgs e)
		{
			txtClientIP.Enabled = true;
			cbServerIP.Enabled = false;
		}

	}
}
