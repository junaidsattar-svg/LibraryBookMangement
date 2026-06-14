namespace App.WindowsApp.Views
{
    partial class BorrowingView
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvBorrows;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnReturn;
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
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvBorrows = new System.Windows.Forms.DataGridView();

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

            this.btnAdd.Text = "Borrow Book";
            this.btnAdd.Location = new System.Drawing.Point(400, 13);
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnAdd.FlatAppearance.BorderSize = 1;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnView.Text = "View";
            this.btnView.Location = new System.Drawing.Point(510, 13);
            this.btnView.Size = new System.Drawing.Size(75, 28);
            this.btnView.BackColor = System.Drawing.Color.White;
            this.btnView.ForeColor = System.Drawing.Color.Black;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnView.FlatAppearance.BorderSize = 1;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);

            this.btnReturn.Text = "Return Book";
            this.btnReturn.Location = new System.Drawing.Point(595, 13);
            this.btnReturn.Size = new System.Drawing.Size(100, 28);
            this.btnReturn.BackColor = System.Drawing.Color.White;
            this.btnReturn.ForeColor = System.Drawing.Color.Black;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnReturn.FlatAppearance.BorderSize = 1;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);

            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(705, 13);
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnRefresh.FlatAppearance.BorderSize = 1;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.dgvBorrows.Location = new System.Drawing.Point(40, 60);
            this.dgvBorrows.Size = new System.Drawing.Size(880, 500);
            this.dgvBorrows.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBorrows.ReadOnly = true;
            this.dgvBorrows.RowHeadersVisible = false;
            this.dgvBorrows.RowTemplate.Height = 30;
            this.dgvBorrows.AllowUserToAddRows = false;
            this.dgvBorrows.AllowUserToResizeRows = false;
            this.dgvBorrows.AllowUserToResizeColumns = false;
            this.dgvBorrows.MultiSelect = false;
            this.dgvBorrows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBorrows.BackgroundColor = System.Drawing.Color.White;
            this.dgvBorrows.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvBorrows.GridColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.dgvBorrows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBorrows.ColumnHeadersHeight = 34;
            this.dgvBorrows.EnableHeadersVisualStyles = false;
            this.dgvBorrows.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.dgvBorrows.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBorrows.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.dgvBorrows.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.dgvBorrows.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBorrows.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvBorrows.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.dgvBorrows.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvBorrows.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 60, 120);
            this.dgvBorrows.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);

            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Controls.Add(this.btnView);
            this.pnlTop.Controls.Add(this.btnReturn);
            this.pnlTop.Controls.Add(this.btnRefresh);

            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.dgvBorrows);
            this.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.Size = new System.Drawing.Size(920, 560);
            this.Load += new System.EventHandler(this.BorrowingView_Load);

            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}