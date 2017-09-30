using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Steam_Overlay_Hooking_Tool
{
	class XML_Downloader
	{
		private string location = "https://raw.githubusercontent.com/SuiMachine/Steam-Overlay-Hooking-Helper/master/XML/AppHookInfos.xml";
		private string FileName = "AppHookInfos.xml";

		public XML_Downloader()
		{
		}

		public bool downloadFile()
		{
			WebClient wbClient = new WebClient();
			Uri downloadLocation = new Uri(location);

			string TempLocation = Path.GetTempFileName();
			try { wbClient.DownloadFile(downloadLocation, TempLocation); }
			catch { return false; }

			FileInfo file = new FileInfo(TempLocation);
			if (file.Length == 0)
			{
				return false;
			}

			File.Copy(TempLocation, Path.Combine(Directory.GetCurrentDirectory(), FileName), true);

			return true;
		}
	}
}
