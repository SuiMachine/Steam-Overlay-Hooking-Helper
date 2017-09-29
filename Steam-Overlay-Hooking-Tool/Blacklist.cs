using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Steam_Overlay_Hooking_Tool
{
	public static class Blacklist
	{
		private static string procName = Assembly.GetExecutingAssembly().Modules.First().Name.ToLower();

		private static string[] listOfBlackListedProcess = new string[]
		{
			"chrome",
			"discord",
			"javaw",
			"msbuild",
			"notepad++",
			procName.Remove(procName.Length-4, 4)
		};

		public static bool Contains(string processName)
		{
			processName = processName.ToLower();
			if (listOfBlackListedProcess.Contains(processName))
				return true;
			else
				return false;
		}
	}
}
