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
            this.panel4 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.txt_title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtb_privateKey = new System.Windows.Forms.TextBox();
            this.btn_addKey = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel3 = new arma3Launcher.Controls.DoubleBufferPanel();
            this.link_clearKeys = new System.Windows.Forms.LinkLabel();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.btn_close);
            this.panel4.Controls.Add(this.txt_title);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(347, 38);
            this.panel4.TabIndex = 14;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Image = global::arma3Launcher.Properties.Resources.arrow_down;
            this.btn_close.Location = new System.Drawing.Point(321, 11);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(16, 16);
            this.btn_close.TabIndex = 13;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // txt_title
            // 
            this.txt_title.AutoSize = true;
            this.txt_title.BackColor = System.Drawing.Color.Transparent;
            this.txt_title.Font = new System.Drawing.Font("Lato", 9F, System.Drawing.FontStyle.Bold);
            this.txt_title.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_title.Location = new System.Drawing.Point(7, 12);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(96, 15);
            this.txt_title.TabIndex = 0;
            this.txt_title.Text = "Add Private Pack";
            this.txt_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Pack Key:";
            // 
            // txtb_privateKey
            // 
            this.txtb_privateKey.Location = new System.Drawing.Point(70, 48);
            this.txtb_privateKey.Name = "txtb_privateKey";
            this.txtb_privateKey.Size = new System.Drawing.Size(267, 20);
            this.txtb_privateKey.TabIndex = 16;
            // 
            // btn_addKey
            // 
            this.btn_addKey.AutoSize = true;
            this.btn_addKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_addKey.Depth = 0;
            this.btn_addKey.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_addKey.Location = new System.Drawing.Point(260, 74);
            this.btn_addKey.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
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
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_addKey);
            this.panel3.Controls.Add(this.link_clearKeys);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(347, 105);
            this.panel3.TabIndex = 18;
            // 
            // link_clearKeys
            // 
            this.link_clearKeys.ActiveLinkColor = System.Drawing.Color.YellowGreen;
            this.link_clearKeys.AutoSize = true;
            this.link_clearKeys.LinkColor = System.Drawing.Color.Silver;
            this.link_clearKeys.Location = new System.Drawing.Point(8, 78);
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
            this.ClientSize = new System.Drawing.Size(347, 105);
            this.Controls.Add(this.txtb_privateKey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PrivatePackManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PrivatePackManager";
            this.Shown += new System.EventHandler(this.PrivatePackManager_Shown);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private arma3Launcher.Controls.DoubleBufferPanel panel4;
        private System.Windows.Forms.PictureBox btn_close;
        private System.Windows.Forms.Label txt_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtb_privateKey;
        private MaterialSkin.Controls.MaterialFlatButton btn_addKey;
        private arma3Launcher.Controls.DoubleBufferPanel panel3;
        private System.Windows.Forms.LinkLabel link_clearKeys;
    }
}