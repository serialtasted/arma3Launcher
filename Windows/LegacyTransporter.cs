using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace arma3Launcher.Windows
{
    public partial class LegacyTransporter : Form
    {
        private List<string> modsName = new List<string>();
        private string Path_TempDownload = Path.GetTempPath() + @"spNLauncher\";

        bool running = false;

        Workers.EmailReporter eReport;
        bool errorOccured = false;

        string AddonsFolder = "";
        string cModsFolder = "";

        private string filename = "legacyVersionController.zip";
        WebClient client_update = new WebClient();
        Uri download_url;

        public LegacyTransporter()
        {
            InitializeComponent();

            eReport = new Workers.EmailReporter();

            AddonsFolder = Properties.Settings.Default.AddonsFolder;
            cModsFolder = Properties.Settings.Default.cModsFolder_value;

            if (cModsFolder == "")
                cModsFolder = Properties.Settings.Default.Arma3Folder;

            if (!AddonsFolder.EndsWith(@"\"))
                AddonsFolder += @"\";

            if (!cModsFolder.EndsWith(@"\"))
                cModsFolder += @"\";
        }

        void FetchRemoteSettings()
        {
            modsName.Clear();

            try
            {
                XmlDocument RemoteXmlInfo = new XmlDocument();
                RemoteXmlInfo.Load(Properties.GlobalValues.S_VersionXML);

                XmlNodeList xnl = RemoteXmlInfo.SelectNodes("//spN_Launcher//ModSetInfo//Mods//mod");
                foreach (XmlNode xn in xnl)
                {
                    if (xn.Attributes["type"].Value == "mod")
                    {
                        modsName.Add(xn.Attributes["name"].Value);
                    }

                    if (xn.Attributes["type"].Value == "blastcore")
                    {
                        modsName.Add(xn.Attributes["name"].Value);
                    }

                    if (xn.Attributes["type"].Value == "jsrs")
                    {
                        modsName.Add(xn.Attributes["name"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                txt_progressStatus.Text += "\n\n##ERROR: " + ex.Message;
                Thread.Sleep(6000);
                Application.ExitThread();
            }
        }

        private void LegacyTransporter_Load(object sender, EventArgs e)
        {
            txt_progressStatus.Text += "*-------------------------------------------------------------------*\n";
            txt_progressStatus.Text += "# Legacy Transporter initialized                                    #\n";
            txt_progressStatus.Text += "*-------------------------------------------------------------------*\n";
        }

        private void LegacyTransporter_Shown(object sender, EventArgs e)
        {
            loader.Start();
            running = true;

            txt_progressStatus.Text += "\n\nFetching remote settings...";
            FetchRemoteSettings();
            txt_progressStatus.Text += "\n\nRemote settings loaded.";

            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Focus();

            Thread.Sleep(1000);
            txt_progressStatus.Text += "\n\n\nChecking if new addons folder is the same as the old custom folder...";
            Thread.Sleep(1500);
            txt_progressStatus.Text += "\n\nNew folder: " + AddonsFolder;
            Thread.Sleep(500);
            txt_progressStatus.Text += "\nOld folder: " + cModsFolder;
            Thread.Sleep(500);
            if (AddonsFolder == cModsFolder)
            {
                txt_progressStatus.Text += "\n\nIt's the same, no need to move files around.";
                Thread.Sleep(500);
            }
            else
            {
                txt_progressStatus.Text += "\n\nThe new folder is different from the old custom folder. Starting to move addons from the old folder...";
                Thread.Sleep(500);

                foreach (string d in Directory.GetDirectories(cModsFolder))
                {
                    foreach (string a in modsName)
                    {
                        if (d.Contains(a))
                        {
                            txt_progressStatus.Text += "\n\nMoving " + d + " to " + AddonsFolder + "...";
                            try
                            {
                                Directory.Move(d, AddonsFolder + a);
                            }
                            catch (Exception ex)
                            {
                                txt_progressStatus.Text += "\nFailed while moving the file from " + d + " to " + AddonsFolder + " with the error:";
                                txt_progressStatus.Text += "\n" + ex.Message;
                            }
                        }
                    }
                }
            }
            Thread.Sleep(500);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txt_progressStatus.Text += "\n\nDownloading version controler files...";

            client_update.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_update_DownloadProgressChanged);
            client_update.DownloadFileCompleted += new AsyncCompletedEventHandler(client_update_DownloadFileCompleted);

            download_url = new Uri("https://dl.dropbox.com/u/3609589/spNLauncher/Releases/legacyVersionController.zip");

            client_update.DownloadFileAsync(download_url, Application.StartupPath + "\\" + filename);
            txt_progressStatus.Text += "\n\n\nDownloading from: " + download_url;
            txt_progressStatus.Text += "\nSaving file to: " + Application.StartupPath + "\\" + filename;
        }

        void client_update_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            txt_progressStatus.Text += "\nDownload completed.";

            string zipFile = Application.StartupPath + "\\" + filename;
            string aux_ModsFolder = AddonsFolder;

            using (ZipArchive archive = ZipFile.OpenRead(zipFile))
            {
                string filePath = "";

                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    try
                    {
                        filePath = Path.Combine(aux_ModsFolder, entry.FullName).Replace(@"/", @"\\").Replace(@"\\", @"\");

                        if (!filePath.StartsWith("."))
                        {
                            if (filePath.EndsWith(@"\"))
                            {
                                if (!Directory.Exists(filePath))
                                {
                                    txt_progressStatus.Text += "\n\nCreating folder .. " + filePath;

                                    Directory.CreateDirectory(filePath);
                                }
                            }
                            else
                            {
                                txt_progressStatus.Text += "\n\nExtracting file .. " + filePath;

                                if (!File.Exists(filePath))
                                {
                                    using (FileStream fs = File.Create(filePath))
                                    {
                                        fs.Close();
                                    }
                                }

                                entry.ExtractToFile(filePath, true);
                            }
                        }
                    }
                    catch (IOException ioex)
                    { txt_progressStatus.Text += "\n\n##ERROR: " + ioex.Message; }
                    catch (Exception ex)
                    { txt_progressStatus.Text += "\n\n##ERROR: " + ex.Message; }

                    Thread.Sleep(500);
                }
            }

            txt_label.Text = "\n\n\nDeleting \"" + zipFile + "\"...";
            try
            { File.Delete(zipFile); txt_label.Text = "\nDeleted \"" + zipFile + "\"."; }
            catch (Exception delEx)
            { txt_progressStatus.Text += "\n\n##ERROR: " + delEx.Message; errorOccured = true; }

            running = false;
            btn_close.Visible = true;
            loader.Stop();
            txt_label.Text = "Operation completed!";
            txt_progressStatus.Text += "\n\n\nDone!";

            if(errorOccured)
                eReport.sendReport("Someone (" + System.Environment.MachineName + ") had a problem with LegacyTransporter.\n\n" + txt_progressStatus.Text);
        }

        void client_update_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            txt_progressStatus.Text += "\n" + e.ProgressPercentage + "%";
            Thread.Sleep(200);
        }

        private void LegacyTransporter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (running)
                e.Cancel = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_progressStatus_TextChanged(object sender, EventArgs e)
        {
            txt_progressStatus.SelectionStart = txt_progressStatus.Text.Length;
            txt_progressStatus.ScrollToCaret();
        }

        int state = 0;

        private void loader_Tick(object sender, EventArgs e)
        {
            switch (state)
            {
                case 0:
                    txt_label.Text = txt_label.Text.Remove(txt_label.Text.Length - 1) + "-";
                    state++;
                    break;
                case 1:
                    txt_label.Text = txt_label.Text.Remove(txt_label.Text.Length - 1) + "\\";
                    state++;
                    break;
                case 2:
                    txt_label.Text = txt_label.Text.Remove(txt_label.Text.Length - 1) + "|";
                    state++;
                    break;
                case 3:
                    txt_label.Text = txt_label.Text.Remove(txt_label.Text.Length - 1) + "/";
                    state = 0;
                    break;
            }
        }
    }
}
