namespace arma3Launcher.Windows
{
    partial class LegacyTransporter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegacyTransporter));
            this.txt_label = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.txt_progressStatus = new System.Windows.Forms.RichTextBox();
            this.btn_close = new System.Windows.Forms.Button();
            this.loader = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_label
            // 
            this.txt_label.AutoSize = true;
            this.txt_label.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_label.Location = new System.Drawing.Point(12, 16);
            this.txt_label.Name = "txt_label";
            this.txt_label.Size = new System.Drawing.Size(293, 13);
            this.txt_label.TabIndex = 0;
            this.txt_label.Text = "Please wait while the launcher gets your system ready... -";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // txt_progressStatus
            // 
            this.txt_progressStatus.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_progressStatus.Location = new System.Drawing.Point(12, 43);
            this.txt_progressStatus.Name = "txt_progressStatus";
            this.txt_progressStatus.ReadOnly = true;
            this.txt_progressStatus.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txt_progressStatus.Size = new System.Drawing.Size(497, 265);
            this.txt_progressStatus.TabIndex = 1;
            this.txt_progressStatus.Text = "";
            this.txt_progressStatus.TextChanged += new System.EventHandler(this.txt_progressStatus_TextChanged);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(6, 21);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Visible = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // loader
            // 
            this.loader.Tick += new System.EventHandler(this.loader_Tick);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::arma3Launcher.Properties.Resources.transfer;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Location = new System.Drawing.Point(428, -10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 71);
            this.panel1.TabIndex = 3;
            // 
            // LegacyTransporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 320);
            this.ControlBox = false;
            this.Controls.Add(this.txt_progressStatus);
            this.Controls.Add(this.txt_label);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LegacyTransporter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "spN Launcher - Legacy Transporter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LegacyTransporter_FormClosing);
            this.Load += new System.EventHandler(this.LegacyTransporter_Load);
            this.Shown += new System.EventHandler(this.LegacyTransporter_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txt_label;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.RichTextBox txt_progressStatus;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Timer loader;
        private System.Windows.Forms.Panel panel1;
    }
}