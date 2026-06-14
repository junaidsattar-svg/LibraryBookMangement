using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace App.WindowsApp.Forms
{
    public partial class BookForm : Form
    {
        private readonly string _connectionString;
        private readonly int? _bookId;
        private readonly bool _isDelete;
        private readonly bool _isView;

        public BookForm(string connectionString, int? bookId, bool isDelete = false, bool isView = false)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _bookId = bookId;
            _isDelete = isDelete;
            _isView = isView;
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            if (_bookId.HasValue)
            {
                LoadBook(_bookId.Value);
                if (_isDelete)
                {
                    Text = "Delete Book";
                    txtTitle.ReadOnly = true;
                    txtAuthor.ReadOnly = true;
                    txtISBN.ReadOnly = true;
                    txtPublisher.ReadOnly = true;
                    txtPublishYear.ReadOnly = true;
                    nudTotalCopies.Enabled = true;
                    cmbCategory.Enabled = true;
                    btnSave.Text = "Delete";
                    btnSave.BackColor = System.Drawing.Color.White;
                    btnSave.ForeColor = System.Drawing.Color.Black;
                    btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
                }
                else if (_isView)
                {
                    Text = "View Book";
                    txtTitle.ReadOnly = true;
                    txtAuthor.ReadOnly = true;
                    txtISBN.ReadOnly = true;
                    txtPublisher.ReadOnly = true;
                    txtPublishYear.ReadOnly = true;
                    nudTotalCopies.Enabled = true;
                    cmbCategory.Enabled = true;
                    btnSave.Visible = false;
                    btnCancel.Text = "Close";
                }
                else
                {
                    Text = "Edit Book";
                }
            }
            else
            {
                Text = "Add Book";
            }
        }

        private void LoadCategories()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT CategoryId, Name FROM Categories", con);
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                cmbCategory.DataSource = table;
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "CategoryId";
            }
        }

        private void LoadBook(int bookId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Books WHERE BookId = @id", con);
                cmd.Parameters.AddWithValue("@id", bookId);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtTitle.Text = reader["Title"].ToString();
                        txtAuthor.Text = reader["Author"].ToString();
                        txtISBN.Text = reader["ISBN"].ToString();
                        txtPublisher.Text = reader["Publisher"].ToString();
                        txtPublishYear.Text = reader["PublishYear"].ToString();
                        nudTotalCopies.Value = Convert.ToInt32(reader["TotalCopies"]);
                        cmbCategory.SelectedValue = reader["CategoryId"];
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_isDelete)
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("DELETE FROM Books WHERE BookId = @id", con);
                    cmd.Parameters.AddWithValue("@id", _bookId.Value);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Title and Author are required.");
                return;
            }

            using (var con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd;
                if (_bookId.HasValue)
                {
                    cmd = new SqlCommand(@"UPDATE Books SET Title=@title, Author=@author, ISBN=@isbn,
                        CategoryId=@cat, TotalCopies=@total, AvailCopies=@avail,
                        PublishYear=@year, Publisher=@pub WHERE BookId=@id", con);
                    cmd.Parameters.AddWithValue("@id", _bookId.Value);
                }
                else
                {
                    cmd = new SqlCommand(@"INSERT INTO Books (Title, Author, ISBN, CategoryId,
                        TotalCopies, AvailCopies, PublishYear, Publisher)
                        VALUES (@title, @author, @isbn, @cat, @total, @avail, @year, @pub)", con);
                }

                cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@author", txtAuthor.Text.Trim());
                cmd.Parameters.AddWithValue("@isbn", txtISBN.Text.Trim());
                cmd.Parameters.AddWithValue("@cat", cmbCategory.SelectedValue ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@total", (int)nudTotalCopies.Value);
                cmd.Parameters.AddWithValue("@avail", (int)nudTotalCopies.Value);
                cmd.Parameters.AddWithValue("@year", string.IsNullOrWhiteSpace(txtPublishYear.Text)
                    ? (object)DBNull.Value : int.Parse(txtPublishYear.Text));
                cmd.Parameters.AddWithValue("@pub", txtPublisher.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}