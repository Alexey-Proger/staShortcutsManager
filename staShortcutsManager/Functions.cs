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

        public static bool staCheck()
        {
            string[] possiblePaths = { @"C:\sta\sta.exe", @"C:\ProgramData\sta\sta.exe" };

            foreach (var path in possiblePaths)
            {
                if (System.IO.File.Exists(path))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool sddCheck()
        {
            string[] possiblePaths = { @"C:\sta\sdd.exe", @"C:\ProgramData\sta\sdd.exe" };

            foreach (var path in possiblePaths)
            {
                if (System.IO.File.Exists(path))
                {
                    return true;
                }
            }
            return false;
        }

        public static string staLocation()
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

        public static string sddLocation()
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
            string targetPath = (Settings.Default.useSdd) ? sddLocation() : staLocation();
            string shortcutPath = Path.Combine(DesktopPath, shortcutFile);

            if (targetPath == "nf" || targetPath == null)
            {
                using (MessageForm mf = new MessageForm($"An error has occurred while creating shortcut:\n{((Settings.Default.useSdd) ? "sdd" : "sta")} not detected. Please reinstall it and try again.", "sta Shortcuts Manager - Error", "Default"))
                {
                    mf.ShowDialog();
                }
                return;
            }
            try
            {
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = targetPath;
                shortcut.Arguments = $"-f -p \"{bootPath}\"";
                shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
                shortcut.Description = $"StA shortcut for switching to {shortcutName}.";
                if (customIcon)
                    shortcut.IconLocation = iconLocation;
                shortcut.Save();
                using (MessageForm mf = new MessageForm($"{shortcutName} shortcut created successfully.", "sta Shortcuts Manager", "Default"))
                {
                    mf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                using (MessageForm mf = new MessageForm($"An error has occurred while creating shortcut:\n{ex}", "sta Shortcuts Manager - Error", "Default"))
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
                request.Timeout = 6000;
                using (var response = request.GetResponse()) { return true; }
            }
            catch { return false; }
        }

        public static bool staUpdate()
        {
            string staUrl = "https://github.com/Alexey-Proger/files/releases/download/SSM/sta.exe";
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
            catch (Exception ex)
            {
                using (MessageForm mf = new MessageForm($"An error has occurred while downloading sta:\n{ex}", "sta Shortcuts Manager - Error", "Default"))
                {
                    mf.ShowDialog();
                }
                return false;
            }
        }
    }
}
