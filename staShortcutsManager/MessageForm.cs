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
        private bool YND;
        public MessageForm(string Message, string Title, bool YesNoDialog)
        {
            InitializeComponent();
            YND = YesNoDialog;
            MessageLabel.Text = Message;
            this.Text = Title;
            if (YesNoDialog)
            {
                MessageLabel.Size = new System.Drawing.Size(362, 117);
                Yes.Enabled = true;
                Yes.Visible = true;
                OK.Text = "No";
                Cancel.Enabled = true;
                Cancel.Visible = true;
                this.Size = new System.Drawing.Size(380, 230);
                OK.Location = new System.Drawing.Point(126, 139);
            }
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            Settings.Default.fileAction = 0;
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (YND)
                Settings.Default.fileAction = 1;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Settings.Default.fileAction = 2;
            this.Close();
        }
    }
}
