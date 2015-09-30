using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arma3Launcher.Windows
{
    public partial class AddonsFolderSetup : Form
    {
        private string GameFolder = "";
        public string AddonsFolder { get; set; }

        public AddonsFolderSetup()
        {
            InitializeComponent();

            GameFolder = Properties.Settings.Default.Arma3Folder;
            txt_windowTitle.Text = AssemblyTitle + " - Addons Folder";
        }

        #region Assembly Info
        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                string aux = "";
                if (Assembly.GetExecutingAssembly().GetName().Version.Build != 0)
                    aux = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Build.ToString() /*+ "." + Assembly.GetExecutingAssembly().GetName().Version.Revision.ToString()*/;
                else
                    aux = Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
                return aux;
            }
        }
        #endregion

        private void btn_ereaseModsDirectory_Click(object sender, EventArgs e)
        {
            txtb_modsDirectory.Text = "";
            btn_done.Enabled = false;
        }

        private void btn_browseModsDirectory_Click(object sender, EventArgs e)
        {
            dlg_folderBrowser.ShowNewFolderButton = true;

            if (dlg_folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (dlg_folderBrowser.SelectedPath != GameFolder)
                {
                    AddonsFolder = dlg_folderBrowser.SelectedPath + @"\";
                    txtb_modsDirectory.Text = dlg_folderBrowser.SelectedPath;

                    btn_done.Enabled = true;
                }
                else
                    MessageBox.Show("The Addons folder can't be the same as the Game folder.\nWe recommend you to have a specific folder for the addons on this launcher to avoid conflicts.", "Wrong directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dlg_folderBrowser.ShowNewFolderButton = false;
        }

        private void btn_done_Click(object sender, EventArgs e)
        {
            if(AddonsFolder != "")
                this.Close();
        }

        private void AddonsFolderSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AddonsFolder == "")
                e.Cancel = true;
        }
    }
}
