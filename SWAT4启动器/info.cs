using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SWAT4启动器
{
    public partial class info : Form
    {
        public info(string gamename)
        {
            InitializeComponent();
            label2.Text = gamename;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
