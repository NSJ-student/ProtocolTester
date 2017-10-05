using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

		public void LoadInit()
		{
			try
			{
				if(File.Exists(".\\Init.txt"))
				{
					StreamReader reader = new StreamReader(".\\Init.txt");
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						string[] spt = line.Split(new char[] { ' ', '=' }, StringSplitOptions.RemoveEmptyEntries);
						if(spt.Length == 2)
						{
							if (spt[0].Equals("AutoLineFeed")) AutoLineFeed = Convert.ToBoolean(spt[1]);
							if (spt[0].Equals("AutoScroll")) AutoScroll = Convert.ToBoolean(spt[1]);
							if (spt[0].Equals("LineFeedOnEnd")) LineFeedOnEnd = Convert.ToBoolean(spt[1]);
							if (spt[0].Equals("ShowTxRxSymbol")) ShowTxRxSymbol = Convert.ToBoolean(spt[1]);
							if (spt[0].Equals("ShowTxRxTime")) ShowTxRxTime = Convert.ToInt32(spt[1]);
							if (spt[0].Equals("RxSymbol")) RxSymbol = spt[1];
							if (spt[0].Equals("TxSymbol")) TxSymbol = spt[1];
						}
					}
					reader.Close();
				}
			}
			catch
			{

			}
		}
		public void SaveInit()
		{
			if (File.Exists(".\\Init.txt"))
			{
				StreamWriter writer = new StreamWriter(".\\Init.txt", true);
				try
				{
					writer.WriteLine();
					writer.WriteLine("### Setting");
					writer.WriteLine();
					writer.WriteLine("AutoLineFeed="+ AutoLineFeed.ToString());
					writer.WriteLine("AutoScroll=" + AutoScroll.ToString());
					writer.WriteLine("LineFeedOnEnd=" + LineFeedOnEnd.ToString());
					writer.WriteLine("ShowTxRxSymbol=" + ShowTxRxSymbol.ToString());
					writer.WriteLine("ShowTxRxTime=" + ShowTxRxTime.ToString());
					writer.WriteLine("RxSymbol=" + RxSymbol);
					writer.WriteLine("TxSymbol=" + TxSymbol);
					writer.Close();
				}
				catch
				{
					writer.Close();
				}
			}
		}
	}
}
