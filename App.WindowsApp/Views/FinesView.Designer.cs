namespace App.WindowsApp.Views
{
    partial class FinesView
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvFines;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlTop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvFines = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.SuspendLayout();

            this.pnlTop.Location = new System.Drawing.Point(40, 0);
            this.pnlTop.Size = new System.Drawing.Size(880, 55);
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);

            this.lblSearch.Text = "Search:";
            this.lblSearch.Location = new System.Drawing.Point(10, 16);
            this.lblSearch.Size = new System.Drawing.Size(55, 22);
            this.lblSearch.ForeColor = System.Drawing.Color.Black;

            this.txtSearch.Location = new System.Drawing.Point(70, 14);
            this.txtSearch.Size = new System.Drawing.Size(220, 22);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            this.btnView.Text = "View";
            this.btnView.Location = new System.Drawing.Point(400, 13);
            this.btnView.Size = new System.Drawing.Size(75, 28);
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.ForeColor = System.Drawing.Color.Black;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnView.FlatAppearance.BorderSize = 1;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);

            this.btnPay.Text = "Pay Fine";
            this.btnPay.Location = new System.Drawing.Point(485, 13);
            this.btnPay.Size = new System.Drawing.Size(75, 28);
            this.btnPay.BackColor = System.Drawing.Color.White;
            this.btnPay.ForeColor = System.Drawing.Color.Black;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnPay.FlatAppearance.BorderSize = 1;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);

            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(570, 13);
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnRefresh.FlatAppearance.BorderSize = 1;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.dgvFines.Location = new System.Drawing.Point(40, 60);
            this.dgvFines.Size = new System.Drawing.Size(880, 500);
            this.dgvFines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFines.ReadOnly = true;
            this.dgvFines.RowHeadersVisible = false;
            this.dgvFines.RowTemplate.Height = 30;
            this.dgvFines.AllowUserToAddRows = false;
            this.dgvFines.AllowUserToResizeRows = false;
            this.dgvFines.AllowUserToResizeColumns = false;
            this.dgvFines.MultiSelect = false;
            this.dgvFines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFines.BackgroundColor = System.Drawing.Color.White;
            this.dgvFines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvFines.GridColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.dgvFines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvFines.ColumnHeadersHeight = 34;
            this.dgvFines.EnableHeadersVisualStyles = false;
            this.dgvFines.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.dgvFines.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvFines.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.dgvFines.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.dgvFines.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvFines.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvFines.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.dgvFines.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvFines.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 60, 120);
            this.dgvFines.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);

            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.btnView);
            this.pnlTop.Controls.Add(this.btnPay);
            this.pnlTop.Controls.Add(this.btnRefresh);

            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.dgvFines);
            this.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.Size = new System.Drawing.Size(920, 560);
            this.Load += new System.EventHandler(this.FinesView_Load);

            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}