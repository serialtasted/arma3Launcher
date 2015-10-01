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
            this.btn_showAddons = new System.Windows.Forms.PictureBox();
            this.img_checkAllowed = new System.Windows.Forms.PictureBox();
            this.btn_useThis = new System.Windows.Forms.PictureBox();
            this.panel_bgTitle = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_version = new System.Windows.Forms.Label();
            this.txt_content = new System.Windows.Forms.Label();
            this.txt_allowed = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_showAddons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_checkAllowed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_useThis)).BeginInit();
            this.panel_bgTitle.SuspendLayout();
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
            // btn_showAddons
            // 
            this.btn_showAddons.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_showAddons.Image = global::arma3Launcher.Properties.Resources.archive_w;
            this.btn_showAddons.Location = new System.Drawing.Point(724, 139);
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
            this.img_checkAllowed.Location = new System.Drawing.Point(11, 141);
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
            // panel_bgTitle
            // 
            this.panel_bgTitle.BackColor = System.Drawing.Color.DimGray;
            this.panel_bgTitle.Controls.Add(this.panel2);
            this.panel_bgTitle.Controls.Add(this.txt_title);
            this.panel_bgTitle.Controls.Add(this.txt_version);
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
            // txt_version
            // 
            this.txt_version.AutoSize = true;
            this.txt_version.BackColor = System.Drawing.Color.Transparent;
            this.txt_version.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_version.ForeColor = System.Drawing.Color.Gray;
            this.txt_version.Location = new System.Drawing.Point(703, 11);
            this.txt_version.MinimumSize = new System.Drawing.Size(150, 0);
            this.txt_version.Name = "txt_version";
            this.txt_version.Size = new System.Drawing.Size(150, 13);
            this.txt_version.TabIndex = 10;
            this.txt_version.Text = "%Version%";
            this.txt_version.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.txt_allowed.Location = new System.Drawing.Point(23, 141);
            this.txt_allowed.Name = "txt_allowed";
            this.txt_allowed.Size = new System.Drawing.Size(54, 13);
            this.txt_allowed.TabIndex = 15;
            this.txt_allowed.Text = "Allowed: ";
            this.txt_allowed.Visible = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.btn_showAddons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_checkAllowed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_useThis)).EndInit();
            this.panel_bgTitle.ResumeLayout(false);
            this.panel_bgTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txt_title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label txt_version;
        private System.Windows.Forms.Label txt_content;
        private System.Windows.Forms.Panel panel_bgTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox btn_useThis;
        private System.Windows.Forms.PictureBox img_checkAllowed;
        private System.Windows.Forms.Label txt_allowed;
        private System.Windows.Forms.PictureBox btn_showAddons;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
