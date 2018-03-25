using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SWAT4启动器
{
    public partial class ListButton : UserControl
    {
        public bool _DeleteAble = true;
        public bool check = false;
        Form1 _frm1;
        public string _file;
        public ListButton(string name,Form1 frm1,string file,bool DeleteAble)
        {
            InitializeComponent();
            GameName = name;
            this.BackColor = Color.FromArgb(80, 80, 80);
            _frm1 = frm1;
            _file = file;
            _DeleteAble = DeleteAble;
        }
        public string GameName{
            get { return label.Text; }
            set { label.Text = value; }
        }
        private void ListButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.BackColor = Color.FromArgb(40, 40, 40);
                this.check = true;
                foreach (ListButton ctrl in _frm1.flowLayoutPanel1.Controls)
                {
                    if (ctrl != this)
                    {
                        ctrl.check = false;
                        ctrl.BackColor = Color.FromArgb(80, 80, 80);
                    }
                }
            }
            else if(_DeleteAble)
            {
                if (!button1.Visible)
                {
                    button1.Show();
                }
                else
                {
                    button1.Hide();
                }

            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            ListButton_MouseClick(sender, e as MouseEventArgs);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string old = INIHelper.Read("launcher", "mod", "launcher.ini");
            if (old == "on")
            {
                button1.Hide();
                return;
            }
            string delstring = this.label.Text + "%file%" + this._file + "%mod%";
            Console.WriteLine(delstring);
            string newer = old.Replace(delstring, string.Empty);
            Console.WriteLine(newer);
            INIHelper.Write("launcher", "mod", newer, "launcher.ini");
            this.Dispose();
        }
    }
}
