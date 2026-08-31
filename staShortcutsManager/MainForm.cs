using IWshRuntimeLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using staShortcutsManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace staShortcutsManager
{
    public partial class MainForm : Form
    {
        #region Main

        String[] RecoveryNames;
        String[] RecoveryDescs;
        String[] RecoveryURLs;

        public MainForm()
        {
            if (Functions.staCheck() == false && Functions.InternetAvailability())
            {
                DialogResult result = MessageBox.Show("sta not detected.\nDo you want to download it?", "sta Shortcuts Manager - Error", MessageBoxButtons.YesNo,MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    if (Functions.staUpdate())
                    {
                        using (MessageForm mf = new MessageForm("sta downloaded successfully.", "sta Shortcuts Manager", "Default"))
                        {
                            mf.ShowDialog();
                        }
                    }
                    else
                    {
                        using (MessageForm mf = new MessageForm("sta installing failed. Please try again or download it manually.", "sta Shortcuts Manager - Error", "Default"))
                        {
                            mf.ShowDialog();
                        }
                        Environment.Exit(0);
                    }
                }
                else
                    Environment.Exit(0);
            }
            else if (Functions.staCheck() == false && !Functions.InternetAvailability())
            {
                using (MessageForm mf = new MessageForm("sta not detected.\nDownload it manually or connect to Internet and try again.", "sta Shortcuts Manager - Error", "Default"))
                {
                    mf.ShowDialog();
                }
                Environment.Exit(0);
            }

            InitializeComponent();

            int properIconSize;
            using (Graphics graphics = this.CreateGraphics())
                properIconSize = (int)((double)32.0d * ((double)graphics.DpiX / 96.0));

            android.Image = (Image)new Bitmap((Image)Resources.sta, new Size(properIconSize, properIconSize));
            recovery.Image = (Image)new Bitmap((Image)Resources.twrp, new Size(properIconSize, properIconSize));
            custom.Image = (Image)new Bitmap((Image)Resources.shortcut, new Size(properIconSize, properIconSize));
            flash.Image = (Image)new Bitmap((Image)Resources.flash, new Size(properIconSize, properIconSize));
            settings.Image = (Image)new Bitmap((Image)Resources.settings, new Size(properIconSize, properIconSize));
            about.Image = (Image)new Bitmap((Image)Resources.about, new Size(properIconSize, properIconSize));

            if (!Functions.InternetAvailability())
            {
                recovery.Enabled = false;
                recovery.Text = "No internet connection";
            }
            
        }

        #endregion

        #region Buttons logic

        private void android_Click(object sender, EventArgs e)
        {
            Functions.CreateShortcut(@"C:\boot.img", "Android", false, "");
        }

        private async void recovery_Click(object sender, EventArgs e)
        {
            recovery.Text = "Please wait...";

            if (checkDeviceSupported())
            {
                if (FetchDevice())
                {
                    RecoveryForm fr = new RecoveryForm(RecoveryNames, RecoveryDescs, RecoveryURLs);
                    this.Enabled = false;
                    fr.ShowDialog(this);
                    this.Enabled = true;
                }
            }
            recovery.Text = "Create recovery shortcut";
            recovery.Enabled = true;
        }

        private void custom_Click(object sender, EventArgs e)
        {
            CustomShortcutForm csf = new CustomShortcutForm();
            this.Enabled = false;
            csf.ShowDialog(this);
            this.Enabled = true;
        }

        private void flash_Click(object sender, EventArgs e)
        {
            FlashForm ff = new FlashForm();
            this.Enabled = false;
            ff.ShowDialog(this);
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
        private bool checkDeviceSupported()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Model FROM Win32_ComputerSystem");
            string model = null;

            foreach (ManagementObject obj in searcher.Get())
            {
                model = (string)obj["Model"];
            }

#if DEBUG
            model = "Pad 5";
#endif

            try
            {
                using (var client = new WebClient())
                {
                    string jsonUrl = "https://raw.githubusercontent.com/Alexey-Proger/files/main/SSM/ssm.json";
                    string jsonContent = client.DownloadString(jsonUrl);

                    JObject root = JObject.Parse(jsonContent);
                    JObject deviceData = (JObject)root["SupportedDevices"];

                    foreach (var property in deviceData.Properties())
                    {
                        if ((property.ToString()).Contains(model))
                        {
                            Settings.Default.deviceName = model;
                            Settings.Default.Save();
                            return true;
                        }
                    }
                    using (MessageForm mf = new MessageForm($"Your device is not supported... yet.\nDevice model: {model}.\nContact the developer if you would like your device (maybe) receive support in the future.", "sta Shortcuts Manager - Error", "Default"))
                    {
                        mf.ShowDialog();
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                using (MessageForm mf = new MessageForm($"Failed to fetch recovery links. Please try again. \nIf this error still occurs contact developer.\nError details: {ex}", "sta Shortcuts Manager - Error", "Default"))
                {
                    mf.ShowDialog();
                    return false;
                }
            }
        }

        private bool FetchDevice()
        {
            try
            {
                using (var client = new WebClient())
                {
                    string jsonUrl = "https://raw.githubusercontent.com/Alexey-Proger/files/main/SSM/ssm.json";
                    string jsonContent = client.DownloadString(jsonUrl);

                    JObject root = JObject.Parse(jsonContent);
                    JObject deviceData = (JObject)root[Settings.Default.deviceName];

                    List<string> recoveryUrls = new List<string>();
                    List<string> descriptions = new List<string>();
                    List<string> names = new List<string>();

                    foreach (var property in deviceData.Properties())
                    {
                        string propName = property.Name;
                        string propValue = property.Value.ToString();

                        if (propName.Contains("desk"))
                        {
                            descriptions.Add(propValue);
                        }
                        else
                        {
                            recoveryUrls.Add(propValue);
                            names.Add(propName);
                        }
                    }
                    RecoveryNames = names.ToArray();
                    RecoveryDescs = descriptions.ToArray();
                    RecoveryURLs = recoveryUrls.ToArray();
                    return true;
                }
            }
            catch(Exception ex)
            {
                using (MessageForm mf = new MessageForm($"Failed to fetch recovery links. Please try again. \nIf this error still occurs contact developer.\nError details: {ex}", "sta Shortcuts Manager - Error", "Default"))
                {
                    mf.ShowDialog();
                    return false;
                }
            }
        }
        #endregion
    }
}
