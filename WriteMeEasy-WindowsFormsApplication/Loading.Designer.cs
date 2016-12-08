namespace WriteMeEasy_WindowsFormsApplication
{
    partial class Loading
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.displayText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(50, 91);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(700, 57);
            this.progressBar.TabIndex = 0;
            this.progressBar.Value = 50;
            // 
            // displayText
            // 
            this.displayText.Dock = System.Windows.Forms.DockStyle.Top;
            this.displayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.1F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayText.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.displayText.Location = new System.Drawing.Point(0, 0);
            this.displayText.Name = "displayText";
            this.displayText.Size = new System.Drawing.Size(768, 82);
            this.displayText.TabIndex = 1;
            this.displayText.Text = "Processing...";
            this.displayText.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(768, 190);
            this.ControlBox = false;
            this.Controls.Add(this.displayText);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loading";
            this.Text = "Loading";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label displayText;
    }
}