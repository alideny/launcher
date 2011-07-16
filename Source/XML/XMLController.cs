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
        public  Dictionary<String, String> realmOptions = new Dictionary<String, String>();
        private Form m_masterForm;
        
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
                string name = "";
                string current_name = "";
                while (objXmlTextReader.Read())
                {
                    switch (objXmlTextReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            name = objXmlTextReader.Name;
                            break;
                        case XmlNodeType.Text:
                            switch (name)
                            {
                                case "RealmName":
                                    realmOptions.Add(objXmlTextReader.Value, "");
                                    current_name = objXmlTextReader.Value;
                                    break;
                                case "RealmList":
                                    realmOptions[current_name] = objXmlTextReader.Value;
                                    break;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            ComboBox box = (ComboBox)m_masterForm.Controls["chosenRealm"];
            foreach (KeyValuePair<String, String> kvp in realmOptions)
                box.Items.Add(kvp.Key);
        }

    }
}
