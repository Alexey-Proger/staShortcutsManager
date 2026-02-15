using IWshRuntimeLibrary;
using staShortcutsManager.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace staShortcutsManager
{
    internal class Functions
    {
        private static string DesktopPath => Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private static string staPath;
        private static string sddPath;

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

        public static string sddCheck()
        {
            string[] possiblePaths = { @"C:\sta\sdd.exe", @"C:\ProgramData\sta\sdd.exe" };

            foreach (var path in possiblePaths)
            {
                if (System.IO.File.Exists(path))
                {
                    sddPath = path;
                    return path;
                }
            }
            return "nf";
        }

        public static void CreateShortcut(string bootPath, string shortcutName, bool customIcon, string iconLocation)
        {
            string shortcutFile = $"{shortcutName}.lnk";
            string targetPath = (Settings.Default.useSdd) ? sddCheck() : staCheck();
            string shortcutPath = Path.Combine(DesktopPath, shortcutFile);
            try
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = targetPath;
                shortcut.Arguments = $"-p \"{bootPath}\"";
                shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
                shortcut.Description = "";
                if (customIcon)
                    shortcut.IconLocation = iconLocation;
                shortcut.Save();
                using (MessageForm mf = new MessageForm($"{shortcutName} shortcut created successfully.", "sta Shortcuts Manager", false))
                {
                    mf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                using (MessageForm mf = new MessageForm($"An error has occurred while creating shortcut:\n{ex}", "sta Shortcuts Manager - Error", false))
                {
                    mf.ShowDialog();
                }
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

        public static bool staUpdate()
        {
            string staUrl = "https://github.com/Alexey-Proger/files/releases/download/files/sta.exe";
            staPath = @"C:\sta\sta.exe";
            string folderPath = @"C:\sta\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(staUrl, staPath);
                client.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool sddUpdate()
        {
            string sddUrl = "https://github.com/Alexey-Proger/files/releases/download/files/sdd.exe";
            sddPath = @"C:\sta\sdd.exe";
            string folderPath = @"C:\sta\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(sddUrl, sddPath);
                client.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool twrpUpdate()
        {
            string twrpUrl = "https://github.com/ArKT-7/twrp_device_xiaomi_nabu/releases/download/mod-win/V4-MODDED-TWRP-WINDOWS.img";
            string twrpPath = @"C:\bootfiles\twrp.img";
            string folderPath = @"C:\bootfiles\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(twrpUrl, twrpPath);
                client.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool twrpIcoUpdate()
        {
            string icoUrl = "https://github.com/Alexey-Proger/files/releases/download/files/twrp.ico";
            string icoPath = @"C:\bootfiles\twrp.ico";
            string folderPath = @"C:\bootfiles\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(icoUrl, icoPath);
                client.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
