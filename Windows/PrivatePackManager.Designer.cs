namespace arma3Launcher.Windows
{
    partial class PrivatePackManager
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
            this.txtb_privateKey = new System.Windows.Forms.TextBox();
            this.btn_addKey = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel3 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.link_clearKeys = new System.Windows.Forms.LinkLabel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtb_privateKey
            // 
            this.txtb_privateKey.Location = new System.Drawing.Point(152, 33);
            this.txtb_privateKey.Name = "txtb_privateKey";
            this.txtb_privateKey.PasswordChar = '\0';
            this.txtb_privateKey.SelectedText = "";
            this.txtb_privateKey.SelectionLength = 0;
            this.txtb_privateKey.SelectionStart = 0;
            this.txtb_privateKey.Size = new System.Drawing.Size(178, 23);
            this.txtb_privateKey.TabIndex = 16;
            this.txtb_privateKey.UseSystemPasswordChar = false;
            // 
            // btn_addKey
            // 
            this.btn_addKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_addKey.AutoSize = true;
            this.btn_addKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_addKey.Depth = 0;
            this.btn_addKey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_addKey.Location = new System.Drawing.Point(259, 5);
            this.btn_addKey.Margin = new System.Windows.Forms.Padding(0);
            this.btn_addKey.MaximumSize = new System.Drawing.Size(75, 23);
            this.btn_addKey.MinimumSize = new System.Drawing.Size(75, 23);
            this.btn_addKey.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_addKey.Name = "btn_addKey";
            this.btn_addKey.Primary = false;
            this.btn_addKey.Size = new System.Drawing.Size(75, 23);
            this.btn_addKey.TabIndex = 17;
            this.btn_addKey.Text = "Add";
            this.btn_addKey.UseVisualStyleBackColor = true;
            this.btn_addKey.Click += new System.EventHandler(this.btn_addKey_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.panel3.Controls.Add(this.btn_addKey);
            this.panel3.Controls.Add(this.link_clearKeys);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(347, 32);
            this.panel3.TabIndex = 18;
            // 
            // link_clearKeys
            // 
            this.link_clearKeys.ActiveLinkColor = System.Drawing.Color.YellowGreen;
            this.link_clearKeys.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.link_clearKeys.AutoSize = true;
            this.link_clearKeys.LinkColor = System.Drawing.Color.Silver;
            this.link_clearKeys.Location = new System.Drawing.Point(13, 10);
            this.link_clearKeys.Name = "link_clearKeys";
            this.link_clearKeys.Size = new System.Drawing.Size(101, 13);
            this.link_clearKeys.TabIndex = 0;
            this.link_clearKeys.TabStop = true;
            this.link_clearKeys.Text = "Clear all saved keys";
            this.link_clearKeys.VisitedLinkColor = System.Drawing.Color.Silver;
            this.link_clearKeys.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_clearKeys_LinkClicked);
            // 
            // PrivatePackManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(347, 96);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtb_privateKey);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrivatePackManager";
            this.Padding = new System.Windows.Forms.Padding(0, 64, 0, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Private Pack";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrivatePackManager_FormClosing);
            this.Shown += new System.EventHandler(this.PrivatePackManager_Shown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtb_privateKey;
        private MaterialSkin.Controls.MaterialFlatButton btn_addKey;
        private arma3Launcher.Controls.DoubleBufferPanel panel3;
        private System.Windows.Forms.LinkLabel link_clearKeys;
    }
}