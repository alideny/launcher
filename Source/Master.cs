﻿using System;
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

            // Add/Remove Realm Depress State
            button1.MouseDown += new MouseEventHandler((sender, e) =>
            {
                button1.Image = global::eXLauncher.Properties.Resources.addrealm_button_depressed;
            });
            button1.MouseUp += new MouseEventHandler((sender, e) =>
            {
                button1.Image = global::eXLauncher.Properties.Resources.addrealm_button;
            });
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
            PluginScanner scanner = new PluginScanner(this);
            scanner.Scan();
            UpdateRealmSelectionToDefault();
        }

        public void UpdateRealmSelectionToDefault()
        {
            ListViewItem item = chosenRealm.Items[Config.DefaultRealm];
            if (item != null)
                item.Selected = true;
            chosenRealm.Select();
        }

        public void AddToRealmOptions(String name, String realmlist, String clientversion)
        {
            Config.realmOptions.Add(name, realmlist, clientversion);
            ListViewItem item = new ListViewItem(name);
            item.Name = name;
            chosenRealm.Items.Add(item);
            chosenRealm.Items[name].Selected = true;
            // TODO: Add to XML to make changes permanent
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
                var realmInfo = Config.realmOptions[(String)chosenRealm.SelectedItems[0].Text] as Vector3<String>;
                if (realmInfo == null)
                {
                    throw new Exception("realmInfo is null!");
                }

                if (!Config.wowDirectories.ContainsX(realmInfo.Y))
                {
                    throw new Exception(String.Format("You do not have a WoW client for the client {0}! Please add one before choosing this realm!", realmInfo.Y));
                }
                var wowClient = Config.wowDirectories[realmInfo.Y] as Vector3<String>;
                LaunchWoWClient(wowClient, realmInfo.X);
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
        private void LaunchWoWClient(Vector3<String> WoWInfo, String realmlist)
        {
            StreamReader reader = null;
            StreamWriter writer = null;
            try
            {
                var realmlistLocation = String.Format("{0}/{1}/realmlist.wtf", WoWInfo.Y.Substring(0, WoWInfo.Y.Length - 8), WoWInfo.X);
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
                            StartWoWProcess(WoWInfo.Y);
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

        /// <summary>
        /// Add/Remove Realm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            AddRemoveRealm messagebox = new AddRemoveRealm(this);
            messagebox.Show();
        }
    }
}
