using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace launcher
{
    public partial class AddWoWFolder : Form
    {
        private ConfigController master;
        public AddWoWFolder(ConfigController form)
        {
            master = form;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "WoW.exe Files (WoW.exe)|WoW.exe";
            dialog.Title = "Browse for WoW.exe File";
            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                box_location.Text = dialog.FileName;
            }
            catch (Exception /*e*/) { }
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            if (!Config.ValidateClient(client.Text))
                return;

            if (!Config.ValidateLocale(locale.Text))
                return;

            master.AddWoWFolder(client.Text, locale.Text, box_location.Text);
            master.ValidateWoWLocation();
            Close();
        }
    }
}
