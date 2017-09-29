namespace Steam_Overlay_Hooking_Tool
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.RadialB_BasedOnXML = new System.Windows.Forms.RadioButton();
			this.RadialB_WindowHooking = new System.Windows.Forms.RadioButton();
			this.CB_Processes = new System.Windows.Forms.ComboBox();
			this.B_Refresh = new System.Windows.Forms.Button();
			this.B_Hook = new System.Windows.Forms.Button();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.trayIconMenuStrip_StopHooking = new System.Windows.Forms.ToolStripMenuItem();
			this.trayIconMenuStrip_Exit = new System.Windows.Forms.ToolStripMenuItem();
			this.panel3 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.AppCheckTimer = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.trayIconMenuStrip.SuspendLayout();
			this.panel3.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(304, 56);
			this.panel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(304, 45);
			this.label1.TabIndex = 0;
			this.label1.Text = "This tool is not developed by Valve and is provided as is. By using it, you agree" +
    " to take full responsbility for all of the issues it might cause.";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.RadialB_BasedOnXML);
			this.panel2.Controls.Add(this.RadialB_WindowHooking);
			this.panel2.Controls.Add(this.CB_Processes);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 56);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(304, 65);
			this.panel2.TabIndex = 1;
			// 
			// RadialB_BasedOnXML
			// 
			this.RadialB_BasedOnXML.AutoSize = true;
			this.RadialB_BasedOnXML.Checked = true;
			this.RadialB_BasedOnXML.Location = new System.Drawing.Point(12, 35);
			this.RadialB_BasedOnXML.Name = "RadialB_BasedOnXML";
			this.RadialB_BasedOnXML.Size = new System.Drawing.Size(150, 17);
			this.RadialB_BasedOnXML.TabIndex = 3;
			this.RadialB_BasedOnXML.TabStop = true;
			this.RadialB_BasedOnXML.Text = "Automatic (based on XML)";
			this.RadialB_BasedOnXML.UseVisualStyleBackColor = true;
			// 
			// RadialB_WindowHooking
			// 
			this.RadialB_WindowHooking.AutoSize = true;
			this.RadialB_WindowHooking.Location = new System.Drawing.Point(12, 12);
			this.RadialB_WindowHooking.Name = "RadialB_WindowHooking";
			this.RadialB_WindowHooking.Size = new System.Drawing.Size(98, 17);
			this.RadialB_WindowHooking.TabIndex = 2;
			this.RadialB_WindowHooking.Text = "Game Window:";
			this.RadialB_WindowHooking.UseVisualStyleBackColor = true;
			// 
			// CB_Processes
			// 
			this.CB_Processes.FormattingEnabled = true;
			this.CB_Processes.Location = new System.Drawing.Point(116, 11);
			this.CB_Processes.Name = "CB_Processes";
			this.CB_Processes.Size = new System.Drawing.Size(176, 21);
			this.CB_Processes.TabIndex = 1;
			// 
			// B_Refresh
			// 
			this.B_Refresh.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.B_Refresh.Location = new System.Drawing.Point(190, 8);
			this.B_Refresh.Name = "B_Refresh";
			this.B_Refresh.Size = new System.Drawing.Size(75, 23);
			this.B_Refresh.TabIndex = 3;
			this.B_Refresh.Text = "Refresh";
			this.B_Refresh.UseVisualStyleBackColor = true;
			this.B_Refresh.Click += new System.EventHandler(this.B_Refresh_Click);
			// 
			// B_Hook
			// 
			this.B_Hook.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.B_Hook.Location = new System.Drawing.Point(38, 8);
			this.B_Hook.Name = "B_Hook";
			this.B_Hook.Size = new System.Drawing.Size(75, 23);
			this.B_Hook.TabIndex = 2;
			this.B_Hook.Text = "Hook it!";
			this.B_Hook.UseVisualStyleBackColor = true;
			this.B_Hook.Click += new System.EventHandler(this.B_Hook_Click);
			// 
			// trayIcon
			// 
			this.trayIcon.ContextMenuStrip = this.trayIconMenuStrip;
			this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
			this.trayIcon.Text = "Steam Overlay Hooking Tool";
			this.trayIcon.Visible = true;
			this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
			// 
			// trayIconMenuStrip
			// 
			this.trayIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayIconMenuStrip_StopHooking,
            this.trayIconMenuStrip_Exit});
			this.trayIconMenuStrip.Name = "contextMenuStrip1";
			this.trayIconMenuStrip.Size = new System.Drawing.Size(146, 48);
			// 
			// trayIconMenuStrip_StopHooking
			// 
			this.trayIconMenuStrip_StopHooking.Name = "trayIconMenuStrip_StopHooking";
			this.trayIconMenuStrip_StopHooking.Size = new System.Drawing.Size(145, 22);
			this.trayIconMenuStrip_StopHooking.Text = "Stop hooking";
			// 
			// trayIconMenuStrip_Exit
			// 
			this.trayIconMenuStrip_Exit.Name = "trayIconMenuStrip_Exit";
			this.trayIconMenuStrip_Exit.Size = new System.Drawing.Size(145, 22);
			this.trayIconMenuStrip_Exit.Text = "Exit";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.tableLayoutPanel1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 121);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(304, 40);
			this.panel3.TabIndex = 2;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.B_Refresh, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.B_Hook, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(304, 40);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// AppCheckTimer
			// 
			this.AppCheckTimer.Interval = 250;
			this.AppCheckTimer.Tick += new System.EventHandler(this.AppCheckTimer_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(304, 163);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "Steam Overlay Hooking Helper";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.trayIconMenuStrip.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ComboBox CB_Processes;
		private System.Windows.Forms.Button B_Hook;
		private System.Windows.Forms.Button B_Refresh;
		private System.Windows.Forms.NotifyIcon trayIcon;
		private System.Windows.Forms.RadioButton RadialB_WindowHooking;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.RadioButton RadialB_BasedOnXML;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Timer AppCheckTimer;
		private System.Windows.Forms.ContextMenuStrip trayIconMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem trayIconMenuStrip_StopHooking;
		private System.Windows.Forms.ToolStripMenuItem trayIconMenuStrip_Exit;
	}
}

