namespace arma3Launcher.Controls
{
    partial class NewsBlock
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
            this.txt_title = new System.Windows.Forms.Label();
            this.lnk_readmore = new System.Windows.Forms.LinkLabel();
            this.txt_content = new System.Windows.Forms.Label();
            this.txt_note = new System.Windows.Forms.Label();
            this.panel_bgTitle = new System.Windows.Forms.Panel();
            this.pic_badge = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_badge)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_title
            // 
            this.txt_title.AutoSize = true;
            this.txt_title.BackColor = System.Drawing.Color.DimGray;
            this.txt_title.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_title.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_title.Location = new System.Drawing.Point(9, 5);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(63, 15);
            this.txt_title.TabIndex = 0;
            this.txt_title.Text = "%Title%";
            // 
            // lnk_readmore
            // 
            this.lnk_readmore.ActiveLinkColor = System.Drawing.SystemColors.ButtonShadow;
            this.lnk_readmore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnk_readmore.AutoSize = true;
            this.lnk_readmore.BackColor = System.Drawing.Color.Transparent;
            this.lnk_readmore.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnk_readmore.ForeColor = System.Drawing.Color.White;
            this.lnk_readmore.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnk_readmore.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lnk_readmore.Location = new System.Drawing.Point(651, 89);
            this.lnk_readmore.MinimumSize = new System.Drawing.Size(200, 0);
            this.lnk_readmore.Name = "lnk_readmore";
            this.lnk_readmore.Size = new System.Drawing.Size(200, 13);
            this.lnk_readmore.TabIndex = 2;
            this.lnk_readmore.TabStop = true;
            this.lnk_readmore.Text = "%Link%";
            this.lnk_readmore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnk_readmore.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lnk_readmore.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_readmore_LinkClicked);
            // 
            // txt_content
            // 
            this.txt_content.AutoSize = true;
            this.txt_content.BackColor = System.Drawing.Color.Transparent;
            this.txt_content.Font = new System.Drawing.Font("Meiryo", 8F);
            this.txt_content.Location = new System.Drawing.Point(16, 30);
            this.txt_content.MaximumSize = new System.Drawing.Size(800, 0);
            this.txt_content.MinimumSize = new System.Drawing.Size(800, 52);
            this.txt_content.Name = "txt_content";
            this.txt_content.Size = new System.Drawing.Size(800, 52);
            this.txt_content.TabIndex = 3;
            this.txt_content.Text = "%Content%\r\n";
            // 
            // txt_note
            // 
            this.txt_note.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_note.AutoSize = true;
            this.txt_note.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_note.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_note.Location = new System.Drawing.Point(9, 89);
            this.txt_note.MaximumSize = new System.Drawing.Size(545, 13);
            this.txt_note.MinimumSize = new System.Drawing.Size(545, 13);
            this.txt_note.Name = "txt_note";
            this.txt_note.Size = new System.Drawing.Size(545, 13);
            this.txt_note.TabIndex = 4;
            this.txt_note.Text = "%Note%";
            this.txt_note.Visible = false;
            // 
            // panel_bgTitle
            // 
            this.panel_bgTitle.BackColor = System.Drawing.Color.DimGray;
            this.panel_bgTitle.Location = new System.Drawing.Point(-1, -1);
            this.panel_bgTitle.Name = "panel_bgTitle";
            this.panel_bgTitle.Size = new System.Drawing.Size(862, 26);
            this.panel_bgTitle.TabIndex = 5;
            // 
            // pic_badge
            // 
            this.pic_badge.Location = new System.Drawing.Point(745, -1);
            this.pic_badge.Name = "pic_badge";
            this.pic_badge.Size = new System.Drawing.Size(116, 40);
            this.pic_badge.TabIndex = 6;
            this.pic_badge.TabStop = false;
            // 
            // NewsBlock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txt_content);
            this.Controls.Add(this.pic_badge);
            this.Controls.Add(this.lnk_readmore);
            this.Controls.Add(this.txt_title);
            this.Controls.Add(this.txt_note);
            this.Controls.Add(this.panel_bgTitle);
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(860, 109);
            this.Name = "NewsBlock";
            this.Size = new System.Drawing.Size(860, 109);
            ((System.ComponentModel.ISupportInitialize)(this.pic_badge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_title;
        private System.Windows.Forms.LinkLabel lnk_readmore;
        private System.Windows.Forms.Label txt_content;
        private System.Windows.Forms.Label txt_note;
        private System.Windows.Forms.Panel panel_bgTitle;
        private System.Windows.Forms.PictureBox pic_badge;
    }
}
