using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolTester
{
	public class CommSettings
	{
		public bool AutoLineFeed;
		public bool LineFeedOnEnd;
		public bool ShowTxRxSymbol;
		public string RxSymbol;
		public string TxSymbol;

		public CommSettings()
		{
			RxSymbol = "Rx> ";
			TxSymbol = "Tx> ";
		}
		public CommSettings(CommSettings setting)
		{
			AutoLineFeed = setting.AutoLineFeed;
			LineFeedOnEnd = setting.LineFeedOnEnd;
			ShowTxRxSymbol = setting.ShowTxRxSymbol;
			RxSymbol = setting.RxSymbol;
			TxSymbol = setting.TxSymbol;
		}
	}
}
