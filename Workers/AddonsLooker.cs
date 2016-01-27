using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arma3Launcher.Workers
{
    class AddonsLooker
    {
        private string AddonsFolder;
        private ListBox lstb_detectedAddons;
        private ListBox lstb_activeAddons;
        private ToolStripMenuItem chb_dragonfyre;
        private ToolStripMenuItem chb_blastcore;


        public AddonsLooker(ListBox lBox_detectedAddons, ListBox lBox_activeAddons, ToolStripMenuItem cBox_dragonfyre, ToolStripMenuItem cBox_BlastCore)
        {
            this.lstb_detectedAddons = lBox_detectedAddons;
            this.lstb_activeAddons = lBox_activeAddons;
            this.chb_dragonfyre = cBox_dragonfyre;
            this.chb_blastcore = cBox_BlastCore;
        }

        public void getAddons(bool isDragonFyreAllowed, bool isBlastcoreAllowed, List<string> modsName)
        {
            AddonsFolder = Properties.Settings.Default.AddonsFolder;

            try
            {
                lstb_detectedAddons.Items.Clear();

                DirectoryInfo addonDir = new DirectoryInfo(AddonsFolder);
                DirectoryInfo[] subDirs = addonDir.GetDirectories();

                if (subDirs.Length == 0)
                {
                    chb_dragonfyre.Enabled = false; chb_dragonfyre.Checked = false;
                    chb_blastcore.Enabled = false; chb_blastcore.Checked = false;
                }
                else
                {
                    bool aux_dragonfyreState = chb_dragonfyre.Checked;
                    bool aux_blastcoreState = chb_blastcore.Checked;

                    foreach (DirectoryInfo dir in addonDir.GetDirectories())
                    {
                        if ((dir.Name.ToLower().Contains("jsrs") || (dir.Name.ToLower().Contains("dragonfyre") && !dir.Name.ToLower().Contains("rhs"))) && isDragonFyreAllowed)
                        {
                            chb_dragonfyre.Enabled = true;
                            chb_dragonfyre.Checked = aux_dragonfyreState;
                            break;
                        }
                        else { chb_dragonfyre.Enabled = false; chb_dragonfyre.Checked = false; }
                    }

                    foreach (DirectoryInfo dir in addonDir.GetDirectories())
                    {
                        if (dir.Name.ToLower().Contains("blastcore") && isBlastcoreAllowed)
                        {
                            chb_blastcore.Enabled = true;
                            chb_blastcore.Checked = aux_blastcoreState;
                            break;
                        }
                        else { chb_blastcore.Enabled = false; chb_blastcore.Checked = false; }
                    }

                    foreach (DirectoryInfo dir in addonDir.GetDirectories())
                    {
                        bool aux_isInstalled = false;
                        bool aux_isListed = false;

                        if (dir.Name.StartsWith("@"))
                        {
                            foreach (string m in modsName)
                            {
                                if (dir.Name == m || dir.Name.ToLower().Contains("blastcore") || dir.Name.ToLower().Contains("jsrs") || (dir.Name.ToLower().Contains("dragonfyre") && !dir.Name.ToLower().Contains("rhs"))) { aux_isInstalled = true; break; }
                                else { continue; }
                            }

                            if (!aux_isInstalled)
                            {
                                foreach (string m in lstb_activeAddons.Items)
                                {
                                    if (dir.Name == m) { aux_isListed = true; break; }
                                    else { continue; }
                                }

                                if (!aux_isListed)
                                    lstb_detectedAddons.Items.Add(dir.Name);
                            }
                        }
                        else { continue; }
                    }

                    foreach (string f in lstb_activeAddons.Items)
                    {
                        foreach (string m in modsName)
                        {
                            if (f == m)
                            {
                                lstb_activeAddons.Items.Remove(f);
                                break;
                            }
                        }

                        bool aux_isInstalled = false;

                        foreach (string d in Directory.GetDirectories(AddonsFolder))
                        {
                            if (d.Contains(f))
                            {
                                aux_isInstalled = true;
                                break;
                            }
                            else { continue; }
                        }

                        if (!aux_isInstalled)
                            lstb_activeAddons.Items.Remove(f);
                    }
                }
            }
            catch
            { }
        }
    }
}
