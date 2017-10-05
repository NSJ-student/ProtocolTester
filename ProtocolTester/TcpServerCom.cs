using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ProtocolTester
{
	class TcpServerCom : IComm
	{
		int test = 0;
		bool ServerRunning;
		IPEndPoint ServerIP;
		Socket ServerSock;
		Socket ClientSock;
		Thread ServerThread;
		Thread RxThread;
		ThreadStart ts, tp;

		public CommType Type
		{
			get
			{
				return CommType.COMM_TCP_SERVER;
			}
		}
		public object CurrentPort
		{
			get
			{
				if (ServerIP != null)
					return ServerIP as IPEndPoint;
				else
					return null;
			}
		}

		public bool IsOpen
		{
			get
			{
				if (ServerSock != null)
					return ServerSock.IsBound;
				else
					return false;
			}
		}

		public event ReceiveHandler OnRecvMsg;
		public event OpenCloseHandler OnOpenClose;
		public event LogHandler OnLogAdded;

		public TcpServerCom()
		{
			ServerRunning = false;
			ts = new ThreadStart(RxClientMsg);
			tp = new ThreadStart(WaitClientConnect);
		}
		
		public bool OpenPort(object port)
		{
			try
			{
				ServerIP = port as IPEndPoint;
				ServerSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				ServerSock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
				ServerSock.Bind(ServerIP);
				ServerSock.Listen(1);

				ServerRunning = true;
				ServerThread = new Thread(tp);
				ServerThread.Start();
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
			ServerRunning = false;

			try
			{
				if ((RxThread != null) && RxThread.IsAlive) RxThread.Abort();
				if (ClientSock != null) ClientSock.Close();

				if (ServerSock != null)
				{
				//	ServerSock.Shutdown(SocketShutdown.Send);
					ServerSock.Close();
				}
				if ((ServerThread != null) && ServerThread.IsAlive)
				{
					ServerThread.Abort();
				}
				OnOpenClose(false);
			}
			catch (Exception es)
			{
				OnLogAdded(this, "*** Close Error : " + es.Message);
			}
		}
		public bool SendData(byte[] Msg, MsgFormat Format)
		{
			if ((ClientSock != null) && ClientSock.Connected)
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

		private void WaitClientConnect()
		{
			int thisisit = test++;
			try
			{
				while (ServerRunning)
				{
					ClientSock = ServerSock.Accept();
					IPEndPoint ip = (IPEndPoint)ClientSock.RemoteEndPoint;

					if (ClientSock.Connected)
					{
						OnOpenClose(true);
						RxThread = new Thread(ts);
						RxThread.Start();
					}
				}
			}
			catch(Exception es)
			{
				OnLogAdded(this, "*** Wait Error : " + es.Message);
			}
			finally
			{
				OnLogAdded(this, "*** Wait Finally : End"+ thisisit.ToString());
			}
		}
		private void RxClientMsg()
		{
			try
			{
				while (ClientSock.Connected)
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
				OnLogAdded(this, "*** Client End ***");
			}
			catch (Exception es)
			{
				OnLogAdded(this, "*** Rx Error : " + es.Message);
			}
		}
	}
}
