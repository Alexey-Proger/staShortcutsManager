using staShortcutsManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace staShortcutsManager
{
    public partial class MessageForm : Form
    {
        private string DM;
        public MessageForm(string Message, string Title, string DialogMode)
        {
            InitializeComponent();

            DM = DialogMode;
            MessageLabel.Text = Message;
            this.Text = Title;
            this.Height = (GetProperSize(10) + MessageLabel.Height + GetProperSize(110) - GetProperSize(10));
            OK.Location = new Point(GetProperSize(127), (this.Height - GetProperSize(90)));

            switch (DialogMode)
            {
                case ("YesNoCancel"):
                    Yes.Enabled = true;
                    Yes.Visible = true;
                    OK.Text = "No";
                    Cancel.Enabled = true;
                    Cancel.Visible = true;
                    Yes.Location = new Point(GetProperSize(13), (this.Height - GetProperSize(90)));
                    OK.Location = new Point(GetProperSize(127), (this.Height - GetProperSize(90)));
                    Cancel.Location = new Point(GetProperSize(241), (this.Height - GetProperSize(90)));
                    break;
                case ("YesNo"):
                    Yes.Enabled = true;
                    Yes.Visible = true;
                    OK.Text = "No";
                    Yes.Location = new Point(GetProperSize(13), (this.Height - GetProperSize(90)));
                    OK.Location = new Point(GetProperSize(201), (this.Height - GetProperSize(90)));
                    Yes.Width = GetProperSize(150);
                    OK.Width = GetProperSize(150);
                    break;
                case ("AppFolder"):
                    Yes.Enabled = true;
                    Yes.Visible = true;
                    Yes.Text = "Change";
                    OK.Text = "Restore";
                    Cancel.Text = "Cancel";
                    Cancel.Enabled = true;
                    Cancel.Visible = true;
                    Yes.Location = new Point(GetProperSize(13), (this.Height - GetProperSize(90)));
                    OK.Location = new Point(GetProperSize(127), (this.Height - GetProperSize(90)));
                    Cancel.Location = new Point(GetProperSize(241), (this.Height - GetProperSize(90)));
                    if(Settings.Default.appFolder == @"C:\sta\bootfiles")
                        OK.Enabled = false;
                    break;
            }
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            Settings.Default.fileAction = 0;
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (DM != "Default")
                Settings.Default.fileAction = 1;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Settings.Default.fileAction = 2;
            this.Close();
        }

        private int GetProperSize(int size)
        {
            int properIconSize;
            using (Graphics graphics = this.CreateGraphics())
                properIconSize = (int)((double)size * ((double)graphics.DpiX / 96.0));
            return properIconSize;
        }
    }
}
