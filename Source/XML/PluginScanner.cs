using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace eXLauncher.XML
{
    public class PluginScanner
    {
        private Master m_masterForm = null;
        public PluginScanner(Master form)
        {
            m_masterForm = form;
        }

        public void Scan()
        {
            String[] files = Directory.GetFiles("./Plugins/", "*.xml");
            foreach (String sFile in files)
            {
                XMLValidator validator = new XMLValidator(sFile, isplugin: true);
                if (validator.ValidateXMLFile())
                {
                    MessageBox.Show(String.Format("Plugin {0} is in an invalid format! Possibly out of date?", sFile));
                    continue;
                }
                XmlTextReader reader = new XmlTextReader(sFile);
                String element = "";
                String name = "", client = "", realmlist = "";
                SArray3 realmOptions = new SArray3();
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            {
                                element = reader.Name;
                                if (String.Compare(element, "Realm") == 0)
                                {
                                    if (realmOptions.ContainsX(name))
                                        continue;
                                    if (name != "" && Config.ValidateClient(client))
                                        realmOptions.Add(name, realmlist, client);
                                    client = "0.0.0";
                                    name = "";
                                    realmlist = "";
                                }
                                break;
                            }
                        case XmlNodeType.Text:
                            {
                                switch (element)
                                {
                                    case "RealmName":
                                        name = reader.Value;
                                        break;
                                    case "RealmList":
                                        realmlist = reader.Value;
                                        break;
                                    case "RealmClient":
                                        client = reader.Value;
                                        break;
                                }
                                break;
                            }
                    }
                }

                if (realmOptions.ContainsX(name))
                    throw new Exception(String.Format("Realm id {0} used more than once!", name));
                if (Config.ValidateClient(client))
                    realmOptions.Add(name, realmlist, client);

                foreach (Vector3<String> vector in realmOptions)
                    Config.realmOptions.Add(vector);

                ListView box = (ListView)m_masterForm.Controls["chosenRealm"];
                foreach (Vector3<String> kvp in realmOptions)
                {
                    ListViewItem itemToAdd = new ListViewItem(kvp.X);
                    itemToAdd.Name = kvp.X;
                    box.Items.Add(itemToAdd);
                }
            }
        }
    }
}
