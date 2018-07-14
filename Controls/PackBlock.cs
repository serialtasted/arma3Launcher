using System;
using System.Windows.Forms;
using arma3Launcher.Effects;
using arma3Launcher.Workers;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using arma3Launcher.Windows;
using System.Threading.Tasks;
using System.Drawing;

namespace arma3Launcher.Controls
{
    public partial class PackBlock : UserControl
    {
        private FlowLayoutPanel packsPan;
        private PackInfo packInfo;
        private MainForm mainForm;
        private View viewList;

        private Version aLocal = null;
        private Version aRemote = null;

        private List<string> modsUrl = new List<string>();

        public PackBlock(MainForm mainForm, string packTitle, string packID, string packDescription, string packAddons, FlowLayoutPanel packsPanel, bool isOptionalAllowed, View viewList)
        {
            InitializeComponent();

            this.packsPan = packsPanel;
            this.txt_title.Text = packTitle;
            this.txt_packID.Text = packID;
            this.btn_useThis.Tag = packID;
            this.txt_content.Text = packDescription;
            this.packInfo = new PackInfo(packTitle, "Addons on this pack:\n" + packAddons);
            this.mainForm = mainForm;
            this.viewList = viewList;

            switch (viewList)
            {
                case View.LargeIcon:
                    break;
                case View.Details:
                    this.Width = 860;
                    this.Height = 174;
                    break;
                case View.SmallIcon:
                    break;
                case View.List:
                    this.Width = 860;
                    this.Height = 88;
                    break;
                case View.Tile:
                    this.Width = 426;
                    this.Height = 88;
                    break;
            }

            if (packID == "arma3")
                btn_showAddons.Visible = false;

            loadbackground(packID);

            if (isOptionalAllowed)
                txt_allowed.Text = txt_allowed.Text + "Steam Workshop Addons | ";

            if (txt_allowed.Text != "Allowed: ")
            { txt_allowed.Text = txt_allowed.Text.Remove(txt_allowed.Text.Length - 3); txt_allowed.Visible = true; img_checkAllowed.Visible = true; }
        }

        private async void loadbackground(string packID)
        {
            if (viewList != View.Details) { return; }

            try
            {
                PictureBox panelBG = new PictureBox();
                panelBG.Load(Properties.GlobalValues.S_PackImgsDir + packID + ".png");
                panel1.BackgroundImage = panelBG.Image;
                txt_content.MinimumSize = new Size(600, 52);
                txt_content.MaximumSize = new Size(600, 52);
            }
            catch { }
        }

        private void setsize()
        {
            if (txt_content.Height > 57)
                this.Height = txt_content.Height + 110;
        }

        private void btn_useThis_Click(object sender, EventArgs e)
        {
            mainForm.updateActivePack(txt_title.Text);

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
            mainForm.updateCurrentPack(false);
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
