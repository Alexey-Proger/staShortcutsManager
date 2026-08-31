namespace staShortcutsManager
{
    partial class RecoveryButton
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.recovery_name = new System.Windows.Forms.Label();
            this.recovery_desk = new System.Windows.Forms.Label();
            this.recovery_icon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.recovery_icon)).BeginInit();
            this.SuspendLayout();
            // 
            // recovery_name
            // 
            this.recovery_name.AutoSize = true;
            this.recovery_name.BackColor = System.Drawing.Color.Transparent;
            this.recovery_name.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.recovery_name.Location = new System.Drawing.Point(83, 4);
            this.recovery_name.Name = "recovery_name";
            this.recovery_name.Size = new System.Drawing.Size(66, 25);
            this.recovery_name.TabIndex = 4;
            this.recovery_name.Text = "TWRP";
            // 
            // recovery_desk
            // 
            this.recovery_desk.BackColor = System.Drawing.Color.Transparent;
            this.recovery_desk.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.recovery_desk.Location = new System.Drawing.Point(85, 28);
            this.recovery_desk.Name = "recovery_desk";
            this.recovery_desk.Size = new System.Drawing.Size(261, 46);
            this.recovery_desk.TabIndex = 5;
            this.recovery_desk.Text = "Default text";
            // 
            // recovery_icon
            // 
            this.recovery_icon.BackColor = System.Drawing.Color.Transparent;
            this.recovery_icon.Image = global::staShortcutsManager.Properties.Resources.twrp2;
            this.recovery_icon.Location = new System.Drawing.Point(7, 4);
            this.recovery_icon.Name = "recovery_icon";
            this.recovery_icon.Size = new System.Drawing.Size(70, 67);
            this.recovery_icon.TabIndex = 3;
            this.recovery_icon.TabStop = false;
            // 
            // RecoveryButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.recovery_desk);
            this.Controls.Add(this.recovery_name);
            this.Controls.Add(this.recovery_icon);
            this.Name = "RecoveryButton";
            this.Size = new System.Drawing.Size(350, 76);
            ((System.ComponentModel.ISupportInitialize)(this.recovery_icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label recovery_desk;
        private System.Windows.Forms.PictureBox recovery_icon;
        private System.Windows.Forms.Label recovery_name;
    }
}
