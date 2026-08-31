using IWshRuntimeLibrary;
using staShortcutsManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace staShortcutsManager
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            Change.Image = (Image)new Bitmap((Image)Resources.ssm, new Size(GetProperSize(32), GetProperSize(32)));
            Clean.Image = (Image)new Bitmap((Image)Resources.twrp, new Size(GetProperSize(32), GetProperSize(32)));
            updateAll.Image = (Image)new Bitmap((Image)Resources.update, new Size(GetProperSize(32), GetProperSize(32)));
            sddUse.Image = (Image)new Bitmap((Image)Resources.off, new Size(GetProperSize(32), GetProperSize(32)));

            sddUse.Checked = Settings.Default.useSdd;
            updateAll.Enabled = Functions.InternetAvailability();
            if (Settings.Default.useSdd)
                updateAll.Text = "Update sdd";
            else
                updateAll.Text = "Update sta";

            if (!Directory.Exists(Settings.Default.appFolder))
            {
                Directory.CreateDirectory(Settings.Default.appFolder);
            }
        }

        #region Buttons logic

        private void Change_Click(object sender, EventArgs e)
        {
            using (MessageForm mf = new MessageForm($"Current app folder: {Settings.Default.appFolder}", "sta Shortcuts Manager", "AppFolder"))
            {
                Settings.Default.fileAction = 0;
                mf.ShowDialog(this);
            }
            if (Settings.Default.fileAction == 0)
            {
                if (FolderSelect.ShowDialog(this) == DialogResult.OK)
                {
                    using (MessageForm mf = new MessageForm($"Do you want to copy files into {FolderSelect.SelectedPath}?", "sta Shortcuts Manager", "YesNo"))
                    {
                        Settings.Default.fileAction = 0;
                        mf.ShowDialog(this);
                    }

                    if (Settings.Default.fileAction == 0)
                    {
                        String[] files = Directory.GetFiles(Settings.Default.appFolder);

                        try
                        {
                            foreach (string file in files)
                            {
                                string filename = Path.GetFileName(file);
                                string newFile = Path.Combine(FolderSelect.SelectedPath, filename);
                                if (System.IO.File.Exists(newFile))
                                {
                                    using (MessageForm mf = new MessageForm($"File exist: {newFile}\nDo you want to override it?", "sta Shortcuts Manager", "YesNo"))
                                    {
                                        Settings.Default.fileAction = 0;
                                        mf.ShowDialog(this);
                                    }
                                    if (Settings.Default.fileAction == 0)
                                    {
                                        System.IO.File.Copy(file, newFile, true);
                                        System.IO.File.Delete(file);
                                    }
                                }
                                else
                                {
                                    System.IO.File.Copy(file, newFile, true);
                                    System.IO.File.Delete(file);
                                }
                            }
                        }
                        catch (System.IO.FileLoadException ex)
                        {
                            using (MessageForm mf = new MessageForm($"Failed to move files!\nApp can't access to files.\nIt's recommended to restart this app.", "sta Shortcuts Manager - completed", "Default"))
                            {
                                mf.ShowDialog(this);
                            }
                        }
                        catch (Exception ex)
                        {
                            using (MessageForm mf = new MessageForm($"Failed to move files!\nError:{ex}\nRecommended to change app folder.", "sta Shortcuts Manager - completed", "Default"))
                            {
                                mf.ShowDialog(this);
                            }
                        }
                    }


                    Settings.Default.appFolder = FolderSelect.SelectedPath;
                    using (MessageForm mf = new MessageForm($"App folder changed to {Settings.Default.appFolder}\nPlease re-create shortcuts.", "sta Shortcuts Manager - completed", "Default"))
                    {
                        mf.ShowDialog(this);
                    }
                }
                else
                {
                    using (MessageForm mf = new MessageForm("Please select folder to change it!", "sta Shortcuts Manager", "Default"))
                    {
                        mf.ShowDialog(this);
                    }
                }
            }
            else if (Settings.Default.fileAction == 1)
            {
                using (MessageForm mf = new MessageForm(@"Do you want to copy files into C:\sta\bootfiles?", "sta Shortcuts Manager", "YesNo"))
                {
                    Settings.Default.fileAction = 0;
                    mf.ShowDialog(this);
                }

                if (Settings.Default.fileAction == 0)
                {
                    String[] files = Directory.GetFiles(Settings.Default.appFolder);

                    try
                    {
                        foreach (string file in files)
                        {
                            string filename = Path.GetFileName(file);
                            string newFile = Path.Combine(@"C:\sta\bootfiles", filename);
                            if (System.IO.File.Exists(newFile))
                            {
                                using (MessageForm mf = new MessageForm($"File exist: {newFile}\nDo you want to override it?", "sta Shortcuts Manager", "YesNo"))
                                {
                                    Settings.Default.fileAction = 0;
                                    mf.ShowDialog(this);
                                }
                                if (Settings.Default.fileAction == 0)
                                {
                                    System.IO.File.Copy(file, newFile, true);
                                    System.IO.File.Delete(file);
                                }
                            }
                            else
                            {
                                System.IO.File.Copy(file, newFile, true);
                                System.IO.File.Delete(file);
                            }
                        }
                    }
                    catch (System.IO.IOException ex)
                    {
                        using (MessageForm mf = new MessageForm($"Failed to move files!\nApp can't access to files.\nIt's recommended to restart app.", "sta Shortcuts Manager - completed", "Default"))
                        {
                            mf.ShowDialog(this);
                        }
                    }
                    catch (Exception ex)
                    {
                        using (MessageForm mf = new MessageForm($"Failed to move files!\nError:{ex}\nRecommended to change app folder.", "sta Shortcuts Manager - completed", "Default"))
                        {
                            mf.ShowDialog(this);
                        }
                    }
                }

                Settings.Default.appFolder = @"C:\sta\bootfiles";
                using (MessageForm mf = new MessageForm($"App folder restored to: {Settings.Default.appFolder}\nPlease re-create shortcuts.", "sta Shortcuts Manager - completed", "Default"))
                {
                    mf.ShowDialog(this);
                }
            }
            Settings.Default.Save();
        }

        private void Clean_Click(object sender, EventArgs e)
        {
            using (MessageForm mf = new MessageForm($"This action will delete ALL FILES in {Settings.Default.appFolder}.\nDo you REALLY want to contitue?", "sta Shortcuts Manager", "YesNo"))
            {
                Settings.Default.fileAction = 0;
                mf.ShowDialog(this);
            }
            if (Settings.Default.fileAction == 0)
            {
                string folderPath = Settings.Default.appFolder;
                Directory.Delete(folderPath, true);
                Directory.CreateDirectory(folderPath);
                using (MessageForm mf = new MessageForm("Files deleted. Have a nice day :)", "sta Shortcuts Manager - completed", "Default"))
                {
                    mf.ShowDialog(this);
                }
            }
        }

        private async void updateAll_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            await updateTask();
            this.Enabled = true;
            this.Focus();
        }

        private void sddUse_CheckedChanged(object sender, EventArgs e)
        {
            sddUse.Image = (Image)new Bitmap((Image)(sddUse.Checked ? Resources.on : Resources.off), new Size(GetProperSize(32), GetProperSize(32)));
        }

        private async void butSave_Click(object sender, EventArgs e)
        {
            if (sddUse.Checked)
            {
                if (Functions.sddCheck() == false && Functions.InternetAvailability())
                {
                    Settings.Default.useSdd = true;

                    await updateTask();

                    if (Functions.sddCheck() == false)
                    {
                        using (MessageForm mf = new MessageForm($"Failed to download sdd. Please try again or download sdd manually.", "sta Shortcuts Manager - Error", "Default"))
                        {
                            mf.ShowDialog(this);
                        }
                    }
                }
                else if (!Functions.sddCheck() && !Functions.InternetAvailability())
                {
                    using (MessageForm mf = new MessageForm($"Failed to download sdd: no internet connection. Please connect to it or download sdd manually.", "sta Shortcuts Manager - Error", "Default"))
                    {
                        mf.ShowDialog(this);
                    }
                }
                else
                    Settings.Default.useSdd = sddUse.Checked;
                Settings.Default.Save();
                this.Close();
            }
            else
            {
                Settings.Default.useSdd = false;
                Settings.Default.Save();
                this.Close();
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Tasks

        private async Task updateTask()
        {
            ProgressForm pf = new ProgressForm("Default");
            pf.Location = new Point(
                    this.Left + (this.Width - pf.Width) / 2,
                    this.Top + (this.Height - pf.Height) / 2
                );
            pf.Show(this);
            pf.UpdateProgress(0, $"Updating {(!Settings.Default.useSdd ? "sta" : "sdd")}...");

            if (Functions.InternetAvailability())
            {
                try
                {
                    await Task.Delay(1300);
                    await Task.Run(() =>
                    {
                        WebClient client = new WebClient();

                        Uri staURI;
                        string targetPath;
                        string folderPath = @"C:\sta\";
                        if (!Settings.Default.useSdd)
                        {
                            staURI = new Uri("https://github.com/Alexey-Proger/files/releases/download/SSM/sta.exe");
                            targetPath = @"C:\sta\sta.exe";
                        }
                        else
                        {
                            staURI = new Uri("https://github.com/Alexey-Proger/files/releases/download/SSM/sdd.exe");
                            targetPath = @"C:\sta\sdd.exe";
                        }

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        try
                        {
                            client.DownloadProgressChanged += (s, e) =>
                            {
                                pf.UpdateProgress((e.ProgressPercentage), $"Updating {(!Settings.Default.useSdd ? "sta" : "sdd")}...");
                            };

                            client.DownloadFileAsync(staURI, targetPath);

                            bool finished = false;

                            client.DownloadFileCompleted += (s, e) =>
                            {
                                finished = true;
                            };

                            while (!finished)
                            {
                                Application.DoEvents();
                                System.Threading.Thread.Sleep(10);
                            }
                        }
                        catch (Exception ex)
                        {
                            using (MessageForm mf = new MessageForm($"Failed to download {(Settings.Default.useSdd ? "sta" : "sdd")}.\nError: {ex}", "sta Shortcuts Manager - Error", "Default"))
                            {
                                mf.ShowDialog(this);
                            }
                            pf.Close();
                            this.Enabled = true;
                            return;
                        }
                    });
                    await Task.Delay(800);
                    pf.UpdateProgress(100, "Completed!");
                    await Task.Delay(500);

                    string Message = $"{(!Settings.Default.useSdd ? "sta" : "sdd")} updated successfully.";

                    using (MessageForm mf = new MessageForm(Message, "sta Shortcuts Manager", "Default"))
                    {
                        mf.ShowDialog(this);
                    }
                    pf.Close();
                }
                catch (Exception ex)
                {
                    using (MessageForm mf = new MessageForm($"An error has occurred: \n{ex}", "sta Shortcuts Manager - Error", "Default"))
                    {
                        mf.ShowDialog(this);
                    }
                    pf.Close();
                }
            }
            else
            {
                using (MessageForm mf = new MessageForm("No Internet connection. Please connect and try again.", "sta Shortcuts Manager - Error", "Default"))
                {
                    mf.ShowDialog(this);
                }
            }
        }

        private int GetProperSize(int size)
        {
            int properIconSize;
            using (Graphics graphics = this.CreateGraphics())
                properIconSize = (int)((double)size * ((double)graphics.DpiX / 96.0));
            return properIconSize;
        }

        #endregion
    }
}
