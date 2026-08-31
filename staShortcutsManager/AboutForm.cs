using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using staShortcutsManager.Properties;

namespace staShortcutsManager
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            int properIconSize;
            using (Graphics graphics = this.CreateGraphics())
                properIconSize = (int)((double)64.0d * ((double)graphics.DpiX / 96.0));

            InitializeComponent();

            pictureBox1.Image = (Image)new Bitmap((Image) Resources.icon.ToBitmap(), new Size(properIconSize, properIconSize));
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkAlexey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://t.me/AlexeyProger");
        }
    }
}
