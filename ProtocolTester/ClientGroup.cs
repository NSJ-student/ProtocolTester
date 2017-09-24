using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace ProtocolTester
{
	public delegate void Send_Message(object sender);
	public delegate void Close_Message(object sender);
	public class ClientGroup
	{
		Msg_Queue msg_queue = null;
		ArrayList member = null;

		/// <summary>
		/// 클라이언트 그룹 생성자
		/// </summary>
		public ClientGroup()
		{
			msg_queue = new Msg_Queue();
			member = new ArrayList();
		}

		/// <summary>
		/// 클라이언트 그룹 소멸자
		/// </summary>
		public void Dispose()
		{
			foreach (Client obj in member)
			{
				obj.Dispose();
			}
		}

		/// <summary>
		/// 현재 접속된 클라이언트 수
		/// </summary>
		public int Length
		{
			get
			{
				return member.Count;
			}
		}

		/// <summary>
		/// 멤버 추가
		/// </summary>
		/// <param name="client"></param>
		public void AddMember(Client client)
		{
			client.Send_All += new Send_Message(Send_All);
			client.Close_MSG += new Close_Message(Close_MSG);
			client.msg_queue = msg_queue;
			member.Add(client);
		}

		/// <summary>
		/// 멤버 제거
		/// </summary>
		/// <param name="ip"></param>
		public void DeleteMember(string ip)
		{
			int index = 0;
			foreach (Client obj in member)
			{
				if (obj.Client_IP == ip)
				{
					obj.Dispose();
					member.RemoveAt(index);
				}
				index++;
			}
		}

		/// <summary>
		/// Send_All 이벤트를 통한 클라이언트 메시지 방송
		/// </summary>
		/// <param name="sender"></param>
		public void Send_All(object sender)
		{
			string msg = this.msg_queue.Dequeue();

			foreach (Client obj in member)
			{
				if (sender != obj)
					obj.Send(msg);
			}
		}

		public void Close_MSG(object sender)
		{
			string msg = this.msg_queue.Dequeue();
			this.DeleteMember(msg);
		}

		/// <summary>
		/// 서버에 접속한 모든 클라이언트에 메시지 방송
		/// </summary>
		/// <param name="msg"></param>
		/// <returns></returns>
		public bool BroadCast(string msg)
		{
			try
			{
				lock (member)
				{
					foreach (Client obj in member)
					{
						if (obj.Connect)
							obj.Send(msg);
					}
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// 지정된 아이피 그룹에게만 문자열 방송
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="ips"></param>
		/// <returns></returns>
		public bool BroadCast(string msg, string ips)
		{
			try
			{
				string[] ip = ips.Split(';'); // 아이피 주소가 ; 형태로 들어옴
				for (int i = 0; i < ip.Length; i++)
				{
					lock (member)
					{
						foreach (Client obj in member)
						{
							if ((obj.Client_IP == ip[i]) && (obj.Connect))
								obj.Send(msg);
						}
					}

				}

				return true;
			}
			catch
			{
				return false;
			}
		}
	}

	public class Client
	{
		public event Send_Message Send_All;
		public event Close_Message Close_MSG;
		public Msg_Queue msg_queue = null;

		Socket client = null;
		Thread th = null;

		string client_ip = null;

		public bool Connect
		{
			get
			{
				return this.client.Connected;
			}
		}

		public string Client_IP
		{
			get
			{
				return client_ip;
			}
		}

		public Client(Socket client)
		{
			this.client = client;

			IPEndPoint ip = (IPEndPoint)this.client.RemoteEndPoint;
			this.client_ip = ip.Address.ToString();

			try
			{
				th = new Thread(new ThreadStart(Receive));
				th.Start();
			}
			catch (Exception ex)
			{
				//this.wnd.Add_MSG(ex.Message);
			}
		}

		public void Dispose()
		{
			try
			{
				if (th.IsAlive)
					th.Abort();
				this.client.Close();
			}
			catch (Exception ex)
			{
				//this.wnd.Add_MSG(ex.Message);
			}
		}

		public void Receive()
		{
			try
			{
				while (client != null && client.Connected)
				{
					byte[] data = this.ReceiveData();
					string msg = Encoding.Default.GetString(data);
					if (msg != null)
					{
						string[] token = msg.Split('\a');
						switch (token[0])
						{
							case "CTOS_MESSAGE_END":
								this.msg_queue.Enqueue(token[1].Trim());
								Close_MSG(this);
								//this.wnd.Add_MSG(token[1] + "님이 로그아웃했습니다.");
								//this.wnd.Delete_listView(token[1].Trim()); // 리스트뷰에서 제거
								break;

							default:
								this.msg_queue.Enqueue(msg);
								Send_All(this);
								break;
						}
					}

				}
			}
			catch (Exception ex)
			{
				//this.wnd.Add_MSG(ex.Message);
			}
		}

		/// <summary>
		/// 접속한 상대방에 데이터 전송
		/// </summary>
		/// <param name="msg">전송할 문자열</param>
		public void Send(string msg)
		{
			try
			{
				if (client.Connected)
				{
					byte[] data = Encoding.Default.GetBytes(msg);
					this.SendData(data);
				}
				else
				{
					//this.wnd.Add_MSG("메시지 전송 실패!");
				}
			}
			catch (Exception ex)
			{
				//this.wnd.Add_MSG(ex.Message);
			}
		}


		/// <summary>
		/// 데이터 수신
		/// </summary>		
		/// <returns>수신한 데이터 배열</returns>
		private byte[] ReceiveData()
		{
			try
			{
				int total = 0;
				int size = 0;
				int left_data = 0;
				int recv_data = 0;

				// 수신할 데이터 크기 알아내기   
				byte[] data_size = new byte[4];
				recv_data = this.client.Receive(data_size, 0, 4, SocketFlags.None);
				size = BitConverter.ToInt32(data_size, 0);
				left_data = size;

				byte[] data = new byte[size];
				// 서버에서 전송한 실제 데이터 수신
				while (total < size)
				{
					recv_data = this.client.Receive(data, total, left_data, 0);
					if (recv_data == 0) break;
					total += recv_data;
					left_data -= recv_data;
				}
				return data;
			}
			catch (Exception ex)
			{
				//this.wnd.Add_MSG(ex.Message);
				return null;
			}
		}

		/// <summary>
		/// 데이터 전송
		/// </summary>
		/// <param name="data">전송할 데이터</param>
		private void SendData(byte[] data)
		{
			try
			{
				int total = 0;
				int size = data.Length;
				int left_data = size;
				int send_data = 0;

				// 전송할 실제 데이터의 크기 전달
				byte[] data_size = new byte[4];
				data_size = BitConverter.GetBytes(size);
				send_data = this.client.Send(data_size);

				// 실제 데이터 전송
				while (total < size)
				{
					send_data = this.client.Send(data, total, left_data, SocketFlags.None);
					total += send_data;
					left_data -= send_data;
				}
			}
			catch (Exception ex)
			{
				//this.wnd.Add_MSG(ex.Message);
			}
		}

	}
	public class Msg_Queue
	{
		Queue msg_queue = null;

		public Msg_Queue()
		{
			msg_queue = new Queue();
		}

		public void Enqueue(string msg)
		{
			lock (msg_queue)
			{
				msg_queue.Enqueue(msg);
			}
		}

		public string Dequeue()
		{
			lock (msg_queue)
			{
				if (msg_queue.Count != 0)
				{
					return msg_queue.Dequeue().ToString().Trim();
				}
				else
				{
					return null;
				}
			}
		}
	}
}
