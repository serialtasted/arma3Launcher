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
        private MainForm mainForm;
        private readonly FlowLayoutPanel gflowpacks;
        private string title = string.Empty;
        private string id = string.Empty;
        private string description = string.Empty;
        private string addons = string.Empty;

        public Packs(MainForm mainForm, FlowLayoutPanel packsPanel)
        {
            this.mainForm = mainForm;
            this.gflowpacks = packsPanel;
        }

        public void Search (string searchArgument)
        {
            for (int i = 0; i < gflowpacks.Controls.Count-1; i++)
            {
                if (!gflowpacks.Controls[i].Tag.ToString().Contains(searchArgument) && searchArgument != string.Empty)
                    gflowpacks.Controls[i].Visible = false;
                else
                    gflowpacks.Controls[i].Visible = true;
            }
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
                    if (Convert.ToBoolean(xn.Attributes["enable"].Value) && (Convert.ToBoolean(xn.Attributes["public"].Value) || Properties.Settings.Default.privateKeys.Split(',').Contains(xn.Attributes["id"].Value)))
                    {
                        title = xn.Attributes["name"].Value;
                        id = xn.Attributes["id"].Value;
                        description = xn.Attributes["description"].Value;
                        addons = string.Empty;


                        XmlNodeList xnl2 = RemoteXmlInfo.SelectNodes("//arma3Launcher//ModSetInfo//" + id + "//mod");
                        foreach (XmlNode xn2 in xnl2)
                        {
                            if (xn2.Attributes["name"].Value != "@dummy")
                            {
                                addons = addons +
                                    " • " + xn2.Attributes["name"].Value +
                                    "\n";
                            }
                        }

                        PackBlock auxPack = new PackBlock(
                            mainForm,
                            title,
                            id,
                            description,
                            addons,
                            gflowpacks,
                            Convert.ToBoolean(RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + id).Attributes["optional"].Value));
                        auxPack.Tag = string.Format("{0} {1} {2} {3}", id, title, description, addons);

                        if (id == Properties.Settings.Default.lastAddonPack)
                        {
                            PictureBox btnUsePack = auxPack.Controls.Find("btn_useThis", true)[0] as PictureBox;
                            btnUsePack.Enabled = false;
                            btnUsePack.Image = Properties.Resources.useThis_active;
                            mainForm.updateActivePack(title);
                        }


                        gflowpacks.Controls.Add(auxPack);
                    }
                }

                Label Maring = new Label() { MaximumSize = new Size(595, 10) };
                gflowpacks.Controls.Add(Maring);
            }
            catch (Exception ex)
            {
                TableLayoutPanel ErrorTable = new TableLayoutPanel();
                ErrorTable.Size = new Size(gflowpacks.Size.Width - 10, gflowpacks.Size.Height - 15);

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
