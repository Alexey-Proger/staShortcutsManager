using staShortcutsManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            sddUse.Checked = Settings.Default.useSdd;
            if (Settings.Default.useSdd)
                updateAll.Text = "Update sdd and TWRP";
            updateAll.Enabled = Functions.InternetAvailability();
        }

        #region Buttons logic

        private async void updateAll_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            await updateTask();
            this.Enabled = true;
            this.Focus();
        }

        private void sddUse_CheckedChanged(object sender, EventArgs e)
        {
            sddUse.Image = sddUse.Checked ? Resources.on : Resources.off;
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            if (Settings.Default.useSdd != sddUse.Checked)
            {
                if (Functions.sddCheck() == "nf" && Functions.InternetAvailability())
                {
                    if (Functions.sddUpdate())
                        Settings.Default.useSdd = sddUse.Checked;
                    else MessageBox.Show("Failed to install sdd. Please try again or install manually.", "sta Shortcuts Manager - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Functions.sddCheck() == "nf" && !Functions.InternetAvailability())
                    MessageBox.Show("No Internet connection. Download it manually or connect to Internet and try again.", "sta Shortcuts Manager - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    Settings.Default.useSdd = sddUse.Checked;
            }
            Settings.Default.Save();
            this.Close();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        pf.UpdateProgress(0, $"Updating {(!Settings.Default.useSdd ? "sta" : "sdd")}...");
                        if (!Settings.Default.useSdd) Functions.staUpdate();
                        else Functions.sddUpdate();

                        pf.UpdateProgress(50, "Updating TWRP files...");
                        Functions.twrpUpdate();

                        pf.UpdateProgress(100, "Completed!");
                    });
                    await Task.Delay(800);
                    using (MessageForm mf = new MessageForm($"{(!Settings.Default.useSdd ? "sta" : "sdd")} and TWRP updated successfully.", "sta Shortcuts Manager", false))
                    {
                        mf.ShowDialog(this);
                    }
                    pf.Close();
                }
                catch (Exception ex)
                {
                    using (MessageForm mf = new MessageForm($"An error has occurred: \n{ex}", "sta Shortcuts Manager - Error", false))
                    {
                        mf.ShowDialog(this);
                    }
                    pf.Close();
                }
            }
            else
            {
                using (MessageForm mf = new MessageForm("No Internet connection. Please connect and try again.", "sta Shortcuts Manager - Error", false))
                {
                    mf.ShowDialog(this);
                }
            }
        }

        #endregion
    }
}
