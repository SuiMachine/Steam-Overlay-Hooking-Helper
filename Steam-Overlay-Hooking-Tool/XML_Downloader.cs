using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace Steam_Overlay_Hooking_Tool
{
	class XML_Downloader
	{
		private string location = "https://raw.githubusercontent.com/SuiMachine/Steam-Overlay-Hooking-Helper/master/XML/AppHookInfos.xml";
		private string FileName = "AppHookInfosNew.xml";

		public XML_Downloader()
		{
		}

		public bool downloadFile()
		{
			WebClient wbClient = new WebClient();
			Uri downloadLocation = new Uri(location);

			string TempLocationFile = Path.GetTempFileName();
			try { wbClient.DownloadFile(downloadLocation, TempLocationFile); }
			catch { return false; }

			FileInfo newXMLfile = new FileInfo(TempLocationFile);
			if (newXMLfile.Length == 0)
			{
				return false;
			}

			string workDirXML = Path.Combine(Directory.GetCurrentDirectory(), FileName);

			File.Copy(TempLocationFile, workDirXML, true);
			return true;
		}
	}
}
