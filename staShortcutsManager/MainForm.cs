using IWshRuntimeLibrary;
using staShortcutsManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace staShortcutsManager
{
    public partial class MainForm : Form
    {
        #region Main

        private string twrpPath = @"C:\bootfiles\twrp.img";
        private string icoPath = @"C:\bootfiles\twrp.ico";
        private string folderPath = @"C:\bootfiles\";

        public MainForm()
        {
            if (Functions.staCheck() == "nf" && Functions.InternetAvailability())
            {
                DialogResult result = MessageBox.Show("sta not detected.\nDo you want to download it?", "sta Shortcuts Manager - Error", MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Functions.staUpdate();
                        using (MessageForm mf = new MessageForm("sta downloaded successfully.", "sta Shortcuts Manager", false))
                        {
                            mf.ShowDialog();
                        }
                    }
                    catch(Exception ex)
                    {
                        using (MessageForm mf = new MessageForm($"An error has occurred: \n{ex}", "sta Shortcuts Manager - Error", false))
                        {
                            mf.ShowDialog();
                        }
                    }
                }
                else
                    Environment.Exit(0);
            }
            else if (Functions.staCheck() == "nf" && !Functions.InternetAvailability())
            {
                using (MessageForm mf = new MessageForm("sta not detected.\nDownload it manually or connect to Internet and try again.", "sta Shortcuts Manager - Error", false))
                {
                    mf.ShowDialog();
                }
                Environment.Exit(0);
            }

            InitializeComponent();
        }

        #endregion

        #region Buttons logic

        private void android_Click(object sender, EventArgs e)
        {
            Functions.CreateShortcut(@"C:\boot.img", "Android", false, "");
        }

        private async void twrp_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(twrpPath) || !System.IO.File.Exists(icoPath))
            {
                this.Enabled = false;
                await twrpTask();
                this.Enabled = true;
                this.Focus();
            }
            else
                Functions.CreateShortcut(twrpPath, "TWRP", true, icoPath);
        }

        private void custom_Click(object sender, EventArgs e)
        {
            CustomShortcutForm csf = new CustomShortcutForm();
            this.Enabled = false;
            csf.ShowDialog(this);
            this.Enabled = true;
        }

        private void settings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            this.Enabled = false;
            sf.ShowDialog(this);
            this.Enabled = true;
        }

        private void about_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            this.Enabled = false;
            about.ShowDialog(this);
            this.Enabled = true;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        #region Tasks

        private async Task twrpTask()
        {
            ProgressForm pf = new ProgressForm();
            pf.Location = new Point(
                    this.Left + (this.Width - pf.Width) / 2,
                    this.Top + (this.Height - pf.Height) / 2
                );
            pf.Show(this);
            pf.UpdateProgress(0, "Downloading TWRP image...");

            if (Functions.InternetAvailability())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        Functions.twrpUpdate();
                        pf.UpdateProgress(50, "Downloading TWRP icon...");
                        Functions.twrpIcoUpdate();
                    });
                    await Task.Delay(1300);
                    pf.UpdateProgress(100, "Completed!");
                    await Task.Delay(500);
                    Functions.CreateShortcut(twrpPath, "TWRP", true, icoPath);
                    pf.Close();
                }
                catch (Exception ex)
                {
                    using (MessageForm mf = new MessageForm($"An error has occurred: \n{ex}", "sta Shortcuts Manager - Error", false))
                    {
                        mf.ShowDialog(this);
                    }
                    pf.Close();
                }
            }
            else
            {
                using (MessageForm mf = new MessageForm("No Internet connection. Please connect and try again.", "sta Shortcuts Manager - Error", false))
                {
                    mf.ShowDialog(this);
                }
                pf.Close();
            }
        }
        #endregion
    }
}
