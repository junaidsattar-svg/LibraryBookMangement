namespace App.WindowsApp.Views
{
    partial class BooksView
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvBooks = new System.Windows.Forms.DataGridView();

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

            this.btnEdit.Text = "Edit";
            this.btnEdit.Location = new System.Drawing.Point(570, 13);
            this.btnEdit.Size = new System.Drawing.Size(75, 28);
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnEdit.FlatAppearance.BorderSize = 1;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(655, 13);
            this.btnDelete.Size = new System.Drawing.Size(75, 28);
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnDelete.FlatAppearance.BorderSize = 1;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(740, 13);
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.btnRefresh.FlatAppearance.BorderSize = 1;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.dgvBooks.Location = new System.Drawing.Point(40, 60);
            this.dgvBooks.Size = new System.Drawing.Size(880, 500);
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.RowTemplate.Height = 30;
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToResizeRows = false;
            this.dgvBooks.AllowUserToResizeColumns = false;
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvBooks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvBooks.GridColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBooks.ColumnHeadersHeight = 34;
            this.dgvBooks.EnableHeadersVisualStyles = false;
            this.dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBooks.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            this.dgvBooks.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.dgvBooks.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBooks.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvBooks.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(50, 50, 50);
            this.dgvBooks.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvBooks.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(0, 60, 120);
            this.dgvBooks.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 248, 255);

            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Controls.Add(this.btnView);
            this.pnlTop.Controls.Add(this.btnEdit);
            this.pnlTop.Controls.Add(this.btnDelete);
            this.pnlTop.Controls.Add(this.btnRefresh);

            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.dgvBooks);
            this.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.Size = new System.Drawing.Size(920, 560);
            this.Load += new System.EventHandler(this.BooksView_Load);

            this.pnlTop.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}