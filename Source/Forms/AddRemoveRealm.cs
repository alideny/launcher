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
    public partial class AddRemoveRealm : Form
    {
        private Master master;
        public AddRemoveRealm(Master form)
        {
            master = form;
            InitializeComponent();
            // Only need to override one because they are both linked
            addrealm.CheckedChanged += new EventHandler(addrealm_CheckedChanged);
        }

        void addrealm_CheckedChanged(object sender, EventArgs e)
        {
            if (!addrealm.Checked)
            {
                addrealm_panel.Visible = false;
                addremovebutton.Text = "Remove Realm";
            }
            else
            {
                addrealm_panel.Visible = true;
                addremovebutton.Text = "Add Realm";
            }
        }

        private void addremovebutton_Click(object sender, EventArgs e)
        {
            if (addrealm.Checked)
            {
                if (Config.ValidateClient(clientversion.Text))
                    master.AddToRealmOptions(name_textbox.Text, realmlist_textbox.Text, clientversion.Text);
            }
            else
            {
                // TODO: Implement Remove into design.
            }
            this.Close();
        }
    }
}
