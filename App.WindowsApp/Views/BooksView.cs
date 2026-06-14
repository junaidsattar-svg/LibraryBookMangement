using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using App.WindowsApp.Forms;

namespace App.WindowsApp.Views
{
    public partial class BooksView : UserControl
    {
        private readonly string _connectionString;

        public BooksView(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void BooksView_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT BookId, Title, Author, ISBN, TotalCopies, AvailCopies, Status FROM Books", con);
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                dgvBooks.DataSource = table;
                dgvBooks.ClearSelection();
                dgvBooks.CurrentCell = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new BookForm(_connectionString, null);
            if (form.ShowDialog() == DialogResult.OK)
                LoadBooks();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0) return;
            int bookId = (int)dgvBooks.SelectedRows[0].Cells["BookId"].Value;
            var form = new BookForm(_connectionString, bookId, false, true);
            form.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0) return;
            int bookId = (int)dgvBooks.SelectedRows[0].Cells["BookId"].Value;
            var form = new BookForm(_connectionString, bookId);
            if (form.ShowDialog() == DialogResult.OK)
                LoadBooks();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0) return;
            int bookId = (int)dgvBooks.SelectedRows[0].Cells["BookId"].Value;
            var form = new BookForm(_connectionString, bookId, true);
            if (form.ShowDialog() == DialogResult.OK)
                LoadBooks();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadBooks();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT BookId, Title, Author, ISBN, TotalCopies, AvailCopies, Status FROM Books WHERE Title LIKE @search OR Author LIKE @search", con);
                cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                dgvBooks.DataSource = table;
                dgvBooks.ClearSelection();
                dgvBooks.CurrentCell = null;
            }
        }
    }
}