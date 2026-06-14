namespace App.WindowsApp.Forms
{
    partial class ReservationForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.ComboBox cmbBook;
        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.ComboBox cmbMember;
        private System.Windows.Forms.Label lblReservationDate;
        private System.Windows.Forms.DateTimePicker dtpReservationDate;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;

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
            this.lblReservationDate = new System.Windows.Forms.Label();
            this.dtpReservationDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
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

            this.lblReservationDate.Text = "Reservation Date:";
            this.lblReservationDate.Location = new System.Drawing.Point(20, 100);
            this.lblReservationDate.Size = new System.Drawing.Size(110, 22);

            this.dtpReservationDate.Location = new System.Drawing.Point(130, 98);
            this.dtpReservationDate.Size = new System.Drawing.Size(200, 22);
            this.dtpReservationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblExpiryDate.Text = "Expiry Date:";
            this.lblExpiryDate.Location = new System.Drawing.Point(20, 140);
            this.lblExpiryDate.Size = new System.Drawing.Size(100, 22);

            this.dtpExpiryDate.Location = new System.Drawing.Point(130, 138);
            this.dtpExpiryDate.Size = new System.Drawing.Size(200, 22);
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(180, 190);
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnClose.Text = "Cancel";
            this.btnClose.Location = new System.Drawing.Point(275, 190);
            this.btnClose.Size = new System.Drawing.Size(85, 30);
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.ClientSize = new System.Drawing.Size(450, 240);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblBook);
            this.Controls.Add(this.cmbBook);
            this.Controls.Add(this.lblMember);
            this.Controls.Add(this.cmbMember);
            this.Controls.Add(this.lblReservationDate);
            this.Controls.Add(this.dtpReservationDate);
            this.Controls.Add(this.lblExpiryDate);
            this.Controls.Add(this.dtpExpiryDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Load += new System.EventHandler(this.ReservationForm_Load);
            this.ResumeLayout(false);
        }
    }
}