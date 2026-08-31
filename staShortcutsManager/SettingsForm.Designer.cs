namespace staShortcutsManager
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.butCancel = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.updateAll = new System.Windows.Forms.Button();
            this.sddUse = new System.Windows.Forms.CheckBox();
            this.Clean = new System.Windows.Forms.Button();
            this.Change = new System.Windows.Forms.Button();
            this.FolderSelect = new staShortcutsManager.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.butCancel.Location = new System.Drawing.Point(169, 230);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(150, 40);
            this.butCancel.TabIndex = 19;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // butSave
            // 
            this.butSave.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.butSave.Location = new System.Drawing.Point(13, 230);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(150, 40);
            this.butSave.TabIndex = 18;
            this.butSave.Text = "Save";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(122, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Settings";
            // 
            // updateAll
            // 
            this.updateAll.Enabled = false;
            this.updateAll.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.updateAll.Image = global::staShortcutsManager.Properties.Resources.update;
            this.updateAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateAll.Location = new System.Drawing.Point(27, 129);
            this.updateAll.Name = "updateAll";
            this.updateAll.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.updateAll.Size = new System.Drawing.Size(278, 40);
            this.updateAll.TabIndex = 20;
            this.updateAll.Text = "Update sta";
            this.updateAll.UseMnemonic = false;
            this.updateAll.UseVisualStyleBackColor = true;
            this.updateAll.Click += new System.EventHandler(this.updateAll_Click);
            // 
            // sddUse
            // 
            this.sddUse.Appearance = System.Windows.Forms.Appearance.Button;
            this.sddUse.FlatAppearance.BorderSize = 0;
            this.sddUse.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.sddUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sddUse.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.sddUse.Image = global::staShortcutsManager.Properties.Resources.off;
            this.sddUse.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.sddUse.Location = new System.Drawing.Point(27, 175);
            this.sddUse.Name = "sddUse";
            this.sddUse.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.sddUse.Size = new System.Drawing.Size(278, 40);
            this.sddUse.TabIndex = 21;
            this.sddUse.Text = "  Use sdd instead of sta";
            this.sddUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sddUse.UseVisualStyleBackColor = true;
            this.sddUse.CheckedChanged += new System.EventHandler(this.sddUse_CheckedChanged);
            // 
            // Clean
            // 
            this.Clean.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.Clean.Image = global::staShortcutsManager.Properties.Resources.twrp;
            this.Clean.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Clean.Location = new System.Drawing.Point(27, 83);
            this.Clean.Name = "Clean";
            this.Clean.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Clean.Size = new System.Drawing.Size(278, 40);
            this.Clean.TabIndex = 22;
            this.Clean.Text = "Clean app folder";
            this.Clean.UseMnemonic = false;
            this.Clean.UseVisualStyleBackColor = true;
            this.Clean.Click += new System.EventHandler(this.Clean_Click);
            // 
            // Change
            // 
            this.Change.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.Change.Image = global::staShortcutsManager.Properties.Resources.ssm;
            this.Change.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Change.Location = new System.Drawing.Point(27, 37);
            this.Change.Name = "Change";
            this.Change.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Change.Size = new System.Drawing.Size(278, 40);
            this.Change.TabIndex = 23;
            this.Change.Text = "Change app folder";
            this.Change.UseMnemonic = false;
            this.Change.UseVisualStyleBackColor = true;
            this.Change.Click += new System.EventHandler(this.Change_Click);
            // 
            // FolderSelect
            // 
            this.FolderSelect.SelectedPath = "";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(332, 281);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.Clean);
            this.Controls.Add(this.sddUse);
            this.Controls.Add(this.updateAll);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateAll;
        private System.Windows.Forms.CheckBox sddUse;
        private System.Windows.Forms.Button Clean;
        private System.Windows.Forms.Button Change;
        private FolderBrowserDialog FolderSelect;
    }
}