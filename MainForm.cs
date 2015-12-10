using System;
using System.ComponentModel;
using System.Drawing;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Diagnostics;
using System.Xml;
using System.Collections.Generic;

using arma3Launcher.Controls;
using arma3Launcher.Workers;

namespace arma3Launcher
{
    public partial class MainForm : Form
    {
        //Feed FeedMethod;
        private zCheckUpdate QuickUpdateMethod;
        private zCheckUpdate UpdateMethod;
        private LaunchCore PrepareLaunch;
        private Packs fetchAddonPacks;
        private EmailReporter eReport;
        private AddonsLooker aLooker;
        private Downloader downloader;
        private Installer installer;
        private RemoteReader remoteReader;

        private Windows.Splash loadingSplash;

        private Version aLocal = null;
        private Version aRemote = null;

        private Button activeButton;
        private int aux_Blinker = 0;

        private string modsDir_previousDir = "";

        private string activePack = "";
        private string GameFolder = "";
        private string AddonsFolder = "";

        private bool isBlastcoreAllowed = false;
        private bool isJSRSAllowed = false;
        private bool isOptionalAllowed = false;

        private string TempFolder = Path.GetTempPath() + @"arma3Launcher\";
        private List<string> modsName = new List<string>();
        private List<string> modsUrl = new List<string>();
        private string cfgFile = "";
        private string cfgUrl = "";
        private string blastcoreUrl = "";
        private string jsrsUrl = "";

        private string Arguments = "";

        private bool isActive = true;

