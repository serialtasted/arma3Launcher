﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using arma3Launcher.Effects;
using arma3Launcher.Workers;
using MaterialSkin;
using MaterialSkin.Controls;

namespace arma3Launcher.Windows
{
    public partial class AddonManager : MaterialForm
    {
        private AddonsLooker aLooker;
        private WindowIO windowIO;
        private BuildRepo repoBuilder;

        private bool checkState = false;

        public AddonManager()
        {
            // Material Skin properties
            MaterialSkinManager.AddFormToManage(this);
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.Grey700, Primary.Grey800, Primary.Grey500, Accent.Lime200, TextShade.WHITE);

            InitializeComponent();

            aLooker = new AddonsLooker();
            windowIO = new WindowIO(this);
            repoBuilder = new BuildRepo(chbl_repoContent, lbl_buildStatus, prgb_repoBuild, buildLog, windowIO, btn_buildRepo, chb_checkAll);

            if (Properties.Settings.Default.RepoFolder != string.Empty)
            { txtb_repoLocation.ForeColor = Color.FromArgb(64, 64, 64); txtb_repoLocation.Text = Properties.Settings.Default.RepoFolder; GetAddons(); }
            else
            { txtb_repoLocation.ForeColor = Color.DarkGray; txtb_repoLocation.Text = "Set directory ->"; }
        }

        private void AddonManager_Shown(object sender, EventArgs e)
        {
            windowIO.WindowIn();
            lbl_buildStatus.Text = "Waiting for orders";
            prgb_repoBuild.Value = 0;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            repoBuilder.CancelBuild();
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

            dlg_folderBrowser.SelectedPath = string.Empty;
        }

        private void GetAddons()
        {
            aLooker.getAddonsCheckListBox(chbl_repoContent, txtb_repoLocation.Text);
        }

        private void btn_ereaseRepoLocation_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.RepoFolder = string.Empty;
            Properties.Settings.Default.Save();

            txtb_repoLocation.ForeColor = Color.DarkGray; txtb_repoLocation.Text = "Set directory ->";
        }

        private void btn_openRepoLocation_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RepoFolder != string.Empty)
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
            if (txtb_repoLocation.Text != "Set directory ->" && txtb_repoLocation.Text != string.Empty)
            {
                if (txtb_repoLocation.Text.EndsWith("\\"))
                    txtb_repoLocation.Text = txtb_repoLocation.Text.Remove(txtb_repoLocation.Text.Length - 1);
            }
            else
            {
                if (txtb_repoLocation.Text == string.Empty)
                {
                    Properties.Settings.Default.RepoFolder = string.Empty;
                    Properties.Settings.Default.Save();

                    txtb_repoLocation.ForeColor = Color.DarkGray; txtb_repoLocation.Text = "Set directory ->";
                }
            }
        }

        private void btn_buildRepo_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RepoFolder != string.Empty)
            {
                repoBuilder.Run(Properties.Settings.Default.RepoFolder);
            }
        }

        private void btn_ereaseRepoLocation_MouseEnter(object sender, EventArgs e)
        {
            btn_ereaseRepoLocation.Image = Properties.Resources.erase_hover;
        }

        private void btn_ereaseRepoLocation_MouseLeave(object sender, EventArgs e)
        {
            btn_ereaseRepoLocation.Image = Properties.Resources.erase_idle;
        }

        private void btn_browseRepoLocation_MouseEnter(object sender, EventArgs e)
        {
            btn_browseRepoLocation.Image = Properties.Resources.addfolder_hover;
        }

        private void btn_browseRepoLocation_MouseLeave(object sender, EventArgs e)
        {
            btn_browseRepoLocation.Image = Properties.Resources.addfolder_idle;
        }

        private void btn_openRepoLocation_MouseEnter(object sender, EventArgs e)
        {
            btn_openRepoLocation.Image = Properties.Resources.openfolder_hover;
        }

        private void btn_openRepoLocation_MouseLeave(object sender, EventArgs e)
        {
            btn_openRepoLocation.Image = Properties.Resources.openfolder_idle;
        }

        private void AddonManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((string)this.Tag != "close")
            {
                repoBuilder.CancelBuild();
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
