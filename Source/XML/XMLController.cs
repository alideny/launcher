using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

using eXLauncher;
using eXLauncher.Includes;

namespace eXLauncher.XML
{
    /// <summary>
    /// Handles all communications between the program and XML files.
    /// </summary>
    public class XMLController
    {
        /// <summary>
        /// Contains all possible realmlist options.
        ///                Name   Realmlist
        /// </summary>
        public  Dictionary<String, String> realmOptions = new Dictionary<String, String>();

        /// <summary>
        /// Contains all WoW directories. (One per Client)
        ///                Client               Locale   Location
        /// </summary>
        public  Dictionary<String, KeyValuePair<String,  String>> wowDirectories = new Dictionary<String, KeyValuePair<String, String>>();

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
                                if (realmOptions.ContainsKey(name))
                                    throw new Exception(String.Format("Realm id {0} used more than once!", name));
                                if (name != "")
                                    realmOptions.Add(name, realmlist);
                                name = "";
                                realmlist = "";
                            }
                            if (String.Compare(element, "WoWDirectory") == 0)
                            {
                                if (wowDirectories.ContainsKey(client))
                                    throw new Exception(String.Format("You cannot have multiple WoW.exe files for the same client {0}!", client));
                                if (client != "0.0.0")
                                    wowDirectories.Add(client, new KeyValuePair<String, String>(locale, fileLocation));
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
                if (realmOptions.ContainsKey(name))
                    throw new Exception(String.Format("Realm id {0} used more than once!", name));
                realmOptions.Add(name, realmlist);

                if (wowDirectories.ContainsKey(client))
                    throw new Exception(String.Format("You cannot have multiple WoW.exe files for the same client {0}!", client));
                wowDirectories.Add(client, new KeyValuePair<String, String>(locale, fileLocation));
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Environment.Exit(1);
            }

            // Realm Options
            ListBox box = (ListBox)m_masterForm.Controls["chosenRealm"];
            foreach (KeyValuePair<String, String> kvp in realmOptions)
                box.Items.Add(kvp.Key);

            box.SelectedItem = defaultRealm;
            // End Realm Options
        }

    }
}
