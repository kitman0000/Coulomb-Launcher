using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SWAT4启动器
{
    public partial class Modname : Form
    {
        public string name;
        public Modname()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
                button1.Show();
            else
                button1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            Close();
        }
    }
}
