namespace arma3Launcher.Controls
{
    partial class PackBlock
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txt_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_download_outter = new System.Windows.Forms.Panel();
            this.panel_download_inner = new System.Windows.Forms.Panel();
            this.txt_curFile = new System.Windows.Forms.Label();
            this.txt_percentageStatus = new System.Windows.Forms.Label();
            this.txt_progressStatus = new System.Windows.Forms.Label();
            this.panel_bgTitle = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_packID = new System.Windows.Forms.Label();
            this.txt_content = new System.Windows.Forms.Label();
            this.txt_allowed = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_cancelDownload = new System.Windows.Forms.PictureBox();
            this.btn_downloadpack = new System.Windows.Forms.PictureBox();
            this.btn_showAddons = new System.Windows.Forms.PictureBox();
            this.img_checkAllowed = new System.Windows.Forms.PictureBox();
            this.btn_useThis = new System.Windows.Forms.PictureBox();
            this.prb_progressBar_All = new arma3Launcher.Controls.Windows7ProgressBar();
            this.prb_progressBar_File = new arma3Launcher.Controls.Windows7ProgressBar();
            this.panel1.SuspendLayout();
            this.panel_download_outter.SuspendLayout();
            this.panel_download_inner.SuspendLayout();
            this.panel_bgTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_downloadpack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_showAddons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_checkAllowed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_useThis)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_title
            // 
            this.txt_title.AutoSize = true;
            this.txt_title.BackColor = System.Drawing.Color.Transparent;
            this.txt_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_title.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_title.Location = new System.Drawing.Point(7, 10);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(52, 15);
            this.txt_title.TabIndex = 0;
            this.txt_title.Text = "%Title%";
            this.txt_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_download_outter);
            this.panel1.Controls.Add(this.btn_downloadpack);
            this.panel1.Controls.Add(this.btn_showAddons);
            this.panel1.Controls.Add(this.img_checkAllowed);
            this.panel1.Controls.Add(this.btn_useThis);
            this.panel1.Controls.Add(this.panel_bgTitle);
            this.panel1.Controls.Add(this.txt_content);
            this.panel1.Controls.Add(this.txt_allowed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 174);
            this.panel1.TabIndex = 6;
            // 
            // panel_download_outter
            // 
            this.panel_download_outter.BackColor = System.Drawing.Color.OliveDrab;
            this.panel_download_outter.Controls.Add(this.panel_download_inner);
            this.panel_download_outter.Controls.Add(this.txt_percentageStatus);
            this.panel_download_outter.Controls.Add(this.txt_progressStatus);
            this.panel_download_outter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_download_outter.Location = new System.Drawing.Point(0, 114);
            this.panel_download_outter.Name = "panel_download_outter";
            this.panel_download_outter.Size = new System.Drawing.Size(860, 60);
            this.panel_download_outter.TabIndex = 18;
            // 
            // panel_download_inner
            // 
            this.panel_download_inner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel_download_inner.Controls.Add(this.btn_cancelDownload);
            this.panel_download_inner.Controls.Add(this.prb_progressBar_All);
            this.panel_download_inner.Controls.Add(this.prb_progressBar_File);
            this.panel_download_inner.Controls.Add(this.txt_curFile);
            this.panel_download_inner.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_download_inner.Location = new System.Drawing.Point(0, 18);
            this.panel_download_inner.Name = "panel_download_inner";
            this.panel_download_inner.Size = new System.Drawing.Size(860, 42);
            this.panel_download_inner.TabIndex = 0;
            // 
            // txt_curFile
            // 
            this.txt_curFile.AutoSize = true;
            this.txt_curFile.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.txt_curFile.ForeColor = System.Drawing.Color.DarkGray;
            this.txt_curFile.Location = new System.Drawing.Point(5, 2);
            this.txt_curFile.MinimumSize = new System.Drawing.Size(250, 0);
            this.txt_curFile.Name = "txt_curFile";
            this.txt_curFile.Size = new System.Drawing.Size(250, 12);
            this.txt_curFile.TabIndex = 14;
            // 
            // txt_percentageStatus
            // 
            this.txt_percentageStatus.AutoSize = true;
            this.txt_percentageStatus.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.txt_percentageStatus.ForeColor = System.Drawing.Color.LightGray;
            this.txt_percentageStatus.Location = new System.Drawing.Point(604, 3);
            this.txt_percentageStatus.MinimumSize = new System.Drawing.Size(250, 0);
            this.txt_percentageStatus.Name = "txt_percentageStatus";
            this.txt_percentageStatus.Size = new System.Drawing.Size(250, 12);
            this.txt_percentageStatus.TabIndex = 13;
            this.txt_percentageStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_progressStatus
            // 
            this.txt_progressStatus.AutoSize = true;
            this.txt_progressStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txt_progressStatus.Location = new System.Drawing.Point(4, 2);
            this.txt_progressStatus.MaximumSize = new System.Drawing.Size(450, 0);
            this.txt_progressStatus.MinimumSize = new System.Drawing.Size(450, 0);
            this.txt_progressStatus.Name = "txt_progressStatus";
            this.txt_progressStatus.Size = new System.Drawing.Size(450, 15);
            this.txt_progressStatus.TabIndex = 12;
            this.txt_progressStatus.Text = "%Download Status%";
            // 
            // panel_bgTitle
            // 
            this.panel_bgTitle.BackColor = System.Drawing.Color.DimGray;
            this.panel_bgTitle.Controls.Add(this.panel2);
            this.panel_bgTitle.Controls.Add(this.txt_title);
            this.panel_bgTitle.Controls.Add(this.txt_packID);
            this.panel_bgTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_bgTitle.Location = new System.Drawing.Point(0, 0);
            this.panel_bgTitle.Name = "panel_bgTitle";
            this.panel_bgTitle.Size = new System.Drawing.Size(860, 38);
            this.panel_bgTitle.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.OliveDrab;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(860, 4);
            this.panel2.TabIndex = 11;
            // 
            // txt_packID
            // 
            this.txt_packID.AutoSize = true;
            this.txt_packID.BackColor = System.Drawing.Color.Transparent;
            this.txt_packID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_packID.ForeColor = System.Drawing.Color.Gray;
            this.txt_packID.Location = new System.Drawing.Point(703, 11);
            this.txt_packID.MinimumSize = new System.Drawing.Size(150, 0);
            this.txt_packID.Name = "txt_packID";
            this.txt_packID.Size = new System.Drawing.Size(150, 13);
            this.txt_packID.TabIndex = 10;
            this.txt_packID.Text = "%pack_ID%";
            this.txt_packID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_content
            // 
            this.txt_content.AutoSize = true;
            this.txt_content.BackColor = System.Drawing.Color.Transparent;
            this.txt_content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_content.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_content.Location = new System.Drawing.Point(30, 61);
            this.txt_content.MaximumSize = new System.Drawing.Size(800, 0);
            this.txt_content.MinimumSize = new System.Drawing.Size(800, 52);
            this.txt_content.Name = "txt_content";
            this.txt_content.Size = new System.Drawing.Size(800, 52);
            this.txt_content.TabIndex = 11;
            this.txt_content.Text = "%Content%\r\n";
            // 
            // txt_allowed
            // 
            this.txt_allowed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_allowed.AutoSize = true;
            this.txt_allowed.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_allowed.Location = new System.Drawing.Point(23, 143);
            this.txt_allowed.Name = "txt_allowed";
            this.txt_allowed.Size = new System.Drawing.Size(54, 13);
            this.txt_allowed.TabIndex = 15;
            this.txt_allowed.Text = "Allowed: ";
            this.txt_allowed.Visible = false;
            // 
            // btn_cancelDownload
            // 
            this.btn_cancelDownload.Image = global::arma3Launcher.Properties.Resources.cloud_off;
            this.btn_cancelDownload.Location = new System.Drawing.Point(817, 5);
            this.btn_cancelDownload.Name = "btn_cancelDownload";
            this.btn_cancelDownload.Size = new System.Drawing.Size(32, 32);
            this.btn_cancelDownload.TabIndex = 17;
            this.btn_cancelDownload.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_cancelDownload, "Cancel download");
            this.btn_cancelDownload.Click += new System.EventHandler(this.btn_cancelDownload_Click_1);
            this.btn_cancelDownload.MouseLeave += new System.EventHandler(this.btn_cancelDownload_MouseLeave);
            this.btn_cancelDownload.MouseHover += new System.EventHandler(this.btn_cancelDownload_MouseHover);
            // 
            // btn_downloadpack
            // 
            this.btn_downloadpack.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_downloadpack.Image = global::arma3Launcher.Properties.Resources.cloud_download;
            this.btn_downloadpack.Location = new System.Drawing.Point(698, 141);
            this.btn_downloadpack.Name = "btn_downloadpack";
            this.btn_downloadpack.Size = new System.Drawing.Size(16, 16);
            this.btn_downloadpack.TabIndex = 17;
            this.btn_downloadpack.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_downloadpack, "Download pack");
            this.btn_downloadpack.Click += new System.EventHandler(this.btn_downloadpack_Click);
            this.btn_downloadpack.MouseLeave += new System.EventHandler(this.btn_downloadpack_MouseLeave);
            this.btn_downloadpack.MouseHover += new System.EventHandler(this.btn_downloadpack_MouseHover);
            // 
            // btn_showAddons
            // 
            this.btn_showAddons.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_showAddons.Image = global::arma3Launcher.Properties.Resources.archive_w;
            this.btn_showAddons.Location = new System.Drawing.Point(724, 141);
            this.btn_showAddons.Name = "btn_showAddons";
            this.btn_showAddons.Size = new System.Drawing.Size(16, 16);
            this.btn_showAddons.TabIndex = 16;
            this.btn_showAddons.TabStop = false;
            this.toolTip1.SetToolTip(this.btn_showAddons, "Addons on this pack");
            this.btn_showAddons.Click += new System.EventHandler(this.btn_showAddons_Click);
            this.btn_showAddons.MouseLeave += new System.EventHandler(this.btn_showAddons_MouseLeave);
            this.btn_showAddons.MouseHover += new System.EventHandler(this.btn_showAddons_MouseHover);
            // 
            // img_checkAllowed
            // 
            this.img_checkAllowed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.img_checkAllowed.BackgroundImage = global::arma3Launcher.Properties.Resources.check_circle;
            this.img_checkAllowed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.img_checkAllowed.Location = new System.Drawing.Point(11, 143);
            this.img_checkAllowed.Name = "img_checkAllowed";
            this.img_checkAllowed.Size = new System.Drawing.Size(12, 13);
            this.img_checkAllowed.TabIndex = 14;
            this.img_checkAllowed.TabStop = false;
            this.img_checkAllowed.Visible = false;
            // 
            // btn_useThis
            // 
            this.btn_useThis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_useThis.Image = global::arma3Launcher.Properties.Resources.useThis_inactive;
            this.btn_useThis.Location = new System.Drawing.Point(755, 129);
            this.btn_useThis.Name = "btn_useThis";
            this.btn_useThis.Size = new System.Drawing.Size(100, 40);
            this.btn_useThis.TabIndex = 13;
            this.btn_useThis.TabStop = false;
            this.btn_useThis.Click += new System.EventHandler(this.btn_useThis_Click);
            this.btn_useThis.MouseLeave += new System.EventHandler(this.btn_useThis_MouseLeave);
            this.btn_useThis.MouseHover += new System.EventHandler(this.btn_useThis_MouseHover);
            // 
            // prb_progressBar_All
            // 
            this.prb_progressBar_All.ContainerControl = this;
            this.prb_progressBar_All.Location = new System.Drawing.Point(12, 28);
            this.prb_progressBar_All.Name = "prb_progressBar_All";
            this.prb_progressBar_All.Size = new System.Drawing.Size(790, 5);
            this.prb_progressBar_All.TabIndex = 16;
            // 
            // prb_progressBar_File
            // 
            this.prb_progressBar_File.ContainerControl = this;
            this.prb_progressBar_File.Location = new System.Drawing.Point(12, 16);
            this.prb_progressBar_File.Name = "prb_progressBar_File";
            this.prb_progressBar_File.Size = new System.Drawing.Size(790, 12);
            this.prb_progressBar_File.TabIndex = 15;
            // 
            // PackBlock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(860, 109);
            this.Name = "PackBlock";
            this.Size = new System.Drawing.Size(860, 174);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_download_outter.ResumeLayout(false);
            this.panel_download_outter.PerformLayout();
            this.panel_download_inner.ResumeLayout(false);
            this.panel_download_inner.PerformLayout();
            this.panel_bgTitle.ResumeLayout(false);
            this.panel_bgTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancelDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_downloadpack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_showAddons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_checkAllowed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_useThis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txt_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txt_packID;
        private System.Windows.Forms.Label txt_content;
        private System.Windows.Forms.Panel panel_bgTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btn_useThis;
        private System.Windows.Forms.PictureBox img_checkAllowed;
        private System.Windows.Forms.Label txt_allowed;
        private System.Windows.Forms.PictureBox btn_showAddons;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox btn_downloadpack;
        private System.Windows.Forms.Panel panel_download_outter;
        private System.Windows.Forms.Panel panel_download_inner;
        private Windows7ProgressBar prb_progressBar_All;
        private System.Windows.Forms.Label txt_progressStatus;
        private System.Windows.Forms.Label txt_curFile;
        private System.Windows.Forms.Label txt_percentageStatus;
        private Windows7ProgressBar prb_progressBar_File;
        private System.Windows.Forms.PictureBox btn_cancelDownload;
    }
}
