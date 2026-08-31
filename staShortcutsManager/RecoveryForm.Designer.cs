namespace staShortcutsManager
{
    partial class RecoveryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoveryForm));
            this.flMain = new System.Windows.Forms.FlowLayoutPanel();
            this.select_an_recovery = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flMain
            // 
            this.flMain.Location = new System.Drawing.Point(14, 46);
            this.flMain.Margin = new System.Windows.Forms.Padding(4);
            this.flMain.Name = "flMain";
            this.flMain.Size = new System.Drawing.Size(358, 247);
            this.flMain.TabIndex = 0;
            // 
            // select_an_recovery
            // 
            this.select_an_recovery.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.select_an_recovery.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.select_an_recovery.Location = new System.Drawing.Point(0, 9);
            this.select_an_recovery.Name = "select_an_recovery";
            this.select_an_recovery.Size = new System.Drawing.Size(385, 25);
            this.select_an_recovery.TabIndex = 1;
            this.select_an_recovery.Text = "Select recovery:";
            this.select_an_recovery.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // butCancel
            // 
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("Segoe UI", 12.75F);
            this.butCancel.Location = new System.Drawing.Point(109, 300);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(166, 40);
            this.butCancel.TabIndex = 9;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // RecoveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(384, 346);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.select_an_recovery);
            this.Controls.Add(this.flMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecoveryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create recovery shortcut";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flMain;
        private System.Windows.Forms.Label select_an_recovery;
        private System.Windows.Forms.Button butCancel;
    }
}