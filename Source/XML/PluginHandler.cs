using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace launcher.XML
{
    public enum PluginType
    {
        Plugin,
        WoWFolder
    }

    public class PluginHandler
    {
        private Master m_masterForm = null;
        public PluginHandler(Master form)
        {
            m_masterForm = form;
        }

        /// <summary>
        /// Scan the Plugins Directory for any plugins, validate them, and add them to the program.
        /// </summary>
        public void ScanPlugins()
        {
            if (!Directory.Exists("./Plugins/"))
                Directory.CreateDirectory("./Plugins/");
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

        /// <summary>
        /// Scan the WoW Folders Directory for any folder plugins, validate them, and add them to the program.
        /// </summary>
        public void ScanDirectories()
        {
            if (!Directory.Exists("./ClientPlugins/"))
                Directory.CreateDirectory("./ClientPlugins/");

            String[] files = Directory.GetFiles("./ClientPlugins/", "*.xml");
            foreach (String file in files)
            {
                XMLValidator validator = new XMLValidator(file, iswowfolder: true);
                if (validator.ValidateXMLFile())
                {
                    MessageBox.Show(String.Format("Plugin {0} is in an invalid format! Possibly out of date?", file));
                    continue;
                }
                XmlTextReader reader = new XmlTextReader(file);
                String element = "";
                String locale = "", client = "", fileLocation = "";
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            {
                                element = reader.Name;
                                if (String.Compare(element, "WoWDirectory") == 0)
                                {
                                    client = "0.0.0";
                                    fileLocation = "";
                                    locale = "";
                                }
                                break;
                            }
                        case XmlNodeType.Text:
                            {
                                switch (element)
                                {
                                    case "Client":
                                        client = reader.Value;
                                        break;
                                    case "FileLocation":
                                        fileLocation = reader.Value;
                                        break;
                                    case "Locale":
                                        locale = reader.Value;
                                        break;
                                }
                                break;
                            }
                    }
                }

                if (Config.wowDirectories.ContainsX(client))
                    throw new Exception(String.Format("You cannot have multiple WoW.exe files for the same client {0}!", client));
                if (Config.ValidateClient(client) && Config.ValidateLocale(locale) && fileLocation != "")
                    Config.wowDirectories.Add(client, locale, fileLocation);
            }
        }

        /// <summary>
        /// Write a new plugin
        /// </summary>
        /// <param name="name">Name of the plugin ({0}.xml)</param>
        /// <param name="type">Type of Plugin</param>
        /// <param name="content">Vector3 containing all necessary information</param>
        /// <returns>True if successful</returns>
        public bool WriteNewPlugin(String name, PluginType type, Vector3<String> content)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "utf-16", "yes"));
            switch (type)
            {
                case PluginType.Plugin:
                    {
                        if (File.Exists(String.Format("./Plugins/{0}.xml", content.X)))
                            return false;
                        document.Add(
                            new XElement("Plugin",
                                new XElement("Realm",
                                    new XElement("RealmName", content.X),
                                    new XElement("RealmList", content.Y),
                                    new XElement("RealmClient", content.Z)
                                )
                            )
                        );
                        document.Save(String.Format("./Plugins/{0}.xml", name));
                        break;
                    }

                case PluginType.WoWFolder:
                    {
                        if (File.Exists(String.Format("./ClientPlugins/{0}.xml", name)))
                            return false;
                        document.Add(
                            new XElement("Folder",
                                new XElement("WoWDirectory",
                                    new XElement("Client", content.X),
                                    new XElement("FileLocation", content.Z),
                                    new XElement("Locale", content.Y)
                                )
                            )
                        );
                        document.Save(String.Format("./ClientPlugins/{0}.xml", name));
                        break;
                    }
            }

            return true;
        }
    }
}
