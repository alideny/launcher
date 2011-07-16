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
    public partial class Master : Form
    {
        public Master()
        {
            InitializeComponent();
        }

        private void Master_Load(object sender, EventArgs e)
        {
            ConfigController controller = new ConfigController(this);
            controller.LoadAllValues();
            controller.ValidateWoWLocation();
        }
    }
}
