using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using arma3Launcher.Controls;
using System.Net;
using System.Xml;

namespace arma3Launcher.Workers
{
    class Packs
    {
        private readonly FlowLayoutPanel gflowpacks;
        private string title = "";
        private string id = "";
        private string description = "";
        private string cfgUrl = "";
        private string addons = "";

        public Packs(FlowLayoutPanel PacksPanel)
        {
            gflowpacks = PacksPanel;
        }

        public void Get ()
        {
            try
            {
                gflowpacks.Controls.Clear();

                XmlDocument RemoteXmlInfo = new XmlDocument();
                RemoteXmlInfo.Load(Properties.GlobalValues.S_VersionXML);

                XmlNodeList xnl = RemoteXmlInfo.SelectNodes("//arma3Launcher//ModSets//pack");
                foreach (XmlNode xn in xnl)
                {
                    title = xn.Attributes["name"].Value;
                    id = xn.Attributes["id"].Value;
                    description = xn.Attributes["description"].Value;
                    cfgUrl = RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + id).Attributes["cfgfile"].Value;
                    addons = "";
                    

                    XmlNodeList xnl2 = RemoteXmlInfo.SelectNodes("//arma3Launcher//ModSetInfo//" + id + "//mod");
                    foreach (XmlNode xn2 in xnl2)
                    {
                        if (xn2.Attributes["type"].Value == "mod")
                        {
                            if (xn2.Attributes["name"].Value != "@dummy")
                            {
                                addons = addons +
                                    " • " + xn2.Attributes["name"].Value + " (" + xn2.Attributes["version"].Value + ")" +
                                    "\n";
                            }
                        }
                    }

                    PackBlock auxPack = new PackBlock(
                        title, 
                        id, 
                        description, 
                        addons, 
                        gflowpacks, 
                        Convert.ToBoolean(RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + id).Attributes["blastcore"].Value), 
                        Convert.ToBoolean(RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + id).Attributes["jsrs"].Value), 
                        Convert.ToBoolean(RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + id).Attributes["optional"].Value));
                    auxPack.Tag = id;

                    if (id == Properties.Settings.Default.lastAddonPack)
                    {
                        PictureBox btnUsePack = auxPack.Controls.Find("btn_useThis", true)[0] as PictureBox;
                        btnUsePack.Enabled = false;
                        btnUsePack.Image = Properties.Resources.useThis_active;
                    }

                    if(Convert.ToBoolean(xn.Attributes["enable"].Value))
                        gflowpacks.Controls.Add(auxPack);
                }

                Label Maring = new Label();
                Maring.MaximumSize = new Size(595, 10);
                gflowpacks.Controls.Add(Maring);
            }
            catch (Exception ex)
            {
                TableLayoutPanel ErrorTable = new TableLayoutPanel();
                ErrorTable.Size = new Size(gflowpacks.Size.Width-10, gflowpacks.Size.Height-15);

                Label ErrorRead = new Label();
                ErrorRead.Anchor = AnchorStyles.None;
                ErrorRead.ForeColor = Color.White;
                ErrorRead.MinimumSize = new Size(595, 170);
                ErrorRead.Font = new Font("Calibri", 9, FontStyle.Bold);
                ErrorRead.TextAlign = ContentAlignment.BottomCenter;
                ErrorRead.Text = "Unable to read the contents from the server!\n" + ex.Message;

                ErrorTable.Controls.Add(ErrorRead);

                gflowpacks.Controls.Add(ErrorTable);
            }
        }
    }
}
