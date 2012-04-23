using System;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace launcher.XML
{
    /// <summary>
    /// Validates the XML file.
    /// </summary>
    public class XMLValidator
    {
        private string m_ConfigFileName;
        private Stream m_ConfigSchemaStream;
        private XmlSchemaSet m_objXmlSchemaSet;
        private bool m_bIsFailure = false;

        /// <summary>
        /// Set up the XML Validator class
        /// </summary>
        /// <param name="plugin">Name of the Config/Plugin</param>
        /// <param name="isplugin">If the file is a plugin</param>
        /// <param name="iswowfolder">If the file is a WoW Directory Plugin</param>
        public XMLValidator(String plugin, bool isplugin = false, bool iswowfolder = false)
        {
            m_ConfigFileName = plugin;
            if (isplugin)
                m_ConfigSchemaStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("launcher.Includes.Plugin.xsd");
            else if (iswowfolder)
                m_ConfigSchemaStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("launcher.Includes.FolderPlugin.xsd");
            else
                m_ConfigSchemaStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("launcher.Includes.Config.xsd");
            m_objXmlSchemaSet = new XmlSchemaSet();

            m_objXmlSchemaSet.Add(XmlSchema.Read(m_ConfigSchemaStream, new ValidationEventHandler(ValidationFailed)));
        }

        /// <summary>
        /// Validates the XML Config File and ensures it is correct format.
        /// </summary>
        /// <returns>Returns false if the XML File is in correct format and validated.</returns>
        public bool ValidateXMLFile()
        {
            XmlReader objXmlValidatingReader = null;

            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(m_objXmlSchemaSet);
                objXmlValidatingReader = XmlReader.Create(m_ConfigFileName, settings);

                while (objXmlValidatingReader.Read()) ;

                return m_bIsFailure;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception : " + ex.Message);
                return true;
            }
            finally
            {
                objXmlValidatingReader.Close();
            }
        }

        /// <summary>
        /// Called when there was an issue with validating the XML file.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="args">String containing the issue with the XML file.</param>
        private void ValidationFailed(object sender, ValidationEventArgs args)
        {
            m_bIsFailure = true;
            MessageBox.Show("Invalid XML File: " + args.Message);
        }
    }
}
