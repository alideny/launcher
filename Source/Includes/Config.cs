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
        public static string WoWLocation;
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
        }

        public void ValidateWoWLocation()
        {
            // TODO Make sure the file is actually a WoW client.

            // If launcher is in the same directory, no need to search further
            if (File.Exists("./WoW.exe"))
                return;

            if (Config.WoWLocation == "C:/Path/To/WoW.exe")
            {
                ForceNewWoWLocation();
                return;
            }
            if (!Config.WoWLocation.EndsWith(".exe", true, null))
            {
                ForceNewWoWLocation();
                return;
            }

            if (File.Exists(Config.WoWLocation))
                return;

            ForceNewWoWLocation();
        }
        
        public void ForceNewWoWLocation()
        {

        }
    }
}
