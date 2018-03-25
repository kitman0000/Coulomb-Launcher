using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SWAT4启动器
{

    public partial class ModManager : UserControl
    {
        public string ModID;
        public string ModName
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public ModManager()
        {
            InitializeComponent();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("remove_"+ModID+".bat");
            string mods = INIHelper.Read("launcher", "download", "launcher.ini");
            string del = mods.Replace(ModID + ":" + label1.Text + ";", string.Empty);
            INIHelper.Write("launcher", "download", del, "launcher.ini");
            this.Dispose();
        }
    }
}
