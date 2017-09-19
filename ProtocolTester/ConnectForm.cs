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
					tabConnect_SelectedIndexChanged(null, null);
					break;
				default:
					tabConnect.SelectedIndex = 0;
					tabConnect_SelectedIndexChanged(null, null);
					break;
			}
		}

		private void btnSerialConnect_Click(object sender, EventArgs e)
		{
			SerialPort port = portObj.CurrentPort as SerialPort;
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
		
		private void tabConnect_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabConnect.SelectedTab == tpSerial)
			{
				portObj.SelectPort(CommType.COMM_SERIAL);

				cbPort.Items.Clear();
				string[] ports = SerialPort.GetPortNames();
				foreach (string item in ports)
				{
					cbPort.Items.Add(item);
				}

				SerialPort port = portObj.CurrentPort as SerialPort;
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
				cbStopBit.SelectedIndex = 0;
				cbFlowControl.SelectedIndex = 0;
			}
		}
	}
}
