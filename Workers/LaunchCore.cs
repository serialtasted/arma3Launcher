using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using arma3Launcher.Controls;

namespace arma3Launcher.Workers
{
    class LaunchCore
    {
        private BackgroundWorker waitEndGame = new BackgroundWorker();
        private string GameFolder = Properties.Settings.Default.Arma3Folder;
        private string AddonsFolder = Properties.Settings.Default.AddonsFolder;
        private string TSFolder = Properties.Settings.Default.TS3Folder;
        private string WorkshopFolder = Properties.Settings.Default.Arma3Folder + "!Workshop\\";
        private string Arguments = string.Empty;
        private string SvArguments = string.Empty;
        private string HcArguments = string.Empty;
        private int HcInstances = 0;

        private Process process;
        private MainForm2 mainForm;
        private DoubleBufferFlowPanel flowpanelAddonPacks;
        private Label status;

        public LaunchCore(DoubleBufferFlowPanel launchOptions,
            string clientProfile,
            string serverConfig,
            string serverProfile,
            string hcProfile,
            int hcInstances,
            bool maxMem,
            string s_maxMem,
            bool malloc,
            string s_malloc,
            bool exThreads,
            string s_exThreads,
            bool cpuCount,
            string s_cpuCount)
        {
            string auxCombinedArguments = AggregateArguments(launchOptions, clientProfile, serverConfig, serverProfile, hcProfile, maxMem, s_maxMem, malloc, s_malloc, exThreads, s_exThreads, cpuCount, s_cpuCount);
            this.HcInstances = hcInstances;

            if (auxCombinedArguments != string.Empty) Arguments = auxCombinedArguments.Remove(auxCombinedArguments.Length - 1);
        }

        public LaunchCore(DoubleBufferFlowPanel launchOptions,
            string clientProfile,
            string serverConfig,
            string serverProfile,
            string hcProfile,
            int hcInstances,
            bool maxMem,
            string s_maxMem, 
            bool malloc,
            string s_malloc, 
            bool exThreads,
            string s_exThreads, 
            bool cpuCount,
            string s_cpuCount,
            DoubleBufferFlowPanel workshopAddons,
            List<string> addonsList,
            bool isOptionalAllowed,
            MainForm2 mainForm)
        {
            string auxCombinedArguments = AggregateArguments(launchOptions, clientProfile, serverConfig, serverProfile, hcProfile, maxMem, s_maxMem, malloc, s_malloc, exThreads, s_exThreads, cpuCount, s_cpuCount);
            string auxCoreMods = "-mod=\"";
            string auxCombinedAddons = string.Empty;

            this.mainForm = mainForm;
            this.HcInstances = hcInstances;

            foreach (string addon in addonsList)
            {
                if (addon != null)
                    if (auxCoreMods != "-mod=\"")
                        auxCoreMods = auxCoreMods + ";" + AddonsFolder + addon;
                    else
                        auxCoreMods = auxCoreMods + AddonsFolder + addon;
                else
                    break;
            }

            if (auxCombinedArguments != string.Empty) Arguments = auxCombinedArguments.Remove(auxCombinedArguments.Length - 1);

            if (workshopAddons.Controls.Count > 0 && isOptionalAllowed)
            {
                foreach (MaterialSkin.Controls.MaterialCheckBox waddon in workshopAddons.Controls)
                {
                    if (waddon.Checked)
                    {
                        if (auxCombinedAddons != string.Empty) auxCombinedAddons += ";" + WorkshopFolder + waddon.Text;
                        else auxCombinedAddons = ";" + WorkshopFolder + waddon.Text;
                    }
                }
            }

            if (addonsList.Count == 0 && auxCombinedAddons != string.Empty)
                auxCombinedAddons = auxCombinedAddons.Remove(0, 1);

            if (Arguments != string.Empty) Arguments = Arguments + " " + auxCoreMods + auxCombinedAddons + "\"";
            else Arguments = auxCoreMods + auxCombinedAddons;

            //MessageBox.Show(Arguments);
        }

