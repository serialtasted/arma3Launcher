using arma3Launcher.Effects;
using arma3Launcher.Workers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace arma3Launcher.Windows
{
    public partial class PrivatePackManager : Form
    {
        private WindowIO windowIO;
        private Fonts customFont = new Fonts();

        public PrivatePackManager()
        {
            InitializeComponent();
            windowIO = new WindowIO(this);

            txt_title.Font = customFont.getFont(Properties.Fonts.Lato_Semibold, 9F, FontStyle.Regular);
        }

        private void btn_addKey_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.privateKeys = string.Format("{0}{1},", Properties.Settings.Default.privateKeys, txtb_privateKey.Text);
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.windowIO.windowOut(true);
        }

        private void PrivatePackManager_Shown(object sender, EventArgs e)
        {
            this.windowIO.windowIn();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.windowIO.windowOut(true);
        }

        private void link_clearKeys_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Properties.Settings.Default.privateKeys = string.Empty;
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.windowIO.windowOut(true);
        }
    }
}
