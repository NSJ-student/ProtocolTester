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
using System.Xml.Linq;

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

		public bool LoadInit()
		{
			try
			{
				if (File.Exists(".\\comm_info.xml"))
				{
					XElement root = XElement.Load("comm_info.xml");
					XElement uart = root.Element("tcp_server");
					XElement element;
					IPAddress ip = null;
					int port = 0;
					
					element = uart.Element("ip");
					if (element != null) ip = IPAddress.Parse(element.Value);

					element = uart.Element("port");
					if (element != null) port = Convert.ToInt32(element.Value);
					
					if ((ip != null) && (port != 0))
					{
						ServerIP = new IPEndPoint(ip, port);
					}

					return true;
				}
				return false;
			}
			catch
			{
				return false;
			}
		}

		public bool SaveInit()
		{
			if (ServerIP == null)
				return false;

			if (File.Exists(".\\comm_info.xml"))
			{
				XElement root = XElement.Load("comm_info.xml");
				XElement server = root.Element("tcp_server");
				XElement element;

				if (server == null)
				{
					server = new XElement("tcp_server");
					server.Add(new XElement("ip", ServerIP.Address.ToString()));
					server.Add(new XElement("port", ServerIP.Port.ToString()));
					root.Add(server);
				}
				else
				{
					element = server.Element("ip");
					if (element == null) element.Add(new XElement("ip", ServerIP.Address.ToString()));
					else if (ServerIP != null) element.ReplaceWith(new XElement("ip", ServerIP.Address.ToString()));

					element = server.Element("port");
					if (element == null) element.Add(new XElement("port", ServerIP.Port.ToString()));
					else if (ServerIP != null) element.ReplaceWith(new XElement("port", ServerIP.Port.ToString()));
				}
				
				root.Save("comm_info.xml");
			}
			else
			{
				XElement root = new XElement("comm_info");
				XElement server = new XElement("tcp_server");

				server.Add(new XElement("ip", ServerIP.Address.ToString()));
				server.Add(new XElement("port", ServerIP.Port.ToString()));
				root.Add(server);

				root.Save("comm_info.xml");
			}

			return true;
		}
	}
}