        private string AggregateArguments(DoubleBufferFlowPanel launchOptions,
            string clientProfile,
            string serverConfig,
            string serverProfile,
            string hcProfile,
            bool maxMem,
            string s_maxMem,
            bool malloc,
            string s_malloc,
            bool exThreads,
            string s_exThreads,
            bool cpuCount,
            string s_cpuCount)
        {
            string auxCombinedArguments = string.Empty;
            this.SvArguments = string.Empty;
            this.HcArguments = string.Empty;

            if (GlobalVar.isServer)
            {
                if (serverConfig.ToLower().EndsWith(".cfg")) SvArguments += "-config=" + serverConfig + " ";
                if (serverProfile.ToLower() != "default") SvArguments += "-name=" + serverProfile + " ";
                if (hcProfile.ToLower() != "default") HcArguments += "-name=" + hcProfile + " ";
            }
            else
            {
                if (clientProfile.ToLower() != "default") auxCombinedArguments += "-name=" + clientProfile + " ";
            }

            if (maxMem && s_maxMem != string.Empty) auxCombinedArguments += "-maxMem=" + s_maxMem + " ";
            if (malloc && s_malloc != string.Empty) auxCombinedArguments += "-malloc=" + s_malloc + " ";
            if (exThreads && s_exThreads != string.Empty) auxCombinedArguments += "-exThreads=" + s_exThreads + " ";
            if (cpuCount && s_cpuCount != string.Empty) auxCombinedArguments += "-cpuCount=" + s_cpuCount + " ";

            foreach (CheckBox option in launchOptions.Controls)
            {
                try
                {
                    if (option.Checked)
                        auxCombinedArguments += option.Tag + " ";
                }
                catch { }
            }

            return auxCombinedArguments;
        }

        public string GetArguments()
        {
            return Arguments;
        }

        public void LaunchGame(string Arguments, Label Status, DoubleBufferFlowPanel flowpanelAddonPacks, string[] serverInfo, string[] tsInfo, bool autoJoin, bool autoJoinTs)
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

            this.flowpanelAddonPacks = flowpanelAddonPacks;
            this.status = Status;

            if (!GlobalVar.isServer)
            {

                Ping ping = new Ping();
                if ((serverInfo[0] != string.Empty && serverInfo[2] != string.Empty) && autoJoin && !GlobalVar.offlineMode)
                {
                    /*PingReply pingresult = ping.Send(serverInfo[0]);
                    if (pingresult.Status == IPStatus.Success)
                    {*/
                    if (serverInfo[2] != string.Empty)
                        Arguments = "-connect=" + serverInfo[0] + " -port=" + serverInfo[1] + " -password=\"" + serverInfo[2] + "\" " + Arguments;
                    else
                        Arguments = "-connect=" + serverInfo[0] + " -port=" + serverInfo[1] + " " + Arguments;
                    //}
                }


                if (Process.GetProcessesByName("ts3client_win64").Length <= 0 && Process.GetProcessesByName("ts3client_win32").Length <= 0 && autoJoinTs && !GlobalVar.offlineMode)
                {
                    if (Directory.Exists(TSFolder) && (File.Exists(TSFolder + "ts3client_win64.exe") || File.Exists(TSFolder + "ts3client_win32.exe")))
                    {
                        try
                        {
                            var fass = new ProcessStartInfo();
                            fass.WorkingDirectory = TSFolder;

                            if (tsInfo[0] != string.Empty && tsInfo[2] != string.Empty)
                                fass.Arguments = "ts3server://\"" + tsInfo[0] + "/?port=" + tsInfo[1] + "&channel=" + tsInfo[3] + "\"";
                            else if (tsInfo[0] != string.Empty)
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
                            MessageBox.Show(ex.Message, "Unable to start TeamSpeak 3");
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
                SvArguments += "-port=" + serverInfo[1] + " " + Arguments;
                HcArguments += "-client -connect=localhost -port=" + serverInfo[1] + " -password=\"" + serverInfo[2] + "\" " + Arguments;
            }

            if (Directory.Exists(GameFolder) && File.Exists(GameFolder + GlobalVar.gameArtifact))
            {
                try
                {
                    string whatsRunning = string.Empty;
                    var gameProcessInfo = new ProcessStartInfo();
                    var hcProcessInfo = new ProcessStartInfo();
                    gameProcessInfo.WorkingDirectory = hcProcessInfo.WorkingDirectory = GameFolder;

                    if (GlobalVar.isServer)
                    {
                        gameProcessInfo.FileName = hcProcessInfo.FileName = GlobalVar.gameArtifact;
                        gameProcessInfo.Arguments = SvArguments;
                        hcProcessInfo.Arguments = HcArguments;

                        for (int i = 0; i < HcInstances; i++)
                        {
                            var hcProcess = new Process();
                            hcProcess.StartInfo = hcProcessInfo;
                            hcProcess.Start();
                        }

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
                    mainForm.minimizeWindow();
                    mainForm.Cursor = Cursors.Default;
                    waitEndGame.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to start Arma 3");
                }
            }
            else
            {
                MessageBox.Show("Game directory doesn't exist or executable not there. Please check your Arma 3 directory and try again.", "Missing directory or file", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.status.Text = "Waiting for orders...";

            if (GlobalVar.autoPilot)
                this.mainForm.reLaunchServer();
        }
    }
}
