namespace staShortcutsManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.select_an_action = new System.Windows.Forms.Label();
            this.separator = new System.Windows.Forms.Label();
            this.about = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.custom = new System.Windows.Forms.Button();
            this.twrp = new System.Windows.Forms.Button();
            this.android = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // select_an_action
            // 
            resources.ApplyResources(this.select_an_action, "select_an_action");
            this.select_an_action.Name = "select_an_action";
            // 
            // separator
            // 
            resources.ApplyResources(this.separator, "separator");
            this.separator.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.separator.Name = "separator";
            // 
            // about
            // 
            resources.ApplyResources(this.about, "about");
            this.about.Image = global::staShortcutsManager.Properties.Resources.about;
            this.about.Name = "about";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // exit
            // 
            resources.ApplyResources(this.exit, "exit");
            this.exit.Name = "exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // settings
            // 
            resources.ApplyResources(this.settings, "settings");
            this.settings.Image = global::staShortcutsManager.Properties.Resources.settings;
            this.settings.Name = "settings";
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // custom
            // 
            resources.ApplyResources(this.custom, "custom");
            this.custom.Image = global::staShortcutsManager.Properties.Resources.shortcut;
            this.custom.Name = "custom";
            this.custom.UseVisualStyleBackColor = true;
            this.custom.Click += new System.EventHandler(this.custom_Click);
            // 
            // twrp
            // 
            resources.ApplyResources(this.twrp, "twrp");
            this.twrp.Image = global::staShortcutsManager.Properties.Resources.twrp;
            this.twrp.Name = "twrp";
            this.twrp.UseVisualStyleBackColor = true;
            this.twrp.Click += new System.EventHandler(this.twrp_Click);
            // 
            // android
            // 
            resources.ApplyResources(this.android, "android");
            this.android.Image = global::staShortcutsManager.Properties.Resources.sta;
            this.android.Name = "android";
            this.android.UseVisualStyleBackColor = true;
            this.android.Click += new System.EventHandler(this.android_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.exit);
            this.Controls.Add(this.about);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.custom);
            this.Controls.Add(this.twrp);
            this.Controls.Add(this.android);
            this.Controls.Add(this.select_an_action);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label select_an_action;
        private System.Windows.Forms.Button android;
        private System.Windows.Forms.Button twrp;
        private System.Windows.Forms.Button custom;
        private System.Windows.Forms.Label separator;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.Button exit;
    }
}

