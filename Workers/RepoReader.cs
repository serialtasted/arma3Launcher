using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using arma3Launcher.Controls;
using MetroFramework.Controls;

namespace arma3Launcher.Workers
{
    class RepoReader
    {
        private Downloader downloader;
        private Installer installer;
        private readonly MainForm2 mainForm;
        private DoubleBufferFlowPanel flowpanelAddonPacks;

        private TreeView repoTreeView;
        private readonly string TempFolder = Path.GetTempPath() + @"arma3Launcher\";
        private string AddonsFolder = string.Empty;

        private List<string> modsHash = new List<string>();
        private List<string> modsEdit = new List<string>();
        private List<string> modsList = new List<string>();

        private int filesOK;
        private int filesINVALID;
        private int filesMISSING;

        private readonly Label lbl_filesOK;
        private readonly Label lbl_filesINVALID;
        private readonly Label lbl_filesMISSING;

        private readonly BackgroundWorker validateRepo = new BackgroundWorker();

        private string repoFile = string.Empty;

        private enum UpdateType {
            None,
            Validation,
            Download
        };
        private UpdateType needsUpdate;

        private bool showMessage = false;
        private bool autoDownload = false;
        private bool validateFiles = false;
        private bool isLaunch = false;

        // invokes
        private TreeNode addNode(string nodeKey, string nodeText)
        {
            if (this.repoTreeView.InvokeRequired)
            {
                return (TreeNode)this.repoTreeView.Invoke( new Func<TreeNode>( () => addNode(nodeKey, nodeText) ) );
            }
            else
            {
                return this.repoTreeView.Nodes.Add(nodeKey, nodeText);
            }
        }

        private TreeNode addNodeLast(TreeNode lastNode, string nodeKey, string nodeText)
        {
            if (this.repoTreeView.InvokeRequired)
            {
                return (TreeNode)this.repoTreeView.Invoke(new Func<TreeNode>(() => addNodeLast(lastNode, nodeKey, nodeText)));
            }
            else
            {
                return lastNode.Nodes.Add(nodeKey, nodeText);
            }
        }

        private void treeViewSort()
        {
            if (this.repoTreeView.InvokeRequired)
            {
                this.repoTreeView.Invoke(new MethodInvoker(delegate {
                    this.repoTreeView.Sort();
                }));
            }
            else
            {
                this.repoTreeView.Sort();
            }
        }

        private void nodeImageIndex(TreeNode nodeKey, int imgIndex)
        {
            if (this.repoTreeView.InvokeRequired)
            {
                this.repoTreeView.Invoke(new MethodInvoker(delegate {
                    nodeKey.ImageIndex = imgIndex;
                    nodeKey.SelectedImageIndex = imgIndex;
                }));
            }
            else
            {
                nodeKey.ImageIndex = imgIndex;
                nodeKey.SelectedImageIndex = imgIndex;
            }
        }

