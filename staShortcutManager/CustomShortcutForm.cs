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

namespace staShortcutManager
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
            iconPathNew = iconPathNew + ".ico";
            bool cancel = false;
            if (File.Exists(bootPathNew))
            {
                DialogResult result = MessageBox.Show($"File {bootPathNew} already exists.\nDo you want to replace it?", "sta Shortcuts Manager - Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    File.Delete(bootPathNew);
                    File.Copy(bootPath, bootPathNew);
                }
                else
                    cancel = true;
            }
            else
                File.Copy(bootPath, bootPathNew);
            if (File.Exists(iconPathNew))
            {
                DialogResult result = MessageBox.Show($"File {iconPathNew} already exists.\nDo you want to replace it?", "sta Shortcuts Manager - Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    File.Delete(iconPathNew);
                    File.Copy(iconPath, iconPathNew);
                }
                else
                    cancel = true;
            }
            else
                File.Copy(iconPath, iconPathNew);
            if (!cancel)
            {
                Functions.CreateShortcut(bootPathNew, tBname.Text, true, iconPathNew);
                this.Close();
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
