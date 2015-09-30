namespace arma3Launcher.Windows
{
    partial class AddonsFolderSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddonsFolderSetup));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_done = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_windowTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ereaseModsDirectory = new System.Windows.Forms.Button();
            this.btn_browseModsDirectory = new System.Windows.Forms.PictureBox();
            this.txtb_modsDirectory = new System.Windows.Forms.TextBox();
            this.dlg_folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_browseModsDirectory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.btn_done);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 185);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 42);
            this.panel1.TabIndex = 0;
            // 
            // btn_done
            // 
            this.btn_done.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_done.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_done.Enabled = false;
            this.btn_done.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_done.Location = new System.Drawing.Point(443, 7);
            this.btn_done.Name = "btn_done";
            this.btn_done.Size = new System.Drawing.Size(75, 23);
            this.btn_done.TabIndex = 0;
            this.btn_done.Text = "Done";
            this.btn_done.UseVisualStyleBackColor = true;
            this.btn_done.Click += new System.EventHandler(this.btn_done_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Warning! Please read the following:";
            // 
            // txt_windowTitle
            // 
            this.txt_windowTitle.AutoSize = true;
            this.txt_windowTitle.BackColor = System.Drawing.Color.Transparent;
            this.txt_windowTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.txt_windowTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_windowTitle.Location = new System.Drawing.Point(6, 6);
            this.txt_windowTitle.Name = "txt_windowTitle";
            this.txt_windowTitle.Size = new System.Drawing.Size(91, 13);
            this.txt_windowTitle.TabIndex = 16;
            this.txt_windowTitle.Text = "%windowTitle%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 74);
            this.label2.MaximumSize = new System.Drawing.Size(500, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 52);
            this.label2.TabIndex = 17;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // btn_ereaseModsDirectory
            // 
            this.btn_ereaseModsDirectory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ereaseModsDirectory.FlatAppearance.BorderSize = 0;
            this.btn_ereaseModsDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ereaseModsDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ereaseModsDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ereaseModsDirectory.ForeColor = System.Drawing.Color.DarkGray;
            this.btn_ereaseModsDirectory.Image = global::arma3Launcher.Properties.Resources.circle_with_cross;
            this.btn_ereaseModsDirectory.Location = new System.Drawing.Point(457, 145);
            this.btn_ereaseModsDirectory.Name = "btn_ereaseModsDirectory";
            this.btn_ereaseModsDirectory.Size = new System.Drawing.Size(20, 20);
            this.btn_ereaseModsDirectory.TabIndex = 19;
            this.btn_ereaseModsDirectory.TabStop = false;
            this.btn_ereaseModsDirectory.UseVisualStyleBackColor = false;
            this.btn_ereaseModsDirectory.Click += new System.EventHandler(this.btn_ereaseModsDirectory_Click);
            // 
            // btn_browseModsDirectory
            // 
            this.btn_browseModsDirectory.BackColor = System.Drawing.Color.Transparent;
            this.btn_browseModsDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_browseModsDirectory.Image = global::arma3Launcher.Properties.Resources.browse;
            this.btn_browseModsDirectory.Location = new System.Drawing.Point(485, 148);
            this.btn_browseModsDirectory.Name = "btn_browseModsDirectory";
            this.btn_browseModsDirectory.Size = new System.Drawing.Size(16, 16);
            this.btn_browseModsDirectory.TabIndex = 20;
            this.btn_browseModsDirectory.TabStop = false;
            this.btn_browseModsDirectory.Click += new System.EventHandler(this.btn_browseModsDirectory_Click);
            // 
            // txtb_modsDirectory
            // 
            this.txtb_modsDirectory.Location = new System.Drawing.Point(30, 144);
            this.txtb_modsDirectory.Name = "txtb_modsDirectory";
            this.txtb_modsDirectory.Size = new System.Drawing.Size(449, 22);
            this.txtb_modsDirectory.TabIndex = 18;
            // 
            // dlg_folderBrowser
            // 
            this.dlg_folderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.dlg_folderBrowser.ShowNewFolderButton = false;
            // 
            // AddonsFolderSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::arma3Launcher.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(530, 227);
            this.Controls.Add(this.btn_ereaseModsDirectory);
            this.Controls.Add(this.btn_browseModsDirectory);
            this.Controls.Add(this.txtb_modsDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_windowTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(530, 227);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(530, 227);
            this.Name = "AddonsFolderSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LauncherSetup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddonsFolderSetup_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_browseModsDirectory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_done;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt_windowTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ereaseModsDirectory;
        private System.Windows.Forms.PictureBox btn_browseModsDirectory;
        private System.Windows.Forms.TextBox txtb_modsDirectory;
        private System.Windows.Forms.FolderBrowserDialog dlg_folderBrowser;
    }
}