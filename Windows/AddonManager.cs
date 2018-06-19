using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using arma3Launcher.Effects;
using arma3Launcher.Workers;

namespace arma3Launcher.Windows
{
    public partial class AddonManager : Form
    {
        private AddonsLooker aLooker;
        private WindowIO windowIO;
        private BuildRepo repoBuilder;

        private bool checkState = false;

        public AddonManager()
        {
            InitializeComponent();
            aLooker = new AddonsLooker(chbl_repoContent);
            windowIO = new WindowIO(this);
            repoBuilder = new BuildRepo(chbl_repoContent, lbl_buildStatus, prgb_repoBuild);

            if (Properties.Settings.Default.RepoFolder != "")
            { txtb_repoLocation.ForeColor = Color.FromArgb(64, 64, 64); txtb_repoLocation.Text = Properties.Settings.Default.RepoFolder; GetAddons(); }
            else
            { txtb_repoLocation.ForeColor = Color.DarkGray; txtb_repoLocation.Text = "Set directory ->"; }
        }

        private void AddonManager_Shown(object sender, EventArgs e)
        {
            windowIO.windowIn();
            lbl_buildStatus.Text = "Waiting for orders";
            prgb_repoBuild.Value = 0;
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

        private void btn_browseRepoLocation_Click(object sender, EventArgs e)
        {
            this.browseRepoFolder();
        }

        private void browseRepoFolder()
        {
            dlg_folderBrowser.Description = "Select repository folder.";
            if (Directory.Exists(txtb_repoLocation.Text))
                dlg_folderBrowser.SelectedPath = txtb_repoLocation.Text;

            if (dlg_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtb_repoLocation.ForeColor = Color.FromArgb(64, 64, 64);
                Properties.Settings.Default.RepoFolder = dlg_folderBrowser.SelectedPath + @"\";
                Properties.Settings.Default.Save();
                txtb_repoLocation.Text = dlg_folderBrowser.SelectedPath;
                GetAddons();
            }

            dlg_folderBrowser.SelectedPath = "";
        }

        private void GetAddons()
        {
            aLooker.getAddons(txtb_repoLocation.Text);
        }

        private void btn_ereaseRepoLocation_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.RepoFolder = "";
            Properties.Settings.Default.Save();

            txtb_repoLocation.ForeColor = Color.DarkGray; txtb_repoLocation.Text = "Set directory ->";
        }

        private void btn_openRepoLocation_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RepoFolder != "")
                Process.Start(Properties.Settings.Default.RepoFolder);
        }

        private void chb_checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!chb_checkAll.Checked) { this.checkState = false; chb_checkAll.Text = "Check All"; }
            else { this.checkState = true; chb_checkAll.Text = "Uncheck All"; }


            for (int i = 0; i < chbl_repoContent.Items.Count; i++)
            {
                chbl_repoContent.SetItemChecked(i, this.checkState);
            }
        }

        private void txtb_repoLocation_TextChanged(object sender, EventArgs e)
        {
            if (txtb_repoLocation.Text != "Set directory ->" && txtb_repoLocation.Text != "")
            {
                if (txtb_repoLocation.Text.EndsWith("\\"))
                    txtb_repoLocation.Text = txtb_repoLocation.Text.Remove(txtb_repoLocation.Text.Length - 1);
            }
            else
            {
                if (txtb_repoLocation.Text == "")
                {
                    Properties.Settings.Default.RepoFolder = "";
                    Properties.Settings.Default.Save();

                    txtb_repoLocation.ForeColor = Color.DarkGray; txtb_repoLocation.Text = "Set directory ->";
                }
            }
        }

        private void btn_buildRepo_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RepoFolder != "")
            {
                repoBuilder.Run(Properties.Settings.Default.RepoFolder);
            }
        }
    }
}
