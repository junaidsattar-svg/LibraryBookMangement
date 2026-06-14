namespace App.WindowsApp.Views
{
    partial class ReservationsView
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnCancel;
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvReservations = new System.Windows.Forms.DataGridView();

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

            this.btnAdd.Text = "Add";
            this.btnAdd.Location = new System.Drawing.Point(400, 13);
            this.btnAdd.Size = new System.Drawing.Size(75, 28);
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnAdd.FlatAppearance.BorderSize = 1;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnView.Text = "View";
            this.btnView.Location = new System.Drawing.Point(485, 13);
            this.btnView.Size = new System.Drawing.Size(75, 28);
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.ForeColor = System.Drawing.Color.Black;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnView.FlatAppearance.BorderSize = 1;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.Location = new System.Drawing.Point(570, 13);
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnCancel.FlatAppearance.BorderSize = 1;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(655, 13);
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnRefresh.FlatAppearance.BorderSize = 1;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.dgvReservations.Location = new System.Drawing.Point(40, 60);
            this.dgvReservations.Size = new System.Drawing.Size(880, 500);
            this.dgvReservations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservations.ReadOnly = true;
            this.dgvReservations.RowHeadersVisible = false;
            this.dgvReservations.RowTemplate.Height = 30;
            this.dgvReservations.AllowUserToAddRows = false;
            this.dgvReservations.AllowUserToResizeRows = false;
            this.dgvReservations.AllowUserToResizeColumns = false;
            this.dgvReservations.MultiSelect = false;
            this.dgvReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservations.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvReservations.GridColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReservations.ColumnHeadersHeight = 34;
            this.dgvReservations.EnableHeadersVisualStyles = false;
            this.dgvReservations.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.dgvReservations.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReservations.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.dgvReservations.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.dgvReservations.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvReservations.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvReservations.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.dgvReservations.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvReservations.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 60, 120);
            this.dgvReservations.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);

            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Controls.Add(this.btnView);
            this.pnlTop.Controls.Add(this.btnCancel);
            this.pnlTop.Controls.Add(this.btnRefresh);

            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.dgvReservations);
            this.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.Size = new System.Drawing.Size(920, 560);
            this.Load += new System.EventHandler(this.ReservationsView_Load);

            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}