namespace ProtocolTester
{
	partial class ConnectForm
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
			this.tabConnect = new System.Windows.Forms.TabControl();
			this.tpSerial = new System.Windows.Forms.TabPage();
			this.btnSerialConnect = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cbPort = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbFlowControl = new System.Windows.Forms.ComboBox();
			this.cbSpeed = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cbStopBit = new System.Windows.Forms.ComboBox();
			this.cbDataBit = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cbParity = new System.Windows.Forms.ComboBox();
			this.tpTcpServer = new System.Windows.Forms.TabPage();
			this.tpTcpClient = new System.Windows.Forms.TabPage();
			this.tpUDP = new System.Windows.Forms.TabPage();
			this.tabConnect.SuspendLayout();
			this.tpSerial.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabConnect
			// 
			this.tabConnect.Controls.Add(this.tpSerial);
			this.tabConnect.Controls.Add(this.tpTcpServer);
			this.tabConnect.Controls.Add(this.tpTcpClient);
			this.tabConnect.Controls.Add(this.tpUDP);
			this.tabConnect.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabConnect.Location = new System.Drawing.Point(0, 0);
			this.tabConnect.Name = "tabConnect";
			this.tabConnect.SelectedIndex = 0;
			this.tabConnect.Size = new System.Drawing.Size(306, 324);
			this.tabConnect.TabIndex = 0;
			this.tabConnect.SelectedIndexChanged += new System.EventHandler(this.tabConnect_SelectedIndexChanged);
			// 
			// tpSerial
			// 
			this.tpSerial.Controls.Add(this.btnSerialConnect);
			this.tpSerial.Controls.Add(this.label1);
			this.tpSerial.Controls.Add(this.cbPort);
			this.tpSerial.Controls.Add(this.label2);
			this.tpSerial.Controls.Add(this.cbFlowControl);
			this.tpSerial.Controls.Add(this.cbSpeed);
			this.tpSerial.Controls.Add(this.label6);
			this.tpSerial.Controls.Add(this.label3);
			this.tpSerial.Controls.Add(this.cbStopBit);
			this.tpSerial.Controls.Add(this.cbDataBit);
			this.tpSerial.Controls.Add(this.label5);
			this.tpSerial.Controls.Add(this.label4);
			this.tpSerial.Controls.Add(this.cbParity);
			this.tpSerial.Location = new System.Drawing.Point(4, 25);
			this.tpSerial.Name = "tpSerial";
			this.tpSerial.Padding = new System.Windows.Forms.Padding(3);
			this.tpSerial.Size = new System.Drawing.Size(298, 295);
			this.tpSerial.TabIndex = 0;
			this.tpSerial.Text = "Serial";
			this.tpSerial.UseVisualStyleBackColor = true;
			// 
			// btnSerialConnect
			// 
			this.btnSerialConnect.Location = new System.Drawing.Point(159, 245);
			this.btnSerialConnect.Name = "btnSerialConnect";
			this.btnSerialConnect.Size = new System.Drawing.Size(103, 29);
			this.btnSerialConnect.TabIndex = 14;
			this.btnSerialConnect.Text = "Connect";
			this.btnSerialConnect.UseVisualStyleBackColor = true;
			this.btnSerialConnect.Click += new System.EventHandler(this.btnSerialConnect_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(42, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Port";
			// 
			// cbPort
			// 
			this.cbPort.FormattingEnabled = true;
			this.cbPort.Location = new System.Drawing.Point(141, 25);
			this.cbPort.Name = "cbPort";
			this.cbPort.Size = new System.Drawing.Size(121, 23);
			this.cbPort.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(42, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Speed";
			// 
			// cbFlowControl
			// 
			this.cbFlowControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFlowControl.FormattingEnabled = true;
			this.cbFlowControl.Items.AddRange(new object[] {
            "None",
            "Xon/Xoff",
            "RTS/CTS"});
			this.cbFlowControl.Location = new System.Drawing.Point(141, 194);
			this.cbFlowControl.Name = "cbFlowControl";
			this.cbFlowControl.Size = new System.Drawing.Size(121, 23);
			this.cbFlowControl.TabIndex = 13;
			// 
			// cbSpeed
			// 
			this.cbSpeed.FormattingEnabled = true;
			this.cbSpeed.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460300",
            "921600"});
			this.cbSpeed.Location = new System.Drawing.Point(141, 78);
			this.cbSpeed.Name = "cbSpeed";
			this.cbSpeed.Size = new System.Drawing.Size(121, 23);
			this.cbSpeed.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(42, 197);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 15);
			this.label6.TabIndex = 12;
			this.label6.Text = "Flow Control";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(42, 110);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 15);
			this.label3.TabIndex = 6;
			this.label3.Text = "Data Bit";
			// 
			// cbStopBit
			// 
			this.cbStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStopBit.FormattingEnabled = true;
			this.cbStopBit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
			this.cbStopBit.Location = new System.Drawing.Point(141, 165);
			this.cbStopBit.Name = "cbStopBit";
			this.cbStopBit.Size = new System.Drawing.Size(121, 23);
			this.cbStopBit.TabIndex = 11;
			// 
			// cbDataBit
			// 
			this.cbDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDataBit.FormattingEnabled = true;
			this.cbDataBit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
			this.cbDataBit.Location = new System.Drawing.Point(141, 107);
			this.cbDataBit.Name = "cbDataBit";
			this.cbDataBit.Size = new System.Drawing.Size(121, 23);
			this.cbDataBit.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(42, 168);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(60, 15);
			this.label5.TabIndex = 10;
			this.label5.Text = "Stop Bit";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(42, 139);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 15);
			this.label4.TabIndex = 8;
			this.label4.Text = "Parity";
			// 
			// cbParity
			// 
			this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbParity.FormattingEnabled = true;
			this.cbParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
			this.cbParity.Location = new System.Drawing.Point(141, 136);
			this.cbParity.Name = "cbParity";
			this.cbParity.Size = new System.Drawing.Size(121, 23);
			this.cbParity.TabIndex = 9;
			// 
			// tpTcpServer
			// 
			this.tpTcpServer.Location = new System.Drawing.Point(4, 25);
			this.tpTcpServer.Name = "tpTcpServer";
			this.tpTcpServer.Padding = new System.Windows.Forms.Padding(3);
			this.tpTcpServer.Size = new System.Drawing.Size(298, 295);
			this.tpTcpServer.TabIndex = 1;
			this.tpTcpServer.Text = "TCP Server";
			this.tpTcpServer.UseVisualStyleBackColor = true;
			// 
			// tpTcpClient
			// 
			this.tpTcpClient.Location = new System.Drawing.Point(4, 25);
			this.tpTcpClient.Name = "tpTcpClient";
			this.tpTcpClient.Size = new System.Drawing.Size(298, 295);
			this.tpTcpClient.TabIndex = 3;
			this.tpTcpClient.Text = "TCP Client";
			this.tpTcpClient.UseVisualStyleBackColor = true;
			// 
			// tpUDP
			// 
			this.tpUDP.Location = new System.Drawing.Point(4, 25);
			this.tpUDP.Name = "tpUDP";
			this.tpUDP.Size = new System.Drawing.Size(298, 295);
			this.tpUDP.TabIndex = 2;
			this.tpUDP.Text = "UDP";
			this.tpUDP.UseVisualStyleBackColor = true;
			// 
			// ConnectForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(306, 324);
			this.Controls.Add(this.tabConnect);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ConnectForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Connect";
			this.tabConnect.ResumeLayout(false);
			this.tpSerial.ResumeLayout(false);
			this.tpSerial.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabConnect;
		private System.Windows.Forms.TabPage tpSerial;
		private System.Windows.Forms.TabPage tpTcpServer;
		private System.Windows.Forms.TabPage tpUDP;
		private System.Windows.Forms.TabPage tpTcpClient;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbPort;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbSpeed;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbDataBit;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox cbParity;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cbStopBit;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbFlowControl;
		private System.Windows.Forms.Button btnSerialConnect;
	}
}