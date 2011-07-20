using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using eXLauncher.XML;
using eXLauncher.Includes;

namespace eXLauncher
{
    /// <summary>
    /// Main thread for the master launcher form.
    /// </summary>
    public partial class Master : Form
    {
        /// <summary>
        /// Called at the startup of the application
        /// TODO: Read the themes and properly set the style
        /// </summary>
        public Master()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when the application is loaded
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void Master_Load(object sender, EventArgs e)
        {
            ConfigController controller = new ConfigController(this);
            controller.LoadAllValues();
            controller.ValidateWoWLocation();
        }

        /// <summary>
        /// Called when a player wants to start the WoW Client.
        /// </summary>
        /// <param name="sender">Not Used</param>
        /// <param name="eArgs">Not Used</param>
        private void btnStartWoW_Click(object sender, EventArgs eArgs)
        {
            try
            {
                var realmInfo = Config.realmOptions[(String)chosenRealm.SelectedItem];
                if (!Config.wowDirectories.ContainsKey(realmInfo.Value))
                {
                    throw new Exception(String.Format("You do not have a WoW client for the client {0}! Please add one before choosing this realm!", realmInfo.Value));
                }
                var wowClient = Config.wowDirectories[realmInfo.Value];
                LaunchWoWClient(wowClient, realmInfo.Key);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// Set up the realmlist.wtf file and start WoW.
        /// </summary>
        /// <param name="WoWInfo">Information containing WoW directory and locale.</param>
        /// <param name="realmlist">What the realmlist file should be changed to.</param>
        private void LaunchWoWClient(KeyValuePair<String, String> WoWInfo, String realmlist)
        {
            StreamReader reader = null;
            StreamWriter writer = null;
            try
            {
                var realmlistLocation = String.Format("{0}/{1}/realmlist.wtf", WoWInfo.Value.Substring(0, WoWInfo.Value.Length - 8), WoWInfo.Key);
                if (!File.Exists(realmlistLocation))
                    throw new Exception(String.Format("The realmlist file could not be found, please check the WoW directory for the chosen realm client!"));
                reader = new StreamReader(new FileStream(realmlistLocation, FileMode.Open, FileAccess.Read));
                writer = new StreamWriter(new FileStream(String.Format("{0}.new", realmlistLocation), FileMode.Create));
                writer.WriteLine(String.Format("set realmlist {0}", realmlist));
                String line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("set realmlist"))
                    {
                        if (line.Contains(String.Format("set realmlist {0}", realmlist)))
                            StartWoWProcess(WoWInfo.Value);
                    }
                }
                reader.Close();
                writer.Close();
                File.Delete(realmlistLocation);
                File.Move(String.Format("{0}.new", realmlistLocation), realmlistLocation);
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.ToString());
            }
        }

        /// <summary>
        /// Start the WoW client and close the launcher.
        /// </summary>
        /// <param name="filename">Location of WoW client to execute.</param>
        private void StartWoWProcess(String filename)
        {
            Process.Start(filename);
            Environment.Exit(0);
        }
    }
}
