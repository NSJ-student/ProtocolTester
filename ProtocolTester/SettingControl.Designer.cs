namespace ProtocolTester
{
	partial class SettingControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cbLineFeedOnEnd = new System.Windows.Forms.CheckBox();
			this.cbShowTxRxSymbol = new System.Windows.Forms.CheckBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtTxSymbol = new System.Windows.Forms.TextBox();
			this.txtRxSymbol = new System.Windows.Forms.TextBox();
			this.cbAutoScroll = new System.Windows.Forms.CheckBox();
			this.cbShowTime = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblShowTime = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbLineFeedOnEnd
			// 
			this.cbLineFeedOnEnd.AutoSize = true;
			this.cbLineFeedOnEnd.Location = new System.Drawing.Point(12, 33);
			this.cbLineFeedOnEnd.Name = "cbLineFeedOnEnd";
			this.cbLineFeedOnEnd.Size = new System.Drawing.Size(176, 19);
			this.cbLineFeedOnEnd.TabIndex = 0;
			this.cbLineFeedOnEnd.Text = "LineFeed On Msg End";
			this.cbLineFeedOnEnd.UseVisualStyleBackColor = true;
			this.cbLineFeedOnEnd.CheckedChanged += new System.EventHandler(this.cbLineFeedOnEnd_CheckedChanged);
			// 
			// cbShowTxRxSymbol
			// 
			this.cbShowTxRxSymbol.AutoSize = true;
			this.cbShowTxRxSymbol.Location = new System.Drawing.Point(12, 83);
			this.cbShowTxRxSymbol.Name = "cbShowTxRxSymbol";
			this.cbShowTxRxSymbol.Size = new System.Drawing.Size(167, 19);
			this.cbShowTxRxSymbol.TabIndex = 1;
			this.cbShowTxRxSymbol.Text = "Show Tx/Rx Symbol";
			this.cbShowTxRxSymbol.UseVisualStyleBackColor = true;
			this.cbShowTxRxSymbol.CheckedChanged += new System.EventHandler(this.cbShowTxRxSymbol_CheckedChanged);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(147, 361);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(228, 361);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtTxSymbol
			// 
			this.txtTxSymbol.Location = new System.Drawing.Point(86, 112);
			this.txtTxSymbol.Name = "txtTxSymbol";
			this.txtTxSymbol.Size = new System.Drawing.Size(74, 25);
			this.txtTxSymbol.TabIndex = 4;
			this.txtTxSymbol.TextChanged += new System.EventHandler(this.txtTxSymbol_TextChanged);
			// 
			// txtRxSymbol
			// 
			this.txtRxSymbol.Location = new System.Drawing.Point(227, 112);
			this.txtRxSymbol.Name = "txtRxSymbol";
			this.txtRxSymbol.Size = new System.Drawing.Size(74, 25);
			this.txtRxSymbol.TabIndex = 5;
			this.txtRxSymbol.TextChanged += new System.EventHandler(this.txtRxSymbol_TextChanged);
			// 
			// cbAutoScroll
			// 
			this.cbAutoScroll.AutoSize = true;
			this.cbAutoScroll.Location = new System.Drawing.Point(12, 58);
			this.cbAutoScroll.Name = "cbAutoScroll";
			this.cbAutoScroll.Size = new System.Drawing.Size(101, 19);
			this.cbAutoScroll.TabIndex = 8;
			this.cbAutoScroll.Text = "Auto Scroll";
			this.cbAutoScroll.UseVisualStyleBackColor = true;
			this.cbAutoScroll.CheckedChanged += new System.EventHandler(this.cbAutoScroll_CheckedChanged);
			// 
			// cbShowTime
			// 
			this.cbShowTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbShowTime.FormattingEnabled = true;
			this.cbShowTime.Location = new System.Drawing.Point(180, 149);
			this.cbShowTime.Name = "cbShowTime";
			this.cbShowTime.Size = new System.Drawing.Size(121, 23);
			this.cbShowTime.TabIndex = 10;
			this.cbShowTime.SelectedIndexChanged += new System.EventHandler(this.cbShowTime_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(177, 115);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 15);
			this.label2.TabIndex = 7;
			this.label2.Text = "Rx : ";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(41, 115);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 15);
			this.label1.TabIndex = 6;
			this.label1.Text = "Tx : ";
			// 
			// lblShowTime
			// 
			this.lblShowTime.AutoSize = true;
			this.lblShowTime.Location = new System.Drawing.Point(12, 152);
			this.lblShowTime.Name = "lblShowTime";
			this.lblShowTime.Size = new System.Drawing.Size(141, 15);
			this.lblShowTime.TabIndex = 11;
			this.lblShowTime.Text = "Show Tx/Rx Time : ";
			// 
			// SettingControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(315, 396);
			this.Controls.Add(this.lblShowTime);
			this.Controls.Add(this.cbShowTime);
			this.Controls.Add(this.cbAutoScroll);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtRxSymbol);
			this.Controls.Add(this.txtTxSymbol);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cbShowTxRxSymbol);
			this.Controls.Add(this.cbLineFeedOnEnd);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SettingControl";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox cbLineFeedOnEnd;
		private System.Windows.Forms.CheckBox cbShowTxRxSymbol;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtTxSymbol;
		private System.Windows.Forms.TextBox txtRxSymbol;
		private System.Windows.Forms.CheckBox cbAutoScroll;
		private System.Windows.Forms.ComboBox cbShowTime;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblShowTime;
	}
}