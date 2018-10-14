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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel_packImage = new arma3Launcher.Controls.DoubleBufferPanel();
            this.panel_effectFade = new arma3Launcher.Controls.DoubleBufferPanel();
            this.btn_playTop = new System.Windows.Forms.PictureBox();
            this.panel_moreInfo = new arma3Launcher.Controls.DoubleBufferPanel();
            this.btn_playBot = new System.Windows.Forms.PictureBox();
            this.panel1 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.doubleBufferPanel1 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.scroll_packContent = new MetroFramework.Controls.MetroScrollBar();
            this.flowpanel_packContent = new arma3Launcher.Controls.DoubleBufferFlowPanel();
            this.lbl_packcontent = new System.Windows.Forms.Label();
            this.btn_addonsOptionsOpen = new System.Windows.Forms.Label();
            this.panel_packInfo = new arma3Launcher.Controls.DoubleBufferPanel();
            this.btn_addonsOptionsClose = new System.Windows.Forms.Label();
            this.txt_title = new System.Windows.Forms.Label();
            this.txt_content = new System.Windows.Forms.Label();
            this.panel_packImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_playTop)).BeginInit();
            this.panel_moreInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_playBot)).BeginInit();
            this.panel1.SuspendLayout();
            this.doubleBufferPanel1.SuspendLayout();
            this.panel_packInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_packImage
            // 
            this.panel_packImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.panel_packImage.BackgroundImage = global::arma3Launcher.Properties.Resources.nopackimg;
            this.panel_packImage.Controls.Add(this.panel_effectFade);
            this.panel_packImage.Controls.Add(this.btn_playTop);
            this.panel_packImage.Controls.Add(this.panel_moreInfo);
            this.panel_packImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_packImage.Location = new System.Drawing.Point(0, 0);
            this.panel_packImage.Name = "panel_packImage";
            this.panel_packImage.Size = new System.Drawing.Size(410, 200);
            this.panel_packImage.TabIndex = 6;
            // 
            // panel_effectFade
            // 
            this.panel_effectFade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel_effectFade.Location = new System.Drawing.Point(0, 0);
            this.panel_effectFade.Name = "panel_effectFade";
            this.panel_effectFade.Size = new System.Drawing.Size(0, 0);
            this.panel_effectFade.TabIndex = 17;
            // 
            // btn_playTop
            // 
            this.btn_playTop.BackColor = System.Drawing.Color.Transparent;
            this.btn_playTop.Image = global::arma3Launcher.Properties.Resources.play_btn_idle_top;
            this.btn_playTop.Location = new System.Drawing.Point(367, 68);
            this.btn_playTop.Name = "btn_playTop";
            this.btn_playTop.Size = new System.Drawing.Size(32, 12);
            this.btn_playTop.TabIndex = 18;
            this.btn_playTop.TabStop = false;
            this.btn_playTop.Visible = false;
            this.btn_playTop.Click += new System.EventHandler(this.btn_playTop_Click);
            this.btn_playTop.MouseEnter += new System.EventHandler(this.btn_playTop_MouseEnter);
            this.btn_playTop.MouseLeave += new System.EventHandler(this.btn_playTop_MouseLeave);
            // 
            // panel_moreInfo
            // 
            this.panel_moreInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            this.panel_moreInfo.Controls.Add(this.btn_playBot);
            this.panel_moreInfo.Controls.Add(this.panel1);
            this.panel_moreInfo.Controls.Add(this.panel_packInfo);
            this.panel_moreInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_moreInfo.Location = new System.Drawing.Point(0, 80);
            this.panel_moreInfo.MaximumSize = new System.Drawing.Size(0, 120);
            this.panel_moreInfo.Name = "panel_moreInfo";
            this.panel_moreInfo.Size = new System.Drawing.Size(410, 120);
            this.panel_moreInfo.TabIndex = 16;
            this.panel_moreInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_moreInfo_Paint);
            // 
            // btn_playBot
            // 
            this.btn_playBot.BackColor = System.Drawing.Color.Transparent;
            this.btn_playBot.Image = global::arma3Launcher.Properties.Resources.play_btn_idle_bot;
            this.btn_playBot.Location = new System.Drawing.Point(367, 0);
            this.btn_playBot.Name = "btn_playBot";
            this.btn_playBot.Size = new System.Drawing.Size(32, 20);
            this.btn_playBot.TabIndex = 13;
            this.btn_playBot.TabStop = false;
            this.btn_playBot.Click += new System.EventHandler(this.btn_playBot_Click);
            this.btn_playBot.MouseEnter += new System.EventHandler(this.btn_playBot_MouseEnter);
            this.btn_playBot.MouseLeave += new System.EventHandler(this.btn_playBot_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.doubleBufferPanel1);
            this.panel1.Controls.Add(this.lbl_packcontent);
            this.panel1.Controls.Add(this.btn_addonsOptionsOpen);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(410, 120);
            this.panel1.TabIndex = 1;
            // 
            // doubleBufferPanel1
            // 
            this.doubleBufferPanel1.Controls.Add(this.scroll_packContent);
            this.doubleBufferPanel1.Controls.Add(this.flowpanel_packContent);
            this.doubleBufferPanel1.Location = new System.Drawing.Point(26, 31);
            this.doubleBufferPanel1.MaximumSize = new System.Drawing.Size(370, 80);
            this.doubleBufferPanel1.MinimumSize = new System.Drawing.Size(370, 80);
            this.doubleBufferPanel1.Name = "doubleBufferPanel1";
            this.doubleBufferPanel1.Size = new System.Drawing.Size(370, 80);
            this.doubleBufferPanel1.TabIndex = 16;
            // 
            // scroll_packContent
            // 
            this.scroll_packContent.Dock = System.Windows.Forms.DockStyle.Right;
            this.scroll_packContent.LargeChange = 10;
            this.scroll_packContent.Location = new System.Drawing.Point(365, 0);
            this.scroll_packContent.Maximum = 100;
            this.scroll_packContent.MaximumSize = new System.Drawing.Size(5, 0);
            this.scroll_packContent.Minimum = 0;
            this.scroll_packContent.MouseWheelBarPartitions = 10;
            this.scroll_packContent.Name = "scroll_packContent";
            this.scroll_packContent.Orientation = MetroFramework.Controls.MetroScrollOrientation.Vertical;
            this.scroll_packContent.ScrollbarSize = 5;
            this.scroll_packContent.Size = new System.Drawing.Size(5, 80);
            this.scroll_packContent.TabIndex = 0;
            this.scroll_packContent.UseSelectable = true;
            this.scroll_packContent.Visible = false;
            this.scroll_packContent.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scroll_packContent_Scroll);
            // 
            // flowpanel_packContent
            // 
            this.flowpanel_packContent.AutoScroll = true;
            this.flowpanel_packContent.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.flowpanel_packContent.AutoScrollMinSize = new System.Drawing.Size(10, 10);
            this.flowpanel_packContent.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowpanel_packContent.Location = new System.Drawing.Point(0, 0);
            this.flowpanel_packContent.Name = "flowpanel_packContent";
            this.flowpanel_packContent.Padding = new System.Windows.Forms.Padding(3);
            this.flowpanel_packContent.Size = new System.Drawing.Size(370, 80);
            this.flowpanel_packContent.TabIndex = 14;
            this.flowpanel_packContent.Paint += new System.Windows.Forms.PaintEventHandler(this.flowpanel_packContent_Paint);
            // 
            // lbl_packcontent
            // 
            this.lbl_packcontent.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_packcontent.AutoSize = true;
            this.lbl_packcontent.BackColor = System.Drawing.Color.Transparent;
            this.lbl_packcontent.Font = new System.Drawing.Font("Lato", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_packcontent.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_packcontent.Location = new System.Drawing.Point(23, 10);
            this.lbl_packcontent.Name = "lbl_packcontent";
            this.lbl_packcontent.Size = new System.Drawing.Size(89, 17);
            this.lbl_packcontent.TabIndex = 15;
            this.lbl_packcontent.Text = "Pack content";
            this.lbl_packcontent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_addonsOptionsOpen
            // 
            this.btn_addonsOptionsOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addonsOptionsOpen.AutoSize = true;
            this.btn_addonsOptionsOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btn_addonsOptionsOpen.Font = new System.Drawing.Font("Consolas", 8F);
            this.btn_addonsOptionsOpen.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_addonsOptionsOpen.Location = new System.Drawing.Point(5, 42);
            this.btn_addonsOptionsOpen.MaximumSize = new System.Drawing.Size(14, 37);
            this.btn_addonsOptionsOpen.MinimumSize = new System.Drawing.Size(14, 37);
            this.btn_addonsOptionsOpen.Name = "btn_addonsOptionsOpen";
            this.btn_addonsOptionsOpen.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btn_addonsOptionsOpen.Size = new System.Drawing.Size(14, 37);
            this.btn_addonsOptionsOpen.TabIndex = 13;
            this.btn_addonsOptionsOpen.Text = "<";
            this.btn_addonsOptionsOpen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_addonsOptionsOpen.Click += new System.EventHandler(this.btn_addonsOptionsOpen_Click);
            this.btn_addonsOptionsOpen.MouseEnter += new System.EventHandler(this.btn_addonsOptionsOpen_MouseEnter);
            this.btn_addonsOptionsOpen.MouseLeave += new System.EventHandler(this.btn_addonsOptionsOpen_MouseLeave);
            // 
            // panel_packInfo
            // 
            this.panel_packInfo.BackColor = System.Drawing.Color.Transparent;
            this.panel_packInfo.Controls.Add(this.btn_addonsOptionsClose);
            this.panel_packInfo.Controls.Add(this.txt_title);
            this.panel_packInfo.Controls.Add(this.txt_content);
            this.panel_packInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_packInfo.Location = new System.Drawing.Point(0, 0);
            this.panel_packInfo.MaximumSize = new System.Drawing.Size(410, 0);
            this.panel_packInfo.Name = "panel_packInfo";
            this.panel_packInfo.Size = new System.Drawing.Size(10, 120);
            this.panel_packInfo.TabIndex = 0;
            // 
            // btn_addonsOptionsClose
            // 
            this.btn_addonsOptionsClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addonsOptionsClose.AutoSize = true;
            this.btn_addonsOptionsClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btn_addonsOptionsClose.Font = new System.Drawing.Font("Consolas", 8F);
            this.btn_addonsOptionsClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_addonsOptionsClose.Location = new System.Drawing.Point(-10, 42);
            this.btn_addonsOptionsClose.MaximumSize = new System.Drawing.Size(14, 37);
            this.btn_addonsOptionsClose.MinimumSize = new System.Drawing.Size(14, 37);
            this.btn_addonsOptionsClose.Name = "btn_addonsOptionsClose";
            this.btn_addonsOptionsClose.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btn_addonsOptionsClose.Size = new System.Drawing.Size(14, 37);
            this.btn_addonsOptionsClose.TabIndex = 12;
            this.btn_addonsOptionsClose.Text = ">";
            this.btn_addonsOptionsClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_addonsOptionsClose.Click += new System.EventHandler(this.btn_addonsOptionsClose_Click);
            this.btn_addonsOptionsClose.MouseEnter += new System.EventHandler(this.btn_addonsOptionsClose_MouseEnter);
            this.btn_addonsOptionsClose.MouseLeave += new System.EventHandler(this.btn_addonsOptionsClose_MouseLeave);
            // 
            // txt_title
            // 
            this.txt_title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txt_title.AutoSize = true;
            this.txt_title.BackColor = System.Drawing.Color.Transparent;
            this.txt_title.Font = new System.Drawing.Font("Lato", 10F, System.Drawing.FontStyle.Bold);
            this.txt_title.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_title.Location = new System.Drawing.Point(-193, 10);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(57, 17);
            this.txt_title.TabIndex = 0;
            this.txt_title.Text = "%Title%";
            this.txt_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_content
            // 
            this.txt_content.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_content.AutoSize = true;
            this.txt_content.BackColor = System.Drawing.Color.Transparent;
            this.txt_content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_content.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_content.Location = new System.Drawing.Point(-390, 31);
            this.txt_content.MaximumSize = new System.Drawing.Size(370, 80);
            this.txt_content.MinimumSize = new System.Drawing.Size(370, 80);
            this.txt_content.Name = "txt_content";
            this.txt_content.Size = new System.Drawing.Size(370, 80);
            this.txt_content.TabIndex = 11;
            this.txt_content.Text = "%Description%\r\n";
            // 
            // PackBlock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.panel_packImage);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "PackBlock";
            this.Size = new System.Drawing.Size(410, 200);
            this.panel_packImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_playTop)).EndInit();
            this.panel_moreInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_playBot)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.doubleBufferPanel1.ResumeLayout(false);
            this.panel_packInfo.ResumeLayout(false);
            this.panel_packInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txt_title;
        private arma3Launcher.Controls.DoubleBufferPanel panel_packImage;
        private System.Windows.Forms.Label txt_content;
        private System.Windows.Forms.ToolTip toolTip1;
        private arma3Launcher.Controls.DoubleBufferPanel panel_moreInfo;
        private arma3Launcher.Controls.DoubleBufferPanel panel_packInfo;
        private System.Windows.Forms.Label btn_addonsOptionsClose;
        private arma3Launcher.Controls.DoubleBufferPanel panel1;
        private System.Windows.Forms.Label btn_addonsOptionsOpen;
        private arma3Launcher.Controls.DoubleBufferFlowPanel flowpanel_packContent;
        private System.Windows.Forms.Label lbl_packcontent;
        private arma3Launcher.Controls.DoubleBufferPanel panel_effectFade;
        private DoubleBufferPanel doubleBufferPanel1;
        private MetroFramework.Controls.MetroScrollBar scroll_packContent;
        private System.Windows.Forms.PictureBox btn_playBot;
        private System.Windows.Forms.PictureBox btn_playTop;
    }
}
