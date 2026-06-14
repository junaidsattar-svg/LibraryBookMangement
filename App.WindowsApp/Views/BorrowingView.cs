using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using App.WindowsApp.Forms;

namespace App.WindowsApp.Views
{
    public partial class BorrowingView : UserControl
    {
        private readonly string _connectionString;

        public BorrowingView(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void BorrowingView_Load(object sender, EventArgs e)
        {
            LoadBorrows();
            dgvBorrows.ClearSelection();
            dgvBorrows.CurrentCell = null;
        }

        private void LoadBorrows()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT br.BorrowId, b.Title AS BookTitle, m.FullName AS MemberName,
                    br.BorrowDate, br.DueDate, br.ReturnDate, br.Status
                    FROM BorrowRecords br
                    JOIN Books b ON br.BookId = b.BookId
                    JOIN Members m ON br.MemberId = m.MemberId", con);
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                dgvBorrows.DataSource = table;
                dgvBorrows.ClearSelection();
                dgvBorrows.CurrentCell = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new BorrowForm(_connectionString, null);
            if (form.ShowDialog() == DialogResult.OK)
                LoadBorrows();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvBorrows.SelectedRows.Count == 0) return;
            int borrowId = (int)dgvBorrows.SelectedRows[0].Cells["BorrowId"].Value;
            var form = new BorrowForm(_connectionString, borrowId, false, true);
            form.ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvBorrows.SelectedRows.Count == 0) return;
            string status = dgvBorrows.SelectedRows[0].Cells["Status"].Value.ToString();
            if (status == "Returned")
            {
                MessageBox.Show("This book is already returned.");
                return;
            }
            int borrowId = (int)dgvBorrows.SelectedRows[0].Cells["BorrowId"].Value;
            var form = new BorrowForm(_connectionString, borrowId, true);
            if (form.ShowDialog() == DialogResult.OK)
                LoadBorrows();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadBorrows();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT br.BorrowId, b.Title AS BookTitle, m.FullName AS MemberName,
                    br.BorrowDate, br.DueDate, br.ReturnDate, br.Status
                    FROM BorrowRecords br
                    JOIN Books b ON br.BookId = b.BookId
                    JOIN Members m ON br.MemberId = m.MemberId
                    WHERE b.Title LIKE @search OR m.FullName LIKE @search", con);
                cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                dgvBorrows.DataSource = table;
                dgvBorrows.ClearSelection();
                dgvBorrows.CurrentCell = null;
            }
        }
    }
}