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
        private string iconPath = @"C:\bootfiles\";
        private string iconName = "disc.ico";

        public CustomShortcutForm()
        {
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
            string folderPath = @"C:\bootfiles\";
            string bootPathNew = Path.Combine(folderPath, bootName);
            string iconPathNew = Path.Combine(folderPath, iconName);
            bool cancel = false;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (File.Exists(bootPathNew))
            {
                Settings.Default.fileAction = 2;
                using (MessageForm mf = new MessageForm($"File {bootPathNew} already exists.\nDo you want to replace it?", "sta Shortcuts Manager", true))
                {
                    mf.ShowDialog(this);
                }
                switch (Settings.Default.fileAction)
                {
                    case 0:
                        File.Delete(bootPathNew);
                        File.Copy(bootPath, bootPathNew);
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

            if (File.Exists(iconPathNew))
            {
                if (!cancel &&  iconPathNew != @"C:\bootfiles\disc.ico")
                {
                    Settings.Default.fileAction = 2;
                    using (MessageForm mf = new MessageForm($"File {iconPathNew} already exists.\nDo you want to replace it?", "sta Shortcuts Manager", true))
                    {
                        mf.ShowDialog(this);
                    }
                    switch (Settings.Default.fileAction)
                    {
                        case 0:
                            File.Delete(iconPathNew);
                            File.Copy(iconPath, iconPathNew);
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
