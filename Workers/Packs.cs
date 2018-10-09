using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using arma3Launcher.Controls;
using System.Net;
using System.Xml;
using System.Threading.Tasks;
using MetroFramework.Controls;

namespace arma3Launcher.Workers
{
    class Packs
    {
        private MainForm2 mainForm;
        private FlowLayoutPanel packsPanel;
        private MetroComboBox cbServerPacks;

        private string title = string.Empty;
        private string id = string.Empty;
        private string description = string.Empty;
        private string addons = string.Empty;

        private List<string> addonsName = new List<string>();

        public Packs(MainForm2 mainForm, FlowLayoutPanel packsPanel, MetroComboBox cbServerPacks)
        {
            this.mainForm = mainForm;
            this.packsPanel = packsPanel;
            this.cbServerPacks = cbServerPacks;
        }

        public void Search (string searchArgument)
        {
            for (int i = 0; i < packsPanel.Controls.Count-1; i++)
            {
                if (!packsPanel.Controls[i].Tag.ToString().Contains(searchArgument) && searchArgument != string.Empty)
                    packsPanel.Controls[i].Visible = false;
                else
                    packsPanel.Controls[i].Visible = true;
            }
        }

        public void RevealPacks(FlowLayoutPanel addonsPanel)
        {
            foreach (Controls.PackBlock item in addonsPanel.Controls)
            {
                item.fadeIn();
            }
        }

        public async void Get ()
        {
            try
            {
                cbServerPacks.Items.Clear();
                packsPanel.Controls.Clear();

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

                        addonsName.Clear();
                        if (id != "arma3")
                        {
                            XmlNodeList addonsList = RemoteXmlInfo.SelectNodes("//arma3Launcher//ModSetInfo//" + id + "//mod");
                            foreach (XmlNode addon in addonsList)
                            {
                                addonsName.Add(addon.Attributes["name"].Value);
                            }
                        }

                        cbServerPacks.Items.Add(id);

                        PackBlock auxPack = new PackBlock(
                            mainForm,
                            title,
                            id,
                            description,
                            RemoteXmlInfo,
                            packsPanel,
                            Convert.ToBoolean(RemoteXmlInfo.SelectSingleNode("//arma3Launcher//ModSetInfo//" + id).Attributes["optional"].Value),
                            addonsName
                        );
                        auxPack.Tag = string.Format("{0} {1} {2}", id, title, description);
                        Padding margin = auxPack.Margin;
                        margin.Left = 3;
                        margin.Right = 3;
                        margin.Top = 0;
                        margin.Bottom = 8;
                        auxPack.Margin = margin;

                        packsPanel.Controls.Add(auxPack);
                    }
                }
            }
            catch (Exception ex)
            {
                TableLayoutPanel ErrorTable = new TableLayoutPanel();
                ErrorTable.Size = new Size(packsPanel.Size.Width, packsPanel.Size.Height);

                Label ErrorRead = new Label();
                ErrorRead.Anchor = AnchorStyles.None;
                ErrorRead.ForeColor = Color.White;
                ErrorRead.MinimumSize = new Size(400, 50);
                ErrorRead.Font = new Font("Calibri", 9, FontStyle.Bold);
                ErrorRead.TextAlign = ContentAlignment.MiddleCenter;
                ErrorRead.Text = "Unable to read the contents from the server!\n" + ex.Message;

                ErrorTable.Controls.Add(ErrorRead);
                packsPanel.Controls.Add(ErrorTable);
            }
        }
    }
}
