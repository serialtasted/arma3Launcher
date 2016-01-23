using System;
using System.Windows.Forms;
using arma3Launcher.Effects;
using arma3Launcher.Workers;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using arma3Launcher.Windows;
using System.Threading.Tasks;

namespace arma3Launcher.Controls
{
    public partial class PackBlock : UserControl
    {
        private FlowLayoutPanel packsPan;
        private PackInfo packInfo;
        private PanelIO panelIO;
        private Installer installer;
        private Downloader downloader;
        private RemoteReader remoteReader;
        private String addonPack;
        private MainForm mainForm;

        private Version aLocal = null;
        private Version aRemote = null;

        private List<string> modsUrl = new List<string>();

        public PackBlock(MainForm mainForm, string packTitle, string packID, string packDescription, string packAddons, FlowLayoutPanel packsPanel, bool isBlastcoreAllowed, bool isJSRSAllowed, bool isOptionalAllowed)
        {
            InitializeComponent();

            this.packsPan = packsPanel;
            this.txt_title.Text = packTitle;
            this.txt_packID.Text = packID;
            this.addonPack = packID;
            this.btn_useThis.Tag = packID;
            this.txt_content.Text = packDescription;
            this.packInfo = new Windows.PackInfo(packTitle, "Addons on this pack:\n" + packAddons);
            this.remoteReader = new RemoteReader();
            this.mainForm = mainForm;

            if (packID == "arma3")
                btn_showAddons.Visible = false;

            loadbackground(packID);

            if (isBlastcoreAllowed)
                txt_allowed.Text = txt_allowed.Text + "Blastcore | ";
            if (isJSRSAllowed)
                txt_allowed.Text = txt_allowed.Text + "JSRS | ";
            if (isOptionalAllowed)
                txt_allowed.Text = txt_allowed.Text + "Optional Addons | ";

            if (txt_allowed.Text != "Allowed: ")
            { txt_allowed.Text = txt_allowed.Text.Remove(txt_allowed.Text.Length - 3); txt_allowed.Visible = true; img_checkAllowed.Visible = true; }

            panelIO = new PanelIO(panel_download_inner, panel_download_outter, 7);
            installer = new Installer(this, prb_progressBar_File, prb_progressBar_All, txt_progressStatus, txt_percentageStatus, txt_curFile, btn_downloadpack, Properties.Settings.Default.Arma3Folder, Properties.Settings.Default.TS3Folder, Properties.Settings.Default.AddonsFolder);
            downloader = new Downloader(this, installer, prb_progressBar_File, prb_progressBar_All, txt_curFile, txt_progressStatus, txt_percentageStatus, btn_downloadpack);

            //setsize();
        }

        private async void loadbackground(string packID)
        {
            try
            {
                PictureBox panelBG = new PictureBox();
                panelBG.Load("https://dl.dropboxusercontent.com/u/3609589/arma3Launcher/PackImgs/" + packID + ".png");
                panel1.BackgroundImage = panelBG.Image;
                txt_content.MinimumSize = new System.Drawing.Size(600, 52);
                txt_content.MaximumSize = new System.Drawing.Size(600, 52);
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

        public void FetchRemoteSettings()
        {
            bool isInstalled = false;
            modsUrl.Clear();

            string AddonsFolder = Properties.Settings.Default.AddonsFolder;

            try
            {
                XmlDocument RemoteXmlInfo = new XmlDocument();
                RemoteXmlInfo.Load(Properties.GlobalValues.S_VersionXML);

                string xmlNodes = "";
                XmlNodeList xnl;

                string cfgFile = addonPack;
                string cfgUrl = remoteReader.GetPackConfigFile(addonPack);

                xmlNodes = "//arma3Launcher//ModSetInfo//" + addonPack + "//mod";
                xnl = RemoteXmlInfo.SelectNodes(xmlNodes);

                foreach (XmlNode xn in xnl)
                {
                    if (xn.Attributes["type"].Value == "mod")
                    {
                        if (AddonsFolder != "")
                        {
                            foreach (string d in Directory.GetDirectories(AddonsFolder))
                            {
                                string[] aux_d = d.Split('\\');

                                if (aux_d[aux_d.Length - 1].Equals(xn.Attributes["name"].Value))
                                {
                                    try
                                    {
                                        if (d.Contains("dummy")) { isInstalled = true; break; }

                                        foreach (var line in File.ReadAllLines(d + @"\spNversionController"))
                                        {
                                            if (line.Contains("version"))
                                            {
                                                string aux_line = line.Replace(" ", "");
                                                string[] splitted_line = aux_line.Split('=');

                                                aLocal = new Version(splitted_line[1]);
                                                aRemote = new Version(xn.Attributes["version"].Value);
                                                break;
                                            }
                                        }

                                        if (aRemote != aLocal)
                                        {
                                            if (!d.Contains("RHS"))
                                                Directory.Delete(d, true);

                                            isInstalled = false;
                                            break;
                                        }
                                        else { isInstalled = true; break; }
                                    }
                                    catch (Exception ex)
                                    {
                                        //MessageBox.Show(ex.Message);
                                    }
                                }
                                else { isInstalled = false; continue; }
                            }
                        }

                        if (!isInstalled && Properties.Settings.Default.downloadQueue == "")
                            modsUrl.Add(xn.Attributes["url"].Value);
                    }
                }

                if (modsUrl.Count > 0)
                    modsUrl.Insert(0, cfgUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to fetch remote settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_progressStatus.Text = "Unable to fetch remote settings.";
            }
        }

        private void btn_showAddons_Click(object sender, EventArgs e)
        {
            packInfo.ShowDialog();
        }

        private void btn_downloadpack_Click(object sender, EventArgs e)
        {
            FetchRemoteSettings();
            if (modsUrl.Count > 0)
            {
                if (!GlobalVar.isDownloading && !GlobalVar.isInstalling)
                {
                    downloader.beginDownload(modsUrl, false, addonPack, addonPack);
                    panelIO.showPanel();
                }
                else
                    MessageBox.Show("There's a download already in progress. Please wait for it to finish.", "Download already in progress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("You already have everything you need to play this pack.", "All files needed already in system", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_showAddons_MouseHover(object sender, EventArgs e)
        {
            btn_showAddons.Image = Properties.Resources.archive_hover;
        }

        private void btn_showAddons_MouseLeave(object sender, EventArgs e)
        {
            btn_showAddons.Image = Properties.Resources.archive_w;
        }

        private void btn_downloadpack_MouseHover(object sender, EventArgs e)
        {
            btn_downloadpack.Image = Properties.Resources.cloud_download_hover;
        }

        private void btn_downloadpack_MouseLeave(object sender, EventArgs e)
        {
            btn_downloadpack.Image = Properties.Resources.cloud_download;
        }

        public void hidePanel()
        { panelIO.hidePanel(); }

        private void btn_cancelDownload_Click_1(object sender, EventArgs e)
        {
            if (GlobalVar.isDownloading) { downloader.cancelDownload(); this.hidePanel(); };
            if (GlobalVar.isInstalling) { MessageBox.Show("One does not simply cancel the installation process.", "You can't stop me now!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); };
        }

        private void btn_cancelDownload_MouseHover(object sender, EventArgs e)
        {
            btn_cancelDownload.Image = Properties.Resources.cloud_off_hover;
        }

        private void btn_cancelDownload_MouseLeave(object sender, EventArgs e)
        {
            btn_cancelDownload.Image = Properties.Resources.cloud_off;
        }
    }
}
