using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using arma3Launcher.Effects;
using arma3Launcher.Controls;

namespace arma3Launcher.Workers
{
    class BuildRepo
    {
        private CheckedListBox addonsList;
        private Label progressText;
        private Windows7ProgressBar progressFile;
        private TextBox buildLog;
        private WindowIO windowIO;
        private Button buildBtn;
        private CheckBox checkBtn;

        private bool isBuilding = false;

        private BackgroundWorker builder = new BackgroundWorker();

        // workers
        private RepoReader repoReader;

        private string repoPath = string.Empty;

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

        private void buildLogText(string text)
        {
            if (this.buildLog.InvokeRequired)
            {
                this.buildLog.Invoke(new MethodInvoker(delegate { this.buildLog.AppendText(text); }));
            }
            else
            {
                this.buildLog.AppendText(text);
            }
        }

        public BuildRepo (CheckedListBox addonsList, Label progressText, Windows7ProgressBar progressFile, TextBox buildLog, WindowIO windowIO, Button buildBtn, CheckBox checkBtn)
        {
            this.repoReader = new RepoReader();

            this.addonsList = addonsList;
            this.progressText = progressText;
            this.progressFile = progressFile;
            this.buildLog = buildLog;
            this.windowIO = windowIO;
            this.buildBtn = buildBtn;
            this.checkBtn = checkBtn;

            this.builder.DoWork += Builder_DoWork;
            this.builder.RunWorkerCompleted += Builder_RunWorkerCompleted;
            this.builder.WorkerSupportsCancellation = true;

            this.progressStatusText("Waiting for orders");
        }

        public void CancelBuild()
        {
            if (this.isBuilding)
            {
                this.builder.CancelAsync();
            }
            else
            {
                windowIO.windowOut(true);
            }
        }

        private void Builder_DoWork(object sender, DoWorkEventArgs e)
        {
            if (File.Exists(repoPath + "repoList.a3l")) { File.Delete(repoPath + "repoList.a3l"); }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            long filesCount = Directory.GetFiles(repoPath, "*", SearchOption.AllDirectories).LongLength;
            int filesSelected = 0;
            int filesDone = 0;
            string[] items = new string[filesCount];

            items = Directory.GetFiles(repoPath, "*", SearchOption.AllDirectories);

            try
            {
                foreach (string item in items)
                {
                    for (int i = 0; i < addonsList.CheckedItems.Count; i++)
                    {
                        if (addonsList.CheckedItems[i].ToString() == item.Remove(0, repoPath.Length).Split('\\')[0]) { filesSelected++; }
                    }
                }

                using (FileStream fs = File.Create(repoPath + "repoList.a3l"))
                {
                    foreach (string item in items)
                    {
                        bool addIt = false;

                        for (int i = 0; i < addonsList.CheckedItems.Count; i++)
                        {
                            if (addonsList.CheckedItems[i].ToString() == item.Remove(0, repoPath.Length).Split('\\')[0]) { addIt = true; }
                        }


                        if (addIt)
                        {
                            int splitCount = item.Split('\\').Length;
                            this.buildLogText(Environment.NewLine + "Adding: " + item.Split('\\')[splitCount - 1]);

                            byte[] file = new UTF8Encoding(true).GetBytes(
                                repoReader.CalculateFileHash(item) + "*" +
                                string.Format("{2:0000}{1:00}{0:00}{3:00}{4:00}{5:00}", File.GetLastWriteTime(item).Day, File.GetLastWriteTime(item).Month, File.GetLastWriteTime(item).Year, File.GetLastWriteTime(item).Hour, File.GetLastWriteTime(item).Minute, File.GetLastWriteTime(item).Second) + "*" +
                                item.Remove(0, repoPath.Length)
                            );
                            fs.Write(file, 0, file.Length);

                            byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                            fs.Write(newline, 0, newline.Length);

                            filesDone++;
                        }

                        this.progressBarFileValue(Convert.ToInt32(((double)filesDone / filesSelected) * 100));

                        if (this.builder.CancellationPending)
                        { e.Cancel = true; break; }
                    }
                }
            }
            catch (Exception ex) { new Windows.MessageBox().Show(ex.Message, "Error while building repository", MessageBoxButtons.OK, MessageIcon.Error); }
            finally
            {
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);

                stopWatch.Stop();

                this.buildLogText(Environment.NewLine);
                this.buildLogText(Environment.NewLine + "Files in repository folder: " + filesCount);
                this.buildLogText(Environment.NewLine + "Files added to catalog: " + filesDone + " of " + filesSelected);
                this.buildLogText(Environment.NewLine + "Catalog built in: " + elapsedTime);
            }
        }

        private void Builder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.isBuilding = false;
            this.buildBtn.Enabled = true;
            this.checkBtn.Enabled = true;

            if (e.Cancelled)
            {
                this.buildLog.ForeColor = System.Drawing.Color.Red;
                this.progressFile.State = ProgressBarState.Error;
                this.progressStatusText("Build canceled!");
                this.buildLogText(Environment.NewLine + "Catalog build canceled!");
                this.buildLogText(Environment.NewLine + "To close the Repository Manager press the close button again.");
            }
            else
            {
                this.progressStatusText("Build complete!");
                this.buildLogText(Environment.NewLine + "Catalog build complete!");
            }
        }

        public void Run(string repoPath)
        {
            this.repoPath = repoPath;

            this.isBuilding = true;
            this.buildLog.Clear();
            this.buildLog.ForeColor = System.Drawing.Color.Lime;
            this.progressFile.State = ProgressBarState.Normal;

            this.progressStatusText("Building repository file...");
            this.buildLogText("Started building process...");
            this.progressBarFileValue(0);

            this.buildBtn.Enabled = false;
            this.checkBtn.Enabled = false;
            builder.RunWorkerAsync();
        }

        private async Task taskDelay(int delayMs)
        {
            await Task.Delay(delayMs);
        }
    }
}
