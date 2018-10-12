namespace arma3Launcher.Windows
{
    partial class DelayServerStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelayServerStart));
            this.lbl_text = new MaterialSkin.Controls.MaterialLabel();
            this.btn_cancel = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // lbl_text
            // 
            this.lbl_text.AutoSize = true;
            this.lbl_text.BackColor = System.Drawing.Color.Transparent;
            this.lbl_text.Depth = 0;
            this.lbl_text.Font = new System.Drawing.Font("Roboto", 11F);
            this.lbl_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_text.Location = new System.Drawing.Point(17, 33);
            this.lbl_text.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(243, 19);
            this.lbl_text.TabIndex = 2;
            this.lbl_text.Text = "Engaging autopilot in 10 seconds...";
            // 
            // btn_cancel
            // 
            this.btn_cancel.AutoSize = true;
            this.btn_cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_cancel.BackColor = System.Drawing.Color.DarkRed;
            this.btn_cancel.Depth = 0;
            this.btn_cancel.Location = new System.Drawing.Point(279, 32);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_cancel.MaximumSize = new System.Drawing.Size(75, 23);
            this.btn_cancel.MinimumSize = new System.Drawing.Size(75, 23);
            this.btn_cancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Primary = false;
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // DelayServerStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(106)))), ((int)(((byte)(103)))));
            this.ClientSize = new System.Drawing.Size(370, 64);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_text);
            this.Controls.Add(this.btn_cancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DelayServerStart";
            this.Padding = new System.Windows.Forms.Padding(0, 64, 0, 0);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DelayServerStart_FormClosing);
            this.Shown += new System.EventHandler(this.DelayServerStart_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel lbl_text;
        private MaterialSkin.Controls.MaterialFlatButton btn_cancel;
    }
}