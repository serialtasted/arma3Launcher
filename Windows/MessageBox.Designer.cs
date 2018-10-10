namespace arma3Launcher.Windows
{
    partial class MessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBox));
            this.diagImg = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.option_3 = new MaterialSkin.Controls.MaterialFlatButton();
            this.option_2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.option_1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Message = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.diagImg)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // diagImg
            // 
            this.diagImg.Location = new System.Drawing.Point(8, -6);
            this.diagImg.Name = "diagImg";
            this.diagImg.Size = new System.Drawing.Size(128, 128);
            this.diagImg.TabIndex = 1;
            this.diagImg.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(48)))));
            this.panel1.Controls.Add(this.option_3);
            this.panel1.Controls.Add(this.option_2);
            this.panel1.Controls.Add(this.option_1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panel1.Location = new System.Drawing.Point(0, 180);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.panel1.Size = new System.Drawing.Size(450, 50);
            this.panel1.TabIndex = 2;
            // 
            // option_3
            // 
            this.option_3.AutoSize = true;
            this.option_3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.option_3.Depth = 0;
            this.option_3.Location = new System.Drawing.Point(348, 6);
            this.option_3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.option_3.MouseState = MaterialSkin.MouseState.HOVER;
            this.option_3.Name = "option_3";
            this.option_3.Primary = false;
            this.option_3.Size = new System.Drawing.Size(93, 36);
            this.option_3.TabIndex = 2;
            this.option_3.Text = "%option 3%";
            this.option_3.UseVisualStyleBackColor = true;
            this.option_3.Visible = false;
            // 
            // option_2
            // 
            this.option_2.AutoSize = true;
            this.option_2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.option_2.Depth = 0;
            this.option_2.Location = new System.Drawing.Point(247, 6);
            this.option_2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.option_2.MouseState = MaterialSkin.MouseState.HOVER;
            this.option_2.Name = "option_2";
            this.option_2.Primary = false;
            this.option_2.Size = new System.Drawing.Size(93, 36);
            this.option_2.TabIndex = 1;
            this.option_2.Text = "%option 2%";
            this.option_2.UseVisualStyleBackColor = true;
            this.option_2.Visible = false;
            // 
            // option_1
            // 
            this.option_1.AutoSize = true;
            this.option_1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.option_1.Depth = 0;
            this.option_1.Location = new System.Drawing.Point(146, 6);
            this.option_1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.option_1.MouseState = MaterialSkin.MouseState.HOVER;
            this.option_1.Name = "option_1";
            this.option_1.Primary = false;
            this.option_1.Size = new System.Drawing.Size(93, 36);
            this.option_1.TabIndex = 0;
            this.option_1.Text = "%option 1%";
            this.option_1.UseVisualStyleBackColor = true;
            this.option_1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.panel2.Controls.Add(this.Message);
            this.panel2.Controls.Add(this.diagImg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 116);
            this.panel2.TabIndex = 3;
            // 
            // Message
            // 
            this.Message.AutoSize = true;
            this.Message.Font = new System.Drawing.Font("Clear Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Message.Location = new System.Drawing.Point(142, 8);
            this.Message.MaximumSize = new System.Drawing.Size(300, 100);
            this.Message.MinimumSize = new System.Drawing.Size(300, 100);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(300, 100);
            this.Message.TabIndex = 2;
            this.Message.Text = "%Message Content%";
            this.Message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 230);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MessageBox";
            this.Padding = new System.Windows.Forms.Padding(0, 64, 0, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "%Title%";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessageBox_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.diagImg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox diagImg;
        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.Panel panel2;
        private MaterialSkin.Controls.MaterialFlatButton option_1;
        private MaterialSkin.Controls.MaterialFlatButton option_2;
        private MaterialSkin.Controls.MaterialFlatButton option_3;
        private System.Windows.Forms.Label Message;
    }
}