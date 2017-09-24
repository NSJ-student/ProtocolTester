﻿using System;
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
	public delegate bool ReceiveHandler(byte[] recvMsg);
	public delegate void OpenCloseHandler(bool IsOpen);
	public delegate void LogHandler(object Obj, string Log);
	public interface IComm
	{
		event ReceiveHandler OnRecvMsg;
		event OpenCloseHandler OnOpenClose;
		event LogHandler OnLogAdded;
		bool IsOpen { get; }
		object CurrentPort { get; }
		CommType Type { get; }
		bool OpenPort(object port);
		void ClosePort();
		bool SendData(string strMsg, MsgFormat Format);
	}
}