        private int menuSelected = 0;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private System.Windows.Forms.Timer effectIn = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer effectOut = new System.Windows.Forms.Timer();

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void WindowTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void WindowVersionStatus_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == SingleInstance.WM_SHOWFIRSTINSTANCE)
            {
                WinApi.ShowToFront(this.Handle);
                this.Show();
                this.TopMost = true;
                Thread.Sleep(1);
                this.TopMost = false;
            }
            base.WndProc(ref m);
        }

        public MainForm()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            InitializeComponent();

            txt_appTitle.Text = AssemblyTitle;
            txt_appVersion.Text = AssemblyVersion;

            QuickUpdateMethod = new zCheckUpdate(WindowVersionStatus);
            UpdateMethod = new zCheckUpdate(btn_update, txt_curversion, txt_latestversion, busy);

            downloader = new Downloader(this, prb_progressBar_File, prb_progressBar_All, txt_progressStatus, txt_percentageStatus, btn_Launch);
            installer = new Installer(this, prb_progressBar_File, prb_progressBar_All, txt_progressStatus, txt_percentageStatus, txt_curFile, btn_Launch, txtb_armaDirectory, txtb_tsDirectory, txtb_modsDirectory, btn_ereaseArmaDirectory, btn_ereaseTSDirectory, btn_ereaseModsDirectory, btn_browseA3, btn_browseTS3, btn_browseModsDirectory, btn_reinstallTFRPlugins, btn_downloadJSRS, btn_downloadBlastcore);
            remoteReader = new RemoteReader();
            fetchAddonPacks = new Packs(FeedContentPanel);
            eReport = new EmailReporter();
            aLooker = new AddonsLooker(lstb_detectedAddons, lstb_activeAddons, chb_jsrs, chb_blastcore);
            loadingSplash = new Windows.Splash();

            effectIn.Interval = 10;
            effectOut.Interval = 10;

            effectIn.Tick += EffectIn_Tick;
            effectOut.Tick += EffectOut_Tick;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadingSplash.Show();

            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

            //FeedMethod = new Feed(FeedContentPanel, Properties.GlobalValues.FP_FeedUrl);
            //FeedMethod.GetRSSNews();
            //delayFecthNews.Start();

            if (Properties.Settings.Default.UpdateSettings)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateSettings = false;
                if (AssemblyVersion == "0.6")
                    Properties.Settings.Default.firstLaunch = true;
                Properties.Settings.Default.Save();
            }

            WindowTitle.Text = AssemblyTitle + " | v" + AssemblyVersion;
            if (!QuickUpdateMethod.QuickCheck())
            {
                menuSelected = 4;
                HideUnhide(menuSelected);

                btn_browseA3.Enabled = false;
                btn_browseTS3.Enabled = false;
                btn_Launch.Enabled = false;

                panelMenu.Visible = false;

                activeButton = btn_update;
                backgroundBlinker.RunWorkerAsync();
            }
            else if (Properties.Settings.Default.firstLaunch)
            {
                menuSelected = 3;
                HideUnhide(menuSelected);
                GetDirectories();
            }
            else
            {
                menuSelected = 0;
                HideUnhide(menuSelected);
            }

            FetchSettings();

            if (Properties.Settings.Default.Arma3Folder == "" && Properties.Settings.Default.TS3Folder == "")
                GetDirectories();

            if (String.IsNullOrEmpty(Properties.Settings.Default.AddonsFolder) || Properties.Settings.Default.AddonsFolder == "\\")
            {
                using (var form = new Windows.AddonsFolderSetup())
                {
                    var result = form.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        txtb_modsDirectory.Text = form.AddonsFolder;
                    }
                }
            }

            FetchRemoteSettings();

            GetAddons();

            getMalloc();

            UpdateMethod.CheckUpdates();

            if (Directory.Exists(AddonsFolder + @"@task_force_radio\plugins"))
                btn_reinstallTFRPlugins.Enabled = true;
            else
                btn_reinstallTFRPlugins.Enabled = false;

            loadingSplash.Close();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            effectIn.Start();

            FeedContentPanel.Focus();

            if (Properties.Settings.Default.downloadQueue != "" && panelMenu.Visible == true)
            {
                if (MessageBox.Show("You haven't finished all the downloads the last time you closed the launcher.\n\"Yes\", to continue downloads.\n\"No\", will DELETE your progress.", "spN Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string[] aux_downloadQueue = Properties.Settings.Default.downloadQueue.Split(',');
                    foreach (string s in aux_downloadQueue)
                    {
                        if (s != "")
                            modsUrl.Add(s);

                        if (s.Contains("DragonFyre"))
                        {
                            btn_downloadJSRS.Enabled = false;
                        }

                        if (s.Contains("Blastcore"))
                        {
                            btn_downloadBlastcore.Enabled = false;
                        }
                    }

                    downloader.beginDownload(modsUrl, false, false);
                }
                else
                {
                    if (Directory.Exists(TempFolder))
                        Directory.Delete(TempFolder, true);

                    Properties.Settings.Default.downloadQueue = "";
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            downloader.SaveDownloadQueue();
            GC.Collect();
        }

        private void EffectIn_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity = this.Opacity + 0.1;
                this.Location = new Point(this.Location.X, this.Location.Y - 1);
            }
            else
            { effectIn.Stop(); }
        }

        private void EffectOut_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity = this.Opacity - 0.1;
                this.Location = new Point(this.Location.X, this.Location.Y + 1);
            }
            else
            { effectOut.Stop(); this.Close(); }
        }

        public void GetAddons()
        {
            aLooker.getAddons(isJSRSAllowed, isBlastcoreAllowed, modsName);
        }

        void GetDirectories()
        {
            string aux_pathError = "";

            try
            {
                string a3Key = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\bohemia interactive\arma 3", "main", "") + @"\";
                Properties.Settings.Default.Arma3Folder = a3Key;

                if (a3Key == null)
                    throw new Exception();
            }
            catch
            {
                aux_pathError = "Arma 3 directory";
            }

            try
            {
                string tsKey = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TeamSpeak 3 Client", "", "");
                if (tsKey == null)
                {
                    RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\TeamSpeak 3 Client");
                    Properties.Settings.Default.TS3Folder = (string)key.GetValue("") + @"\";
                }
                else
                    Properties.Settings.Default.TS3Folder = tsKey;

                if (tsKey == null)
                    throw new Exception();
            }
            catch
            {
                try
                {
                    string tsKey = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\TeamSpeak 3 Client", "", "");
                    if (tsKey == null)
                    {
                        RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64).OpenSubKey(@"Software\TeamSpeak 3 Client");
                        Properties.Settings.Default.TS3Folder = (string)key.GetValue("") + @"\";
                    }
                    else
                        Properties.Settings.Default.TS3Folder = tsKey;

                    if (tsKey == null)
                        throw new Exception();
                }
                catch
                {
                    if (aux_pathError != "")
                        aux_pathError = "Arma 3 and TeamSpeak 3 directories";
                    else
                        aux_pathError = "TeamSpeak 3 directory";
                }
            }

            if (aux_pathError != "")
                txt_progressStatus.Text = "Unable to get " + aux_pathError;

            Properties.Settings.Default.firstLaunch = false;
            Properties.Settings.Default.Save();

            if (Properties.Settings.Default.Arma3Folder != "")
            {
                txtb_armaDirectory.ForeColor = Color.FromArgb(64, 64, 64); txtb_armaDirectory.Text = Properties.Settings.Default.Arma3Folder.Remove(Properties.Settings.Default.Arma3Folder.Length - 1);
            }
            else
            { txtb_armaDirectory.ForeColor = Color.DarkGray; txtb_armaDirectory.Text = "Set directory ->"; }

            if (Properties.Settings.Default.TS3Folder != "")
            { txtb_tsDirectory.ForeColor = Color.FromArgb(64, 64, 64); txtb_tsDirectory.Text = Properties.Settings.Default.TS3Folder.Remove(Properties.Settings.Default.TS3Folder.Length - 1); }
            else
            { txtb_tsDirectory.ForeColor = Color.DarkGray; txtb_tsDirectory.Text = "Set directory ->"; }
        }

        void FetchSettings()
        {
            if (Properties.Settings.Default.Arma3Folder != "")
            { txtb_armaDirectory.Text = Properties.Settings.Default.Arma3Folder.Remove(Properties.Settings.Default.Arma3Folder.Length - 1); GameFolder = Properties.Settings.Default.Arma3Folder; }
            else
            { txtb_armaDirectory.ForeColor = Color.DarkGray; txtb_armaDirectory.Text = "Set directory ->"; }

            if (Properties.Settings.Default.TS3Folder != "")
            { txtb_tsDirectory.Text = Properties.Settings.Default.TS3Folder.Remove(Properties.Settings.Default.TS3Folder.Length - 1); }
            else
            { txtb_tsDirectory.ForeColor = Color.DarkGray; txtb_tsDirectory.Text = "Set directory ->"; }

            chb_noLogs.Checked = Properties.Settings.Default.noLogs;
            chb_noPause.Checked = Properties.Settings.Default.noPause;
            chb_noSplash.Checked = Properties.Settings.Default.noSplash;
            chb_noCB.Checked = Properties.Settings.Default.noCB;
            chb_enableHT.Checked = Properties.Settings.Default.enableHT;
            chb_skipIntro.Checked = Properties.Settings.Default.skipIntro;
            chb_window.Checked = Properties.Settings.Default.window;
            chb_winxp.Checked = Properties.Settings.Default.winxp;
            chb_showScriptErrors.Checked = Properties.Settings.Default.showScriptErrors;
            chb_noBenchmark.Checked = Properties.Settings.Default.noBenchmark;

            chb_world.Checked = Properties.Settings.Default.world;
            txtb_world.Text = Properties.Settings.Default.world_value;

            chb_maxMem.Checked = Properties.Settings.Default.maxMem;
            txtb_maxMem.Text = Properties.Settings.Default.maxMem_value.ToString();

            chb_malloc.Checked = Properties.Settings.Default.malloc;
            txtb_malloc.Text = Properties.Settings.Default.malloc_value.ToString();

            chb_maxVRAM.Checked = Properties.Settings.Default.maxVRAM;
            txtb_maxVRAM.Text = Properties.Settings.Default.maxVRAM_value.ToString();

            chb_exThreads.Checked = Properties.Settings.Default.exThreads;
            txtb_exThreads.Text = Properties.Settings.Default.exThreads_value.ToString();

            chb_cpuCount.Checked = Properties.Settings.Default.cpuCount;
            txtb_cpuCount.Text = Properties.Settings.Default.cpuCount_value.ToString();

            chb_jsrs.Checked = Properties.Settings.Default.JSRS;
            chb_blastcore.Checked = Properties.Settings.Default.BlastCore;

            AddonsFolder = Properties.Settings.Default.AddonsFolder;

            txtb_modsDirectory.Text = Properties.Settings.Default.AddonsFolder;

            lstb_activeAddons.Items.Clear();
            string[] aux_activeMods = Properties.Settings.Default.activeMods.Split(',');
            foreach (string s in aux_activeMods)
            {
                if (s != "")
                    lstb_activeAddons.Items.Add(s);
            }

            pref_startGameAfterDownloadsAreCompleted.Checked = true/*Properties.Settings.Default.startGameAfterDownload*/;
            pref_runLauncherOnStartup.Checked = Properties.Settings.Default.runLauncherOnStartup;
            pref_allowNotifications.Checked = Properties.Settings.Default.allowNotifications;
            pref_allowNotifications.Checked = Properties.Settings.Default.autoDownload;
        }

        void SaveSettings()
        {
            Properties.Settings.Default.noLogs = chb_noLogs.Checked;
            Properties.Settings.Default.noPause = chb_noPause.Checked;
            Properties.Settings.Default.noSplash = chb_noSplash.Checked;
            Properties.Settings.Default.noCB = chb_noCB.Checked;
            Properties.Settings.Default.enableHT = chb_enableHT.Checked;
            Properties.Settings.Default.skipIntro = chb_skipIntro.Checked;
            Properties.Settings.Default.window = chb_window.Checked;
            Properties.Settings.Default.winxp = chb_winxp.Checked;
            Properties.Settings.Default.showScriptErrors = chb_showScriptErrors.Checked;
            Properties.Settings.Default.noBenchmark = chb_noBenchmark.Checked;

            Properties.Settings.Default.world = chb_world.Checked;
            Properties.Settings.Default.world_value = txtb_world.Text;

            Properties.Settings.Default.maxMem = chb_maxMem.Checked;
            Properties.Settings.Default.maxMem_value = Convert.ToInt32(txtb_maxMem.Text);

            Properties.Settings.Default.malloc = chb_malloc.Checked;
            Properties.Settings.Default.malloc_value = txtb_malloc.Text;

            Properties.Settings.Default.maxVRAM = chb_maxVRAM.Checked;
            Properties.Settings.Default.maxVRAM_value = Convert.ToInt32(txtb_maxVRAM.Text);

            Properties.Settings.Default.exThreads = chb_exThreads.Checked;
            Properties.Settings.Default.exThreads_value = Convert.ToInt32(txtb_exThreads.Text);

            Properties.Settings.Default.cpuCount = chb_cpuCount.Checked;
            Properties.Settings.Default.cpuCount_value = Convert.ToInt32(txtb_cpuCount.Text);

            Properties.Settings.Default.JSRS = chb_jsrs.Checked;
            Properties.Settings.Default.BlastCore = chb_blastcore.Checked;

            Properties.Settings.Default.AddonsFolder = txtb_modsDirectory.Text + @"\";

            string aux_activeMods = "";
            foreach (var item in lstb_activeAddons.Items)
            {
                if (aux_activeMods == "")
                    aux_activeMods = item + ",";
                else
                    aux_activeMods = aux_activeMods + item + ",";
            }
            Properties.Settings.Default.activeMods = aux_activeMods;

            Properties.Settings.Default.startGameAfterDownload = pref_startGameAfterDownloadsAreCompleted.Checked;
            Properties.Settings.Default.runLauncherOnStartup = pref_runLauncherOnStartup.Checked;
            Properties.Settings.Default.allowNotifications = pref_allowNotifications.Checked;
            Properties.Settings.Default.autoDownload = pref_allowNotifications.Checked;

            Properties.Settings.Default.Save();
        }

        public void FetchRemoteSettings()
        {
            bool isInstalled = false;
            modsName.Clear();
            modsUrl.Clear();

            AddonsFolder = Properties.Settings.Default.AddonsFolder;

            try
            {
                XmlDocument RemoteXmlInfo = new XmlDocument();
                RemoteXmlInfo.Load(Properties.GlobalValues.S_VersionXML);

                string xmlNodes = "";
                XmlNodeList xnl;

                //Common Files
                xmlNodes = "//arma3Launcher//ModSetInfo//Recommended//mod";
                xnl = RemoteXmlInfo.SelectNodes(xmlNodes);

                foreach (XmlNode xn in xnl)
                {
                    if (xn.Attributes["type"].Value == "blastcore")
                    {
                        blastcoreUrl = xn.Attributes["url"].Value;
                        btn_downloadBlastcore.Text = "Download (" + xn.Attributes["version"].Value + ")";
                    }

                    if (xn.Attributes["type"].Value == "jsrs")
                    {
                        jsrsUrl = xn.Attributes["url"].Value;
                        btn_downloadJSRS.Text = "Download (" + xn.Attributes["version"].Value + ")";
                    }
                }

                //Validate if activePack exists or select first on the list
                xmlNodes = "//arma3Launcher//ModSets//pack";
                xnl = RemoteXmlInfo.SelectNodes(xmlNodes);
                string firstPack = "";
                activePack = "";

                foreach (XmlNode xn in xnl)
                {
                    if (String.IsNullOrEmpty(firstPack) && Convert.ToBoolean(xn.Attributes["enable"].Value))
                    { firstPack = xn.Attributes["id"].Value; }

                    if (Properties.Settings.Default.lastAddonPack == xn.Attributes["id"].Value && Convert.ToBoolean(xn.Attributes["enable"].Value))
                    { activePack = Properties.Settings.Default.lastAddonPack; break; }
                }

                if (String.IsNullOrEmpty(activePack))
                { Properties.Settings.Default.lastAddonPack = activePack = firstPack; }

                isBlastcoreAllowed = Convert.ToBoolean(RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + activePack).Attributes["blastcore"].Value);
                isJSRSAllowed = Convert.ToBoolean(RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + activePack).Attributes["jsrs"].Value);
                isOptionalAllowed = Convert.ToBoolean(RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + activePack).Attributes["optional"].Value);

                cfgFile = activePack;
                cfgUrl = RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + activePack).Attributes["cfgfile"].Value;

                if (isBlastcoreAllowed)
                { chb_blastcore.Enabled = true; }
                else
                { chb_blastcore.Enabled = false; }

                if (isJSRSAllowed)
                { chb_jsrs.Enabled = true; }
                else
                { chb_jsrs.Enabled = false; }

                if (isOptionalAllowed)
                { panel_Optional.Enabled = true; }
                else
                { panel_Optional.Enabled = false; }

                xmlNodes = "//arma3Launcher//ModSetInfo//" + activePack + "//mod";
                xnl = RemoteXmlInfo.SelectNodes(xmlNodes);

                foreach (XmlNode xn in xnl)
                {
                    if (xn.Attributes["type"].Value == "mod")
                    {
                        modsName.Add(xn.Attributes["name"].Value);

                        if (AddonsFolder != "")
                        {
                            foreach (string d in Directory.GetDirectories(AddonsFolder))
                            {
                                string[] aux_d = d.Split('\\');

                                if (aux_d[aux_d.Length - 1].Equals(xn.Attributes["name"].Value))
                                {
                                    try
                                    {
                                        if (d.Contains("dummy")) { isInstalled = true; break; }

                                        foreach (var line in File.ReadAllLines(d + @"\spNversionController"))
                                        {
                                            if (line.Contains("version"))
                                            {
                                                string aux_line = line.Replace(" ", "");
                                                string[] splitted_line = aux_line.Split('=');

                                                aLocal = new Version(splitted_line[1]);
                                                aRemote = new Version(xn.Attributes["version"].Value);
                                                break;
                                            }
                                        }

                                        if (aRemote != aLocal)
                                        {
                                            if (!d.Contains("RHS"))
                                                Directory.Delete(d, true);

                                            isInstalled = false;
                                            break;
                                        }
                                        else { isInstalled = true; break; }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                                else { isInstalled = false; continue; }
                            }
                        }

                        if (!isInstalled && Properties.Settings.Default.downloadQueue == "")
                            modsUrl.Add(xn.Attributes["url"].Value);
                    }
                }

                /*if (modsUrl.Count > 0)
                    modsUrl.Insert(0,cfgUrl);*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to fetch remote settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_progressStatus.Text = "Unable to fetch remote settings.";
            }
            finally
            {
                fetchAddonPacks.Get();
            }
        }

        void getMalloc()
        {
            txtb_malloc.Items.Clear();

            try
            {
                string[] fileEntries = Directory.GetFiles(Properties.Settings.Default.Arma3Folder + "Dll\\", "*.dll");
                foreach (string fileName in fileEntries)
                {
                    txtb_malloc.Items.Add(Path.GetFileName(fileName).Remove(Path.GetFileName(fileName).Length - 4));
                }
            }
            catch
            { }
        }

        #region Assembly Info
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                string aux = "";
                if (Assembly.GetExecutingAssembly().GetName().Version.Build != 0)
                    aux = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Build.ToString() /*+ "." + Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString()*/;
                else
                    aux = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
                return aux;
            }
        }
        #endregion

        #region System Buttons
        private void sysbtn_close_Click(object sender, EventArgs e)
        {
            effectOut.Start();
        }

        private void sysbtn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void sysbtn_moreOptions_Click(object sender, EventArgs e)
        {
            menu_moreOptions.Show(sysbtn_moreOptions, 0, 18);
        }

        private void sysbtn_close_MouseEnter(object sender, EventArgs e)
        {
            sysbtn_close.Image = Properties.Resources.bgclose2;
        }

        private void sysbtn_close_MouseLeave(object sender, EventArgs e)
        {
            if (isActive)
                sysbtn_close.Image = Properties.Resources.bgclose1;
            else
                sysbtn_close.Image = Properties.Resources.bgclose3;
        }
        private void sysbtn_close_MouseDown(object sender, MouseEventArgs e)
        {
            sysbtn_close.Image = Properties.Resources.bgclose4;
        }

        private void sysbtn_minimize_MouseEnter(object sender, EventArgs e)
        {
            sysbtn_minimize.Image = Properties.Resources.bgminimize2;
        }

        private void sysbtn_minimize_MouseLeave(object sender, EventArgs e)
        {
            if (isActive)
                sysbtn_minimize.Image = Properties.Resources.bgminimize1;
            else
                sysbtn_minimize.Image = Properties.Resources.bgminimize3;
        }

        private void sysbtn_minimize_MouseDown(object sender, MouseEventArgs e)
        {
            sysbtn_minimize.Image = Properties.Resources.bgminimize4;
        }

        private void sysbtn_moreOptions_MouseDown(object sender, MouseEventArgs e)
        {
            sysbtn_moreOptions.Image = Properties.Resources.bgmore4_fw;
        }

        private void sysbtn_moreOptions_MouseEnter(object sender, EventArgs e)
        {
            sysbtn_moreOptions.Image = Properties.Resources.bgmore2_fw;
        }

        private void sysbtn_moreOptions_MouseLeave(object sender, EventArgs e)
        {
            if (isActive)
                sysbtn_moreOptions.Image = Properties.Resources.bgmore1_fw;
            else
                sysbtn_moreOptions.Image = Properties.Resources.bgmore3_fw;
        }
        #endregion

        private void btn_browseA3_Click(object sender, EventArgs e)
        {
            /* try
             {
                 Properties.Settings.Default.Arma3Folder = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\bohemia interactive\arma 3", "main", "") + @"\";
                 Properties.Settings.Default.Save();

                 if (Properties.Settings.Default.Arma3Folder != "")
                 { txtb_armaDirectory.ForeColor = Color.FromArgb(64, 64, 64); txtb_armaDirectory.Text = Properties.Settings.Default.Arma3Folder.Remove(Properties.Settings.Default.Arma3Folder.Length - 1); }
                 else
                 { txtb_armaDirectory.ForeColor = Color.DarkGray; txtb_armaDirectory.Text = "Set directory ->"; }
             }
             catch
             {*/
            #region Arma Directory Validation
            if (dlg_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string auxA3Folder = dlg_folderBrowser.SelectedPath;
                bool auxIsFolder = false;

                try
                {
                    foreach (string f in Directory.GetFiles(auxA3Folder))
                    {
                        if (f.Contains("arma3.exe")) { auxIsFolder = true; break; }
                        else { continue; }
                    }
                }
                catch
                { }
                finally
                {
                    if (auxIsFolder)
                    {
                        txtb_armaDirectory.ForeColor = Color.FromArgb(64, 64, 64);
                        Properties.Settings.Default.Arma3Folder = auxA3Folder + @"\";
                        Properties.Settings.Default.Save();
                        txtb_armaDirectory.Text = auxA3Folder;
                    }
                    else
                    {
                        MessageBox.Show("No Arma3 application found on that folder.\nMake sure that's the root folder.", "Not the correct folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                #endregion
                //}

            }
        }

        private void btn_browseA3_DoubleClick(object sender, EventArgs e)
        {
            #region Arma Directory Validation
            if (dlg_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string auxA3Folder = dlg_folderBrowser.SelectedPath;
                bool auxIsFolder = false;

                try
                {
                    foreach (string f in Directory.GetFiles(auxA3Folder))
                    {
                        if (f.Contains("arma3.exe")) { auxIsFolder = true; break; }
                        else { continue; }
                    }
                }
                catch
                { }
                finally
                {
                    if (auxIsFolder)
                    {
                        txtb_armaDirectory.ForeColor = Color.FromArgb(64, 64, 64);
                        Properties.Settings.Default.Arma3Folder = auxA3Folder + @"\";
                        Properties.Settings.Default.Save();
                        txtb_armaDirectory.Text = auxA3Folder;
                    }
                    else
                    {
                        MessageBox.Show("No Arma3 application found on that folder.\nMake sure that's the root folder.", "Not the correct folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion
        }

        private void btn_browseTS3_Click(object sender, EventArgs e)
        {
            /*try
            {
                string tsKey = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\TeamSpeak 3 Client", "", "");
                if (tsKey == null)
                {
                    RegistryKey key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\TeamSpeak 3 Client");
                    Properties.Settings.Default.TS3Folder = (string)key.GetValue("") + @"\";
                }
                else
                    Properties.Settings.Default.TS3Folder = tsKey;

                Properties.Settings.Default.Save();

                if (Properties.Settings.Default.TS3Folder != "")
                { txtb_tsDirectory.ForeColor = Color.FromArgb(64, 64, 64); txtb_tsDirectory.Text = Properties.Settings.Default.TS3Folder.Remove(Properties.Settings.Default.TS3Folder.Length - 1); }
                else
                { txtb_tsDirectory.ForeColor = Color.DarkGray; txtb_tsDirectory.Text = "Set directory ->"; }
            }
            catch
            {*/
            #region TS Directory Validation
            if (dlg_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string auxTS3Folder = dlg_folderBrowser.SelectedPath;
                bool auxIsFolder = false;

                try
                {
                    foreach (string f in Directory.GetFiles(auxTS3Folder))
                    {
                        if (f.Contains("ts3client_win64.exe") || f.Contains("ts3client_win32.exe")) { auxIsFolder = true; break; }
                        else { continue; }
                    }
                }
                catch
                { }
                finally
                {
                    if (auxIsFolder)
                    {
                        txtb_tsDirectory.ForeColor = Color.FromArgb(64, 64, 64);
                        Properties.Settings.Default.TS3Folder = auxTS3Folder + @"\";
                        Properties.Settings.Default.Save();
                        txtb_tsDirectory.Text = auxTS3Folder;
                    }
                    else
                    {
                        MessageBox.Show("No TeamSpeak 3 application found on that folder.\nMake sure that's the root folder.", "Not the correct folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion
            //}
        }

        private void btn_browseTS3_DoubleClick(object sender, EventArgs e)
        {
            #region TS Directory Validation
            if (dlg_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string auxTS3Folder = dlg_folderBrowser.SelectedPath;
                bool auxIsFolder = false;

                try
                {
                    foreach (string f in Directory.GetFiles(auxTS3Folder))
                    {
                        if (f.Contains("ts3client_win64.exe") || f.Contains("ts3client_win32.exe")) { auxIsFolder = true; break; }
                        else { continue; }
                    }
                }
                catch
                { }
                finally
                {
                    if (auxIsFolder)
                    {
                        txtb_tsDirectory.ForeColor = Color.FromArgb(64, 64, 64);
                        Properties.Settings.Default.TS3Folder = auxTS3Folder + @"\";
                        Properties.Settings.Default.Save();
                        txtb_tsDirectory.Text = auxTS3Folder;
                    }
                    else
                    {
                        MessageBox.Show("No TeamSpeak 3 application found on that folder.\nMake sure that's the root folder.", "Not the correct folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion
        }

        /*-----------------------------------
            START MENU FUNCTIONS
         * Function Hide/Unhide
         * Click
         * Mouse Enter
         * Mouse Leave
        -----------------------------------*/

        #region Menu Region
        /*-----------------------------------
            Hide/Unhide
        -----------------------------------*/
        private void HideUnhide(int selectedOption)
        {
            if (selectedOption == 0) { menu_news.ForeColor = Color.OliveDrab; panel_news.Visible = true; FeedContentPanel.Focus(); }
            else { menu_news.ForeColor = Color.Gray; panel_news.Visible = false; }

            if (selectedOption == 1) { menu_community.ForeColor = Color.OliveDrab; panel_community.Visible = true; }
            else { menu_community.ForeColor = Color.Gray; panel_community.Visible = false; }

            if (selectedOption == 2) { menu_launchOptions.ForeColor = Color.OliveDrab; panel_launchOptions.Visible = true; }
            else { menu_launchOptions.ForeColor = Color.Gray; panel_launchOptions.Visible = false; }

            if (selectedOption == 3) { menu_help.ForeColor = Color.OliveDrab; panel_help.Visible = true; }
            else { menu_help.ForeColor = Color.Gray; panel_help.Visible = false; }

            if (selectedOption == 4) { menu_about.ForeColor = Color.OliveDrab; panel_about.Visible = true; }
            else { menu_about.ForeColor = Color.Gray; panel_about.Visible = false; }
        }

        /*-----------------------------------
            Menu News
        -----------------------------------*/
        private void menu_news_Click(object sender, EventArgs e)
        {
            menuSelected = 0;
            HideUnhide(menuSelected);
        }

        private void menu_news_MouseEnter(object sender, EventArgs e)
        {
            menu_news.ForeColor = Color.DarkGray;
        }

        private void menu_news_MouseLeave(object sender, EventArgs e)
        {
            if (menuSelected != 0)
                menu_news.ForeColor = Color.Gray;
            else
                menu_news.ForeColor = Color.OliveDrab;
        }

        /*-----------------------------------
            Menu spN Community
        -----------------------------------*/
        private void menu_community_Click(object sender, EventArgs e)
        {
            menuSelected = 1;
            HideUnhide(menuSelected);
        }

        private void menu_community_MouseEnter(object sender, EventArgs e)
        {
            menu_community.ForeColor = Color.DarkGray;
        }

        private void menu_community_MouseLeave(object sender, EventArgs e)
        {
            if (menuSelected != 1)
                menu_community.ForeColor = Color.Gray;
            else
                menu_community.ForeColor = Color.OliveDrab;
        }

        /*-----------------------------------
            Menu Launch & Addons Options
        -----------------------------------*/
        private void menu_launchOptions_Click(object sender, EventArgs e)
        {
            menuSelected = 2;
            HideUnhide(menuSelected);
        }

        private void menu_launchOptions_MouseEnter(object sender, EventArgs e)
        {
            menu_launchOptions.ForeColor = Color.DarkGray;
        }

        private void menu_launchOptions_MouseLeave(object sender, EventArgs e)
        {
            if (menuSelected != 2)
                menu_launchOptions.ForeColor = Color.Gray;
            else
                menu_launchOptions.ForeColor = Color.OliveDrab;
        }

        /*-----------------------------------
            Menu Help
        -----------------------------------*/
        private void menu_help_Click(object sender, EventArgs e)
        {
            menuSelected = 3;
            HideUnhide(menuSelected);
        }

        private void menu_help_MouseEnter(object sender, EventArgs e)
        {
            menu_help.ForeColor = Color.DarkGray;
        }

        private void menu_help_MouseLeave(object sender, EventArgs e)
        {
            if (menuSelected != 3)
                menu_help.ForeColor = Color.Gray;
            else
                menu_help.ForeColor = Color.OliveDrab;
        }

        /*-----------------------------------
            Menu About
        -----------------------------------*/
        private void menu_about_Click(object sender, EventArgs e)
        {
            menuSelected = 4;
            HideUnhide(menuSelected);
        }

        private void menu_about_MouseEnter(object sender, EventArgs e)
        {
            menu_about.ForeColor = Color.DarkGray;
        }

        private void menu_about_MouseLeave(object sender, EventArgs e)
        {
            if (menuSelected != 4)
                menu_about.ForeColor = Color.Gray;
            else
                menu_about.ForeColor = Color.OliveDrab;
        }

        /*-----------------------------------
            END MENU FUNCTIONS
        -----------------------------------*/

        #endregion

        /*-----------------------------------
            START UPDATE FUNCTIONS (!! TO BE MOVED !!)
         * Update btn Click
         * StartUpdator()
        -----------------------------------*/

        #region Update Functions
        private void btn_update_Click(object sender, EventArgs e)
        {
            StartUpdator();
            Thread.Sleep(500);
            effectOut.Start();
        }

        void StartUpdator()
        {
            try
            {
                WebClient update_file = new WebClient();
                Uri update_url = new Uri(Properties.GlobalValues.S_UpdateUrl);

                update_file.DownloadFile(update_url, "zUpdator.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                var fass = new ProcessStartInfo();
                fass.FileName = "zUpdator.exe";
                fass.Arguments = "\"" + txt_curversion.Text + "_" + txt_latestversion.Text + "\"";

                var process = new Process();
                process.StartInfo = fass;
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        /*-----------------------------------
            END UPDATE FUNCTIONS
        -----------------------------------*/

        #region Recommended Addons
        private void btn_JSRS_Click(object sender, EventArgs e)
        {
            Process.Start("http://dl.jsrs-studios.com/1.%20JSRS-Studios%20Downloads/");
        }

        private void btn_Blastcore_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.armaholic.com/page.php?id=23899");
        }
        #endregion

        #region Game Options Conditions
        private void chb_world_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_world.Checked)
                txtb_world.Enabled = true;
            else
                txtb_world.Enabled = false;
        }

        private void chb_maxMem_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_maxMem.Checked)
                txtb_maxMem.Enabled = true;
            else
                txtb_maxMem.Enabled = false;
        }

        private void chb_malloc_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_malloc.Checked)
                txtb_malloc.Enabled = true;
            else
                txtb_malloc.Enabled = false;
        }

        private void chb_maxVRAM_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_maxVRAM.Checked)
                txtb_maxVRAM.Enabled = true;
            else
                txtb_maxVRAM.Enabled = false;
        }

        private void chb_exThreads_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_exThreads.Checked)
                txtb_exThreads.Enabled = true;
            else
                txtb_exThreads.Enabled = false;
        }

        private void chb_cpuCount_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_cpuCount.Checked)
                txtb_cpuCount.Enabled = true;
            else
                txtb_cpuCount.Enabled = false;
        }
        #endregion

        private void btn_Launch_Click(object sender, EventArgs e)
        {
            btn_Launch.Focus();

            FetchRemoteSettings();
            GetAddons();

            Process[] pname = Process.GetProcessesByName("steam");
            if (pname.Length == 0)
            {
                try
                {
                    txt_progressStatus.Text = "Starting Steam...";

                    var fass = new ProcessStartInfo();
                    fass.WorkingDirectory = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", "").ToString().Replace(@"/", @"\") + @"\";
                    fass.FileName = "steam.exe";
                    fass.Arguments = Arguments;

                    var process = new Process();
                    process.StartInfo = fass;
                    process.Start();
                    Thread.SpinWait(2000);
                    Thread.Sleep(2000);
                }
                catch { }
            }

            btn_Launch.Enabled = false;

            string aux_error = "";
            string aux_errors = "";

            if (Properties.Settings.Default.Arma3Folder == "")
                aux_error = "Arma 3";

            if (Properties.Settings.Default.TS3Folder == "")
                if (aux_error != "")
                { aux_errors = aux_error + ", TeamSpeak 3"; aux_error = ""; }
                else
                { aux_error = "TeamSpeak 3"; }

            if (Properties.Settings.Default.AddonsFolder == "")
                if (aux_error != "")
                { aux_errors = aux_error + ", Addons"; aux_error = ""; }
                else
                { aux_error = "Addons"; }


            if (aux_error != "")
                MessageBox.Show("The " + aux_error + " folder is not selected!\nCheck the \"Help\" tab for more info on how to use the launcher.", "Missing directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (aux_errors != "")
                MessageBox.Show("The following folders are missing: " + aux_errors + "\nCheck the \"Help\" tab for more info on how to use the launcher.", "Missing directories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                PrepareLaunch = new LaunchCore(chb_noLogs.Checked,
                    chb_noPause.Checked,
                    chb_noSplash.Checked,
                    chb_noCB.Checked,
                    chb_enableHT.Checked,
                    chb_skipIntro.Checked,
                    chb_window.Checked,
                    chb_winxp.Checked,
                    chb_showScriptErrors.Checked,
                    chb_noBenchmark.Checked,
                    chb_world.Checked,
                    txtb_world.Text,
                    chb_maxMem.Checked,
                    txtb_maxMem.Text,
                    chb_malloc.Checked,
                    txtb_malloc.Text,
                    chb_maxVRAM.Checked,
                    txtb_maxVRAM.Text,
                    chb_exThreads.Checked,
                    txtb_exThreads.Text,
                    chb_cpuCount.Checked,
                    txtb_cpuCount.Text,
                    chb_jsrs.Checked,
                    chb_jsrs.Tag.ToString(),
                    chb_blastcore.Checked,
                    chb_blastcore.Tag.ToString(),
                    lstb_activeAddons,
                    modsName);

                Arguments = PrepareLaunch.GetArguments();
                SaveSettings();

                if (PrepareLaunch.isModPackInstalled(modsName, modsUrl))
                    PrepareLaunch.LaunchGame(Arguments, this, txt_progressStatus, btn_Launch, remoteReader.ServerInfo(activePack), remoteReader.TeamSpeakInfo());
                else
                    downloader.beginDownload(modsUrl, false, true);
            }
        }

        private void txtb_armaDirectory_TextChanged(object sender, EventArgs e)
        {
            getMalloc();
        }

        private void txtb_armaDirectory_Leave(object sender, EventArgs e)
        {
            if (txtb_armaDirectory.Text.EndsWith(@"\"))
            {
                txtb_armaDirectory.Text = txtb_armaDirectory.Text.Remove(txtb_armaDirectory.Text.Length - 1);
            }
        }

        private void txtb_tsDirectory_Leave(object sender, EventArgs e)
        {
            if (txtb_tsDirectory.Text.EndsWith(@"\"))
            {
                txtb_tsDirectory.Text = txtb_tsDirectory.Text.Remove(txtb_tsDirectory.Text.Length - 1);
            }
        }

        private void btn_ereaseArmaDirectory_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Arma3Folder = "";
            Properties.Settings.Default.Save();

            txtb_armaDirectory.ForeColor = Color.DarkGray; txtb_armaDirectory.Text = "Set directory ->";
        }

        private void btn_ereaseTSDirectory_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TS3Folder = "";
            Properties.Settings.Default.Save();

            txtb_tsDirectory.ForeColor = Color.DarkGray; txtb_tsDirectory.Text = "Set directory ->";
        }

        private void btn_copyLaunchOptions_Click(object sender, EventArgs e)
        {
            PrepareLaunch = new LaunchCore(chb_noLogs.Checked,
                chb_noPause.Checked,
                chb_noSplash.Checked,
                chb_noCB.Checked,
                chb_enableHT.Checked,
                chb_skipIntro.Checked,
                chb_window.Checked,
                chb_winxp.Checked,
                chb_showScriptErrors.Checked,
                chb_noBenchmark.Checked,
                chb_world.Checked,
                txtb_world.Text,
                chb_maxMem.Checked,
                txtb_maxMem.Text,
                chb_malloc.Checked,
                txtb_malloc.Text,
                chb_maxVRAM.Checked,
                txtb_maxVRAM.Text,
                chb_exThreads.Checked,
                txtb_exThreads.Text,
                chb_cpuCount.Checked,
                txtb_cpuCount.Text);

            string Arguments = PrepareLaunch.GetArguments();
            if (Arguments != "" && Arguments != null)
            {
                Clipboard.SetText(Arguments);
                MessageBox.Show("This is on your clipboard:\n" + Arguments, "Launch options copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { MessageBox.Show("Select any option before trying to copy", "Launch options copy failed", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void backgroundBlinker_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                activeButton.FlatStyle = FlatStyle.Flat;
                activeButton.BackColor = Color.YellowGreen;
                Thread.Sleep(800);
                activeButton.FlatStyle = FlatStyle.Standard;
                activeButton.BackColor = Color.Transparent;
                Thread.Sleep(400);
            } while (aux_Blinker == 0);
        }

        private void btn_activateAddon_Click(object sender, EventArgs e)
        {
            if (lstb_activeAddons.Items.Count > 0)
                lstb_activeAddons.SetSelected(0, false);

            try
            {
                lstb_activeAddons.Items.Add(lstb_detectedAddons.SelectedItem);
                lstb_detectedAddons.Items.Remove(lstb_detectedAddons.SelectedItem);

                SaveSettings();
                lstb_detectedAddons.Focus();
                if (lstb_detectedAddons.Items.Count > 0)
                    lstb_detectedAddons.SelectedIndex = 0;
                lstb_detectedAddons.Select();
            }
            catch
            { }
        }

        private void btn_deactivateAddon_Click(object sender, EventArgs e)
        {
            if (lstb_detectedAddons.Items.Count > 0)
                lstb_detectedAddons.SetSelected(0, false);

            try
            {
                lstb_detectedAddons.Items.Add(lstb_activeAddons.SelectedItem);
                lstb_activeAddons.Items.Remove(lstb_activeAddons.SelectedItem);

                SaveSettings();
                lstb_activeAddons.Focus();
                if (lstb_activeAddons.Items.Count > 0)
                    lstb_activeAddons.SelectedIndex = 0;
                lstb_activeAddons.Select();
            }
            catch
            { }
        }

        private void btn_reloadAddons_Click(object sender, EventArgs e)
        {
            FetchRemoteSettings();
            GetAddons();
        }

        private void btn_Launch_MouseEnter(object sender, EventArgs e)
        {
            if (btn_Launch.Enabled)
                btn_Launch.Image = Properties.Resources.rocket_launch;
        }

        private void btn_Launch_MouseLeave(object sender, EventArgs e)
        {
            btn_Launch.Image = Properties.Resources.rocket;
        }

        private void btn_Launch_EnabledChanged(object sender, EventArgs e)
        {
            if (btn_Launch.Enabled)
                this.Cursor = Cursors.Default;
            else
                this.Cursor = Cursors.AppStarting;
        }

        private void btn_goTwitter_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.GlobalValues.Link_Twitter);
        }

        private void btn_goTwitch_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.GlobalValues.Link_Twitch);
        }

        private void btn_goYoutube_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.GlobalValues.Link_Youtube);
        }

        private void btn_goGit_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.GlobalValues.Link_Gihub);
        }

        private void btn_downloadJSRS_Click(object sender, EventArgs e)
        {
            if (!downloader.isDownloading())
            {
                modsUrl.Clear();
                modsUrl.Add(jsrsUrl);
                downloader.beginDownload(modsUrl, false, false);
            }
            else
                downloader.enqueueUrl(jsrsUrl);

            btn_downloadJSRS.Enabled = false;
        }

        private void btn_downloadBlastcore_Click(object sender, EventArgs e)
        {
            if (!downloader.isDownloading())
            {
                modsUrl.Clear();
                modsUrl.Add(blastcoreUrl);
                downloader.beginDownload(modsUrl, false, false);
            }
            else
                downloader.enqueueUrl(blastcoreUrl);

            btn_downloadBlastcore.Enabled = false;
        }

        private void btn_downloadConfigs_Click(object sender, EventArgs e)
        {
            if (!downloader.isDownloading())
            {
                modsUrl.Clear();
                modsUrl.Add(cfgUrl);
                downloader.beginDownload(modsUrl, true, false);
            }

            btn_downloadConfigs.Enabled = false;
        }

        private void btn_ereaseModsDirectory_Click(object sender, EventArgs e)
        {
            txtb_modsDirectory.Text = "";
        }

        private void btn_browseModsDirectory_Click(object sender, EventArgs e)
        {
            dlg_folderBrowser.ShowNewFolderButton = true;

            if (dlg_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (dlg_folderBrowser.SelectedPath != GameFolder)
                {
                    Properties.Settings.Default.AddonsFolder = dlg_folderBrowser.SelectedPath + @"\";
                    Properties.Settings.Default.Save();
                    txtb_modsDirectory.Text = dlg_folderBrowser.SelectedPath;
                    GetAddons();
                }
                else
                    MessageBox.Show("The Addons folder can't be the same as the Game folder.\nWe recommend you to have a specific folder for the addons on this launcher to avoid conflicts.", "Wrong directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dlg_folderBrowser.ShowNewFolderButton = false;
        }

        private void txtb_modsDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtb_modsDirectory.Text.EndsWith("\\"))
                txtb_modsDirectory.Text = txtb_modsDirectory.Text.Remove(txtb_modsDirectory.Text.Length - 1);

            if (txtb_modsDirectory.Text.EndsWith("/"))
                txtb_modsDirectory.Text = txtb_modsDirectory.Text.Remove(txtb_modsDirectory.Text.Length - 1).Replace("/", "\\");

            if (txtb_modsDirectory.Text != txtb_armaDirectory.Text && !File.Exists(txtb_modsDirectory.Text + "\\arma3.exe"))
            {
                Properties.Settings.Default.AddonsFolder = txtb_modsDirectory.Text + @"\";
                Properties.Settings.Default.Save();

                GetAddons();
                modsDir_previousDir = txtb_modsDirectory.Text;
            }
            else
            {
                txtb_modsDirectory.Text = modsDir_previousDir;
                MessageBox.Show("The Addons folder can't be the same as the Game folder.\nWe recommend you to have a specific folder for the addons on this launcher to avoid conflicts.", "Wrong directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_openA3_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Arma3Folder != "")
                Process.Start(Properties.Settings.Default.Arma3Folder);
        }

        private void btn_openTS3_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TS3Folder != "")
                Process.Start(Properties.Settings.Default.TS3Folder);
        }

        private void btn_openModsDirectory_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AddonsFolder != "")
                Process.Start(Properties.Settings.Default.AddonsFolder);
        }

        private void backgroundFetchNews_DoWork(object sender, DoWorkEventArgs e)
        {
            //FeedMethod.GetRSSNews();
        }

        private void delayFecthNews_Tick(object sender, EventArgs e)
        {
            delayFecthNews.Stop();
            backgroundFetchNews.RunWorkerAsync();
        }

        private void backgroundFetchNews_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            delayFecthNews.Start();
        }

        private void btn_reloadRemoteSettings_Click(object sender, EventArgs e)
        {
            FetchRemoteSettings();
            GetAddons();
        }

        private void btn_showRemoteSettings_Click(object sender, EventArgs e)
        {
            string aux_listMods = "";

            foreach (var mod in modsName)
            {
                if (mod != null)
                {
                    aux_listMods = aux_listMods + " " + mod + ";";
                }
                else
                    break;
            }

            MessageBox.Show("Temp Path: " + TempFolder + "\nConfig File: " + cfgFile + "\nGame Server: " + remoteReader.ServerInfo(activePack)[0] + ":" + remoteReader.ServerInfo(activePack)[1] + "\n\nActive Mods:" + aux_listMods, "Fetched remote settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_reinstallTFRPlugins_Click(object sender, EventArgs e)
        { installer.installTeamSpeakPlugin(); }

        public void runInstaller(bool isLaunch)
        { installer.beginInstall(isLaunch, this.activePack); }

        public void runGame()
        { PrepareLaunch.LaunchGame(Arguments, this, txt_progressStatus, btn_Launch, remoteReader.ServerInfo(activePack), remoteReader.TeamSpeakInfo()); }

        public bool startGameAfterDownload()
        { return pref_startGameAfterDownloadsAreCompleted.Checked; }

        public bool runLauncherStartup()
        { return pref_runLauncherOnStartup.Checked; }

        public bool allowNotifications()
        { return pref_allowNotifications.Checked; }

        public bool autoDownloadUpdates()
        { return pref_autoDownload.Checked; }
    }
}