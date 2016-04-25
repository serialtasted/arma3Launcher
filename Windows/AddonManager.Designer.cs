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
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.window_topBar = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_title = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.window_topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.window_topBar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(572, 391);
            this.panel3.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 38);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(570, 351);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // window_topBar
            // 
            this.window_topBar.BackColor = System.Drawing.Color.DimGray;
            this.window_topBar.Controls.Add(this.btn_close);
            this.window_topBar.Controls.Add(this.panel5);
            this.window_topBar.Controls.Add(this.txt_title);
            this.window_topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.window_topBar.Location = new System.Drawing.Point(0, 0);
            this.window_topBar.Name = "window_topBar";
            this.window_topBar.Size = new System.Drawing.Size(570, 38);
            this.window_topBar.TabIndex = 12;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.OliveDrab;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 34);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(570, 4);
            this.panel5.TabIndex = 11;
            // 
            // txt_title
            // 
            this.txt_title.AutoSize = true;
            this.txt_title.BackColor = System.Drawing.Color.Transparent;
            this.txt_title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_title.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_title.Location = new System.Drawing.Point(7, 10);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(95, 15);
            this.txt_title.TabIndex = 0;
            this.txt_title.Tag = "";
            this.txt_title.Text = "Addon Manager";
            this.txt_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_close.Image = global::arma3Launcher.Properties.Resources.arrow_down;
            this.btn_close.Location = new System.Drawing.Point(544, 11);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(16, 16);
            this.btn_close.TabIndex = 13;
            this.btn_close.TabStop = false;
            // 
            // AddonManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 391);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddonManager";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddonManager";
            this.panel3.ResumeLayout(false);
            this.window_topBar.ResumeLayout(false);
            this.window_topBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel window_topBar;
        private System.Windows.Forms.PictureBox btn_close;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label txt_title;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}