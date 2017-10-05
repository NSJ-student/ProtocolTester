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
		TcpServerCom TcpServerComPort;
		TcpClientCom TcpClientComPort;
		public event ReceiveHandler OnRecvMsg;
		public event OpenCloseHandler OnOpenClose;
		public event LogHandler OnLogAdded;

		public CommType Type
		{
			get
			{
				if (CurrentComPort == null)
					return CommType.COMM_NONE;
				else
					return CurrentComPort.Type;
			}
		}
		public bool IsOpen
		{
			get
			{
				return (CurrentComPort != null) ? CurrentComPort.IsOpen : false;
			}
		}
		public object CurrentPort
		{
			get
			{
				return CurrentComPort.CurrentPort;
			}
		}

		public PortObjects()
		{
			SerialComPort = new SerialCom();
			TcpServerComPort = new TcpServerCom();
			TcpClientComPort = new TcpClientCom();

			SerialComPort.OnRecvMsg += RecvData;
			TcpServerComPort.OnRecvMsg += RecvData;
			TcpClientComPort.OnRecvMsg += RecvData;

			SerialComPort.OnOpenClose += OpenCloseControl;
			TcpServerComPort.OnOpenClose += OpenCloseControl;
			TcpClientComPort.OnOpenClose += OpenCloseControl;

			SerialComPort.OnLogAdded += LogData;
			TcpServerComPort.OnLogAdded += LogData;
			TcpClientComPort.OnLogAdded += LogData;

			CurrentComPort = null;
		}

		public bool SelectPort(CommType type)
		{
			switch(type)
			{
				case CommType.COMM_SERIAL: CurrentComPort = SerialComPort; return true;
				case CommType.COMM_TCP_SERVER: CurrentComPort = TcpServerComPort; return true;
				case CommType.COMM_TCP_CLIENT: CurrentComPort = TcpClientComPort; return true;
				default: CurrentComPort = null;  return false;
			}
		}
		public object GetPort(CommType type)
		{
			switch (type)
			{
				case CommType.COMM_SERIAL: return SerialComPort.CurrentPort;
				case CommType.COMM_TCP_SERVER: return TcpServerComPort.CurrentPort;
				case CommType.COMM_TCP_CLIENT: return TcpClientComPort.CurrentPort;
				default: return null;
			}
		}
		public bool OpenPort(object port)
		{
			bool ret = false;

			if(CurrentComPort != null)
			{
				ret = CurrentComPort.OpenPort(port);
			}

			return ret;
		}
		public void ClosePort()
		{
			if (CurrentComPort != null)
			{
				CurrentComPort.ClosePort();
//				CurrentComPort = null;
			}
		}

		public bool SendData(byte[] Msg, MsgFormat Format)
		{
			bool ret = false;

			if (CurrentComPort != null)
				ret = CurrentComPort.SendData(Msg, Format);

			return ret;
		}

		private bool RecvData(byte[] rxData)
		{
			return OnRecvMsg(rxData);
		}
		private void OpenCloseControl(bool IsOpen)
		{
			OnOpenClose(IsOpen);
		}
		private void LogData(object Obj, string Log)
		{
			OnLogAdded(Obj, Log);
		}
	}
}
