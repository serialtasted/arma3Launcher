using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace arma3Launcher.Workers
{
    class LaunchCore
    {
        private BackgroundWorker waitEndGame = new BackgroundWorker();
        private string GameFolder = Properties.Settings.Default.Arma3Folder;
        private string AddonsFolder = Properties.Settings.Default.AddonsFolder;
        private string TSFolder = Properties.Settings.Default.TS3Folder;
        private string Arguments = "";
        private string SvArguments = "";
        private string HcArguments = "";

        private Process process;
        private MainForm mainForm;
        private PictureBox launch;
        private Label status;

        public LaunchCore(FlowLayoutPanel launchOptions,
            bool maxMem,
            string s_maxMem,
            bool malloc,
            string s_malloc,
            bool exThreads,
            string s_exThreads,
            bool cpuCount,
            string s_cpuCount)
        {
            string auxCombinedArguments = AggregateArguments(launchOptions, maxMem, s_maxMem, malloc, s_malloc, exThreads, s_exThreads, cpuCount, s_cpuCount);

            if (auxCombinedArguments != "") Arguments = auxCombinedArguments.Remove(auxCombinedArguments.Length - 1);
        }

        public LaunchCore(FlowLayoutPanel launchOptions, 
            bool maxMem,
            string s_maxMem, 
            bool malloc,
            string s_malloc, 
            bool exThreads,
            string s_exThreads, 
            bool cpuCount,
            string s_cpuCount,
            CheckedListBox activeAddons,
            List<string> modsList,
            MainForm mainForm)
        {
            string auxCombinedArguments = AggregateArguments(launchOptions, maxMem, s_maxMem, malloc, s_malloc, exThreads, s_exThreads, cpuCount, s_cpuCount);
            string auxCoreMods = "-mod=\"";
            string auxCombinedAddons = "";
            int i = 0;

            this.mainForm = mainForm;

            foreach (string mod in modsList)
            {
                if (mod != null)
                    if (auxCoreMods != "-mod=\"")
                        auxCoreMods = auxCoreMods + ";" + AddonsFolder + mod;
                    else
                        auxCoreMods = auxCoreMods + AddonsFolder + mod;
                else
                    break;
            }

            if (auxCombinedArguments != "") Arguments = auxCombinedArguments.Remove(auxCombinedArguments.Length - 1);

            if (activeAddons.CheckedItems.Count > 0 && activeAddons.Enabled)
            {
                do
                {
                    if (auxCombinedAddons != "") auxCombinedAddons = auxCombinedAddons + ";" + AddonsFolder + activeAddons.CheckedItems[i].ToString();
                    else auxCombinedAddons = ";" + AddonsFolder + activeAddons.CheckedItems[i].ToString();
                    i++;
                } while (i != activeAddons.CheckedItems.Count);
            }

            if (modsList.Count == 0 && auxCombinedAddons != "")
                auxCombinedAddons = auxCombinedAddons.Remove(0, 1);

            if (Arguments != "") Arguments = Arguments + " " + auxCoreMods + auxCombinedAddons + "\"";
            else Arguments = auxCoreMods + auxCombinedAddons;

            //MessageBox.Show(Arguments);
        }

        private string AggregateArguments(FlowLayoutPanel launchOptions,
            bool maxMem,
            string s_maxMem,
            bool malloc,
            string s_malloc,
            bool exThreads,
            string s_exThreads,
            bool cpuCount,
            string s_cpuCount)
        {
            string auxCombinedArguments = "";

            foreach (CheckBox option in launchOptions.Controls)
            {
                try
                {
                    if (option.Checked)
                        auxCombinedArguments += option.Tag + " ";
                }
                catch { }
            }

            if (maxMem && s_maxMem != "") auxCombinedArguments = auxCombinedArguments + "-maxMem=" + s_maxMem + " ";
            if (malloc && s_malloc != "") auxCombinedArguments = auxCombinedArguments + "-malloc=" + s_malloc + " ";
            if (exThreads && s_exThreads != "") auxCombinedArguments = auxCombinedArguments + "-exThreads=" + s_exThreads + " ";
            if (cpuCount && s_cpuCount != "") auxCombinedArguments = auxCombinedArguments + "-cpuCount=" + s_cpuCount + " ";

            return auxCombinedArguments;
        }

        public string GetArguments()
        {
            return Arguments;
        }
        
        public bool isModPackInstalled()
        {
            return !(this.mainForm.ReadRepo(false));
        }

        public void LaunchGame(string Arguments, Label Status, PictureBox Launch, string[] serverInfo, string[] tsInfo, bool autoJoin)
        {
            /* 
            Array content list:
                serverInfo[0]: server ip
                serverInfo[1]: server port
                serverInfo[2]: server password

                tsInfo[0]: server ip
                tsInfo[1]: server port
                tsInfo[2]: server password
                tsInfo[3]: default channel
            */

            waitEndGame.WorkerSupportsCancellation = true;
            waitEndGame.WorkerReportsProgress = true;
            waitEndGame.DoWork += WaitEndGame_DoWork;
            waitEndGame.RunWorkerCompleted += WaitEndGame_RunWorkerCompleted;

            this.launch = Launch;
            this.status = Status;

            if (!GlobalVar.isServer)
            {

                Ping ping = new Ping();
                if ((serverInfo[0] != "" && serverInfo[2] != "") && autoJoin)
                {
                    /*PingReply pingresult = ping.Send(serverInfo[0]);
                    if (pingresult.Status == IPStatus.Success)
                    {*/
                    if (serverInfo[2] != "")
                        Arguments = "-connect=" + serverInfo[0] + " -port=" + serverInfo[1] + " -password=\"" + serverInfo[2] + "\" " + Arguments;
                    else
                        Arguments = "-connect=" + serverInfo[0] + " -port=" + serverInfo[1] + " " + Arguments;
                    //}
                }


                if (Process.GetProcessesByName("ts3client_win64").Length <= 0 && Process.GetProcessesByName("ts3client_win32").Length <= 0)
                {
                    if (Directory.Exists(TSFolder) && (File.Exists(TSFolder + "ts3client_win64.exe") || File.Exists(TSFolder + "ts3client_win32.exe")))
                    {
                        try
                        {
                            var fass = new ProcessStartInfo();
                            fass.WorkingDirectory = TSFolder;

                            if (tsInfo[0] != "" && tsInfo[2] != "")
                                fass.Arguments = "ts3server://\"" + tsInfo[0] + "/?port=" + tsInfo[1] + "&channel=" + tsInfo[3] + "\"";
                            else if (tsInfo[0] != "")
                                fass.Arguments = "ts3server://\"" + tsInfo[0] + "/?port=" + tsInfo[1] + "&password=" + tsInfo[2] + "&channel=" + tsInfo[3] + "\"";

                            if (File.Exists(TSFolder + "ts3client_win64.exe"))
                                fass.FileName = "ts3client_win64.exe";

                            if (File.Exists(TSFolder + "ts3client_win32.exe"))
                                fass.FileName = "ts3client_win32.exe";

                            var process = new Process();
                            process.StartInfo = fass;

                            process.Start();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                        MessageBox.Show("TeamSpeak directory doesn't exist or executable not there. Please check your TeamSpeak directory and try again.", "Missing directory or file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Process[] pname = Process.GetProcessesByName("steam");
                if (pname.Length == 0)
                {
                    try
                    {
                        Status.Text = "Starting Steam...";

                        var fass = new ProcessStartInfo();
                        fass.WorkingDirectory = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam", "SteamPath", "").ToString().Replace(@"/", @"\") + @"\";
                        fass.FileName = "steam.exe";
                        fass.Arguments = Arguments;

                        var process = new Process();
                        process.StartInfo = fass;
                        process.Start();
                        Thread.SpinWait(2000);
                        Thread.Sleep(2000);
                    }
                    catch { }
                }

            }
            else
            {
                SvArguments = "-port=" + serverInfo[1] + " \"-config=" + GameFolder + "TADST\\PTrdefault\\TADST_config.cfg\" \"-cfg=" + GameFolder + "TADST\\PTrdefault\\TADST_basic.cfg\" \"-profiles=" + GameFolder + "TADST\\PTrdefault\" -name=PTrdefault " + Arguments;
                HcArguments = "-client -connect=localhost -port=" + serverInfo[1] + " -password=\"" + serverInfo[2] + "\" -profile=PTrHeadlessClient -name=PTrHeadlessClient " + Arguments;
            }

            if (Directory.Exists(GameFolder) && File.Exists(GameFolder + GlobalVar.gameArtifact))
            {
                try
                {
                    string whatsRunning = "";
                    var gameProcessInfo = new ProcessStartInfo();
                    var hcProcessInfo = new ProcessStartInfo();
                    gameProcessInfo.WorkingDirectory = hcProcessInfo.WorkingDirectory = GameFolder;

                    if (GlobalVar.isServer)
                    {
                        gameProcessInfo.FileName = hcProcessInfo.FileName = "arma3server.exe";
                        gameProcessInfo.Arguments = SvArguments;
                        hcProcessInfo.Arguments = HcArguments;

                        var hcProcess = new Process();
                        hcProcess.StartInfo = hcProcessInfo;
                        hcProcess.Start();

                        whatsRunning = "Server";
                    }
                    else
                    {
                        gameProcessInfo.FileName = GlobalVar.gameArtifact;
                        gameProcessInfo.Arguments = "2 1 " + Arguments;

                        whatsRunning = "Game";
                    }

                    var gameProcess = new Process();
                    gameProcess.StartInfo = gameProcessInfo;
                    this.process = gameProcess;
                    gameProcess.Start();

                    Thread.Sleep(500);

                    GC.Collect();

                    Status.Text = whatsRunning + " running...";
                    mainForm.reSizeBarText(whatsRunning + "Running");
                    Launch.Enabled = false;
                    mainForm.minimizeWindow();
                    mainForm.Cursor = Cursors.Default;
                    waitEndGame.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Game directory doesn't exist or executable not there. Please check your Arma 3 directory and try again.", "Missing directory or file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Launch.Enabled = true;
            }
        }

        private void WaitEndGame_DoWork(object sender, DoWorkEventArgs e)
        {
            this.process.WaitForExit();
        }

        private void WaitEndGame_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.mainForm.WindowState = FormWindowState.Normal;
            this.mainForm.Focus();
            this.launch.Enabled = true;
            this.status.Text = "Waiting for orders...";
            this.mainForm.reSizeBarText("WaitingForOrders");

            if (GlobalVar.autoPilot)
                this.mainForm.reLaunchServer();
        }
    }
}
