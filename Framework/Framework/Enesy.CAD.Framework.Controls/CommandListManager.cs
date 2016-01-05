using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Enesy.CAD.Framework
{
    public partial class CommandListManager : Dialog
    {
        public CommandListManager()
        {
            InitializeComponent();
        }

        private void CommandListManager_Leave(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
        }
    }
}
