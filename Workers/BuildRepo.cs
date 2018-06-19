using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arma3Launcher.Workers
{
    class BuildRepo
    {
        private CheckedListBox addonsList;
        private Label progressText;
        private ProgressBar progressFile;

        private BackgroundWorker builder = new BackgroundWorker();

        private string repoPath = "";

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

        public BuildRepo (CheckedListBox addonsList, Label progressText, ProgressBar progressFile)
        {
            this.addonsList = addonsList;
            this.progressText = progressText;
            this.progressFile = progressFile;

            this.builder.DoWork += Builder_DoWork;
            this.builder.RunWorkerCompleted += Builder_RunWorkerCompleted;

            this.progressStatusText("Waiting for orders");
        }

        private void Builder_DoWork(object sender, DoWorkEventArgs e)
        {
            if (File.Exists(repoPath + "repoList.a3l")) { File.Delete(repoPath + "repoList.a3l"); }

            long filesCount = Directory.GetFiles(repoPath, "*", SearchOption.AllDirectories).LongLength;
            int filesDone = 0;
            string[] items = new string[filesCount];

            items = Directory.GetFiles(repoPath, "*", SearchOption.AllDirectories);

            try
            {
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
                            byte[] file = new UTF8Encoding(true).GetBytes(
                                new FileInfo(item).Length.ToString() +
                                "*" +
                                item.Remove(0, repoPath.Length)
                            );
                            fs.Write(file, 0, file.Length);

                            byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
                            fs.Write(newline, 0, newline.Length);
                        }

                        this.progressBarFileValue(Convert.ToInt32(((double)filesDone / filesCount) * 100));
                        filesDone++;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error while building repository", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Builder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressStatusText("Build complete!");
        }

        public void Run(string repoPath)
        {
            this.repoPath = repoPath;
            this.progressStatusText("Building repository file...");
            this.progressBarFileValue(0);

            builder.RunWorkerAsync();
        }
    }
}
