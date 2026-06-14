namespace App.WindowsApp.Forms
{
    partial class BookForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.Label lblPublishYear;
        private System.Windows.Forms.TextBox txtPublishYear;
        private System.Windows.Forms.Label lblCopies;
        private System.Windows.Forms.NumericUpDown nudTotalCopies;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblISBN = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.lblPublishYear = new System.Windows.Forms.Label();
            this.txtPublishYear = new System.Windows.Forms.TextBox();
            this.lblCopies = new System.Windows.Forms.Label();
            this.nudTotalCopies = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblTitle.Text = "Title:";
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(100, 22);

            this.txtTitle.Location = new System.Drawing.Point(130, 18);
            this.txtTitle.Size = new System.Drawing.Size(280, 22);

            this.lblAuthor.Text = "Author:";
            this.lblAuthor.Location = new System.Drawing.Point(20, 60);
            this.lblAuthor.Size = new System.Drawing.Size(100, 22);

            this.txtAuthor.Location = new System.Drawing.Point(130, 58);
            this.txtAuthor.Size = new System.Drawing.Size(280, 22);

            this.lblISBN.Text = "ISBN:";
            this.lblISBN.Location = new System.Drawing.Point(20, 100);
            this.lblISBN.Size = new System.Drawing.Size(100, 22);

            this.txtISBN.Location = new System.Drawing.Point(130, 98);
            this.txtISBN.Size = new System.Drawing.Size(280, 22);

            this.lblCategory.Text = "Category:";
            this.lblCategory.Location = new System.Drawing.Point(20, 140);
            this.lblCategory.Size = new System.Drawing.Size(100, 22);

            this.cmbCategory.Location = new System.Drawing.Point(130, 138);
            this.cmbCategory.Size = new System.Drawing.Size(280, 22);
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblPublisher.Text = "Publisher:";
            this.lblPublisher.Location = new System.Drawing.Point(20, 180);
            this.lblPublisher.Size = new System.Drawing.Size(100, 22);

            this.txtPublisher.Location = new System.Drawing.Point(130, 178);
            this.txtPublisher.Size = new System.Drawing.Size(280, 22);

            this.lblPublishYear.Text = "Publish Year:";
            this.lblPublishYear.Location = new System.Drawing.Point(20, 220);
            this.lblPublishYear.Size = new System.Drawing.Size(100, 22);

            this.txtPublishYear.Location = new System.Drawing.Point(130, 218);
            this.txtPublishYear.Size = new System.Drawing.Size(100, 22);

            this.lblCopies.Text = "Total Copies:";
            this.lblCopies.Location = new System.Drawing.Point(20, 260);
            this.lblCopies.Size = new System.Drawing.Size(100, 22);

            this.nudTotalCopies.Location = new System.Drawing.Point(130, 258);
            this.nudTotalCopies.Size = new System.Drawing.Size(100, 22);
            this.nudTotalCopies.Minimum = 1;
            this.nudTotalCopies.Maximum = 100;
            this.nudTotalCopies.Value = 1;

            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(230, 310);
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(325, 310);
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.ClientSize = new System.Drawing.Size(450, 360);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblPublisher);
            this.Controls.Add(this.txtPublisher);
            this.Controls.Add(this.lblPublishYear);
            this.Controls.Add(this.txtPublishYear);
            this.Controls.Add(this.lblCopies);
            this.Controls.Add(this.nudTotalCopies);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Load += new System.EventHandler(this.BookForm_Load);
            this.ResumeLayout(false);
        }
    }
}