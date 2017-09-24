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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
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
			this.cbShowTxRxSymbol.Location = new System.Drawing.Point(12, 70);
			this.cbShowTxRxSymbol.Name = "cbShowTxRxSymbol";
			this.cbShowTxRxSymbol.Size = new System.Drawing.Size(167, 19);
			this.cbShowTxRxSymbol.TabIndex = 1;
			this.cbShowTxRxSymbol.Text = "Show Tx/Rx Symbol";
			this.cbShowTxRxSymbol.UseVisualStyleBackColor = true;
			this.cbShowTxRxSymbol.CheckedChanged += new System.EventHandler(this.cbShowTxRxSymbol_CheckedChanged);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(115, 221);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(196, 221);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtTxSymbol
			// 
			this.txtTxSymbol.Location = new System.Drawing.Point(163, 95);
			this.txtTxSymbol.Name = "txtTxSymbol";
			this.txtTxSymbol.Size = new System.Drawing.Size(74, 25);
			this.txtTxSymbol.TabIndex = 4;
			this.txtTxSymbol.TextChanged += new System.EventHandler(this.txtTxSymbol_TextChanged);
			// 
			// txtRxSymbol
			// 
			this.txtRxSymbol.Location = new System.Drawing.Point(163, 129);
			this.txtRxSymbol.Name = "txtRxSymbol";
			this.txtRxSymbol.Size = new System.Drawing.Size(74, 25);
			this.txtRxSymbol.TabIndex = 5;
			this.txtRxSymbol.TextChanged += new System.EventHandler(this.txtRxSymbol_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(67, 98);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 15);
			this.label1.TabIndex = 6;
			this.label1.Text = "Tx Symbol";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(70, 132);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 15);
			this.label2.TabIndex = 7;
			this.label2.Text = "RxSymbol";
			// 
			// SettingControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(283, 256);
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}