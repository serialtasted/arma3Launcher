using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using arma3Launcher.Controls;
using MaterialSkin.Controls;

namespace arma3Launcher.Workers
{
    class AddonsLooker
    {
        private DoubleBufferFlowPanel flowpanel_detectedAddons;
        private ListBox lBox_detectedAddons;


        public AddonsLooker(CheckedListBox lBox_detectedAddons)
        {
            this.lBox_detectedAddons = lBox_detectedAddons;
        }

        public AddonsLooker(DoubleBufferFlowPanel flowpanel_detectedAddons)
        {
            this.flowpanel_detectedAddons = flowpanel_detectedAddons;
        }

        public void getAddonsFlowPanel(string folderToLook)
        {
            try
            {
                this.flowpanel_detectedAddons.Controls.Clear();

                DirectoryInfo addonDir = new DirectoryInfo(folderToLook);
                DirectoryInfo[] subDirs = addonDir.GetDirectories();

                foreach (DirectoryInfo dir in addonDir.GetDirectories())
                {
                    if (dir.Name.StartsWith("@"))
                    {
                        MaterialCheckBox addonItem = new MaterialCheckBox();
                        addonItem.Text = dir.Name;
                        addonItem.AutoSize = true;

                        flowpanel_detectedAddons.Controls.Add(addonItem);
                    }
                    else { continue; }
                }
            }
            catch
            { }
        }

        public void getAddonsCheckListBox(string folderToLook)
        {
            try
            {
                lBox_detectedAddons.Items.Clear();

                DirectoryInfo addonDir = new DirectoryInfo(folderToLook);
                DirectoryInfo[] subDirs = addonDir.GetDirectories();

                foreach (DirectoryInfo dir in addonDir.GetDirectories())
                {
                    if (dir.Name.StartsWith("@")) { lBox_detectedAddons.Items.Add(dir.Name); }
                    else { continue; }
                }
            }
            catch
            { }
        }
    }
}
