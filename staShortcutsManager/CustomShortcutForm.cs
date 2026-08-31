using staShortcutsManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace staShortcutsManager
{
    public partial class CustomShortcutForm : Form
    {
        private string bootPath;
        private string bootName;
        private string iconPath = Settings.Default.appFolder;
        private string iconName = "disc.ico";

        public CustomShortcutForm()
        {
            if (!Directory.Exists(Settings.Default.appFolder))
            {
                Directory.CreateDirectory(Settings.Default.appFolder);
            }

            InitializeComponent();
        }

        #region Buttons logic
        private void butBoot_Click(object sender, EventArgs e)
        {
            if (openIMG.ShowDialog() == DialogResult.OK)
            {
                bootPath = openIMG.FileName;
                bootName = openIMG.SafeFileName;
                tBboot.Text = bootPath;
                if (tBname.Text != "")
                    butCreate.Enabled = true;
            }
        }

        private void butIcon_Click(object sender, EventArgs e)
        {
            if (openICON.ShowDialog() == DialogResult.OK)
            {
                iconPath = openICON.FileName;
                iconName = openICON.SafeFileName;
                tBicon.Text = iconPath;
            }
        }

        private void tBname_TextChanged(object sender, EventArgs e)
        {
            if (bootPath != null && tBname.Text != "")
                butCreate.Enabled = true;
            else
                butCreate.Enabled = false;
        }

        private void butCreate_Click(object sender, EventArgs e)
        {
            string folderPath = Settings.Default.appFolder;
            string bootPathNew = Path.Combine(folderPath, bootName);
            string iconPathNew = Path.Combine(folderPath, iconName);
            bool cancel = false;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (File.Exists(bootPathNew) && !bootPath.Contains(folderPath))
            {
                Settings.Default.fileAction = 2;
                using (MessageForm mf = new MessageForm($"File {bootPathNew} already exists.\nDo you want to replace it?", "sta Shortcuts Manager", "YesNoCancel"))
                {
                    mf.ShowDialog(this);
                }
                switch (Settings.Default.fileAction)
                {
                    case 0:
                        File.Copy(bootPath, bootPathNew, true);
                        break;
                    case 1:
                        break;
                    case 2:
                        cancel = true;
                        break;
                }
            }
            else
                File.Copy(bootPath, bootPathNew);

            string iconPathSSM = Path.Combine(iconPath, iconName);

            if (!File.Exists(iconPathSSM))
            {
                byte[] data;
                using (MemoryStream ms = new MemoryStream())
                {
                    Resources.disc.Save(ms);
                    data = ms.ToArray();
                }
                File.WriteAllBytes(iconPathSSM, data);
            }

            if (File.Exists(iconPathNew))
            {
                if (!cancel &&  iconPathNew != Path.Combine(Settings.Default.appFolder, "disc.ico"))
                {
                    Settings.Default.fileAction = 2;
                    using (MessageForm mf = new MessageForm($"File {iconPathNew} already exists.\nDo you want to replace it?", "sta Shortcuts Manager", "Default"))
                    {
                        mf.ShowDialog(this);
                    }
                    switch (Settings.Default.fileAction)
                    {
                        case 0:
                            File.Copy(iconPath, iconPathNew, true);
                            break;
                        case 1:
                            break;
                        case 2:
                            cancel = true;
                            break;
                    }
                }
            }
            else
                File.Copy(iconPath, iconPathNew);

            if (!cancel)
            {
                try { Functions.CreateShortcut(bootPathNew, tBname.Text, true, iconPathNew); this.Close(); }
                catch (Exception ex) { MessageBox.Show($"An error has occurred while creating shortcut:\n{ex}\nTry changing shortcut name.", "sta Shortcuts Manager - Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
