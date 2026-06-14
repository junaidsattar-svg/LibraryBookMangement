namespace App.WindowsApp.Forms
{
    partial class FineForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblMember;
        private System.Windows.Forms.TextBox txtMember;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblIssued;
        private System.Windows.Forms.TextBox txtIssued;
        private System.Windows.Forms.Label lblPaid;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMember = new System.Windows.Forms.Label();
            this.txtMember = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblIssued = new System.Windows.Forms.Label();
            this.txtIssued = new System.Windows.Forms.TextBox();
            this.lblPaid = new System.Windows.Forms.Label();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblMember.Text = "Member:";
            this.lblMember.Location = new System.Drawing.Point(20, 20);
            this.lblMember.Size = new System.Drawing.Size(100, 22);

            this.txtMember.Location = new System.Drawing.Point(130, 18);
            this.txtMember.Size = new System.Drawing.Size(280, 22);
            this.txtMember.ReadOnly = true;

            this.lblAmount.Text = "Amount:";
            this.lblAmount.Location = new System.Drawing.Point(20, 60);
            this.lblAmount.Size = new System.Drawing.Size(100, 22);

            this.txtAmount.Location = new System.Drawing.Point(130, 58);
            this.txtAmount.Size = new System.Drawing.Size(280, 22);
            this.txtAmount.ReadOnly = true;

            this.lblStatus.Text = "Status:";
            this.lblStatus.Location = new System.Drawing.Point(20, 100);
            this.lblStatus.Size = new System.Drawing.Size(100, 22);

            this.txtStatus.Location = new System.Drawing.Point(130, 98);
            this.txtStatus.Size = new System.Drawing.Size(280, 22);
            this.txtStatus.ReadOnly = true;

            this.lblIssued.Text = "Issued Date:";
            this.lblIssued.Location = new System.Drawing.Point(20, 140);
            this.lblIssued.Size = new System.Drawing.Size(100, 22);

            this.txtIssued.Location = new System.Drawing.Point(130, 138);
            this.txtIssued.Size = new System.Drawing.Size(280, 22);
            this.txtIssued.ReadOnly = true;

            this.lblPaid.Text = "Paid Date:";
            this.lblPaid.Location = new System.Drawing.Point(20, 180);
            this.lblPaid.Size = new System.Drawing.Size(100, 22);

            this.txtPaid.Location = new System.Drawing.Point(130, 178);
            this.txtPaid.Size = new System.Drawing.Size(280, 22);
            this.txtPaid.ReadOnly = true;

            this.btnSave.Text = "Save";
            this.btnSave.Location = new System.Drawing.Point(180, 230);
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(275, 230);
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.ClientSize = new System.Drawing.Size(450, 280);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblMember);
            this.Controls.Add(this.txtMember);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblIssued);
            this.Controls.Add(this.txtIssued);
            this.Controls.Add(this.lblPaid);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Load += new System.EventHandler(this.FineForm_Load);
            this.ResumeLayout(false);
        }
    }
}