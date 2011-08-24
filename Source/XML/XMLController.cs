using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

using eXLauncher;

namespace eXLauncher.XML
{
    /// <summary>
    /// Handles all communications between the program and XML files.
    /// </summary>
    public class XMLController
    {
        /// <summary>
        /// Contains all possible realmlist options.
        ///                Name               Realmlist  Client
        /// </summary>
        public  SArray3 realmOptions = new SArray3();

        /// <summary>
        /// Contains all WoW directories. (One per Client)
        ///                Client               Locale   Location
        /// </summary>
        public  SArray3 wowDirectories = new SArray3();

        private Form m_masterForm;
        private String defaultRealm;
        
        /// <summary>
        /// Controls the Config file and makes sure it is in correct format.
        /// </summary>
        /// <param name="masterForm">Master form for accessing controls.</param>
        public XMLController(Form masterForm)
        {
            m_masterForm = masterForm;
            XMLValidator validator = new XMLValidator("Config.xml");
            validator.ValidateXMLFile();
        }

        /// <summary>
        /// Load all values from the config.
        /// </summary>
        public void LoadFromConfig()
        {
            try
            {
                XmlTextReader objXmlTextReader = new XmlTextReader("Config.XML");
                String element = "";
                // Start Variables for Realms
                String name = "", realmlist = "";
                // End Variables for Realms
                // Start Variables for WoWDirectories
                String fileLocation = "", client = "0.0.0", locale = "";
                // End Variables for WoWDirectories
                while (objXmlTextReader.Read())
                {
                    switch (objXmlTextReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            element = objXmlTextReader.Name;
                            if (String.Compare(element, "Realm") == 0)
                            {
                                if (realmOptions.ContainsX(name))
                                    throw new Exception(String.Format("Realm id {0} used more than once!", name));
                                if (name != "" && client != "0.0.0")
                                    realmOptions.Add(name, realmlist, client);
                                client = "0.0.0";
                                name = "";
                                realmlist = "";
                            }
                            if (String.Compare(element, "WoWDirectory") == 0)
                            {
                                if (wowDirectories.ContainsX(client))
                                    throw new Exception(String.Format("You cannot have multiple WoW.exe files for the same client {0}!", client));
                                if (client != "0.0.0" && locale != "" && fileLocation != "")
                                    wowDirectories.Add(client, locale, fileLocation);
                                client = "0.0.0";
                                fileLocation = "";
                                locale = "";
                            }
                            break;
                        case XmlNodeType.Text:
                            switch (element)
                            {
                                // Realms
                                case "RealmName":
                                    name = objXmlTextReader.Value;
                                    break;
                                case "RealmList":
                                    realmlist = objXmlTextReader.Value;
                                    break;
                                case "RealmClient":
                                    client = objXmlTextReader.Value;
                                    break;

                                // Defaults
                                case "RealmDefaultName":
                                    defaultRealm = objXmlTextReader.Value;
                                    break;

                                // WoW Directory
                                case "Client":
                                    client = objXmlTextReader.Value;
                                    break;
                                case "Locale":
                                    locale = objXmlTextReader.Value;
                                    break;
                                case "FileLocation":
                                    fileLocation = objXmlTextReader.Value;
                                    break;
                            }
                            break;
                    }
                }
                if (realmOptions.ContainsX(name))
                    throw new Exception(String.Format("Realm id {0} used more than once!", name));
                if (client != "0.0.0")
                    realmOptions.Add(name, realmlist, client);

                if (wowDirectories.ContainsX(client))
                    throw new Exception(String.Format("You cannot have multiple WoW.exe files for the same client {0}!", client));
                if (client != "0.0.0" && locale != "" && fileLocation != "")
                    wowDirectories.Add(client, locale, fileLocation);
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Environment.Exit(1);
            }

            // Realm Options
            ListView box = (ListView)m_masterForm.Controls["chosenRealm"];
            foreach (Vector3<String> kvp in realmOptions)
            {
                ListViewItem itemToAdd = new ListViewItem(kvp.X);
                itemToAdd.Name = kvp.X;
                box.Items.Add(itemToAdd);
            }

            ListViewItem item = box.Items[defaultRealm];
            if (item != null)
                item.Selected = true;
            box.Select();
            // End Realm Options
        }

    }
}
