using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

using eXLauncher;
using eXLauncher.XML;

namespace eXLauncher
{
    public static class Config
    {
        /// <summary>
        /// Contains all possible realmlist options.
        /// Key: Name
        /// Value.Key: Realmlist
        /// Value.Value: Client
        /// </summary>
        public static SArray3 realmOptions;

        /// <summary>
        /// Contains all WoW directories. (One per Client)
        /// Key: Client
        /// Value.Key: Locale
        /// Value.Value: Location
        /// </summary>
        public static SArray3 wowDirectories;

        /// <summary>
        /// Make sure the client string is properly formatted
        /// </summary>
        /// <param name="client">Client version supplied</param>
        /// <returns>True if the client version is correctly formatted. False if 0.0.0 or incorrectly formatted.</returns>
        public static bool ValidateClient(String client)
        {
            if (client.Contains("0.0.0"))
                return false;

            // Number . Number . Number (OPTIONAL LETTER)
            Regex r = new Regex(@"\d{1}.\d{1}.\d{1}(\w{1})?");
            if (!r.IsMatch(client))
                return false;

            return true;
        }

        /// <summary>
        /// Make sure the locale provided is properly formatted.
        /// </summary>
        /// <param name="locale">Locale value supplied</param>
        /// <returns>True if valid locale.</returns>
        public static bool ValidateLocale(String locale)
        {
            if (locale.Length != 4)
                return false;

            Regex r = new Regex(@"en\w{2}");
            String improvedLocale = String.Format("{0}{1}{2}", locale.Substring(0, 2), Char.ToUpper(locale[2]), Char.ToUpper(locale[3]));

            if (!r.IsMatch(improvedLocale))
                return false;

            return true;
        }

        /// <summary>
        /// Default Realm selected in config
        /// </summary>
        public static String DefaultRealm = "";
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
            Config.realmOptions = new SArray3(loader.realmOptions);
            Config.wowDirectories = new SArray3(loader.wowDirectories);
        }

        /// <summary>
        /// Make sure all WoW locations are valid, and if none exist, force the user to add one.
        /// </summary>
        public void ValidateWoWLocation()
        {
            bool forceAdd = false;
            try
            {
                foreach (Vector3<String> kvp in Config.wowDirectories)
                {
                    if (!Config.ValidateLocale(kvp.Y))
                        throw new Exception(String.Format("WoW Client ID: {0} has invalid locale {1}, Please fix it before starting the launcher again1", kvp.X, kvp.Y));

                    if (!File.Exists(String.Format("{0}/{1}/realmlist.wtf", kvp.Z.Substring(0, kvp.Z.Length - 8), kvp.Y)))
                        throw new Exception(String.Format("WoW Client ID: {0} has invalid WoW.exe file directory. The realmlist file could not be found!", kvp.X));
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

        // TODO: Implement loading a messagebox allowing a user to add info.
        public void AddWoWLocation()
        {

        }        
    }
}
