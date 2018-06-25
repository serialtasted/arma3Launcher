using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Xml;
using System.Collections.Generic;
using arma3Launcher.Workers;
using arma3Launcher.Effects;
using System.Threading.Tasks;
using Microsoft.Win32;

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
        private RepoReader repoReader;
        private WindowIO windowIO;
        private PanelIO addonsPanelIO;
        private PanelIO communityPanelIO;
        private PanelIO launchoptionsPanelIO;
        private PanelIO helpPanelIO;
        private PanelIO aboutPanelIO;
        private PanelIO topPanelsIO;
        private PanelIO botPanelIO;

        private int expandState = 0;
        private Windows.AddonManager addonManager;

        private Windows.Splash loadingSplash;

        private Version aLocal = null;
        private Version aRemote = null;

        private Button activeButton;
        private int aux_Blinker = 0;

        private string armaDir_previousDir = "";
        private string tsDir_previousDir = "";
        private string modsDir_previousDir = "";

        private string activePack = "";
        private string GameFolder = "";
        private string TSFolder = "";
        private string AddonsFolder = "";

        private string oldVersionStatusText = "";

        private bool isOptionalAllowed = false;

        private string TempFolder = Path.GetTempPath() + @"arma3Launcher\";
        private List<string> modsName = new List<string>();

        private string Arguments = "";

        private bool isActive = true;
        private bool isUpdate = false;
        private bool hasShown = false;

        private int menuSelected = 0;

        // broweser settings for youtube
        string embedYT = "<html><head>" +
                    "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\"/>" +
                    "</head><body>" +
                    "<iframe width=\"681\" height=\"259\" src=\"{0}\"" +
                    "frameborder = \"0\" allow = \"autoplay; encrypted-media\" allowfullscreen></iframe>" +
                    "</body></html>";

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

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

            QuickUpdateMethod = new zCheckUpdate(WindowVersionStatus, busy);
            UpdateMethod = new zCheckUpdate(btn_update, btn_checkUpdates, txt_curversion, txt_latestversion, busy);

            aLooker = new AddonsLooker(steamworkshopAddonsList);
            remoteReader = new RemoteReader();
            repoReader = new RepoReader(trv_repoContent, lbl_repofileok, lbl_repofileinvalid, lbl_repofilemissing);
            fetchAddonPacks = new Packs(this, PacksPanel);
            eReport = new EmailReporter();
            loadingSplash = new Windows.Splash();
            windowIO = new WindowIO(this);
            installer = new Installer(this, prb_progressBar_File, prb_progressBar_All, txt_progressStatus, txt_percentageStatus, txt_curFile, btn_Launch, btn_cancelDownload, txtb_armaDirectory, txtb_tsDirectory, txtb_modsDirectory, btn_ereaseArmaDirectory, btn_ereaseTSDirectory, btn_ereaseModsDirectory, btn_browseA3, btn_browseTS3, btn_browseModsDirectory, btn_reinstallTFRPlugins, btn_checkRepo, repoReader);
            downloader = new Downloader(this, installer, prb_progressBar_File, prb_progressBar_All, txt_curFile, txt_progressStatus, txt_percentageStatus, btn_Launch, btn_cancelDownload, btn_checkRepo);

            addonsPanelIO = new PanelIO(panel_packs, Panels, 304, 306, 33);
            communityPanelIO = new PanelIO(panel_community, Panels, 304, 306, 33);
            launchoptionsPanelIO = new PanelIO(panel_launchOptions, Panels, 304, 306, 33);
            helpPanelIO = new PanelIO(panel_help, Panels, 304, 306, 33);
            aboutPanelIO = new PanelIO(panel_about, Panels, 304, 306, 33);
            topPanelsIO = new PanelIO(panelDirectories, panelMenu, 90, 42, 4);
            botPanelIO = new PanelIO(panel_bottomHide_Inner, panel_bottomhide, 906, 906, 56);

            addonManager = new Windows.AddonManager();

            // default video on community tab
            web_youtubeEmbed.DocumentText = string.Format(this.embedYT, "https://www.youtube.com/embed/uM7JY6Q7O4Q");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadingSplash.Show();

            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);

            //FeedMethod = new Feed(FeedContentPanel, Properties.GlobalValues.FP_FeedUrl);
            //FeedMethod.GetRSSNews();
            //delayFecthNews.Start();

            if (GlobalVar.isServer) { WindowTitle.Text = AssemblyTitle + " | v" + AssemblyVersion + " | Server Edition"; }
            else { WindowTitle.Text = AssemblyTitle + " | v" + AssemblyVersion; }

            // Change stuff if isServer
            if (GlobalVar.isServer)
            {
                pref_switchclientserver.Text = "Switch to Client Mode";
                panel_steamAddons.Visible = false;
                panel_serverOptions.Visible = true;
                panel_headlessOptions.Visible = true;
                pref_joinServerAuto.Visible = false;
                btn_reinstallTFRPlugins.Visible = false;
                pref_serverAutopilot.Visible = true;
                chb_battleye.Enabled = false;
                btn_addonManager.Visible = true;

                pref_startGameAfterDownloadsAreCompleted.Text = "Start server when ready";

                cb_clientProfile.Enabled = false;
                lbl_clientProfile.Enabled = false;

                foreach (Control control in panel_TeamSpeakDir.Controls)
                {
                    control.Visible = false;
                }

                if (!Properties.Settings.Default.firstLaunch)
                    if (new Windows.DelayServerStart().ShowDialog() == DialogResult.OK)
                        switchAutopilot(true);
                    else
                        switchAutopilot(false);

                this.ServerSettings();
            }

            if (!GlobalVar.autoPilot && !QuickUpdateMethod.QuickCheck())
            {
                menuSelected = 4;
                HideUnhide(menuSelected);

                panelLaunch.Enabled = false;
                sysbtn_moreOptions.Visible = false;

                aboutPanelIO = new PanelIO(panel_about, Panels, 435, 437, 33);

                activeButton = btn_update;
                backgroundBlinker.RunWorkerAsync();

                isUpdate = true;
            }
            else if (Properties.Settings.Default.firstLaunch)
            {
                if (GlobalVar.isServer) { pref_startGameAfterDownloadsAreCompleted.Checked = true; }

                menuSelected = 3;
                HideUnhide(menuSelected);
            }
            else
            {
                menuSelected = 0;
                HideUnhide(menuSelected);
            }

            this.ClientSettings();
            this.FetchSettings();

            if (!isUpdate)
            {
                updateCurrentPack(true);
                getMalloc();


                if (Directory.Exists(AddonsFolder + @"@task_force_radio\plugins"))
                    btn_reinstallTFRPlugins.Enabled = true;
                else
                    btn_reinstallTFRPlugins.Enabled = false;
            }

            UpdateMethod.CheckUpdates();

            loadingSplash.Close();
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            windowIO.windowIn();

            PacksPanel.Focus();

            if (!isUpdate)
            {
                topPanelsIO.showPanelDual();
                await taskDelay(800);
                topPanelsIO = new PanelIO(panelDirectories, 437, 90, 33);
                panelMenu.Dock = DockStyle.Bottom;
                panelDirectories.BringToFront();
            }

            if (ReadRepo(false) && panelMenu.Visible == true)
            {
                topPanelsIO.showPanelSingle();
                btn_opencloseDirPanel.Image = Properties.Resources.chevron_up;
            }
            else
            {
                if (GlobalVar.autoPilot)
                {
                    await taskDelay(2500);
                    launchProcess();
                }
            }

            this.hasShown = true;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!installer.isInstalling())
            {
                SaveSettings();
                GC.Collect();
            }
            else
            {
                if (MessageBox.Show("The launcher is installing the addons. Do you want to cancel the process and leave?", "Installing addons", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    e.Cancel = true;
                else
                { SaveSettings(); GC.Collect(); }
            }
        }

        public void GetAddons()
        {
            aLooker.getAddons(Properties.Settings.Default.Arma3Folder + "\\!Workshop");
        }

        private void ServerSettings()
        {
            cb_serverConfig.Items.Clear();
            cb_serverProfile.Items.Clear();
            cb_hcProfile.Items.Clear();

            string documentsA3Profiles = "";
            try { documentsA3Profiles = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Arma 3 - Other Profiles"; }
            catch { }

            // get server config
            if (File.Exists(Properties.Settings.Default.Arma3Folder + "server.cfg"))
                cb_serverConfig.Items.Add("server.cfg");
            else
                cb_serverConfig.Items.Add("Server.cfg not found");

            // get server profiles
            cb_serverProfile.Items.Add("Default");
            if (documentsA3Profiles != string.Empty && Directory.Exists(documentsA3Profiles))
            {
                foreach (var item in Directory.GetDirectories(documentsA3Profiles, "*", SearchOption.TopDirectoryOnly))
                {
                    cb_serverProfile.Items.Add(item.Remove(0, documentsA3Profiles.Length + 1));
                }
            }

            // get hc profiles
            cb_hcProfile.Items.Add("Default");
            if (documentsA3Profiles != string.Empty && Directory.Exists(documentsA3Profiles))
            {
                foreach (var item in Directory.GetDirectories(documentsA3Profiles, "*", SearchOption.TopDirectoryOnly))
                {
                    cb_hcProfile.Items.Add(item.Remove(0, documentsA3Profiles.Length + 1));
                }
            }
        }

        private void ClientSettings()
        {
            cb_clientProfile.Items.Clear();

            string documentsA3Profiles = "";
            try { documentsA3Profiles = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Arma 3 - Other Profiles"; }
            catch { }

            cb_clientProfile.Items.Add("Default");
            if (documentsA3Profiles != string.Empty && Directory.Exists(documentsA3Profiles))
            {
                foreach (var item in Directory.GetDirectories(documentsA3Profiles, "*", SearchOption.TopDirectoryOnly))
                {
                    cb_clientProfile.Items.Add(item.Remove(0, documentsA3Profiles.Length + 1));
                }
            }
        }

        public bool ReadRepo(bool showMessage)
        {
            if (GlobalVar.isReadingRepo)
                return false;

            GlobalVar.isReadingRepo = true;

            if (Properties.Settings.Default.AddonsFolder != string.Empty)
            {
                string updateType = repoReader.ReadRepo();

                if (updateType == string.Empty)
                {
                    if (showMessage)
                        MessageBox.Show("All files are synced with the repository!", "You're amazing", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GlobalVar.isReadingRepo = false;
                    return false;
                }
                else
                {
                    if (updateType == "download" && (GlobalVar.autoPilot || pref_autoDownload.Checked || (showMessage && MessageBox.Show("Your local files are not in sync with the repository.\nDo you want to download the missing files?", "Repository has new updates", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)))
                        downloader.beginDownload(GlobalVar.files2Download, GlobalVar.autoPilot, activePack);
                    else
                    {
                        if (updateType == "validation") { installer.ValidateLocalFiles(); }
                        else { GlobalVar.isReadingRepo = false; }
                    }

                    return true;
                }
            }
            else
            {
                this.trv_repoContent.Nodes.Clear();
                this.trv_repoContent.Nodes.Add("ERROR", "No addons folder selected!", 5, 5);

                this.lbl_repofileok.Text = "N/A";
                this.lbl_repofileinvalid.Text = "N/A";
                this.lbl_repofilemissing.Text = "N/A";

                GlobalVar.isReadingRepo = false;
                return false;
            }
        }

        private void FetchSettings()
        {
            // directories
            if (Properties.Settings.Default.Arma3Folder != string.Empty)
            { txtb_armaDirectory.ForeColor = Color.FromArgb(64, 64, 64); GameFolder = txtb_armaDirectory.Text = Properties.Settings.Default.Arma3Folder; }
            else
            { txtb_armaDirectory.ForeColor = Color.DarkGray; txtb_armaDirectory.Text = "Set directory ->"; }

            if (Properties.Settings.Default.TS3Folder != string.Empty)
            { txtb_tsDirectory.ForeColor = Color.FromArgb(64, 64, 64); TSFolder = txtb_tsDirectory.Text = Properties.Settings.Default.TS3Folder; }
            else
            { txtb_tsDirectory.ForeColor = Color.DarkGray; txtb_tsDirectory.Text = "Set directory ->"; }

            if (Properties.Settings.Default.AddonsFolder != string.Empty)
            { txtb_modsDirectory.ForeColor = Color.FromArgb(64, 64, 64); AddonsFolder = txtb_modsDirectory.Text = Properties.Settings.Default.AddonsFolder; }
            else
            { txtb_modsDirectory.ForeColor = Color.DarkGray; txtb_modsDirectory.Text = "Set directory ->"; }

            // launch options
            chb_noPause.Checked = Properties.Settings.Default.noPause;
            chb_noSplash.Checked = Properties.Settings.Default.noSplash;
            chb_enableHT.Checked = Properties.Settings.Default.enableHT;
            chb_skipIntro.Checked = Properties.Settings.Default.skipIntro;
            chb_window.Checked = Properties.Settings.Default.window;
            chb_showScriptErrors.Checked = Properties.Settings.Default.showScriptErrors;
            chb_hugePages.Checked = Properties.Settings.Default.hugePages;
            chb_filePatching.Checked = Properties.Settings.Default.filePatching;
            chb_worldEmpty.Checked = Properties.Settings.Default.worldEmpty;

            chb_maxMem.Checked = Properties.Settings.Default.maxMem;
            txtb_maxMem.Text = Properties.Settings.Default.maxMem_value.ToString();

            chb_malloc.Checked = Properties.Settings.Default.malloc;
            txtb_malloc.Text = Properties.Settings.Default.malloc_value.ToString();

            chb_exThreads.Checked = Properties.Settings.Default.exThreads;
            txtb_exThreads.Text = Properties.Settings.Default.exThreads_value.ToString();

            chb_cpuCount.Checked = Properties.Settings.Default.cpuCount;
            txtb_cpuCount.Text = Properties.Settings.Default.cpuCount_value.ToString();

            // game artifact
            if (Environment.Is64BitOperatingSystem)
            {
                pref_64bitGame.Checked = Properties.Settings.Default.x64Game;
                pref_64bitGame.Visible = true;
                img_x64status.Visible = true;

                if (Properties.Settings.Default.x64Game)
                {
                    img_x64status.Image = Properties.Resources.x64_active;

                    if (GlobalVar.isServer)
                    {
                        GlobalVar.gameArtifact = "arma3server_x64.exe";
                    }
                    else
                    {
                        chb_battleye.Checked = Properties.Settings.Default.battleye;
                        if (Properties.Settings.Default.battleye)
                            GlobalVar.gameArtifact = "arma3battleye.exe";
                        else
                            GlobalVar.gameArtifact = "arma3_x64.exe";
                    }
                }
                else
                {
                    img_x64status.Image = Properties.Resources.x64_inactive;

                    if (GlobalVar.isServer)
                    {
                        GlobalVar.gameArtifact = "arma3server.exe";
                    }
                    else
                    {
                        chb_battleye.Checked = Properties.Settings.Default.battleye;
                        if (Properties.Settings.Default.battleye)
                            GlobalVar.gameArtifact = "arma3battleye.exe";
                        else
                            GlobalVar.gameArtifact = "arma3.exe";
                    }
                }
            }
            else
            {
                pref_64bitGame.Checked = false;
                Properties.Settings.Default.x64Game = false;


                if (GlobalVar.isServer)
                {
                    GlobalVar.gameArtifact = "arma3server.exe";
                }
                else
                {
                    chb_battleye.Checked = Properties.Settings.Default.battleye;
                    if (Properties.Settings.Default.battleye)
                        GlobalVar.gameArtifact = "arma3battleye.exe";
                    else
                        GlobalVar.gameArtifact = "arma3.exe";
                }
            }

            // preferences
            pref_startGameAfterDownloadsAreCompleted.Checked = Properties.Settings.Default.startGameAfterDownload;
            pref_runLauncherOnStartup.Checked = Properties.Settings.Default.runLauncherOnStartup;
            pref_allowNotifications.Checked = Properties.Settings.Default.allowNotifications;
            pref_autoDownload.Checked = Properties.Settings.Default.autoDownload;
            pref_joinServerAuto.Checked = Properties.Settings.Default.joinServerAutomatically;

            // server-client specific settings
            if (GlobalVar.isServer)
            {
                if (Properties.Settings.Default.ServerConfig != string.Empty)
                    cb_serverConfig.SelectedItem = Properties.Settings.Default.ServerConfig;
                else
                    cb_serverConfig.SelectedIndex = 0;

                if (Properties.Settings.Default.ServerProfile != string.Empty)
                    cb_serverProfile.SelectedItem = Properties.Settings.Default.ServerProfile;
                else
                    cb_serverProfile.SelectedIndex = 0;

                if (Properties.Settings.Default.HCProfile != string.Empty)
                    cb_hcProfile.SelectedItem = Properties.Settings.Default.HCProfile;
                else
                    cb_hcProfile.SelectedIndex = 0;

                cb_hcInstances.SelectedIndex = Properties.Settings.Default.HCInstances;
            }
            else
            {
                if (Properties.Settings.Default.ClientProfile != string.Empty)
                    cb_clientProfile.SelectedItem = Properties.Settings.Default.ClientProfile;
                else
                    cb_clientProfile.SelectedIndex = 0;
            }
        }

        private void SaveSettings()
        {
            // launch options
            Properties.Settings.Default.noPause = chb_noPause.Checked;
            Properties.Settings.Default.noSplash = chb_noSplash.Checked;
            Properties.Settings.Default.enableHT = chb_enableHT.Checked;
            Properties.Settings.Default.skipIntro = chb_skipIntro.Checked;
            Properties.Settings.Default.window = chb_window.Checked;
            Properties.Settings.Default.battleye = chb_battleye.Checked;
            Properties.Settings.Default.showScriptErrors = chb_showScriptErrors.Checked;
            Properties.Settings.Default.hugePages = chb_hugePages.Checked;
            Properties.Settings.Default.filePatching = chb_filePatching.Checked;
            Properties.Settings.Default.worldEmpty = chb_worldEmpty.Checked;

            Properties.Settings.Default.maxMem = chb_maxMem.Checked;
            Properties.Settings.Default.maxMem_value = Convert.ToInt32(txtb_maxMem.Text);

            Properties.Settings.Default.malloc = chb_malloc.Checked;
            Properties.Settings.Default.malloc_value = txtb_malloc.Text;

            Properties.Settings.Default.exThreads = chb_exThreads.Checked;
            Properties.Settings.Default.exThreads_value = Convert.ToInt32(txtb_exThreads.Text);

            Properties.Settings.Default.cpuCount = chb_cpuCount.Checked;
            Properties.Settings.Default.cpuCount_value = Convert.ToInt32(txtb_cpuCount.Text);

            Properties.Settings.Default.x64Game = pref_64bitGame.Checked;

            // preferences
            Properties.Settings.Default.startGameAfterDownload = pref_startGameAfterDownloadsAreCompleted.Checked;
            Properties.Settings.Default.runLauncherOnStartup = pref_runLauncherOnStartup.Checked;
            Properties.Settings.Default.allowNotifications = pref_allowNotifications.Checked;
            Properties.Settings.Default.autoDownload = pref_autoDownload.Checked;
            Properties.Settings.Default.joinServerAutomatically = pref_joinServerAuto.Checked;

            // server-client specific settings
            if (GlobalVar.isServer)
            {
                Properties.Settings.Default.ServerConfig = (string)cb_serverConfig.SelectedItem;
                Properties.Settings.Default.ServerProfile = (string)cb_serverProfile.SelectedItem;
                Properties.Settings.Default.HCProfile = (string)cb_hcProfile.SelectedItem;
                Properties.Settings.Default.HCInstances = cb_hcInstances.SelectedIndex;
            }
            else
            {
                Properties.Settings.Default.ClientProfile = (string)cb_clientProfile.SelectedItem;
            }

            Properties.Settings.Default.Save();
        }

        public void FetchRemoteSettings(bool refreshPacks)
        {
            bool forceRefreshPacks = false;
            modsName.Clear();

            AddonsFolder = Properties.Settings.Default.AddonsFolder;

            try
            {
                XmlDocument RemoteXmlInfo = new XmlDocument();
                RemoteXmlInfo.Load(Properties.GlobalValues.S_VersionXML);

                string xmlNodes = "";
                XmlNodeList xnl;

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
                { Properties.Settings.Default.lastAddonPack = activePack = firstPack; forceRefreshPacks = true; }

                isOptionalAllowed = Convert.ToBoolean(RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + activePack).Attributes["optional"].Value);

                if (isOptionalAllowed)
                { panel_steamAddons.Enabled = true; }
                else
                { panel_steamAddons.Enabled = false; }

                xmlNodes = "//arma3Launcher//ModSetInfo//" + activePack + "//mod";
                xnl = RemoteXmlInfo.SelectNodes(xmlNodes);

                foreach (XmlNode xn in xnl)
                {
                    modsName.Add(xn.Attributes["name"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to fetch remote settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_progressStatus.Text = "Unable to fetch remote settings.";
            }
            finally
            {
                if (refreshPacks || forceRefreshPacks)
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
            windowIO.windowOut(true);
        }

        private void sysbtn_minimize_Click(object sender, EventArgs e)
        {
            minimizeWindow();
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
            this.browseGameFolder();
        }

        private void btn_browseTS3_Click(object sender, EventArgs e)
        {
            this.browseTSFolder();
        }

        private void browseGameFolder()
        {
            dlg_folderBrowser.Description = "Select Arma 3 root folder.";
            if (Directory.Exists(txtb_armaDirectory.Text))
                dlg_folderBrowser.SelectedPath = txtb_armaDirectory.Text;

            if (dlg_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string auxA3Folder = dlg_folderBrowser.SelectedPath;
                bool auxIsFolder = false;

                try
                {
                    foreach (string f in Directory.GetFiles(auxA3Folder))
                    {
                        if ((f.Contains(GlobalVar.gameArtifact) && !GlobalVar.isServer) || (f.Contains("arma3server.exe") && GlobalVar.isServer)) { auxIsFolder = true; break; }
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
                        GameFolder = Properties.Settings.Default.Arma3Folder = auxA3Folder + @"\";
                        Properties.Settings.Default.Save();
                        txtb_armaDirectory.Text = auxA3Folder;
                        GetAddons();
                    }
                    else
                    {
                        MessageBox.Show("Game executable not there. Please check your Arma 3 directory and try again.", "Missing file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            dlg_folderBrowser.SelectedPath = "";
        }

        private void browseTSFolder()
        {
            dlg_folderBrowser.Description = "Select TeamSpeak 3 root folder.";
            if (Directory.Exists(txtb_tsDirectory.Text))
                dlg_folderBrowser.SelectedPath = txtb_tsDirectory.Text;

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
                        TSFolder = Properties.Settings.Default.TS3Folder = auxTS3Folder + @"\";
                        Properties.Settings.Default.Save();
                        txtb_tsDirectory.Text = auxTS3Folder;
                    }
                    else
                    {
                        MessageBox.Show("TeamSpeak executable not there. Please check your TeamSpeak directory and try again.", "Missing file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            dlg_folderBrowser.SelectedPath = "";
        }

        private void browseAddonsFolder()
        {
            dlg_folderBrowser.ShowNewFolderButton = true;
            dlg_folderBrowser.Description = "Select the Addons folder or create a new one.\n⚠ It can't be the same as the Game folder.";
            if (Directory.Exists(txtb_modsDirectory.Text))
                dlg_folderBrowser.SelectedPath = txtb_modsDirectory.Text;

            if (dlg_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (dlg_folderBrowser.SelectedPath != GameFolder || GlobalVar.isServer)
                {
                    AddonsFolder = Properties.Settings.Default.AddonsFolder = dlg_folderBrowser.SelectedPath + @"\";
                    Properties.Settings.Default.Save();
                    txtb_modsDirectory.Text = dlg_folderBrowser.SelectedPath;
                }
                else
                {
                    MessageBox.Show("The Addons folder can't be the same as the Game folder.\nWe recommend you to have a specific folder for the addons on this launcher to avoid conflicts.", "Wrong directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.browseAddonsFolder();
                }
            }

            dlg_folderBrowser.SelectedPath = "";
            dlg_folderBrowser.ShowNewFolderButton = false;
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
        private bool _isTop = false;
        private async void HideUnhide(int selectedOption)
        {
            if (!GlobalVar.isAnimating)
            {
                if (panel_packs.Height > 0) { Panels.BackColor = Color.DimGray; addonsPanelIO.hidePanelDual(); menu_packs.ForeColor = Color.Gray; }
                if (panel_community.Height > 0) { Panels.BackColor = Color.DimGray; communityPanelIO.hidePanelDual(); menu_community.ForeColor = Color.Gray; }
                if (panel_launchOptions.Height > 0) { Panels.BackColor = Color.DimGray; launchoptionsPanelIO.hidePanelDual(); menu_launchOptions.ForeColor = Color.Gray; }
                if (panel_help.Height > 0) { Panels.BackColor = Color.DimGray; helpPanelIO.hidePanelDual(); menu_help.ForeColor = Color.Gray; }
                if (panel_about.Height > 0) { Panels.BackColor = Color.DimGray; aboutPanelIO.hidePanelDual(); menu_about.ForeColor = Color.Gray; }

                while (GlobalVar.isAnimating)
                    await taskDelay(300);

                if (selectedOption == 0) { Panels.BackColor = Color.OliveDrab; menu_packs.ForeColor = Color.OliveDrab; addonsPanelIO.showPanelDual(); }
                if (selectedOption == 1) { Panels.BackColor = Color.OliveDrab; menu_community.ForeColor = Color.OliveDrab; communityPanelIO.showPanelDual(); }
                if (selectedOption == 2) { Panels.BackColor = Color.OliveDrab; menu_launchOptions.ForeColor = Color.OliveDrab; launchoptionsPanelIO.showPanelDual(); }
                if (selectedOption == 3) { Panels.BackColor = Color.OliveDrab; menu_help.ForeColor = Color.OliveDrab; helpPanelIO.showPanelDual(); }
                if (selectedOption == 4) { Panels.BackColor = Color.OliveDrab; menu_about.ForeColor = Color.OliveDrab; aboutPanelIO.showPanelDual(); }
            }
        }

        /*-----------------------------------
            Menu News
        -----------------------------------*/
        private void menu_news_Click(object sender, EventArgs e)
        {
            if (!GlobalVar.isAnimating)
            {
                menuSelected = 0;
                HideUnhide(menuSelected);
            }
        }

        private void menu_news_MouseEnter(object sender, EventArgs e)
        {
            menu_packs.ForeColor = Color.DarkGray;
        }

        private void menu_news_MouseLeave(object sender, EventArgs e)
        {
            if (menuSelected != 0)
                menu_packs.ForeColor = Color.Gray;
            else
                menu_packs.ForeColor = Color.OliveDrab;
        }

        /*-----------------------------------
            Menu spN Community
        -----------------------------------*/
        private void menu_community_Click(object sender, EventArgs e)
        {
            if (!GlobalVar.isAnimating)
            {
                menuSelected = 1;
                HideUnhide(menuSelected);
            }
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
            if (!GlobalVar.isAnimating)
            {
                menuSelected = 2;
                HideUnhide(menuSelected);
            }
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
            if (!GlobalVar.isAnimating)
            {
                menuSelected = 3;
                HideUnhide(menuSelected);
            }
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
            if (!GlobalVar.isAnimating)
            {
                menuSelected = 4;
                HideUnhide(menuSelected);
            }
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
            windowIO.windowOut(true);
        }

        void StartUpdator()
        {
            try
            {
                WebClient update_file = new WebClient();
                Uri update_url = new Uri(Properties.GlobalValues.S_UpdateUrl);

                update_file.DownloadFile(update_url, Application.ExecutablePath.Remove(Application.ExecutablePath.Length - Process.GetCurrentProcess().MainModule.ModuleName.Length) + "zUpdator.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                var fass = new ProcessStartInfo();
                fass.WorkingDirectory = Application.ExecutablePath.Remove(Application.ExecutablePath.Length - Process.GetCurrentProcess().MainModule.ModuleName.Length);
                fass.FileName = "zUpdator.exe";
                fass.Arguments = "-curversion=" + txt_curversion.Text +
                    " -newversion=" + txt_latestversion.Text +
                    " -filename=" + Process.GetCurrentProcess().MainModule.ModuleName;

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

        #region Game Options Conditions
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
            { txtb_cpuCount.Enabled = true; chb_enableHT.Enabled = false; chb_enableHT.Checked = false; }
            else
            { txtb_cpuCount.Enabled = false; chb_enableHT.Enabled = true; }
        }
        #endregion

        private void btn_Launch_Click(object sender, EventArgs e)
        {
            btn_Launch.Focus();
            launchProcess();
        }

        public void reLaunchServer()
        {
            if (new Windows.DelayServerStart().ShowDialog() == DialogResult.OK)
                switchAutopilot(true);
            else
                switchAutopilot(false);

            if (GlobalVar.autoPilot)
                launchProcess();
        }

        private void launchProcess()
        {
            if ((Directory.Exists(TSFolder) && (File.Exists(TSFolder + "ts3client_win64.exe") || File.Exists(TSFolder + "ts3client_win32.exe")) || GlobalVar.isServer))
            {
                if (Directory.Exists(GameFolder) && ((File.Exists(GameFolder + GlobalVar.gameArtifact) && !GlobalVar.isServer) || (File.Exists(GameFolder + "arma3server.exe") && GlobalVar.isServer)))
                {
                    if (Directory.Exists(AddonsFolder))
                    {
                        updateCurrentPack(false);

                        btn_Launch.Enabled = false;

                        PrepareLaunch = new LaunchCore(panel_launchOptionsChb,
                            (string)cb_clientProfile.SelectedItem,
                            (string)cb_serverConfig.SelectedItem,
                            (string)cb_serverProfile.SelectedItem,
                            (string)cb_hcProfile.SelectedItem,
                            cb_hcInstances.SelectedIndex,
                            chb_maxMem.Checked,
                            txtb_maxMem.Text,
                            chb_malloc.Checked,
                            txtb_malloc.Text,
                            chb_exThreads.Checked,
                            txtb_exThreads.Text,
                            chb_cpuCount.Checked,
                            txtb_cpuCount.Text,
                            steamworkshopAddonsList,
                            modsName,
                            this);

                        Arguments = PrepareLaunch.GetArguments();
                        SaveSettings();

                        if (activePack == "arma3" || PrepareLaunch.isModPackInstalled())
                            runGame();
                        else
                        {
                            if (!GlobalVar.isDownloading && !GlobalVar.isInstalling)
                                downloader.beginDownload(GlobalVar.files2Download, true, activePack);
                            else
                                MessageBox.Show("There's a download already in progress. Please wait for it to finish.", "Download already in progress", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Addons directory doesn't exist. Please check your Addons directory and try again.", "Missing directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.browseAddonsFolder();
                    }
                }
                else
                {
                    MessageBox.Show("Game directory doesn't exist or executable not there. Please check your Arma 3 directory and try again.", "Missing directory or file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.browseGameFolder();
                }
            }
            else
            {
                MessageBox.Show("TeamSpeak directory doesn't exist or executable not there. Please check your TeamSpeak directory and try again.", "Missing directory or file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.browseTSFolder();
            }
        }

        private void txtb_armaDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtb_armaDirectory.Text != "Set directory ->" && txtb_armaDirectory.Text != "")
            {
                txtb_armaDirectory.ForeColor = Color.FromArgb(64, 64, 64);

                if (txtb_armaDirectory.Text.EndsWith("\\"))
                    txtb_armaDirectory.Text = txtb_armaDirectory.Text.Remove(txtb_armaDirectory.Text.Length - 1);

                if (txtb_armaDirectory.Text.EndsWith("/"))
                    txtb_armaDirectory.Text = txtb_armaDirectory.Text.Remove(txtb_armaDirectory.Text.Length - 1).Replace("/", "\\");

                if (Directory.Exists(txtb_armaDirectory.Text) && ((File.Exists(txtb_armaDirectory.Text + @"\arma3battleye.exe") && !GlobalVar.isServer) || (File.Exists(txtb_armaDirectory.Text + @"\arma3server.exe") && GlobalVar.isServer)))
                {
                    GameFolder = Properties.Settings.Default.Arma3Folder = txtb_armaDirectory.Text + @"\";
                    Properties.Settings.Default.Save();

                    getMalloc();
                    armaDir_previousDir = txtb_armaDirectory.Text;
                }
                else
                {
                    MessageBox.Show("Game executable not there. Please check your Arma 3 directory and try again.", "Missing file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (String.IsNullOrEmpty(armaDir_previousDir))
                        this.browseGameFolder();
                    else
                        txtb_armaDirectory.Text = armaDir_previousDir;
                }
            }
            else
            {
                if (txtb_armaDirectory.Text == "")
                {
                    Properties.Settings.Default.Arma3Folder = "";
                    Properties.Settings.Default.Save();

                    txtb_armaDirectory.ForeColor = Color.DarkGray; txtb_armaDirectory.Text = "Set directory ->";
                }
            }
        }

        private void txtb_tsDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtb_tsDirectory.Text != "Set directory ->" && txtb_tsDirectory.Text != "")
            {
                txtb_tsDirectory.ForeColor = Color.FromArgb(64, 64, 64);

                if (txtb_tsDirectory.Text.EndsWith("\\"))
                    txtb_tsDirectory.Text = txtb_tsDirectory.Text.Remove(txtb_tsDirectory.Text.Length - 1);

                if (txtb_tsDirectory.Text.EndsWith("/"))
                    txtb_tsDirectory.Text = txtb_tsDirectory.Text.Remove(txtb_tsDirectory.Text.Length - 1).Replace("/", "\\");

                if (Directory.Exists(txtb_tsDirectory.Text) && (File.Exists(txtb_tsDirectory.Text + @"\ts3client_win64.exe") || File.Exists(txtb_tsDirectory.Text + @"\ts3client_win32.exe")))
                {
                    TSFolder = Properties.Settings.Default.TS3Folder = txtb_tsDirectory.Text + @"\";
                    Properties.Settings.Default.Save();

                    tsDir_previousDir = txtb_tsDirectory.Text;
                }
                else
                {
                    MessageBox.Show("TeamSpeak executable not there. Please check your TeamSpeak directory and try again.", "Missing file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (String.IsNullOrEmpty(tsDir_previousDir))
                        this.browseTSFolder();
                    else
                        txtb_tsDirectory.Text = tsDir_previousDir;
                }
            }
            else
            {
                if (txtb_tsDirectory.Text == "")
                {
                    Properties.Settings.Default.TS3Folder = "";
                    Properties.Settings.Default.Save();

                    txtb_tsDirectory.ForeColor = Color.DarkGray; txtb_tsDirectory.Text = "Set directory ->";
                }
            }
        }

        private void txtb_modsDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtb_modsDirectory.Text != "Set directory ->" && txtb_modsDirectory.Text != "")
            {
                txtb_modsDirectory.ForeColor = Color.FromArgb(64, 64, 64);

                if (txtb_modsDirectory.Text.EndsWith("\\"))
                    txtb_modsDirectory.Text = txtb_modsDirectory.Text.Remove(txtb_modsDirectory.Text.Length - 1);

                if (txtb_modsDirectory.Text.EndsWith("/"))
                    txtb_modsDirectory.Text = txtb_modsDirectory.Text.Remove(txtb_modsDirectory.Text.Length - 1).Replace("/", "\\");

                if ((txtb_modsDirectory.Text != txtb_armaDirectory.Text && !File.Exists(txtb_modsDirectory.Text + "\\arma3.exe")) || GlobalVar.isServer)
                {
                    AddonsFolder = Properties.Settings.Default.AddonsFolder = txtb_modsDirectory.Text + @"\";
                    Properties.Settings.Default.Save();

                    GetAddons();
                    modsDir_previousDir = txtb_modsDirectory.Text;
                }
                else
                {
                    MessageBox.Show("The Addons folder can't be the same as the Game folder.\nWe recommend you to have a specific folder for the addons on this launcher to avoid conflicts.", "Wrong directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (String.IsNullOrEmpty(modsDir_previousDir))
                        this.browseAddonsFolder();
                    else
                        txtb_modsDirectory.Text = modsDir_previousDir;
                }
            }
            else
            {
                if (txtb_modsDirectory.Text == "")
                {
                    Properties.Settings.Default.AddonsFolder = "";
                    Properties.Settings.Default.Save();

                    txtb_modsDirectory.ForeColor = Color.DarkGray; txtb_modsDirectory.Text = "Set directory ->";
                }
            }

            if(hasShown)
                ReadRepo(false);
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
            PrepareLaunch = new LaunchCore(panel_launchOptionsChb,
                (string)cb_clientProfile.SelectedItem,
                (string)cb_serverConfig.SelectedItem,
                (string)cb_serverProfile.SelectedItem,
                (string)cb_hcProfile.SelectedItem,
                cb_hcInstances.SelectedIndex,
                chb_maxMem.Checked,
                txtb_maxMem.Text,
                chb_malloc.Checked,
                txtb_malloc.Text,
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

        private void btn_reloadAddons_Click(object sender, EventArgs e)
        {
            updateCurrentPack(false);
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

        private void btn_ereaseModsDirectory_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AddonsFolder = "";
            Properties.Settings.Default.Save();

            txtb_modsDirectory.ForeColor = Color.DarkGray; txtb_modsDirectory.Text = "Set directory ->";
        }

        private void btn_browseModsDirectory_Click(object sender, EventArgs e)
        {
            this.browseAddonsFolder();
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
            updateCurrentPack(true);
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

            MessageBox.Show("Temp Path: " + TempFolder + "\nGame Server: " + remoteReader.ServerInfo()[0] + ":" + remoteReader.ServerInfo()[1] + "\n\nActive Mods:" + aux_listMods, "Fetched remote settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_reinstallTFRPlugins_Click(object sender, EventArgs e)
        { installer.installTeamSpeakPlugin(); }

        public async void runGame()
        { hideDownloadPanel(); await taskDelay(800); PrepareLaunch.LaunchGame(Arguments, txt_progressStatus, btn_Launch, remoteReader.ServerInfo(), remoteReader.TeamSpeakInfo(), pref_joinServerAuto.Checked); }

        public void updateCurrentPack(bool refreshPacks)
        { FetchRemoteSettings(refreshPacks); GetAddons(); }

        public bool startGameAfterDownload()
        { return pref_startGameAfterDownloadsAreCompleted.Checked; }

        public bool runLauncherStartup()
        { return pref_runLauncherOnStartup.Checked; }

        public bool allowNotifications()
        { return pref_allowNotifications.Checked; }

        public bool autoDownloadUpdates()
        { return pref_autoDownload.Checked; }

        public void updateActivePack(string packName)
        { txt_selectedPack.MinimumSize = new Size(200, 0); txt_selectedPack.Text = packName; }

        public void reSizeBarText(string text)
        { txt_reSizeBar.Text = "#" + text; }

        public void showDownloadPanel()
        { botPanelIO.showPanelDual(); }

        public void hideDownloadPanel()
        { botPanelIO.hidePanelDual(); }

        private void txtb_armaDirectory_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtb_armaDirectory.Text == "Set directory ->")
                txtb_armaDirectory.SelectAll();
        }

        private void txtb_armaDirectory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtb_armaDirectory.SelectAll();
        }

        private void txtb_tsDirectory_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtb_tsDirectory.Text == "Set directory ->")
                txtb_tsDirectory.SelectAll();
        }

        private void txtb_tsDirectory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtb_tsDirectory.SelectAll();
        }

        private void txtb_modsDirectory_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtb_modsDirectory.Text == "Set directory ->")
                txtb_modsDirectory.SelectAll();
        }

        private void txtb_modsDirectory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtb_modsDirectory.SelectAll();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Properties.Settings.Default.firstLaunch) { Properties.Settings.Default.firstLaunch = false; Properties.Settings.Default.Save(); }
        }

        private void btn_reloadMallocs_Click(object sender, EventArgs e)
        {
            getMalloc();
        }

        private async Task taskDelay(int delayMs)
        {
            await Task.Delay(delayMs);
        }

        private void btn_cancelDownload_MouseHover(object sender, EventArgs e)
        {
            btn_cancelDownload.BackgroundImage = Properties.Resources.cancel_circle_big_red;
        }

        private void btn_cancelDownload_MouseLeave(object sender, EventArgs e)
        {
            btn_cancelDownload.BackgroundImage = Properties.Resources.cancel_circle_big_white;
        }

        private void btn_cancelDownload_Click(object sender, EventArgs e)
        {
            if (GlobalVar.isDownloading)
            {
                if (MessageBox.Show("Are you sure you want to stop the download?", "Stop download progress?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    downloader.cancelDownload();
            }

            if (GlobalVar.isInstalling)
            {
                MessageBox.Show("One does not simply stop the installation process.", "You can't stop me now!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void switchToServerModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GlobalVar.isServer)
                Properties.Settings.Default.isServerMode = false;
            else
                Properties.Settings.Default.isServerMode = true;

            this.Close();
            Process.Start(Application.ExecutablePath);
        }

        private void pref_serverAutopilot_CheckedChanged(object sender, EventArgs e)
        {
            if (pref_serverAutopilot.Checked)
                switchAutopilot(true);
            else
                switchAutopilot(false);
        }

        private void switchAutopilot(bool On)
        {
            if (On)
            { GlobalVar.autoPilot = true; WindowVersionStatus.Text = "Autopilot engaged"; pref_serverAutopilot.Checked = true; }
            else
            { GlobalVar.autoPilot = false; WindowVersionStatus.Text = oldVersionStatusText; pref_serverAutopilot.Checked = false; }
        }

        private void pref_runLauncherOnStartup_Click(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (pref_runLauncherOnStartup.Checked)
                rk.SetValue(AssemblyTitle, Application.ExecutablePath);
            else
                rk.DeleteValue(AssemblyTitle, false);
        }

        private void pref_64bitGame_Click(object sender, EventArgs e)
        {
            if (pref_64bitGame.Checked)
            {
                img_x64status.Image = Properties.Resources.x64_active;

                if (GlobalVar.isServer)
                {
                    GlobalVar.gameArtifact = "arma3server_x64.exe";
                }
                else
                {
                    if (Properties.Settings.Default.battleye)
                        GlobalVar.gameArtifact = "arma3battleye.exe";
                    else
                        GlobalVar.gameArtifact = "arma3_x64.exe";
                }
            }
            else
            {
                img_x64status.Image = Properties.Resources.x64_inactive;

                if (GlobalVar.isServer)
                {
                    GlobalVar.gameArtifact = "arma3server.exe";
                }
                else
                {
                    if (Properties.Settings.Default.battleye)
                        GlobalVar.gameArtifact = "arma3battleye.exe";
                    else
                        GlobalVar.gameArtifact = "arma3.exe";
                }
            }
        }

        private void WindowVersionStatus_TextChanged(object sender, EventArgs e)
        {
            if (WindowVersionStatus.Text != "Autopilot engaged")
                oldVersionStatusText = WindowVersionStatus.Text;
        }

        private void chb_battleye_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_battleye.Checked)
                GlobalVar.gameArtifact = "arma3battleye.exe";
            else
                GlobalVar.gameArtifact = "arma3.exe";
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                windowIO.windowIn();
        }

        public void minimizeWindow()
        {
            windowIO.windowOut(false);
        }

        private void btn_checkUpdates_Click(object sender, EventArgs e)
        {
            busy.Visible = true;

            if (!QuickUpdateMethod.QuickCheck())
            {
                UpdateMethod.CheckUpdates();
                activeButton = btn_update;
                backgroundBlinker.RunWorkerAsync();
            }
        }

        private System.Windows.Forms.Timer reSize_Underline = new System.Windows.Forms.Timer();

        private async void txt_selectedPack_TextChanged(object sender, EventArgs e)
        {
            reSize_Underline.Tick += ReSizeUnderline_Tick;
            reSize_Underline.Interval = 1;

            await taskDelay(400);
            txt_selectedPack.MinimumSize = new Size(0, 0);
            await taskDelay(400);
            reSize_Underline.Start();
        }

        private void ReSizeUnderline_Tick(object sender, EventArgs e)
        {
            if (packName_underLine.Width > txt_selectedPack.Width + 30)
                packName_underLine.Width--;
            else
                packName_underLine.Width++;

            if (packName_underLine.Width == txt_selectedPack.Width + 30)
                reSize_Underline.Stop();
        }

        private void txt_thisSpace_Click(object sender, EventArgs e)
        {
            txt_thisSpace.Text = "What about now? Funky right?";
            img_thisSpace.Image = Properties.Resources.littlecat;
        }

        private void txt_thisSpace_MouseHover(object sender, EventArgs e)
        {
            if (img_thisSpace.Image == null)
            {
                Random rnd = new Random();
                int rNumber = rnd.Next(1, 10);
                switch (rNumber)
                {
                    case 1:
                        txt_thisSpace.Text = "STAY AWAY FROM ME!!!";
                        break;
                    case 2:
                        txt_thisSpace.Text = "Don't you there click me... Take that white shit out of here";
                        break;
                    case 3:
                        txt_thisSpace.Text = "Little pussy, little pussy... Come over here";
                        break;
                    case 4:
                        txt_thisSpace.Text = "I'm seeing shit in colors! Owwwww World";
                        break;
                    case 5:
                        txt_thisSpace.Text = "A blank space is not a blank space";
                        break;
                    case 6:
                        txt_thisSpace.Text = "Oh shit! What are you doing with that cursor?";
                        break;
                    case 7:
                        txt_thisSpace.Text = "What da'Hell? This text changes!! *MAGIC*";
                        break;
                    case 8:
                        txt_thisSpace.Text = "*PUFF*";
                        break;
                    case 9:
                        txt_thisSpace.Text = "This is absolute shit (period)";
                        break;
                    case 10:
                        txt_thisSpace.Text = "There are 128 different colors in that cat. I know it because I saw him.";
                        break;
                    default:
                        break;
                }
            }
        }

        private void txt_thisSpace_MouseLeave(object sender, EventArgs e)
        {
            if (img_thisSpace.Image == null)
            {
                txt_thisSpace.Text = "Does this blank space bother you?";
            }
        }

        private void vlink_infMovement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            web_youtubeEmbed.DocumentText = string.Format(this.embedYT, "https://www.youtube.com/embed/uM7JY6Q7O4Q");
        }

        private void vlink_microDAGR_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            web_youtubeEmbed.DocumentText = string.Format(this.embedYT, "https://www.youtube.com/embed/YXNJRgKbokM");
        }

        private void vlink_medicalBasic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            web_youtubeEmbed.DocumentText = string.Format(this.embedYT, "https://www.youtube.com/embed/reEXxeS-o0U");
        }

        private void txtb_searchPack_Enter(object sender, EventArgs e)
        {
            if (txtb_searchPack.Text == "Search")
            {
                txtb_searchPack.ForeColor = Color.FromArgb(64, 64, 64);
                txtb_searchPack.Text = "";
            }
        }

        private void txtb_searchPack_Leave(object sender, EventArgs e)
        {
            if (txtb_searchPack.Text == "")
            {
                txtb_searchPack.ForeColor = Color.DarkGray;
                txtb_searchPack.Text = "Search";
            }
        }

        private void btn_ereaseSearchPack_Click(object sender, EventArgs e)
        {
            fetchAddonPacks.Search("");
            txtb_searchPack.ForeColor = Color.DarkGray;
            txtb_searchPack.Text = "Search";
        }

        private void txtb_searchPack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fetchAddonPacks.Search(txtb_searchPack.Text);
            }
        }

        private void btn_addPrivatePack_Click(object sender, EventArgs e)
        {
            if (new Windows.PrivatePackManager().ShowDialog() == DialogResult.OK)
            {
                fetchAddonPacks.Search("");
                txtb_searchPack.ForeColor = Color.DarkGray;
                txtb_searchPack.Text = "Search";
                fetchAddonPacks.Get();
            }
        }

        private void btn_reloadSteamAddons_Click(object sender, EventArgs e)
        {
            GetAddons();
        }

        /// <summary>
        /// Top Bar Repo Actions
        /// </summary>
        private void btn_opencloseDirPanel_Click(object sender, EventArgs e)
        {
            if (panelDirectories.Height > 90) { topPanelsIO.hidePanelSingle(); btn_opencloseDirPanel.Image = Properties.Resources.chevron_down; }
            else { topPanelsIO.showPanelSingle(); btn_opencloseDirPanel.Image = Properties.Resources.chevron_up; }
        }

        private void btn_repoExpandAll_Click(object sender, EventArgs e)
        {
            if (expandState == 0)
            {
                btn_repoExpandAll.Text = "Collapse All";
                trv_repoContent.ExpandAll();
                expandState = 1;
            }
            else
            {
                btn_repoExpandAll.Text = "Expand All";
                trv_repoContent.CollapseAll();
                expandState = 0;
            }
        }

        private void btn_addonManager_Click(object sender, EventArgs e)
        {
            addonManager.ShowDialog();
        }

        private void btn_checkRepo_Click(object sender, EventArgs e)
        {
            ReadRepo(true);
        }

        private void web_youtubeEmbed_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            web_youtubeEmbed.Document.Body.Style = "overflow:hidden; margin: 0";
            web_loading.Visible = false;
            web_youtubeEmbed.Visible = true;
        }

        private void web_youtubeEmbed_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            web_youtubeEmbed.Visible = false;
            web_loading.Visible = true;
        }

        private void btn_openWorkshop_Click(object sender, EventArgs e)
        {
            Process.Start("https://steamcommunity.com/app/107410/workshop/");
        }

        private void btn_addShortcutDesktop_Click(object sender, EventArgs e)
        {
            object shDesktop = (object)"Desktop";
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Run PTrangers Arma 3 Launcher.lnk";
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "Run PTrangers Arma 3 Launcher";
            shortcut.TargetPath = Application.ExecutablePath;
            shortcut.Save();
        }
    }
}