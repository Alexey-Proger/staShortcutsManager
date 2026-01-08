using IWshRuntimeLibrary;
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

namespace staShortcutManager
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
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"An error has occurred: \n{ex}", "sta Shortcuts Manager - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    Environment.Exit(0);
            }
            else if (Functions.staCheck() == "nf" && !Functions.InternetAvailability())
            {
                MessageBox.Show("sta not detected.\nDownload it manually or connect to Internet and try again.", "sta Shortcuts Manager - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            csf.ShowDialog(this);
        }

        private async void update_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            await updateTask();
            this.Enabled = true;
            this.Focus();
        }

        private void about_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.ShowDialog(this);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        #region Tasks
        private async Task updateTask()
        {
            ProgressForm pf = new ProgressForm();
            pf.Location = new Point(
                    this.Left + (this.Width - pf.Width) / 2,
                    this.Top + (this.Height - pf.Height) / 2
                );
            pf.Show(this);

            if (Functions.InternetAvailability())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        Functions.staUpdate();
                        pf.UpdateProgress(50);
                        Functions.twrpUpdate();
                        pf.UpdateProgress(100);
                    });
                    await Task.Delay(800);
                    pf.Close();
                    //MessageBox.Show($"sta and TWRP updated successfully.", "sta Shortcuts Manager - Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error has occurred: \n{ex}", "sta Shortcuts Manager - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pf.Close();
                }
            }
            else
            {
                MessageBox.Show($"No Internet connection. Please connect and try again.", "sta Shortcuts Manager - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pf.Close();
            }
        }

        private async Task twrpTask()
        {
            ProgressForm pf = new ProgressForm();
            pf.Location = new Point(
                    this.Left + (this.Width - pf.Width) / 2,
                    this.Top + (this.Height - pf.Height) / 2
                );
            pf.Show(this);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (Functions.InternetAvailability())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        Functions.twrpUpdate();
                        pf.UpdateProgress(50);
                        Functions.CreateShortcut(twrpPath, "TWRP", true, icoPath);
                        pf.UpdateProgress(100);
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error has occurred: \n{ex}", "sta Shortcuts Manager - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"No internet connection. Please connect and try again.", "sta Shortcuts Manager - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pf.UpdateProgress(100);
            await Task.Delay(800);
            pf.Close();
        }
        #endregion
    }
}
