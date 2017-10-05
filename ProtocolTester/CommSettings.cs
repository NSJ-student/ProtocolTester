using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolTester
{
	public class CommSettings
	{
		static public string[] TimeType = 
		{
			"None",
			"yy/MM/dd",
			"yy/MM/dd HH:mm:ss.fff",
			"HH:mm:ss",
			"HH:mm:ss.fff",
			"Milliseconds"
		};	
		public bool AutoLineFeed;
		public bool AutoScroll;
		public bool LineFeedOnEnd;
		public bool ShowTxRxSymbol;
		public int ShowTxRxTime;
		public string RxSymbol;
		public string TxSymbol;

		public CommSettings()
		{
			RxSymbol = "Rx> ";
			TxSymbol = "Tx> ";
			ShowTxRxTime = 0;
		}
		public CommSettings(CommSettings setting)
		{
			AutoLineFeed = setting.AutoLineFeed;
			LineFeedOnEnd = setting.LineFeedOnEnd;
			ShowTxRxSymbol = setting.ShowTxRxSymbol;
			AutoScroll = setting.AutoScroll;
			RxSymbol = setting.RxSymbol;
			TxSymbol = setting.TxSymbol;
			ShowTxRxTime = setting.ShowTxRxTime;
		}
	}
}
