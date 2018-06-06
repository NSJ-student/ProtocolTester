using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

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
				if (File.Exists(".\\settings.xml"))
				{
					var xdoc = XDocument.Load("settings.xml");
					var xelements = xdoc.Root;
					XElement element;

					element = xelements.Element("autoLF");
					if(element != null) AutoLineFeed = Convert.ToBoolean(element.Value);

					element = xelements.Element("autoScroll");
					if (element != null) AutoScroll = Convert.ToBoolean(xelements.Element("autoScroll").Value);

					element = xelements.Element("endLF");
					if (element != null) LineFeedOnEnd = Convert.ToBoolean(xelements.Element("endLF").Value);

					element = xelements.Element("showSymbol");
					if (element != null) ShowTxRxSymbol = Convert.ToBoolean(xelements.Element("showSymbol").Value);

					element = xelements.Element("showTime");
					if (element != null) ShowTxRxTime = Convert.ToInt32(xelements.Element("showTime").Value);

					element = xelements.Element("rxSymbol");
					if (element != null) RxSymbol = xelements.Element("rxSymbol").Value;

					element = xelements.Element("txSymbol");
					if (element != null) TxSymbol = xelements.Element("txSymbol").Value;
				}
			}
			catch
			{

			}
		}
		public void SaveInit()
		{
			XElement root;
			if (File.Exists(".\\settings.xml"))
			{
				root = XElement.Load("settings.xml");
				XElement element;
				
				element = root.Element("autoLF");
				if (element == null) element.Add(new XElement("autoLF", AutoLineFeed.ToString()));
				else element.ReplaceWith(new XElement("autoLF", AutoLineFeed.ToString()));

				element = root.Element("autoScroll");
				if (element == null) element.Add(new XElement("autoScroll", AutoScroll.ToString()));
				else element.ReplaceWith(new XElement("autoScroll", AutoScroll.ToString()));

				element = root.Element("endLF");
				if (element == null) element.Add(new XElement("endLF", LineFeedOnEnd.ToString()));
				else element.ReplaceWith(new XElement("endLF", LineFeedOnEnd.ToString()));

				element = root.Element("showSymbol");
				if (element == null) element.Add(new XElement("showSymbol", ShowTxRxSymbol.ToString()));
				else element.ReplaceWith(new XElement("showSymbol", ShowTxRxSymbol.ToString()));

				element = root.Element("showTime");
				if (element == null) element.Add(new XElement("showTime", ShowTxRxTime.ToString()));
				else element.ReplaceWith(new XElement("showTime", ShowTxRxTime.ToString()));

				element = root.Element("rxSymbol");
				if (element == null) element.Add(new XElement("rxSymbol", RxSymbol));
				else element.ReplaceWith(new XElement("rxSymbol", RxSymbol));

				element = root.Element("txSymbol");
				if (element == null) element.Add(new XElement("txSymbol", TxSymbol));
				else element.ReplaceWith(new XElement("txSymbol", TxSymbol));

				root.Save("settings.xml");
			}
			else
			{
				root = new XElement("settings");

				root.Add(new XElement("autoLF", AutoLineFeed.ToString()));
				root.Add(new XElement("autoScroll", AutoScroll.ToString()));
				root.Add(new XElement("endLF", LineFeedOnEnd.ToString()));
				root.Add(new XElement("showSymbol", ShowTxRxSymbol.ToString()));
				root.Add(new XElement("showTime", ShowTxRxTime.ToString()));
				root.Add(new XElement("rxSymbol", RxSymbol));
				root.Add(new XElement("txSymbol", TxSymbol));

				root.Save("settings.xml");
			}
		}
	}
}
