using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using arma3Launcher.Workers;
using arma3Launcher.Effects;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Xml;
using Microsoft.Win32;
using Microsoft.VisualBasic.Devices;
using MaterialSkin.Controls;
using MaterialSkin;
using arma3Launcher.Controls;

namespace arma3Launcher
{
    public partial class MainForm2 : Form
    {
        private zCheckUpdate QuickUpdateMethod;
        private LaunchCore PrepareLaunch;
        private Packs fetchAddonPacks;
        private AddonsLooker aLooker;
        private Downloader downloader;
        private Installer installer;
        private RemoteReader remoteReader;
        private RepoReader repoReader;
        private WindowIO windowIO;

        private PanelIO sideMenuIO;
        private PanelIO addonPacksPanelIO;
        private PanelIO launchOptionsPanelIO;
        private PanelIO repositoryDownloadsPanelIO;
        private PanelIO preferencesPanelIO;
        private PanelIO addonOptionsPanelIO;
        private PanelIO repoInfoPanelIO;

        private Windows.Splash loadingSplash;

        private Fonts customFont = new Fonts();

        private string packID = string.Empty;
        private List<string> addonsName = new List<string>();
        private bool isOptionalAllowed = false;

        private string armaDir_previousDir = string.Empty;
        private string tsDir_previousDir = string.Empty;
        private string modsDir_previousDir = string.Empty;
        private string optionalDir_previousDir = string.Empty;

        private string GameFolder = string.Empty;
        private string TSFolder = string.Empty;
        private string AddonsFolder = string.Empty;
        private string OptionalAddonsFolder = string.Empty;
        private string documentsA3Profiles = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Arma 3 - Other Profiles";
        private string missionsFolder = string.Empty;

        private string oldVersionStatusText = string.Empty;

        private long memoryMinimum = 256;
        private long memoryMaximum = 256;

        private string TempFolder = Path.GetTempPath() + @"arma3Launcher\";

        private string Arguments = string.Empty;

        private bool isUpdate = false;
        private bool hasShown = false;
        private bool sideMenuOpen = false;

        // Move window stuff
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public MainForm2()
        {
            this.SetStyle(
                System.Windows.Forms.ControlStyles.UserPaint |
                System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
                System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
                true
            );

            // Material Skin Properties
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightGreen800, Primary.LightGreen900, Primary.LightGreen500, Accent.Lime200, TextShade.WHITE);

            // Init Components
            InitializeComponent();

            // Apply fonts to menu items (they're actually labels...)
            this.menu_addonPacks.Font = this.customFont.getFont(Properties.Fonts.BebasNeue_Book, 20F, FontStyle.Regular);
            this.menu_launchOptions.Font = this.customFont.getFont(Properties.Fonts.BebasNeue_Book, 20F, FontStyle.Regular);
            this.menu_repositoryDownloads.Font = this.customFont.getFont(Properties.Fonts.BebasNeue_Book, 20F, FontStyle.Regular);
            this.menu_preferences.Font = this.customFont.getFont(Properties.Fonts.BebasNeue_Book, 20F, FontStyle.Regular);
            this.menu_help.Font = this.customFont.getFont(Properties.Fonts.Lato_Regular, 9.5F, FontStyle.Regular);
            this.menu_about.Font = this.customFont.getFont(Properties.Fonts.Lato_Regular, 9.5F, FontStyle.Regular);

            // Apply fonts to labels
            this.lbl_addonOptions.Font = this.customFont.getFont(Properties.Fonts.BebasNeue_Book, 30F, FontStyle.Regular);
            this.lbl_launchOptions.Font = this.customFont.getFont(Properties.Fonts.BebasNeue_Book, 30F, FontStyle.Regular);
            this.lbl_repositoryDownloads.Font = this.customFont.getFont(Properties.Fonts.BebasNeue_Book, 30F, FontStyle.Regular);
            this.lbl_preferences.Font = this.customFont.getFont(Properties.Fonts.BebasNeue_Book, 30F, FontStyle.Regular);

            this.lbl_pref_Arma3Dir.Font = this.customFont.getFont(Properties.Fonts.ClearSans_Light, 9.75F, FontStyle.Regular);
            this.lbl_pref_AddonsDir.Font = this.customFont.getFont(Properties.Fonts.ClearSans_Light, 9.75F, FontStyle.Regular);
            this.lbl_pref_OptionalDir.Font = this.customFont.getFont(Properties.Fonts.ClearSans_Light, 9.75F, FontStyle.Regular);
            this.lbl_pref_TeamSpeakDir.Font = this.customFont.getFont(Properties.Fonts.ClearSans_Light, 9.75F, FontStyle.Regular);

            // Init workers
            this.QuickUpdateMethod = new zCheckUpdate(txt_versionNumber);

            this.aLooker = new AddonsLooker();
            this.remoteReader = new RemoteReader();
            this.fetchAddonPacks = new Packs(this, flowpanel_addonPacks, cb_serverPack);
            this.installer = new Installer(this, prb_progressBar_File, prb_progressBar_All, txt_progressStatus, txt_percentageStatus, txt_curFile, flowpanel_addonPacks, btn_cancelDownload, txtb_pref_armaDirectory, txtb_pref_tsDirectory, txtb_pref_addonsDirectory, btn_pref_ereaseArmaDir, btn_pref_ereaseTSDir, btn_pref_ereaseAddonsDir, btn_pref_browseA3Dir, btn_pref_browseTS3Dir, btn_pref_browseAddonsDir, btn_reinstallTFRPlugins, btn_checkRepo);
            this.downloader = new Downloader(this, installer, prb_progressBar_File, prb_progressBar_All, txt_curFile, txt_progressStatus, txt_percentageStatus, flowpanel_addonPacks, btn_cancelDownload, btn_checkRepo);
            this.repoReader = new RepoReader(this, flowpanel_addonPacks, trv_repoContent, downloader, installer, lbl_repofileok, lbl_repofileinvalid, lbl_repofilemissing);

            // Init forms
            this.loadingSplash = new Windows.Splash();

            // Init window IO
            this.windowIO = new WindowIO(this);

            // Init panel IO
            this.sideMenuIO = new PanelIO(this.panel_sideMenu, 300, 42);
            this.addonPacksPanelIO = new PanelIO(this.panel_addonPacks, this.panel_outterPanel, this, 161);
            this.launchOptionsPanelIO = new PanelIO(this.panel_launchOptions, this.panel_outterPanel, this, 161);
            this.repositoryDownloadsPanelIO = new PanelIO(this.panel_repositoryDownloads, this.panel_outterPanel, this, 161);
            this.preferencesPanelIO = new PanelIO(this.panel_preferences, this.panel_outterPanel, this, 161);
            this.addonOptionsPanelIO = new PanelIO(this.panel_addonOptions, this, 86);
            this.repoInfoPanelIO = new PanelIO(this.panel_repoInfo, 1240, 86);

            // Position panel IO
            this.repoInfoPanelIO.showPanelSingle();
        }

        private void win_titleBar_MouseDown(object sender, MouseEventArgs e)
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

