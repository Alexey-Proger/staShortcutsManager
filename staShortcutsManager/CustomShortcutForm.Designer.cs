namespace staShortcutsManager
{
    partial class CustomShortcutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomShortcutForm));
            this.openIMG = new System.Windows.Forms.OpenFileDialog();
            this.openICON = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBboot = new System.Windows.Forms.TextBox();
            this.butBoot = new System.Windows.Forms.Button();
            this.butIcon = new System.Windows.Forms.Button();
            this.tBicon = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.butCreate = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.tBname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openIMG
            // 
            this.openIMG.Filter = "Android boot.img file|*.img";
            // 
            // openICON
            // 
            this.openICON.Filter = "Icon file|*.ico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(68, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Creating custom shortcut";
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
            this.tBboot.Location = new System.Drawing.Point(13, 64);
            this.tBboot.MinimumSize = new System.Drawing.Size(4, 26);
            this.tBboot.Name = "tBboot";
            this.tBboot.ReadOnly = true;
            this.tBboot.Size = new System.Drawing.Size(226, 26);
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
            // butIcon
            // 
            this.butIcon.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.butIcon.Location = new System.Drawing.Point(248, 118);
            this.butIcon.Name = "butIcon";
            this.butIcon.Size = new System.Drawing.Size(104, 32);
            this.butIcon.TabIndex = 6;
            this.butIcon.Text = "Select";
            this.butIcon.UseVisualStyleBackColor = true;
            this.butIcon.Click += new System.EventHandler(this.butIcon_Click);
            // 
            // tBicon
            // 
            this.tBicon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBicon.Location = new System.Drawing.Point(13, 121);
            this.tBicon.MinimumSize = new System.Drawing.Size(4, 26);
            this.tBicon.Name = "tBicon";
            this.tBicon.ReadOnly = true;
            this.tBicon.Size = new System.Drawing.Size(226, 26);
            this.tBicon.TabIndex = 5;
            this.tBicon.WordWrap = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Path to icon:";
            // 
            // butCreate
            // 
            this.butCreate.Enabled = false;
            this.butCreate.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.butCreate.Location = new System.Drawing.Point(12, 218);
            this.butCreate.Name = "butCreate";
            this.butCreate.Size = new System.Drawing.Size(167, 40);
            this.butCreate.TabIndex = 7;
            this.butCreate.Text = "Create";
            this.butCreate.UseVisualStyleBackColor = true;
            this.butCreate.Click += new System.EventHandler(this.butCreate_Click);
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.butCancel.Location = new System.Drawing.Point(185, 218);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(167, 40);
            this.butCancel.TabIndex = 8;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // tBname
            // 
            this.tBname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBname.Location = new System.Drawing.Point(13, 178);
            this.tBname.MaxLength = 128;
            this.tBname.MinimumSize = new System.Drawing.Size(4, 26);
            this.tBname.Name = "tBname";
            this.tBname.Size = new System.Drawing.Size(339, 26);
            this.tBname.TabIndex = 10;
            this.tBname.WordWrap = false;
            this.tBname.TextChanged += new System.EventHandler(this.tBname_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Shortcut name:";
            // 
            // CustomShortcutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(364, 269);
            this.Controls.Add(this.tBname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butCreate);
            this.Controls.Add(this.butIcon);
            this.Controls.Add(this.tBicon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.butBoot);
            this.Controls.Add(this.tBboot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomShortcutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Creating custom shortcut";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openIMG;
        private System.Windows.Forms.OpenFileDialog openICON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tBboot;
        private System.Windows.Forms.Button butBoot;
        private System.Windows.Forms.Button butIcon;
        private System.Windows.Forms.TextBox tBicon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button butCreate;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.TextBox tBname;
        private System.Windows.Forms.Label label4;
    }
}