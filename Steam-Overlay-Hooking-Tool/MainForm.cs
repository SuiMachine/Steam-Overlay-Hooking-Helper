using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Steam_Overlay_Hooking_Tool
{
	public partial class MainForm : Form
	{
		private bool hooked { get; set; }
		private Process gameProcess;
		private string SteamOverlayLocation = "";
		private string OverlayProc = "GameOverlayUI.exe";
		private XML_List xmlList;
		private XML_Downloader downloader;


		public MainForm()
		{
			InitializeComponent();
			hooked = false;
		}

		private void RefreshAppWindows()
		{
			CB_Processes.Items.Clear();
			var Processes = Process.GetProcesses();
			foreach(var proces in Processes)
			{
				if(proces.MainWindowTitle != null && proces.MainWindowTitle != "")
				{
					if(!Blacklist.Contains(proces.ProcessName))
					{
						CB_Processes.Items.Add(proces.ProcessName);
					}
				}
			}
		}

		private void SetSteamLocation()
		{
			var registry = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Valve\\Steam");
			if (registry != null)
			{
				SteamOverlayLocation = (string)registry.GetValue("InstallPath");
			}
		}

		private void AppCheckTimer_Tick(object sender, EventArgs e)
		{
			if (!hooked)
			{
				if (RadialB_WindowHooking.Checked)
				{
					string selected = CB_Processes.SelectedItem.ToString();
					Process[] myProcess = Process.GetProcessesByName(selected);
					if (myProcess.Length > 0)
					{
						gameProcess = myProcess[0];
						Process gameOverlayProc = new Process();
						gameOverlayProc.StartInfo.WorkingDirectory = SteamOverlayLocation;
						gameOverlayProc.StartInfo.FileName = Path.Combine(SteamOverlayLocation, OverlayProc);
						gameOverlayProc.StartInfo.Arguments = String.Format("-pid {0} -manuallyclearframes {1}", gameProcess.Id, 0);
						gameOverlayProc.Start();
						hooked = true;
						Debug.WriteLine("Hooking to: " + gameProcess.ProcessName + " (" + gameProcess.MainWindowTitle + ")");
					}
				}
				else
				{
					gameProcess = xmlList.GetProcessFromXMLList();
					if (gameProcess != null)
					{
						Process gameOverlayProc = new Process();
						gameOverlayProc.StartInfo.WorkingDirectory = SteamOverlayLocation;
						gameOverlayProc.StartInfo.FileName = Path.Combine(SteamOverlayLocation, OverlayProc);
						gameOverlayProc.StartInfo.Arguments = xmlList.GetLaunchParameters(gameProcess);
						gameOverlayProc.Start();
						hooked = true;
						Debug.WriteLine("Hooking to: " + gameProcess.ProcessName + " (" + gameProcess.MainWindowTitle + ")");
					}
				}
			}
			else
			{
				if (gameProcess.HasExited)
				{
					//Could probably be done with an event.
					Debug.WriteLine("Lost game process. Starting to watch for processes again.");
					hooked = false;
				}
			}
		}

		#region FormEvents
		private void MainForm_Load(object sender, EventArgs e)
		{
			SetSteamLocation();
			RefreshAppWindows();
			this.trayIconMenuStrip_StopHooking.Click += TrayIconMenuStrip_StopHooking_Click;
			this.trayIconMenuStrip_Exit.Click += TrayIconMenuStrip_Exit_Click;
			downloader = new XML_Downloader();
			if(!downloader.downloadFile())
			{
				MessageBox.Show("Failed to download game XML.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}

			xmlList = new XML_List();
		}

		private void TrayIconMenuStrip_StopHooking_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
		}

		private void TrayIconMenuStrip_Exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void B_Refresh_Click(object sender, EventArgs e)
		{
			RefreshAppWindows();
		}

		private void B_Hook_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		private void MainForm_SizeChanged(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.AppCheckTimer.Start();
				this.trayIcon.Visible = true;
				this.Hide();
#if DEBUG
				Debug.WriteLine("Window changes to Minimized. Starting timer.");
#endif
			}
			else
			{
				this.AppCheckTimer.Stop();
				this.trayIcon.Visible = false;
				this.Show();

#if DEBUG
				Debug.WriteLine("Window changes to Normal. Stopping timer.");
#endif
			}
		}

		private void trayIcon_DoubleClick(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			trayIcon.Visible = false;
		}
#endregion
	}
}
