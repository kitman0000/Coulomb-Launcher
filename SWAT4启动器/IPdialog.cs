using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SWAT4启动器
{
    public partial class IPdialog : Form
    {
        public string IP;
        public IPdialog()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            IP = IPtextBox.Text;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            IP = "none";
            Close();
        }
    }
}
