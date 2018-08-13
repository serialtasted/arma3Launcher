using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arma3Launcher.Workers
{
    class RepoReader
    {
        private TreeView repoTreeView;
        private string TempFolder = Path.GetTempPath() + @"arma3Launcher\";
        private string AddonsFolder = string.Empty;

        private List<string> modsHash = new List<string>();
        private List<string> modsEdit = new List<string>();
        private List<string> modsList = new List<string>();

        private int filesOK;
        private int filesINVALID;
        private int filesMISSING;

        private Label lbl_filesOK;
        private Label lbl_filesINVALID;
        private Label lbl_filesMISSING;

        private string needsUpdate = string.Empty;

        public RepoReader()
        { }

        public RepoReader(TreeView repoTreeView, Label lbl_filesOK, Label lbl_filesINVALID, Label lbl_filesMISSING)
        {
            this.repoTreeView = repoTreeView;
            this.lbl_filesOK = lbl_filesOK;
            this.lbl_filesINVALID = lbl_filesINVALID;
            this.lbl_filesMISSING = lbl_filesMISSING;
        }

        public string ReadRepo()
        {
            string repoFile = GetRepoFile();

            this.repoTreeView.Nodes.Clear();
            this.modsHash.Clear();
            this.modsList.Clear();

            this.filesOK = 0;
            this.filesINVALID = 0;
            this.filesMISSING = 0;
            this.AddonsFolder = Properties.Settings.Default.AddonsFolder;

            GlobalVar.folders2Create.Clear();
            GlobalVar.files2Download.Clear();

            this.needsUpdate = string.Empty;

            using (StreamReader sr = File.OpenText(repoFile))
            {
                string s = string.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    try
                    {
                        modsHash.Add(s.Split('*')[0]);
                        modsEdit.Add(s.Split('*')[1]);
                        modsList.Add(s.Split('*')[2]);
                    }
                    catch // legacy
                    {
                        modsHash.Add(s.Split('*')[0]);
                        modsList.Add(s.Split('*')[1]);
                    }
                }

                repoTreeView.PathSeparator = "\\";
                PopulateTreeView(repoTreeView, modsList, modsHash, '\\', modsEdit);
                repoTreeView.Sort();
            }

            // checks if repofile is different from last time
            if (IsRepoDifferent(repoFile) && this.needsUpdate == string.Empty) { this.needsUpdate = "validation"; }

            if (Directory.Exists(TempFolder))
                Directory.Delete(TempFolder, true);

            // update file status
            this.lbl_filesOK.Text = filesOK.ToString();
            this.lbl_filesINVALID.Text = filesINVALID.ToString();
            this.lbl_filesMISSING.Text = filesMISSING.ToString();

            GlobalVar.isReadingRepo = false;
            return needsUpdate;
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
                MessageBox.Show(e.Message, "Unable to get repository info");
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

        private void PopulateTreeView(TreeView treeView, IEnumerable<string> paths, List<string> fHash, char pathSeparator, List<string> fEdit)
        {
            TreeNode lastNode = null;
            string subPathAgg;
            string fileHash = String.Empty;
            DateTime fileEdit;
            int a = 0;
            int i;
            foreach (string path in paths)
            {
                fileHash = fHash[a];
                fileEdit = DateTime.Parse(fEdit[a]);
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
                            lastNode = treeView.Nodes.Add(subPathAgg, subPath);
                        else
                            lastNode = lastNode.Nodes.Add(subPathAgg, subPath);
                    else
                        lastNode = nodes[0];

                    if (subPathAgg.EndsWith("\\"))
                        ValidateFolder(subPath, subPathAgg, lastNode);
                    else
                        ValidateFile(subPath, subPathAgg, lastNode, fileHash, fileEdit);

                    i++;
                }
                lastNode = null;
                a++;
            }
        }

        private void ValidateFile(string remoteFile, string fullPath, TreeNode node, string remoteFileHash, DateTime fileEdit)
        {
            bool invalidFile = false;

            if (File.Exists(AddonsFolder + fullPath))
            {
                string localfileHash = CalculateFileHash(AddonsFolder + fullPath);
                DateTime localfileEdit =  File.GetLastWriteTime(AddonsFolder + fullPath);

                if (localfileHash == remoteFileHash && localfileEdit > fileEdit)
                {
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    this.filesOK++;
                }
                else
                {
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                    invalidFile = true;
                    this.filesINVALID++;
                }
            }
            else
            {
                node.ImageIndex = 2;
                node.SelectedImageIndex = 2;
                invalidFile = true;
                this.filesMISSING++;
            }

            if(invalidFile)
            {
                GlobalVar.files2Download.Add(fullPath);
                this.needsUpdate = "download";

                TreeNode auxNode = node;
                while (auxNode.Parent != null)
                {
                    auxNode.Parent.ImageIndex = 4;
                    auxNode.Parent.SelectedImageIndex = 4;
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
                    node.ImageIndex = 3;
                    node.SelectedImageIndex = 3;
                }
            }
            else
            {
                node.ImageIndex = 5;
                node.SelectedImageIndex = 5;
                invalidFolder = true;
            }

            if (invalidFolder)
            {
                GlobalVar.folders2Create.Add(fullPath);
                this.needsUpdate = "download";

                TreeNode auxNode = node;
                while (auxNode.Parent != null)
                {
                    auxNode.Parent.ImageIndex = 4;
                    auxNode.Parent.SelectedImageIndex = 4;
                    auxNode = auxNode.Parent;
                }
            }
        }
    }
}
