using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Xml.Linq;

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
        public event UpdateTitle OnTitleChange;

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
                OnTitleChange("Tester (" + ClientIP.Address.ToString() + ")");

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

                OnTitleChange("Tester");
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

		public bool LoadInit()
		{
			try
			{
				if (File.Exists(".\\comm_info.xml"))
				{
					XElement root = XElement.Load("comm_info.xml");
					XElement uart = root.Element("tcp_client");
					XElement element;
					IPAddress ip = null;
					int port = 0;

					element = uart.Element("ip");
					if (element != null) ip = IPAddress.Parse(element.Value);

					element = uart.Element("port");
					if (element != null) port = Convert.ToInt32(element.Value);

					if ((ip != null) && (port != 0))
					{
						ClientIP = new IPEndPoint(ip, port);
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
			if (ClientIP == null)
				return false;

			if (File.Exists(".\\comm_info.xml"))
			{
				XElement root = XElement.Load("comm_info.xml");
				XElement client = root.Element("tcp_client");
				XElement element;

				if(client == null)
				{
					client = new XElement("tcp_client");
					client.Add(new XElement("ip", ClientIP.Address.ToString()));
					client.Add(new XElement("port", ClientIP.Port.ToString()));
					root.Add(client);
				}
				else
				{
					element = client.Element("ip");
					if (element == null) element.Add(new XElement("ip", ClientIP.Address.ToString()));
					else if (ClientIP != null) element.ReplaceWith(new XElement("ip", ClientIP.Address.ToString()));

					element = client.Element("port");
					if (element == null) element.Add(new XElement("port", ClientIP.Port.ToString()));
					else if (ClientIP != null) element.ReplaceWith(new XElement("port", ClientIP.Port.ToString()));
				}

				root.Save("comm_info.xml");
			}
			else
			{
				XElement root = new XElement("comm_info");
				XElement client = new XElement("tcp_client");

				client.Add(new XElement("ip", ClientIP.Address.ToString()));
				client.Add(new XElement("port", ClientIP.Port.ToString()));
				root.Add(client);

				root.Save("comm_info.xml");
			}

			return true;
		}
	}
}
