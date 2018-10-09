using arma3Launcher.Effects;
using arma3Launcher.Workers;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace arma3Launcher.Windows
{
    public partial class PrivatePackManager : MaterialForm
    {
        private WindowIO windowIO;

        public PrivatePackManager()
        {
            // Material Skin properties
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Grey700, Primary.Grey800, Primary.Grey500, Accent.Lime200, TextShade.WHITE);

            InitializeComponent();
            windowIO = new WindowIO(this);
        }

        private void btn_addKey_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.PrivateKeys = string.Format("{0}{1},", Properties.Settings.Default.PrivateKeys, txtb_privateKey.Text);
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
        }

        private void PrivatePackManager_Shown(object sender, EventArgs e)
        {
            this.windowIO.windowIn();
        }

        private void link_clearKeys_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Properties.Settings.Default.PrivateKeys = string.Empty;
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.windowIO.windowOut(true);
        }

        private void PrivatePackManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((string)this.Tag != "close")
            {
                windowIO.windowOut(true);
                e.Cancel = true;
            }
            else
            {
                GC.Collect(2, GCCollectionMode.Forced);
                this.Dispose();
            }
        }
    }
}
