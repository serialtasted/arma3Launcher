using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace arma3Launcher.Windows
{
    public partial class PackInfo : Form
    {
        private Timer effectIn = new Timer();
        private Timer effectOut = new Timer();

        public PackInfo(string Title, string Content)
        {
            InitializeComponent();
            txt_title.Text = Title;
            txt_content.Text = Content;

            setsize();

            effectIn.Interval = 10;
            effectOut.Interval = 10;

            effectIn.Tick += EffectIn_Tick;
            effectOut.Tick += EffectOut_Tick;
        }

        private void PackInfo_Shown(object sender, EventArgs e)
        {
            effectIn.Start();
        }

        private void EffectIn_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity = this.Opacity + 0.1;
                this.Location = new Point(this.Location.X, this.Location.Y - 1);
            }
            else
            { effectIn.Stop(); }
        }

        private void EffectOut_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity = this.Opacity - 0.1;
                this.Location = new Point(this.Location.X, this.Location.Y + 1);
            }
            else
            { effectOut.Stop(); this.Close(); }
        }

        private void setsize()
        {
            if (txt_content.Height > 57)
                this.Height = txt_content.Height + 80;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            effectOut.Start();
        }

        private void btn_close_MouseHover(object sender, EventArgs e)
        {
            btn_close.Image = Properties.Resources.arrow_down_hover;
        }

        private void btn_close_MouseLeave(object sender, EventArgs e)
        {
            btn_close.Image = Properties.Resources.arrow_down;
        }
    }
}
