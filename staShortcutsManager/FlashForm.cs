using staShortcutsManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace staShortcutsManager
{
    public partial class FlashForm : Form
    {
        private string bootPath;
        private string bootName;

        public FlashForm()
        {
            InitializeComponent();
            dontReboot.Image = (Image)new Bitmap((Image)Resources.off, new Size(GetProperSize(32), GetProperSize(32)));
        }

        private void butBoot_Click(object sender, EventArgs e)
        {
            if (openIMG.ShowDialog() == DialogResult.OK)
            {
                bootPath = openIMG.FileName;
                bootName = openIMG.SafeFileName;
                tBboot.Text = bootPath;
                butFlash.Enabled = true;
            }
        }

        private void dontReboot_CheckedChanged(object sender, EventArgs e)
        {
            dontReboot.Image = (Image)new Bitmap((Image)(dontReboot.Checked ? Resources.on : Resources.off), new Size(GetProperSize(32), GetProperSize(32)));
        }

        private void butFlash_Click(object sender, EventArgs e)
        {
            try
            {
                string program = Settings.Default.useSdd ? Functions.sddLocation() : Functions.staLocation();
                string processArgs = $"{((dontReboot.Checked) ? "-n" : "")} -p \"{bootPath}\"";
                Process process = new Process();
                process.StartInfo.FileName = program;
                process.StartInfo.Arguments = processArgs;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.LoadUserProfile = true;

                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                using (MessageForm mf = new MessageForm($"An error has occurred:\n{ex}\nPlease try again.", "sta Shortcuts Manager - Error", "Default"))
                {
                    mf.ShowDialog();
                }
            }
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
