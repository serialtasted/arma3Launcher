namespace arma3Launcher.Windows
{
    partial class AddonManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddonManager));
            this.panel3 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel1 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.buildLog = new System.Windows.Forms.TextBox();
            this.chbl_repoContent = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.prgb_repoBuild = new arma3Launcher.Controls.Windows7ProgressBar();
            this.lbl_buildStatus = new System.Windows.Forms.Label();
            this.chb_checkAll = new System.Windows.Forms.CheckBox();
            this.btn_buildRepo = new System.Windows.Forms.Button();
            this.window_topBar = new arma3Launcher.Controls.DoubleBufferPanel();
            this.lbl_repoLocation = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.txtb_repoLocation = new System.Windows.Forms.TextBox();
            this.txt_title = new System.Windows.Forms.Label();
            this.dlg_folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_openRepoLocation = new System.Windows.Forms.PictureBox();
            this.btn_browseRepoLocation = new System.Windows.Forms.PictureBox();
            this.btn_ereaseRepoLocation = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.window_topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_openRepoLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_browseRepoLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ereaseRepoLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.window_topBar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(600, 463);
            this.panel3.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel1.Controls.Add(this.buildLog);
            this.panel1.Controls.Add(this.chbl_repoContent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 73);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(598, 343);
            this.panel1.TabIndex = 13;
            // 
            // buildLog
            // 
            this.buildLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.buildLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.buildLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buildLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildLog.ForeColor = System.Drawing.Color.Lime;
            this.buildLog.Location = new System.Drawing.Point(8, 165);
            this.buildLog.Multiline = true;
            this.buildLog.Name = "buildLog";
            this.buildLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.buildLog.Size = new System.Drawing.Size(582, 170);
            this.buildLog.TabIndex = 1;
            // 
            // chbl_repoContent
            // 
            this.chbl_repoContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.chbl_repoContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chbl_repoContent.CheckOnClick = true;
            this.chbl_repoContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbl_repoContent.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbl_repoContent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chbl_repoContent.FormattingEnabled = true;
            this.chbl_repoContent.Location = new System.Drawing.Point(8, 8);
            this.chbl_repoContent.Name = "chbl_repoContent";
            this.chbl_repoContent.ScrollAlwaysVisible = true;
            this.chbl_repoContent.Size = new System.Drawing.Size(582, 153);
            this.chbl_repoContent.Sorted = true;
            this.chbl_repoContent.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.panel2.Controls.Add(this.prgb_repoBuild);
            this.panel2.Controls.Add(this.lbl_buildStatus);
            this.panel2.Controls.Add(this.chb_checkAll);
            this.panel2.Controls.Add(this.btn_buildRepo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 416);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 45);
            this.panel2.TabIndex = 19;
            // 
            // prgb_repoBuild
            // 
            this.prgb_repoBuild.ContainerControl = this;
            this.prgb_repoBuild.Location = new System.Drawing.Point(8, 20);
            this.prgb_repoBuild.Name = "prgb_repoBuild";
            this.prgb_repoBuild.Size = new System.Drawing.Size(376, 17);
            this.prgb_repoBuild.TabIndex = 2;
            // 
            // lbl_buildStatus
            // 
            this.lbl_buildStatus.AutoSize = true;
            this.lbl_buildStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_buildStatus.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_buildStatus.Location = new System.Drawing.Point(7, 4);
            this.lbl_buildStatus.Name = "lbl_buildStatus";
            this.lbl_buildStatus.Size = new System.Drawing.Size(85, 13);
            this.lbl_buildStatus.TabIndex = 21;
            this.lbl_buildStatus.Text = "%Build Status%";
            // 
            // chb_checkAll
            // 
            this.chb_checkAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chb_checkAll.AutoSize = true;
            this.chb_checkAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chb_checkAll.Location = new System.Drawing.Point(390, 4);
            this.chb_checkAll.MinimumSize = new System.Drawing.Size(99, 34);
            this.chb_checkAll.Name = "chb_checkAll";
            this.chb_checkAll.Size = new System.Drawing.Size(99, 34);
            this.chb_checkAll.TabIndex = 20;
            this.chb_checkAll.Text = "Check All";
            this.chb_checkAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chb_checkAll.UseVisualStyleBackColor = true;
            this.chb_checkAll.CheckedChanged += new System.EventHandler(this.chb_checkAll_CheckedChanged);
            // 
            // btn_buildRepo
            // 
            this.btn_buildRepo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_buildRepo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_buildRepo.Location = new System.Drawing.Point(492, 4);
            this.btn_buildRepo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btn_buildRepo.Name = "btn_buildRepo";
            this.btn_buildRepo.Size = new System.Drawing.Size(99, 34);
            this.btn_buildRepo.TabIndex = 18;
            this.btn_buildRepo.TabStop = false;
            this.btn_buildRepo.Text = "Build Repository";
            this.btn_buildRepo.UseVisualStyleBackColor = true;
            this.btn_buildRepo.Click += new System.EventHandler(this.btn_buildRepo_Click);
            // 
            // window_topBar
            // 
            this.window_topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.window_topBar.Controls.Add(this.btn_openRepoLocation);
            this.window_topBar.Controls.Add(this.btn_browseRepoLocation);
            this.window_topBar.Controls.Add(this.btn_ereaseRepoLocation);
            this.window_topBar.Controls.Add(this.lbl_repoLocation);
            this.window_topBar.Controls.Add(this.btn_close);
            this.window_topBar.Controls.Add(this.txtb_repoLocation);
            this.window_topBar.Controls.Add(this.txt_title);
            this.window_topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.window_topBar.Location = new System.Drawing.Point(0, 0);
            this.window_topBar.Name = "window_topBar";
            this.window_topBar.Size = new System.Drawing.Size(598, 73);
            this.window_topBar.TabIndex = 12;
            // 
            // lbl_repoLocation
            // 
            this.lbl_repoLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_repoLocation.AutoSize = true;
            this.lbl_repoLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_repoLocation.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_repoLocation.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_repoLocation.Location = new System.Drawing.Point(7, 42);
            this.lbl_repoLocation.Name = "lbl_repoLocation";
            this.lbl_repoLocation.Size = new System.Drawing.Size(116, 15);
            this.lbl_repoLocation.TabIndex = 14;
            this.lbl_repoLocation.Text = "Repository directory:";
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Image = global::arma3Launcher.Properties.Resources.arrow_down;
            this.btn_close.Location = new System.Drawing.Point(572, 11);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(16, 16);
            this.btn_close.TabIndex = 13;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            this.btn_close.MouseEnter += new System.EventHandler(this.btn_close_MouseEnter);
            this.btn_close.MouseLeave += new System.EventHandler(this.btn_close_MouseLeave);
            // 
            // txtb_repoLocation
            // 
            this.txtb_repoLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_repoLocation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtb_repoLocation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtb_repoLocation.ForeColor = System.Drawing.Color.DarkGray;
            this.txtb_repoLocation.Location = new System.Drawing.Point(129, 37);
            this.txtb_repoLocation.Name = "txtb_repoLocation";
            this.txtb_repoLocation.ReadOnly = true;
            this.txtb_repoLocation.Size = new System.Drawing.Size(408, 25);
            this.txtb_repoLocation.TabIndex = 14;
            this.txtb_repoLocation.TabStop = false;
            this.txtb_repoLocation.Text = "Set directory ->";
            this.txtb_repoLocation.TextChanged += new System.EventHandler(this.txtb_repoLocation_TextChanged);
            // 
            // txt_title
            // 
            this.txt_title.AutoSize = true;
            this.txt_title.BackColor = System.Drawing.Color.Transparent;
            this.txt_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_title.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_title.Location = new System.Drawing.Point(7, 10);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(119, 15);
            this.txt_title.TabIndex = 0;
            this.txt_title.Tag = "";
            this.txt_title.Text = "Repository Manager";
            this.txt_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dlg_folderBrowser
            // 
            this.dlg_folderBrowser.ShowNewFolderButton = false;
            // 
            // btn_openRepoLocation
            // 
            this.btn_openRepoLocation.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_openRepoLocation.Image = ((System.Drawing.Image)(resources.GetObject("btn_openRepoLocation.Image")));
            this.btn_openRepoLocation.Location = new System.Drawing.Point(568, 42);
            this.btn_openRepoLocation.Name = "btn_openRepoLocation";
            this.btn_openRepoLocation.Size = new System.Drawing.Size(16, 16);
            this.btn_openRepoLocation.TabIndex = 19;
            this.btn_openRepoLocation.TabStop = false;
            this.btn_openRepoLocation.Click += new System.EventHandler(this.btn_openRepoLocation_Click);
            this.btn_openRepoLocation.MouseEnter += new System.EventHandler(this.btn_openRepoLocation_MouseEnter);
            this.btn_openRepoLocation.MouseLeave += new System.EventHandler(this.btn_openRepoLocation_MouseLeave);
            // 
            // btn_browseRepoLocation
            // 
            this.btn_browseRepoLocation.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_browseRepoLocation.Image = global::arma3Launcher.Properties.Resources.addfolder_idle;
            this.btn_browseRepoLocation.Location = new System.Drawing.Point(548, 42);
            this.btn_browseRepoLocation.Name = "btn_browseRepoLocation";
            this.btn_browseRepoLocation.Size = new System.Drawing.Size(16, 16);
            this.btn_browseRepoLocation.TabIndex = 18;
            this.btn_browseRepoLocation.TabStop = false;
            this.btn_browseRepoLocation.Click += new System.EventHandler(this.btn_browseRepoLocation_Click);
            this.btn_browseRepoLocation.MouseEnter += new System.EventHandler(this.btn_browseRepoLocation_MouseEnter);
            this.btn_browseRepoLocation.MouseLeave += new System.EventHandler(this.btn_browseRepoLocation_MouseLeave);
            // 
            // btn_ereaseRepoLocation
            // 
            this.btn_ereaseRepoLocation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ereaseRepoLocation.Image = ((System.Drawing.Image)(resources.GetObject("btn_ereaseRepoLocation.Image")));
            this.btn_ereaseRepoLocation.Location = new System.Drawing.Point(518, 44);
            this.btn_ereaseRepoLocation.Name = "btn_ereaseRepoLocation";
            this.btn_ereaseRepoLocation.Size = new System.Drawing.Size(12, 12);
            this.btn_ereaseRepoLocation.TabIndex = 20;
            this.btn_ereaseRepoLocation.TabStop = false;
            this.btn_ereaseRepoLocation.Click += new System.EventHandler(this.btn_ereaseRepoLocation_Click);
            this.btn_ereaseRepoLocation.MouseEnter += new System.EventHandler(this.btn_ereaseRepoLocation_MouseEnter);
            this.btn_ereaseRepoLocation.MouseLeave += new System.EventHandler(this.btn_ereaseRepoLocation_MouseLeave);
            // 
            // AddonManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 463);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddonManager";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddonManager";
            this.Shown += new System.EventHandler(this.AddonManager_Shown);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.window_topBar.ResumeLayout(false);
            this.window_topBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_openRepoLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_browseRepoLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_ereaseRepoLocation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private arma3Launcher.Controls.DoubleBufferPanel panel3;
        private arma3Launcher.Controls.DoubleBufferPanel window_topBar;
        private System.Windows.Forms.PictureBox btn_close;
        private System.Windows.Forms.Label txt_title;
        private arma3Launcher.Controls.DoubleBufferPanel panel1;
        private System.Windows.Forms.Label lbl_repoLocation;
        private System.Windows.Forms.TextBox txtb_repoLocation;
        private System.Windows.Forms.CheckedListBox chbl_repoContent;
        private arma3Launcher.Controls.DoubleBufferPanel panel2;
        private System.Windows.Forms.Button btn_buildRepo;
        private System.Windows.Forms.FolderBrowserDialog dlg_folderBrowser;
        private System.Windows.Forms.CheckBox chb_checkAll;
        private System.Windows.Forms.Label lbl_buildStatus;
        private System.Windows.Forms.TextBox buildLog;
        private Controls.Windows7ProgressBar prgb_repoBuild;
        private System.Windows.Forms.PictureBox btn_openRepoLocation;
        private System.Windows.Forms.PictureBox btn_browseRepoLocation;
        private System.Windows.Forms.PictureBox btn_ereaseRepoLocation;
    }
}