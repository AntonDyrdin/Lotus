namespace Lotus
{
    partial class Preview
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
            this.SuspendLayout();
            // 
            // Preview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Lotus.Properties.Resources.preview;
            this.ClientSize = new System.Drawing.Size(480, 310);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(720, 305);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Preview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Preview";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Preview_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}