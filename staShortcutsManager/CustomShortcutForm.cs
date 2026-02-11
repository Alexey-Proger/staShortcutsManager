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
        public CustomShortcutForm()
        {
            InitializeComponent();
        }

        private string bootPath;
        private string bootName;
        private string iconPath;
        private string iconName;

        #region Buttons logic
        private void butBoot_Click(object sender, EventArgs e)
        {
            if (openIMG.ShowDialog() == DialogResult.OK)
            {
                bootPath = openIMG.FileName;
                bootName = openIMG.SafeFileName;
                tBboot.Text = bootPath;
                if (iconPath != null && tBname.Text != "")
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
                if (bootPath != null && tBname.Text != "")
                    butCreate.Enabled = true;
            }
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
                Settings.Default.fileAction = 1;
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
                if (!cancel)
                {
                    Settings.Default.fileAction = 1;
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

        private void tBname_TextChanged(object sender, EventArgs e)
        {
            if (iconPath != null && bootPath != null && tBname.Text != "")
                butCreate.Enabled = true;
            else
                butCreate.Enabled = false;
        }
        #endregion
    }
}
