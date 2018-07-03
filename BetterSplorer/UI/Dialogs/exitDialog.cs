using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetterSplorer.UI.Dialogs
{
    public partial class exitDialog : Form
    {
        public exitDialog()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (actionDropdown.SelectedIndex == 0)
            {
                Program.QuitBetterSplorer();
            }
            if (actionDropdown.SelectedIndex == 1)
            {
                Process.Start("logoff.exe");
            }
            if (actionDropdown.SelectedIndex == 2)
            {
                Process.Start("shutdown.exe", "/r /t 0");
            }
            if (actionDropdown.SelectedIndex == 3)
            {
                Process.Start("shutdown.exe", "/s /-t 0");
            }
        }

        private void exitDialog_Load(object sender, EventArgs e)
        {
            actionDropdown.SelectedIndex = 0;
        }
    }
}
