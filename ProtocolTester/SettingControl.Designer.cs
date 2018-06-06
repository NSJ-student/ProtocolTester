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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbLineFeedOnEnd
			// 
			this.cbLineFeedOnEnd.AutoSize = true;
			this.cbLineFeedOnEnd.Location = new System.Drawing.Point(19, 17);
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
			this.cbShowTxRxSymbol.Location = new System.Drawing.Point(19, 67);
			this.cbShowTxRxSymbol.Name = "cbShowTxRxSymbol";
			this.cbShowTxRxSymbol.Size = new System.Drawing.Size(167, 19);
			this.cbShowTxRxSymbol.TabIndex = 1;
			this.cbShowTxRxSymbol.Text = "Show Tx/Rx Symbol";
			this.cbShowTxRxSymbol.UseVisualStyleBackColor = true;
			this.cbShowTxRxSymbol.CheckedChanged += new System.EventHandler(this.cbShowTxRxSymbol_CheckedChanged);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(201, 6);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 29);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(282, 6);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 29);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtTxSymbol
			// 
			this.txtTxSymbol.Location = new System.Drawing.Point(93, 96);
			this.txtTxSymbol.Name = "txtTxSymbol";
			this.txtTxSymbol.Size = new System.Drawing.Size(74, 25);
			this.txtTxSymbol.TabIndex = 4;
			this.txtTxSymbol.TextChanged += new System.EventHandler(this.txtTxSymbol_TextChanged);
			// 
			// txtRxSymbol
			// 
			this.txtRxSymbol.Location = new System.Drawing.Point(234, 96);
			this.txtRxSymbol.Name = "txtRxSymbol";
			this.txtRxSymbol.Size = new System.Drawing.Size(74, 25);
			this.txtRxSymbol.TabIndex = 5;
			this.txtRxSymbol.TextChanged += new System.EventHandler(this.txtRxSymbol_TextChanged);
			// 
			// cbAutoScroll
			// 
			this.cbAutoScroll.AutoSize = true;
			this.cbAutoScroll.Location = new System.Drawing.Point(19, 42);
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
			this.cbShowTime.Location = new System.Drawing.Point(187, 133);
			this.cbShowTime.Name = "cbShowTime";
			this.cbShowTime.Size = new System.Drawing.Size(121, 23);
			this.cbShowTime.TabIndex = 10;
			this.cbShowTime.SelectedIndexChanged += new System.EventHandler(this.cbShowTime_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(184, 99);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 15);
			this.label2.TabIndex = 7;
			this.label2.Text = "Rx : ";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(48, 99);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 15);
			this.label1.TabIndex = 6;
			this.label1.Text = "Tx : ";
			// 
			// lblShowTime
			// 
			this.lblShowTime.AutoSize = true;
			this.lblShowTime.Location = new System.Drawing.Point(19, 136);
			this.lblShowTime.Name = "lblShowTime";
			this.lblShowTime.Size = new System.Drawing.Size(141, 15);
			this.lblShowTime.TabIndex = 11;
			this.lblShowTime.Text = "Show Tx/Rx Time : ";
			// 
			// tabControl1
			// 
			this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.HotTrack = true;
			this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.tabControl1.ItemSize = new System.Drawing.Size(74, 0);
			this.tabControl1.Location = new System.Drawing.Point(8, 8);
			this.tabControl1.Multiline = true;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(370, 333);
			this.tabControl1.TabIndex = 12;
			// 
			// tabPage1
			// 
			this.tabPage1.AutoScroll = true;
			this.tabPage1.BackColor = System.Drawing.SystemColors.Menu;
			this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tabPage1.Controls.Add(this.cbLineFeedOnEnd);
			this.tabPage1.Controls.Add(this.lblShowTime);
			this.tabPage1.Controls.Add(this.cbShowTxRxSymbol);
			this.tabPage1.Controls.Add(this.cbShowTime);
			this.tabPage1.Controls.Add(this.txtTxSymbol);
			this.tabPage1.Controls.Add(this.cbAutoScroll);
			this.tabPage1.Controls.Add(this.txtRxSymbol);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(26, 4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(340, 325);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			// 
			// tabPage2
			// 
			this.tabPage2.AutoScroll = true;
			this.tabPage2.BackColor = System.Drawing.SystemColors.Menu;
			this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.tabPage2.Location = new System.Drawing.Point(26, 4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(340, 311);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(386, 399);
			this.tableLayoutPanel1.TabIndex = 14;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
			this.flowLayoutPanel1.Controls.Add(this.btnCancel);
			this.flowLayoutPanel1.Controls.Add(this.btnOK);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 349);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(366, 40);
			this.flowLayoutPanel1.TabIndex = 14;
			// 
			// SettingControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(386, 399);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SettingControl";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.TopMost = true;
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

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
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
	}
}