using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace arma3Launcher.Controls
{
    public partial class PackBlock : UserControl
    {
        FlowLayoutPanel packsPan;
        Windows.PackInfo packInfo;

        public PackBlock(string packTitle, string packID, string packDescription, string packAddons, FlowLayoutPanel packsPanel, bool isBlastcoreAllowed, bool isJSRSAllowed, bool isOptionalAllowed)
        {
            InitializeComponent();

            packsPan = packsPanel;
            txt_title.Text = packTitle;
            txt_version.Text = packID;
            btn_useThis.Tag = packID;
            txt_content.Text = packDescription;
            packInfo = new Windows.PackInfo(packTitle, "Addons on this pack:\n" + packAddons);

            if (isBlastcoreAllowed)
                txt_allowed.Text = txt_allowed.Text + "Blastcore | ";
            if (isJSRSAllowed)
                txt_allowed.Text = txt_allowed.Text + "JSRS | ";
            if (isOptionalAllowed)
                txt_allowed.Text = txt_allowed.Text + "Optional Addons | ";

            if (txt_allowed.Text != "Allowed: ")
            { txt_allowed.Text = txt_allowed.Text.Remove(txt_allowed.Text.Length - 3); txt_allowed.Visible = true; img_checkAllowed.Visible = true; }


            setsize();
        }

        private void setsize()
        {
            if (txt_content.Height > 57)
                this.Height = txt_content.Height + 110;
        }

        private void btn_useThis_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.lastAddonPack = btn_useThis.Tag.ToString();
            Properties.Settings.Default.Save();

            try
            {
                int i = 0;
                foreach (Control c in packsPan.Controls)
                {
                    if (i < packsPan.Controls.Count)
                    {
                        PictureBox btnUsePack = c.Controls.Find("btn_useThis", true)[0] as PictureBox;
                        btnUsePack.Image = Properties.Resources.useThis_inactive;
                        btnUsePack.Enabled = true;
                    }
                    i++;
                }
            }
            catch { }

            btn_useThis.Image = Properties.Resources.useThis_active;
            btn_useThis.Enabled = false;
        }

        private void btn_useThis_MouseHover(object sender, EventArgs e)
        {
            if (btn_useThis.Enabled)
                btn_useThis.Image = Properties.Resources.useThis_hover;
        }

        private void btn_useThis_MouseLeave(object sender, EventArgs e)
        {
            if (btn_useThis.Enabled)
                btn_useThis.Image = Properties.Resources.useThis_inactive;
        }

        private void btn_showAddons_Click(object sender, EventArgs e)
        {
            packInfo.ShowDialog();
        }

        private void btn_showAddons_MouseHover(object sender, EventArgs e)
        {
            btn_showAddons.Image = Properties.Resources.archive_hover;
        }

        private void btn_showAddons_MouseLeave(object sender, EventArgs e)
        {
            btn_showAddons.Image = Properties.Resources.archive_w;
        }
    }
}
