﻿namespace ProtocolTester
{
	partial class CommScheduler
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommScheduler));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.dgvSchedule = new System.Windows.Forms.DataGridView();
			this.cEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.cType = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.cFormat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cCycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cDelayMs = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cSend = new System.Windows.Forms.DataGridViewButtonColumn();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.lblCycle = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblTime = new System.Windows.Forms.Label();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnNewItem = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.dockingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.dgvSchedule, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 5, 1);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// dgvSchedule
			// 
			this.dgvSchedule.AllowDrop = true;
			this.dgvSchedule.AllowUserToAddRows = false;
			this.dgvSchedule.AllowUserToResizeRows = false;
			this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cEnable,
            this.cType,
            this.cFormat,
            this.cName,
            this.cValue,
            this.cCycle,
            this.cDelayMs,
            this.cSend});
			this.tableLayoutPanel1.SetColumnSpan(this.dgvSchedule, 6);
			resources.ApplyResources(this.dgvSchedule, "dgvSchedule");
			this.dgvSchedule.Name = "dgvSchedule";
			this.dgvSchedule.RowHeadersVisible = false;
			this.dgvSchedule.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgvSchedule.RowTemplate.Height = 27;
			this.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvSchedule.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchedule_CellEndEdit);
			this.dgvSchedule.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSchedule_CellMouseDown);
			this.dgvSchedule.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSchedule_CellMouseMove);
			this.dgvSchedule.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSchedule_CellMouseUp);
			this.dgvSchedule.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSchedule_CellValueChanged);
			this.dgvSchedule.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvSchedule_CurrentCellDirtyStateChanged);
			this.dgvSchedule.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvSchedule_DragDrop);
			this.dgvSchedule.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvSchedule_DragEnter);
			this.dgvSchedule.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvSchedule_MouseUp);
			// 
			// cEnable
			// 
			this.cEnable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			resources.ApplyResources(this.cEnable, "cEnable");
			this.cEnable.Name = "cEnable";
			this.cEnable.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// cType
			// 
			this.cType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
			resources.ApplyResources(this.cType, "cType");
			this.cType.Items.AddRange(new object[] {
            "SEND",
            "DELAY"});
			this.cType.Name = "cType";
			this.cType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// cFormat
			// 
			this.cFormat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			resources.ApplyResources(this.cFormat, "cFormat");
			this.cFormat.Name = "cFormat";
			this.cFormat.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// cName
			// 
			resources.ApplyResources(this.cName, "cName");
			this.cName.Name = "cName";
			// 
			// cValue
			// 
			this.cValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			resources.ApplyResources(this.cValue, "cValue");
			this.cValue.Name = "cValue";
			// 
			// cCycle
			// 
			this.cCycle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			resources.ApplyResources(this.cCycle, "cCycle");
			this.cCycle.Name = "cCycle";
			this.cCycle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// cDelayMs
			// 
			this.cDelayMs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			resources.ApplyResources(this.cDelayMs, "cDelayMs");
			this.cDelayMs.MaxInputLength = 10;
			this.cDelayMs.Name = "cDelayMs";
			this.cDelayMs.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.cDelayMs.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// cSend
			// 
			this.cSend.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
			resources.ApplyResources(this.cSend, "cSend");
			this.cSend.Name = "cSend";
			this.cSend.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.cSend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.cSend.Text = "Send";
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.btnStart);
			this.flowLayoutPanel2.Controls.Add(this.btnStop);
			this.flowLayoutPanel2.Controls.Add(this.lblCycle);
			this.flowLayoutPanel2.Controls.Add(this.label1);
			this.flowLayoutPanel2.Controls.Add(this.lblTime);
			resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			// 
			// btnStart
			// 
			resources.ApplyResources(this.btnStart, "btnStart");
			this.btnStart.Name = "btnStart";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStop
			// 
			resources.ApplyResources(this.btnStop, "btnStop");
			this.btnStop.Name = "btnStop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// lblCycle
			// 
			resources.ApplyResources(this.lblCycle, "lblCycle");
			this.lblCycle.Name = "lblCycle";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// lblTime
			// 
			resources.ApplyResources(this.lblTime, "lblTime");
			this.lblTime.Name = "lblTime";
			// 
			// flowLayoutPanel3
			// 
			this.flowLayoutPanel3.Controls.Add(this.btnNewItem);
			this.flowLayoutPanel3.Controls.Add(this.btnDelete);
			resources.ApplyResources(this.flowLayoutPanel3, "flowLayoutPanel3");
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			// 
			// btnNewItem
			// 
			resources.ApplyResources(this.btnNewItem, "btnNewItem");
			this.btnNewItem.Name = "btnNewItem";
			this.btnNewItem.UseVisualStyleBackColor = true;
			this.btnNewItem.Click += new System.EventHandler(this.btnNewItem_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.btnDelete, "btnDelete");
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.btnDown);
			this.flowLayoutPanel1.Controls.Add(this.btnUp);
			resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			// 
			// btnDown
			// 
			this.btnDown.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.btnDown, "btnDown");
			this.btnDown.Name = "btnDown";
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnUp
			// 
			resources.ApplyResources(this.btnUp, "btnUp");
			this.btnUp.Name = "btnUp";
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dockingToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
			// 
			// dockingToolStripMenuItem
			// 
			this.dockingToolStripMenuItem.CheckOnClick = true;
			this.dockingToolStripMenuItem.Name = "dockingToolStripMenuItem";
			resources.ApplyResources(this.dockingToolStripMenuItem, "dockingToolStripMenuItem");
			this.dockingToolStripMenuItem.CheckedChanged += new System.EventHandler(this.dockingToolStripMenuItem_CheckedChanged);
			// 
			// CommScheduler
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Controls.Add(this.tableLayoutPanel1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CommScheduler";
			this.ShowInTaskbar = false;
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommScheduler_FormClosing);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataGridView dgvSchedule;
		private System.Windows.Forms.Button btnDown;
		private System.Windows.Forms.Button btnUp;
		private System.Windows.Forms.Button btnNewItem;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.Label lblCycle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem dockingToolStripMenuItem;
		private System.Windows.Forms.DataGridViewCheckBoxColumn cEnable;
		private System.Windows.Forms.DataGridViewComboBoxColumn cType;
		private System.Windows.Forms.DataGridViewCheckBoxColumn cFormat;
		private System.Windows.Forms.DataGridViewTextBoxColumn cName;
		private System.Windows.Forms.DataGridViewTextBoxColumn cValue;
		private System.Windows.Forms.DataGridViewTextBoxColumn cCycle;
		private System.Windows.Forms.DataGridViewTextBoxColumn cDelayMs;
		private System.Windows.Forms.DataGridViewButtonColumn cSend;
	}
}