using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

namespace ProtocolTester
{
	class SerialCom : IComm
	{
		SerialPort PortInfo;
		Thread rxThread;
		public override event ReceiveHandler OnRecvMsg;
		public override bool IsOpen
		{
			get
			{
				return (PortInfo != null) ? PortInfo.IsOpen : false;
			}
		}
		public override object CurrentPort
		{
			get
			{
				return PortInfo;
			}
		}
		public SerialCom()
		{
			comType = CommType.COMM_SERIAL;
			PortInfo = null;
			ThreadStart ts = new ThreadStart(ReadMsg);
			rxThread = new Thread(ts);
		}
		public SerialCom(SerialPort port)
		{
			comType = CommType.COMM_SERIAL;
			PortInfo = port;
			ThreadStart ts = new ThreadStart(ReadMsg);
			rxThread = new Thread(ts);
		}

		public override bool OpenPort(object port)
		{
			PortInfo = port as SerialPort;

			try
			{
				PortInfo.Open();
				rxThread.Start();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public override void ClosePort()
		{
			if(PortInfo.IsOpen)
			{
				if(rxThread.IsAlive)
				{
					rxThread.Abort();
				}
				PortInfo.Close();
			}
		}

		public override bool SendData(string strMsg, MsgFormat Format)
		{
			if(IsOpen)
			{
				PortInfo.Write(strMsg);
				return true;
			}
			else
			{
				return false;
			}
		}

		private void ReadMsg()
		{
			while(PortInfo.IsOpen)
			{
				if(PortInfo.BytesToRead > 0)
				{
					string reads = PortInfo.ReadExisting();
					OnRecvMsg(reads);
				}
				Thread.Sleep(10);
			}
		}
	}
}
