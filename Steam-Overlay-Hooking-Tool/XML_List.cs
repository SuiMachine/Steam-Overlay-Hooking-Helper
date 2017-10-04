using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;

namespace Steam_Overlay_Hooking_Tool
{
	public class ApplicationHookInfo
	{
		public string processName { get; set; }
		public string windowTitleRegex { get; set; }
		public bool manuallyClearFrames { get; set; }
		public bool enableMovies { get; set; }
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
		private const string XMLFILENAME = "AppHookInfos.xml";
		private const string TEMPDOCFILENAME = "AppHookInfosNew.xml";
		private List<ApplicationHookInfo> appHookList = null;
		private XmlDocument xmlDoc;
		private XmlNode rootNode;

		public XML_List()
		{
			xmlDoc = new XmlDocument();

			if (File.Exists(XMLFILENAME))
			{
				DateTime downloadedXML = getDateForDownloadedXML();
				FileInfo currentXML = new FileInfo(XMLFILENAME);
#if DEBUG
				Debug.WriteLine("Downloaded XML DateTime: " + downloadedXML.ToString());
				Debug.WriteLine("Current XML DateTime:" + currentXML.LastWriteTimeUtc.ToString());
#endif
				if(File.Exists(TEMPDOCFILENAME))
				{
					if (downloadedXML > currentXML.LastWriteTimeUtc)
					{
						File.Delete(XMLFILENAME);
						File.Move(TEMPDOCFILENAME, XMLFILENAME);
					}
					else
					{
						File.Delete(TEMPDOCFILENAME);
					}
				}

				xmlDoc.Load(XMLFILENAME);
			}

			rootNode = GetCreateNode("RootGamesNode");
			appHookList = new List<ApplicationHookInfo>();
			foreach(XmlNode gameNode in rootNode.ChildNodes)
			{
				ApplicationHookInfo newAppHKInfo = new ApplicationHookInfo(gameNode["Process"].InnerText);
				foreach (XmlNode childNode in gameNode)
				{
					if (childNode.Name == "WindowTitle") newAppHKInfo.windowTitleRegex = childNode.InnerText;
					else if (childNode.Name == "Delay") newAppHKInfo.delay = int.Parse(childNode.InnerText);
					else if (childNode.Name == "ManuallyClearFrames") newAppHKInfo.manuallyClearFrames = bool.Parse(childNode.InnerText);
					else if (childNode.Name == "EnableMovies") newAppHKInfo.enableMovies = bool.Parse(childNode.InnerText);
					else if (childNode.Name == "Is64Bit") newAppHKInfo.is64bit = bool.Parse(childNode.InnerText);
				}
				appHookList.Add(newAppHKInfo);
			}
		}

		private DateTime getDateForDownloadedXML()
		{
			if (File.Exists(TEMPDOCFILENAME))
			{
				XmlDocument tempDoc = new XmlDocument();
				tempDoc.Load(TEMPDOCFILENAME);
				XmlNode rtNode = tempDoc["RootGamesNode"];
				DateTime tempDate = new DateTime();
				var attribs = rtNode.Attributes;
				if (DateTime.TryParse(rtNode.Attributes["Modified"].Value, out tempDate))
					return tempDate;
				else
					return DateTime.MinValue;
			}
			else
			{
				return DateTime.MinValue;
			}
		}

		private XmlNode GetCreateNode(string NodeName, XmlNode parentNode = null)
		{
			if (parentNode == null)
			{
				XmlNode retNode;
				if (xmlDoc[NodeName] == null)
				{
					retNode = xmlDoc.CreateElement(NodeName);
					xmlDoc.AppendChild(retNode);
				}
				else
					retNode = xmlDoc[NodeName];

				return retNode;
			}
			else
			{
				XmlNode retNode;
				if (parentNode[NodeName] == null)
				{
					retNode = xmlDoc.CreateElement(NodeName);
					parentNode.AppendChild(retNode);
				}
				else
					retNode = parentNode[NodeName];

				return retNode;
			}
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
			sb.Append(hkInfo.enableMovies ? " -enablemovies 1" : "");
			System.Threading.Thread.Sleep(hkInfo.delay);
			return sb.ToString();
		}


	}

	public static class XMLSettingsHelper
	{
		public static TYPE Parse<TYPE>(this string value, object DEFAULT_VALUE)
		{
			try
			{
				TYPE result = default(TYPE);
				if (!string.IsNullOrEmpty(value))
				{
					// we are not going to handle exception here
					// if you need SafeParse then you should create
					// another method specially for that.
					TypeConverter tc = TypeDescriptor.GetConverter(typeof(TYPE));
					result = (TYPE)tc.ConvertFrom(value);
				}
				return result;
			}
			catch
			{
				return (TYPE)DEFAULT_VALUE;
			}
		}
	}
}
