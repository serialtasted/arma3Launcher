using arma3Launcher.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arma3Launcher.Workers
{
    class Installer
    {
        // controls
        private Windows7ProgressBar progressFile;
        private Windows7ProgressBar progressAll;
        private Label progressText;
        private Label progressDetails;
        private Label progressCurFile;
        private PictureBox launcherButton;
        private String activeForm;

        // controls (directory fields)
        private TextBox gamePathBox;
        private TextBox ts3PathBox;
        private TextBox addonsPathBox;
        private Button gamePathErase;
        private Button ts3PathErase;
        private Button addonsPathErase;
        private PictureBox gamePathFind;
        private PictureBox ts3PathFind;
        private PictureBox addonsPathFind;

        // controls (toolstrip menu items)
        private ToolStripMenuItem ts3Plugin;
        private ToolStripMenuItem downloadJSRS;
        private ToolStripMenuItem downloadBlastcore;

        // forms
        private MainForm mainForm;

        // user controls
        private PackBlock packBlock;

        // background workers
        private BackgroundWorker installFiles = new BackgroundWorker();

        // timer
        private Timer delayLaunch = new Timer();

        // folder paths
        private string TempFolder = Path.GetTempPath() + @"arma3Launcher\";
        private string GameFolder = "";
        private string TS3Folder = "";
        private string AddonsFolder = "";

        // paramters
        private bool isLaunch = false;

        // controllers
        private string configFile = "";
        private string activePack = "";
        private bool installationRunning = false;
        private bool isJSRS = false;
        private bool isBlastcore = false;

        // error report
        private EmailReporter reportError;

        // callbacks
        delegate void stringCallBack(string text);
        delegate void intCallBack(int number);

        // invokes
        private void progressBarFileStyle(ProgressBarStyle prbStyle)
        {
            if (this.progressFile.InvokeRequired)
            {
                this.progressFile.Invoke(new MethodInvoker(delegate { this.progressFile.Style = prbStyle; }));
            }
            else
            {
                this.progressFile.Style = prbStyle;
            }
        }

        private void progressBarFileState(ProgressBarState prbState)
        {
            if (this.progressFile.InvokeRequired)
            {
                this.progressFile.Invoke(new MethodInvoker(delegate { this.progressFile.State = prbState; }));
            }
            else
            {
                this.progressFile.State = prbState;
            }
        }

        private void currentFileText(string text)
        {
            if (this.progressCurFile.InvokeRequired)
            {
                this.progressCurFile.Invoke(new MethodInvoker(delegate { this.progressCurFile.Text = text; }));
            }
            else
            {
                this.progressCurFile.Text = text;
            }
        }

        private void progressStatusText(string text)
        {
            if (this.progressText.InvokeRequired)
            {
                this.progressText.Invoke(new MethodInvoker(delegate { this.progressText.Text = text; }));
            }
            else
            {
                this.progressText.Text = text;
            }
        }

        private void progressDetailsText(string text)
        {
            if (this.progressDetails.InvokeRequired)
            {
                this.progressDetails.Invoke(new MethodInvoker(delegate { this.progressDetails.Text = text; }));
            }
            else
            {
                this.progressDetails.Text = text;
            }
        }

        private void progressBarFileValue(int prbValue)
        {
            if (this.progressFile.InvokeRequired)
            {
                this.progressFile.Invoke(new MethodInvoker(delegate { this.progressFile.Value = prbValue; }));
            }
            else
            {
                this.progressFile.Value = prbValue;
            }
        }

        private void progressBarAllValue(int prbValue)
        {
            if (this.progressAll.InvokeRequired)
            {
                this.progressAll.Invoke(new MethodInvoker(delegate { this.progressAll.Value = prbValue; }));
            }
            else
            {
                this.progressAll.Value = prbValue;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainForm"></param>
        /// <param name="progressFile"></param>
        /// <param name="progressAll"></param>
        /// <param name="progressText"></param>
        /// <param name="progressDetails"></param>
        /// <param name="progressCurFile"></param>
        /// <param name="launcherButton"></param>
        public Installer (MainForm mainForm, Windows7ProgressBar progressFile, Windows7ProgressBar progressAll, Label progressText, Label progressDetails, Label progressCurFile, PictureBox launcherButton,
            TextBox gamePathBox, TextBox ts3PathBox, TextBox addonsPathBox, Button gamePathErase, Button ts3PathErase, Button addonsPathErase, PictureBox gamePathFind, PictureBox ts3PathFind, PictureBox addonsPathFind,
            ToolStripMenuItem ts3Plugin, ToolStripMenuItem downloadJSRS, ToolStripMenuItem downloadBlastcore)
        {
            this.activeForm = "mainForm";
            this.mainForm = mainForm;

            // construct error report
            this.reportError = new EmailReporter();

            // define controls
            this.progressFile = progressFile;
            this.progressAll = progressAll;
            this.progressText = progressText;
            this.progressDetails = progressDetails;
            this.progressCurFile = progressCurFile;
            this.launcherButton = launcherButton;

            // define controls (directory fields)
            this.gamePathBox = gamePathBox;
            this.gamePathErase = gamePathErase;
            this.gamePathFind = gamePathFind;

            this.ts3PathBox = ts3PathBox;
            this.ts3PathErase = ts3PathErase;
            this.ts3PathFind = ts3PathFind;

            this.addonsPathBox = addonsPathBox;
            this.addonsPathErase = addonsPathErase;
            this.addonsPathFind = addonsPathFind;

            // define controls (toolstrip menu items)
            this.ts3Plugin = ts3Plugin;
            this.downloadJSRS = downloadJSRS;
            this.downloadBlastcore = downloadBlastcore;

            // define background worker
            this.installFiles.DoWork += InstallFiles_DoWork;
            this.installFiles.RunWorkerCompleted += InstallFiles_RunWorkerCompleted;

            // define timer
            this.delayLaunch.Interval = 2000;
            this.delayLaunch.Tick += DelayLaunch_Tick;
        }

        public Installer(PackBlock packBlock, Windows7ProgressBar progressFile, Windows7ProgressBar progressAll, Label progressText, Label progressDetails, Label progressCurFile, PictureBox launcherButton,
            String gamePath, String ts3Path, String addonsPath)
        {
            this.activeForm = "packBlock";
            this.packBlock = packBlock;

            // construct error report
            this.reportError = new EmailReporter();

            // define controls
            this.progressFile = progressFile;
            this.progressAll = progressAll;
            this.progressText = progressText;
            this.progressDetails = progressDetails;
            this.progressCurFile = progressCurFile;
            this.launcherButton = launcherButton;

            // define paths
            gamePathBox = new TextBox();
            gamePathBox.Text = gamePath;

            ts3PathBox = new TextBox();
            ts3PathBox.Text = ts3Path;

            addonsPathBox = new TextBox();
            addonsPathBox.Text = addonsPath;

            // define background worker
            this.installFiles.DoWork += InstallFiles_DoWork;
            this.installFiles.RunWorkerCompleted += InstallFiles_RunWorkerCompleted;
        }

        /// <summary>
        /// Begins the process of installation
        /// </summary>
        /// <param name="isConfig"></param>
        public void beginInstall(bool isLaunch, string configFile, string activePack)
        {
            // report status
            this.progressStatusText("Preparing the installation process...");

            // define config file name
            this.configFile = configFile;

            // reset progress bars
            this.progressFile.Value = 0;
            this.progressAll.Value = 0;

            // define if is launch
            this.isLaunch = isLaunch;

            // define active pack
            this.activePack = activePack;

            // define paths
            this.GameFolder = Properties.Settings.Default.Arma3Folder;
            this.TS3Folder = Properties.Settings.Default.TS3Folder;
            this.AddonsFolder = Properties.Settings.Default.AddonsFolder;

            // create addons folder
            if (!Directory.Exists(AddonsFolder))
                Directory.CreateDirectory(AddonsFolder);

            // lock directory fields
            this.gamePathBox.Enabled = false;
            this.gamePathErase.Enabled = false;
            this.gamePathFind.Enabled = false;

            this.ts3PathBox.Enabled = false;
            this.ts3PathErase.Enabled = false;
            this.ts3PathFind.Enabled = false;

            this.addonsPathBox.Enabled = false;
            this.addonsPathErase.Enabled = false;
            this.addonsPathFind.Enabled = false;

            // begin installation
            this.installationRunning = true;
            GlobalVar.isInstalling = true;
            this.installFiles.RunWorkerAsync();
        }

        /// <summary>
        /// Installation background worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InstallFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            bool isTFR = false;
            bool isRHS_AFRF = false;
            bool isRHS_USF = false;

            bool allFine = true;
            string aux_ModsFolder = AddonsFolder;

            try
            {
                int nAll = 0;
                foreach (string zipFile in Directory.GetFiles(this.TempFolder))
                {
                    if (zipFile != null)
                        using (ZipArchive archive = ZipFile.OpenRead(zipFile))
                        {
                            this.progressStatusText("Extracting new files...");

                            string filePath = "";
                            int nFile = 0;

                            if (zipFile.Contains(this.configFile))
                                aux_ModsFolder = GameFolder;
                            else
                                aux_ModsFolder = AddonsFolder;

                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                if (entry.FullName.Contains("@task_force_radio") && !isTFR)
                                { isTFR = true; }

                                if (entry.FullName.Contains("@RHSAFRF") && !isRHS_AFRF)
                                { isRHS_AFRF = true; }

                                if (entry.FullName.Contains("@RHSUSF") && !isRHS_USF)
                                { isRHS_USF = true; }

                                try
                                {
                                    filePath = Path.Combine(aux_ModsFolder, entry.FullName).Replace(@"/", @"\\").Replace(@"\\", @"\");

                                    string[] aux_topFolder = entry.FullName.Split('/');
                                    if (!Directory.Exists(Path.Combine(aux_ModsFolder, aux_topFolder[0])) && aux_topFolder.Length > 1)
                                        Directory.CreateDirectory(Path.Combine(aux_ModsFolder, aux_topFolder[0]));

                                    if (!entry.FullName.Contains(@"\."))
                                    {
                                        if (filePath.EndsWith(@"\"))
                                        {
                                            if (!Directory.Exists(filePath))
                                            {
                                                this.currentFileText("Creating folder .. " + filePath);

                                                Directory.CreateDirectory(filePath);
                                            }
                                        }
                                        else
                                        {
                                            this.currentFileText("Extracting file .. " + filePath);

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
                                { MessageBox.Show(ioex.Message); }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message); }

                                this.progressBarFileValue(Convert.ToInt32(((double)nFile++ / archive.Entries.Count) * 100));
                            }

                            this.currentFileText("");
                        }
                    else
                        break;

                    this.progressBarAllValue(Convert.ToInt32(((double)nAll++ / (Directory.GetFiles(this.TempFolder).Length + 1)) * 100));
                }

                #region isTFR
                if (isTFR)
                {
                    bool awaitTSPlugin = true;
                    do
                    {
                        try
                        {
                            this.progressBarFileState(ProgressBarState.Normal);
                            this.progressStatusText("Installing TeamSpeak 3 plugins...");

                            string sourcePath = AddonsFolder + @"@task_force_radio\plugins";
                            string destinationPath = Properties.Settings.Default.TS3Folder + @"plugins";

                            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                                Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));


                            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                                File.Copy(newPath, newPath.Replace(sourcePath, destinationPath), true);

                            awaitTSPlugin = false;
                        }
                        catch
                        {
                            this.progressBarFileState(ProgressBarState.Pause);
                            if (MessageBox.Show("Disable all TFR plugins in your TeamSpeak 3 before continue.\n\n • Go to \"Settings\"\n • Open the \"Plugins\" window\n • Disable all Task Force Radio plugins\n • Hit \"Close\"", "Found a problem with TFR installation", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                                awaitTSPlugin = true;
                            else
                            { 
                                awaitTSPlugin = false;
                                throw;
                            }
                        }
                    } while (awaitTSPlugin);
                }
                #endregion

                #region isRHS_AFRF
                if (isRHS_AFRF)
                {
                    try
                    {
                        var fass = new ProcessStartInfo();
                        fass.WorkingDirectory = AddonsFolder + "@RHSAFRF";
                        fass.FileName = "update_rhsafrf.bat";

                        var process = new Process();
                        process.StartInfo = fass;
                        process.Start();

                        this.progressStatusText("Installing RHS AFRF...");
                        this.progressBarFileStyle(ProgressBarStyle.Marquee);
                        process.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                #endregion

                #region isRHS_USF
                if (isRHS_USF)
                {
                    try
                    {
                        var fass = new ProcessStartInfo();
                        fass.WorkingDirectory = AddonsFolder + "@RHSUSF";
                        fass.FileName = "update_rhsusf.bat";

                        var process = new Process();
                        process.StartInfo = fass;
                        process.Start();

                        this.progressStatusText("Installing RHS USF...");
                        this.progressBarFileStyle(ProgressBarStyle.Marquee);
                        process.WaitForExit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                this.progressBarFileState(ProgressBarState.Error);
                e.Cancel = true;
                allFine = false;
                this.progressStatusText("Something went wrong. Please try again.");
                MessageBox.Show(ex.Message, "Installation failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (allFine)
                    this.progressStatusText("Installation completed successfully. Cleaning up...");

                if (Directory.Exists(AddonsFolder + @"@task_force_radio\plugins"))
                    this.ts3Plugin.Enabled = true;
                else
                    this.ts3Plugin.Enabled = false;
            }
        }

        private void InstallFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.isJSRS)
                this.downloadJSRS.Enabled = true;

            if (this.isBlastcore)
                this.downloadBlastcore.Enabled = true;

            if (Directory.Exists(this.TempFolder))
                Directory.Delete(this.TempFolder, true);

            switch (activeForm)
            {
                case "mainForm":
                    if (!e.Cancelled && this.isLaunch && this.mainForm.startGameAfterDownload())
                    {
                        this.isLaunch = false;
                        this.progressBarFileStyle(ProgressBarStyle.Marquee);
                        this.progressBarFileValue(50);
                        this.progressStatusText("Launching game...");
                        this.delayLaunch.Start();
                    }
                    else if (!e.Cancelled && this.isLaunch && !this.mainForm.startGameAfterDownload())
                    {
                        this.isLaunch = false;
                        this.progressStatusText("Game ready to launch...");
                    }
                    else if (!e.Cancelled)
                    {
                        this.progressStatusText("Waiting for orders");
                        this.mainForm.GetAddons();
                    }

                    // unlock directory fields
                    this.gamePathBox.Enabled = true;
                    this.gamePathErase.Enabled = true;
                    this.gamePathFind.Enabled = true;

                    this.ts3PathBox.Enabled = true;
                    this.ts3PathErase.Enabled = true;
                    this.ts3PathFind.Enabled = true;

                    this.addonsPathBox.Enabled = true;
                    this.addonsPathErase.Enabled = true;
                    this.addonsPathFind.Enabled = true;

                    break;

                case "packBlock":
                    this.packBlock.hidePanel();
                    break;
            }

            this.progressBarAllValue(0);
            this.progressBarFileValue(0);
            this.progressBarFileState(ProgressBarState.Normal);
            this.progressBarFileStyle(ProgressBarStyle.Continuous);

            // unlock controls
            this.launcherButton.Enabled = true;

            this.installationRunning = false;
            GlobalVar.isInstalling = false;
        }

        /// <summary>
        /// Check if is installing addons
        /// </summary>
        /// <returns></returns>
        public bool isInstalling()
        {
            return this.installationRunning;
        }

        /// <summary>
        /// Gives some delay to the launch process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DelayLaunch_Tick(object sender, EventArgs e)
        {
            this.delayLaunch.Stop();
            this.mainForm.runGame();
        }

        public void installTeamSpeakPlugin()
        {
            this.progressBarFileStyle(ProgressBarStyle.Continuous);
            this.progressBarFileValue(0);

            if (Directory.Exists(AddonsFolder + @"@task_force_radio\plugins"))
            {
                bool awaitTSPlugin = true;
                do
                {
                    try
                    {
                        this.progressBarFileState(ProgressBarState.Normal);
                        this.progressStatusText("Installing TeamSpeak 3 plugins...");

                        string sourcePath = AddonsFolder + @"@task_force_radio\plugins";
                        string destinationPath = Properties.Settings.Default.TS3Folder + @"plugins";

                        foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                            Directory.CreateDirectory(dirPath.Replace(sourcePath, destinationPath));


                        foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                            File.Copy(newPath, newPath.Replace(sourcePath, destinationPath), true);

                        awaitTSPlugin = false;

                        MessageBox.Show("Task Force Radio plugins have been reinstalled sucessfully.", "TFR Plugins", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        this.progressBarFileState(ProgressBarState.Pause);
                        if (MessageBox.Show("Disable all TFR plugins in your TeamSpeak 3 before continue.\n\n • Go to \"Settings\"\n • Open the \"Plugins\" window\n • Disable all Task Force Radio plugins\n • Hit \"Close\"", "Found a problem with TFR installation", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                            awaitTSPlugin = true;
                        else
                        {
                            awaitTSPlugin = false;
                            break;
                        }
                    }
                } while (awaitTSPlugin);

                this.progressBarFileValue(0);
                this.progressStatusText("Waiting for orders");
            }
            else
            {
                MessageBox.Show("No such directory \"" + AddonsFolder + @"@task_force_radio\plugins" + "\".", "No such file or directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
