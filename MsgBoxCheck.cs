using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Calendar
{
    public partial class MsgBoxCheck : Form
    {
        public MsgBoxCheck()
        {
            this.Icon = new Icon(@"files\icon.ico");
            InitializeComponent();
        }

        private void MsgBoxCheck_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawIcon(SystemIcons.Information, 25, 45);
        }
    }
}
