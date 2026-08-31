namespace staShortcutsManager
{
    partial class FlashForm
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlashForm));
            this.openIMG = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBboot = new System.Windows.Forms.TextBox();
            this.butBoot = new System.Windows.Forms.Button();
            this.butFlash = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.dontReboot = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openIMG
            // 
            this.openIMG.Filter = "Android boot.img file|*.img";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flash any boot.img";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Path to boot.img:";
            // 
            // tBboot
            // 
            this.tBboot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBboot.Location = new System.Drawing.Point(13, 65);
            this.tBboot.MinimumSize = new System.Drawing.Size(4, 26);
            this.tBboot.Name = "tBboot";
            this.tBboot.ReadOnly = true;
            this.tBboot.Size = new System.Drawing.Size(229, 26);
            this.tBboot.TabIndex = 2;
            this.tBboot.WordWrap = false;
            // 
            // butBoot
            // 
            this.butBoot.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.butBoot.Location = new System.Drawing.Point(248, 61);
            this.butBoot.Name = "butBoot";
            this.butBoot.Size = new System.Drawing.Size(104, 32);
            this.butBoot.TabIndex = 3;
            this.butBoot.Text = "Select";
            this.butBoot.UseVisualStyleBackColor = true;
            this.butBoot.Click += new System.EventHandler(this.butBoot_Click);
            // 
            // butFlash
            // 
            this.butFlash.Enabled = false;
            this.butFlash.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.butFlash.Location = new System.Drawing.Point(12, 148);
            this.butFlash.Name = "butFlash";
            this.butFlash.Size = new System.Drawing.Size(167, 40);
            this.butFlash.TabIndex = 7;
            this.butFlash.Text = "Flash";
            this.butFlash.UseVisualStyleBackColor = true;
            this.butFlash.Click += new System.EventHandler(this.butFlash_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.butCancel.Location = new System.Drawing.Point(185, 148);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(167, 40);
            this.butCancel.TabIndex = 8;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            // 
            // dontReboot
            // 
            this.dontReboot.Appearance = System.Windows.Forms.Appearance.Button;
            this.dontReboot.FlatAppearance.BorderSize = 0;
            this.dontReboot.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Control;
            this.dontReboot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dontReboot.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.dontReboot.Image = global::staShortcutsManager.Properties.Resources.off;
            this.dontReboot.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.dontReboot.Location = new System.Drawing.Point(12, 99);
            this.dontReboot.Name = "dontReboot";
            this.dontReboot.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.dontReboot.Size = new System.Drawing.Size(340, 40);
            this.dontReboot.TabIndex = 22;
            this.dontReboot.Text = "Don\'t reboot after flashing";
            this.dontReboot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dontReboot.UseVisualStyleBackColor = true;
            this.dontReboot.CheckedChanged += new System.EventHandler(this.dontReboot_CheckedChanged);
            // 
            // FlashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(364, 195);
            this.Controls.Add(this.dontReboot);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butFlash);
            this.Controls.Add(this.butBoot);
            this.Controls.Add(this.tBboot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FlashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Flash any boot.img";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openIMG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBboot;
        private System.Windows.Forms.Button butBoot;
        private System.Windows.Forms.Button butFlash;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.CheckBox dontReboot;
    }
}