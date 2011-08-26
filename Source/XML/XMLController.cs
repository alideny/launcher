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

                while (objXmlTextReader.Read())
                {
                    switch (objXmlTextReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            element = objXmlTextReader.Name;
                            break;
                        case XmlNodeType.Text:
                            switch (element)
                            {
                                // Defaults
                                case "RealmDefaultName":
                                    defaultRealm = objXmlTextReader.Value;
                                    break;
                            }
                            break;
                    }
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Environment.Exit(1);
            }

            Config.DefaultRealm = defaultRealm;
        }

    }
}
