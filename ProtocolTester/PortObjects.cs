using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolTester
{
	public class PortObjects : IComm
	{
		IComm CurrentComPort;
		SerialCom SerialComPort;
		public override event ReceiveHandler OnRecvMsg;
		public override bool IsOpen
		{
			get
			{
				return (CurrentComPort != null) ? CurrentComPort.IsOpen : false;
			}
		}
		public override object CurrentPort
		{
			get
			{
				return CurrentComPort.CurrentPort;
			}
		}

		public PortObjects()
		{
			comType = CommType.COMM_NONE;
			SerialComPort = new SerialCom();
			CurrentComPort = null;
		}

		public bool SelectPort(CommType type)
		{
			switch(type)
			{
				case CommType.COMM_SERIAL: CurrentComPort = SerialComPort; return true;
				default: CurrentComPort = null;  return false;
			}
		}
		public override bool OpenPort(object port)
		{
			bool ret = false;

			if(CurrentComPort != null)
			{
				CurrentComPort.OnRecvMsg += RecvData;
				ret = CurrentComPort.OpenPort(port);
			}

			return ret;
		}
		public override void ClosePort()
		{
			if (CurrentComPort != null)
			{
				CurrentComPort.ClosePort();
				CurrentComPort = null;
			}
		}

		public override bool SendData(string strMsg, MsgFormat Format)
		{
			bool ret = false;

			if (CurrentComPort != null)
				ret = CurrentComPort.SendData(strMsg, Format);

			return ret;
		}

		private bool RecvData(string rxData)
		{
			return OnRecvMsg(rxData);
		}
	}
}
