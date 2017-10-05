using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace ProtocolTester
{
	class SerialCom : IComm
	{
		SerialPort PortInfo;
		Thread rxThread;
		public event ReceiveHandler OnRecvMsg;
		public event OpenCloseHandler OnOpenClose;
		public event LogHandler OnLogAdded;

		public CommType Type
		{
			get
			{
				return CommType.COMM_SERIAL;
			}
		}
		public bool IsOpen
		{
			get
			{
				return (PortInfo != null) ? PortInfo.IsOpen : false;
			}
		}
		public object CurrentPort
		{
			get
			{
				return PortInfo;
			}
		}
		public SerialCom()
		{
			ThreadStart ts = new ThreadStart(ReadMsg);
			rxThread = new Thread(ts);
		}
		public SerialCom(string PortName, int BaudRate)
			: this()
		{
			PortInfo = new SerialPort(PortName);
			PortInfo.BaudRate = BaudRate;
			PortInfo.DataBits = 8;
			PortInfo.StopBits = StopBits.One;
			PortInfo.Parity = Parity.None;
		}
		public SerialCom(SerialPort port)
			: this()
		{
			PortInfo = port;
		}

		public bool OpenPort(object port)
		{
			PortInfo = port as SerialPort;

			try
			{
				PortInfo.Open();
				OnOpenClose(true);
				rxThread.Start();
				return true;
			}
			catch
			{
				return false;
			}
		}
		public void ClosePort()
		{
			if(PortInfo.IsOpen)
			{
				if(rxThread.IsAlive)
				{
					rxThread.Abort();
				}
				PortInfo.Close();
				OnOpenClose(false);
			}
		}

		public bool SendData(byte[] Msg, MsgFormat Format)
		{
			if(IsOpen)
			{
				string sendData = Encoding.Default.GetString(Msg);
				PortInfo.Write(sendData);
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
					byte[] reads = new byte[PortInfo.BytesToRead];
					PortInfo.Read(reads, 0, PortInfo.BytesToRead);

					OnRecvMsg(reads);
				}
				Thread.Sleep(10);
			}
		}

		public bool LoadInit()
		{
			try
			{
				if (File.Exists(".\\Init.txt"))
				{
					StreamReader reader = new StreamReader(".\\Init.txt");
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						string[] spt = line.Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
						if (spt.Length == 2)
						{
							if (PortInfo == null)
								PortInfo = new SerialPort();

							if (spt[0].Equals("PortName"))	PortInfo.PortName = spt[1];
							if (spt[0].Equals("BaudRate"))	PortInfo.BaudRate = Convert.ToInt32(spt[1]);
							if (spt[0].Equals("Parity"))	PortInfo.Parity = (Parity)Convert.ToInt32(spt[1]);
							if (spt[0].Equals("StopBits"))	PortInfo.StopBits = (StopBits)Convert.ToInt32(spt[1]);
							if (spt[0].Equals("DataBits"))	PortInfo.DataBits = Convert.ToInt32(spt[1]);
						}
					}
					reader.Close();
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
			if (File.Exists(".\\Init.txt"))
			{
				if (PortInfo != null)
				{
					StreamWriter writer = new StreamWriter(".\\Init.txt", true);
					try
					{
						writer.WriteLine();
						writer.WriteLine("### Serial PortInfo");
						writer.WriteLine();
						writer.WriteLine("PortName=" + PortInfo.PortName);
						writer.WriteLine("BaudRate=" + PortInfo.BaudRate.ToString());
						writer.WriteLine("Parity=" + PortInfo.Parity.ToString());
						writer.WriteLine("StopBits=" + PortInfo.StopBits.ToString());
						writer.WriteLine("DataBits=" + PortInfo.DataBits.ToString());
						writer.Close();
					}
					catch
					{
						writer.Close();
						return false;
					}
					return true;
				}
			}
			return false;
		}
	}
}
