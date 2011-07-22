using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using eXLauncher;
using eXLauncher.XML;

namespace eXLauncher.Includes
{
    public static class Config
    {
        /// <summary>
        /// Contains all possible realmlist options.
        /// Key: Name
        /// Value.Key: Realmlist
        /// Value.Value: Client
        /// </summary>
        public static Dictionary<String, KeyValuePair<String, String>> realmOptions;

        /// <summary>
        /// Contains all WoW directories. (One per Client)
        /// Key: Client
        /// Value.Key: Locale
        /// Value.Value: Location
        /// </summary>
        public static Dictionary<String, KeyValuePair<String, String>> wowDirectories;
    }

    /// <summary>
    /// Control all config values
    /// </summary>
    public class ConfigController
    {
        private Form _masterForm;
        private XMLController loader;
        public ConfigController(Master form)
        {
            _masterForm = form;
        }

        /// <summary>
        /// Load all values from the config.
        /// </summary>
        public void LoadAllValues()
        {
            loader = new XMLController(_masterForm);
            loader.LoadFromConfig();
            Config.realmOptions = loader.realmOptions;
            Config.wowDirectories = loader.wowDirectories;
        }

        /// <summary>
        /// Make sure all WoW locations are valid, and if none exist, force the user to add one.
        /// </summary>
        public void ValidateWoWLocation()
        {
            bool forceAdd = false;
            try
            {
                try { Config.wowDirectories.Remove("0.0.0"); }
                catch (Exception) { }
                foreach (KeyValuePair<String, KeyValuePair<String, String>> kvp in Config.wowDirectories)
                {
                    if (kvp.Value.Key.Substring(0, 2) != "en")
                        throw new Exception(String.Format("WoW Client ID: {0} has invalid locale {1}, Please fix it before starting the launcher again1", kvp.Key, kvp.Value.Key));

                    if (!File.Exists(String.Format("{0}/{1}/realmlist.wtf", kvp.Value.Value.Substring(0, kvp.Value.Value.Length - 8), kvp.Value.Key)))
                        throw new Exception(String.Format("WoW Client ID: {0} has invalid WoW.exe file directory. The realmlist file could not be found!", kvp.Key));
                }

                if (Config.wowDirectories.Count < 1)
                {
                    forceAdd = true;
                    throw new Exception("You must have at least one WoW directory! Please add one now!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                if (forceAdd)
                    AddWoWLocation();
            }
        }

        public void AddWoWLocation()
        {

        }
    }
}
