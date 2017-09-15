using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace ProtocolTester
{
	public delegate bool SetSerial(SerialPort port);
	class SerialCom : IComm
	{
		SerialPort PortInfo;
		public override bool IsOpen
		{
			get
			{
				return PortInfo.IsOpen;
			}
		}
		public SerialCom(SerialPort port)
		{
			comType = CommType.COMM_SERIAL;
			PortInfo = port;
			try
			{
				port.Open();
			}
			catch
			{
				
			}
		}
		public override void ClosePort()
		{
			if(PortInfo.IsOpen)
			{
				PortInfo.Close();
			}
		}
	}
}
