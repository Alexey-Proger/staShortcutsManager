namespace staShortcutsManager
{
    partial class ProgressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressForm));
            this.TaskLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TaskLabel
            // 
            this.TaskLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.TaskLabel.Location = new System.Drawing.Point(12, 9);
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.Size = new System.Drawing.Size(328, 28);
            this.TaskLabel.TabIndex = 1;
            this.TaskLabel.Text = "(1/2): Downloading recovery image...";
            this.TaskLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(11, 47);
            this.progressBar.MarqueeAnimationSpeed = 25;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(249, 16);
            this.progressBar.TabIndex = 2;
            this.progressBar.UseWaitCursor = true;
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Cancel.Location = new System.Drawing.Point(266, 39);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 30);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(350, 71);
            this.ControlBox = false;
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.TaskLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(366, 110);
            this.Name = "ProgressForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Please wait...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label TaskLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button Cancel;
    }
}