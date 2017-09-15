using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolTester
{
	abstract class IComm
	{
		public enum CommType
		{
			COMM_SERIAL,
			COMM_TCP_SERVER,
			COMM_TCP_CLIENT,
			COMM_UDP
		}
		protected CommType comType;
		public abstract bool IsOpen { get; }
		public CommType Type
		{
			get
			{
				return comType;
			}
		}
		public abstract void ClosePort();
	}
}
