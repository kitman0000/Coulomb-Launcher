using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SWAT4启动器
{
    public partial class DownloadButton : UserControl
    {
        public EventHandler mouse;
        public DownloadButton()
        {
            InitializeComponent();

        }

        private void TextLabel_Click(object sender, EventArgs e)
        {
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("c2");
        }

        private void DownloadButton_Load(object sender, EventArgs e)
        {
            this.TextLabel.Click += mouse;
        }
        /// <summary>
        /// 设置进度条位置
        /// </summary>
        /// <param name="percentage">百分比，必须小于等于100</param>
        public void setProgress(int percentAge)
        {
            if (percentAge > 100)
                this.Progress.Width = Width;
            this.Progress.Width = (int)(this.Width * ((float)percentAge/100));
            Console.WriteLine("长度" + this.Width * ((float)percentAge / 100));
        }

        private void TextLabel_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(0, 150, 0);
        }

        private void TextLabel_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(0, 99, 0);
        }

        private void TextLabel_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("c1");
            DownloadButton_Click(sender, e);
        }

        private void TextLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BackColor = Color.FromArgb(0, 80, 0);
            }
        }

        private void TextLabel_MouseUp(object sender, MouseEventArgs e)
        {
            BackColor = Color.FromArgb(0, 120, 0);
        }
    }
}
