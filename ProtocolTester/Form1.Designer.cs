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
			this.btnSettings = new System.Windows.Forms.Button();
			this.lblSend = new System.Windows.Forms.Label();
			this.btnLogClear = new System.Windows.Forms.Button();
			this.lblStartMsg = new System.Windows.Forms.Label();
			this.txtStartMsg = new System.Windows.Forms.TextBox();
			this.lblEndMsg = new System.Windows.Forms.Label();
			this.txtEndMsg = new System.Windows.Forms.TextBox();
			this.txtSendMsg = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.lblRxFormat = new System.Windows.Forms.Label();
			this.rbRxMsgHex = new System.Windows.Forms.RadioButton();
			this.rbRxMsgASCII = new System.Windows.Forms.RadioButton();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.lblSendFormat = new System.Windows.Forms.Label();
			this.rbSendHex = new System.Windows.Forms.RadioButton();
			this.rbSendASCII = new System.Windows.Forms.RadioButton();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnShortKey = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 8;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 214F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Controls.Add(this.rtbLog, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.btnSettings, 6, 1);
			this.tableLayoutPanel1.Controls.Add(this.lblSend, 1, 4);
			this.tableLayoutPanel1.Controls.Add(this.btnLogClear, 6, 3);
			this.tableLayoutPanel1.Controls.Add(this.lblStartMsg, 3, 6);
			this.tableLayoutPanel1.Controls.Add(this.txtStartMsg, 4, 6);
			this.tableLayoutPanel1.Controls.Add(this.lblEndMsg, 5, 6);
			this.tableLayoutPanel1.Controls.Add(this.txtEndMsg, 6, 6);
			this.tableLayoutPanel1.Controls.Add(this.txtSendMsg, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.btnSend, 6, 5);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 6);
			this.tableLayoutPanel1.Controls.Add(this.btnConnect, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.btnShortKey, 4, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 8;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(582, 553);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// rtbLog
			// 
			this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.rtbLog, 6);
			this.rtbLog.Location = new System.Drawing.Point(13, 43);
			this.rtbLog.Name = "rtbLog";
			this.rtbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.rtbLog.Size = new System.Drawing.Size(556, 377);
			this.rtbLog.TabIndex = 1;
			this.rtbLog.Text = "";
			// 
			// btnSettings
			// 
			this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSettings.Location = new System.Drawing.Point(495, 13);
			this.btnSettings.Name = "btnSettings";
			this.btnSettings.Size = new System.Drawing.Size(74, 23);
			this.btnSettings.TabIndex = 11;
			this.btnSettings.Text = "Settings";
			this.btnSettings.UseVisualStyleBackColor = true;
			this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
			// 
			// lblSend
			// 
			this.lblSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSend.AutoSize = true;
			this.lblSend.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblSend.Location = new System.Drawing.Point(13, 460);
			this.lblSend.Name = "lblSend";
			this.lblSend.Size = new System.Drawing.Size(208, 15);
			this.lblSend.TabIndex = 4;
			this.lblSend.Text = "Send Msg: ";
			// 
			// btnLogClear
			// 
			this.btnLogClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLogClear.Location = new System.Drawing.Point(495, 426);
			this.btnLogClear.Name = "btnLogClear";
			this.btnLogClear.Size = new System.Drawing.Size(74, 23);
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
			this.lblStartMsg.Location = new System.Drawing.Point(315, 520);
			this.lblStartMsg.Name = "lblStartMsg";
			this.lblStartMsg.Size = new System.Drawing.Size(44, 15);
			this.lblStartMsg.TabIndex = 7;
			this.lblStartMsg.Text = "Start";
			// 
			// txtStartMsg
			// 
			this.txtStartMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtStartMsg.Location = new System.Drawing.Point(365, 516);
			this.txtStartMsg.Name = "txtStartMsg";
			this.txtStartMsg.Size = new System.Drawing.Size(74, 25);
			this.txtStartMsg.TabIndex = 9;
			// 
			// lblEndMsg
			// 
			this.lblEndMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblEndMsg.AutoSize = true;
			this.lblEndMsg.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblEndMsg.Location = new System.Drawing.Point(445, 520);
			this.lblEndMsg.Name = "lblEndMsg";
			this.lblEndMsg.Size = new System.Drawing.Size(44, 15);
			this.lblEndMsg.TabIndex = 8;
			this.lblEndMsg.Text = "End";
			// 
			// txtEndMsg
			// 
			this.txtEndMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.txtEndMsg.Location = new System.Drawing.Point(495, 516);
			this.txtEndMsg.Name = "txtEndMsg";
			this.txtEndMsg.Size = new System.Drawing.Size(74, 25);
			this.txtEndMsg.TabIndex = 10;
			// 
			// txtSendMsg
			// 
			this.txtSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.SetColumnSpan(this.txtSendMsg, 5);
			this.txtSendMsg.Location = new System.Drawing.Point(13, 486);
			this.txtSendMsg.Name = "txtSendMsg";
			this.txtSendMsg.Size = new System.Drawing.Size(476, 25);
			this.txtSendMsg.TabIndex = 2;
			this.txtSendMsg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSendMsg_KeyUp);
			// 
			// btnSend
			// 
			this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSend.Location = new System.Drawing.Point(495, 486);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(74, 23);
			this.btnSend.TabIndex = 3;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.lblRxFormat);
			this.flowLayoutPanel1.Controls.Add(this.rbRxMsgHex);
			this.flowLayoutPanel1.Controls.Add(this.rbRxMsgASCII);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 426);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(208, 24);
			this.flowLayoutPanel1.TabIndex = 19;
			// 
			// lblRxFormat
			// 
			this.lblRxFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRxFormat.AutoSize = true;
			this.lblRxFormat.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblRxFormat.Location = new System.Drawing.Point(3, 5);
			this.lblRxFormat.Name = "lblRxFormat";
			this.lblRxFormat.Size = new System.Drawing.Size(63, 15);
			this.lblRxFormat.TabIndex = 16;
			this.lblRxFormat.Text = "Format:";
			// 
			// rbRxMsgHex
			// 
			this.rbRxMsgHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbRxMsgHex.AutoSize = true;
			this.rbRxMsgHex.Location = new System.Drawing.Point(72, 3);
			this.rbRxMsgHex.Name = "rbRxMsgHex";
			this.rbRxMsgHex.Size = new System.Drawing.Size(55, 19);
			this.rbRxMsgHex.TabIndex = 15;
			this.rbRxMsgHex.Text = "Hex";
			this.rbRxMsgHex.UseVisualStyleBackColor = true;
			this.rbRxMsgHex.Click += new System.EventHandler(this.rbRxMsgHex_Click);
			// 
			// rbRxMsgASCII
			// 
			this.rbRxMsgASCII.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbRxMsgASCII.AutoSize = true;
			this.rbRxMsgASCII.Checked = true;
			this.rbRxMsgASCII.Location = new System.Drawing.Point(133, 3);
			this.rbRxMsgASCII.Name = "rbRxMsgASCII";
			this.rbRxMsgASCII.Size = new System.Drawing.Size(63, 19);
			this.rbRxMsgASCII.TabIndex = 14;
			this.rbRxMsgASCII.TabStop = true;
			this.rbRxMsgASCII.Text = "ASCII";
			this.rbRxMsgASCII.UseVisualStyleBackColor = true;
			this.rbRxMsgASCII.Click += new System.EventHandler(this.rbRxMsgASCII_Click);
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.lblSendFormat);
			this.flowLayoutPanel2.Controls.Add(this.rbSendHex);
			this.flowLayoutPanel2.Controls.Add(this.rbSendASCII);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(13, 516);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(208, 24);
			this.flowLayoutPanel2.TabIndex = 20;
			// 
			// lblSendFormat
			// 
			this.lblSendFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSendFormat.AutoSize = true;
			this.lblSendFormat.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lblSendFormat.Location = new System.Drawing.Point(3, 5);
			this.lblSendFormat.Name = "lblSendFormat";
			this.lblSendFormat.Size = new System.Drawing.Size(63, 15);
			this.lblSendFormat.TabIndex = 17;
			this.lblSendFormat.Text = "Format:";
			// 
			// rbSendHex
			// 
			this.rbSendHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbSendHex.AutoSize = true;
			this.rbSendHex.Location = new System.Drawing.Point(72, 3);
			this.rbSendHex.Name = "rbSendHex";
			this.rbSendHex.Size = new System.Drawing.Size(55, 19);
			this.rbSendHex.TabIndex = 18;
			this.rbSendHex.TabStop = true;
			this.rbSendHex.Text = "Hex";
			this.rbSendHex.UseVisualStyleBackColor = true;
			this.rbSendHex.Click += new System.EventHandler(this.rbSendHex_Click);
			// 
			// rbSendASCII
			// 
			this.rbSendASCII.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.rbSendASCII.AutoSize = true;
			this.rbSendASCII.Checked = true;
			this.rbSendASCII.Location = new System.Drawing.Point(133, 3);
			this.rbSendASCII.Name = "rbSendASCII";
			this.rbSendASCII.Size = new System.Drawing.Size(63, 19);
			this.rbSendASCII.TabIndex = 13;
			this.rbSendASCII.TabStop = true;
			this.rbSendASCII.Text = "ASCII";
			this.rbSendASCII.UseVisualStyleBackColor = true;
			this.rbSendASCII.Click += new System.EventHandler(this.rbSendASCII_Click);
			// 
			// btnConnect
			// 
			this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.btnConnect.Location = new System.Drawing.Point(13, 13);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(134, 23);
			this.btnConnect.TabIndex = 0;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnShortKey
			// 
			this.btnShortKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.btnShortKey.Location = new System.Drawing.Point(365, 13);
			this.btnShortKey.Name = "btnShortKey";
			this.btnShortKey.Size = new System.Drawing.Size(74, 23);
			this.btnShortKey.TabIndex = 12;
			this.btnShortKey.Text = "Short Key";
			this.btnShortKey.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(582, 553);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MinimumSize = new System.Drawing.Size(600, 600);
			this.Name = "Form1";
			this.Text = "Tester";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.RichTextBox rtbLog;
		private System.Windows.Forms.TextBox txtSendMsg;
		private System.Windows.Forms.Label lblSend;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Button btnLogClear;
		private System.Windows.Forms.TextBox txtStartMsg;
		private System.Windows.Forms.Label lblStartMsg;
		private System.Windows.Forms.Label lblEndMsg;
		private System.Windows.Forms.TextBox txtEndMsg;
		private System.Windows.Forms.Button btnSettings;
		private System.Windows.Forms.Button btnShortKey;
		private System.Windows.Forms.RadioButton rbSendASCII;
		private System.Windows.Forms.RadioButton rbRxMsgASCII;
		private System.Windows.Forms.RadioButton rbRxMsgHex;
		private System.Windows.Forms.Label lblRxFormat;
		private System.Windows.Forms.Label lblSendFormat;
		private System.Windows.Forms.RadioButton rbSendHex;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
	}
}

