using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
    }
}
