using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using System.Xml;
using System.Windows.Forms;
//using System.Drawing;
using System.Reflection;
//using System.Threading;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace arma3Launcher.Workers
{
    class zCheckUpdate
    {
        private readonly Button btn_Update;
        private readonly Button btn_checkUpdate;
        private readonly Label txt_Cur;
        private readonly Label txt_New;

        private readonly Label txt_versiontag;

        private string urlversionxml = Properties.GlobalValues.S_VersionXML;
        private string NewVersionS = string.Empty;
        private string CurVersionS = string.Empty;

        public zCheckUpdate(Label VersionTag)
        {
            txt_versiontag = VersionTag;
        }

        public zCheckUpdate(Button BtnUpdate, Button BtnCheckUpdate, Label TxtCurVersion, Label TxtNewVersion)
        {
            btn_Update = BtnUpdate;
            btn_checkUpdate = BtnCheckUpdate;
            txt_Cur = TxtCurVersion;
            txt_New = TxtNewVersion;
        }

        public bool QuickCheck()
        {
            Version NewVersion = null;
            Version CurVersion = null;

            bool isUpdate = false;

            NewVersionS = string.Empty;
            CurVersionS = string.Empty;
            string aux_vBuild = string.Empty;

            try
            {
                try
                {
                    #region NewUpdateXmlInfo
                    XmlDocument NewUpdateXmlInfo = new XmlDocument();
                    NewUpdateXmlInfo.Load(urlversionxml);

                    int new_versionmajor = Convert.ToInt32(NewUpdateXmlInfo.SelectSingleNode("//arma3Launcher//LauncherInfo//Version").Attributes["major"].Value);
                    int new_versionminor = Convert.ToInt32(NewUpdateXmlInfo.SelectSingleNode("//arma3Launcher//LauncherInfo//Version").Attributes["minor"].Value);
                    int new_versionbuild = Convert.ToInt32(NewUpdateXmlInfo.SelectSingleNode("//arma3Launcher//LauncherInfo//Version").Attributes["build"].Value);
                    string new_versiontag = NewUpdateXmlInfo.SelectSingleNode("//arma3Launcher//LauncherInfo//Version").Attributes["tag"].Value;

                    NewVersion = new Version(new_versionmajor, new_versionminor, new_versionbuild);
                    #endregion

                    if (NewVersion.Build != 0)
                        aux_vBuild = "." + NewVersion.Build;
                    else
                        aux_vBuild = string.Empty;

                    if (new_versiontag != string.Empty)
                        NewVersionS = NewVersion.Major + "." + NewVersion.Minor + aux_vBuild + " (" + new_versiontag + ")";
                    else
                        NewVersionS = NewVersion.Major + "." + NewVersion.Minor + aux_vBuild;
                }
                catch { }

                try
                {
                    #region CurVersionInfo
                    int cur_versionmajor = Assembly.GetExecutingAssembly().GetName().Version.Major;
                    int cur_versionminor = Assembly.GetExecutingAssembly().GetName().Version.Minor;
                    int cur_versionbuild = Assembly.GetExecutingAssembly().GetName().Version.Build;
                    string cur_versiontag = Properties.GlobalValues.S_VersionTag;

                    CurVersion = new Version(cur_versionmajor, cur_versionminor, cur_versionbuild);
                    #endregion

                    if (CurVersion.Build != 0)
                        aux_vBuild = "." + CurVersion.Build;
                    else
                        aux_vBuild = string.Empty;

                    txt_versiontag.Text = cur_versiontag;

                    if (cur_versiontag != string.Empty)
                        CurVersionS = CurVersion.Major + "." + CurVersion.Minor + aux_vBuild + " (" + cur_versiontag + ")";
                    else
                        CurVersionS = CurVersion.Major + "." + CurVersion.Minor + aux_vBuild;
                }
                catch
                {
                    txt_versiontag.Text = "Unable to determinate installed version.";
                }

                if (NewVersion > CurVersion)
                {
                    GlobalVar.isUpdateAvailable = true;

                    MessageBoxButtons msgBtns = MessageBoxButtons.OK;
                    if (GlobalVar.isDebug)
                        msgBtns = MessageBoxButtons.OKCancel;

                    if (new Windows.MessageBox().Show("There's a new launcher version available.", "Version " + NewVersionS + " available", msgBtns, MessageIcon.Information) == DialogResult.OK)
                        isUpdate = true;

                    txt_versiontag.Text = "Version " + NewVersionS + " available to update!";
                }
                else if (NewVersion < CurVersion)
                {
                    GlobalVar.isUpdateAvailable = true;

                    MessageBoxButtons msgBtns = MessageBoxButtons.OK;
                    if (GlobalVar.isDebug)
                        msgBtns = MessageBoxButtons.OKCancel;

                    if (new Windows.MessageBox().Show("The launcher needs to downgrade to a stable version.", "Version " + NewVersionS + " available", msgBtns, MessageIcon.Information) == DialogResult.OK)
                        isUpdate = true;

                    txt_versiontag.Text = "Version " + NewVersionS + " available to downgrade!";
                }
                else
                {
                    txt_versiontag.Text = "Version " + CurVersionS;
                }
            }
            catch { }

            return isUpdate;
        }

        public void StartUpdate()
        {
            try
            {
                WebClient update_file = new WebClient();
                Uri update_url = new Uri(Properties.GlobalValues.S_UpdateUrl);

                update_file.DownloadFile(update_url, Application.ExecutablePath.Remove(Application.ExecutablePath.Length - Process.GetCurrentProcess().MainModule.ModuleName.Length) + "zUpdator.exe");
            }
            catch (Exception ex)
            {
                new Windows.MessageBox().Show(ex.Message, "Unable to download zUpdator");
            }
            finally
            {

                try
                {
                    var fass = new ProcessStartInfo();
                    fass.WorkingDirectory = Application.ExecutablePath.Remove(Application.ExecutablePath.Length - Process.GetCurrentProcess().MainModule.ModuleName.Length);
                    fass.FileName = "zUpdator.exe";
                    fass.Arguments = "-curversion=" + CurVersionS +
                        " -newversion=" + NewVersionS +
                        " -filename=" + Process.GetCurrentProcess().MainModule.ModuleName;

                    Application.Exit();

                    var process = new Process();
                    process.StartInfo = fass;
                    process.Start();
                }
                catch (Exception ex)
                {
                    new Windows.MessageBox().Show(ex.Message, "Unable to start zUpdator");
                }
            }
        }
    }
}
