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
        private ListBox lstb_detectedAddons;


        public AddonsLooker(CheckedListBox lBox_detectedAddons)
        {
            this.lstb_detectedAddons = lBox_detectedAddons;
        }

        public void getAddons(string folderToLook)
        {
            try
            {
                lstb_detectedAddons.Items.Clear();

                DirectoryInfo addonDir = new DirectoryInfo(folderToLook);
                DirectoryInfo[] subDirs = addonDir.GetDirectories();

                foreach (DirectoryInfo dir in addonDir.GetDirectories())
                {
                    if (dir.Name.StartsWith("@")) { lstb_detectedAddons.Items.Add(dir.Name); }
                    else { continue; }
                }
            }
            catch
            { }
        }
    }
}