        private async Task taskDelay(int delayMs)
        {
            await Task.Delay(delayMs);
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
                    if (titleAttribute.Title != string.Empty)
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
                string aux = string.Empty;
                if (Assembly.GetExecutingAssembly().GetName().Version.Build != 0)
                    aux = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Build.ToString() /*+ "." + Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString()*/;
                else
                    aux = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
                return aux;
            }
        }
        #endregion

        #region Tittle Bar Buttons
        // Mouse Hover Buttons
        private void btn_windowMenu_MouseEnter(object sender, EventArgs e)
        {
            if (this.sideMenuOpen) { this.btn_windowMenu.Image = Properties.Resources.windowCrossHover; }
            else { this.btn_windowMenu.Image = Properties.Resources.windowMenuHover; }
        }

        private void btn_windowMinimize_MouseEnter(object sender, EventArgs e)
        {
            this.btn_windowMinimize.Image = Properties.Resources.windowToTaskbarHover;
        }

        private void btn_windowClose_MouseEnter(object sender, EventArgs e)
        {
            this.btn_windowClose.Image = Properties.Resources.windowCloseHover;
        }

        // Mouse Leave Buttons
        private void btn_windowMenu_MouseLeave(object sender, EventArgs e)
        {
            if (this.sideMenuOpen) { this.btn_windowMenu.Image = Properties.Resources.windowCross; }
            else { this.btn_windowMenu.Image = Properties.Resources.windowMenu; }
        }

        private void btn_windowMinimize_MouseLeave(object sender, EventArgs e)
        {
            this.btn_windowMinimize.Image = Properties.Resources.windowToTaskbar;
        }

        private void btn_windowClose_MouseLeave(object sender, EventArgs e)
        {
            this.btn_windowClose.Image = Properties.Resources.windowClose;
        }

        // Button Action
        private void btn_windowMenu_Click(object sender, EventArgs e)
        {
            if (this.panel_sideMenu.Width < 300)
            {
                this.btn_windowMenu.Image = Properties.Resources.windowCross;
                this.sideMenuIO.showPanelSingle();
                this.sideMenuOpen = true;
            }
            else
            {
                this.btn_windowMenu.Image = Properties.Resources.windowMenu;
                this.sideMenuIO.hidePanelSingle();
                this.sideMenuOpen = false;
            }
        }

        private void btn_windowMinimize_Click(object sender, EventArgs e)
        {
            this.minimizeWindow();
        }
        public void minimizeWindow()
        {
            this.windowIO.windowOut(false);
        }

        private void btn_windowClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region MainForm Events
        private void MainForm2_Shown(object sender, EventArgs e)
        {
            windowIO.windowIn();

            flowpanel_addonPacks.Focus();

            if (!isUpdate)
            {
                fetchAddonPacks.RevealPacks(flowpanel_addonPacks);
                ReadRepo(false, false);
            }

            this.hasShown = true;
        }

        private void MainForm2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (GlobalVar.isDownloading)
                {
                    if (new Windows.MessageBox().Show("Are you sure you want to stop the download?", "Stop download progress?", MessageBoxButtons.YesNo, MessageIcon.Question) == DialogResult.No)
                        e.Cancel = true;
                }
                else if (GlobalVar.isInstalling)
                {
                    if (new Windows.MessageBox().Show("The launcher is installing the addons. Do you want to cancel the process and leave?", "Installing addons", MessageBoxButtons.YesNo, MessageIcon.Warning) == DialogResult.No)
                        e.Cancel = true;
                }
                else
                {
                    SaveSettings();
                    GC.Collect(2, GCCollectionMode.Forced);
                    windowIO.windowOut(true);
                    e.Cancel = true;
                }
            }
        }

        private void MainForm2_Resize(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
                windowIO.windowIn();
        }

        private void MainForm2_Load(object sender, EventArgs e)
        {
            loadingSplash.Show();

            this.Location = new Point((Screen.FromControl(this).WorkingArea.Width - this.Width) / 2,
                          (Screen.FromControl(this).WorkingArea.Height - this.Height) / 2);

            if (GlobalVar.isServer) { this.Text = WindowTitle.Text = AssemblyTitle + " | Server Edition"; }
            else { this.Text = WindowTitle.Text = AssemblyTitle; }
            txt_versionNumber.Text = "version " + AssemblyVersion;

            if (!remoteReader.isLauncherLocked() || GlobalVar.isDebug)
            {
                // Change stuff if isServer
                if (GlobalVar.isServer)
                {
                    chb_pref_serverMode.Checked = true;
                    panel_serverOptions.Visible = true;
                    panel_headlessOptions.Visible = true;
                    panel_serverOptions_vSep.Visible = true;
                    panel_serverOptions_hSep.Visible = true;
                    tsmi_manageRepository.Visible = true;

                    btn_addonsOptionsOpen.Visible = false;
                    chb_pref_joinServer.Visible = false;
                    chb_pref_joinTSServer.Visible = false;
                    chb_pref_serverAutopilot.Visible = true;
                    chb_battleye.Enabled = false;

                    chb_pref_startGame.Text = "Start server when ready";

                    cb_clientProfile.Enabled = false;
                    lbl_clientProfile.Enabled = false;

                    int _idx = 0;
                    foreach (Panel panel in flowpanel_preferencesDirectories.Controls)
                    {
                        if(panel.Name == panel_TeamSpeakDir.Name)
                        {
                            if (_idx > 0) flowpanel_preferencesDirectories.Controls[_idx - 1].Visible = false;
                            panel.Visible = false;
                        }

                        _idx++;
                    }

                    if (!Properties.Settings.Default.firstLaunch)
                        if (new Windows.DelayServerStart().ShowDialog() == DialogResult.OK)
                            switchAutopilot(true);
                        else
                            switchAutopilot(false);

                }

                if (!GlobalVar.autoPilot && !QuickUpdateMethod.QuickCheck())
                {
                    QuickUpdateMethod.StartUpdate();
                    isUpdate = true;
                }
                else if (Properties.Settings.Default.firstLaunch)
                {
                    if (GlobalVar.isServer) { chb_pref_startGame.Checked = true; }

                    GlobalVar.menuSelected = 3;
                    HideUnhide(GlobalVar.menuSelected);
                }
                else if (Properties.Settings.Default.Arma3Folder.Equals(string.Empty) ||
                    Properties.Settings.Default.AddonsFolder.Equals(string.Empty) ||
                    Properties.Settings.Default.TS3Folder.Equals(string.Empty) ||
                    !Directory.Exists(Properties.Settings.Default.Arma3Folder) ||
                    !Directory.Exists(Properties.Settings.Default.AddonsFolder) ||
                    !Directory.Exists(Properties.Settings.Default.TS3Folder))
                {
                    GlobalVar.menuSelected = 3;
                    HideUnhide(GlobalVar.menuSelected);
                }
                else
                {
                    GlobalVar.menuSelected = 0;
                    HideUnhide(GlobalVar.menuSelected);
                }

                if (!isUpdate)
                {
                    updateCurrentPack(true, false);

                    if (Directory.Exists(AddonsFolder + @"@task_force_radio\plugins"))
                        btn_reinstallTFRPlugins.Enabled = true;
                    else
                        btn_reinstallTFRPlugins.Enabled = false;
                }

                this.GetMalloc();
                this.MachineSettings();
                this.LoadSettings();
            }
            else
            {
                new Windows.MessageBox().Show("To prevent the loss of data the launcher has been locked.\n\nOnce all the needed maintenance is done it'll be unlocked.\n\nPlease try again later.", "Launcher locked!", MessageBoxButtons.OK, MessageIcon.Warning);
                Process.GetCurrentProcess().Kill();
            }

            loadingSplash.Close();
        } 
        #endregion

        #region Side Menu
        /*-----------------------------------
            Hide/Unhide
        -----------------------------------*/
        public async void HideUnhide(int selectedOption)
        {
            if (!GlobalVar.isAnimating)
            {
                this.btn_windowMenu.Image = Properties.Resources.windowMenu;
                this.sideMenuIO.hidePanelSingle();
                this.sideMenuOpen = false;

                if (panel_addonPacks.Width > 0) {           panel_outterPanel.BackColor = Color.DimGray;    menu_addonPacks.ForeColor = Color.WhiteSmoke;           panel_outterPanel.Dock = DockStyle.Left;   panel_addonPacks.Dock = DockStyle.Left;            addonPacksPanelIO.hidePanelDual(); }
                if (panel_launchOptions.Width > 0) {        panel_outterPanel.BackColor = Color.DimGray;    menu_launchOptions.ForeColor = Color.WhiteSmoke;        panel_outterPanel.Dock = DockStyle.Left;   panel_launchOptions.Dock = DockStyle.Left;         launchOptionsPanelIO.hidePanelDual(); }
                if (panel_repositoryDownloads.Width > 0) {  panel_outterPanel.BackColor = Color.DimGray;    menu_repositoryDownloads.ForeColor = Color.WhiteSmoke;  panel_outterPanel.Dock = DockStyle.Left;   panel_repositoryDownloads.Dock = DockStyle.Left;   repositoryDownloadsPanelIO.hidePanelDual(); }
                if (panel_preferences.Width > 0) {          panel_outterPanel.BackColor = Color.DimGray;    menu_preferences.ForeColor = Color.WhiteSmoke;          panel_outterPanel.Dock = DockStyle.Left;   panel_preferences.Dock = DockStyle.Left;           preferencesPanelIO.hidePanelDual(); }

                while (GlobalVar.isAnimating)
                    await taskDelay(400);

                if (selectedOption == 0) { panel_outterPanel.BackColor = Color.OliveDrab;   menu_addonPacks.ForeColor = Color.YellowGreen;              panel_outterPanel.Dock = DockStyle.Right;   panel_addonPacks.Dock = DockStyle.Right;            addonPacksPanelIO.showPanelDual(); }
                if (selectedOption == 1) { panel_outterPanel.BackColor = Color.OliveDrab;   menu_launchOptions.ForeColor = Color.YellowGreen;           panel_outterPanel.Dock = DockStyle.Right;   panel_launchOptions.Dock = DockStyle.Right;         launchOptionsPanelIO.showPanelDual(); }
                if (selectedOption == 2) { panel_outterPanel.BackColor = Color.OliveDrab;   menu_repositoryDownloads.ForeColor = Color.YellowGreen;     panel_outterPanel.Dock = DockStyle.Right;   panel_repositoryDownloads.Dock = DockStyle.Right;   repositoryDownloadsPanelIO.showPanelDual(); }
                if (selectedOption == 3) { panel_outterPanel.BackColor = Color.OliveDrab;   menu_preferences.ForeColor = Color.YellowGreen;             panel_outterPanel.Dock = DockStyle.Right;   panel_preferences.Dock = DockStyle.Right;           preferencesPanelIO.showPanelDual(); }
            }
        }

        /*-----------------------------------
            Menu Addon Packs
        -----------------------------------*/
        private void menu_addonPacks_Click(object sender, EventArgs e)
        {
            if (GlobalVar.menuSelected != 0 && !GlobalVar.isAnimating)
            {
                GlobalVar.menuSelected = 0;
                this.HideUnhide(GlobalVar.menuSelected);
            }
        }

        private void menu_addonPacks_MouseEnter(object sender, EventArgs e)
        {
            this.menu_addonPacks.ForeColor = Color.OliveDrab;
        }

        private void menu_addonPacks_MouseLeave(object sender, EventArgs e)
        {
            if (GlobalVar.menuSelected != 0)
                this.menu_addonPacks.ForeColor = Color.WhiteSmoke;
            else
                this.menu_addonPacks.ForeColor = Color.YellowGreen;
        }

        /*-----------------------------------
            Menu Launch Options
        -----------------------------------*/
        private void menu_launchOptions_Click(object sender, EventArgs e)
        {
            if (GlobalVar.menuSelected != 1 && !GlobalVar.isAnimating)
            {
                GlobalVar.menuSelected = 1;
                this.HideUnhide(GlobalVar.menuSelected);
            }
        }

        private void menu_launchOptions_MouseEnter(object sender, EventArgs e)
        {
            this.menu_launchOptions.ForeColor = Color.OliveDrab;
        }

        private void menu_launchOptions_MouseLeave(object sender, EventArgs e)
        {
            if (GlobalVar.menuSelected != 1)
                this.menu_launchOptions.ForeColor = Color.WhiteSmoke;
            else
                this.menu_launchOptions.ForeColor = Color.YellowGreen;
        }

        /*-----------------------------------
            Menu Repository Downloads
        -----------------------------------*/
        private void menu_repositoryDownloads_Click(object sender, EventArgs e)
        {
            if (GlobalVar.menuSelected != 2 && !GlobalVar.isAnimating)
            {
                GlobalVar.menuSelected = 2;
                this.HideUnhide(GlobalVar.menuSelected);
            }
        }

        private void menu_repositoryDownloads_MouseEnter(object sender, EventArgs e)
        {
            this.menu_repositoryDownloads.ForeColor = Color.OliveDrab;
        }

        private void menu_repositoryDownloads_MouseLeave(object sender, EventArgs e)
        {
            if (GlobalVar.menuSelected != 2)
                this.menu_repositoryDownloads.ForeColor = Color.WhiteSmoke;
            else
                this.menu_repositoryDownloads.ForeColor = Color.YellowGreen;
        }

        /*-----------------------------------
            Menu Preferences
        -----------------------------------*/
        private void menu_preferences_Click(object sender, EventArgs e)
        {
            if (GlobalVar.menuSelected != 3 && !GlobalVar.isAnimating)
            {
                GlobalVar.menuSelected = 3;
                this.HideUnhide(GlobalVar.menuSelected);
            }
        }

        private void menu_preferences_MouseEnter(object sender, EventArgs e)
        {
            this.menu_preferences.ForeColor = Color.OliveDrab;
        }

        private void menu_preferences_MouseLeave(object sender, EventArgs e)
        {
            if (GlobalVar.menuSelected != 3)
                this.menu_preferences.ForeColor = Color.WhiteSmoke;
            else
                this.menu_preferences.ForeColor = Color.YellowGreen;
        }

        /*-----------------------------------
            Menu Help
        -----------------------------------*/
        private void menu_help_Click(object sender, EventArgs e)
        {
            new Windows.Help().ShowDialog();
        }

        private void menu_help_MouseEnter(object sender, EventArgs e)
        {
            this.menu_help.ForeColor = Color.OliveDrab;
        }

        private void menu_help_MouseLeave(object sender, EventArgs e)
        {
            this.menu_help.ForeColor = Color.Silver;
        }

        /*-----------------------------------
            Menu About
        -----------------------------------*/
        private void menu_about_Click(object sender, EventArgs e)
        {
            new Windows.About(AssemblyTitle, AssemblyVersion).ShowDialog();
        }

        private void menu_about_MouseEnter(object sender, EventArgs e)
        {
            this.menu_about.ForeColor = Color.OliveDrab;
        }

        private void menu_about_MouseLeave(object sender, EventArgs e)
        {
            this.menu_about.ForeColor = Color.Silver;
        }
        #endregion

        #region Button States
        private void btn_pref_ereaseArmaDir_MouseEnter(object sender, EventArgs e)
        {
            btn_pref_ereaseArmaDir.Image = Properties.Resources.erase_hover;
        }

        private void btn_pref_ereaseArmaDir_MouseLeave(object sender, EventArgs e)
        {
            btn_pref_ereaseArmaDir.Image = Properties.Resources.erase_idle;
        }

        private void btn_pref_ereaseAddonsDir_MouseEnter(object sender, EventArgs e)
        {
            btn_pref_ereaseAddonsDir.Image = Properties.Resources.erase_hover;
        }

        private void btn_pref_ereaseAddonsDir_MouseLeave(object sender, EventArgs e)
        {
            btn_pref_ereaseAddonsDir.Image = Properties.Resources.erase_idle;
        }

        private void btn_pref_ereaseTSDir_MouseEnter(object sender, EventArgs e)
        {
            btn_pref_ereaseTSDir.Image = Properties.Resources.erase_hover;
        }

        private void btn_pref_ereaseTSDir_MouseLeave(object sender, EventArgs e)
        {
            btn_pref_ereaseTSDir.Image = Properties.Resources.erase_idle;
        }

        private void btn_pref_browseA3Dir_MouseEnter(object sender, EventArgs e)
        {
            btn_pref_browseA3Dir.Image = Properties.Resources.addfolder_hover;
        }

        private void btn_pref_browseA3Dir_MouseLeave(object sender, EventArgs e)
        {
            btn_pref_browseA3Dir.Image = Properties.Resources.addfolder_idle;
        }

        private void btn_pref_openA3Dir_MouseEnter(object sender, EventArgs e)
        {
            btn_pref_openA3Dir.Image = Properties.Resources.openfolder_hover;
        }

        private void btn_pref_openA3Dir_MouseLeave(object sender, EventArgs e)
        {
            btn_pref_openA3Dir.Image = Properties.Resources.openfolder_idle;
        }

        private void btn_pref_browseAddonsDir_MouseEnter(object sender, EventArgs e)
        {
            btn_pref_browseAddonsDir.Image = Properties.Resources.addfolder_hover;
        }

        private void btn_pref_browseAddonsDir_MouseLeave(object sender, EventArgs e)
        {
            btn_pref_browseAddonsDir.Image = Properties.Resources.addfolder_idle;
        }

        private void btn_pref_openAddonsDir_MouseEnter(object sender, EventArgs e)
        {
            btn_pref_openAddonsDir.Image = Properties.Resources.openfolder_hover;
        }

        private void btn_pref_openAddonsDir_MouseLeave(object sender, EventArgs e)
        {
            btn_pref_openAddonsDir.Image = Properties.Resources.openfolder_idle;
        }

        private void btn_pref_browseTS3Dir_MouseEnter(object sender, EventArgs e)
        {
            btn_pref_browseTS3Dir.Image = Properties.Resources.addfolder_hover;
        }

        private void btn_pref_browseTS3Dir_MouseLeave(object sender, EventArgs e)
        {
            btn_pref_browseTS3Dir.Image = Properties.Resources.addfolder_idle;
        }

        private void btn_pref_openTS3Dir_MouseEnter(object sender, EventArgs e)
        {
            btn_pref_openTS3Dir.Image = Properties.Resources.openfolder_hover;
        }

        private void btn_pref_openTS3Dir_MouseLeave(object sender, EventArgs e)
        {
            btn_pref_openTS3Dir.Image = Properties.Resources.openfolder_idle;
        }

        private void btn_pref_ereaseOptionalDir_MouseEnter(object sender, EventArgs e)
        {
            btn_pref_ereaseOptionalDir.Image = Properties.Resources.erase_hover;
        }

        private void btn_pref_ereaseOptionalDir_MouseLeave(object sender, EventArgs e)
        {
            btn_pref_ereaseOptionalDir.Image = Properties.Resources.erase_idle;
        }

        private void btn_pref_browseOptionalDir_MouseEnter(object sender, EventArgs e)
        {
            btn_pref_browseOptionalDir.Image = Properties.Resources.addfolder_hover;
        }

        private void btn_pref_browseOptionalDir_MouseLeave(object sender, EventArgs e)
        {
            btn_pref_browseOptionalDir.Image = Properties.Resources.addfolder_idle;
        }

        private void btn_pref_openOptionalDir_MouseEnter(object sender, EventArgs e)
        {
            btn_pref_openOptionalDir.Image = Properties.Resources.openfolder_hover;
        }

        private void btn_pref_openOptionalDir_MouseLeave(object sender, EventArgs e)
        {
            btn_pref_openOptionalDir.Image = Properties.Resources.openfolder_idle;
        }
        #endregion

        #region Addon Packs Panel
        private void btn_addonsOptionsOpen_Click(object sender, EventArgs e)
        {
            this.addonOptionsPanelIO.showPanelSingle();
        }

        private void btn_addonsOptionsOpen_MouseEnter(object sender, EventArgs e)
        {
            this.btn_addonsOptionsOpen.ForeColor = Color.Silver;
            this.btn_addonsOptionsOpen.BackColor = Color.FromArgb(55, 55, 55);
        }

        private void btn_addonsOptionsOpen_MouseLeave(object sender, EventArgs e)
        {
            this.btn_addonsOptionsOpen.ForeColor = Color.WhiteSmoke;
            this.btn_addonsOptionsOpen.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void btn_addonsOptionsClose_Click(object sender, EventArgs e)
        {
            this.addonOptionsPanelIO.hidePanelSingle();
        }

        private void btn_addonsOptionsClose_MouseEnter(object sender, EventArgs e)
        {
            this.btn_addonsOptionsClose.ForeColor = Color.Silver;
            this.btn_addonsOptionsClose.BackColor = Color.FromArgb(55, 55, 55);
        }

        private void btn_addonsOptionsClose_MouseLeave(object sender, EventArgs e)
        {
            this.btn_addonsOptionsClose.ForeColor = Color.WhiteSmoke;
            this.btn_addonsOptionsClose.BackColor = Color.FromArgb(45, 45, 45);
        }
        #endregion

        private void GetWorkshopAddons()
        {
            this.aLooker.getAddonsFlowPanel(flowpanel_steamworkshopAddonsList, Properties.Settings.Default.Arma3Folder + "!Workshop\\", steamworkshopMenu);
            this.PropertiesWorkshopReader();
        }

        private void GetOptionalAddons()
        {
            this.aLooker.getAddonsFlowPanel(flowpanel_optionalAddons, Properties.Settings.Default.OptionalAddonsFolder, optionaladdonsMenu);
            this.PropertiesOptionalAddonsReader();
        }

        private void ServerSettings()
        {
            cb_serverConfig.Items.Clear();
            cb_serverProfile.Items.Clear();
            cb_serverMission.Items.Clear();
            cb_hcProfile.Items.Clear();

            // get server config
            cb_serverConfig.Items.Add("Default");
            try
            {
                foreach (var item in Directory.GetFiles(Properties.Settings.Default.Arma3Folder, "*.cfg", SearchOption.TopDirectoryOnly))
                {
                    cb_serverConfig.Items.Add(item.Remove(0, Properties.Settings.Default.Arma3Folder.Length));
                }
            }
            catch { }

            // get server profiles
            cb_serverProfile.Items.Add("Default");
            if (Directory.Exists(this.documentsA3Profiles))
            {
                foreach (var item in Directory.GetDirectories(this.documentsA3Profiles, "*", SearchOption.TopDirectoryOnly))
                {
                    cb_serverProfile.Items.Add(item.Remove(0, this.documentsA3Profiles.Length + 1));
                }
            }

            // get mission files
            cb_serverMission.Items.Add("Default");
            if (Directory.Exists(this.missionsFolder))
            {
                foreach (var item in Directory.GetFiles(this.missionsFolder, "*.pbo", SearchOption.TopDirectoryOnly))
                {
                    cb_serverMission.Items.Add(item.Remove(0, this.missionsFolder.Length + 1));
                }
            }

            // get hc profiles
            cb_hcProfile.Items.Add("Default");
            if (Directory.Exists(this.documentsA3Profiles))
            {
                foreach (var item in Directory.GetDirectories(this.documentsA3Profiles, "*", SearchOption.TopDirectoryOnly))
                {
                    cb_hcProfile.Items.Add(item.Remove(0, this.documentsA3Profiles.Length + 1));
                }
            }
        }

        private void ClientSettings()
        {
            cb_clientProfile.Items.Clear();

            cb_clientProfile.Items.Add("Default");
            if (Directory.Exists(this.documentsA3Profiles))
            {
                foreach (var item in Directory.GetDirectories(this.documentsA3Profiles, "*", SearchOption.TopDirectoryOnly))
                {
                    cb_clientProfile.Items.Add(item.Remove(0, this.documentsA3Profiles.Length + 1));
                }
            }
        }

        private void MachineSettings()
        {
            cb_cpuCount.Items.Clear();
            cb_exThreads.Items.Clear();

            // get logical processors
            for (int i = 1; i <= Environment.ProcessorCount; i++)
            {
                cb_cpuCount.Items.Add(i);
            }

            // set default exthreads
            int[] exThreads = new int[] { 0, 1, 3 };
            foreach (int item in exThreads)
            {
                cb_exThreads.Items.Add(item);
            }

            // get cpu core number
            int coreCount = 0;
            foreach (var item in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                coreCount += int.Parse(item["NumberOfCores"].ToString());
            }

            // set extra exthreads if cpu cores more than 2
            if (coreCount > 2)
            {
                int[] exThreadsPlus = new int[] { 5, 7 };
                foreach (int item in exThreadsPlus)
                {
                    cb_exThreads.Items.Add(item);
                }
            }

            // get machine memory
            long machineMemory = (Convert.ToInt64(new ComputerInfo().TotalPhysicalMemory) / 1024) / 1024;
            memoryMaximum = machineMemory;
        }

        private void PropertiesOptionalAddonsReader()
        {
            foreach (var waddon in Properties.Settings.Default.optionalAddons.Split(';'))
            {
                try
                {
                    foreach (MaterialCheckBox item in flowpanel_optionalAddons.Controls)
                    {
                        if (item.Text == waddon)
                        { item.Checked = true; break; }
                    }
                }
                catch { }
            }
        }

        private void PropertiesOptionalAddonsSaver()
        {
            try
            {
                string auxOptionalAddons = string.Empty;
                foreach (MaterialCheckBox item in flowpanel_optionalAddons.Controls)
                {
                    if (item.Checked)
                    {
                        if (auxOptionalAddons != string.Empty) auxOptionalAddons += ";" + item.Text;
                        else auxOptionalAddons = item.Text;
                    }
                }
                Properties.Settings.Default.optionalAddons = auxOptionalAddons;
                Properties.Settings.Default.Save();
            }
            catch { }
        }

        private void PropertiesWorkshopReader()
        {
            foreach (var waddon in Properties.Settings.Default.workshopAddons.Split(';'))
            {
                try
                {
                    foreach (MaterialCheckBox item in flowpanel_steamworkshopAddonsList.Controls)
                    {
                        if (item.Text == waddon)
                        { item.Checked = true; break; }
                    }
                }
                catch { }
            }
        }

        private void PropertiesWorkshopSaver()
        {
            try
            {
                string auxWorkshopAddons = string.Empty;
                foreach (MaterialCheckBox item in flowpanel_steamworkshopAddonsList.Controls)
                {
                    if (item.Checked)
                    {
                        if (auxWorkshopAddons != string.Empty) auxWorkshopAddons += ";" + item.Text;
                        else auxWorkshopAddons = item.Text;
                    }
                }
                Properties.Settings.Default.workshopAddons = auxWorkshopAddons;
                Properties.Settings.Default.Save();
            }
            catch { }
        }

        private void LoadSettings()
        {
            // directories
            if (Properties.Settings.Default.Arma3Folder != string.Empty)
            { txtb_pref_armaDirectory.ForeColor = Color.FromArgb(64, 64, 64); GameFolder = txtb_pref_armaDirectory.Text = Properties.Settings.Default.Arma3Folder; missionsFolder = Properties.Settings.Default.Arma3Folder + "mpmissions"; }
            else
            { txtb_pref_armaDirectory.ForeColor = Color.DarkGray; txtb_pref_armaDirectory.Text = "Set directory ->"; }

            if (Properties.Settings.Default.TS3Folder != string.Empty)
            { txtb_pref_tsDirectory.ForeColor = Color.FromArgb(64, 64, 64); TSFolder = txtb_pref_tsDirectory.Text = Properties.Settings.Default.TS3Folder; }
            else
            { txtb_pref_tsDirectory.ForeColor = Color.DarkGray; txtb_pref_tsDirectory.Text = "Set directory ->"; }

            if (Properties.Settings.Default.AddonsFolder != string.Empty)
            { txtb_pref_addonsDirectory.ForeColor = Color.FromArgb(64, 64, 64); AddonsFolder = txtb_pref_addonsDirectory.Text = Properties.Settings.Default.AddonsFolder; }
            else
            { txtb_pref_addonsDirectory.ForeColor = Color.DarkGray; txtb_pref_addonsDirectory.Text = "Set directory ->"; }

            if (Properties.Settings.Default.OptionalAddonsFolder != string.Empty)
            { txtb_pref_optionalDirectory.ForeColor = Color.FromArgb(64, 64, 64); OptionalAddonsFolder = txtb_pref_optionalDirectory.Text = Properties.Settings.Default.OptionalAddonsFolder; }
            else
            { txtb_pref_optionalDirectory.ForeColor = Color.DarkGray; txtb_pref_optionalDirectory.Text = "Set directory ->"; }

            if (GlobalVar.isServer)
                this.ServerSettings();
            else
                this.ClientSettings();

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
            if (Properties.Settings.Default.maxMem_value >= memoryMinimum && Properties.Settings.Default.maxMem_value <= memoryMaximum) { num_maxMem.Text = Properties.Settings.Default.maxMem_value.ToString(); }
            else { chb_maxMem.Checked = false; num_maxMem.Text = memoryMinimum.ToString(); }

            chb_malloc.Checked = Properties.Settings.Default.malloc;
            try
            {
                if (File.Exists(Properties.Settings.Default.Arma3Folder + "Dll\\" + Properties.Settings.Default.malloc_value + ".dll")) { cb_malloc.SelectedItem = Properties.Settings.Default.malloc_value; }
                else { chb_malloc.Checked = false; cb_malloc.SelectedItem = null; }
            }
            catch
            {
                chb_malloc.Checked = false; cb_malloc.SelectedItem = null;
            }

            chb_exThreads.Checked = Properties.Settings.Default.exThreads;
            cb_exThreads.SelectedItem = Properties.Settings.Default.exThreads_value;
            if (cb_exThreads.SelectedItem == null) { chb_exThreads.Checked = false; cb_exThreads.SelectedIndex = 0; }

            chb_cpuCount.Checked = Properties.Settings.Default.cpuCount;
            cb_cpuCount.SelectedItem = Properties.Settings.Default.cpuCount_value;
            if (cb_cpuCount.SelectedItem == null) { chb_cpuCount.Checked = false; cb_cpuCount.SelectedIndex = 0; }

            // game artifact
            chb_battleye.Checked = Properties.Settings.Default.battleye;
            if (Environment.Is64BitOperatingSystem)
            {
                chb_use64Bit.Checked = Properties.Settings.Default.x64Game;
                chb_use64Bit.Visible = true;
            }
            else
            {
                chb_use64Bit.Checked = false;
                Properties.Settings.Default.x64Game = false;
            }

            // preferences
            chb_pref_startGame.Checked = Properties.Settings.Default.startGameAfterDownload;
            chb_pref_allowNotifications.Checked = Properties.Settings.Default.allowNotifications;
            chb_pref_autoDownload.Checked = Properties.Settings.Default.autoDownload;
            chb_pref_joinServer.Checked = Properties.Settings.Default.joinServerAutomatically;
            chb_pref_joinTSServer.Checked = Properties.Settings.Default.joinTsServerAutomatically;
            chb_pref_disableAnimations.Checked = Properties.Settings.Default.DisableAnimations;

            // preference run on startup
            chb_pref_runLauncherStartup.Checked = false;
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            foreach (string key in rk.GetValueNames())
            {
                if (key == AssemblyTitle)
                {
                    chb_pref_runLauncherStartup.Checked = true;
                    if (rk.GetValue(AssemblyTitle).ToString() != Application.ExecutablePath)
                        rk.SetValue(AssemblyTitle, Application.ExecutablePath);
                }
            }

            // workshop addons
            this.PropertiesWorkshopReader();

            // optional addons
            this.PropertiesOptionalAddonsReader();

            // server-client specific settings
            if (GlobalVar.isServer)
            {
                // Server
                try
                {
                    if (Properties.Settings.Default.ServerConfig != string.Empty && File.Exists(Properties.Settings.Default.Arma3Folder + Properties.Settings.Default.ServerConfig))
                        cb_serverConfig.SelectedItem = Properties.Settings.Default.ServerConfig;
                    else
                        cb_serverConfig.SelectedIndex = 0;
                }
                catch
                {
                    cb_serverConfig.SelectedIndex = 0;
                }

                if (Properties.Settings.Default.ServerProfile != string.Empty && Directory.Exists(this.documentsA3Profiles + "\\" + Properties.Settings.Default.ServerProfile))
                    cb_serverProfile.SelectedItem = Properties.Settings.Default.ServerProfile;
                else
                    cb_serverProfile.SelectedIndex = 0;

                if (Properties.Settings.Default.ServerPack != string.Empty)
                    cb_serverPack.SelectedItem = Properties.Settings.Default.ServerPack;
                else
                    cb_serverPack.SelectedIndex = 0;
                if(cb_serverPack.SelectedItem == null)
                    cb_serverPack.SelectedIndex = 0;

                if (Properties.Settings.Default.ServerMission != string.Empty && File.Exists(this.missionsFolder + "\\" + Properties.Settings.Default.ServerMission))
                    cb_serverMission.SelectedItem = Properties.Settings.Default.ServerMission;
                else
                    cb_serverMission.SelectedIndex = 0;

                // HC
                if (Properties.Settings.Default.HCProfile != string.Empty && Directory.Exists(this.documentsA3Profiles + "\\" + Properties.Settings.Default.HCProfile))
                    cb_hcProfile.SelectedItem = Properties.Settings.Default.HCProfile;
                else
                    cb_hcProfile.SelectedIndex = 0;

                num_hcInstances.Text = Properties.Settings.Default.HCInstances.ToString();
            }
            else
            {
                if (Properties.Settings.Default.ClientProfile != string.Empty && Directory.Exists(this.documentsA3Profiles + "\\" + Properties.Settings.Default.ClientProfile))
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
            Properties.Settings.Default.maxMem_value = (int)Convert.ToInt32(num_maxMem.Text);

            Properties.Settings.Default.malloc = chb_malloc.Checked;
            Properties.Settings.Default.malloc_value = (string)cb_malloc.SelectedItem;

            Properties.Settings.Default.exThreads = chb_exThreads.Checked;
            Properties.Settings.Default.exThreads_value = (int)cb_exThreads.SelectedItem;

            Properties.Settings.Default.cpuCount = chb_cpuCount.Checked;
            Properties.Settings.Default.cpuCount_value = (int)cb_cpuCount.SelectedItem;

            Properties.Settings.Default.x64Game = chb_use64Bit.Checked;

            // preferences
            Properties.Settings.Default.startGameAfterDownload = chb_pref_startGame.Checked;
            Properties.Settings.Default.allowNotifications = chb_pref_allowNotifications.Checked;
            Properties.Settings.Default.autoDownload = chb_pref_autoDownload.Checked;
            Properties.Settings.Default.joinServerAutomatically = chb_pref_joinServer.Checked;
            Properties.Settings.Default.joinTsServerAutomatically = chb_pref_joinTSServer.Checked;
            Properties.Settings.Default.DisableAnimations = chb_pref_disableAnimations.Checked;

            // workshop addons
            this.PropertiesWorkshopSaver();

            // optional addons
            this.PropertiesOptionalAddonsSaver();

            // server-client specific settings
            if (GlobalVar.isServer)
            {
                // Server
                Properties.Settings.Default.ServerConfig = (string)cb_serverConfig.SelectedItem;
                Properties.Settings.Default.ServerProfile = (string)cb_serverProfile.SelectedItem;
                Properties.Settings.Default.ServerPack = (string)cb_serverPack.SelectedItem;
                Properties.Settings.Default.ServerMission = (string)cb_serverMission.SelectedItem;

                // HC
                Properties.Settings.Default.HCProfile = (string)cb_hcProfile.SelectedItem;
                Properties.Settings.Default.HCInstances = (int)Convert.ToInt32(num_hcInstances.Text);
            }
            else
            {
                Properties.Settings.Default.ClientProfile = (string)cb_clientProfile.SelectedItem;
            }

            Properties.Settings.Default.Save();
        }

        public void FetchRemoteSettings(bool refreshPacks, bool isAutoRun)
        {
            AddonsFolder = Properties.Settings.Default.AddonsFolder;
            bool keepGoing = true;

            do
            {
                try
                {
                    if (isAutoRun)
                        packID = (string)cb_serverPack.SelectedItem;
                    else
                        packID = Properties.Settings.Default.lastAddonPack;

                    XmlDocument RemoteXmlInfo = new XmlDocument();
                    RemoteXmlInfo.Load(Properties.GlobalValues.S_VersionXML);

                    addonsName.Clear();
                    if (packID != "arma3")
                    {
                        XmlNodeList addonsList = RemoteXmlInfo.SelectNodes("//arma3Launcher//ModSetInfo//" + packID + "//mod");
                        foreach (XmlNode addon in addonsList)
                        {
                            addonsName.Add(addon.Attributes["name"].Value);
                        }
                    }

                    isOptionalAllowed = Convert.ToBoolean(RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + packID).Attributes["optional"].Value);
                }
                catch (Exception ex)
                {
                    keepGoing = false;

                    MessageBoxButtons msgOptions = MessageBoxButtons.RetryCancel;
                    if (GlobalVar.isDebug)
                        msgOptions = MessageBoxButtons.AbortRetryIgnore;

                    switch (new Windows.MessageBox().Show(ex.Message, "Unable to fetch remote settings", msgOptions, MessageIcon.Warning))
                    {
                        case DialogResult.Abort:
                            Process.GetCurrentProcess().Kill();
                            break;
                        case DialogResult.Cancel:
                            Process.GetCurrentProcess().Kill();
                            break;
                        case DialogResult.Retry:
                            break;
                        case DialogResult.Ignore:
                            setOfflineMode();
                            keepGoing = true;
                            break;
                        default:
                            break;
                    }
                }
                finally
                {
                    if (refreshPacks)
                        fetchAddonPacks.Get();
                }
            } while (!keepGoing);
        }

        private void setOfflineMode()
        {
            GlobalVar.offlineMode = true;
            WindowTitle.Text = WindowTitle.Text + " | Offline Mode";
        }

        private void GetMalloc()
        {
            cb_malloc.Items.Clear();

            try
            {
                string[] fileEntries = Directory.GetFiles(Properties.Settings.Default.Arma3Folder + "Dll\\", "*.dll", SearchOption.TopDirectoryOnly);
                foreach (string fileName in fileEntries)
                {
                    cb_malloc.Items.Add(Path.GetFileName(fileName).Remove(Path.GetFileName(fileName).Length - 4));
                }
            }
            catch
            { }
        }

        private void switchAutopilot(bool On)
        {
            if (On && !GlobalVar.autoPilot)
            { GlobalVar.autoPilot = true; oldVersionStatusText = WindowTitle.Text; WindowTitle.Text = WindowTitle.Text + " | Autopilot engaged"; chb_pref_serverAutopilot.Checked = true; }
            else if (!On && GlobalVar.autoPilot)
            { GlobalVar.autoPilot = false; oldVersionStatusText = WindowTitle.Text; WindowTitle.Text = oldVersionStatusText; chb_pref_serverAutopilot.Checked = false; }
        }

        public void reLaunchServer()
        {
            if (new Windows.DelayServerStart().ShowDialog() == DialogResult.OK)
                switchAutopilot(true);
            else
                switchAutopilot(false);

            if (GlobalVar.autoPilot)
                LaunchGame(true);
                
        }

        public async void LaunchGame(bool isAutoRun)
        {
            FetchRemoteSettings(false, isAutoRun);

            if ((Directory.Exists(TSFolder) && (File.Exists(TSFolder + "ts3client_win64.exe") || File.Exists(TSFolder + "ts3client_win32.exe")) || GlobalVar.isServer))
            {
                if (Directory.Exists(GameFolder) && ((File.Exists(GameFolder + GlobalVar.gameArtifact) && !GlobalVar.isServer) || (File.Exists(GameFolder + "arma3server.exe") && GlobalVar.isServer)))
                {
                    if (Directory.Exists(AddonsFolder))
                    {
                        updateCurrentPack(false, true);

                        PrepareLaunch = new LaunchCore(flowpanel_launchOptionsChb,
                            (string)cb_clientProfile.SelectedItem,
                            (string)cb_serverConfig.SelectedItem,
                            (string)cb_serverProfile.SelectedItem,
                            (string)cb_hcProfile.SelectedItem,
                            (int)Convert.ToInt32(num_hcInstances.Text),
                            chb_maxMem.Checked,
                            num_maxMem.Text,
                            chb_malloc.Checked,
                            (string)cb_malloc.SelectedItem,
                            chb_exThreads.Checked,
                            cb_exThreads.SelectedItem.ToString(),
                            chb_cpuCount.Checked,
                            cb_cpuCount.SelectedItem.ToString(),
                            flowpanel_steamworkshopAddonsList,
                            flowpanel_optionalAddons,
                            addonsName,
                            isOptionalAllowed,
                            this);

                        Arguments = PrepareLaunch.GetArguments();
                        SaveSettings();

                        if (packID == "arma3" || GlobalVar.repoChecked)
                        {
                            hideDownloadPanel();
                            await taskDelay(800);

                            PrepareLaunch.LaunchGame(
                                Arguments,
                                txt_progressStatus,
                                flowpanel_addonPacks,
                                remoteReader.ServerInfo(),
                                remoteReader.TeamSpeakInfo(),
                                chb_pref_joinServer.Checked,
                                chb_pref_joinTSServer.Checked
                            );
                        }
                        else
                        {
                            if (!GlobalVar.isDownloading && !GlobalVar.isInstalling)
                                downloader.beginDownload(GlobalVar.files2Download, true);
                            else
                                new Windows.MessageBox().Show("There's a download already in progress. Please wait for it to finish.", "Download already in progress", MessageBoxButtons.OK, MessageIcon.Error);
                        }
                    }
                    else
                    {
                        new Windows.MessageBox().Show("Addons directory doesn't exist. Please check your Addons directory and try again.", "Missing directory", MessageBoxButtons.OK, MessageIcon.Error);
                        this.browseAddonsFolder();
                    }
                }
                else
                {
                    new Windows.MessageBox().Show("Game directory doesn't exist or executable not there. Please check your Arma 3 directory and try again.", "Missing directory or file", MessageBoxButtons.OK, MessageIcon.Error);
                    this.browseGameFolder();
                }
            }
            else
            {
                new Windows.MessageBox().Show("TeamSpeak directory doesn't exist or executable not there. Please check your TeamSpeak directory and try again.", "Missing directory or file", MessageBoxButtons.OK, MessageIcon.Error);
                this.browseTSFolder();
            }
        }

        private void browseGameFolder()
        {
            dlg_folderBrowser.Description = "Select Arma 3 root folder.";
            if (Directory.Exists(txtb_pref_armaDirectory.Text))
                dlg_folderBrowser.SelectedPath = txtb_pref_armaDirectory.Text;

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
                        txtb_pref_armaDirectory.ForeColor = Color.FromArgb(64, 64, 64);
                        GameFolder = Properties.Settings.Default.Arma3Folder = auxA3Folder + @"\";
                        missionsFolder = Properties.Settings.Default.Arma3Folder + "mpmissions";
                        Properties.Settings.Default.Save();
                        txtb_pref_armaDirectory.Text = auxA3Folder;
                        GetWorkshopAddons();
                    }
                    else
                    {
                        new Windows.MessageBox().Show("Game executable not there. Please check your Arma 3 directory and try again.", "Missing file", MessageBoxButtons.OK, MessageIcon.Error);
                    }
                }
            }

            dlg_folderBrowser.SelectedPath = string.Empty;
        }

        private void browseTSFolder()
        {
            dlg_folderBrowser.Description = "Select TeamSpeak 3 root folder.";
            if (Directory.Exists(txtb_pref_tsDirectory.Text))
                dlg_folderBrowser.SelectedPath = txtb_pref_tsDirectory.Text;

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
                        txtb_pref_tsDirectory.ForeColor = Color.FromArgb(64, 64, 64);
                        TSFolder = Properties.Settings.Default.TS3Folder = auxTS3Folder + @"\";
                        Properties.Settings.Default.Save();
                        txtb_pref_tsDirectory.Text = auxTS3Folder;
                    }
                    else
                    {
                        new Windows.MessageBox().Show("TeamSpeak executable not there. Please check your TeamSpeak directory and try again.", "Missing file", MessageBoxButtons.OK, MessageIcon.Error);
                    }
                }
            }

            dlg_folderBrowser.SelectedPath = string.Empty;
        }

        private void browseAddonsFolder()
        {
            dlg_folderBrowser.ShowNewFolderButton = true;
            dlg_folderBrowser.Description = "Select the Addons folder or create a new one.\n⚠ It can't be the same as the Game folder.";
            if (Directory.Exists(txtb_pref_addonsDirectory.Text))
                dlg_folderBrowser.SelectedPath = txtb_pref_addonsDirectory.Text;

            if (dlg_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (dlg_folderBrowser.SelectedPath != GameFolder)
                {
                    AddonsFolder = Properties.Settings.Default.AddonsFolder = dlg_folderBrowser.SelectedPath + @"\";
                    Properties.Settings.Default.Save();
                    txtb_pref_addonsDirectory.Text = dlg_folderBrowser.SelectedPath;
                }
                else
                {
                    new Windows.MessageBox().Show("The Addons folder can't be the same as the Game folder.\nWe recommend you to have a specific folder for the addons on this launcher to avoid conflicts.", "Wrong directory", MessageBoxButtons.OK, MessageIcon.Error);
                    this.browseAddonsFolder();
                }
            }

            dlg_folderBrowser.SelectedPath = string.Empty;
            dlg_folderBrowser.ShowNewFolderButton = false;
        }

        private void browseOptionalFolder()
        {
            dlg_folderBrowser.ShowNewFolderButton = true;
            dlg_folderBrowser.Description = "Select the Optional Addons folder or create a new one.\n⚠ It can't be the same as the Game or the Addons folders.";
            if (Directory.Exists(txtb_pref_optionalDirectory.Text))
                dlg_folderBrowser.SelectedPath = txtb_pref_optionalDirectory.Text;

            if (dlg_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (dlg_folderBrowser.SelectedPath != AddonsFolder && (dlg_folderBrowser.SelectedPath != GameFolder || (dlg_folderBrowser.SelectedPath != GameFolder + "!Workshop")))
                {
                    AddonsFolder = Properties.Settings.Default.OptionalAddonsFolder = dlg_folderBrowser.SelectedPath + @"\";
                    Properties.Settings.Default.Save();
                    txtb_pref_optionalDirectory.Text = dlg_folderBrowser.SelectedPath;
                }
                else
                {
                    if (dlg_folderBrowser.SelectedPath == AddonsFolder)
                        new Windows.MessageBox().Show("The Optional Addons folder can't be the same as the Addons folder.", "Wrong directory", MessageBoxButtons.OK, MessageIcon.Error);
                    else if (dlg_folderBrowser.SelectedPath == GameFolder || (dlg_folderBrowser.SelectedPath == GameFolder + "!Workshop"))
                        new Windows.MessageBox().Show("The Optional Addons folder can't be the same as the Game folder.", "Wrong directory", MessageBoxButtons.OK, MessageIcon.Error);

                    this.browseAddonsFolder();
                }
            }

            dlg_folderBrowser.SelectedPath = string.Empty;
            dlg_folderBrowser.ShowNewFolderButton = false;
        }

        private void btn_reinstallTFRPlugins_Click(object sender, EventArgs e)
        { installer.installTeamSpeakPlugin(); }

        public void updateCurrentPack(bool refreshPacks, bool revealPacks)
        { FetchRemoteSettings(refreshPacks, false); GetWorkshopAddons(); GetOptionalAddons(); if (revealPacks) { fetchAddonPacks.RevealPacks(flowpanel_addonPacks); } }

        public bool startGameAfterDownload()
        { return chb_pref_startGame.Checked; }

        public bool runLauncherStartup()
        { return chb_pref_runLauncherStartup.Checked; }

        public bool allowNotifications()
        { return chb_pref_allowNotifications.Checked; }

        public bool autoDownloadUpdates()
        { return chb_pref_autoDownload.Checked; }

        public void showDownloadPanel()
        { repoInfoPanelIO.hidePanelSingle(); }

        public void hideDownloadPanel()
        { repoInfoPanelIO.showPanelSingle(); }

        public void ReadRepo(bool showMessage, bool validateFiles)
        { repoReader.ReadRepo(showMessage, chb_pref_autoDownload.Checked, validateFiles); }

        #region Game Options Conditions
        private void chb_maxMem_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_maxMem.Checked)
            { num_maxMem.Enabled = true; btn_memIncrease.Enabled = true; btn_memDecrease.Enabled = true; }
            else
            { num_maxMem.Enabled = false; btn_memIncrease.Enabled = false; btn_memDecrease.Enabled = false; }
        }

        private void chb_malloc_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_malloc.Checked)
                cb_malloc.Enabled = true;
            else
                cb_malloc.Enabled = false;
        }

        private void chb_exThreads_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_exThreads.Checked)
                cb_exThreads.Enabled = true;
            else
                cb_exThreads.Enabled = false;
        }

        private void chb_cpuCount_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_cpuCount.Checked)
            { cb_cpuCount.Enabled = true; chb_enableHT.Enabled = false; chb_enableHT.Checked = false; }
            else
            { cb_cpuCount.Enabled = false; chb_enableHT.Enabled = true; }
        }
        #endregion

        private void addPrivatePackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new Windows.PrivatePackManager().ShowDialog() == DialogResult.OK)
            {
                fetchAddonPacks.Search("");
                fetchAddonPacks.Get();
            }
        }

        private void reloadPacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateCurrentPack(true, true);
        }

        private void btn_memIncrease_Click(object sender, EventArgs e)
        {
            long curValue = Convert.ToInt32(num_maxMem.Text);
            if (curValue < memoryMaximum)
            {
                long increasedValue = curValue + 256;
                num_maxMem.Text = increasedValue.ToString();
            }
                    
        }

        private void btn_memDecrease_Click(object sender, EventArgs e)
        {
            long curValue = Convert.ToInt32(num_maxMem.Text);
            if (curValue > memoryMinimum)
            {
                long decreasedValue = curValue - 256;
                num_maxMem.Text = decreasedValue.ToString();
            }
        }

        private void btn_decreaseHcInstances_Click(object sender, EventArgs e)
        {
            long curValue = Convert.ToInt32(num_hcInstances.Text);
            if (curValue > 0)
            {
                long decreasedValue = curValue - 1;
                num_hcInstances.Text = decreasedValue.ToString();
            }
        }

        private void btn_increaseHcInstances_Click(object sender, EventArgs e)
        {
            long curValue = Convert.ToInt32(num_hcInstances.Text);
            if (curValue < 10)
            {
                long increasedValue = curValue + 1;
                num_hcInstances.Text = increasedValue.ToString();
            }

        }

        private void manageRepositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Windows.AddonManager().ShowDialog();
        }

        private void btn_checkRepo_Click(object sender, EventArgs e)
        {
            ReadRepo(true, true);
        }

        #region Preferences Directories Actions
        // BROWSE BUTTONS
        private void btn_pref_browseA3Dir_Click(object sender, EventArgs e)
        {
            this.browseGameFolder();
        }

        private void btn_pref_browseAddonsDir_Click(object sender, EventArgs e)
        {
            this.browseAddonsFolder();
        }

        private void btn_pref_browseOptionalDir_Click(object sender, EventArgs e)
        {
            this.browseOptionalFolder();
        }

        private void btn_pref_browseTS3Dir_Click(object sender, EventArgs e)
        {
            this.browseTSFolder();
        }

        // EREASE BUTTONS
        private void btn_pref_ereaseArmaDir_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Arma3Folder = string.Empty;
            Properties.Settings.Default.Save();

            txtb_pref_armaDirectory.ForeColor = Color.DarkGray; txtb_pref_armaDirectory.Text = "Set directory ->";
        }

        private void btn_pref_ereaseAddonsDir_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AddonsFolder = string.Empty;
            Properties.Settings.Default.Save();

            txtb_pref_addonsDirectory.ForeColor = Color.DarkGray; txtb_pref_addonsDirectory.Text = "Set directory ->";
        }
        private void btn_pref_ereaseOptionalDir_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.OptionalAddonsFolder = string.Empty;
            Properties.Settings.Default.Save();

            txtb_pref_optionalDirectory.ForeColor = Color.DarkGray; txtb_pref_optionalDirectory.Text = "Set directory ->";
        }

        private void btn_pref_ereaseTSDir_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.TS3Folder = string.Empty;
            Properties.Settings.Default.Save();

            txtb_pref_tsDirectory.ForeColor = Color.DarkGray; txtb_pref_tsDirectory.Text = "Set directory ->";
        }

        // OPEN DIRECTORY BUTTONS
        private void btn_pref_openA3Dir_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Arma3Folder != string.Empty)
                Process.Start(Properties.Settings.Default.Arma3Folder);
            else
                this.browseGameFolder();
        }

        private void btn_pref_openAddonsDir_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AddonsFolder != string.Empty)
                Process.Start(Properties.Settings.Default.AddonsFolder);
            else
                this.browseAddonsFolder();
        }

        private void btn_pref_openOptionalDir_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.OptionalAddonsFolder != string.Empty)
                Process.Start(Properties.Settings.Default.OptionalAddonsFolder);
            else
                this.browseOptionalFolder();
        }

        private void btn_pref_openTS3Dir_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.TS3Folder != string.Empty)
                Process.Start(Properties.Settings.Default.TS3Folder);
            else
                this.browseTSFolder();
        }

        // ARMA 3 DIR TEXTBOX
        private void txtb_pref_armaDirectory_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtb_pref_armaDirectory.Text == "Set directory ->")
                txtb_pref_armaDirectory.SelectAll();
        }

        private void txtb_pref_armaDirectory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtb_pref_armaDirectory.SelectAll();
        }

        private void txtb_pref_armaDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtb_pref_armaDirectory.Text != "Set directory ->" && txtb_pref_armaDirectory.Text != string.Empty)
            {
                txtb_pref_armaDirectory.ForeColor = Color.FromArgb(64, 64, 64);

                if (txtb_pref_armaDirectory.Text.EndsWith("\\"))
                    txtb_pref_armaDirectory.Text = txtb_pref_armaDirectory.Text.Remove(txtb_pref_armaDirectory.Text.Length - 1);

                if (txtb_pref_armaDirectory.Text.EndsWith("/"))
                    txtb_pref_armaDirectory.Text = txtb_pref_armaDirectory.Text.Remove(txtb_pref_armaDirectory.Text.Length - 1).Replace("/", "\\");

                if (Directory.Exists(txtb_pref_armaDirectory.Text) && ((File.Exists(txtb_pref_armaDirectory.Text + @"\arma3battleye.exe") && !GlobalVar.isServer) || (File.Exists(txtb_pref_armaDirectory.Text + @"\arma3server.exe") && GlobalVar.isServer)))
                {
                    GameFolder = Properties.Settings.Default.Arma3Folder = txtb_pref_armaDirectory.Text + @"\";
                    missionsFolder = Properties.Settings.Default.Arma3Folder + "mpmissions";
                    Properties.Settings.Default.Save();

                    armaDir_previousDir = txtb_pref_armaDirectory.Text;
                }
                else
                {
                    new Windows.MessageBox().Show("Game executable not there. Please check your Arma 3 directory and try again.", "Missing file", MessageBoxButtons.OK, MessageIcon.Error);
                    if (String.IsNullOrEmpty(armaDir_previousDir))
                    {
                        txtb_pref_armaDirectory.ForeColor = Color.DarkGray; txtb_pref_armaDirectory.Text = "Set directory ->";
                        this.browseGameFolder();
                    }
                    else
                        txtb_pref_armaDirectory.Text = armaDir_previousDir;
                }
            }
            else
            {
                if (txtb_pref_armaDirectory.Text == string.Empty)
                {
                    Properties.Settings.Default.Arma3Folder = string.Empty;
                    Properties.Settings.Default.Save();

                    txtb_pref_armaDirectory.ForeColor = Color.DarkGray; txtb_pref_armaDirectory.Text = "Set directory ->";
                }
            }

            GetMalloc();
            GetWorkshopAddons();
        }

        // ADDONS DIR TEXTBOX
        private void txtb_pref_addonsDirectory_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtb_pref_addonsDirectory.Text == "Set directory ->")
                txtb_pref_addonsDirectory.SelectAll();
        }

        private void txtb_pref_addonsDirectory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtb_pref_addonsDirectory.SelectAll();
        }

        private void txtb_pref_addonsDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtb_pref_addonsDirectory.Text != "Set directory ->" && txtb_pref_addonsDirectory.Text != string.Empty)
            {
                txtb_pref_addonsDirectory.ForeColor = Color.FromArgb(64, 64, 64);

                if (txtb_pref_addonsDirectory.Text.EndsWith("\\"))
                    txtb_pref_addonsDirectory.Text = txtb_pref_addonsDirectory.Text.Remove(txtb_pref_addonsDirectory.Text.Length - 1);

                if (txtb_pref_addonsDirectory.Text.EndsWith("/"))
                    txtb_pref_addonsDirectory.Text = txtb_pref_addonsDirectory.Text.Remove(txtb_pref_addonsDirectory.Text.Length - 1).Replace("/", "\\");

                if ((txtb_pref_addonsDirectory.Text != txtb_pref_armaDirectory.Text && !File.Exists(txtb_pref_addonsDirectory.Text + "\\arma3.exe")) || GlobalVar.isServer)
                {
                    AddonsFolder = Properties.Settings.Default.AddonsFolder = txtb_pref_addonsDirectory.Text + @"\";
                    Properties.Settings.Default.Save();

                    modsDir_previousDir = txtb_pref_addonsDirectory.Text;
                }
                else
                {
                    new Windows.MessageBox().Show("The Addons folder can't be the same as the Game folder.\nWe recommend you to have a specific folder for the addons on this launcher to avoid conflicts.", "Wrong directory", MessageBoxButtons.OK, MessageIcon.Error);
                    if (String.IsNullOrEmpty(modsDir_previousDir))
                    {
                        txtb_pref_addonsDirectory.ForeColor = Color.DarkGray; txtb_pref_addonsDirectory.Text = "Set directory ->";
                        this.browseAddonsFolder();
                    }
                    else
                        txtb_pref_addonsDirectory.Text = modsDir_previousDir;
                }
            }
            else
            {
                if (txtb_pref_addonsDirectory.Text == string.Empty)
                {
                    Properties.Settings.Default.AddonsFolder = string.Empty;
                    Properties.Settings.Default.Save();

                    txtb_pref_addonsDirectory.ForeColor = Color.DarkGray; txtb_pref_addonsDirectory.Text = "Set directory ->";
                }
            }

            if (hasShown)
                ReadRepo(false, true);
        }

        // OPTIONAL ADDONS DIR TEXTBOX
        private void txtb_pref_optionalDirectory_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtb_pref_optionalDirectory.Text == "Set directory ->")
                txtb_pref_optionalDirectory.SelectAll();
        }

        private void txtb_pref_optionalDirectory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtb_pref_optionalDirectory.SelectAll();
        }

        private void txtb_pref_optionalDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtb_pref_optionalDirectory.Text != "Set directory ->" && txtb_pref_optionalDirectory.Text != string.Empty)
            {
                txtb_pref_optionalDirectory.ForeColor = Color.FromArgb(64, 64, 64);

                if (txtb_pref_optionalDirectory.Text.EndsWith("\\"))
                    txtb_pref_optionalDirectory.Text = txtb_pref_optionalDirectory.Text.Remove(txtb_pref_optionalDirectory.Text.Length - 1);

                if (txtb_pref_optionalDirectory.Text.EndsWith("/"))
                    txtb_pref_optionalDirectory.Text = txtb_pref_optionalDirectory.Text.Remove(txtb_pref_optionalDirectory.Text.Length - 1).Replace("/", "\\");

                if (Directory.Exists(txtb_pref_optionalDirectory.Text) && txtb_pref_optionalDirectory.Text != txtb_pref_addonsDirectory.Text && (txtb_pref_optionalDirectory.Text != txtb_pref_armaDirectory.Text || txtb_pref_optionalDirectory.Text == (txtb_pref_armaDirectory.Text + "\\!Workshop")))
                {
                    OptionalAddonsFolder = Properties.Settings.Default.OptionalAddonsFolder = txtb_pref_optionalDirectory.Text + @"\";
                    Properties.Settings.Default.Save();

                    optionalDir_previousDir = txtb_pref_optionalDirectory.Text;
                }
                else
                {
                    if (txtb_pref_optionalDirectory.Text == txtb_pref_addonsDirectory.Text)
                        new Windows.MessageBox().Show("The Optional Addons folder can't be the same as the Addons folder.", "Wrong directory", MessageBoxButtons.OK, MessageIcon.Error);
                    else if (txtb_pref_optionalDirectory.Text == txtb_pref_armaDirectory.Text || txtb_pref_optionalDirectory.Text == (txtb_pref_armaDirectory.Text + "\\!Workshop"))
                        new Windows.MessageBox().Show("The Optional Addons folder can't be the same as the Game folder.", "Wrong directory", MessageBoxButtons.OK, MessageIcon.Error);
                    else
                        new Windows.MessageBox().Show("Selected directory does not exist.", "Missing directory", MessageBoxButtons.OK, MessageIcon.Error);

                    if (String.IsNullOrEmpty(optionalDir_previousDir))
                    {
                        txtb_pref_optionalDirectory.ForeColor = Color.DarkGray; txtb_pref_optionalDirectory.Text = "Set directory ->";
                        this.browseOptionalFolder();
                    }
                    else
                        txtb_pref_optionalDirectory.Text = optionalDir_previousDir;
                }
            }
            else
            {
                if (txtb_pref_optionalDirectory.Text == string.Empty)
                {
                    Properties.Settings.Default.OptionalAddonsFolder = string.Empty;
                    Properties.Settings.Default.Save();

                    txtb_pref_optionalDirectory.ForeColor = Color.DarkGray; txtb_pref_optionalDirectory.Text = "Set directory ->";
                }
            }

            GetOptionalAddons();
        }

        // TS3 DIR TEXTBOX
        private void txtb_pref_tsDirectory_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtb_pref_tsDirectory.Text == "Set directory ->")
                txtb_pref_tsDirectory.SelectAll();
        }

        private void txtb_pref_tsDirectory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtb_pref_tsDirectory.SelectAll();
        }

        private void txtb_pref_tsDirectory_TextChanged(object sender, EventArgs e)
        {
            if (txtb_pref_tsDirectory.Text != "Set directory ->" && txtb_pref_tsDirectory.Text != string.Empty)
            {
                txtb_pref_tsDirectory.ForeColor = Color.FromArgb(64, 64, 64);

                if (txtb_pref_tsDirectory.Text.EndsWith("\\"))
                    txtb_pref_tsDirectory.Text = txtb_pref_tsDirectory.Text.Remove(txtb_pref_tsDirectory.Text.Length - 1);

                if (txtb_pref_tsDirectory.Text.EndsWith("/"))
                    txtb_pref_tsDirectory.Text = txtb_pref_tsDirectory.Text.Remove(txtb_pref_tsDirectory.Text.Length - 1).Replace("/", "\\");

                if (Directory.Exists(txtb_pref_tsDirectory.Text) && (File.Exists(txtb_pref_tsDirectory.Text + @"\ts3client_win64.exe") || File.Exists(txtb_pref_tsDirectory.Text + @"\ts3client_win32.exe")))
                {
                    TSFolder = Properties.Settings.Default.TS3Folder = txtb_pref_tsDirectory.Text + @"\";
                    Properties.Settings.Default.Save();

                    tsDir_previousDir = txtb_pref_tsDirectory.Text;
                }
                else
                {
                    new Windows.MessageBox().Show("TeamSpeak executable not there. Please check your TeamSpeak directory and try again.", "Missing file", MessageBoxButtons.OK, MessageIcon.Error);
                    if (String.IsNullOrEmpty(tsDir_previousDir))
                    {
                        txtb_pref_tsDirectory.ForeColor = Color.DarkGray; txtb_pref_tsDirectory.Text = "Set directory ->";
                        this.browseTSFolder();
                    }
                    else
                        txtb_pref_tsDirectory.Text = tsDir_previousDir;
                }
            }
            else
            {
                if (txtb_pref_tsDirectory.Text == string.Empty)
                {
                    Properties.Settings.Default.TS3Folder = string.Empty;
                    Properties.Settings.Default.Save();

                    txtb_pref_tsDirectory.ForeColor = Color.DarkGray; txtb_pref_tsDirectory.Text = "Set directory ->";
                }
            }
        } 
        #endregion

        private void panel_repoDownload_Paint(object sender, PaintEventArgs e)
        {
            if (panel_repoDownload.Location.X < 1240)
                img_repoBusy.Visible = true;
        }

        private void panel_repoInfo_Paint(object sender, PaintEventArgs e)
        {
            if (panel_repoInfo.Width > 0)
                img_repoBusy.Visible = false;
        }

        private void chb_pref_serverAutopilot_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_pref_serverAutopilot.Checked)
            {
                if (new Windows.DelayServerStart().ShowDialog() == DialogResult.OK)
                    switchAutopilot(true);
                else
                    chb_pref_serverAutopilot.Checked = false;
            }
            else
            { switchAutopilot(false); }
        }

        private void chb_pref_runLauncherStartup_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (chb_pref_runLauncherStartup.Checked)
                rk.SetValue(AssemblyTitle, Application.ExecutablePath);
            else
                rk.DeleteValue(AssemblyTitle, false);
        }

        private void repositoryMenu_Opening(object sender, CancelEventArgs e)
        {
            TreeNode auxNode = trv_repoContent.SelectedNode;
            while (auxNode.Parent != null)
                auxNode = auxNode.Parent;

            if (Directory.Exists(Properties.Settings.Default.AddonsFolder + auxNode.Text))
            {
                tsmi_openAddonFolder.Enabled = true;
            }
            else
            {
                tsmi_openAddonFolder.Enabled = false;
            }
        }

        private void openAddonFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode auxNode = trv_repoContent.SelectedNode;
            while (auxNode.Parent != null)
                auxNode = auxNode.Parent;

            Process.Start(Properties.Settings.Default.AddonsFolder + auxNode.Text);
        }

        private void chb_battleye_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_battleye.Checked)
                GlobalVar.gameArtifact = "arma3battleye.exe";
            else
                GlobalVar.gameArtifact = "arma3.exe";
        }

        private void chb_use64Bit_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_use64Bit.Checked)
            {
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

        private void chb_pref_serverMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_pref_serverMode.Checked && !Properties.Settings.Default.isServerMode)
            {
                if (new Windows.MessageBox().Show("Requires the launcher to be restarted to activate Server Mode.\nSelecting \"YES\" will make the launcher close.", "Switch to Server Mode?", MessageBoxButtons.YesNo, MessageIcon.Question) == DialogResult.Yes)
                { Properties.Settings.Default.isServerMode = true; this.Close(); }
            }
            else if (!chb_pref_serverMode.Checked && Properties.Settings.Default.isServerMode)
            {
                if (new Windows.MessageBox().Show("Requires the launcher to be restarted to activate Client Mode.\nSelecting \"YES\" will make the launcher close.", "Switch to Client Mode?", MessageBoxButtons.YesNo, MessageIcon.Question) == DialogResult.Yes)
                { Properties.Settings.Default.isServerMode = false; this.Close(); }
            }
        }

        private void chb_pref_disableAnimations_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_pref_disableAnimations.Checked)
                GlobalVar.disableAnimations = true;
            else
                GlobalVar.disableAnimations = false;
        }

        private void btn_openWorkshop_Click(object sender, EventArgs e)
        {
            Process.Start("https://steamcommunity.com/app/107410/workshop/");
        }

        private void btn_openArmaholic_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.armaholic.com/");
        }

        private void tsmi_openWorkshopFolder_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (sender as ToolStripItem);
            if (item != null)
            {
                ContextMenuStrip owner = item.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    Process.Start(Properties.Settings.Default.Arma3Folder + "!Workshop\\" + owner.SourceControl.Text);
                }
            }
        }

        private void tsmi_workshopReload_Click(object sender, EventArgs e)
        {
            GetWorkshopAddons();
        }

        private void tsmi_openOptionalFolder_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (sender as ToolStripItem);
            if (item != null)
            {
                ContextMenuStrip owner = item.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    Process.Start(Properties.Settings.Default.OptionalAddonsFolder + owner.SourceControl.Text);
                }
            }
        }

        private void tsmi_reloadOptional_Click(object sender, EventArgs e)
        {
            GetOptionalAddons();
        }
    }
}
