using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

using eXLauncher;

namespace eXLauncher.XML
{
    public class XMLController
    {
        /// <summary>
        /// Contains all possible realmlist options.
        ///                ID               Name    Realmlist
        /// </summary>
        public  Dictionary<int, KeyValuePair<String,   String>> realmOptions = new Dictionary<int, KeyValuePair<String, String>>();
        private Form m_masterForm;
        private int defaultRealm;
        
        /// <summary>
        /// Controls the Config file.
        /// </summary>
        /// <param name="masterForm">Master form for accessing controls.</param>
        public XMLController(Form masterForm)
        {
            m_masterForm = masterForm;
            XMLValidator validator = new XMLValidator("Config.xml");
            validator.ValidateXMLFile();
        }
        /// <summary>
        /// 
        /// </summary>
        public void LoadRealmOptions()
        {
            try
            {
                XmlTextReader objXmlTextReader = new XmlTextReader("Config.XML");
                string element = "";
                int id = 0;
                string name = "", realmlist = "";
                while (objXmlTextReader.Read())
                {
                    switch (objXmlTextReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            element = objXmlTextReader.Name;
                            if (String.Compare(element, "Realm") == 0)
                            {
                                if (realmOptions.ContainsKey(id))
                                    throw new Exception(String.Format("Realm id {0} used more than once!", id));
                                realmOptions.Add(id, new KeyValuePair<String, String>(name, realmlist));
                                id = 0;
                                name = "";
                                realmlist = "";
                            }
                            break;
                        case XmlNodeType.Text:
                            switch (element)
                            {
                                case "RealmId":
                                    id = Int32.Parse(objXmlTextReader.Value);
                                    break;
                                case "RealmName":
                                    name = objXmlTextReader.Value;
                                    break;
                                case "RealmList":
                                    realmlist = objXmlTextReader.Value;
                                    break;

                                // Defaults
                                case "RealmDefaultId":
                                    defaultRealm = Int32.Parse(objXmlTextReader.Value);
                                    break;
                            }
                            break;
                    }
                }
                if (realmOptions.ContainsKey(id))
                    throw new Exception(String.Format("Realm id {0} used more than once!", id));
                realmOptions.Add(id, new KeyValuePair<String, String>(name, realmlist));
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Environment.Exit(1);
            }
            ListBox box = (ListBox)m_masterForm.Controls["chosenRealm"];
            foreach (KeyValuePair<int, KeyValuePair<String, String>> kvp in realmOptions)
                box.Items.Add(kvp.Value.Key);
            box.Items.RemoveAt(0); // Remove the empty choice.
            box.SelectedItem = realmOptions[defaultRealm].Key;
        }

    }
}
