using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace ProtocolTester
{
	class TcpClientCom : IComm
	{
		IPEndPoint ClientIP;
		Socket ClientSock;
		Thread ClientThread;
		ThreadStart ts;

		public object CurrentPort
		{
			get
			{
				if (ClientIP != null)
					return ClientIP as IPEndPoint;
				else
					return null;
			}
		}

		public bool IsOpen
		{
			get
			{
				if (ClientSock != null)
					return ClientSock.Connected;
				else
					return false;
			}
		}

		public CommType Type
		{
			get
			{
				return CommType.COMM_TCP_CLIENT;
			}
		}

		public event ReceiveHandler OnRecvMsg;
		public event OpenCloseHandler OnOpenClose;
		public event LogHandler OnLogAdded;

		public TcpClientCom()
		{
			ts = new ThreadStart(RxClientMsg);
		}

		public bool OpenPort(object port)
		{
			try
			{
				ClientIP = port as IPEndPoint;
				ClientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				ClientSock.Connect(ClientIP);

				OnOpenClose(true);
				ClientThread = new Thread(ts);
				ClientThread.Start();
				return true;
			}
			catch (Exception es)
			{
				OnLogAdded(this, "*** Open Error : " + es.Message);
				return false;
			}
		}
		public void ClosePort()
		{
			try
			{
				if (ClientSock.Connected)
					ClientSock.Close();
				if (ClientThread.IsAlive)
					ClientThread.Abort();
				OnOpenClose(false);
			}
			catch (Exception es)
			{
				OnLogAdded(this, "*** Close Error : " + es.Message);
			}
		}
		public bool SendData(byte[] Msg, MsgFormat Format)
		{
			if (IsOpen)
			{
				//byte[] sendData = Encoding.Default.GetBytes(strMsg);
				ClientSock.Send(Msg);
				return true;
			}
			else
			{
				return false;
			}
		}
		private void RxClientMsg()
		{
			try
			{
				while (IsOpen)
				{
					if (ClientSock.Available > 0)
					{
						byte[] data = new byte[ClientSock.Available];
						int rxLength = ClientSock.Receive(data);
						if (rxLength == 0)
						{
							ClientSock.Disconnect(false);
							ClientSock.Close();
							OnOpenClose(false);
							break;
						}

						OnRecvMsg(data);
					}
					Thread.Sleep(10);
				}
				OnLogAdded(this, "*** Rx End ***");
			}
			catch (Exception es)
			{
				OnLogAdded(this, "*** Rx Error : " + es.Message + "");
			}
		}
	}
}
