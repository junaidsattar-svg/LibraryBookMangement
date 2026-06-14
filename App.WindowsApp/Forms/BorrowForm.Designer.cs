namespace App.WindowsApp.Forms
{
    partial class BorrowForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.ComboBox cmbBook;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.Label lblBorrowDate;
        private System.Windows.Forms.DateTimePicker dtpBorrowDate;
        private System.Windows.Forms.Label lblDueDate;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblBook = new System.Windows.Forms.Label();
            this.cmbBook = new System.Windows.Forms.ComboBox();
            this.lblMember = new System.Windows.Forms.Label();
            this.cmbMember = new System.Windows.Forms.ComboBox();
            this.lblBorrowDate = new System.Windows.Forms.Label();
            this.dtpBorrowDate = new System.Windows.Forms.DateTimePicker();
            this.lblDueDate = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblBook.Text = "Book:";
            this.lblBook.Location = new System.Drawing.Point(20, 20);
            this.lblBook.Size = new System.Drawing.Size(100, 22);

            this.cmbBook.Location = new System.Drawing.Point(130, 18);
            this.cmbBook.Size = new System.Drawing.Size(280, 22);
            this.cmbBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblMember.Text = "Member:";
            this.lblMember.Location = new System.Drawing.Point(20, 60);
            this.lblMember.Size = new System.Drawing.Size(100, 22);

            this.cmbMember.Location = new System.Drawing.Point(130, 58);
            this.cmbMember.Size = new System.Drawing.Size(280, 22);
            this.cmbMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblBorrowDate.Text = "Borrow Date:";
            this.lblBorrowDate.Location = new System.Drawing.Point(20, 100);
            this.lblBorrowDate.Size = new System.Drawing.Size(100, 22);

            this.dtpBorrowDate.Location = new System.Drawing.Point(130, 98);
            this.dtpBorrowDate.Size = new System.Drawing.Size(200, 22);
            this.dtpBorrowDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblDueDate.Text = "Due Date:";
            this.lblDueDate.Location = new System.Drawing.Point(20, 140);
            this.lblDueDate.Size = new System.Drawing.Size(100, 22);

            this.dtpDueDate.Location = new System.Drawing.Point(130, 138);
            this.dtpDueDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(180, 200);
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(275, 200);
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.ClientSize = new System.Drawing.Size(450, 250);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblBook);
            this.Controls.Add(this.cmbBook);
            this.Controls.Add(this.lblMember);
            this.Controls.Add(this.cmbMember);
            this.Controls.Add(this.lblBorrowDate);
            this.Controls.Add(this.dtpBorrowDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Load += new System.EventHandler(this.BorrowForm_Load);
            this.ResumeLayout(false);
        }
    }
}