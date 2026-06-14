namespace App.WindowsApp.Views
{
    partial class ChartsView
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
            this.BackColor = System.Drawing.Color.White;
            this.Size = new System.Drawing.Size(920, 560);
            this.Load += new System.EventHandler(this.ChartsView_Load);
            this.ResumeLayout(false);
        }
    }
}