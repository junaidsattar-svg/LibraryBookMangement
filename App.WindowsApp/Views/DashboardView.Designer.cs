namespace App.WindowsApp.Views
{
    partial class DashboardView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DashboardView";
            this.Size = new System.Drawing.Size(880, 620);
            this.Load += new System.EventHandler(this.DashboardView_Load);
            this.ResumeLayout(false);
        }
    }
}