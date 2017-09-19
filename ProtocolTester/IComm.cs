using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolTester
{
	public enum CommType
	{
		COMM_SERIAL,
		COMM_TCP_SERVER,
		COMM_TCP_CLIENT,
		COMM_UDP,
		COMM_NONE
	}
	public enum MsgFormat
	{
		MSG_STRING,
		MSG_HEX
	}
	public delegate bool ReceiveHandler(string recvMsg);
	public abstract class IComm
	{
		protected CommType comType;
		public abstract event ReceiveHandler OnRecvMsg;
		public abstract bool IsOpen { get; }
		public abstract object CurrentPort { get; }
		public CommType Type
		{
			get
			{
				return comType;
			}
		}
		public abstract bool OpenPort(object port);
		public abstract void ClosePort();
		public abstract bool SendData(string strMsg, MsgFormat Format);
	}
}
