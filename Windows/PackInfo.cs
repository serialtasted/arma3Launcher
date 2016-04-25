using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using arma3Launcher.Effects;

namespace arma3Launcher.Windows
{
    public partial class PackInfo : Form
    {
        private WindowIO windowIO;

        public PackInfo(string Title, string Content)
        {
            InitializeComponent();
            txt_title.Text = Title;
            txt_content.Text = Content;
            windowIO = new WindowIO(this);
            setsize();
        }

        private void PackInfo_Shown(object sender, EventArgs e)
        {
            windowIO.windowIn();
        }

        private void setsize()
        {
            if (txt_content.Height > 57)
                this.Height = txt_content.Height + 80;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            windowIO.windowOut(true);
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
