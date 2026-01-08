using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace staShortcutManager
{
    internal class Functions
    {
        private static string DesktopPath => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static string staPath;

        public static string staCheck()
        {
            string[] possiblePaths = { @"C:\sta\sta.exe", @"C:\ProgramData\sta\sta.exe" };

            foreach (var path in possiblePaths)
            {
                if (System.IO.File.Exists(path))
                {
                    staPath = path;
                    return path;
                }
            }
            return "nf";
        }

        public static void CreateShortcut(string bootPath, string shortcutName, bool customIcon, string iconLocation)
        {
            shortcutName = $"{shortcutName}.lnk";
            string shortcutPath = Path.Combine(DesktopPath, shortcutName);
            try
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = staCheck();
                shortcut.Arguments = $"-p \"{bootPath}\"";
                shortcut.WorkingDirectory = Path.GetDirectoryName(staPath);
                shortcut.Description = "";
                if (customIcon)
                    shortcut.IconLocation = iconLocation;
                shortcut.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred while creating shortcut:\n" + ex.Message, "sta Shortcuts Manager - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool InternetAvailability()
        {
            try
            {
                var request = WebRequest.Create("http://clients3.google.com/generate_204");
                request.Timeout = 7000;
                using (var response = request.GetResponse()) { return true; }
            }
            catch { return false; }
        }

        public static void staUpdate()
        {
            string staUrl = "https://github.com/Misha803/Files/releases/download/Files!/sta.exe";
            staPath = @"C:\sta\sta.exe";
            string folderPath = @"C:\sta\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(staUrl, staPath);
            }
        }

        public static void twrpUpdate()
        {
            string twrpUrl = "https://raw.githubusercontent.com/Alexey-Proger/files/main/twrp.img";
            string icoUrl = "https://raw.githubusercontent.com/Alexey-Proger/files/main/twrp.ico";
            string twrpPath = @"C:\bootfiles\twrp.img";
            string icoPath = @"C:\bootfiles\twrp.ico";
            string folderPath = @"C:\bootfiles\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(twrpUrl, twrpPath);
                client.DownloadFile(icoUrl, icoPath);
            }
        }
    }

    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(360, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            // 
            // ProgressForm
            // 
            this.ClientSize = new System.Drawing.Size(384, 61);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Please wait...";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ProgressBar progressBar;

        public void UpdateProgress(int percentage)
        {
            progressBar.Value = percentage;
        }
    }
}
