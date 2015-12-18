using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace arma3Launcher.Workers
{
    class RemoteReader
    {
        XmlDocument RemoteXmlInfo;

        public RemoteReader()
        {
            RemoteXmlInfo = new XmlDocument();
            RemoteXmlInfo.Load(Properties.GlobalValues.S_VersionXML);
        }

        /// <summary>
        /// Fetch TeamSpeak server info
        /// </summary>
        /// <returns>
        /// tsInfo[0]: server ip
        /// tsInfo[1]: server port
        /// tsInfo[2]: server password
        /// tsInfo[3]: default channel
        /// </returns>
        public string[] TeamSpeakInfo()
        {
            string[] tsInfo = new string[4];

            tsInfo[0] = RemoteXmlInfo.SelectSingleNode("//arma3Launcher//LauncherInfo//TeamSpeak").Attributes["ip"].Value;
            tsInfo[1] = RemoteXmlInfo.SelectSingleNode("//arma3Launcher//LauncherInfo//TeamSpeak").Attributes["port"].Value;
            tsInfo[2] = RemoteXmlInfo.SelectSingleNode("//arma3Launcher//LauncherInfo//TeamSpeak").Attributes["password"].Value;
            tsInfo[3] = RemoteXmlInfo.SelectSingleNode("//arma3Launcher//LauncherInfo//TeamSpeak").Attributes["channel"].Value;

            return tsInfo;
        }

        /// <summary>
        /// Fetch server data from current active pack
        /// </summary>
        /// <param name="activePack"></param>
        /// <returns>
        /// serverInfo[0]: server ip
        /// serverInfo[1]: server port
        /// serverInfo[2]: server password
        /// </returns>
        public string[] ServerInfo(string activePack)
        {
            string[] serverInfo = new string[3];

            serverInfo[0] = RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + activePack).Attributes["ip"].Value;
            serverInfo[1] = RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + activePack).Attributes["port"].Value;
            serverInfo[2] = RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + activePack).Attributes["password"].Value;

            return serverInfo;
        }

        /// <summary>
        /// Get addon packs
        /// </summary>
        /// <returns></returns>
        public object GetPacks()
        {

            return null;
        }

        /// <summary>
        /// Get addons and their versions from active pack
        /// </summary>
        /// <param name="activePack"></param>
        /// <returns>
        /// 
        /// </returns>
        public string[,] GetAddons(string activePack)
        {
            string[,] addonPack = new string[254, 2];
            int ap = 0;

            XmlNodeList xnl = RemoteXmlInfo.SelectNodes("//arma3Launcher//ModSetInfo//" + activePack + "//mod");
            foreach (XmlNode xn in xnl)
            {
                if (xn.Attributes["type"].Value == "mod" && xn.Attributes["name"].Value != "@dummy")
                {
                    addonPack[ap, 0] = xn.Attributes["name"].Value;
                    addonPack[ap, 1] = xn.Attributes["version"].Value;
                    ap++;
                }
            }

            return addonPack;
        }

        /// <summary>
        /// Compares addons between client and server
        /// </summary>
        /// <param name="activePack"></param>
        /// <returns></returns>
        public bool CompareAddons (string activePack)
        {
            return false;
        }
    }
}
