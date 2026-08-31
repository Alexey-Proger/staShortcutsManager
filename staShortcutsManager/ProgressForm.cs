using staShortcutsManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace staShortcutsManager
{
    public partial class ProgressForm : Form
    {
        public ProgressForm(string progressMode)
        {
            InitializeComponent();

            switch (progressMode)
            {
                case ("Default"):
                    Cancel.Visible = false;
                    Cancel.Enabled = false;
                    progressBar.Size = new Size(GetProperSize(330), GetProperSize(16));
                    break;
            }

            this.Size = new Size(GetProperSize(366), GetProperSize(110));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (progressBar.Value != 100 && !Cancel.Visible)
                e.Cancel = true;
        }

        public void UpdateProgress(int perc, string task)
        {
            TaskLabel.Text = task;
            progressBar.Value = perc;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Settings.Default.fileAction = 0;
            MessageForm mf = new MessageForm("Do you really want to cancel recovery downloading?", "sta Shortcuts Manager", "YesNo");
            mf.ShowDialog(this);
            if (Settings.Default.fileAction == 0)
            {
                NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "RecoveryPipe", PipeDirection.In);
                pipeClient.Connect();
            }
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
