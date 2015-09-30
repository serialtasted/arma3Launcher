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
        private ToolStripMenuItem chb_jsrs;
        private ToolStripMenuItem chb_blastcore;


        public AddonsLooker(ListBox lBox_detectedAddons, ListBox lBox_activeAddons, ToolStripMenuItem cBox_JSRS, ToolStripMenuItem cBox_BlastCore)
        {
            lstb_detectedAddons = lBox_detectedAddons;
            lstb_activeAddons = lBox_activeAddons;
            chb_jsrs = cBox_JSRS;
            chb_blastcore = cBox_BlastCore;
        }

        public void getAddons(bool isJSRSAllowed, bool isBlastcoreAllowed, List<string> modsName)
        {
            AddonsFolder = Properties.Settings.Default.AddonsFolder;

            try
            {
                lstb_detectedAddons.Items.Clear();

                DirectoryInfo addonDir = new DirectoryInfo(AddonsFolder);
                DirectoryInfo[] subDirs = addonDir.GetDirectories();

                if (subDirs.Length == 0)
                {
                    chb_jsrs.Tag = ""; chb_jsrs.Enabled = false; chb_jsrs.Checked = false;
                    chb_blastcore.Tag = ""; chb_blastcore.Enabled = false; chb_blastcore.Checked = false;
                }
                else
                {
                    bool aux_jsrsState = chb_jsrs.Checked;
                    bool aux_blastcoreState = chb_blastcore.Checked;

                    foreach (DirectoryInfo dir in addonDir.GetDirectories())
                    {
                        if ((dir.Name.ToLower().Contains("jsrs") || dir.Name.ToLower().Contains("dragonfyre")) && isJSRSAllowed)
                        {
                            chb_jsrs.Enabled = true;
                            chb_jsrs.Checked = aux_jsrsState;
                            chb_jsrs.Tag = Path.GetFileName(dir.Name);
                            break;
                        }
                        else { chb_jsrs.Tag = ""; chb_jsrs.Enabled = false; chb_jsrs.Checked = false; }
                    }

                    foreach (DirectoryInfo dir in addonDir.GetDirectories())
                    {
                        if (dir.Name.ToLower().Contains("blastcore") && isBlastcoreAllowed)
                        {
                            chb_blastcore.Enabled = true;
                            chb_blastcore.Checked = aux_blastcoreState;
                            chb_blastcore.Tag = Path.GetFileName(dir.Name);
                            break;
                        }
                        else { chb_blastcore.Tag = ""; chb_blastcore.Enabled = false; chb_blastcore.Checked = false; }
                    }

                    foreach (DirectoryInfo dir in addonDir.GetDirectories())
                    {
                        bool aux_isInstalled = false;
                        bool aux_isListed = false;

                        if (dir.Name.StartsWith("@"))
                        {
                            foreach (string m in modsName)
                            {
                                if (dir.Name == m || dir.Name.ToLower().Contains("blastcore") || dir.Name.ToLower().Contains("jsrs") || dir.Name.ToLower().Contains("dragonfyre")) { aux_isInstalled = true; break; }
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
