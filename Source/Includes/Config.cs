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
        ///                ID               Name    Realmlist
        /// </summary>
        public static Dictionary<int, KeyValuePair<String, String>> realmOptions;

        /// <summary>
        /// Contains all WoW directories. (One per Client)
        ///                Client               Locale   Location
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

        public void LoadAllValues()
        {
            loader = new XMLController(_masterForm);
            loader.LoadFromConfig();
            Config.realmOptions = loader.realmOptions;
            Config.wowDirectories = loader.wowDirectories;
        }

        public void ValidateWoWLocation()
        {
            // TODO Further check to make sure the location is correct.
            foreach (KeyValuePair<String, KeyValuePair<String, String>> kvp in Config.wowDirectories)
            {
                if (kvp.Key == "0.0.0")
                    Config.wowDirectories.Remove(kvp.Key);
            }
        }
    }
}
