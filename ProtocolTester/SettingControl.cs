using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtocolTester
{
	public delegate void UpdateSettings(CommSettings settings);
	public partial class SettingControl : Form
	{
		CommSettings Settings;
		UpdateSettings UpdateSettings;
		public SettingControl(CommSettings settings, UpdateSettings up)
		{
			InitializeComponent();

			Settings = new CommSettings(settings);
			UpdateSettings = up;
			if (settings.LineFeedOnEnd)
				cbLineFeedOnEnd.Checked = true;
			if (settings.ShowTxRxSymbol)
				cbShowTxRxSymbol.Checked = true;
			if (settings.AutoScroll)
				cbAutoScroll.Checked = true;
			txtRxSymbol.Text = settings.RxSymbol;
			txtTxSymbol.Text = settings.TxSymbol;

			cbShowTime.Items.AddRange(CommSettings.TimeType);
			cbShowTime.SelectedIndex = settings.ShowTxRxTime;
		}

		private void cbShowTxRxSymbol_CheckedChanged(object sender, EventArgs e)
		{
			Settings.ShowTxRxSymbol = cbShowTxRxSymbol.Checked;
		}

		private void cbLineFeedOnEnd_CheckedChanged(object sender, EventArgs e)
		{
			Settings.LineFeedOnEnd = cbLineFeedOnEnd.Checked;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			UpdateSettings(Settings);
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void txtRxSymbol_TextChanged(object sender, EventArgs e)
		{
			Settings.RxSymbol = txtRxSymbol.Text;
		}

		private void txtTxSymbol_TextChanged(object sender, EventArgs e)
		{
			Settings.TxSymbol = txtTxSymbol.Text;
		}

		private void cbAutoScroll_CheckedChanged(object sender, EventArgs e)
		{
			Settings.AutoScroll = cbAutoScroll.Checked;
		}

		private void cbShowTime_SelectedIndexChanged(object sender, EventArgs e)
		{
			Settings.ShowTxRxTime = cbShowTime.SelectedIndex;
		}
	}
}