        private void disablePackBlockBtn(PackBlock control)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(delegate { control.disablePlayButton(); }));
            }
            else
            {
                control.disablePlayButton();
            }
        }

        private void updateFilesLabel(Label control, string text)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new MethodInvoker(delegate { control.Text = text; }));
            }
            else
            {
                control.Text = text;
            }
        }

        private async Task taskDelay(int delayMs)
        {
            await Task.Delay(delayMs);
        }

        // ONLY TO ACCESS THE CALCULATE FILE HASH!
        public RepoReader()
        { }

        public RepoReader(MainForm2 mainForm, DoubleBufferFlowPanel flowpanelAddonPacks, TreeView repoTreeView, Downloader downloader, Installer installer, Label lbl_filesOK, Label lbl_filesINVALID, Label lbl_filesMISSING)
        {
            this.mainForm = mainForm;
            this.flowpanelAddonPacks = flowpanelAddonPacks;
            this.repoTreeView = repoTreeView;
            this.downloader = downloader;
            this.installer = installer;
            
            this.lbl_filesOK = lbl_filesOK;
            this.lbl_filesINVALID = lbl_filesINVALID;
            this.lbl_filesMISSING = lbl_filesMISSING;

            // define validation worker
            this.validateRepo.DoWork += ValidateRepo_DoWork;
            this.validateRepo.RunWorkerCompleted += ValidateRepo_RunWorkerCompleted;
            this.validateRepo.WorkerSupportsCancellation = true;
        }

        public async void ReadRepo(bool showMessage, bool autoDownload, bool validateFiles, bool isLaunch)
        {
            if (validateFiles)
                mainForm.showSnackBar("Validating repository...", 2000, false);

            while (GlobalVar.isReadingRepo)
                await taskDelay(100);

            if (GlobalVar.isDownloading || GlobalVar.isInstalling || GlobalVar.offlineMode)
                return;

            if (Properties.Settings.Default.AddonsFolder == string.Empty)
            {
                this.repoTreeView.Nodes.Clear();
                this.repoTreeView.Nodes.Add("ERROR", "No addons folder selected!", 5, 5);
                this.mainForm.showSnackBar("No addons folder selected!", 2000, true, true, MaterialSkin.Primary.Red800);

                this.lbl_filesOK.Text = "N/A";
                this.lbl_filesINVALID.Text = "N/A";
                this.lbl_filesMISSING.Text = "N/A";

                GlobalVar.isReadingRepo = false;
                return;
            }

            this.repoTreeView.Nodes.Clear();
            this.modsHash.Clear();
            this.modsEdit.Clear();
            this.modsList.Clear();

            this.filesOK = 0;
            this.filesINVALID = 0;
            this.filesMISSING = 0;

            // update file status
            this.lbl_filesOK.Text = filesOK.ToString();
            this.lbl_filesINVALID.Text = filesINVALID.ToString();
            this.lbl_filesMISSING.Text = filesMISSING.ToString();

            this.AddonsFolder = Properties.Settings.Default.AddonsFolder;

            this.showMessage = showMessage;
            this.autoDownload = autoDownload;
            this.validateFiles = validateFiles;
            this.isLaunch = isLaunch;

            GlobalVar.folders2Create.Clear();
            GlobalVar.files2Download.Clear();

            this.needsUpdate = UpdateType.None;

            this.validateRepo.RunWorkerAsync();

            GlobalVar.repoChecked = false;
            GlobalVar.isReadingRepo = true;
        }

        private void ValidateRepo_DoWork(object sender, DoWorkEventArgs e)
        {
            this.repoFile = GetRepoFile();

            // checks if repofile is different from last time and needs force validation
            if (IsRepoDifferent(repoFile) && Properties.Settings.Default.ServerPack != "arma3") { this.needsUpdate = UpdateType.Validation; validateFiles = true; }
            if (autoDownload && Properties.Settings.Default.ServerPack != "arma3") { validateFiles = true; }

            if (validateFiles)
            {
                foreach (PackBlock item in flowpanelAddonPacks.Controls)
                {
                    disablePackBlockBtn(item);
                }
            }

            using (StreamReader sr = File.OpenText(repoFile))
            {
                string s = string.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    modsHash.Add(s.Split('*')[0]);
                    modsEdit.Add(s.Split('*')[1]);
                    modsList.Add(s.Split('*')[2]);
                }

                repoTreeView.PathSeparator = "\\";
                PopulateTreeView(repoTreeView, modsList, modsHash, '\\', modsEdit, validateFiles);
                treeViewSort();
            }

            if (Directory.Exists(TempFolder))
                Directory.Delete(TempFolder, true);
            
        }

        private void ValidateRepo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            GlobalVar.isReadingRepo = false;

            if (e.Cancelled)
                return;

            if (needsUpdate == UpdateType.None)
            {
                foreach (PackBlock item in flowpanelAddonPacks.Controls)
                {
                    item.enablePlayButton();
                }

                GlobalVar.repoChecked = true;

                if (showMessage)
                    new Windows.MessageBox().Show("All files are synced with the repository!", "You're amazing", MessageBoxButtons.OK, MessageIcon.Information);
                else if (validateFiles && !isLaunch)
                    mainForm.showSnackBar("Finished repository validation", 2000, false);
            }
            else
            {
                if (needsUpdate == UpdateType.Download)
                {
                    if (!showMessage)
                        mainForm.showSnackBar("Repository needs update!", 2000, false);

                    foreach (PackBlock item in flowpanelAddonPacks.Controls)
                    {
                        item.disablePlayButton();
                    }

                    if (GlobalVar.menuSelected != 2)
                    {
                        GlobalVar.menuSelected = 2;
                        this.mainForm.HideUnhide(GlobalVar.menuSelected);
                    }

                    if (GlobalVar.autoPilot || autoDownload || (showMessage && new Windows.MessageBox().Show("Your local files are not in sync with the repository.\nDo you want to download the missing files?", "Repository has new updates", MessageBoxButtons.YesNo, MessageIcon.Question) == DialogResult.Yes))
                        downloader.beginDownload(GlobalVar.files2Download, GlobalVar.autoPilot);
                }
                else if (needsUpdate == UpdateType.Validation)
                {
                    mainForm.showSnackBar("Validating local storage...", 2000, false);

                    foreach (PackBlock item in flowpanelAddonPacks.Controls)
                    {
                        item.disablePlayButton();
                    }

                    if (GlobalVar.menuSelected != 2)
                    {
                        GlobalVar.menuSelected = 2;
                        this.mainForm.HideUnhide(GlobalVar.menuSelected);
                    }

                    installer.ValidateLocalFiles();
                }
            }
        }

        public bool IsRepoDifferent(string repoFile)
        {
            if (this.CalculateFileHash(repoFile) != Properties.Settings.Default.LastRepoFileHash)
                return true;
            else
                return false;
        }

        public string GetRepoFile()
        {
            WebClient request = new WebClient();

            string url = Properties.GlobalValues.S_RepoList;
            string tempFile = TempFolder + "repoList.a3l";

            request.Credentials = new NetworkCredential("anonymous", "anonymous@example.com");

            try
            {
                if (!Directory.Exists(TempFolder)) { Directory.CreateDirectory(TempFolder); }
                else if (File.Exists(tempFile)) { File.Delete(tempFile); }
                request.DownloadFile(new Uri(url), tempFile);
            }
            catch (WebException e)
            {
                new Windows.MessageBox().Show(e.Message, "Unable to get repository info");
            }

            return tempFile;
        }

        public string CalculateFileHash(string filename)
        {
            //TODO: Implement MD5 hash system
            // - local catalog compares with remote catalog
            // - build catalog during file download
            // - compute hash during file download
            // - file validation compares hash with remote catalog

            /*
            {
                using(var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var hash = crypt.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", String.Empty).ToLowerInvariant();
                }
            }*/

            var fInfo = new FileInfo(filename);
            return Convert.ToString(fInfo.Length);
        }

        private void PopulateTreeView(TreeView treeView, IEnumerable<string> paths, List<string> fHash, char pathSeparator, List<string> fEdit, bool validateFiles)
        {
            TreeNode lastNode = null;
            string subPathAgg;
            string fileHash = String.Empty;
            long fileEdit = 0;
            int a = 0;
            int i;
            foreach (string path in paths)
            {
                fileHash = fHash[a];
                fileEdit = Convert.ToInt64(fEdit[a]);
                subPathAgg = string.Empty;
                i = 0;
                foreach (string subPath in path.Split(pathSeparator))
                {
                    if (i < path.Split(pathSeparator).Length - 1)
                        subPathAgg += subPath + pathSeparator;
                    else
                        subPathAgg += subPath;

                    TreeNode[] nodes = treeView.Nodes.Find(subPathAgg, true);
                    if (nodes.Length == 0)
                        if (lastNode == null)
                            lastNode = addNode(subPathAgg, subPath);
                        else
                            lastNode = addNodeLast(lastNode, subPathAgg, subPath);
                    else
                        lastNode = nodes[0];

                    if (subPathAgg.EndsWith("\\"))
                    { if (validateFiles) { ValidateFolder(subPath, subPathAgg, lastNode); } else { this.nodeImageIndex(lastNode, 3); } }
                    else
                    { if (validateFiles) { ValidateFile(subPath, subPathAgg, lastNode, fileHash, fileEdit); } else { this.nodeImageIndex(lastNode, 0); updateFilesLabel(lbl_filesOK, Convert.ToString(this.filesOK++)); } }

                    i++;
                }
                lastNode = null;
                a++;
            }
        }

        private void ValidateFile(string remoteFile, string fullPath, TreeNode node, string remoteFileHash, long fileEdit)
        {
            bool invalidFile = false;

            if (File.Exists(AddonsFolder + fullPath))
            {
                string item = AddonsFolder + fullPath;
                string localfileHash = CalculateFileHash(item);
                long localfileEdit =  Convert.ToInt64(string.Format("{2:0000}{1:00}{0:00}{3:00}{4:00}{5:00}", File.GetLastWriteTime(item).Day, File.GetLastWriteTime(item).Month, File.GetLastWriteTime(item).Year, File.GetLastWriteTime(item).Hour, File.GetLastWriteTime(item).Minute, File.GetLastWriteTime(item).Second));

                if (localfileHash == remoteFileHash && localfileEdit > fileEdit)
                {
                    this.nodeImageIndex(node, 0);
                    this.filesOK++;
                    updateFilesLabel(lbl_filesOK, Convert.ToString(this.filesOK));
                }
                else
                {
                    this.nodeImageIndex(node, 1);
                    invalidFile = true;
                    this.filesINVALID++;
                    updateFilesLabel(lbl_filesINVALID, Convert.ToString(this.filesINVALID));
                }
            }
            else
            {
                this.nodeImageIndex(node, 2);
                invalidFile = true;
                this.filesMISSING++;
                updateFilesLabel(lbl_filesMISSING, Convert.ToString(this.filesMISSING));
            }

            if(invalidFile)
            {
                GlobalVar.files2Download.Add(fullPath);
                this.needsUpdate = UpdateType.Download;

                TreeNode auxNode = node;
                while (auxNode.Parent != null)
                {
                    this.nodeImageIndex(auxNode.Parent, 4);
                    auxNode = auxNode.Parent;
                }
            }

        }

        private void ValidateFolder(string remoteFolder, string fullPath, TreeNode node)
        {
            bool invalidFolder = false;

            if (Directory.Exists(AddonsFolder + fullPath))
            {
                if (node.ImageIndex != 4)
                {
                    this.nodeImageIndex(node, 3);
                }
            }
            else
            {
                this.nodeImageIndex(node, 5);
                invalidFolder = true;
            }

            if (invalidFolder)
            {
                GlobalVar.folders2Create.Add(fullPath);
                this.needsUpdate = UpdateType.Download;

                TreeNode auxNode = node;
                while (auxNode.Parent != null)
                {
                    this.nodeImageIndex(auxNode.Parent, 4);
                    auxNode = auxNode.Parent;
                }
            }
        }
    }
}
