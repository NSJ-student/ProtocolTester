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
		public event SetSerial setSerial;
		public ConnectForm()
		{
			InitializeComponent();

			cbParity.SelectedIndex = 0;
			cbStopBit.SelectedIndex = 0;
//			cbFlowControl.SelectedIndex = 0;
			cbDataBit.SelectedIndex = 0;
		}

		private void btnSerialConnect_Click(object sender, EventArgs e)
		{
			SerialPort port = new SerialPort();

			port.PortName = (!cbPort.Text.Equals("")) ? cbPort.Text : port.PortName;
			port.BaudRate = (!cbSpeed.Text.Equals("")) ? Convert.ToInt32(cbSpeed.Text) : 115200;
			port.DataBits = Convert.ToInt32(cbDataBit.Text);
			port.Parity = (Parity)cbParity.SelectedIndex;
			switch(cbStopBit.SelectedIndex)
			{
				case 0: port.StopBits = StopBits.One; break;
				case 1: port.StopBits = StopBits.OnePointFive; break;
				case 2: port.StopBits = StopBits.Two; break;
				default: port.StopBits = StopBits.One; break;
			}
			port.RtsEnable = false;

			if (setSerial.Invoke(port))
			{
				if (cbPort.FindString(port.PortName) < 0)
					cbPort.Items.Add(port.PortName);
				if (cbSpeed.FindString(port.BaudRate.ToString()) < 0)
					cbSpeed.Items.Add(port.BaudRate.ToString());
			}

			Visible = false;
		}

		private void ConnectForm_VisibleChanged(object sender, EventArgs e)
		{
			if(Visible)
			{
				cbPort.Items.Clear();

				string[] ports = SerialPort.GetPortNames();
				foreach (string item in ports)
				{
					cbPort.Items.Add(item);
				}
			}
		}
	}
}
