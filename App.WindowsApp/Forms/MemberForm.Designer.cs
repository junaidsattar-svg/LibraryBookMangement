namespace App.WindowsApp.Forms
{
    partial class MemberForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblJoinDate;
        private System.Windows.Forms.DateTimePicker dtpJoinDate;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpExpiryDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblJoinDate = new System.Windows.Forms.Label();
            this.dtpJoinDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblFullName.Text = "Full Name:";
            this.lblFullName.Location = new System.Drawing.Point(20, 20);
            this.lblFullName.Size = new System.Drawing.Size(100, 22);

            this.txtFullName.Location = new System.Drawing.Point(130, 18);
            this.txtFullName.Size = new System.Drawing.Size(280, 22);

            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(20, 60);
            this.lblEmail.Size = new System.Drawing.Size(100, 22);

            this.txtEmail.Location = new System.Drawing.Point(130, 58);
            this.txtEmail.Size = new System.Drawing.Size(280, 22);

            this.lblPhone.Text = "Phone:";
            this.lblPhone.Location = new System.Drawing.Point(20, 100);
            this.lblPhone.Size = new System.Drawing.Size(100, 22);

            this.txtPhone.Location = new System.Drawing.Point(130, 98);
            this.txtPhone.Size = new System.Drawing.Size(280, 22);

            this.lblAddress.Text = "Address:";
            this.lblAddress.Location = new System.Drawing.Point(20, 140);
            this.lblAddress.Size = new System.Drawing.Size(100, 22);

            this.txtAddress.Location = new System.Drawing.Point(130, 138);
            this.txtAddress.Size = new System.Drawing.Size(280, 22);

            this.lblStatus.Text = "Status:";
            this.lblStatus.Location = new System.Drawing.Point(20, 180);
            this.lblStatus.Size = new System.Drawing.Size(100, 22);

            this.cmbStatus.Location = new System.Drawing.Point(130, 178);
            this.cmbStatus.Size = new System.Drawing.Size(280, 22);
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] { "Active", "Suspended", "Expired" });
            this.cmbStatus.SelectedIndex = 0;

            this.lblJoinDate.Text = "Join Date:";
            this.lblJoinDate.Location = new System.Drawing.Point(20, 220);
            this.lblJoinDate.Size = new System.Drawing.Size(100, 22);

            this.dtpJoinDate.Location = new System.Drawing.Point(130, 218);
            this.dtpJoinDate.Size = new System.Drawing.Size(200, 22);
            this.dtpJoinDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblExpiryDate.Text = "Expiry Date:";
            this.lblExpiryDate.Location = new System.Drawing.Point(20, 260);
            this.lblExpiryDate.Size = new System.Drawing.Size(100, 22);

            this.dtpExpiryDate.Location = new System.Drawing.Point(130, 258);
            this.dtpExpiryDate.Size = new System.Drawing.Size(200, 22);
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(230, 310);
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(325, 310);
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.ClientSize = new System.Drawing.Size(450, 360);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblJoinDate);
            this.Controls.Add(this.dtpJoinDate);
            this.Controls.Add(this.lblExpiryDate);
            this.Controls.Add(this.dtpExpiryDate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Load += new System.EventHandler(this.MemberForm_Load);
            this.ResumeLayout(false);
        }
    }
}