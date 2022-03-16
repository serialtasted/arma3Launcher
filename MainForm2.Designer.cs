namespace arma3Launcher
{
    partial class MainForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm2));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node0", -2, -2);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node2", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node3", 2, 2);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node0", 3, 3);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node1", 4, 4);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node2", 5, 5);
            System.Drawing.Drawing2D.GraphicsPath graphicsPath1 = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath graphicsPath2 = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath graphicsPath3 = new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Drawing2D.GraphicsPath graphicsPath4 = new System.Drawing.Drawing2D.GraphicsPath();
            this.imageListRepo = new System.Windows.Forms.ImageList(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btn_cancelDownload = new System.Windows.Forms.PictureBox();
            this.dlg_folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.flowAddonsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_reloadPacks = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_addPrivatePack = new System.Windows.Forms.ToolStripMenuItem();
            this.repositoryMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_selectedAddonName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_openAddonFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_openLocalFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.repositorymenu_separator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_reloadRepository = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_manageRepository = new System.Windows.Forms.ToolStripMenuItem();
            this.optionaladdonsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_openOptionalFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_reloadOptional = new System.Windows.Forms.ToolStripMenuItem();
            this.steamworkshopMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_openWorkshopFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_workshopReload = new System.Windows.Forms.ToolStripMenuItem();
            this.win_mainWindow = new arma3Launcher.Controls.DoubleBufferPanel();
            this.snackbar_mainWindow = new MaterialSkin.Controls.MaterialSnackbar();
            this.panel_sideMenu = new arma3Launcher.Controls.DoubleBufferPanel();
            this.sidemenu_menuList = new arma3Launcher.Controls.DoubleBufferFlowPanel();
            this.doubleBufferPanel5 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.menu_addonPacks = new System.Windows.Forms.Label();
            this.doubleBufferPanel6 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.doubleBufferPanel7 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.menu_launchOptions = new System.Windows.Forms.Label();
            this.doubleBufferPanel8 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.doubleBufferPanel9 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.menu_repositoryDownloads = new System.Windows.Forms.Label();
            this.img_repoBusy = new System.Windows.Forms.PictureBox();
            this.doubleBufferPanel10 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.doubleBufferPanel11 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.menu_preferences = new System.Windows.Forms.Label();
            this.sidemenu_botPanel = new arma3Launcher.Controls.DoubleBufferPanel();
            this.menu_help = new System.Windows.Forms.Label();
            this.menu_about = new System.Windows.Forms.Label();
            this.txt_versionNumber = new System.Windows.Forms.Label();
            this.panel_mainPanel = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_outterPanel = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_launchOptions = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_contentLaunchOptions = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_serverOptions_vSep = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_launchOptionsCenter = new arma3Launcher.Controls.DoubleBufferPanel();
            this.cb_malloc = new MetroFramework.Controls.MetroComboBox();
            this.btn_memDecrease = new MaterialSkin.Controls.MaterialFlatButton();
            this.lbl_clientProfile = new MaterialSkin.Controls.MaterialLabel();
            this.chb_malloc = new MaterialSkin.Controls.MaterialCheckBox();
            this.cb_exThreads = new MetroFramework.Controls.MetroComboBox();
            this.chb_exThreads = new MaterialSkin.Controls.MaterialCheckBox();
            this.cb_cpuCount = new MetroFramework.Controls.MetroComboBox();
            this.chb_cpuCount = new MaterialSkin.Controls.MaterialCheckBox();
            this.cb_clientProfile = new MetroFramework.Controls.MetroComboBox();
            this.num_maxMem = new MetroFramework.Controls.MetroTextBox();
            this.chb_maxMem = new MaterialSkin.Controls.MaterialCheckBox();
            this.btn_memIncrease = new MaterialSkin.Controls.MaterialFlatButton();
            this.flowpanel_serverOptions = new arma3Launcher.Controls.DoubleBufferFlowPanel();
            this.panel_serverOptions = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel23 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.cb_serverMission = new MetroFramework.Controls.MetroComboBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.cb_serverPack = new MetroFramework.Controls.MetroComboBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.cb_serverProfile = new MetroFramework.Controls.MetroComboBox();
            this.cb_serverConfig = new MetroFramework.Controls.MetroComboBox();
            this.panel24 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.label30 = new System.Windows.Forms.Label();
            this.panel_serverOptions_hSep = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_headlessOptions = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel25 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.btn_decreaseHcInstances = new MaterialSkin.Controls.MaterialFlatButton();
            this.num_hcInstances = new MetroFramework.Controls.MetroTextBox();
            this.btn_increaseHcInstances = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.cb_hcProfile = new MetroFramework.Controls.MetroComboBox();
            this.panel26 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.label37 = new System.Windows.Forms.Label();
            this.panel1 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.flowpanel_launchOptionsChb = new arma3Launcher.Controls.DoubleBufferFlowPanel();
            this.chb_use64Bit = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_showScriptErrors = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_noPause = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_noSplash = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_skipIntro = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_window = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_enableHT = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_hugePages = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_filePatching = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_worldEmpty = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_battleye = new MaterialSkin.Controls.MaterialCheckBox();
            this.lbl_launchOptions = new System.Windows.Forms.Label();
            this.panel_preferences = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_contentPreferences = new arma3Launcher.Controls.DoubleBufferPanel();
            this.flowLayoutPanel2 = new arma3Launcher.Controls.DoubleBufferFlowPanel();
            this.txt_pref_gamePrefrences = new System.Windows.Forms.Label();
            this.chb_pref_startGame = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_pref_joinServer = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_pref_joinTSServer = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_pref_serverAutopilot = new MaterialSkin.Controls.MaterialCheckBox();
            this.panel18 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.txt_pref_launcherPreferences = new System.Windows.Forms.Label();
            this.chb_pref_disableAnimations = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_pref_runLauncherStartup = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_pref_allowNotifications = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_pref_autoDownload = new MaterialSkin.Controls.MaterialCheckBox();
            this.chb_pref_serverMode = new MaterialSkin.Controls.MaterialCheckBox();
            this.panel17 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.flowpanel_preferencesDirectories = new arma3Launcher.Controls.DoubleBufferFlowPanel();
            this.panel_Arma3Dir = new arma3Launcher.Controls.DoubleBufferPanel();
            this.btn_pref_openA3Dir = new System.Windows.Forms.PictureBox();
            this.btn_pref_browseA3Dir = new System.Windows.Forms.PictureBox();
            this.btn_pref_ereaseArmaDir = new System.Windows.Forms.PictureBox();
            this.lbl_pref_Arma3Dir = new System.Windows.Forms.Label();
            this.txtb_pref_armaDirectory = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.doubleBufferPanel22 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_addonsDir = new arma3Launcher.Controls.DoubleBufferPanel();
            this.lbl_pref_AddonsDir = new System.Windows.Forms.Label();
            this.btn_pref_ereaseAddonsDir = new System.Windows.Forms.PictureBox();
            this.btn_pref_openAddonsDir = new System.Windows.Forms.PictureBox();
            this.btn_pref_browseAddonsDir = new System.Windows.Forms.PictureBox();
            this.txtb_pref_addonsDirectory = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.doubleBufferPanel23 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_optionalAddonsDir = new arma3Launcher.Controls.DoubleBufferPanel();
            this.btn_pref_ereaseOptionalDir = new System.Windows.Forms.PictureBox();
            this.btn_pref_openOptionalDir = new System.Windows.Forms.PictureBox();
            this.btn_pref_browseOptionalDir = new System.Windows.Forms.PictureBox();
            this.txtb_pref_optionalDirectory = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lbl_pref_OptionalDir = new System.Windows.Forms.Label();
            this.doubleBufferPanel24 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_TeamSpeakDir = new arma3Launcher.Controls.DoubleBufferPanel();
            this.btn_pref_ereaseTSDir = new System.Windows.Forms.PictureBox();
            this.btn_pref_openTS3Dir = new System.Windows.Forms.PictureBox();
            this.btn_pref_browseTS3Dir = new System.Windows.Forms.PictureBox();
            this.txtb_pref_tsDirectory = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lbl_pref_TeamSpeakDir = new System.Windows.Forms.Label();
            this.lbl_preferences = new System.Windows.Forms.Label();
            this.panel_repositoryDownloads = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_contentRepositoryDownloads = new arma3Launcher.Controls.DoubleBufferPanel();
            this.trv_repoContent = new arma3Launcher.Controls.DoubleBufferTreeView();
            this.panel_repoBottom = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_repoDownload = new arma3Launcher.Controls.DoubleBufferPanel();
            this.prb_progressBar_All = new arma3Launcher.Controls.Windows7ProgressBar();
            this.prb_progressBar_File = new arma3Launcher.Controls.Windows7ProgressBar();
            this.txt_curFile = new System.Windows.Forms.Label();
            this.txt_percentageStatus = new System.Windows.Forms.Label();
            this.txt_progressStatus = new System.Windows.Forms.Label();
            this.panel_repoInfo = new arma3Launcher.Controls.DoubleBufferPanel();
            this.btn_updateRepo = new MaterialSkin.Controls.MaterialFlatButton();
            this.btn_checkRepo = new MaterialSkin.Controls.MaterialFlatButton();
            this.lbl_repofileok = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.lbl_repofilemissing = new System.Windows.Forms.Label();
            this.lbl_repofileinvalid = new System.Windows.Forms.Label();
            this.lbl_repositoryDownloads = new System.Windows.Forms.Label();
            this.panel_addonPacks = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_addonPacksFlow = new arma3Launcher.Controls.DoubleBufferPanel();
            this.btn_addonsOptionsOpen = new System.Windows.Forms.Label();
            this.flowpanel_addonPacks = new arma3Launcher.Controls.DoubleBufferFlowPanel();
            this.panel2 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel3 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel4 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel5 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel6 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel8 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel7 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel9 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel10 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_addonOptions = new arma3Launcher.Controls.DoubleBufferPanel();
            this.btn_addonsOptionsClose = new System.Windows.Forms.Label();
            this.panel_contentAddonOptions = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_sideAddonOptions = new arma3Launcher.Controls.DoubleBufferFlowPanel();
            this.sideAOP_armaholic = new arma3Launcher.Controls.DoubleBufferPanel();
            this.materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            this.btn_openArmaholic = new MaterialSkin.Controls.MaterialRaisedButton();
            this.sideAOP_separator1 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.sideAOP_steamworkshop = new arma3Launcher.Controls.DoubleBufferPanel();
            this.materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            this.btn_openWorkshop = new MaterialSkin.Controls.MaterialRaisedButton();
            this.sideAOP_separator2 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.sideAOP_taskforceradio = new arma3Launcher.Controls.DoubleBufferPanel();
            this.materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            this.btn_reinstallTFRPlugins = new MaterialSkin.Controls.MaterialRaisedButton();
            this.sideAOP_separator3 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.sideAOP_userconfig = new arma3Launcher.Controls.DoubleBufferPanel();
            this.materialLabel12 = new MaterialSkin.Controls.MaterialLabel();
            this.btn_reinstallUserconfigFiles = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel_optionalAddons = new arma3Launcher.Controls.DoubleBufferPanel();
            this.scroll_optionalAddons = new MetroFramework.Controls.MetroScrollBar();
            this.flowpanel_optionalAddons = new arma3Launcher.Controls.DoubleBufferFlowPanel();
            this.doubleBufferPanel13 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.chb_optionalEnabled = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.doubleBufferPanel14 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_steamworkshopAddons = new arma3Launcher.Controls.DoubleBufferPanel();
            this.scroll_steamAddons = new MetroFramework.Controls.MetroScrollBar();
            this.flowpanel_steamworkshopAddonsList = new arma3Launcher.Controls.DoubleBufferFlowPanel();
            this.doubleBufferPanel3 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.chb_workshopEnabled = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.lbl_addonOptions = new System.Windows.Forms.Label();
            this.win_titleBar = new arma3Launcher.Controls.DoubleBufferPanel();
            this.WindowTitle = new System.Windows.Forms.Label();
            this.btn_windowMenu = new System.Windows.Forms.PictureBox();
            this.btn_windowClose = new System.Windows.Forms.PictureBox();
            this.btn_windowMinimize = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelDownload)).BeginInit();
            this.flowAddonsMenu.SuspendLayout();
            this.repositoryMenu.SuspendLayout();
            this.optionaladdonsMenu.SuspendLayout();
            this.steamworkshopMenu.SuspendLayout();
            this.win_mainWindow.SuspendLayout();
            this.panel_sideMenu.SuspendLayout();
            this.sidemenu_menuList.SuspendLayout();
            this.doubleBufferPanel5.SuspendLayout();
            this.doubleBufferPanel7.SuspendLayout();
            this.doubleBufferPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_repoBusy)).BeginInit();
            this.doubleBufferPanel11.SuspendLayout();
            this.sidemenu_botPanel.SuspendLayout();
            this.panel_mainPanel.SuspendLayout();
            this.panel_outterPanel.SuspendLayout();
            this.panel_launchOptions.SuspendLayout();
            this.panel_contentLaunchOptions.SuspendLayout();
            this.panel_launchOptionsCenter.SuspendLayout();
            this.flowpanel_serverOptions.SuspendLayout();
            this.panel_serverOptions.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel_headlessOptions.SuspendLayout();
            this.panel25.SuspendLayout();
            this.panel26.SuspendLayout();
            this.flowpanel_launchOptionsChb.SuspendLayout();
            this.panel_preferences.SuspendLayout();
            this.panel_contentPreferences.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowpanel_preferencesDirectories.SuspendLayout();
            this.panel_Arma3Dir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_openA3Dir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_browseA3Dir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_ereaseArmaDir)).BeginInit();
            this.panel_addonsDir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_ereaseAddonsDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_openAddonsDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_browseAddonsDir)).BeginInit();
            this.panel_optionalAddonsDir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_ereaseOptionalDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_openOptionalDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_browseOptionalDir)).BeginInit();
            this.panel_TeamSpeakDir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_ereaseTSDir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_openTS3Dir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_browseTS3Dir)).BeginInit();
            this.panel_repositoryDownloads.SuspendLayout();
            this.panel_contentRepositoryDownloads.SuspendLayout();
            this.panel_repoBottom.SuspendLayout();
            this.panel_repoDownload.SuspendLayout();
            this.panel_repoInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.panel_addonPacks.SuspendLayout();
            this.panel_addonPacksFlow.SuspendLayout();
            this.flowpanel_addonPacks.SuspendLayout();
            this.panel_addonOptions.SuspendLayout();
            this.panel_contentAddonOptions.SuspendLayout();
            this.panel_sideAddonOptions.SuspendLayout();
            this.sideAOP_armaholic.SuspendLayout();
            this.sideAOP_steamworkshop.SuspendLayout();
            this.sideAOP_taskforceradio.SuspendLayout();
            this.sideAOP_userconfig.SuspendLayout();
            this.panel_optionalAddons.SuspendLayout();
            this.doubleBufferPanel13.SuspendLayout();
            this.panel_steamworkshopAddons.SuspendLayout();
            this.doubleBufferPanel3.SuspendLayout();
            this.win_titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_windowMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_windowClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_windowMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // imageListRepo
            // 
            this.imageListRepo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListRepo.ImageStream")));
            this.imageListRepo.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListRepo.Images.SetKeyName(0, "document-checked.png");
            this.imageListRepo.Images.SetKeyName(1, "document-error.png");
            this.imageListRepo.Images.SetKeyName(2, "document-cancel.png");
            this.imageListRepo.Images.SetKeyName(3, "folder-checked.png");
            this.imageListRepo.Images.SetKeyName(4, "folder-error.png");
            this.imageListRepo.Images.SetKeyName(5, "folder-cancel.png");
            // 
            // btn_cancelDownload
            // 
            this.btn_cancelDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancelDownload.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancelDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_cancelDownload.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_cancelDownload.Image = global::arma3Launcher.Properties.Resources.cancel_circle_big_white;
            this.btn_cancelDownload.Location = new System.Drawing.Point(1199, 27);
            this.btn_cancelDownload.Name = "btn_cancelDownload";
            this.btn_cancelDownload.Size = new System.Drawing.Size(24, 24);
            this.btn_cancelDownload.TabIndex = 12;
            this.btn_cancelDownload.TabStop = false;
            this.toolTip.SetToolTip(this.btn_cancelDownload, "Cancel download");
            this.btn_cancelDownload.Click += new System.EventHandler(this.btn_cancelDownload_Click);
            this.btn_cancelDownload.MouseEnter += new System.EventHandler(this.btn_cancelDownload_MouseEnter);
            this.btn_cancelDownload.MouseLeave += new System.EventHandler(this.btn_cancelDownload_MouseLeave);
            // 
            // dlg_folderBrowser
            // 
            this.dlg_folderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.dlg_folderBrowser.ShowNewFolderButton = false;
            // 
            // flowAddonsMenu
            // 
            this.flowAddonsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.flowAddonsMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowAddonsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_reloadPacks,
            this.tsmi_addPrivatePack});
            this.flowAddonsMenu.Name = "flowAddonsMenu";
            this.flowAddonsMenu.ShowImageMargin = false;
            this.flowAddonsMenu.ShowItemToolTips = false;
            this.flowAddonsMenu.Size = new System.Drawing.Size(139, 48);
            // 
            // tsmi_reloadPacks
            // 
            this.tsmi_reloadPacks.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmi_reloadPacks.Name = "tsmi_reloadPacks";
            this.tsmi_reloadPacks.Size = new System.Drawing.Size(138, 22);
            this.tsmi_reloadPacks.Text = "Reload packs";
            this.tsmi_reloadPacks.Click += new System.EventHandler(this.reloadPacksToolStripMenuItem_Click);
            // 
            // tsmi_addPrivatePack
            // 
            this.tsmi_addPrivatePack.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmi_addPrivatePack.Name = "tsmi_addPrivatePack";
            this.tsmi_addPrivatePack.Size = new System.Drawing.Size(138, 22);
            this.tsmi_addPrivatePack.Text = "Add private pack";
            this.tsmi_addPrivatePack.Click += new System.EventHandler(this.addPrivatePackToolStripMenuItem_Click);
            // 
            // repositoryMenu
            // 
            this.repositoryMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.repositoryMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_selectedAddonName,
            this.tsmi_openAddonFolder,
            this.tsmi_openLocalFolder,
            this.repositorymenu_separator,
            this.tsmi_reloadRepository,
            this.tsmi_manageRepository});
            this.repositoryMenu.Name = "flowAddonsMenu";
            this.repositoryMenu.ShowImageMargin = false;
            this.repositoryMenu.ShowItemToolTips = false;
            this.repositoryMenu.Size = new System.Drawing.Size(197, 120);
            this.repositoryMenu.Opening += new System.ComponentModel.CancelEventHandler(this.repositoryMenu_Opening);
            // 
            // tsmi_selectedAddonName
            // 
            this.tsmi_selectedAddonName.Enabled = false;
            this.tsmi_selectedAddonName.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmi_selectedAddonName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmi_selectedAddonName.Name = "tsmi_selectedAddonName";
            this.tsmi_selectedAddonName.Size = new System.Drawing.Size(196, 22);
            this.tsmi_selectedAddonName.Text = "%AddonName%";
            this.tsmi_selectedAddonName.Visible = false;
            // 
            // tsmi_openAddonFolder
            // 
            this.tsmi_openAddonFolder.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmi_openAddonFolder.Name = "tsmi_openAddonFolder";
            this.tsmi_openAddonFolder.Size = new System.Drawing.Size(196, 22);
            this.tsmi_openAddonFolder.Text = "Open addon folder";
            this.tsmi_openAddonFolder.Click += new System.EventHandler(this.openAddonFolderToolStripMenuItem_Click);
            // 
            // tsmi_openLocalFolder
            // 
            this.tsmi_openLocalFolder.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmi_openLocalFolder.Name = "tsmi_openLocalFolder";
            this.tsmi_openLocalFolder.Size = new System.Drawing.Size(196, 22);
            this.tsmi_openLocalFolder.Text = "Open local repository folder";
            this.tsmi_openLocalFolder.Click += new System.EventHandler(this.tsmi_openLocalFolder_Click);
            // 
            // repositorymenu_separator
            // 
            this.repositorymenu_separator.Name = "repositorymenu_separator";
            this.repositorymenu_separator.Size = new System.Drawing.Size(193, 6);
            // 
            // tsmi_reloadRepository
            // 
            this.tsmi_reloadRepository.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmi_reloadRepository.Name = "tsmi_reloadRepository";
            this.tsmi_reloadRepository.Size = new System.Drawing.Size(196, 22);
            this.tsmi_reloadRepository.Text = "Reload repository";
            this.tsmi_reloadRepository.Click += new System.EventHandler(this.tsmi_reloadRepository_Click);
            // 
            // tsmi_manageRepository
            // 
            this.tsmi_manageRepository.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmi_manageRepository.Name = "tsmi_manageRepository";
            this.tsmi_manageRepository.Size = new System.Drawing.Size(196, 22);
            this.tsmi_manageRepository.Text = "Manage repository";
            this.tsmi_manageRepository.Click += new System.EventHandler(this.manageRepositoryToolStripMenuItem_Click);
            // 
            // optionaladdonsMenu
            // 
            this.optionaladdonsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.optionaladdonsMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionaladdonsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_openOptionalFolder,
            this.toolStripSeparator2,
            this.tsmi_reloadOptional});
            this.optionaladdonsMenu.Name = "flowAddonsMenu";
            this.optionaladdonsMenu.ShowImageMargin = false;
            this.optionaladdonsMenu.ShowItemToolTips = false;
            this.optionaladdonsMenu.Size = new System.Drawing.Size(150, 54);
            this.optionaladdonsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.optionaladdonsMenu_Opening);
            // 
            // tsmi_openOptionalFolder
            // 
            this.tsmi_openOptionalFolder.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmi_openOptionalFolder.Name = "tsmi_openOptionalFolder";
            this.tsmi_openOptionalFolder.Size = new System.Drawing.Size(149, 22);
            this.tsmi_openOptionalFolder.Text = "Open addon folder";
            this.tsmi_openOptionalFolder.Click += new System.EventHandler(this.tsmi_openOptionalFolder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(146, 6);
            // 
            // tsmi_reloadOptional
            // 
            this.tsmi_reloadOptional.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmi_reloadOptional.Name = "tsmi_reloadOptional";
            this.tsmi_reloadOptional.Size = new System.Drawing.Size(149, 22);
            this.tsmi_reloadOptional.Text = "Reload addons";
            this.tsmi_reloadOptional.Click += new System.EventHandler(this.tsmi_reloadOptional_Click);
            // 
            // steamworkshopMenu
            // 
            this.steamworkshopMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.steamworkshopMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.steamworkshopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_openWorkshopFolder,
            this.toolStripSeparator1,
            this.tsmi_workshopReload});
            this.steamworkshopMenu.Name = "flowAddonsMenu";
            this.steamworkshopMenu.ShowImageMargin = false;
            this.steamworkshopMenu.ShowItemToolTips = false;
            this.steamworkshopMenu.Size = new System.Drawing.Size(150, 54);
            this.steamworkshopMenu.Opening += new System.ComponentModel.CancelEventHandler(this.steamworkshopMenu_Opening);
            // 
            // tsmi_openWorkshopFolder
            // 
            this.tsmi_openWorkshopFolder.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmi_openWorkshopFolder.Name = "tsmi_openWorkshopFolder";
            this.tsmi_openWorkshopFolder.Size = new System.Drawing.Size(149, 22);
            this.tsmi_openWorkshopFolder.Text = "Open addon folder";
            this.tsmi_openWorkshopFolder.Click += new System.EventHandler(this.tsmi_openWorkshopFolder_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // tsmi_workshopReload
            // 
            this.tsmi_workshopReload.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.tsmi_workshopReload.Name = "tsmi_workshopReload";
            this.tsmi_workshopReload.Size = new System.Drawing.Size(149, 22);
            this.tsmi_workshopReload.Text = "Reload addons";
            this.tsmi_workshopReload.Click += new System.EventHandler(this.tsmi_workshopReload_Click);
            // 
            // win_mainWindow
            // 
            this.win_mainWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.win_mainWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.win_mainWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.win_mainWindow.Controls.Add(this.snackbar_mainWindow);
            this.win_mainWindow.Controls.Add(this.panel_sideMenu);
            this.win_mainWindow.Controls.Add(this.panel_mainPanel);
            this.win_mainWindow.Controls.Add(this.win_titleBar);
            this.win_mainWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.win_mainWindow.Location = new System.Drawing.Point(0, 0);
            this.win_mainWindow.Name = "win_mainWindow";
            this.win_mainWindow.Size = new System.Drawing.Size(1300, 700);
            this.win_mainWindow.TabIndex = 2;
            // 
            // snackbar_mainWindow
            // 
            this.snackbar_mainWindow.ButtonText = "";
            this.snackbar_mainWindow.Depth = 0;
            this.snackbar_mainWindow.Font = new System.Drawing.Font("Roboto", 9F);
            this.snackbar_mainWindow.FontSize = 9;
            this.snackbar_mainWindow.Location = new System.Drawing.Point(505, 638);
            this.snackbar_mainWindow.MouseState = MaterialSkin.MouseState.HOVER;
            this.snackbar_mainWindow.Name = "snackbar_mainWindow";
            this.snackbar_mainWindow.Primary = true;
            this.snackbar_mainWindow.RoundedCornerRadius = 1;
            this.snackbar_mainWindow.Shadow = null;
            this.snackbar_mainWindow.ShadowShape = null;
            this.snackbar_mainWindow.ShowButton = false;
            this.snackbar_mainWindow.Size = new System.Drawing.Size(288, 48);
            this.snackbar_mainWindow.TabIndex = 5;
            this.snackbar_mainWindow.Text = "%Message%";
            this.snackbar_mainWindow.Visible = false;
            // 
            // panel_sideMenu
            // 
            this.panel_sideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.panel_sideMenu.Controls.Add(this.sidemenu_menuList);
            this.panel_sideMenu.Controls.Add(this.sidemenu_botPanel);
            this.panel_sideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_sideMenu.Location = new System.Drawing.Point(0, 30);
            this.panel_sideMenu.MaximumSize = new System.Drawing.Size(300, 0);
            this.panel_sideMenu.MinimumSize = new System.Drawing.Size(0, 670);
            this.panel_sideMenu.Name = "panel_sideMenu";
            this.panel_sideMenu.Size = new System.Drawing.Size(10, 670);
            this.panel_sideMenu.TabIndex = 1;
            // 
            // sidemenu_menuList
            // 
            this.sidemenu_menuList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sidemenu_menuList.Controls.Add(this.doubleBufferPanel5);
            this.sidemenu_menuList.Controls.Add(this.doubleBufferPanel6);
            this.sidemenu_menuList.Controls.Add(this.doubleBufferPanel7);
            this.sidemenu_menuList.Controls.Add(this.doubleBufferPanel8);
            this.sidemenu_menuList.Controls.Add(this.doubleBufferPanel9);
            this.sidemenu_menuList.Controls.Add(this.doubleBufferPanel10);
            this.sidemenu_menuList.Controls.Add(this.doubleBufferPanel11);
            this.sidemenu_menuList.Location = new System.Drawing.Point(-290, 0);
            this.sidemenu_menuList.Margin = new System.Windows.Forms.Padding(0);
            this.sidemenu_menuList.Name = "sidemenu_menuList";
            this.sidemenu_menuList.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.sidemenu_menuList.Size = new System.Drawing.Size(300, 599);
            this.sidemenu_menuList.TabIndex = 11;
            // 
            // doubleBufferPanel5
            // 
            this.doubleBufferPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleBufferPanel5.Controls.Add(this.menu_addonPacks);
            this.doubleBufferPanel5.Location = new System.Drawing.Point(0, 20);
            this.doubleBufferPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.doubleBufferPanel5.MaximumSize = new System.Drawing.Size(300, 30);
            this.doubleBufferPanel5.MinimumSize = new System.Drawing.Size(300, 30);
            this.doubleBufferPanel5.Name = "doubleBufferPanel5";
            this.doubleBufferPanel5.Size = new System.Drawing.Size(300, 30);
            this.doubleBufferPanel5.TabIndex = 0;
            // 
            // menu_addonPacks
            // 
            this.menu_addonPacks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menu_addonPacks.AutoSize = true;
            this.menu_addonPacks.BackColor = System.Drawing.Color.Transparent;
            this.menu_addonPacks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_addonPacks.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.menu_addonPacks.Location = new System.Drawing.Point(10, 1);
            this.menu_addonPacks.Name = "menu_addonPacks";
            this.menu_addonPacks.Size = new System.Drawing.Size(174, 31);
            this.menu_addonPacks.TabIndex = 2;
            this.menu_addonPacks.Text = "Addon Packs";
            this.menu_addonPacks.Click += new System.EventHandler(this.menu_addonPacks_Click);
            this.menu_addonPacks.MouseEnter += new System.EventHandler(this.menu_addonPacks_MouseEnter);
            this.menu_addonPacks.MouseLeave += new System.EventHandler(this.menu_addonPacks_MouseLeave);
            // 
            // doubleBufferPanel6
            // 
            this.doubleBufferPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleBufferPanel6.BackColor = System.Drawing.Color.DimGray;
            this.doubleBufferPanel6.Location = new System.Drawing.Point(15, 55);
            this.doubleBufferPanel6.Margin = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.doubleBufferPanel6.Name = "doubleBufferPanel6";
            this.doubleBufferPanel6.Size = new System.Drawing.Size(270, 1);
            this.doubleBufferPanel6.TabIndex = 11;
            // 
            // doubleBufferPanel7
            // 
            this.doubleBufferPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleBufferPanel7.Controls.Add(this.menu_launchOptions);
            this.doubleBufferPanel7.Location = new System.Drawing.Point(0, 61);
            this.doubleBufferPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.doubleBufferPanel7.MaximumSize = new System.Drawing.Size(300, 30);
            this.doubleBufferPanel7.MinimumSize = new System.Drawing.Size(300, 30);
            this.doubleBufferPanel7.Name = "doubleBufferPanel7";
            this.doubleBufferPanel7.Size = new System.Drawing.Size(300, 30);
            this.doubleBufferPanel7.TabIndex = 12;
            // 
            // menu_launchOptions
            // 
            this.menu_launchOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menu_launchOptions.AutoSize = true;
            this.menu_launchOptions.BackColor = System.Drawing.Color.Transparent;
            this.menu_launchOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_launchOptions.Location = new System.Drawing.Point(10, 1);
            this.menu_launchOptions.Name = "menu_launchOptions";
            this.menu_launchOptions.Size = new System.Drawing.Size(204, 31);
            this.menu_launchOptions.TabIndex = 3;
            this.menu_launchOptions.Text = "Launch Options";
            this.menu_launchOptions.Click += new System.EventHandler(this.menu_launchOptions_Click);
            this.menu_launchOptions.MouseEnter += new System.EventHandler(this.menu_launchOptions_MouseEnter);
            this.menu_launchOptions.MouseLeave += new System.EventHandler(this.menu_launchOptions_MouseLeave);
            // 
            // doubleBufferPanel8
            // 
            this.doubleBufferPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleBufferPanel8.BackColor = System.Drawing.Color.DimGray;
            this.doubleBufferPanel8.Location = new System.Drawing.Point(15, 96);
            this.doubleBufferPanel8.Margin = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.doubleBufferPanel8.Name = "doubleBufferPanel8";
            this.doubleBufferPanel8.Size = new System.Drawing.Size(270, 1);
            this.doubleBufferPanel8.TabIndex = 13;
            // 
            // doubleBufferPanel9
            // 
            this.doubleBufferPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleBufferPanel9.Controls.Add(this.menu_repositoryDownloads);
            this.doubleBufferPanel9.Controls.Add(this.img_repoBusy);
            this.doubleBufferPanel9.Location = new System.Drawing.Point(0, 102);
            this.doubleBufferPanel9.Margin = new System.Windows.Forms.Padding(0);
            this.doubleBufferPanel9.MaximumSize = new System.Drawing.Size(300, 30);
            this.doubleBufferPanel9.MinimumSize = new System.Drawing.Size(300, 30);
            this.doubleBufferPanel9.Name = "doubleBufferPanel9";
            this.doubleBufferPanel9.Size = new System.Drawing.Size(300, 30);
            this.doubleBufferPanel9.TabIndex = 14;
            // 
            // menu_repositoryDownloads
            // 
            this.menu_repositoryDownloads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menu_repositoryDownloads.AutoSize = true;
            this.menu_repositoryDownloads.BackColor = System.Drawing.Color.Transparent;
            this.menu_repositoryDownloads.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_repositoryDownloads.Location = new System.Drawing.Point(10, 1);
            this.menu_repositoryDownloads.Name = "menu_repositoryDownloads";
            this.menu_repositoryDownloads.Size = new System.Drawing.Size(287, 31);
            this.menu_repositoryDownloads.TabIndex = 4;
            this.menu_repositoryDownloads.Text = "Repository Downloads";
            this.menu_repositoryDownloads.Click += new System.EventHandler(this.menu_repositoryDownloads_Click);
            this.menu_repositoryDownloads.MouseEnter += new System.EventHandler(this.menu_repositoryDownloads_MouseEnter);
            this.menu_repositoryDownloads.MouseLeave += new System.EventHandler(this.menu_repositoryDownloads_MouseLeave);
            // 
            // img_repoBusy
            // 
            this.img_repoBusy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.img_repoBusy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.img_repoBusy.Image = global::arma3Launcher.Properties.Resources.sidemenu_busy_32;
            this.img_repoBusy.Location = new System.Drawing.Point(259, -1);
            this.img_repoBusy.Name = "img_repoBusy";
            this.img_repoBusy.Size = new System.Drawing.Size(32, 32);
            this.img_repoBusy.TabIndex = 9;
            this.img_repoBusy.TabStop = false;
            this.img_repoBusy.Visible = false;
            // 
            // doubleBufferPanel10
            // 
            this.doubleBufferPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleBufferPanel10.BackColor = System.Drawing.Color.DimGray;
            this.doubleBufferPanel10.Location = new System.Drawing.Point(15, 137);
            this.doubleBufferPanel10.Margin = new System.Windows.Forms.Padding(15, 5, 15, 5);
            this.doubleBufferPanel10.Name = "doubleBufferPanel10";
            this.doubleBufferPanel10.Size = new System.Drawing.Size(270, 1);
            this.doubleBufferPanel10.TabIndex = 15;
            // 
            // doubleBufferPanel11
            // 
            this.doubleBufferPanel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleBufferPanel11.Controls.Add(this.menu_preferences);
            this.doubleBufferPanel11.Location = new System.Drawing.Point(0, 143);
            this.doubleBufferPanel11.Margin = new System.Windows.Forms.Padding(0);
            this.doubleBufferPanel11.MaximumSize = new System.Drawing.Size(300, 30);
            this.doubleBufferPanel11.MinimumSize = new System.Drawing.Size(300, 30);
            this.doubleBufferPanel11.Name = "doubleBufferPanel11";
            this.doubleBufferPanel11.Size = new System.Drawing.Size(300, 30);
            this.doubleBufferPanel11.TabIndex = 16;
            // 
            // menu_preferences
            // 
            this.menu_preferences.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menu_preferences.AutoSize = true;
            this.menu_preferences.BackColor = System.Drawing.Color.Transparent;
            this.menu_preferences.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_preferences.Location = new System.Drawing.Point(10, 1);
            this.menu_preferences.Name = "menu_preferences";
            this.menu_preferences.Size = new System.Drawing.Size(161, 31);
            this.menu_preferences.TabIndex = 5;
            this.menu_preferences.Text = "Preferences";
            this.menu_preferences.Click += new System.EventHandler(this.menu_preferences_Click);
            this.menu_preferences.MouseEnter += new System.EventHandler(this.menu_preferences_MouseEnter);
            this.menu_preferences.MouseLeave += new System.EventHandler(this.menu_preferences_MouseLeave);
            // 
            // sidemenu_botPanel
            // 
            this.sidemenu_botPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(47)))));
            this.sidemenu_botPanel.Controls.Add(this.menu_help);
            this.sidemenu_botPanel.Controls.Add(this.menu_about);
            this.sidemenu_botPanel.Controls.Add(this.txt_versionNumber);
            this.sidemenu_botPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sidemenu_botPanel.Location = new System.Drawing.Point(0, 597);
            this.sidemenu_botPanel.Name = "sidemenu_botPanel";
            this.sidemenu_botPanel.Size = new System.Drawing.Size(10, 73);
            this.sidemenu_botPanel.TabIndex = 10;
            // 
            // menu_help
            // 
            this.menu_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.menu_help.AutoSize = true;
            this.menu_help.BackColor = System.Drawing.Color.Transparent;
            this.menu_help.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.menu_help.ForeColor = System.Drawing.Color.Silver;
            this.menu_help.Location = new System.Drawing.Point(-277, 17);
            this.menu_help.Name = "menu_help";
            this.menu_help.Size = new System.Drawing.Size(36, 16);
            this.menu_help.TabIndex = 6;
            this.menu_help.Text = "Help";
            this.menu_help.Click += new System.EventHandler(this.menu_help_Click);
            this.menu_help.MouseEnter += new System.EventHandler(this.menu_help_MouseEnter);
            this.menu_help.MouseLeave += new System.EventHandler(this.menu_help_MouseLeave);
            // 
            // menu_about
            // 
            this.menu_about.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.menu_about.AutoSize = true;
            this.menu_about.BackColor = System.Drawing.Color.Transparent;
            this.menu_about.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.menu_about.ForeColor = System.Drawing.Color.Silver;
            this.menu_about.Location = new System.Drawing.Point(-277, 40);
            this.menu_about.Name = "menu_about";
            this.menu_about.Size = new System.Drawing.Size(42, 16);
            this.menu_about.TabIndex = 7;
            this.menu_about.Text = "About";
            this.menu_about.Click += new System.EventHandler(this.menu_about_Click);
            this.menu_about.MouseEnter += new System.EventHandler(this.menu_about_MouseEnter);
            this.menu_about.MouseLeave += new System.EventHandler(this.menu_about_MouseLeave);
            // 
            // txt_versionNumber
            // 
            this.txt_versionNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_versionNumber.AutoSize = true;
            this.txt_versionNumber.BackColor = System.Drawing.Color.Transparent;
            this.txt_versionNumber.Font = new System.Drawing.Font("Consolas", 7.25F);
            this.txt_versionNumber.ForeColor = System.Drawing.Color.DarkGray;
            this.txt_versionNumber.Location = new System.Drawing.Point(-48, 43);
            this.txt_versionNumber.Name = "txt_versionNumber";
            this.txt_versionNumber.Size = new System.Drawing.Size(50, 12);
            this.txt_versionNumber.TabIndex = 8;
            this.txt_versionNumber.Text = "%version%";
            this.txt_versionNumber.Click += new System.EventHandler(this.txt_versionNumber_Click);
            this.txt_versionNumber.Paint += new System.Windows.Forms.PaintEventHandler(this.txt_versionNumber_Paint);
            this.txt_versionNumber.MouseEnter += new System.EventHandler(this.txt_versionNumber_MouseEnter);
            this.txt_versionNumber.MouseLeave += new System.EventHandler(this.txt_versionNumber_MouseLeave);
            // 
            // panel_mainPanel
            // 
            this.panel_mainPanel.BackgroundImage = global::arma3Launcher.Properties.Resources.panel_seperator;
            this.panel_mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_mainPanel.Controls.Add(this.panel_outterPanel);
            this.panel_mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_mainPanel.Location = new System.Drawing.Point(0, 30);
            this.panel_mainPanel.Name = "panel_mainPanel";
            this.panel_mainPanel.Size = new System.Drawing.Size(1298, 668);
            this.panel_mainPanel.TabIndex = 2;
            // 
            // panel_outterPanel
            // 
            this.panel_outterPanel.BackColor = System.Drawing.Color.DimGray;
            this.panel_outterPanel.Controls.Add(this.panel_launchOptions);
            this.panel_outterPanel.Controls.Add(this.panel_preferences);
            this.panel_outterPanel.Controls.Add(this.panel_repositoryDownloads);
            this.panel_outterPanel.Controls.Add(this.panel_addonPacks);
            this.panel_outterPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_outterPanel.Location = new System.Drawing.Point(0, 0);
            this.panel_outterPanel.MinimumSize = new System.Drawing.Size(0, 670);
            this.panel_outterPanel.Name = "panel_outterPanel";
            this.panel_outterPanel.Size = new System.Drawing.Size(1300, 670);
            this.panel_outterPanel.TabIndex = 0;
            // 
            // panel_launchOptions
            // 
            this.panel_launchOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel_launchOptions.Controls.Add(this.panel_contentLaunchOptions);
            this.panel_launchOptions.Controls.Add(this.lbl_launchOptions);
            this.panel_launchOptions.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_launchOptions.Location = new System.Drawing.Point(3900, 0);
            this.panel_launchOptions.Name = "panel_launchOptions";
            this.panel_launchOptions.Size = new System.Drawing.Size(1300, 670);
            this.panel_launchOptions.TabIndex = 1;
            // 
            // panel_contentLaunchOptions
            // 
            this.panel_contentLaunchOptions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_contentLaunchOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel_contentLaunchOptions.Controls.Add(this.panel_serverOptions_vSep);
            this.panel_contentLaunchOptions.Controls.Add(this.panel_launchOptionsCenter);
            this.panel_contentLaunchOptions.Controls.Add(this.flowpanel_serverOptions);
            this.panel_contentLaunchOptions.Controls.Add(this.panel1);
            this.panel_contentLaunchOptions.Controls.Add(this.flowpanel_launchOptionsChb);
            this.panel_contentLaunchOptions.Location = new System.Drawing.Point(32, 80);
            this.panel_contentLaunchOptions.Name = "panel_contentLaunchOptions";
            this.panel_contentLaunchOptions.Size = new System.Drawing.Size(1240, 560);
            this.panel_contentLaunchOptions.TabIndex = 4;
            // 
            // panel_serverOptions_vSep
            // 
            this.panel_serverOptions_vSep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.panel_serverOptions_vSep.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_serverOptions_vSep.Location = new System.Drawing.Point(922, 0);
            this.panel_serverOptions_vSep.Name = "panel_serverOptions_vSep";
            this.panel_serverOptions_vSep.Size = new System.Drawing.Size(2, 560);
            this.panel_serverOptions_vSep.TabIndex = 21;
            this.panel_serverOptions_vSep.Visible = false;
            // 
            // panel_launchOptionsCenter
            // 
            this.panel_launchOptionsCenter.Controls.Add(this.cb_malloc);
            this.panel_launchOptionsCenter.Controls.Add(this.btn_memDecrease);
            this.panel_launchOptionsCenter.Controls.Add(this.lbl_clientProfile);
            this.panel_launchOptionsCenter.Controls.Add(this.chb_malloc);
            this.panel_launchOptionsCenter.Controls.Add(this.cb_exThreads);
            this.panel_launchOptionsCenter.Controls.Add(this.chb_exThreads);
            this.panel_launchOptionsCenter.Controls.Add(this.cb_cpuCount);
            this.panel_launchOptionsCenter.Controls.Add(this.chb_cpuCount);
            this.panel_launchOptionsCenter.Controls.Add(this.cb_clientProfile);
            this.panel_launchOptionsCenter.Controls.Add(this.num_maxMem);
            this.panel_launchOptionsCenter.Controls.Add(this.chb_maxMem);
            this.panel_launchOptionsCenter.Controls.Add(this.btn_memIncrease);
            this.panel_launchOptionsCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_launchOptionsCenter.Location = new System.Drawing.Point(230, 0);
            this.panel_launchOptionsCenter.Name = "panel_launchOptionsCenter";
            this.panel_launchOptionsCenter.Size = new System.Drawing.Size(694, 560);
            this.panel_launchOptionsCenter.TabIndex = 20;
            // 
            // cb_malloc
            // 
            this.cb_malloc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_malloc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cb_malloc.Enabled = false;
            this.cb_malloc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_malloc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.cb_malloc.FormattingEnabled = true;
            this.cb_malloc.ItemHeight = 23;
            this.cb_malloc.Location = new System.Drawing.Point(129, 209);
            this.cb_malloc.Margin = new System.Windows.Forms.Padding(0);
            this.cb_malloc.Name = "cb_malloc";
            this.cb_malloc.Size = new System.Drawing.Size(548, 29);
            this.cb_malloc.Style = MetroFramework.MetroColorStyle.Lime;
            this.cb_malloc.TabIndex = 17;
            this.cb_malloc.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cb_malloc.UseSelectable = true;
            // 
            // btn_memDecrease
            // 
            this.btn_memDecrease.AutoSize = true;
            this.btn_memDecrease.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_memDecrease.Depth = 0;
            this.btn_memDecrease.Enabled = false;
            this.btn_memDecrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_memDecrease.Icon = null;
            this.btn_memDecrease.Location = new System.Drawing.Point(278, 55);
            this.btn_memDecrease.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_memDecrease.MaximumSize = new System.Drawing.Size(29, 29);
            this.btn_memDecrease.MinimumSize = new System.Drawing.Size(29, 29);
            this.btn_memDecrease.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_memDecrease.Name = "btn_memDecrease";
            this.btn_memDecrease.Primary = false;
            this.btn_memDecrease.Shadow = null;
            this.btn_memDecrease.ShadowShape = null;
            this.btn_memDecrease.Size = new System.Drawing.Size(29, 29);
            this.btn_memDecrease.TabIndex = 20;
            this.btn_memDecrease.Text = "─";
            this.btn_memDecrease.Click += new System.EventHandler(this.btn_memDecrease_Click);
            // 
            // lbl_clientProfile
            // 
            this.lbl_clientProfile.AutoSize = true;
            this.lbl_clientProfile.Depth = 0;
            this.lbl_clientProfile.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_clientProfile.FontSize = 11;
            this.lbl_clientProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_clientProfile.Location = new System.Drawing.Point(14, 14);
            this.lbl_clientProfile.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lbl_clientProfile.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_clientProfile.Name = "lbl_clientProfile";
            this.lbl_clientProfile.Primary = false;
            this.lbl_clientProfile.Shadow = null;
            this.lbl_clientProfile.ShadowShape = null;
            this.lbl_clientProfile.Size = new System.Drawing.Size(96, 19);
            this.lbl_clientProfile.TabIndex = 18;
            this.lbl_clientProfile.Text = "Client Profile";
            // 
            // chb_malloc
            // 
            this.chb_malloc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chb_malloc.AutoSize = true;
            this.chb_malloc.Checked = false;
            this.chb_malloc.Depth = 0;
            this.chb_malloc.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_malloc.Location = new System.Drawing.Point(18, 207);
            this.chb_malloc.Margin = new System.Windows.Forms.Padding(0);
            this.chb_malloc.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_malloc.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_malloc.Name = "chb_malloc";
            this.chb_malloc.Ripple = true;
            this.chb_malloc.Shadow = null;
            this.chb_malloc.ShadowShape = null;
            this.chb_malloc.Size = new System.Drawing.Size(76, 30);
            this.chb_malloc.TabIndex = 9;
            this.chb_malloc.Text = "-malloc";
            this.chb_malloc.CheckedChanged += new MaterialSkin.Controls.MaterialCheckBox.CheckedChangedEventHandler(this.chb_malloc_CheckedChanged);
            // 
            // cb_exThreads
            // 
            this.cb_exThreads.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cb_exThreads.Enabled = false;
            this.cb_exThreads.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_exThreads.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.cb_exThreads.FormattingEnabled = true;
            this.cb_exThreads.ItemHeight = 23;
            this.cb_exThreads.Location = new System.Drawing.Point(129, 157);
            this.cb_exThreads.Margin = new System.Windows.Forms.Padding(3, 0, 8, 3);
            this.cb_exThreads.Name = "cb_exThreads";
            this.cb_exThreads.Size = new System.Drawing.Size(548, 29);
            this.cb_exThreads.Style = MetroFramework.MetroColorStyle.Lime;
            this.cb_exThreads.TabIndex = 5;
            this.cb_exThreads.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cb_exThreads.UseSelectable = true;
            // 
            // chb_exThreads
            // 
            this.chb_exThreads.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chb_exThreads.AutoSize = true;
            this.chb_exThreads.Checked = false;
            this.chb_exThreads.Depth = 0;
            this.chb_exThreads.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_exThreads.Location = new System.Drawing.Point(18, 156);
            this.chb_exThreads.Margin = new System.Windows.Forms.Padding(0);
            this.chb_exThreads.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_exThreads.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_exThreads.Name = "chb_exThreads";
            this.chb_exThreads.Ripple = true;
            this.chb_exThreads.Shadow = null;
            this.chb_exThreads.ShadowShape = null;
            this.chb_exThreads.Size = new System.Drawing.Size(99, 30);
            this.chb_exThreads.TabIndex = 1;
            this.chb_exThreads.Text = "-exThreads";
            this.chb_exThreads.CheckedChanged += new MaterialSkin.Controls.MaterialCheckBox.CheckedChangedEventHandler(this.chb_exThreads_CheckedChanged);
            // 
            // cb_cpuCount
            // 
            this.cb_cpuCount.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cb_cpuCount.Enabled = false;
            this.cb_cpuCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cpuCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.cb_cpuCount.FormattingEnabled = true;
            this.cb_cpuCount.ItemHeight = 23;
            this.cb_cpuCount.Location = new System.Drawing.Point(129, 105);
            this.cb_cpuCount.Margin = new System.Windows.Forms.Padding(3, 0, 8, 3);
            this.cb_cpuCount.Name = "cb_cpuCount";
            this.cb_cpuCount.Size = new System.Drawing.Size(548, 29);
            this.cb_cpuCount.Style = MetroFramework.MetroColorStyle.Lime;
            this.cb_cpuCount.TabIndex = 5;
            this.cb_cpuCount.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cb_cpuCount.UseSelectable = true;
            // 
            // chb_cpuCount
            // 
            this.chb_cpuCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chb_cpuCount.AutoSize = true;
            this.chb_cpuCount.Checked = false;
            this.chb_cpuCount.Depth = 0;
            this.chb_cpuCount.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_cpuCount.Location = new System.Drawing.Point(18, 105);
            this.chb_cpuCount.Margin = new System.Windows.Forms.Padding(0);
            this.chb_cpuCount.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_cpuCount.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_cpuCount.Name = "chb_cpuCount";
            this.chb_cpuCount.Ripple = true;
            this.chb_cpuCount.Shadow = null;
            this.chb_cpuCount.ShadowShape = null;
            this.chb_cpuCount.Size = new System.Drawing.Size(94, 30);
            this.chb_cpuCount.TabIndex = 8;
            this.chb_cpuCount.Text = "-cpuCount";
            this.chb_cpuCount.CheckedChanged += new MaterialSkin.Controls.MaterialCheckBox.CheckedChangedEventHandler(this.chb_cpuCount_CheckedChanged);
            // 
            // cb_clientProfile
            // 
            this.cb_clientProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_clientProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.cb_clientProfile.FormattingEnabled = true;
            this.cb_clientProfile.ItemHeight = 23;
            this.cb_clientProfile.Location = new System.Drawing.Point(129, 10);
            this.cb_clientProfile.Margin = new System.Windows.Forms.Padding(3, 0, 8, 3);
            this.cb_clientProfile.Name = "cb_clientProfile";
            this.cb_clientProfile.Size = new System.Drawing.Size(548, 29);
            this.cb_clientProfile.Style = MetroFramework.MetroColorStyle.Lime;
            this.cb_clientProfile.TabIndex = 4;
            this.cb_clientProfile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cb_clientProfile.UseSelectable = true;
            // 
            // num_maxMem
            // 
            // 
            // 
            // 
            this.num_maxMem.CustomButton.Image = null;
            this.num_maxMem.CustomButton.Location = new System.Drawing.Point(119, 1);
            this.num_maxMem.CustomButton.Name = "";
            this.num_maxMem.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.num_maxMem.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.num_maxMem.CustomButton.TabIndex = 1;
            this.num_maxMem.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.num_maxMem.CustomButton.UseSelectable = true;
            this.num_maxMem.CustomButton.Visible = false;
            this.num_maxMem.Enabled = false;
            this.num_maxMem.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.num_maxMem.Lines = new string[] {
        "256"};
            this.num_maxMem.Location = new System.Drawing.Point(129, 55);
            this.num_maxMem.MaxLength = 32767;
            this.num_maxMem.Name = "num_maxMem";
            this.num_maxMem.PasswordChar = '\0';
            this.num_maxMem.ReadOnly = true;
            this.num_maxMem.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.num_maxMem.SelectedText = "";
            this.num_maxMem.SelectionLength = 0;
            this.num_maxMem.SelectionStart = 0;
            this.num_maxMem.ShortcutsEnabled = true;
            this.num_maxMem.Size = new System.Drawing.Size(147, 29);
            this.num_maxMem.Style = MetroFramework.MetroColorStyle.Lime;
            this.num_maxMem.TabIndex = 19;
            this.num_maxMem.Text = "256";
            this.num_maxMem.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.num_maxMem.UseSelectable = true;
            this.num_maxMem.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.num_maxMem.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chb_maxMem
            // 
            this.chb_maxMem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chb_maxMem.AutoSize = true;
            this.chb_maxMem.Checked = false;
            this.chb_maxMem.Depth = 0;
            this.chb_maxMem.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_maxMem.Location = new System.Drawing.Point(18, 54);
            this.chb_maxMem.Margin = new System.Windows.Forms.Padding(0);
            this.chb_maxMem.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_maxMem.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_maxMem.Name = "chb_maxMem";
            this.chb_maxMem.Ripple = true;
            this.chb_maxMem.Shadow = null;
            this.chb_maxMem.ShadowShape = null;
            this.chb_maxMem.Size = new System.Drawing.Size(92, 30);
            this.chb_maxMem.TabIndex = 2;
            this.chb_maxMem.Text = "-maxMem";
            this.chb_maxMem.CheckedChanged += new MaterialSkin.Controls.MaterialCheckBox.CheckedChangedEventHandler(this.chb_maxMem_CheckedChanged);
            // 
            // btn_memIncrease
            // 
            this.btn_memIncrease.AutoSize = true;
            this.btn_memIncrease.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_memIncrease.Depth = 0;
            this.btn_memIncrease.Enabled = false;
            this.btn_memIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_memIncrease.Icon = null;
            this.btn_memIncrease.Location = new System.Drawing.Point(308, 55);
            this.btn_memIncrease.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_memIncrease.MaximumSize = new System.Drawing.Size(29, 29);
            this.btn_memIncrease.MinimumSize = new System.Drawing.Size(29, 29);
            this.btn_memIncrease.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_memIncrease.Name = "btn_memIncrease";
            this.btn_memIncrease.Primary = false;
            this.btn_memIncrease.Shadow = null;
            this.btn_memIncrease.ShadowShape = null;
            this.btn_memIncrease.Size = new System.Drawing.Size(29, 29);
            this.btn_memIncrease.TabIndex = 10;
            this.btn_memIncrease.Text = "┼";
            this.btn_memIncrease.Click += new System.EventHandler(this.btn_memIncrease_Click);
            // 
            // flowpanel_serverOptions
            // 
            this.flowpanel_serverOptions.Controls.Add(this.panel_serverOptions);
            this.flowpanel_serverOptions.Controls.Add(this.panel_serverOptions_hSep);
            this.flowpanel_serverOptions.Controls.Add(this.panel_headlessOptions);
            this.flowpanel_serverOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowpanel_serverOptions.Location = new System.Drawing.Point(924, 0);
            this.flowpanel_serverOptions.Name = "flowpanel_serverOptions";
            this.flowpanel_serverOptions.Size = new System.Drawing.Size(316, 560);
            this.flowpanel_serverOptions.TabIndex = 8;
            // 
            // panel_serverOptions
            // 
            this.panel_serverOptions.Controls.Add(this.panel23);
            this.panel_serverOptions.Controls.Add(this.panel24);
            this.panel_serverOptions.Location = new System.Drawing.Point(0, 0);
            this.panel_serverOptions.Margin = new System.Windows.Forms.Padding(0);
            this.panel_serverOptions.Name = "panel_serverOptions";
            this.panel_serverOptions.Size = new System.Drawing.Size(316, 232);
            this.panel_serverOptions.TabIndex = 6;
            this.panel_serverOptions.Visible = false;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.materialLabel7);
            this.panel23.Controls.Add(this.cb_serverMission);
            this.panel23.Controls.Add(this.materialLabel6);
            this.panel23.Controls.Add(this.cb_serverPack);
            this.panel23.Controls.Add(this.materialLabel2);
            this.panel23.Controls.Add(this.materialLabel1);
            this.panel23.Controls.Add(this.cb_serverProfile);
            this.panel23.Controls.Add(this.cb_serverConfig);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel23.Location = new System.Drawing.Point(0, 35);
            this.panel23.Name = "panel23";
            this.panel23.Padding = new System.Windows.Forms.Padding(8);
            this.panel23.Size = new System.Drawing.Size(316, 197);
            this.panel23.TabIndex = 1;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.FontSize = 11;
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(12, 155);
            this.materialLabel7.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Primary = false;
            this.materialLabel7.Shadow = null;
            this.materialLabel7.ShadowShape = null;
            this.materialLabel7.Size = new System.Drawing.Size(63, 19);
            this.materialLabel7.TabIndex = 24;
            this.materialLabel7.Text = "Mission";
            // 
            // cb_serverMission
            // 
            this.cb_serverMission.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cb_serverMission.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cb_serverMission.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cb_serverMission.FormattingEnabled = true;
            this.cb_serverMission.ItemHeight = 23;
            this.cb_serverMission.Location = new System.Drawing.Point(116, 150);
            this.cb_serverMission.Name = "cb_serverMission";
            this.cb_serverMission.Size = new System.Drawing.Size(188, 29);
            this.cb_serverMission.Style = MetroFramework.MetroColorStyle.Lime;
            this.cb_serverMission.TabIndex = 23;
            this.cb_serverMission.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cb_serverMission.UseSelectable = true;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.FontSize = 11;
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(12, 120);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Primary = false;
            this.materialLabel6.Shadow = null;
            this.materialLabel6.ShadowShape = null;
            this.materialLabel6.Size = new System.Drawing.Size(89, 19);
            this.materialLabel6.TabIndex = 22;
            this.materialLabel6.Text = "Addon Pack";
            // 
            // cb_serverPack
            // 
            this.cb_serverPack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cb_serverPack.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cb_serverPack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cb_serverPack.FormattingEnabled = true;
            this.cb_serverPack.ItemHeight = 23;
            this.cb_serverPack.Location = new System.Drawing.Point(116, 115);
            this.cb_serverPack.Name = "cb_serverPack";
            this.cb_serverPack.Size = new System.Drawing.Size(188, 29);
            this.cb_serverPack.Style = MetroFramework.MetroColorStyle.Lime;
            this.cb_serverPack.TabIndex = 21;
            this.cb_serverPack.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cb_serverPack.UseSelectable = true;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.FontSize = 11;
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(12, 55);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Primary = false;
            this.materialLabel2.Shadow = null;
            this.materialLabel2.ShadowShape = null;
            this.materialLabel2.Size = new System.Drawing.Size(99, 19);
            this.materialLabel2.TabIndex = 20;
            this.materialLabel2.Text = "Server Profile";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.FontSize = 11;
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(12, 19);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Primary = false;
            this.materialLabel1.Shadow = null;
            this.materialLabel1.ShadowShape = null;
            this.materialLabel1.Size = new System.Drawing.Size(81, 19);
            this.materialLabel1.TabIndex = 19;
            this.materialLabel1.Text = "Config File";
            // 
            // cb_serverProfile
            // 
            this.cb_serverProfile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cb_serverProfile.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cb_serverProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cb_serverProfile.FormattingEnabled = true;
            this.cb_serverProfile.ItemHeight = 23;
            this.cb_serverProfile.Location = new System.Drawing.Point(116, 50);
            this.cb_serverProfile.Name = "cb_serverProfile";
            this.cb_serverProfile.Size = new System.Drawing.Size(188, 29);
            this.cb_serverProfile.Style = MetroFramework.MetroColorStyle.Lime;
            this.cb_serverProfile.TabIndex = 3;
            this.cb_serverProfile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cb_serverProfile.UseSelectable = true;
            // 
            // cb_serverConfig
            // 
            this.cb_serverConfig.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cb_serverConfig.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cb_serverConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cb_serverConfig.FormattingEnabled = true;
            this.cb_serverConfig.ItemHeight = 23;
            this.cb_serverConfig.Location = new System.Drawing.Point(116, 14);
            this.cb_serverConfig.Name = "cb_serverConfig";
            this.cb_serverConfig.Size = new System.Drawing.Size(188, 29);
            this.cb_serverConfig.Style = MetroFramework.MetroColorStyle.Lime;
            this.cb_serverConfig.TabIndex = 1;
            this.cb_serverConfig.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cb_serverConfig.UseSelectable = true;
            // 
            // panel24
            // 
            this.panel24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel24.Controls.Add(this.label30);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(0, 0);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(316, 35);
            this.panel24.TabIndex = 0;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(10, 12);
            this.label30.Margin = new System.Windows.Forms.Padding(10, 5, 3, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(114, 21);
            this.label30.TabIndex = 1;
            this.label30.Text = "Server Options";
            // 
            // panel_serverOptions_hSep
            // 
            this.panel_serverOptions_hSep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.panel_serverOptions_hSep.Location = new System.Drawing.Point(10, 247);
            this.panel_serverOptions_hSep.Margin = new System.Windows.Forms.Padding(10, 15, 20, 15);
            this.panel_serverOptions_hSep.Name = "panel_serverOptions_hSep";
            this.panel_serverOptions_hSep.Size = new System.Drawing.Size(295, 2);
            this.panel_serverOptions_hSep.TabIndex = 11;
            this.panel_serverOptions_hSep.Visible = false;
            // 
            // panel_headlessOptions
            // 
            this.panel_headlessOptions.Controls.Add(this.panel25);
            this.panel_headlessOptions.Controls.Add(this.panel26);
            this.panel_headlessOptions.Location = new System.Drawing.Point(0, 264);
            this.panel_headlessOptions.Margin = new System.Windows.Forms.Padding(0);
            this.panel_headlessOptions.Name = "panel_headlessOptions";
            this.panel_headlessOptions.Size = new System.Drawing.Size(316, 134);
            this.panel_headlessOptions.TabIndex = 7;
            this.panel_headlessOptions.Visible = false;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.btn_decreaseHcInstances);
            this.panel25.Controls.Add(this.num_hcInstances);
            this.panel25.Controls.Add(this.btn_increaseHcInstances);
            this.panel25.Controls.Add(this.materialLabel4);
            this.panel25.Controls.Add(this.materialLabel3);
            this.panel25.Controls.Add(this.cb_hcProfile);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel25.Location = new System.Drawing.Point(0, 35);
            this.panel25.Name = "panel25";
            this.panel25.Padding = new System.Windows.Forms.Padding(8);
            this.panel25.Size = new System.Drawing.Size(316, 99);
            this.panel25.TabIndex = 1;
            // 
            // btn_decreaseHcInstances
            // 
            this.btn_decreaseHcInstances.AutoSize = true;
            this.btn_decreaseHcInstances.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_decreaseHcInstances.Depth = 0;
            this.btn_decreaseHcInstances.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_decreaseHcInstances.Icon = null;
            this.btn_decreaseHcInstances.Location = new System.Drawing.Point(245, 50);
            this.btn_decreaseHcInstances.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_decreaseHcInstances.MaximumSize = new System.Drawing.Size(29, 29);
            this.btn_decreaseHcInstances.MinimumSize = new System.Drawing.Size(29, 29);
            this.btn_decreaseHcInstances.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_decreaseHcInstances.Name = "btn_decreaseHcInstances";
            this.btn_decreaseHcInstances.Primary = false;
            this.btn_decreaseHcInstances.Shadow = null;
            this.btn_decreaseHcInstances.ShadowShape = null;
            this.btn_decreaseHcInstances.Size = new System.Drawing.Size(29, 29);
            this.btn_decreaseHcInstances.TabIndex = 23;
            this.btn_decreaseHcInstances.Text = "─";
            this.btn_decreaseHcInstances.Click += new System.EventHandler(this.btn_decreaseHcInstances_Click);
            // 
            // num_hcInstances
            // 
            // 
            // 
            // 
            this.num_hcInstances.CustomButton.Image = null;
            this.num_hcInstances.CustomButton.Location = new System.Drawing.Point(99, 1);
            this.num_hcInstances.CustomButton.Name = "";
            this.num_hcInstances.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.num_hcInstances.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.num_hcInstances.CustomButton.TabIndex = 1;
            this.num_hcInstances.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.num_hcInstances.CustomButton.UseSelectable = true;
            this.num_hcInstances.CustomButton.Visible = false;
            this.num_hcInstances.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.num_hcInstances.Lines = new string[] {
        "0"};
            this.num_hcInstances.Location = new System.Drawing.Point(116, 50);
            this.num_hcInstances.MaxLength = 32767;
            this.num_hcInstances.Name = "num_hcInstances";
            this.num_hcInstances.PasswordChar = '\0';
            this.num_hcInstances.ReadOnly = true;
            this.num_hcInstances.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.num_hcInstances.SelectedText = "";
            this.num_hcInstances.SelectionLength = 0;
            this.num_hcInstances.SelectionStart = 0;
            this.num_hcInstances.ShortcutsEnabled = true;
            this.num_hcInstances.Size = new System.Drawing.Size(127, 29);
            this.num_hcInstances.Style = MetroFramework.MetroColorStyle.Lime;
            this.num_hcInstances.TabIndex = 22;
            this.num_hcInstances.Text = "0";
            this.num_hcInstances.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.num_hcInstances.UseSelectable = true;
            this.num_hcInstances.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.num_hcInstances.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btn_increaseHcInstances
            // 
            this.btn_increaseHcInstances.AutoSize = true;
            this.btn_increaseHcInstances.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_increaseHcInstances.Depth = 0;
            this.btn_increaseHcInstances.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_increaseHcInstances.Icon = null;
            this.btn_increaseHcInstances.Location = new System.Drawing.Point(275, 50);
            this.btn_increaseHcInstances.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_increaseHcInstances.MaximumSize = new System.Drawing.Size(29, 29);
            this.btn_increaseHcInstances.MinimumSize = new System.Drawing.Size(29, 29);
            this.btn_increaseHcInstances.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_increaseHcInstances.Name = "btn_increaseHcInstances";
            this.btn_increaseHcInstances.Primary = false;
            this.btn_increaseHcInstances.Shadow = null;
            this.btn_increaseHcInstances.ShadowShape = null;
            this.btn_increaseHcInstances.Size = new System.Drawing.Size(29, 29);
            this.btn_increaseHcInstances.TabIndex = 21;
            this.btn_increaseHcInstances.Text = "┼";
            this.btn_increaseHcInstances.Click += new System.EventHandler(this.btn_increaseHcInstances_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.FontSize = 11;
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(12, 55);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Primary = false;
            this.materialLabel4.Shadow = null;
            this.materialLabel4.ShadowShape = null;
            this.materialLabel4.Size = new System.Drawing.Size(99, 19);
            this.materialLabel4.TabIndex = 20;
            this.materialLabel4.Text = "HC Instances";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.FontSize = 11;
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(12, 19);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Primary = false;
            this.materialLabel3.Shadow = null;
            this.materialLabel3.ShadowShape = null;
            this.materialLabel3.Size = new System.Drawing.Size(78, 19);
            this.materialLabel3.TabIndex = 19;
            this.materialLabel3.Text = "HC Profile";
            // 
            // cb_hcProfile
            // 
            this.cb_hcProfile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cb_hcProfile.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cb_hcProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cb_hcProfile.FormattingEnabled = true;
            this.cb_hcProfile.ItemHeight = 23;
            this.cb_hcProfile.Location = new System.Drawing.Point(116, 14);
            this.cb_hcProfile.Name = "cb_hcProfile";
            this.cb_hcProfile.Size = new System.Drawing.Size(188, 29);
            this.cb_hcProfile.Style = MetroFramework.MetroColorStyle.Lime;
            this.cb_hcProfile.TabIndex = 1;
            this.cb_hcProfile.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.cb_hcProfile.UseSelectable = true;
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel26.Controls.Add(this.label37);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel26.Location = new System.Drawing.Point(0, 0);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(316, 35);
            this.panel26.TabIndex = 0;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label37.Location = new System.Drawing.Point(10, 12);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(175, 21);
            this.label37.TabIndex = 1;
            this.label37.Text = "Headless Client Options";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(228, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 560);
            this.panel1.TabIndex = 9;
            // 
            // flowpanel_launchOptionsChb
            // 
            this.flowpanel_launchOptionsChb.Controls.Add(this.chb_use64Bit);
            this.flowpanel_launchOptionsChb.Controls.Add(this.chb_showScriptErrors);
            this.flowpanel_launchOptionsChb.Controls.Add(this.chb_noPause);
            this.flowpanel_launchOptionsChb.Controls.Add(this.chb_noSplash);
            this.flowpanel_launchOptionsChb.Controls.Add(this.chb_skipIntro);
            this.flowpanel_launchOptionsChb.Controls.Add(this.chb_window);
            this.flowpanel_launchOptionsChb.Controls.Add(this.chb_enableHT);
            this.flowpanel_launchOptionsChb.Controls.Add(this.chb_hugePages);
            this.flowpanel_launchOptionsChb.Controls.Add(this.chb_filePatching);
            this.flowpanel_launchOptionsChb.Controls.Add(this.chb_worldEmpty);
            this.flowpanel_launchOptionsChb.Controls.Add(this.chb_battleye);
            this.flowpanel_launchOptionsChb.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowpanel_launchOptionsChb.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowpanel_launchOptionsChb.Location = new System.Drawing.Point(0, 0);
            this.flowpanel_launchOptionsChb.Name = "flowpanel_launchOptionsChb";
            this.flowpanel_launchOptionsChb.Padding = new System.Windows.Forms.Padding(8, 8, 8, 0);
            this.flowpanel_launchOptionsChb.Size = new System.Drawing.Size(228, 560);
            this.flowpanel_launchOptionsChb.TabIndex = 3;
            // 
            // chb_use64Bit
            // 
            this.chb_use64Bit.AutoSize = true;
            this.chb_use64Bit.Checked = false;
            this.chb_use64Bit.Depth = 0;
            this.chb_use64Bit.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_use64Bit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chb_use64Bit.Location = new System.Drawing.Point(8, 8);
            this.chb_use64Bit.Margin = new System.Windows.Forms.Padding(0);
            this.chb_use64Bit.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_use64Bit.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_use64Bit.Name = "chb_use64Bit";
            this.chb_use64Bit.Ripple = true;
            this.chb_use64Bit.Shadow = null;
            this.chb_use64Bit.ShadowShape = null;
            this.chb_use64Bit.Size = new System.Drawing.Size(128, 30);
            this.chb_use64Bit.TabIndex = 12;
            this.chb_use64Bit.Text = "Run Arma 64-bit";
            this.chb_use64Bit.Visible = false;
            this.chb_use64Bit.CheckedChanged += new MaterialSkin.Controls.MaterialCheckBox.CheckedChangedEventHandler(this.chb_use64Bit_CheckedChanged);
            // 
            // chb_showScriptErrors
            // 
            this.chb_showScriptErrors.AutoSize = true;
            this.chb_showScriptErrors.Checked = false;
            this.chb_showScriptErrors.Depth = 0;
            this.chb_showScriptErrors.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_showScriptErrors.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chb_showScriptErrors.Location = new System.Drawing.Point(8, 38);
            this.chb_showScriptErrors.Margin = new System.Windows.Forms.Padding(0);
            this.chb_showScriptErrors.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_showScriptErrors.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_showScriptErrors.Name = "chb_showScriptErrors";
            this.chb_showScriptErrors.Ripple = true;
            this.chb_showScriptErrors.Shadow = null;
            this.chb_showScriptErrors.ShadowShape = null;
            this.chb_showScriptErrors.Size = new System.Drawing.Size(143, 30);
            this.chb_showScriptErrors.TabIndex = 8;
            this.chb_showScriptErrors.Tag = "-showScriptErrors";
            this.chb_showScriptErrors.Text = "Show Script Errors";
            // 
            // chb_noPause
            // 
            this.chb_noPause.AutoSize = true;
            this.chb_noPause.Checked = false;
            this.chb_noPause.Depth = 0;
            this.chb_noPause.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_noPause.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chb_noPause.Location = new System.Drawing.Point(8, 68);
            this.chb_noPause.Margin = new System.Windows.Forms.Padding(0);
            this.chb_noPause.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_noPause.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_noPause.Name = "chb_noPause";
            this.chb_noPause.Ripple = true;
            this.chb_noPause.Shadow = null;
            this.chb_noPause.ShadowShape = null;
            this.chb_noPause.Size = new System.Drawing.Size(89, 30);
            this.chb_noPause.TabIndex = 1;
            this.chb_noPause.Tag = "-noPause";
            this.chb_noPause.Text = "No Pause";
            // 
            // chb_noSplash
            // 
            this.chb_noSplash.AutoSize = true;
            this.chb_noSplash.Checked = false;
            this.chb_noSplash.Depth = 0;
            this.chb_noSplash.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_noSplash.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chb_noSplash.Location = new System.Drawing.Point(8, 98);
            this.chb_noSplash.Margin = new System.Windows.Forms.Padding(0);
            this.chb_noSplash.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_noSplash.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_noSplash.Name = "chb_noSplash";
            this.chb_noSplash.Ripple = true;
            this.chb_noSplash.Shadow = null;
            this.chb_noSplash.ShadowShape = null;
            this.chb_noSplash.Size = new System.Drawing.Size(138, 30);
            this.chb_noSplash.TabIndex = 2;
            this.chb_noSplash.Tag = "-noSplash";
            this.chb_noSplash.Text = "No Splash Screen";
            // 
            // chb_skipIntro
            // 
            this.chb_skipIntro.AutoSize = true;
            this.chb_skipIntro.Checked = false;
            this.chb_skipIntro.Depth = 0;
            this.chb_skipIntro.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_skipIntro.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chb_skipIntro.Location = new System.Drawing.Point(8, 128);
            this.chb_skipIntro.Margin = new System.Windows.Forms.Padding(0);
            this.chb_skipIntro.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_skipIntro.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_skipIntro.Name = "chb_skipIntro";
            this.chb_skipIntro.Ripple = true;
            this.chb_skipIntro.Shadow = null;
            this.chb_skipIntro.ShadowShape = null;
            this.chb_skipIntro.Size = new System.Drawing.Size(88, 30);
            this.chb_skipIntro.TabIndex = 5;
            this.chb_skipIntro.Tag = "-skipIntro";
            this.chb_skipIntro.Text = "Skip Intro";
            // 
            // chb_window
            // 
            this.chb_window.AutoSize = true;
            this.chb_window.Checked = false;
            this.chb_window.Depth = 0;
            this.chb_window.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_window.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chb_window.Location = new System.Drawing.Point(8, 158);
            this.chb_window.Margin = new System.Windows.Forms.Padding(0);
            this.chb_window.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_window.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_window.Name = "chb_window";
            this.chb_window.Ripple = true;
            this.chb_window.Shadow = null;
            this.chb_window.ShadowShape = null;
            this.chb_window.Size = new System.Drawing.Size(117, 30);
            this.chb_window.TabIndex = 6;
            this.chb_window.Tag = "-window";
            this.chb_window.Text = "Window Mode";
            // 
            // chb_enableHT
            // 
            this.chb_enableHT.AutoSize = true;
            this.chb_enableHT.Checked = false;
            this.chb_enableHT.Depth = 0;
            this.chb_enableHT.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_enableHT.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chb_enableHT.Location = new System.Drawing.Point(8, 188);
            this.chb_enableHT.Margin = new System.Windows.Forms.Padding(0);
            this.chb_enableHT.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_enableHT.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_enableHT.Name = "chb_enableHT";
            this.chb_enableHT.Ripple = true;
            this.chb_enableHT.Shadow = null;
            this.chb_enableHT.ShadowShape = null;
            this.chb_enableHT.Size = new System.Drawing.Size(92, 30);
            this.chb_enableHT.TabIndex = 4;
            this.chb_enableHT.Tag = "-enableHT";
            this.chb_enableHT.Text = "Enable HT";
            // 
            // chb_hugePages
            // 
            this.chb_hugePages.AutoSize = true;
            this.chb_hugePages.Checked = false;
            this.chb_hugePages.Depth = 0;
            this.chb_hugePages.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_hugePages.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chb_hugePages.Location = new System.Drawing.Point(8, 218);
            this.chb_hugePages.Margin = new System.Windows.Forms.Padding(0);
            this.chb_hugePages.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_hugePages.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_hugePages.Name = "chb_hugePages";
            this.chb_hugePages.Ripple = true;
            this.chb_hugePages.Shadow = null;
            this.chb_hugePages.ShadowShape = null;
            this.chb_hugePages.Size = new System.Drawing.Size(103, 30);
            this.chb_hugePages.TabIndex = 3;
            this.chb_hugePages.Tag = "-hugepages";
            this.chb_hugePages.Text = "Huge pages";
            // 
            // chb_filePatching
            // 
            this.chb_filePatching.AutoSize = true;
            this.chb_filePatching.Checked = false;
            this.chb_filePatching.Depth = 0;
            this.chb_filePatching.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_filePatching.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chb_filePatching.Location = new System.Drawing.Point(8, 248);
            this.chb_filePatching.Margin = new System.Windows.Forms.Padding(0);
            this.chb_filePatching.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_filePatching.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_filePatching.Name = "chb_filePatching";
            this.chb_filePatching.Ripple = true;
            this.chb_filePatching.Shadow = null;
            this.chb_filePatching.ShadowShape = null;
            this.chb_filePatching.Size = new System.Drawing.Size(109, 30);
            this.chb_filePatching.TabIndex = 10;
            this.chb_filePatching.Tag = "-filePatching";
            this.chb_filePatching.Text = "File Patching";
            // 
            // chb_worldEmpty
            // 
            this.chb_worldEmpty.AutoSize = true;
            this.chb_worldEmpty.Checked = false;
            this.chb_worldEmpty.Depth = 0;
            this.chb_worldEmpty.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_worldEmpty.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chb_worldEmpty.Location = new System.Drawing.Point(8, 278);
            this.chb_worldEmpty.Margin = new System.Windows.Forms.Padding(0);
            this.chb_worldEmpty.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_worldEmpty.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_worldEmpty.Name = "chb_worldEmpty";
            this.chb_worldEmpty.Ripple = true;
            this.chb_worldEmpty.Shadow = null;
            this.chb_worldEmpty.ShadowShape = null;
            this.chb_worldEmpty.Size = new System.Drawing.Size(108, 30);
            this.chb_worldEmpty.TabIndex = 11;
            this.chb_worldEmpty.Tag = "-world=empty";
            this.chb_worldEmpty.Text = "World Empty";
            // 
            // chb_battleye
            // 
            this.chb_battleye.AutoSize = true;
            this.chb_battleye.Checked = false;
            this.chb_battleye.Depth = 0;
            this.chb_battleye.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_battleye.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chb_battleye.Location = new System.Drawing.Point(8, 308);
            this.chb_battleye.Margin = new System.Windows.Forms.Padding(0);
            this.chb_battleye.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_battleye.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_battleye.Name = "chb_battleye";
            this.chb_battleye.Ripple = true;
            this.chb_battleye.Shadow = null;
            this.chb_battleye.ShadowShape = null;
            this.chb_battleye.Size = new System.Drawing.Size(124, 30);
            this.chb_battleye.TabIndex = 7;
            this.chb_battleye.Text = "Enable Battleye";
            this.chb_battleye.CheckedChanged += new MaterialSkin.Controls.MaterialCheckBox.CheckedChangedEventHandler(this.chb_battleye_CheckedChanged);
            // 
            // lbl_launchOptions
            // 
            this.lbl_launchOptions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_launchOptions.AutoSize = true;
            this.lbl_launchOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.lbl_launchOptions.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_launchOptions.Location = new System.Drawing.Point(10, 15);
            this.lbl_launchOptions.Name = "lbl_launchOptions";
            this.lbl_launchOptions.Size = new System.Drawing.Size(361, 55);
            this.lbl_launchOptions.TabIndex = 3;
            this.lbl_launchOptions.Text = "Launch Options";
            // 
            // panel_preferences
            // 
            this.panel_preferences.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel_preferences.Controls.Add(this.panel_contentPreferences);
            this.panel_preferences.Controls.Add(this.lbl_preferences);
            this.panel_preferences.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_preferences.Location = new System.Drawing.Point(2600, 0);
            this.panel_preferences.Name = "panel_preferences";
            this.panel_preferences.Size = new System.Drawing.Size(1300, 670);
            this.panel_preferences.TabIndex = 3;
            // 
            // panel_contentPreferences
            // 
            this.panel_contentPreferences.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_contentPreferences.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel_contentPreferences.Controls.Add(this.flowLayoutPanel2);
            this.panel_contentPreferences.Controls.Add(this.panel17);
            this.panel_contentPreferences.Controls.Add(this.flowpanel_preferencesDirectories);
            this.panel_contentPreferences.Location = new System.Drawing.Point(32, 80);
            this.panel_contentPreferences.Name = "panel_contentPreferences";
            this.panel_contentPreferences.Size = new System.Drawing.Size(1240, 560);
            this.panel_contentPreferences.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.txt_pref_gamePrefrences);
            this.flowLayoutPanel2.Controls.Add(this.chb_pref_startGame);
            this.flowLayoutPanel2.Controls.Add(this.chb_pref_joinServer);
            this.flowLayoutPanel2.Controls.Add(this.chb_pref_joinTSServer);
            this.flowLayoutPanel2.Controls.Add(this.chb_pref_serverAutopilot);
            this.flowLayoutPanel2.Controls.Add(this.panel18);
            this.flowLayoutPanel2.Controls.Add(this.txt_pref_launcherPreferences);
            this.flowLayoutPanel2.Controls.Add(this.chb_pref_disableAnimations);
            this.flowLayoutPanel2.Controls.Add(this.chb_pref_runLauncherStartup);
            this.flowLayoutPanel2.Controls.Add(this.chb_pref_allowNotifications);
            this.flowLayoutPanel2.Controls.Add(this.chb_pref_autoDownload);
            this.flowLayoutPanel2.Controls.Add(this.chb_pref_serverMode);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(952, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(288, 560);
            this.flowLayoutPanel2.TabIndex = 19;
            // 
            // txt_pref_gamePrefrences
            // 
            this.txt_pref_gamePrefrences.AutoSize = true;
            this.txt_pref_gamePrefrences.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_pref_gamePrefrences.Location = new System.Drawing.Point(20, 15);
            this.txt_pref_gamePrefrences.Margin = new System.Windows.Forms.Padding(10, 15, 15, 5);
            this.txt_pref_gamePrefrences.Name = "txt_pref_gamePrefrences";
            this.txt_pref_gamePrefrences.Size = new System.Drawing.Size(136, 21);
            this.txt_pref_gamePrefrences.TabIndex = 0;
            this.txt_pref_gamePrefrences.Text = "Game preferences";
            // 
            // chb_pref_startGame
            // 
            this.chb_pref_startGame.AutoSize = true;
            this.chb_pref_startGame.Checked = false;
            this.chb_pref_startGame.Depth = 0;
            this.chb_pref_startGame.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_pref_startGame.Location = new System.Drawing.Point(10, 41);
            this.chb_pref_startGame.Margin = new System.Windows.Forms.Padding(0);
            this.chb_pref_startGame.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_pref_startGame.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_pref_startGame.Name = "chb_pref_startGame";
            this.chb_pref_startGame.Ripple = true;
            this.chb_pref_startGame.Shadow = null;
            this.chb_pref_startGame.ShadowShape = null;
            this.chb_pref_startGame.Size = new System.Drawing.Size(170, 30);
            this.chb_pref_startGame.TabIndex = 1;
            this.chb_pref_startGame.Text = "Start game when ready";
            // 
            // chb_pref_joinServer
            // 
            this.chb_pref_joinServer.AutoSize = true;
            this.chb_pref_joinServer.Checked = false;
            this.chb_pref_joinServer.Depth = 0;
            this.chb_pref_joinServer.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_pref_joinServer.Location = new System.Drawing.Point(10, 71);
            this.chb_pref_joinServer.Margin = new System.Windows.Forms.Padding(0);
            this.chb_pref_joinServer.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_pref_joinServer.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_pref_joinServer.Name = "chb_pref_joinServer";
            this.chb_pref_joinServer.Ripple = true;
            this.chb_pref_joinServer.Shadow = null;
            this.chb_pref_joinServer.ShadowShape = null;
            this.chb_pref_joinServer.Size = new System.Drawing.Size(183, 30);
            this.chb_pref_joinServer.TabIndex = 2;
            this.chb_pref_joinServer.Text = "Join server automatically";
            // 
            // chb_pref_joinTSServer
            // 
            this.chb_pref_joinTSServer.AutoSize = true;
            this.chb_pref_joinTSServer.Checked = false;
            this.chb_pref_joinTSServer.Depth = 0;
            this.chb_pref_joinTSServer.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_pref_joinTSServer.Location = new System.Drawing.Point(10, 101);
            this.chb_pref_joinTSServer.Margin = new System.Windows.Forms.Padding(0);
            this.chb_pref_joinTSServer.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_pref_joinTSServer.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_pref_joinTSServer.Name = "chb_pref_joinTSServer";
            this.chb_pref_joinTSServer.Ripple = true;
            this.chb_pref_joinTSServer.Shadow = null;
            this.chb_pref_joinTSServer.ShadowShape = null;
            this.chb_pref_joinTSServer.Size = new System.Drawing.Size(259, 30);
            this.chb_pref_joinTSServer.TabIndex = 3;
            this.chb_pref_joinTSServer.Text = "Join TeamSpeak server automatically";
            // 
            // chb_pref_serverAutopilot
            // 
            this.chb_pref_serverAutopilot.AutoSize = true;
            this.chb_pref_serverAutopilot.Checked = false;
            this.chb_pref_serverAutopilot.Depth = 0;
            this.chb_pref_serverAutopilot.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_pref_serverAutopilot.Location = new System.Drawing.Point(10, 131);
            this.chb_pref_serverAutopilot.Margin = new System.Windows.Forms.Padding(0);
            this.chb_pref_serverAutopilot.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_pref_serverAutopilot.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_pref_serverAutopilot.Name = "chb_pref_serverAutopilot";
            this.chb_pref_serverAutopilot.Ripple = true;
            this.chb_pref_serverAutopilot.Shadow = null;
            this.chb_pref_serverAutopilot.ShadowShape = null;
            this.chb_pref_serverAutopilot.Size = new System.Drawing.Size(126, 30);
            this.chb_pref_serverAutopilot.TabIndex = 4;
            this.chb_pref_serverAutopilot.Text = "Server autopilot";
            this.chb_pref_serverAutopilot.Visible = false;
            this.chb_pref_serverAutopilot.CheckedChanged += new MaterialSkin.Controls.MaterialCheckBox.CheckedChangedEventHandler(this.chb_pref_serverAutopilot_CheckedChanged);
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.panel18.Location = new System.Drawing.Point(20, 176);
            this.panel18.Margin = new System.Windows.Forms.Padding(10, 15, 20, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(250, 2);
            this.panel18.TabIndex = 10;
            // 
            // txt_pref_launcherPreferences
            // 
            this.txt_pref_launcherPreferences.AutoSize = true;
            this.txt_pref_launcherPreferences.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_pref_launcherPreferences.Location = new System.Drawing.Point(20, 193);
            this.txt_pref_launcherPreferences.Margin = new System.Windows.Forms.Padding(10, 15, 15, 5);
            this.txt_pref_launcherPreferences.Name = "txt_pref_launcherPreferences";
            this.txt_pref_launcherPreferences.Size = new System.Drawing.Size(159, 21);
            this.txt_pref_launcherPreferences.TabIndex = 5;
            this.txt_pref_launcherPreferences.Text = "Launcher preferences";
            // 
            // chb_pref_disableAnimations
            // 
            this.chb_pref_disableAnimations.AutoSize = true;
            this.chb_pref_disableAnimations.Checked = false;
            this.chb_pref_disableAnimations.Depth = 0;
            this.chb_pref_disableAnimations.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_pref_disableAnimations.Location = new System.Drawing.Point(10, 219);
            this.chb_pref_disableAnimations.Margin = new System.Windows.Forms.Padding(0);
            this.chb_pref_disableAnimations.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_pref_disableAnimations.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_pref_disableAnimations.Name = "chb_pref_disableAnimations";
            this.chb_pref_disableAnimations.Ripple = true;
            this.chb_pref_disableAnimations.Shadow = null;
            this.chb_pref_disableAnimations.ShadowShape = null;
            this.chb_pref_disableAnimations.Size = new System.Drawing.Size(208, 30);
            this.chb_pref_disableAnimations.TabIndex = 11;
            this.chb_pref_disableAnimations.Text = "Disable transition animations";
            this.chb_pref_disableAnimations.CheckedChanged += new MaterialSkin.Controls.MaterialCheckBox.CheckedChangedEventHandler(this.chb_pref_disableAnimations_CheckedChanged);
            // 
            // chb_pref_runLauncherStartup
            // 
            this.chb_pref_runLauncherStartup.AutoSize = true;
            this.chb_pref_runLauncherStartup.Checked = false;
            this.chb_pref_runLauncherStartup.Depth = 0;
            this.chb_pref_runLauncherStartup.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_pref_runLauncherStartup.Location = new System.Drawing.Point(10, 249);
            this.chb_pref_runLauncherStartup.Margin = new System.Windows.Forms.Padding(0);
            this.chb_pref_runLauncherStartup.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_pref_runLauncherStartup.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_pref_runLauncherStartup.Name = "chb_pref_runLauncherStartup";
            this.chb_pref_runLauncherStartup.Ripple = true;
            this.chb_pref_runLauncherStartup.Shadow = null;
            this.chb_pref_runLauncherStartup.ShadowShape = null;
            this.chb_pref_runLauncherStartup.Size = new System.Drawing.Size(198, 30);
            this.chb_pref_runLauncherStartup.TabIndex = 6;
            this.chb_pref_runLauncherStartup.Text = "Run the launcher on startup";
            this.chb_pref_runLauncherStartup.Visible = false;
            this.chb_pref_runLauncherStartup.CheckedChanged += new MaterialSkin.Controls.MaterialCheckBox.CheckedChangedEventHandler(this.chb_pref_runLauncherStartup_CheckedChanged);
            // 
            // chb_pref_allowNotifications
            // 
            this.chb_pref_allowNotifications.AutoSize = true;
            this.chb_pref_allowNotifications.Checked = false;
            this.chb_pref_allowNotifications.Depth = 0;
            this.chb_pref_allowNotifications.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_pref_allowNotifications.Location = new System.Drawing.Point(10, 279);
            this.chb_pref_allowNotifications.Margin = new System.Windows.Forms.Padding(0);
            this.chb_pref_allowNotifications.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_pref_allowNotifications.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_pref_allowNotifications.Name = "chb_pref_allowNotifications";
            this.chb_pref_allowNotifications.Ripple = true;
            this.chb_pref_allowNotifications.Shadow = null;
            this.chb_pref_allowNotifications.ShadowShape = null;
            this.chb_pref_allowNotifications.Size = new System.Drawing.Size(143, 30);
            this.chb_pref_allowNotifications.TabIndex = 7;
            this.chb_pref_allowNotifications.Text = "Allow notifications";
            this.chb_pref_allowNotifications.Visible = false;
            // 
            // chb_pref_autoDownload
            // 
            this.chb_pref_autoDownload.AutoSize = true;
            this.chb_pref_autoDownload.Checked = false;
            this.chb_pref_autoDownload.Depth = 0;
            this.chb_pref_autoDownload.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_pref_autoDownload.Location = new System.Drawing.Point(10, 309);
            this.chb_pref_autoDownload.Margin = new System.Windows.Forms.Padding(0);
            this.chb_pref_autoDownload.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_pref_autoDownload.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_pref_autoDownload.Name = "chb_pref_autoDownload";
            this.chb_pref_autoDownload.Ripple = true;
            this.chb_pref_autoDownload.Shadow = null;
            this.chb_pref_autoDownload.ShadowShape = null;
            this.chb_pref_autoDownload.Size = new System.Drawing.Size(240, 30);
            this.chb_pref_autoDownload.TabIndex = 8;
            this.chb_pref_autoDownload.Text = "Auto-download repository updates";
            // 
            // chb_pref_serverMode
            // 
            this.chb_pref_serverMode.AutoSize = true;
            this.chb_pref_serverMode.Checked = false;
            this.chb_pref_serverMode.Depth = 0;
            this.chb_pref_serverMode.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_pref_serverMode.Location = new System.Drawing.Point(10, 339);
            this.chb_pref_serverMode.Margin = new System.Windows.Forms.Padding(0);
            this.chb_pref_serverMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_pref_serverMode.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_pref_serverMode.Name = "chb_pref_serverMode";
            this.chb_pref_serverMode.Ripple = true;
            this.chb_pref_serverMode.Shadow = null;
            this.chb_pref_serverMode.ShadowShape = null;
            this.chb_pref_serverMode.Size = new System.Drawing.Size(270, 30);
            this.chb_pref_serverMode.TabIndex = 9;
            this.chb_pref_serverMode.Text = "Server Mode (launcher restart required)";
            this.chb_pref_serverMode.CheckedChanged += new MaterialSkin.Controls.MaterialCheckBox.CheckedChangedEventHandler(this.chb_pref_serverMode_CheckedChanged);
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(950, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(2, 560);
            this.panel17.TabIndex = 18;
            // 
            // flowpanel_preferencesDirectories
            // 
            this.flowpanel_preferencesDirectories.Controls.Add(this.panel_Arma3Dir);
            this.flowpanel_preferencesDirectories.Controls.Add(this.doubleBufferPanel22);
            this.flowpanel_preferencesDirectories.Controls.Add(this.panel_addonsDir);
            this.flowpanel_preferencesDirectories.Controls.Add(this.doubleBufferPanel23);
            this.flowpanel_preferencesDirectories.Controls.Add(this.panel_optionalAddonsDir);
            this.flowpanel_preferencesDirectories.Controls.Add(this.doubleBufferPanel24);
            this.flowpanel_preferencesDirectories.Controls.Add(this.panel_TeamSpeakDir);
            this.flowpanel_preferencesDirectories.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowpanel_preferencesDirectories.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowpanel_preferencesDirectories.Location = new System.Drawing.Point(0, 0);
            this.flowpanel_preferencesDirectories.Name = "flowpanel_preferencesDirectories";
            this.flowpanel_preferencesDirectories.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.flowpanel_preferencesDirectories.Size = new System.Drawing.Size(950, 560);
            this.flowpanel_preferencesDirectories.TabIndex = 17;
            // 
            // panel_Arma3Dir
            // 
            this.panel_Arma3Dir.Controls.Add(this.btn_pref_openA3Dir);
            this.panel_Arma3Dir.Controls.Add(this.btn_pref_browseA3Dir);
            this.panel_Arma3Dir.Controls.Add(this.btn_pref_ereaseArmaDir);
            this.panel_Arma3Dir.Controls.Add(this.lbl_pref_Arma3Dir);
            this.panel_Arma3Dir.Controls.Add(this.txtb_pref_armaDirectory);
            this.panel_Arma3Dir.Location = new System.Drawing.Point(0, 5);
            this.panel_Arma3Dir.Margin = new System.Windows.Forms.Padding(0);
            this.panel_Arma3Dir.MaximumSize = new System.Drawing.Size(950, 50);
            this.panel_Arma3Dir.MinimumSize = new System.Drawing.Size(950, 50);
            this.panel_Arma3Dir.Name = "panel_Arma3Dir";
            this.panel_Arma3Dir.Size = new System.Drawing.Size(950, 50);
            this.panel_Arma3Dir.TabIndex = 18;
            // 
            // btn_pref_openA3Dir
            // 
            this.btn_pref_openA3Dir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_pref_openA3Dir.Image = ((System.Drawing.Image)(resources.GetObject("btn_pref_openA3Dir.Image")));
            this.btn_pref_openA3Dir.Location = new System.Drawing.Point(912, 17);
            this.btn_pref_openA3Dir.Name = "btn_pref_openA3Dir";
            this.btn_pref_openA3Dir.Size = new System.Drawing.Size(16, 16);
            this.btn_pref_openA3Dir.TabIndex = 11;
            this.btn_pref_openA3Dir.TabStop = false;
            this.btn_pref_openA3Dir.Click += new System.EventHandler(this.btn_pref_openA3Dir_Click);
            this.btn_pref_openA3Dir.MouseEnter += new System.EventHandler(this.btn_pref_openA3Dir_MouseEnter);
            this.btn_pref_openA3Dir.MouseLeave += new System.EventHandler(this.btn_pref_openA3Dir_MouseLeave);
            // 
            // btn_pref_browseA3Dir
            // 
            this.btn_pref_browseA3Dir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_pref_browseA3Dir.Image = global::arma3Launcher.Properties.Resources.addfolder_idle;
            this.btn_pref_browseA3Dir.Location = new System.Drawing.Point(892, 17);
            this.btn_pref_browseA3Dir.Name = "btn_pref_browseA3Dir";
            this.btn_pref_browseA3Dir.Size = new System.Drawing.Size(16, 16);
            this.btn_pref_browseA3Dir.TabIndex = 8;
            this.btn_pref_browseA3Dir.TabStop = false;
            this.btn_pref_browseA3Dir.Click += new System.EventHandler(this.btn_pref_browseA3Dir_Click);
            this.btn_pref_browseA3Dir.MouseEnter += new System.EventHandler(this.btn_pref_browseA3Dir_MouseEnter);
            this.btn_pref_browseA3Dir.MouseLeave += new System.EventHandler(this.btn_pref_browseA3Dir_MouseLeave);
            // 
            // btn_pref_ereaseArmaDir
            // 
            this.btn_pref_ereaseArmaDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btn_pref_ereaseArmaDir.Image = ((System.Drawing.Image)(resources.GetObject("btn_pref_ereaseArmaDir.Image")));
            this.btn_pref_ereaseArmaDir.Location = new System.Drawing.Point(862, 19);
            this.btn_pref_ereaseArmaDir.Name = "btn_pref_ereaseArmaDir";
            this.btn_pref_ereaseArmaDir.Size = new System.Drawing.Size(12, 12);
            this.btn_pref_ereaseArmaDir.TabIndex = 12;
            this.btn_pref_ereaseArmaDir.TabStop = false;
            this.btn_pref_ereaseArmaDir.Click += new System.EventHandler(this.btn_pref_ereaseArmaDir_Click);
            this.btn_pref_ereaseArmaDir.MouseEnter += new System.EventHandler(this.btn_pref_ereaseArmaDir_MouseEnter);
            this.btn_pref_ereaseArmaDir.MouseLeave += new System.EventHandler(this.btn_pref_ereaseArmaDir_MouseLeave);
            // 
            // lbl_pref_Arma3Dir
            // 
            this.lbl_pref_Arma3Dir.AutoSize = true;
            this.lbl_pref_Arma3Dir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pref_Arma3Dir.Location = new System.Drawing.Point(7, 16);
            this.lbl_pref_Arma3Dir.Name = "lbl_pref_Arma3Dir";
            this.lbl_pref_Arma3Dir.Size = new System.Drawing.Size(107, 16);
            this.lbl_pref_Arma3Dir.TabIndex = 0;
            this.lbl_pref_Arma3Dir.Text = "Arma 3 directory:";
            // 
            // txtb_pref_armaDirectory
            // 
            this.txtb_pref_armaDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.txtb_pref_armaDirectory.Depth = 0;
            this.txtb_pref_armaDirectory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtb_pref_armaDirectory.ForeColor = System.Drawing.Color.DarkGray;
            this.txtb_pref_armaDirectory.Hint = "";
            this.txtb_pref_armaDirectory.Location = new System.Drawing.Point(185, 15);
            this.txtb_pref_armaDirectory.MaxLength = 32767;
            this.txtb_pref_armaDirectory.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtb_pref_armaDirectory.Name = "txtb_pref_armaDirectory";
            this.txtb_pref_armaDirectory.PasswordChar = '\0';
            this.txtb_pref_armaDirectory.SelectedText = "";
            this.txtb_pref_armaDirectory.SelectionLength = 0;
            this.txtb_pref_armaDirectory.SelectionStart = 0;
            this.txtb_pref_armaDirectory.Shadow = null;
            this.txtb_pref_armaDirectory.ShadowShape = null;
            this.txtb_pref_armaDirectory.Size = new System.Drawing.Size(694, 23);
            this.txtb_pref_armaDirectory.TabIndex = 3;
            this.txtb_pref_armaDirectory.Text = "Set directory ->";
            this.txtb_pref_armaDirectory.UseSystemPasswordChar = false;
            this.txtb_pref_armaDirectory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtb_pref_armaDirectory_MouseClick);
            this.txtb_pref_armaDirectory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtb_pref_armaDirectory_MouseDoubleClick);
            this.txtb_pref_armaDirectory.TextChanged += new System.EventHandler(this.txtb_pref_armaDirectory_TextChanged);
            // 
            // doubleBufferPanel22
            // 
            this.doubleBufferPanel22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.doubleBufferPanel22.Location = new System.Drawing.Point(15, 65);
            this.doubleBufferPanel22.Margin = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.doubleBufferPanel22.Name = "doubleBufferPanel22";
            this.doubleBufferPanel22.Size = new System.Drawing.Size(920, 2);
            this.doubleBufferPanel22.TabIndex = 21;
            // 
            // panel_addonsDir
            // 
            this.panel_addonsDir.Controls.Add(this.lbl_pref_AddonsDir);
            this.panel_addonsDir.Controls.Add(this.btn_pref_ereaseAddonsDir);
            this.panel_addonsDir.Controls.Add(this.btn_pref_openAddonsDir);
            this.panel_addonsDir.Controls.Add(this.btn_pref_browseAddonsDir);
            this.panel_addonsDir.Controls.Add(this.txtb_pref_addonsDirectory);
            this.panel_addonsDir.Location = new System.Drawing.Point(0, 77);
            this.panel_addonsDir.Margin = new System.Windows.Forms.Padding(0);
            this.panel_addonsDir.MaximumSize = new System.Drawing.Size(950, 50);
            this.panel_addonsDir.MinimumSize = new System.Drawing.Size(950, 50);
            this.panel_addonsDir.Name = "panel_addonsDir";
            this.panel_addonsDir.Size = new System.Drawing.Size(950, 50);
            this.panel_addonsDir.TabIndex = 19;
            // 
            // lbl_pref_AddonsDir
            // 
            this.lbl_pref_AddonsDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_pref_AddonsDir.AutoSize = true;
            this.lbl_pref_AddonsDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pref_AddonsDir.Location = new System.Drawing.Point(7, 16);
            this.lbl_pref_AddonsDir.Name = "lbl_pref_AddonsDir";
            this.lbl_pref_AddonsDir.Size = new System.Drawing.Size(112, 16);
            this.lbl_pref_AddonsDir.TabIndex = 12;
            this.lbl_pref_AddonsDir.Text = "Addons directory:";
            // 
            // btn_pref_ereaseAddonsDir
            // 
            this.btn_pref_ereaseAddonsDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btn_pref_ereaseAddonsDir.Image = ((System.Drawing.Image)(resources.GetObject("btn_pref_ereaseAddonsDir.Image")));
            this.btn_pref_ereaseAddonsDir.Location = new System.Drawing.Point(862, 19);
            this.btn_pref_ereaseAddonsDir.Name = "btn_pref_ereaseAddonsDir";
            this.btn_pref_ereaseAddonsDir.Size = new System.Drawing.Size(12, 12);
            this.btn_pref_ereaseAddonsDir.TabIndex = 20;
            this.btn_pref_ereaseAddonsDir.TabStop = false;
            this.btn_pref_ereaseAddonsDir.Click += new System.EventHandler(this.btn_pref_ereaseAddonsDir_Click);
            this.btn_pref_ereaseAddonsDir.MouseEnter += new System.EventHandler(this.btn_pref_ereaseAddonsDir_MouseEnter);
            this.btn_pref_ereaseAddonsDir.MouseLeave += new System.EventHandler(this.btn_pref_ereaseAddonsDir_MouseLeave);
            // 
            // btn_pref_openAddonsDir
            // 
            this.btn_pref_openAddonsDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_pref_openAddonsDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_pref_openAddonsDir.Image = ((System.Drawing.Image)(resources.GetObject("btn_pref_openAddonsDir.Image")));
            this.btn_pref_openAddonsDir.Location = new System.Drawing.Point(911, 17);
            this.btn_pref_openAddonsDir.Name = "btn_pref_openAddonsDir";
            this.btn_pref_openAddonsDir.Size = new System.Drawing.Size(16, 16);
            this.btn_pref_openAddonsDir.TabIndex = 11;
            this.btn_pref_openAddonsDir.TabStop = false;
            this.btn_pref_openAddonsDir.Click += new System.EventHandler(this.btn_pref_openAddonsDir_Click);
            this.btn_pref_openAddonsDir.MouseEnter += new System.EventHandler(this.btn_pref_openAddonsDir_MouseEnter);
            this.btn_pref_openAddonsDir.MouseLeave += new System.EventHandler(this.btn_pref_openAddonsDir_MouseLeave);
            // 
            // btn_pref_browseAddonsDir
            // 
            this.btn_pref_browseAddonsDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_pref_browseAddonsDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_pref_browseAddonsDir.Image = ((System.Drawing.Image)(resources.GetObject("btn_pref_browseAddonsDir.Image")));
            this.btn_pref_browseAddonsDir.Location = new System.Drawing.Point(892, 17);
            this.btn_pref_browseAddonsDir.Name = "btn_pref_browseAddonsDir";
            this.btn_pref_browseAddonsDir.Size = new System.Drawing.Size(16, 16);
            this.btn_pref_browseAddonsDir.TabIndex = 10;
            this.btn_pref_browseAddonsDir.TabStop = false;
            this.btn_pref_browseAddonsDir.Click += new System.EventHandler(this.btn_pref_browseAddonsDir_Click);
            this.btn_pref_browseAddonsDir.MouseEnter += new System.EventHandler(this.btn_pref_browseAddonsDir_MouseEnter);
            this.btn_pref_browseAddonsDir.MouseLeave += new System.EventHandler(this.btn_pref_browseAddonsDir_MouseLeave);
            // 
            // txtb_pref_addonsDirectory
            // 
            this.txtb_pref_addonsDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtb_pref_addonsDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.txtb_pref_addonsDirectory.Depth = 0;
            this.txtb_pref_addonsDirectory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtb_pref_addonsDirectory.ForeColor = System.Drawing.Color.DarkGray;
            this.txtb_pref_addonsDirectory.Hint = "";
            this.txtb_pref_addonsDirectory.Location = new System.Drawing.Point(185, 15);
            this.txtb_pref_addonsDirectory.MaxLength = 32767;
            this.txtb_pref_addonsDirectory.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtb_pref_addonsDirectory.Name = "txtb_pref_addonsDirectory";
            this.txtb_pref_addonsDirectory.PasswordChar = '\0';
            this.txtb_pref_addonsDirectory.SelectedText = "";
            this.txtb_pref_addonsDirectory.SelectionLength = 0;
            this.txtb_pref_addonsDirectory.SelectionStart = 0;
            this.txtb_pref_addonsDirectory.Shadow = null;
            this.txtb_pref_addonsDirectory.ShadowShape = null;
            this.txtb_pref_addonsDirectory.Size = new System.Drawing.Size(694, 23);
            this.txtb_pref_addonsDirectory.TabIndex = 4;
            this.txtb_pref_addonsDirectory.Text = "Set directory ->";
            this.txtb_pref_addonsDirectory.UseSystemPasswordChar = false;
            this.txtb_pref_addonsDirectory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtb_pref_addonsDirectory_MouseClick);
            this.txtb_pref_addonsDirectory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtb_pref_addonsDirectory_MouseDoubleClick);
            this.txtb_pref_addonsDirectory.TextChanged += new System.EventHandler(this.txtb_pref_addonsDirectory_TextChanged);
            // 
            // doubleBufferPanel23
            // 
            this.doubleBufferPanel23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.doubleBufferPanel23.Location = new System.Drawing.Point(15, 137);
            this.doubleBufferPanel23.Margin = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.doubleBufferPanel23.Name = "doubleBufferPanel23";
            this.doubleBufferPanel23.Size = new System.Drawing.Size(920, 2);
            this.doubleBufferPanel23.TabIndex = 22;
            // 
            // panel_optionalAddonsDir
            // 
            this.panel_optionalAddonsDir.Controls.Add(this.btn_pref_ereaseOptionalDir);
            this.panel_optionalAddonsDir.Controls.Add(this.btn_pref_openOptionalDir);
            this.panel_optionalAddonsDir.Controls.Add(this.btn_pref_browseOptionalDir);
            this.panel_optionalAddonsDir.Controls.Add(this.txtb_pref_optionalDirectory);
            this.panel_optionalAddonsDir.Controls.Add(this.lbl_pref_OptionalDir);
            this.panel_optionalAddonsDir.Location = new System.Drawing.Point(0, 149);
            this.panel_optionalAddonsDir.Margin = new System.Windows.Forms.Padding(0);
            this.panel_optionalAddonsDir.MaximumSize = new System.Drawing.Size(950, 50);
            this.panel_optionalAddonsDir.MinimumSize = new System.Drawing.Size(950, 50);
            this.panel_optionalAddonsDir.Name = "panel_optionalAddonsDir";
            this.panel_optionalAddonsDir.Size = new System.Drawing.Size(950, 50);
            this.panel_optionalAddonsDir.TabIndex = 20;
            // 
            // btn_pref_ereaseOptionalDir
            // 
            this.btn_pref_ereaseOptionalDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btn_pref_ereaseOptionalDir.Image = ((System.Drawing.Image)(resources.GetObject("btn_pref_ereaseOptionalDir.Image")));
            this.btn_pref_ereaseOptionalDir.Location = new System.Drawing.Point(862, 19);
            this.btn_pref_ereaseOptionalDir.Name = "btn_pref_ereaseOptionalDir";
            this.btn_pref_ereaseOptionalDir.Size = new System.Drawing.Size(12, 12);
            this.btn_pref_ereaseOptionalDir.TabIndex = 21;
            this.btn_pref_ereaseOptionalDir.TabStop = false;
            this.btn_pref_ereaseOptionalDir.Click += new System.EventHandler(this.btn_pref_ereaseOptionalDir_Click);
            this.btn_pref_ereaseOptionalDir.MouseEnter += new System.EventHandler(this.btn_pref_ereaseOptionalDir_MouseEnter);
            this.btn_pref_ereaseOptionalDir.MouseLeave += new System.EventHandler(this.btn_pref_ereaseOptionalDir_MouseLeave);
            // 
            // btn_pref_openOptionalDir
            // 
            this.btn_pref_openOptionalDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_pref_openOptionalDir.Image = ((System.Drawing.Image)(resources.GetObject("btn_pref_openOptionalDir.Image")));
            this.btn_pref_openOptionalDir.Location = new System.Drawing.Point(912, 17);
            this.btn_pref_openOptionalDir.Name = "btn_pref_openOptionalDir";
            this.btn_pref_openOptionalDir.Size = new System.Drawing.Size(16, 16);
            this.btn_pref_openOptionalDir.TabIndex = 10;
            this.btn_pref_openOptionalDir.TabStop = false;
            this.btn_pref_openOptionalDir.Click += new System.EventHandler(this.btn_pref_openOptionalDir_Click);
            this.btn_pref_openOptionalDir.MouseEnter += new System.EventHandler(this.btn_pref_openOptionalDir_MouseEnter);
            this.btn_pref_openOptionalDir.MouseLeave += new System.EventHandler(this.btn_pref_openOptionalDir_MouseLeave);
            // 
            // btn_pref_browseOptionalDir
            // 
            this.btn_pref_browseOptionalDir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_pref_browseOptionalDir.Image = ((System.Drawing.Image)(resources.GetObject("btn_pref_browseOptionalDir.Image")));
            this.btn_pref_browseOptionalDir.Location = new System.Drawing.Point(892, 17);
            this.btn_pref_browseOptionalDir.Name = "btn_pref_browseOptionalDir";
            this.btn_pref_browseOptionalDir.Size = new System.Drawing.Size(16, 16);
            this.btn_pref_browseOptionalDir.TabIndex = 9;
            this.btn_pref_browseOptionalDir.TabStop = false;
            this.btn_pref_browseOptionalDir.Click += new System.EventHandler(this.btn_pref_browseOptionalDir_Click);
            this.btn_pref_browseOptionalDir.MouseEnter += new System.EventHandler(this.btn_pref_browseOptionalDir_MouseEnter);
            this.btn_pref_browseOptionalDir.MouseLeave += new System.EventHandler(this.btn_pref_browseOptionalDir_MouseLeave);
            // 
            // txtb_pref_optionalDirectory
            // 
            this.txtb_pref_optionalDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.txtb_pref_optionalDirectory.Depth = 0;
            this.txtb_pref_optionalDirectory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtb_pref_optionalDirectory.ForeColor = System.Drawing.Color.DarkGray;
            this.txtb_pref_optionalDirectory.Hint = "";
            this.txtb_pref_optionalDirectory.Location = new System.Drawing.Point(185, 15);
            this.txtb_pref_optionalDirectory.MaxLength = 32767;
            this.txtb_pref_optionalDirectory.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtb_pref_optionalDirectory.Name = "txtb_pref_optionalDirectory";
            this.txtb_pref_optionalDirectory.PasswordChar = '\0';
            this.txtb_pref_optionalDirectory.SelectedText = "";
            this.txtb_pref_optionalDirectory.SelectionLength = 0;
            this.txtb_pref_optionalDirectory.SelectionStart = 0;
            this.txtb_pref_optionalDirectory.Shadow = null;
            this.txtb_pref_optionalDirectory.ShadowShape = null;
            this.txtb_pref_optionalDirectory.Size = new System.Drawing.Size(694, 23);
            this.txtb_pref_optionalDirectory.TabIndex = 2;
            this.txtb_pref_optionalDirectory.Text = "Set directory ->";
            this.txtb_pref_optionalDirectory.UseSystemPasswordChar = false;
            this.txtb_pref_optionalDirectory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtb_pref_optionalDirectory_MouseClick);
            this.txtb_pref_optionalDirectory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtb_pref_optionalDirectory_MouseDoubleClick);
            this.txtb_pref_optionalDirectory.TextChanged += new System.EventHandler(this.txtb_pref_optionalDirectory_TextChanged);
            // 
            // lbl_pref_OptionalDir
            // 
            this.lbl_pref_OptionalDir.AutoSize = true;
            this.lbl_pref_OptionalDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pref_OptionalDir.Location = new System.Drawing.Point(7, 16);
            this.lbl_pref_OptionalDir.Name = "lbl_pref_OptionalDir";
            this.lbl_pref_OptionalDir.Size = new System.Drawing.Size(164, 16);
            this.lbl_pref_OptionalDir.TabIndex = 1;
            this.lbl_pref_OptionalDir.Text = "Optional addons directory:";
            // 
            // doubleBufferPanel24
            // 
            this.doubleBufferPanel24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.doubleBufferPanel24.Location = new System.Drawing.Point(15, 209);
            this.doubleBufferPanel24.Margin = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.doubleBufferPanel24.Name = "doubleBufferPanel24";
            this.doubleBufferPanel24.Size = new System.Drawing.Size(920, 2);
            this.doubleBufferPanel24.TabIndex = 23;
            // 
            // panel_TeamSpeakDir
            // 
            this.panel_TeamSpeakDir.Controls.Add(this.btn_pref_ereaseTSDir);
            this.panel_TeamSpeakDir.Controls.Add(this.btn_pref_openTS3Dir);
            this.panel_TeamSpeakDir.Controls.Add(this.btn_pref_browseTS3Dir);
            this.panel_TeamSpeakDir.Controls.Add(this.txtb_pref_tsDirectory);
            this.panel_TeamSpeakDir.Controls.Add(this.lbl_pref_TeamSpeakDir);
            this.panel_TeamSpeakDir.Location = new System.Drawing.Point(0, 221);
            this.panel_TeamSpeakDir.Margin = new System.Windows.Forms.Padding(0);
            this.panel_TeamSpeakDir.MaximumSize = new System.Drawing.Size(950, 50);
            this.panel_TeamSpeakDir.MinimumSize = new System.Drawing.Size(950, 50);
            this.panel_TeamSpeakDir.Name = "panel_TeamSpeakDir";
            this.panel_TeamSpeakDir.Size = new System.Drawing.Size(950, 50);
            this.panel_TeamSpeakDir.TabIndex = 17;
            // 
            // btn_pref_ereaseTSDir
            // 
            this.btn_pref_ereaseTSDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.btn_pref_ereaseTSDir.Image = ((System.Drawing.Image)(resources.GetObject("btn_pref_ereaseTSDir.Image")));
            this.btn_pref_ereaseTSDir.Location = new System.Drawing.Point(862, 19);
            this.btn_pref_ereaseTSDir.Name = "btn_pref_ereaseTSDir";
            this.btn_pref_ereaseTSDir.Size = new System.Drawing.Size(12, 12);
            this.btn_pref_ereaseTSDir.TabIndex = 21;
            this.btn_pref_ereaseTSDir.TabStop = false;
            this.btn_pref_ereaseTSDir.Click += new System.EventHandler(this.btn_pref_ereaseTSDir_Click);
            this.btn_pref_ereaseTSDir.MouseEnter += new System.EventHandler(this.btn_pref_ereaseTSDir_MouseEnter);
            this.btn_pref_ereaseTSDir.MouseLeave += new System.EventHandler(this.btn_pref_ereaseTSDir_MouseLeave);
            // 
            // btn_pref_openTS3Dir
            // 
            this.btn_pref_openTS3Dir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_pref_openTS3Dir.Image = ((System.Drawing.Image)(resources.GetObject("btn_pref_openTS3Dir.Image")));
            this.btn_pref_openTS3Dir.Location = new System.Drawing.Point(912, 17);
            this.btn_pref_openTS3Dir.Name = "btn_pref_openTS3Dir";
            this.btn_pref_openTS3Dir.Size = new System.Drawing.Size(16, 16);
            this.btn_pref_openTS3Dir.TabIndex = 10;
            this.btn_pref_openTS3Dir.TabStop = false;
            this.btn_pref_openTS3Dir.Click += new System.EventHandler(this.btn_pref_openTS3Dir_Click);
            this.btn_pref_openTS3Dir.MouseEnter += new System.EventHandler(this.btn_pref_openTS3Dir_MouseEnter);
            this.btn_pref_openTS3Dir.MouseLeave += new System.EventHandler(this.btn_pref_openTS3Dir_MouseLeave);
            // 
            // btn_pref_browseTS3Dir
            // 
            this.btn_pref_browseTS3Dir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_pref_browseTS3Dir.Image = ((System.Drawing.Image)(resources.GetObject("btn_pref_browseTS3Dir.Image")));
            this.btn_pref_browseTS3Dir.Location = new System.Drawing.Point(892, 17);
            this.btn_pref_browseTS3Dir.Name = "btn_pref_browseTS3Dir";
            this.btn_pref_browseTS3Dir.Size = new System.Drawing.Size(16, 16);
            this.btn_pref_browseTS3Dir.TabIndex = 9;
            this.btn_pref_browseTS3Dir.TabStop = false;
            this.btn_pref_browseTS3Dir.Click += new System.EventHandler(this.btn_pref_browseTS3Dir_Click);
            this.btn_pref_browseTS3Dir.MouseEnter += new System.EventHandler(this.btn_pref_browseTS3Dir_MouseEnter);
            this.btn_pref_browseTS3Dir.MouseLeave += new System.EventHandler(this.btn_pref_browseTS3Dir_MouseLeave);
            // 
            // txtb_pref_tsDirectory
            // 
            this.txtb_pref_tsDirectory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.txtb_pref_tsDirectory.Depth = 0;
            this.txtb_pref_tsDirectory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtb_pref_tsDirectory.ForeColor = System.Drawing.Color.DarkGray;
            this.txtb_pref_tsDirectory.Hint = "";
            this.txtb_pref_tsDirectory.Location = new System.Drawing.Point(185, 15);
            this.txtb_pref_tsDirectory.MaxLength = 32767;
            this.txtb_pref_tsDirectory.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtb_pref_tsDirectory.Name = "txtb_pref_tsDirectory";
            this.txtb_pref_tsDirectory.PasswordChar = '\0';
            this.txtb_pref_tsDirectory.SelectedText = "";
            this.txtb_pref_tsDirectory.SelectionLength = 0;
            this.txtb_pref_tsDirectory.SelectionStart = 0;
            this.txtb_pref_tsDirectory.Shadow = null;
            this.txtb_pref_tsDirectory.ShadowShape = null;
            this.txtb_pref_tsDirectory.Size = new System.Drawing.Size(694, 23);
            this.txtb_pref_tsDirectory.TabIndex = 2;
            this.txtb_pref_tsDirectory.Text = "Set directory ->";
            this.txtb_pref_tsDirectory.UseSystemPasswordChar = false;
            this.txtb_pref_tsDirectory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtb_pref_tsDirectory_MouseClick);
            this.txtb_pref_tsDirectory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtb_pref_tsDirectory_MouseDoubleClick);
            this.txtb_pref_tsDirectory.TextChanged += new System.EventHandler(this.txtb_pref_tsDirectory_TextChanged);
            // 
            // lbl_pref_TeamSpeakDir
            // 
            this.lbl_pref_TeamSpeakDir.AutoSize = true;
            this.lbl_pref_TeamSpeakDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pref_TeamSpeakDir.Location = new System.Drawing.Point(7, 16);
            this.lbl_pref_TeamSpeakDir.Name = "lbl_pref_TeamSpeakDir";
            this.lbl_pref_TeamSpeakDir.Size = new System.Drawing.Size(151, 16);
            this.lbl_pref_TeamSpeakDir.TabIndex = 1;
            this.lbl_pref_TeamSpeakDir.Text = "TeamSpeak 3 directory:";
            // 
            // lbl_preferences
            // 
            this.lbl_preferences.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_preferences.AutoSize = true;
            this.lbl_preferences.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.lbl_preferences.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_preferences.Location = new System.Drawing.Point(10, 15);
            this.lbl_preferences.Name = "lbl_preferences";
            this.lbl_preferences.Size = new System.Drawing.Size(284, 55);
            this.lbl_preferences.TabIndex = 3;
            this.lbl_preferences.Text = "Preferences";
            // 
            // panel_repositoryDownloads
            // 
            this.panel_repositoryDownloads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel_repositoryDownloads.Controls.Add(this.panel_contentRepositoryDownloads);
            this.panel_repositoryDownloads.Controls.Add(this.lbl_repositoryDownloads);
            this.panel_repositoryDownloads.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_repositoryDownloads.Location = new System.Drawing.Point(1300, 0);
            this.panel_repositoryDownloads.Name = "panel_repositoryDownloads";
            this.panel_repositoryDownloads.Size = new System.Drawing.Size(1300, 670);
            this.panel_repositoryDownloads.TabIndex = 2;
            // 
            // panel_contentRepositoryDownloads
            // 
            this.panel_contentRepositoryDownloads.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_contentRepositoryDownloads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.panel_contentRepositoryDownloads.Controls.Add(this.trv_repoContent);
            this.panel_contentRepositoryDownloads.Controls.Add(this.panel_repoBottom);
            this.panel_contentRepositoryDownloads.Location = new System.Drawing.Point(32, 80);
            this.panel_contentRepositoryDownloads.Name = "panel_contentRepositoryDownloads";
            this.panel_contentRepositoryDownloads.Size = new System.Drawing.Size(1240, 560);
            this.panel_contentRepositoryDownloads.TabIndex = 4;
            // 
            // trv_repoContent
            // 
            this.trv_repoContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.trv_repoContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trv_repoContent.ContextMenuStrip = this.repositoryMenu;
            this.trv_repoContent.Dock = System.Windows.Forms.DockStyle.Left;
            this.trv_repoContent.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trv_repoContent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.trv_repoContent.FullRowSelect = true;
            this.trv_repoContent.ImageIndex = 0;
            this.trv_repoContent.ImageList = this.imageListRepo;
            this.trv_repoContent.Indent = 20;
            this.trv_repoContent.ItemHeight = 30;
            this.trv_repoContent.LineColor = System.Drawing.Color.Gainsboro;
            this.trv_repoContent.Location = new System.Drawing.Point(0, 0);
            this.trv_repoContent.MinimumSize = new System.Drawing.Size(1240, 0);
            this.trv_repoContent.Name = "trv_repoContent";
            treeNode1.ImageIndex = -2;
            treeNode1.Name = "Node0";
            treeNode1.SelectedImageIndex = -2;
            treeNode1.Text = "Node0";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "Node2";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "Node2";
            treeNode3.ImageIndex = 2;
            treeNode3.Name = "Node3";
            treeNode3.SelectedImageIndex = 2;
            treeNode3.Text = "Node3";
            treeNode4.ImageIndex = 3;
            treeNode4.Name = "Node0";
            treeNode4.SelectedImageIndex = 3;
            treeNode4.Text = "Node0";
            treeNode5.ImageIndex = 4;
            treeNode5.Name = "Node1";
            treeNode5.SelectedImageIndex = 4;
            treeNode5.Text = "Node1";
            treeNode6.ImageIndex = 5;
            treeNode6.Name = "Node2";
            treeNode6.SelectedImageIndex = 5;
            treeNode6.Text = "Node2";
            this.trv_repoContent.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.trv_repoContent.SelectedImageIndex = 0;
            this.trv_repoContent.ShowRootLines = false;
            this.trv_repoContent.Size = new System.Drawing.Size(1240, 490);
            this.trv_repoContent.TabIndex = 31;
            this.trv_repoContent.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trv_repoContent_NodeMouseClick);
            // 
            // panel_repoBottom
            // 
            this.panel_repoBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(45)))));
            this.panel_repoBottom.Controls.Add(this.panel_repoDownload);
            this.panel_repoBottom.Controls.Add(this.panel_repoInfo);
            this.panel_repoBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_repoBottom.Location = new System.Drawing.Point(0, 490);
            this.panel_repoBottom.Name = "panel_repoBottom";
            this.panel_repoBottom.Size = new System.Drawing.Size(1240, 70);
            this.panel_repoBottom.TabIndex = 30;
            // 
            // panel_repoDownload
            // 
            this.panel_repoDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(45)))));
            this.panel_repoDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_repoDownload.Controls.Add(this.prb_progressBar_All);
            this.panel_repoDownload.Controls.Add(this.btn_cancelDownload);
            this.panel_repoDownload.Controls.Add(this.prb_progressBar_File);
            this.panel_repoDownload.Controls.Add(this.txt_curFile);
            this.panel_repoDownload.Controls.Add(this.txt_percentageStatus);
            this.panel_repoDownload.Controls.Add(this.txt_progressStatus);
            this.panel_repoDownload.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_repoDownload.Location = new System.Drawing.Point(1240, 0);
            this.panel_repoDownload.MinimumSize = new System.Drawing.Size(1240, 0);
            this.panel_repoDownload.Name = "panel_repoDownload";
            this.panel_repoDownload.Size = new System.Drawing.Size(1240, 70);
            this.panel_repoDownload.TabIndex = 13;
            this.panel_repoDownload.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_repoDownload_Paint);
            // 
            // prb_progressBar_All
            // 
            this.prb_progressBar_All.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prb_progressBar_All.ContainerControl = this;
            this.prb_progressBar_All.Location = new System.Drawing.Point(20, 47);
            this.prb_progressBar_All.Name = "prb_progressBar_All";
            this.prb_progressBar_All.ShowInTaskbar = true;
            this.prb_progressBar_All.Size = new System.Drawing.Size(1170, 5);
            this.prb_progressBar_All.TabIndex = 11;
            // 
            // prb_progressBar_File
            // 
            this.prb_progressBar_File.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prb_progressBar_File.ContainerControl = this;
            this.prb_progressBar_File.Location = new System.Drawing.Point(20, 27);
            this.prb_progressBar_File.Name = "prb_progressBar_File";
            this.prb_progressBar_File.Size = new System.Drawing.Size(1170, 20);
            this.prb_progressBar_File.TabIndex = 10;
            // 
            // txt_curFile
            // 
            this.txt_curFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_curFile.AutoSize = true;
            this.txt_curFile.BackColor = System.Drawing.Color.Transparent;
            this.txt_curFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.txt_curFile.ForeColor = System.Drawing.Color.LightGray;
            this.txt_curFile.Location = new System.Drawing.Point(18, 51);
            this.txt_curFile.MaximumSize = new System.Drawing.Size(0, 12);
            this.txt_curFile.MinimumSize = new System.Drawing.Size(250, 12);
            this.txt_curFile.Name = "txt_curFile";
            this.txt_curFile.Size = new System.Drawing.Size(250, 12);
            this.txt_curFile.TabIndex = 8;
            this.txt_curFile.Text = "%CURFILE%";
            // 
            // txt_percentageStatus
            // 
            this.txt_percentageStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_percentageStatus.AutoSize = true;
            this.txt_percentageStatus.BackColor = System.Drawing.Color.Transparent;
            this.txt_percentageStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_percentageStatus.ForeColor = System.Drawing.Color.DarkGray;
            this.txt_percentageStatus.Location = new System.Drawing.Point(993, 10);
            this.txt_percentageStatus.MaximumSize = new System.Drawing.Size(200, 19);
            this.txt_percentageStatus.MinimumSize = new System.Drawing.Size(200, 19);
            this.txt_percentageStatus.Name = "txt_percentageStatus";
            this.txt_percentageStatus.Size = new System.Drawing.Size(200, 19);
            this.txt_percentageStatus.TabIndex = 7;
            this.txt_percentageStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_progressStatus
            // 
            this.txt_progressStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_progressStatus.AutoSize = true;
            this.txt_progressStatus.BackColor = System.Drawing.Color.Transparent;
            this.txt_progressStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_progressStatus.Location = new System.Drawing.Point(17, 8);
            this.txt_progressStatus.MaximumSize = new System.Drawing.Size(650, 19);
            this.txt_progressStatus.MinimumSize = new System.Drawing.Size(650, 19);
            this.txt_progressStatus.Name = "txt_progressStatus";
            this.txt_progressStatus.Size = new System.Drawing.Size(650, 19);
            this.txt_progressStatus.TabIndex = 6;
            this.txt_progressStatus.Text = "Waiting for orders";
            // 
            // panel_repoInfo
            // 
            this.panel_repoInfo.Controls.Add(this.btn_updateRepo);
            this.panel_repoInfo.Controls.Add(this.btn_checkRepo);
            this.panel_repoInfo.Controls.Add(this.lbl_repofileok);
            this.panel_repoInfo.Controls.Add(this.pictureBox8);
            this.panel_repoInfo.Controls.Add(this.label14);
            this.panel_repoInfo.Controls.Add(this.pictureBox7);
            this.panel_repoInfo.Controls.Add(this.pictureBox6);
            this.panel_repoInfo.Controls.Add(this.lbl_repofilemissing);
            this.panel_repoInfo.Controls.Add(this.lbl_repofileinvalid);
            this.panel_repoInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_repoInfo.Location = new System.Drawing.Point(0, 0);
            this.panel_repoInfo.MaximumSize = new System.Drawing.Size(1240, 0);
            this.panel_repoInfo.Name = "panel_repoInfo";
            this.panel_repoInfo.Size = new System.Drawing.Size(1240, 70);
            this.panel_repoInfo.TabIndex = 0;
            this.panel_repoInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_repoInfo_Paint);
            // 
            // btn_updateRepo
            // 
            this.btn_updateRepo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_updateRepo.AutoSize = true;
            this.btn_updateRepo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_updateRepo.Depth = 0;
            this.btn_updateRepo.Icon = null;
            this.btn_updateRepo.Location = new System.Drawing.Point(1072, 17);
            this.btn_updateRepo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_updateRepo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_updateRepo.Name = "btn_updateRepo";
            this.btn_updateRepo.Primary = false;
            this.btn_updateRepo.Shadow = null;
            this.btn_updateRepo.ShadowShape = null;
            this.btn_updateRepo.Size = new System.Drawing.Size(157, 36);
            this.btn_updateRepo.TabIndex = 39;
            this.btn_updateRepo.Text = "Check for Updates";
            this.btn_updateRepo.Click += new System.EventHandler(this.btn_updateRepo_Click);
            // 
            // btn_checkRepo
            // 
            this.btn_checkRepo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_checkRepo.AutoSize = true;
            this.btn_checkRepo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_checkRepo.Depth = 0;
            this.btn_checkRepo.Icon = null;
            this.btn_checkRepo.Location = new System.Drawing.Point(897, 17);
            this.btn_checkRepo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_checkRepo.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_checkRepo.Name = "btn_checkRepo";
            this.btn_checkRepo.Primary = false;
            this.btn_checkRepo.Shadow = null;
            this.btn_checkRepo.ShadowShape = null;
            this.btn_checkRepo.Size = new System.Drawing.Size(167, 36);
            this.btn_checkRepo.TabIndex = 38;
            this.btn_checkRepo.Text = "Validate Local Files";
            this.btn_checkRepo.Click += new System.EventHandler(this.btn_checkRepo_Click);
            // 
            // lbl_repofileok
            // 
            this.lbl_repofileok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_repofileok.AutoSize = true;
            this.lbl_repofileok.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbl_repofileok.ForeColor = System.Drawing.Color.DarkGray;
            this.lbl_repofileok.Location = new System.Drawing.Point(32, 38);
            this.lbl_repofileok.MinimumSize = new System.Drawing.Size(70, 13);
            this.lbl_repofileok.Name = "lbl_repofileok";
            this.lbl_repofileok.Size = new System.Drawing.Size(70, 13);
            this.lbl_repofileok.TabIndex = 34;
            this.lbl_repofileok.Text = "%OK%";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox8.BackgroundImage = global::arma3Launcher.Properties.Resources.document_cancel;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox8.Location = new System.Drawing.Point(222, 36);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(16, 18);
            this.pictureBox8.TabIndex = 30;
            this.pictureBox8.TabStop = false;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkGray;
            this.label14.Location = new System.Drawing.Point(10, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 15);
            this.label14.TabIndex = 30;
            this.label14.Text = "Local Status:";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox7.BackgroundImage = global::arma3Launcher.Properties.Resources.document_error;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Location = new System.Drawing.Point(118, 36);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(16, 18);
            this.pictureBox7.TabIndex = 29;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.BackgroundImage = global::arma3Launcher.Properties.Resources.document_checked;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Location = new System.Drawing.Point(14, 36);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 18);
            this.pictureBox6.TabIndex = 28;
            this.pictureBox6.TabStop = false;
            // 
            // lbl_repofilemissing
            // 
            this.lbl_repofilemissing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_repofilemissing.AutoSize = true;
            this.lbl_repofilemissing.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbl_repofilemissing.ForeColor = System.Drawing.Color.DarkGray;
            this.lbl_repofilemissing.Location = new System.Drawing.Point(240, 38);
            this.lbl_repofilemissing.MinimumSize = new System.Drawing.Size(70, 13);
            this.lbl_repofilemissing.Name = "lbl_repofilemissing";
            this.lbl_repofilemissing.Size = new System.Drawing.Size(70, 13);
            this.lbl_repofilemissing.TabIndex = 36;
            this.lbl_repofilemissing.Text = "%MISSING%";
            // 
            // lbl_repofileinvalid
            // 
            this.lbl_repofileinvalid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_repofileinvalid.AutoSize = true;
            this.lbl_repofileinvalid.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lbl_repofileinvalid.ForeColor = System.Drawing.Color.DarkGray;
            this.lbl_repofileinvalid.Location = new System.Drawing.Point(136, 38);
            this.lbl_repofileinvalid.MinimumSize = new System.Drawing.Size(70, 13);
            this.lbl_repofileinvalid.Name = "lbl_repofileinvalid";
            this.lbl_repofileinvalid.Size = new System.Drawing.Size(70, 13);
            this.lbl_repofileinvalid.TabIndex = 35;
            this.lbl_repofileinvalid.Text = "%INVALID%";
            // 
            // lbl_repositoryDownloads
            // 
            this.lbl_repositoryDownloads.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_repositoryDownloads.AutoSize = true;
            this.lbl_repositoryDownloads.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.lbl_repositoryDownloads.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_repositoryDownloads.Location = new System.Drawing.Point(10, 15);
            this.lbl_repositoryDownloads.Name = "lbl_repositoryDownloads";
            this.lbl_repositoryDownloads.Size = new System.Drawing.Size(506, 55);
            this.lbl_repositoryDownloads.TabIndex = 3;
            this.lbl_repositoryDownloads.Text = "Repository Downloads";
            // 
            // panel_addonPacks
            // 
            this.panel_addonPacks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel_addonPacks.Controls.Add(this.panel_addonPacksFlow);
            this.panel_addonPacks.Controls.Add(this.panel_addonOptions);
            this.panel_addonPacks.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_addonPacks.Location = new System.Drawing.Point(0, 0);
            this.panel_addonPacks.Name = "panel_addonPacks";
            this.panel_addonPacks.Size = new System.Drawing.Size(1300, 670);
            this.panel_addonPacks.TabIndex = 0;
            // 
            // panel_addonPacksFlow
            // 
            this.panel_addonPacksFlow.Controls.Add(this.btn_addonsOptionsOpen);
            this.panel_addonPacksFlow.Controls.Add(this.flowpanel_addonPacks);
            this.panel_addonPacksFlow.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_addonPacksFlow.Location = new System.Drawing.Point(1265, 0);
            this.panel_addonPacksFlow.Name = "panel_addonPacksFlow";
            this.panel_addonPacksFlow.Size = new System.Drawing.Size(1300, 670);
            this.panel_addonPacksFlow.TabIndex = 2;
            // 
            // btn_addonsOptionsOpen
            // 
            this.btn_addonsOptionsOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_addonsOptionsOpen.AutoSize = true;
            this.btn_addonsOptionsOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btn_addonsOptionsOpen.Font = new System.Drawing.Font("Consolas", 14F);
            this.btn_addonsOptionsOpen.Location = new System.Drawing.Point(7, 307);
            this.btn_addonsOptionsOpen.MaximumSize = new System.Drawing.Size(16, 57);
            this.btn_addonsOptionsOpen.MinimumSize = new System.Drawing.Size(16, 57);
            this.btn_addonsOptionsOpen.Name = "btn_addonsOptionsOpen";
            this.btn_addonsOptionsOpen.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btn_addonsOptionsOpen.Size = new System.Drawing.Size(16, 57);
            this.btn_addonsOptionsOpen.TabIndex = 1;
            this.btn_addonsOptionsOpen.Text = "<";
            this.btn_addonsOptionsOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_addonsOptionsOpen.Click += new System.EventHandler(this.btn_addonsOptionsOpen_Click);
            this.btn_addonsOptionsOpen.MouseEnter += new System.EventHandler(this.btn_addonsOptionsOpen_MouseEnter);
            this.btn_addonsOptionsOpen.MouseLeave += new System.EventHandler(this.btn_addonsOptionsOpen_MouseLeave);
            // 
            // flowpanel_addonPacks
            // 
            this.flowpanel_addonPacks.ContextMenuStrip = this.flowAddonsMenu;
            this.flowpanel_addonPacks.Controls.Add(this.panel2);
            this.flowpanel_addonPacks.Controls.Add(this.panel3);
            this.flowpanel_addonPacks.Controls.Add(this.panel4);
            this.flowpanel_addonPacks.Controls.Add(this.panel5);
            this.flowpanel_addonPacks.Controls.Add(this.panel6);
            this.flowpanel_addonPacks.Controls.Add(this.panel8);
            this.flowpanel_addonPacks.Controls.Add(this.panel7);
            this.flowpanel_addonPacks.Controls.Add(this.panel9);
            this.flowpanel_addonPacks.Controls.Add(this.panel10);
            this.flowpanel_addonPacks.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowpanel_addonPacks.Location = new System.Drawing.Point(0, 0);
            this.flowpanel_addonPacks.MaximumSize = new System.Drawing.Size(1300, 0);
            this.flowpanel_addonPacks.Name = "flowpanel_addonPacks";
            this.flowpanel_addonPacks.Padding = new System.Windows.Forms.Padding(26, 30, 26, 30);
            this.flowpanel_addonPacks.Size = new System.Drawing.Size(1300, 670);
            this.flowpanel_addonPacks.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel2.Location = new System.Drawing.Point(29, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(410, 200);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Yellow;
            this.panel3.Location = new System.Drawing.Point(445, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(410, 200);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Maroon;
            this.panel4.Location = new System.Drawing.Point(861, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(410, 200);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel5.Location = new System.Drawing.Point(29, 239);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(410, 200);
            this.panel5.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel6.Location = new System.Drawing.Point(445, 239);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(410, 200);
            this.panel6.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.OliveDrab;
            this.panel8.Location = new System.Drawing.Point(861, 239);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(410, 200);
            this.panel8.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.YellowGreen;
            this.panel7.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.panel7.Location = new System.Drawing.Point(29, 445);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(410, 200);
            this.panel7.TabIndex = 5;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.Magenta;
            this.panel9.Location = new System.Drawing.Point(445, 445);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(410, 200);
            this.panel9.TabIndex = 6;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel10.Location = new System.Drawing.Point(861, 445);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(410, 200);
            this.panel10.TabIndex = 1;
            // 
            // panel_addonOptions
            // 
            this.panel_addonOptions.Controls.Add(this.btn_addonsOptionsClose);
            this.panel_addonOptions.Controls.Add(this.panel_contentAddonOptions);
            this.panel_addonOptions.Controls.Add(this.lbl_addonOptions);
            this.panel_addonOptions.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_addonOptions.Location = new System.Drawing.Point(0, 0);
            this.panel_addonOptions.MaximumSize = new System.Drawing.Size(1300, 0);
            this.panel_addonOptions.Name = "panel_addonOptions";
            this.panel_addonOptions.Size = new System.Drawing.Size(1265, 670);
            this.panel_addonOptions.TabIndex = 1;
            // 
            // btn_addonsOptionsClose
            // 
            this.btn_addonsOptionsClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addonsOptionsClose.AutoSize = true;
            this.btn_addonsOptionsClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btn_addonsOptionsClose.Font = new System.Drawing.Font("Consolas", 14F);
            this.btn_addonsOptionsClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_addonsOptionsClose.Location = new System.Drawing.Point(1243, 307);
            this.btn_addonsOptionsClose.MaximumSize = new System.Drawing.Size(16, 57);
            this.btn_addonsOptionsClose.MinimumSize = new System.Drawing.Size(16, 57);
            this.btn_addonsOptionsClose.Name = "btn_addonsOptionsClose";
            this.btn_addonsOptionsClose.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btn_addonsOptionsClose.Size = new System.Drawing.Size(16, 57);
            this.btn_addonsOptionsClose.TabIndex = 0;
            this.btn_addonsOptionsClose.Text = ">";
            this.btn_addonsOptionsClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_addonsOptionsClose.Click += new System.EventHandler(this.btn_addonsOptionsClose_Click);
            this.btn_addonsOptionsClose.MouseEnter += new System.EventHandler(this.btn_addonsOptionsClose_MouseEnter);
            this.btn_addonsOptionsClose.MouseLeave += new System.EventHandler(this.btn_addonsOptionsClose_MouseLeave);
            // 
            // panel_contentAddonOptions
            // 
            this.panel_contentAddonOptions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_contentAddonOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel_contentAddonOptions.Controls.Add(this.panel_sideAddonOptions);
            this.panel_contentAddonOptions.Controls.Add(this.panel_optionalAddons);
            this.panel_contentAddonOptions.Controls.Add(this.doubleBufferPanel14);
            this.panel_contentAddonOptions.Controls.Add(this.panel_steamworkshopAddons);
            this.panel_contentAddonOptions.Location = new System.Drawing.Point(14, 80);
            this.panel_contentAddonOptions.Name = "panel_contentAddonOptions";
            this.panel_contentAddonOptions.Size = new System.Drawing.Size(1240, 560);
            this.panel_contentAddonOptions.TabIndex = 2;
            // 
            // panel_sideAddonOptions
            // 
            this.panel_sideAddonOptions.Controls.Add(this.sideAOP_armaholic);
            this.panel_sideAddonOptions.Controls.Add(this.sideAOP_separator1);
            this.panel_sideAddonOptions.Controls.Add(this.sideAOP_steamworkshop);
            this.panel_sideAddonOptions.Controls.Add(this.sideAOP_separator2);
            this.panel_sideAddonOptions.Controls.Add(this.sideAOP_taskforceradio);
            this.panel_sideAddonOptions.Controls.Add(this.sideAOP_separator3);
            this.panel_sideAddonOptions.Controls.Add(this.sideAOP_userconfig);
            this.panel_sideAddonOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_sideAddonOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel_sideAddonOptions.Location = new System.Drawing.Point(925, 0);
            this.panel_sideAddonOptions.Name = "panel_sideAddonOptions";
            this.panel_sideAddonOptions.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.panel_sideAddonOptions.Size = new System.Drawing.Size(315, 560);
            this.panel_sideAddonOptions.TabIndex = 7;
            // 
            // sideAOP_armaholic
            // 
            this.sideAOP_armaholic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.sideAOP_armaholic.Controls.Add(this.materialLabel11);
            this.sideAOP_armaholic.Controls.Add(this.btn_openArmaholic);
            this.sideAOP_armaholic.Location = new System.Drawing.Point(5, 15);
            this.sideAOP_armaholic.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sideAOP_armaholic.Name = "sideAOP_armaholic";
            this.sideAOP_armaholic.Size = new System.Drawing.Size(305, 50);
            this.sideAOP_armaholic.TabIndex = 8;
            // 
            // materialLabel11
            // 
            this.materialLabel11.AutoSize = true;
            this.materialLabel11.Depth = 0;
            this.materialLabel11.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel11.FontSize = 11;
            this.materialLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel11.Location = new System.Drawing.Point(8, 16);
            this.materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel11.Name = "materialLabel11";
            this.materialLabel11.Primary = false;
            this.materialLabel11.Shadow = null;
            this.materialLabel11.ShadowShape = null;
            this.materialLabel11.Size = new System.Drawing.Size(82, 19);
            this.materialLabel11.TabIndex = 7;
            this.materialLabel11.Text = "Armaholic:";
            // 
            // btn_openArmaholic
            // 
            this.btn_openArmaholic.AutoSize = true;
            this.btn_openArmaholic.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_openArmaholic.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_openArmaholic.Depth = 0;
            this.btn_openArmaholic.Font = new System.Drawing.Font("Roboto", 9F);
            this.btn_openArmaholic.FontSize = 9;
            this.btn_openArmaholic.Icon = null;
            this.btn_openArmaholic.Location = new System.Drawing.Point(147, 8);
            this.btn_openArmaholic.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_openArmaholic.MaximumSize = new System.Drawing.Size(150, 35);
            this.btn_openArmaholic.MinimumSize = new System.Drawing.Size(150, 35);
            this.btn_openArmaholic.MouseState = MaterialSkin.MouseState.OUT;
            this.btn_openArmaholic.Name = "btn_openArmaholic";
            this.btn_openArmaholic.Primary = true;
            this.btn_openArmaholic.RoundedCornerRadius = 2;
            this.btn_openArmaholic.Shadow = null;
            graphicsPath1.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.btn_openArmaholic.ShadowShape = graphicsPath1;
            this.btn_openArmaholic.Size = new System.Drawing.Size(150, 35);
            this.btn_openArmaholic.TabIndex = 6;
            this.btn_openArmaholic.Text = "Visit";
            this.btn_openArmaholic.Click += new System.EventHandler(this.btn_openArmaholic_Click);
            // 
            // sideAOP_separator1
            // 
            this.sideAOP_separator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.sideAOP_separator1.Location = new System.Drawing.Point(10, 80);
            this.sideAOP_separator1.Margin = new System.Windows.Forms.Padding(10, 15, 20, 15);
            this.sideAOP_separator1.Name = "sideAOP_separator1";
            this.sideAOP_separator1.Size = new System.Drawing.Size(295, 2);
            this.sideAOP_separator1.TabIndex = 12;
            // 
            // sideAOP_steamworkshop
            // 
            this.sideAOP_steamworkshop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.sideAOP_steamworkshop.Controls.Add(this.materialLabel10);
            this.sideAOP_steamworkshop.Controls.Add(this.btn_openWorkshop);
            this.sideAOP_steamworkshop.Location = new System.Drawing.Point(5, 97);
            this.sideAOP_steamworkshop.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sideAOP_steamworkshop.Name = "sideAOP_steamworkshop";
            this.sideAOP_steamworkshop.Size = new System.Drawing.Size(305, 50);
            this.sideAOP_steamworkshop.TabIndex = 10;
            // 
            // materialLabel10
            // 
            this.materialLabel10.AutoSize = true;
            this.materialLabel10.Depth = 0;
            this.materialLabel10.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel10.FontSize = 11;
            this.materialLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel10.Location = new System.Drawing.Point(8, 16);
            this.materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel10.Name = "materialLabel10";
            this.materialLabel10.Primary = false;
            this.materialLabel10.Shadow = null;
            this.materialLabel10.ShadowShape = null;
            this.materialLabel10.Size = new System.Drawing.Size(128, 19);
            this.materialLabel10.TabIndex = 5;
            this.materialLabel10.Text = "Steam Workshop:";
            // 
            // btn_openWorkshop
            // 
            this.btn_openWorkshop.AutoSize = true;
            this.btn_openWorkshop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_openWorkshop.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_openWorkshop.Depth = 0;
            this.btn_openWorkshop.Font = new System.Drawing.Font("Roboto", 9F);
            this.btn_openWorkshop.FontSize = 9;
            this.btn_openWorkshop.Icon = null;
            this.btn_openWorkshop.Location = new System.Drawing.Point(147, 8);
            this.btn_openWorkshop.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_openWorkshop.MaximumSize = new System.Drawing.Size(150, 35);
            this.btn_openWorkshop.MinimumSize = new System.Drawing.Size(150, 35);
            this.btn_openWorkshop.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_openWorkshop.Name = "btn_openWorkshop";
            this.btn_openWorkshop.Primary = true;
            this.btn_openWorkshop.RoundedCornerRadius = 2;
            this.btn_openWorkshop.Shadow = null;
            graphicsPath2.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.btn_openWorkshop.ShadowShape = graphicsPath2;
            this.btn_openWorkshop.Size = new System.Drawing.Size(150, 35);
            this.btn_openWorkshop.TabIndex = 4;
            this.btn_openWorkshop.Text = "Visit";
            this.btn_openWorkshop.Click += new System.EventHandler(this.btn_openWorkshop_Click);
            // 
            // sideAOP_separator2
            // 
            this.sideAOP_separator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.sideAOP_separator2.Location = new System.Drawing.Point(10, 162);
            this.sideAOP_separator2.Margin = new System.Windows.Forms.Padding(10, 15, 20, 15);
            this.sideAOP_separator2.Name = "sideAOP_separator2";
            this.sideAOP_separator2.Size = new System.Drawing.Size(295, 2);
            this.sideAOP_separator2.TabIndex = 13;
            // 
            // sideAOP_taskforceradio
            // 
            this.sideAOP_taskforceradio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.sideAOP_taskforceradio.Controls.Add(this.materialLabel9);
            this.sideAOP_taskforceradio.Controls.Add(this.btn_reinstallTFRPlugins);
            this.sideAOP_taskforceradio.Location = new System.Drawing.Point(5, 179);
            this.sideAOP_taskforceradio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sideAOP_taskforceradio.Name = "sideAOP_taskforceradio";
            this.sideAOP_taskforceradio.Size = new System.Drawing.Size(305, 50);
            this.sideAOP_taskforceradio.TabIndex = 11;
            // 
            // materialLabel9
            // 
            this.materialLabel9.AutoSize = true;
            this.materialLabel9.Depth = 0;
            this.materialLabel9.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel9.FontSize = 11;
            this.materialLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel9.Location = new System.Drawing.Point(8, 16);
            this.materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel9.Name = "materialLabel9";
            this.materialLabel9.Primary = false;
            this.materialLabel9.Shadow = null;
            this.materialLabel9.ShadowShape = null;
            this.materialLabel9.Size = new System.Drawing.Size(130, 19);
            this.materialLabel9.TabIndex = 3;
            this.materialLabel9.Text = "Task Force Radio:";
            // 
            // btn_reinstallTFRPlugins
            // 
            this.btn_reinstallTFRPlugins.AutoSize = true;
            this.btn_reinstallTFRPlugins.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_reinstallTFRPlugins.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_reinstallTFRPlugins.Depth = 0;
            this.btn_reinstallTFRPlugins.Font = new System.Drawing.Font("Roboto", 9F);
            this.btn_reinstallTFRPlugins.FontSize = 9;
            this.btn_reinstallTFRPlugins.Icon = null;
            this.btn_reinstallTFRPlugins.Location = new System.Drawing.Point(147, 8);
            this.btn_reinstallTFRPlugins.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_reinstallTFRPlugins.MaximumSize = new System.Drawing.Size(150, 35);
            this.btn_reinstallTFRPlugins.MinimumSize = new System.Drawing.Size(150, 35);
            this.btn_reinstallTFRPlugins.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_reinstallTFRPlugins.Name = "btn_reinstallTFRPlugins";
            this.btn_reinstallTFRPlugins.Primary = true;
            this.btn_reinstallTFRPlugins.RoundedCornerRadius = 2;
            this.btn_reinstallTFRPlugins.Shadow = null;
            graphicsPath3.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.btn_reinstallTFRPlugins.ShadowShape = graphicsPath3;
            this.btn_reinstallTFRPlugins.Size = new System.Drawing.Size(150, 35);
            this.btn_reinstallTFRPlugins.TabIndex = 1;
            this.btn_reinstallTFRPlugins.Text = "Reinstall Plugins";
            this.btn_reinstallTFRPlugins.Click += new System.EventHandler(this.btn_reinstallTFRPlugins_Click);
            // 
            // sideAOP_separator3
            // 
            this.sideAOP_separator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.sideAOP_separator3.Location = new System.Drawing.Point(10, 244);
            this.sideAOP_separator3.Margin = new System.Windows.Forms.Padding(10, 15, 20, 15);
            this.sideAOP_separator3.Name = "sideAOP_separator3";
            this.sideAOP_separator3.Size = new System.Drawing.Size(295, 2);
            this.sideAOP_separator3.TabIndex = 15;
            // 
            // sideAOP_userconfig
            // 
            this.sideAOP_userconfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.sideAOP_userconfig.Controls.Add(this.materialLabel12);
            this.sideAOP_userconfig.Controls.Add(this.btn_reinstallUserconfigFiles);
            this.sideAOP_userconfig.Location = new System.Drawing.Point(5, 261);
            this.sideAOP_userconfig.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.sideAOP_userconfig.Name = "sideAOP_userconfig";
            this.sideAOP_userconfig.Size = new System.Drawing.Size(305, 50);
            this.sideAOP_userconfig.TabIndex = 14;
            // 
            // materialLabel12
            // 
            this.materialLabel12.AutoSize = true;
            this.materialLabel12.Depth = 0;
            this.materialLabel12.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel12.FontSize = 11;
            this.materialLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel12.Location = new System.Drawing.Point(8, 16);
            this.materialLabel12.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel12.Name = "materialLabel12";
            this.materialLabel12.Primary = false;
            this.materialLabel12.Shadow = null;
            this.materialLabel12.ShadowShape = null;
            this.materialLabel12.Size = new System.Drawing.Size(129, 19);
            this.materialLabel12.TabIndex = 3;
            this.materialLabel12.Text = "Userconfig folder:";
            // 
            // btn_reinstallUserconfigFiles
            // 
            this.btn_reinstallUserconfigFiles.AutoSize = true;
            this.btn_reinstallUserconfigFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_reinstallUserconfigFiles.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_reinstallUserconfigFiles.Depth = 0;
            this.btn_reinstallUserconfigFiles.Font = new System.Drawing.Font("Roboto", 9F);
            this.btn_reinstallUserconfigFiles.FontSize = 9;
            this.btn_reinstallUserconfigFiles.Icon = null;
            this.btn_reinstallUserconfigFiles.Location = new System.Drawing.Point(147, 8);
            this.btn_reinstallUserconfigFiles.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_reinstallUserconfigFiles.MaximumSize = new System.Drawing.Size(150, 35);
            this.btn_reinstallUserconfigFiles.MinimumSize = new System.Drawing.Size(150, 35);
            this.btn_reinstallUserconfigFiles.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_reinstallUserconfigFiles.Name = "btn_reinstallUserconfigFiles";
            this.btn_reinstallUserconfigFiles.Primary = true;
            this.btn_reinstallUserconfigFiles.RoundedCornerRadius = 2;
            this.btn_reinstallUserconfigFiles.Shadow = null;
            graphicsPath4.FillMode = System.Drawing.Drawing2D.FillMode.Alternate;
            this.btn_reinstallUserconfigFiles.ShadowShape = graphicsPath4;
            this.btn_reinstallUserconfigFiles.Size = new System.Drawing.Size(150, 35);
            this.btn_reinstallUserconfigFiles.TabIndex = 1;
            this.btn_reinstallUserconfigFiles.Text = "Reinstall Files";
            this.btn_reinstallUserconfigFiles.Click += new System.EventHandler(this.btn_reinstallUserconfigFiles_Click);
            // 
            // panel_optionalAddons
            // 
            this.panel_optionalAddons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.panel_optionalAddons.Controls.Add(this.scroll_optionalAddons);
            this.panel_optionalAddons.Controls.Add(this.flowpanel_optionalAddons);
            this.panel_optionalAddons.Controls.Add(this.doubleBufferPanel13);
            this.panel_optionalAddons.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_optionalAddons.Location = new System.Drawing.Point(465, 0);
            this.panel_optionalAddons.MaximumSize = new System.Drawing.Size(460, 0);
            this.panel_optionalAddons.Name = "panel_optionalAddons";
            this.panel_optionalAddons.Size = new System.Drawing.Size(460, 560);
            this.panel_optionalAddons.TabIndex = 6;
            // 
            // scroll_optionalAddons
            // 
            this.scroll_optionalAddons.Dock = System.Windows.Forms.DockStyle.Right;
            this.scroll_optionalAddons.LargeChange = 10;
            this.scroll_optionalAddons.Location = new System.Drawing.Point(455, 30);
            this.scroll_optionalAddons.Maximum = 100;
            this.scroll_optionalAddons.MaximumSize = new System.Drawing.Size(5, 0);
            this.scroll_optionalAddons.Minimum = 0;
            this.scroll_optionalAddons.MouseWheelBarPartitions = 10;
            this.scroll_optionalAddons.Name = "scroll_optionalAddons";
            this.scroll_optionalAddons.Orientation = MetroFramework.Controls.MetroScrollOrientation.Vertical;
            this.scroll_optionalAddons.ScrollbarSize = 5;
            this.scroll_optionalAddons.Size = new System.Drawing.Size(5, 530);
            this.scroll_optionalAddons.TabIndex = 4;
            this.scroll_optionalAddons.UseSelectable = true;
            this.scroll_optionalAddons.Visible = false;
            this.scroll_optionalAddons.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scroll_optionalAddons_Scroll);
            // 
            // flowpanel_optionalAddons
            // 
            this.flowpanel_optionalAddons.AutoScroll = true;
            this.flowpanel_optionalAddons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.flowpanel_optionalAddons.ContextMenuStrip = this.optionaladdonsMenu;
            this.flowpanel_optionalAddons.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowpanel_optionalAddons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowpanel_optionalAddons.Location = new System.Drawing.Point(0, 30);
            this.flowpanel_optionalAddons.MinimumSize = new System.Drawing.Size(460, 0);
            this.flowpanel_optionalAddons.Name = "flowpanel_optionalAddons";
            this.flowpanel_optionalAddons.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.flowpanel_optionalAddons.Size = new System.Drawing.Size(460, 530);
            this.flowpanel_optionalAddons.TabIndex = 0;
            this.flowpanel_optionalAddons.WrapContents = false;
            this.flowpanel_optionalAddons.Paint += new System.Windows.Forms.PaintEventHandler(this.flowpanel_optionalAddons_Paint);
            // 
            // doubleBufferPanel13
            // 
            this.doubleBufferPanel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.doubleBufferPanel13.Controls.Add(this.chb_optionalEnabled);
            this.doubleBufferPanel13.Controls.Add(this.materialLabel8);
            this.doubleBufferPanel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.doubleBufferPanel13.Location = new System.Drawing.Point(0, 0);
            this.doubleBufferPanel13.Name = "doubleBufferPanel13";
            this.doubleBufferPanel13.Size = new System.Drawing.Size(460, 30);
            this.doubleBufferPanel13.TabIndex = 3;
            // 
            // chb_optionalEnabled
            // 
            this.chb_optionalEnabled.Checked = false;
            this.chb_optionalEnabled.Depth = 0;
            this.chb_optionalEnabled.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_optionalEnabled.Location = new System.Drawing.Point(424, -3);
            this.chb_optionalEnabled.Margin = new System.Windows.Forms.Padding(0);
            this.chb_optionalEnabled.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_optionalEnabled.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_optionalEnabled.Name = "chb_optionalEnabled";
            this.chb_optionalEnabled.Ripple = true;
            this.chb_optionalEnabled.Shadow = null;
            this.chb_optionalEnabled.ShadowShape = null;
            this.chb_optionalEnabled.Size = new System.Drawing.Size(36, 36);
            this.chb_optionalEnabled.TabIndex = 4;
            this.chb_optionalEnabled.Text = null;
            this.chb_optionalEnabled.CheckedChanged += new MaterialSkin.Controls.MaterialCheckBox.CheckedChangedEventHandler(this.chb_optionalEnabled_CheckedChanged);
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.FontSize = 11;
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(8, 6);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Primary = false;
            this.materialLabel8.Shadow = null;
            this.materialLabel8.ShadowShape = null;
            this.materialLabel8.Size = new System.Drawing.Size(120, 19);
            this.materialLabel8.TabIndex = 2;
            this.materialLabel8.Text = "Optional Addons";
            // 
            // doubleBufferPanel14
            // 
            this.doubleBufferPanel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.doubleBufferPanel14.Location = new System.Drawing.Point(460, 0);
            this.doubleBufferPanel14.Name = "doubleBufferPanel14";
            this.doubleBufferPanel14.Size = new System.Drawing.Size(5, 560);
            this.doubleBufferPanel14.TabIndex = 5;
            // 
            // panel_steamworkshopAddons
            // 
            this.panel_steamworkshopAddons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.panel_steamworkshopAddons.Controls.Add(this.scroll_steamAddons);
            this.panel_steamworkshopAddons.Controls.Add(this.flowpanel_steamworkshopAddonsList);
            this.panel_steamworkshopAddons.Controls.Add(this.doubleBufferPanel3);
            this.panel_steamworkshopAddons.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_steamworkshopAddons.Location = new System.Drawing.Point(0, 0);
            this.panel_steamworkshopAddons.MaximumSize = new System.Drawing.Size(460, 0);
            this.panel_steamworkshopAddons.Name = "panel_steamworkshopAddons";
            this.panel_steamworkshopAddons.Size = new System.Drawing.Size(460, 560);
            this.panel_steamworkshopAddons.TabIndex = 3;
            // 
            // scroll_steamAddons
            // 
            this.scroll_steamAddons.Dock = System.Windows.Forms.DockStyle.Right;
            this.scroll_steamAddons.LargeChange = 10;
            this.scroll_steamAddons.Location = new System.Drawing.Point(455, 30);
            this.scroll_steamAddons.Maximum = 100;
            this.scroll_steamAddons.MaximumSize = new System.Drawing.Size(5, 0);
            this.scroll_steamAddons.Minimum = 0;
            this.scroll_steamAddons.MouseWheelBarPartitions = 10;
            this.scroll_steamAddons.Name = "scroll_steamAddons";
            this.scroll_steamAddons.Orientation = MetroFramework.Controls.MetroScrollOrientation.Vertical;
            this.scroll_steamAddons.ScrollbarSize = 5;
            this.scroll_steamAddons.Size = new System.Drawing.Size(5, 530);
            this.scroll_steamAddons.TabIndex = 4;
            this.scroll_steamAddons.UseSelectable = true;
            this.scroll_steamAddons.Visible = false;
            this.scroll_steamAddons.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scroll_steamAddons_Scroll);
            // 
            // flowpanel_steamworkshopAddonsList
            // 
            this.flowpanel_steamworkshopAddonsList.AutoScroll = true;
            this.flowpanel_steamworkshopAddonsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.flowpanel_steamworkshopAddonsList.ContextMenuStrip = this.steamworkshopMenu;
            this.flowpanel_steamworkshopAddonsList.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowpanel_steamworkshopAddonsList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowpanel_steamworkshopAddonsList.Location = new System.Drawing.Point(0, 30);
            this.flowpanel_steamworkshopAddonsList.MinimumSize = new System.Drawing.Size(460, 0);
            this.flowpanel_steamworkshopAddonsList.Name = "flowpanel_steamworkshopAddonsList";
            this.flowpanel_steamworkshopAddonsList.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.flowpanel_steamworkshopAddonsList.Size = new System.Drawing.Size(460, 530);
            this.flowpanel_steamworkshopAddonsList.TabIndex = 0;
            this.flowpanel_steamworkshopAddonsList.WrapContents = false;
            this.flowpanel_steamworkshopAddonsList.Paint += new System.Windows.Forms.PaintEventHandler(this.flowpanel_steamworkshopAddonsList_Paint);
            // 
            // doubleBufferPanel3
            // 
            this.doubleBufferPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.doubleBufferPanel3.Controls.Add(this.chb_workshopEnabled);
            this.doubleBufferPanel3.Controls.Add(this.materialLabel5);
            this.doubleBufferPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.doubleBufferPanel3.Location = new System.Drawing.Point(0, 0);
            this.doubleBufferPanel3.Name = "doubleBufferPanel3";
            this.doubleBufferPanel3.Size = new System.Drawing.Size(460, 30);
            this.doubleBufferPanel3.TabIndex = 3;
            // 
            // chb_workshopEnabled
            // 
            this.chb_workshopEnabled.Checked = false;
            this.chb_workshopEnabled.Depth = 0;
            this.chb_workshopEnabled.Font = new System.Drawing.Font("Roboto", 10F);
            this.chb_workshopEnabled.Location = new System.Drawing.Point(424, -3);
            this.chb_workshopEnabled.Margin = new System.Windows.Forms.Padding(0);
            this.chb_workshopEnabled.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chb_workshopEnabled.MouseState = MaterialSkin.MouseState.HOVER;
            this.chb_workshopEnabled.Name = "chb_workshopEnabled";
            this.chb_workshopEnabled.Ripple = true;
            this.chb_workshopEnabled.Shadow = null;
            this.chb_workshopEnabled.ShadowShape = null;
            this.chb_workshopEnabled.Size = new System.Drawing.Size(36, 36);
            this.chb_workshopEnabled.TabIndex = 3;
            this.chb_workshopEnabled.Text = null;
            this.chb_workshopEnabled.CheckedChanged += new MaterialSkin.Controls.MaterialCheckBox.CheckedChangedEventHandler(this.chb_workshopEnabled_CheckedChanged);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.FontSize = 11;
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(8, 6);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Primary = false;
            this.materialLabel5.Shadow = null;
            this.materialLabel5.ShadowShape = null;
            this.materialLabel5.Size = new System.Drawing.Size(179, 19);
            this.materialLabel5.TabIndex = 2;
            this.materialLabel5.Text = "Steam Workshop Addons";
            // 
            // lbl_addonOptions
            // 
            this.lbl_addonOptions.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_addonOptions.AutoSize = true;
            this.lbl_addonOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.lbl_addonOptions.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_addonOptions.Location = new System.Drawing.Point(-8, 15);
            this.lbl_addonOptions.Name = "lbl_addonOptions";
            this.lbl_addonOptions.Size = new System.Drawing.Size(342, 55);
            this.lbl_addonOptions.TabIndex = 1;
            this.lbl_addonOptions.Text = "Addon Options";
            // 
            // win_titleBar
            // 
            this.win_titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.win_titleBar.Controls.Add(this.WindowTitle);
            this.win_titleBar.Controls.Add(this.btn_windowMenu);
            this.win_titleBar.Controls.Add(this.btn_windowClose);
            this.win_titleBar.Controls.Add(this.btn_windowMinimize);
            this.win_titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.win_titleBar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.win_titleBar.Location = new System.Drawing.Point(0, 0);
            this.win_titleBar.MaximumSize = new System.Drawing.Size(0, 30);
            this.win_titleBar.MinimumSize = new System.Drawing.Size(1300, 30);
            this.win_titleBar.Name = "win_titleBar";
            this.win_titleBar.Size = new System.Drawing.Size(1300, 30);
            this.win_titleBar.TabIndex = 0;
            this.win_titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.win_titleBar_MouseDown);
            // 
            // WindowTitle
            // 
            this.WindowTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WindowTitle.AutoSize = true;
            this.WindowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.WindowTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(125)))));
            this.WindowTitle.Location = new System.Drawing.Point(250, 6);
            this.WindowTitle.MinimumSize = new System.Drawing.Size(800, 0);
            this.WindowTitle.Name = "WindowTitle";
            this.WindowTitle.Size = new System.Drawing.Size(800, 20);
            this.WindowTitle.TabIndex = 4;
            this.WindowTitle.Text = "%window title%";
            this.WindowTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.WindowTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowTitle_MouseDown);
            // 
            // btn_windowMenu
            // 
            this.btn_windowMenu.Image = global::arma3Launcher.Properties.Resources.windowMenu;
            this.btn_windowMenu.Location = new System.Drawing.Point(4, 2);
            this.btn_windowMenu.Name = "btn_windowMenu";
            this.btn_windowMenu.Size = new System.Drawing.Size(24, 27);
            this.btn_windowMenu.TabIndex = 3;
            this.btn_windowMenu.TabStop = false;
            this.btn_windowMenu.Click += new System.EventHandler(this.btn_windowMenu_Click);
            this.btn_windowMenu.MouseEnter += new System.EventHandler(this.btn_windowMenu_MouseEnter);
            this.btn_windowMenu.MouseLeave += new System.EventHandler(this.btn_windowMenu_MouseLeave);
            // 
            // btn_windowClose
            // 
            this.btn_windowClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_windowClose.Image = global::arma3Launcher.Properties.Resources.windowClose;
            this.btn_windowClose.Location = new System.Drawing.Point(1270, 2);
            this.btn_windowClose.Name = "btn_windowClose";
            this.btn_windowClose.Size = new System.Drawing.Size(24, 27);
            this.btn_windowClose.TabIndex = 0;
            this.btn_windowClose.TabStop = false;
            this.btn_windowClose.Click += new System.EventHandler(this.btn_windowClose_Click);
            this.btn_windowClose.MouseEnter += new System.EventHandler(this.btn_windowClose_MouseEnter);
            this.btn_windowClose.MouseLeave += new System.EventHandler(this.btn_windowClose_MouseLeave);
            // 
            // btn_windowMinimize
            // 
            this.btn_windowMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_windowMinimize.Image = global::arma3Launcher.Properties.Resources.windowToTaskbar;
            this.btn_windowMinimize.Location = new System.Drawing.Point(1241, 2);
            this.btn_windowMinimize.Name = "btn_windowMinimize";
            this.btn_windowMinimize.Size = new System.Drawing.Size(24, 27);
            this.btn_windowMinimize.TabIndex = 2;
            this.btn_windowMinimize.TabStop = false;
            this.btn_windowMinimize.Click += new System.EventHandler(this.btn_windowMinimize_Click);
            this.btn_windowMinimize.MouseEnter += new System.EventHandler(this.btn_windowMinimize_MouseEnter);
            this.btn_windowMinimize.MouseLeave += new System.EventHandler(this.btn_windowMinimize_MouseLeave);
            // 
            // MainForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.win_mainWindow);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1300, 793);
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.Name = "MainForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm2";
            this.Activated += new System.EventHandler(this.MainForm2_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm2_FormClosing);
            this.Load += new System.EventHandler(this.MainForm2_Load);
            this.Shown += new System.EventHandler(this.MainForm2_Shown);
            this.Resize += new System.EventHandler(this.MainForm2_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelDownload)).EndInit();
            this.flowAddonsMenu.ResumeLayout(false);
            this.repositoryMenu.ResumeLayout(false);
            this.optionaladdonsMenu.ResumeLayout(false);
            this.steamworkshopMenu.ResumeLayout(false);
            this.win_mainWindow.ResumeLayout(false);
            this.panel_sideMenu.ResumeLayout(false);
            this.sidemenu_menuList.ResumeLayout(false);
            this.doubleBufferPanel5.ResumeLayout(false);
            this.doubleBufferPanel5.PerformLayout();
            this.doubleBufferPanel7.ResumeLayout(false);
            this.doubleBufferPanel7.PerformLayout();
            this.doubleBufferPanel9.ResumeLayout(false);
            this.doubleBufferPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_repoBusy)).EndInit();
            this.doubleBufferPanel11.ResumeLayout(false);
            this.doubleBufferPanel11.PerformLayout();
            this.sidemenu_botPanel.ResumeLayout(false);
            this.sidemenu_botPanel.PerformLayout();
            this.panel_mainPanel.ResumeLayout(false);
            this.panel_outterPanel.ResumeLayout(false);
            this.panel_launchOptions.ResumeLayout(false);
            this.panel_launchOptions.PerformLayout();
            this.panel_contentLaunchOptions.ResumeLayout(false);
            this.panel_launchOptionsCenter.ResumeLayout(false);
            this.panel_launchOptionsCenter.PerformLayout();
            this.flowpanel_serverOptions.ResumeLayout(false);
            this.panel_serverOptions.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel_headlessOptions.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.flowpanel_launchOptionsChb.ResumeLayout(false);
            this.flowpanel_launchOptionsChb.PerformLayout();
            this.panel_preferences.ResumeLayout(false);
            this.panel_preferences.PerformLayout();
            this.panel_contentPreferences.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowpanel_preferencesDirectories.ResumeLayout(false);
            this.panel_Arma3Dir.ResumeLayout(false);
            this.panel_Arma3Dir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_openA3Dir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_browseA3Dir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_ereaseArmaDir)).EndInit();
            this.panel_addonsDir.ResumeLayout(false);
            this.panel_addonsDir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_ereaseAddonsDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_openAddonsDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_browseAddonsDir)).EndInit();
            this.panel_optionalAddonsDir.ResumeLayout(false);
            this.panel_optionalAddonsDir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_ereaseOptionalDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_openOptionalDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_browseOptionalDir)).EndInit();
            this.panel_TeamSpeakDir.ResumeLayout(false);
            this.panel_TeamSpeakDir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_ereaseTSDir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_openTS3Dir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_pref_browseTS3Dir)).EndInit();
            this.panel_repositoryDownloads.ResumeLayout(false);
            this.panel_repositoryDownloads.PerformLayout();
            this.panel_contentRepositoryDownloads.ResumeLayout(false);
            this.panel_repoBottom.ResumeLayout(false);
            this.panel_repoDownload.ResumeLayout(false);
            this.panel_repoDownload.PerformLayout();
            this.panel_repoInfo.ResumeLayout(false);
            this.panel_repoInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.panel_addonPacks.ResumeLayout(false);
            this.panel_addonPacksFlow.ResumeLayout(false);
            this.panel_addonPacksFlow.PerformLayout();
            this.flowpanel_addonPacks.ResumeLayout(false);
            this.panel_addonOptions.ResumeLayout(false);
            this.panel_addonOptions.PerformLayout();
            this.panel_contentAddonOptions.ResumeLayout(false);
            this.panel_sideAddonOptions.ResumeLayout(false);
            this.sideAOP_armaholic.ResumeLayout(false);
            this.sideAOP_armaholic.PerformLayout();
            this.sideAOP_steamworkshop.ResumeLayout(false);
            this.sideAOP_steamworkshop.PerformLayout();
            this.sideAOP_taskforceradio.ResumeLayout(false);
            this.sideAOP_taskforceradio.PerformLayout();
            this.sideAOP_userconfig.ResumeLayout(false);
            this.sideAOP_userconfig.PerformLayout();
            this.panel_optionalAddons.ResumeLayout(false);
            this.doubleBufferPanel13.ResumeLayout(false);
            this.doubleBufferPanel13.PerformLayout();
            this.panel_steamworkshopAddons.ResumeLayout(false);
            this.doubleBufferPanel3.ResumeLayout(false);
            this.doubleBufferPanel3.PerformLayout();
            this.win_titleBar.ResumeLayout(false);
            this.win_titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_windowMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_windowClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_windowMinimize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private arma3Launcher.Controls.DoubleBufferPanel win_titleBar;
        private arma3Launcher.Controls.DoubleBufferPanel panel_sideMenu;
        private System.Windows.Forms.Label txt_versionNumber;
        private System.Windows.Forms.Label menu_about;
        private System.Windows.Forms.Label menu_help;
        private System.Windows.Forms.Label menu_preferences;
        private System.Windows.Forms.Label menu_repositoryDownloads;
        private System.Windows.Forms.Label menu_launchOptions;
        private System.Windows.Forms.Label menu_addonPacks;
        private System.Windows.Forms.PictureBox btn_windowMinimize;
        private System.Windows.Forms.PictureBox btn_windowClose;
        private System.Windows.Forms.PictureBox btn_windowMenu;
        private arma3Launcher.Controls.DoubleBufferPanel win_mainWindow;
        private System.Windows.Forms.Label WindowTitle;
        private arma3Launcher.Controls.DoubleBufferPanel panel_mainPanel;
        private arma3Launcher.Controls.DoubleBufferPanel panel_outterPanel;
        private arma3Launcher.Controls.DoubleBufferPanel panel_addonPacks;
        private arma3Launcher.Controls.DoubleBufferPanel panel_launchOptions;
        private arma3Launcher.Controls.DoubleBufferPanel panel_preferences;
        private arma3Launcher.Controls.DoubleBufferPanel panel_repositoryDownloads;
        private arma3Launcher.Controls.DoubleBufferPanel panel_addonPacksFlow;
        private System.Windows.Forms.Label btn_addonsOptionsOpen;
        private arma3Launcher.Controls.DoubleBufferFlowPanel flowpanel_addonPacks;
        private arma3Launcher.Controls.DoubleBufferPanel panel2;
        private arma3Launcher.Controls.DoubleBufferPanel panel3;
        private arma3Launcher.Controls.DoubleBufferPanel panel4;
        private arma3Launcher.Controls.DoubleBufferPanel panel5;
        private arma3Launcher.Controls.DoubleBufferPanel panel6;
        private arma3Launcher.Controls.DoubleBufferPanel panel8;
        private arma3Launcher.Controls.DoubleBufferPanel panel_addonOptions;
        private System.Windows.Forms.Label btn_addonsOptionsClose;
        private arma3Launcher.Controls.DoubleBufferPanel panel7;
        private arma3Launcher.Controls.DoubleBufferPanel panel9;
        private arma3Launcher.Controls.DoubleBufferPanel panel10;
        private System.Windows.Forms.Label lbl_addonOptions;
        private arma3Launcher.Controls.DoubleBufferPanel panel_contentAddonOptions;
        private arma3Launcher.Controls.DoubleBufferPanel panel_contentLaunchOptions;
        private System.Windows.Forms.Label lbl_launchOptions;
        private arma3Launcher.Controls.DoubleBufferPanel panel_contentRepositoryDownloads;
        private System.Windows.Forms.Label lbl_repositoryDownloads;
        private arma3Launcher.Controls.DoubleBufferPanel panel_contentPreferences;
        private System.Windows.Forms.Label lbl_preferences;
        private arma3Launcher.Controls.DoubleBufferPanel panel_repoBottom;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_repofilemissing;
        private System.Windows.Forms.Label lbl_repofileinvalid;
        private System.Windows.Forms.Label lbl_repofileok;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.ImageList imageListRepo;
        private System.Windows.Forms.ToolTip toolTip;
        private arma3Launcher.Controls.DoubleBufferTreeView trv_repoContent;
        private arma3Launcher.Controls.DoubleBufferFlowPanel flowpanel_launchOptionsChb;
        private MaterialSkin.Controls.MaterialCheckBox chb_showScriptErrors;
        private MaterialSkin.Controls.MaterialCheckBox chb_noPause;
        private MaterialSkin.Controls.MaterialCheckBox chb_noSplash;
        private MaterialSkin.Controls.MaterialCheckBox chb_skipIntro;
        private MaterialSkin.Controls.MaterialCheckBox chb_window;
        private MaterialSkin.Controls.MaterialCheckBox chb_enableHT;
        private MaterialSkin.Controls.MaterialCheckBox chb_hugePages;
        private MaterialSkin.Controls.MaterialCheckBox chb_filePatching;
        private MaterialSkin.Controls.MaterialCheckBox chb_worldEmpty;
        private MaterialSkin.Controls.MaterialCheckBox chb_battleye;
        private MaterialSkin.Controls.MaterialCheckBox chb_use64Bit;
        private MetroFramework.Controls.MetroComboBox cb_exThreads;
        private MetroFramework.Controls.MetroComboBox cb_cpuCount;
        private MaterialSkin.Controls.MaterialCheckBox chb_malloc;
        private MaterialSkin.Controls.MaterialCheckBox chb_exThreads;
        private MaterialSkin.Controls.MaterialCheckBox chb_cpuCount;
        private MaterialSkin.Controls.MaterialCheckBox chb_maxMem;
        private MetroFramework.Controls.MetroComboBox cb_malloc;
        private arma3Launcher.Controls.DoubleBufferFlowPanel flowpanel_serverOptions;
        private arma3Launcher.Controls.DoubleBufferPanel panel_serverOptions;
        private arma3Launcher.Controls.DoubleBufferPanel panel23;
        private MetroFramework.Controls.MetroComboBox cb_serverProfile;
        private MetroFramework.Controls.MetroComboBox cb_serverConfig;
        private arma3Launcher.Controls.DoubleBufferPanel panel24;
        private System.Windows.Forms.Label label30;
        private arma3Launcher.Controls.DoubleBufferPanel panel_headlessOptions;
        private arma3Launcher.Controls.DoubleBufferPanel panel25;
        private MetroFramework.Controls.MetroComboBox cb_hcProfile;
        private arma3Launcher.Controls.DoubleBufferPanel panel26;
        private System.Windows.Forms.Label label37;
        private arma3Launcher.Controls.DoubleBufferPanel panel1;
        private arma3Launcher.Controls.DoubleBufferPanel panel17;
        private arma3Launcher.Controls.DoubleBufferFlowPanel flowpanel_preferencesDirectories;
        private arma3Launcher.Controls.DoubleBufferPanel panel_addonsDir;
        private System.Windows.Forms.Label lbl_pref_AddonsDir;
        private System.Windows.Forms.PictureBox btn_pref_openAddonsDir;
        private System.Windows.Forms.PictureBox btn_pref_browseAddonsDir;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtb_pref_addonsDirectory;
        private arma3Launcher.Controls.DoubleBufferPanel panel_TeamSpeakDir;
        private System.Windows.Forms.PictureBox btn_pref_openTS3Dir;
        private System.Windows.Forms.PictureBox btn_pref_browseTS3Dir;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtb_pref_tsDirectory;
        private System.Windows.Forms.Label lbl_pref_TeamSpeakDir;
        private arma3Launcher.Controls.DoubleBufferPanel panel_Arma3Dir;
        private System.Windows.Forms.PictureBox btn_pref_openA3Dir;
        private System.Windows.Forms.PictureBox btn_pref_browseA3Dir;
        private System.Windows.Forms.Label lbl_pref_Arma3Dir;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtb_pref_armaDirectory;
        private arma3Launcher.Controls.DoubleBufferFlowPanel flowLayoutPanel2;
        private System.Windows.Forms.Label txt_pref_gamePrefrences;
        private MaterialSkin.Controls.MaterialCheckBox chb_pref_startGame;
        private MaterialSkin.Controls.MaterialCheckBox chb_pref_joinServer;
        private MaterialSkin.Controls.MaterialCheckBox chb_pref_joinTSServer;
        private MaterialSkin.Controls.MaterialCheckBox chb_pref_serverAutopilot;
        private System.Windows.Forms.Label txt_pref_launcherPreferences;
        private arma3Launcher.Controls.DoubleBufferPanel panel18;
        private MaterialSkin.Controls.MaterialCheckBox chb_pref_runLauncherStartup;
        private MaterialSkin.Controls.MaterialCheckBox chb_pref_allowNotifications;
        private MaterialSkin.Controls.MaterialCheckBox chb_pref_autoDownload;
        private MaterialSkin.Controls.MaterialCheckBox chb_pref_serverMode;
        private System.Windows.Forms.FolderBrowserDialog dlg_folderBrowser;
        private System.Windows.Forms.ContextMenuStrip flowAddonsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmi_reloadPacks;
        private System.Windows.Forms.ToolStripMenuItem tsmi_addPrivatePack;
        private MaterialSkin.Controls.MaterialLabel lbl_clientProfile;
        private MetroFramework.Controls.MetroComboBox cb_clientProfile;
        private Controls.DoubleBufferPanel panel_launchOptionsCenter;
        private MetroFramework.Controls.MetroTextBox num_maxMem;
        private MaterialSkin.Controls.MaterialFlatButton btn_memIncrease;
        private MaterialSkin.Controls.MaterialFlatButton btn_memDecrease;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialFlatButton btn_decreaseHcInstances;
        private MetroFramework.Controls.MetroTextBox num_hcInstances;
        private MaterialSkin.Controls.MaterialFlatButton btn_increaseHcInstances;
        private MaterialSkin.Controls.MaterialFlatButton btn_checkRepo;
        private System.Windows.Forms.ContextMenuStrip repositoryMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmi_manageRepository;
        private System.Windows.Forms.ToolStripMenuItem tsmi_reloadRepository;
        private Controls.DoubleBufferPanel panel_repoInfo;
        private Controls.DoubleBufferPanel panel_repoDownload;
        private System.Windows.Forms.Label txt_percentageStatus;
        private System.Windows.Forms.Label txt_progressStatus;
        private Controls.Windows7ProgressBar prb_progressBar_All;
        private System.Windows.Forms.PictureBox btn_cancelDownload;
        private Controls.Windows7ProgressBar prb_progressBar_File;
        private System.Windows.Forms.Label txt_curFile;
        private System.Windows.Forms.PictureBox img_repoBusy;
        private Controls.DoubleBufferFlowPanel flowpanel_steamworkshopAddonsList;
        private System.Windows.Forms.ToolStripMenuItem tsmi_openAddonFolder;
        private System.Windows.Forms.ToolStripSeparator repositorymenu_separator;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private Controls.DoubleBufferPanel panel_steamworkshopAddons;
        private Controls.DoubleBufferPanel doubleBufferPanel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MetroFramework.Controls.MetroComboBox cb_serverPack;
        private Controls.DoubleBufferPanel panel_serverOptions_vSep;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MetroFramework.Controls.MetroComboBox cb_serverMission;
        private Controls.DoubleBufferPanel panel_serverOptions_hSep;
        private System.Windows.Forms.PictureBox btn_pref_ereaseTSDir;
        private System.Windows.Forms.PictureBox btn_pref_ereaseAddonsDir;
        private System.Windows.Forms.PictureBox btn_pref_ereaseArmaDir;
        private Controls.DoubleBufferPanel sidemenu_botPanel;
        private Controls.DoubleBufferFlowPanel sidemenu_menuList;
        private Controls.DoubleBufferPanel doubleBufferPanel5;
        private Controls.DoubleBufferPanel doubleBufferPanel6;
        private Controls.DoubleBufferPanel doubleBufferPanel7;
        private Controls.DoubleBufferPanel doubleBufferPanel8;
        private Controls.DoubleBufferPanel doubleBufferPanel9;
        private Controls.DoubleBufferPanel doubleBufferPanel10;
        private Controls.DoubleBufferPanel doubleBufferPanel11;
        private MaterialSkin.Controls.MaterialCheckBox chb_pref_disableAnimations;
        private arma3Launcher.Controls.DoubleBufferFlowPanel panel_sideAddonOptions;
        private Controls.DoubleBufferPanel panel_optionalAddons;
        private Controls.DoubleBufferFlowPanel flowpanel_optionalAddons;
        private Controls.DoubleBufferPanel doubleBufferPanel13;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private Controls.DoubleBufferPanel doubleBufferPanel14;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialRaisedButton btn_openArmaholic;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialRaisedButton btn_openWorkshop;
        private System.Windows.Forms.ContextMenuStrip steamworkshopMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmi_openWorkshopFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_workshopReload;
        private System.Windows.Forms.ContextMenuStrip optionaladdonsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmi_openOptionalFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_reloadOptional;
        private Controls.DoubleBufferPanel sideAOP_armaholic;
        private Controls.DoubleBufferPanel sideAOP_steamworkshop;
        private Controls.DoubleBufferPanel sideAOP_separator1;
        private Controls.DoubleBufferPanel sideAOP_separator2;
        private Controls.DoubleBufferPanel panel_optionalAddonsDir;
        private System.Windows.Forms.PictureBox btn_pref_ereaseOptionalDir;
        private System.Windows.Forms.PictureBox btn_pref_openOptionalDir;
        private System.Windows.Forms.PictureBox btn_pref_browseOptionalDir;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtb_pref_optionalDirectory;
        private System.Windows.Forms.Label lbl_pref_OptionalDir;
        private Controls.DoubleBufferPanel doubleBufferPanel22;
        private Controls.DoubleBufferPanel doubleBufferPanel23;
        private Controls.DoubleBufferPanel doubleBufferPanel24;
        private MaterialSkin.Controls.MaterialSnackbar snackbar_mainWindow;
        private MetroFramework.Controls.MetroScrollBar scroll_optionalAddons;
        private MetroFramework.Controls.MetroScrollBar scroll_steamAddons;
        private Controls.DoubleBufferPanel sideAOP_separator3;
        private Controls.DoubleBufferPanel sideAOP_userconfig;
        private MaterialSkin.Controls.MaterialLabel materialLabel12;
        private MaterialSkin.Controls.MaterialRaisedButton btn_reinstallUserconfigFiles;
        private MaterialSkin.Controls.MaterialCheckBox chb_workshopEnabled;
        private MaterialSkin.Controls.MaterialCheckBox chb_optionalEnabled;
        private Controls.DoubleBufferPanel sideAOP_taskforceradio;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialRaisedButton btn_reinstallTFRPlugins;
        private MaterialSkin.Controls.MaterialFlatButton btn_updateRepo;
        private System.Windows.Forms.ToolStripMenuItem tsmi_selectedAddonName;
        private System.Windows.Forms.ToolStripMenuItem tsmi_openLocalFolder;
    }
}