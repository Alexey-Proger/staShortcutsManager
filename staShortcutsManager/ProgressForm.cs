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
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (progressBar.Value != 100)
                e.Cancel = true;
        }

        public void UpdateProgress(int perc, string task)
        {
            TaskLabel.Text = task;
            progressBar.Value = perc;
        }
    }
}
