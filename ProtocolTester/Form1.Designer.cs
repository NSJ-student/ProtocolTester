namespace ProtocolTester
{
	partial class Form1
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.rtbLog = new System.Windows.Forms.RichTextBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnSettings = new System.Windows.Forms.Button();
			this.lblSend = new System.Windows.Forms.Label();
			this.txtSendMsg = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.cbFormat = new System.Windows.Forms.CheckBox();
			this.btnLogClear = new System.Windows.Forms.Button();
			this.lblStartMsg = new System.Windows.Forms.Label();
			this.lblEndMsg = new System.Windows.Forms.Label();
			this.txtStartMsg = new System.Windows.Forms.TextBox();
			this.txtEndMsg = new System.Windows.Forms.TextBox();
			this.btnShortKey = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 7;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.rtbLog, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnConnect, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnSettings, 5, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblSend, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.txtSendMsg, 2, 3);
			this.tableLayoutPanel1.Controls.Add(this.btnSend, 5, 3);
			this.tableLayoutPanel1.Controls.Add(this.cbFormat, 3, 4);
			this.tableLayoutPanel1.Controls.Add(this.btnLogClear, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.lblStartMsg, 4, 4);
			this.tableLayoutPanel1.Controls.Add(this.lblEndMsg, 5, 4);
			this.tableLayoutPanel1.Controls.Add(this.txtStartMsg, 4, 5);
			this.tableLayoutPanel1.Controls.Add(this.txtEndMsg, 5, 5);
			this.tableLayoutPanel1.Controls.Add(this.btnShortKey, 1, 5);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 553);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// rtbLog
			// 
			this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.rtbLog, 5);
			this.rtbLog.Location = new System.Drawing.Point(13, 43);
			this.rtbLog.Name = "rtbLog";
			this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.rtbLog.Size = new System.Drawing.Size(436, 407);
			this.rtbLog.TabIndex = 1;
			this.rtbLog.Text = "";
			// 
			// btnConnect
			// 
			this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.btnConnect, 2);
			this.btnConnect.Location = new System.Drawing.Point(13, 13);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(94, 23);
			this.btnConnect.TabIndex = 0;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnSettings
			// 
			this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSettings.Location = new System.Drawing.Point(375, 13);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(74, 23);
			this.btnSettings.TabIndex = 11;
			this.btnSettings.Text = "Settings";
			this.btnSettings.UseVisualStyleBackColor = true;
			// 
			// lblSend
			// 
			this.lblSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSend.AutoSize = true;
			this.lblSend.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblSend.Location = new System.Drawing.Point(13, 460);
			this.lblSend.Name = "lblSend";
			this.lblSend.Size = new System.Drawing.Size(44, 15);
			this.lblSend.TabIndex = 4;
			this.lblSend.Text = "Msg: ";
			// 
			// txtSendMsg
			// 
			this.txtSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.txtSendMsg, 3);
			this.txtSendMsg.Location = new System.Drawing.Point(63, 456);
			this.txtSendMsg.Name = "txtSendMsg";
			this.txtSendMsg.Size = new System.Drawing.Size(306, 25);
			this.txtSendMsg.TabIndex = 2;
			// 
			// btnSend
			// 
			this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSend.Location = new System.Drawing.Point(375, 456);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(74, 23);
			this.btnSend.TabIndex = 3;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// cbFormat
			// 
			this.cbFormat.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.cbFormat.AutoSize = true;
			this.cbFormat.Location = new System.Drawing.Point(113, 488);
			this.cbFormat.Name = "cbFormat";
			this.cbFormat.Size = new System.Drawing.Size(56, 19);
			this.cbFormat.TabIndex = 5;
			this.cbFormat.Text = "Hex";
			this.cbFormat.UseVisualStyleBackColor = true;
			this.cbFormat.CheckedChanged += new System.EventHandler(this.cbFormat_CheckedChanged);
			// 
			// btnLogClear
			// 
			this.btnLogClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.btnLogClear, 2);
			this.btnLogClear.Location = new System.Drawing.Point(13, 486);
			this.btnLogClear.Name = "btnLogClear";
			this.btnLogClear.Size = new System.Drawing.Size(94, 23);
			this.btnLogClear.TabIndex = 6;
			this.btnLogClear.Text = "Clear";
			this.btnLogClear.UseVisualStyleBackColor = true;
			this.btnLogClear.Click += new System.EventHandler(this.btnLogClear_Click);
			// 
			// lblStartMsg
			// 
			this.lblStartMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblStartMsg.AutoSize = true;
			this.lblStartMsg.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblStartMsg.Location = new System.Drawing.Point(295, 490);
			this.lblStartMsg.Name = "lblStartMsg";
			this.lblStartMsg.Size = new System.Drawing.Size(74, 15);
			this.lblStartMsg.TabIndex = 7;
			this.lblStartMsg.Text = "Start";
			// 
			// lblEndMsg
			// 
			this.lblEndMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEndMsg.AutoSize = true;
			this.lblEndMsg.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblEndMsg.Location = new System.Drawing.Point(375, 490);
			this.lblEndMsg.Name = "lblEndMsg";
			this.lblEndMsg.Size = new System.Drawing.Size(74, 15);
			this.lblEndMsg.TabIndex = 8;
			this.lblEndMsg.Text = "End";
			// 
			// txtStartMsg
			// 
			this.txtStartMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtStartMsg.Location = new System.Drawing.Point(295, 516);
			this.txtStartMsg.Name = "txtStartMsg";
			this.txtStartMsg.Size = new System.Drawing.Size(74, 25);
			this.txtStartMsg.TabIndex = 9;
			// 
			// txtEndMsg
			// 
			this.txtEndMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEndMsg.Location = new System.Drawing.Point(375, 516);
			this.txtEndMsg.Name = "txtEndMsg";
			this.txtEndMsg.Size = new System.Drawing.Size(74, 25);
			this.txtEndMsg.TabIndex = 10;
			// 
			// btnShortKey
			// 
			this.btnShortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.btnShortKey, 2);
			this.btnShortKey.Location = new System.Drawing.Point(13, 516);
			this.btnShortKey.Name = "btnShortKey";
			this.btnShortKey.Size = new System.Drawing.Size(94, 23);
			this.btnShortKey.TabIndex = 12;
			this.btnShortKey.Text = "Short Key";
			this.btnShortKey.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(462, 553);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Tester";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.RichTextBox rtbLog;
		private System.Windows.Forms.TextBox txtSendMsg;
		private System.Windows.Forms.Label lblSend;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.CheckBox cbFormat;
		private System.Windows.Forms.Button btnLogClear;
		private System.Windows.Forms.TextBox txtStartMsg;
		private System.Windows.Forms.Label lblStartMsg;
		private System.Windows.Forms.Label lblEndMsg;
		private System.Windows.Forms.TextBox txtEndMsg;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.Button btnShortKey;
	}
}

