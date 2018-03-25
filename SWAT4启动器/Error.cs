using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SWAT4启动器
{
    public partial class Error : CCWin.CCSkinMain
    {
        public Error(string ErrorMsg)
        {
            InitializeComponent();
            ErrorMsgrichTextBox.Text = ErrorMsg;
        }
    }
}
