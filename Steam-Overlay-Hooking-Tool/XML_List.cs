using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Steam_Overlay_Hooking_Tool
{
	public class ApplicationHookInfo
	{
		public string processName { get; set; }
		public string windowTitleRegex { get; set; }
		public bool manuallyClearFrames { get; set; }
		public int delay { get; set; }
		public bool is64bit { get; set; }

		public ApplicationHookInfo(string processName)
		{
			this.processName = processName;
		}

		public ApplicationHookInfo(string processName, string windowTitleRegex)
		{
			this.processName = processName;
			this.windowTitleRegex = windowTitleRegex;
		}

		public override string ToString()
		{
			return processName;
		}

		public static explicit operator string(ApplicationHookInfo obj)
		{
			return obj.processName;
		}
	}

	class XML_List
	{
		private List<ApplicationHookInfo> appHookList = null;

		public XML_List()
		{
			appHookList = new List<ApplicationHookInfo>()
			{
				new ApplicationHookInfo("trl", "Tomb Raider: Legend") {delay = 2000, is64bit = false, manuallyClearFrames = false }
			};
		}

		public Process GetProcessFromXMLList()
		{
			Process[] processes = Process.GetProcesses();

			foreach(var processChk in appHookList)
			{
				var procMatching = processes.Where(x => x.ProcessName.ToLower() == processChk.processName.ToLower());
				if(procMatching.Count() > 0)
				{
					Process[] currentProcMathing = procMatching.ToArray();
					if (processChk.windowTitleRegex != null && processChk.windowTitleRegex != "")
					{
						currentProcMathing = currentProcMathing.Where(x => Regex.IsMatch(x.MainWindowTitle, processChk.windowTitleRegex)).ToArray();
					}

					if (currentProcMathing.Length > 0)
						return currentProcMathing[0];
				}
			}

			return null;
		}

		public string GetLaunchParameters(Process proc)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("-pid " + proc.Id.ToString());
			ApplicationHookInfo hkInfo = appHookList.First(x => x.processName.ToLower() == proc.ProcessName.ToLower());
			sb.Append(" -manuallyclearframes " + (hkInfo.manuallyClearFrames ? "1" : "0"));
			System.Threading.Thread.Sleep(hkInfo.delay);

			return sb.ToString();
		}


	}
}
