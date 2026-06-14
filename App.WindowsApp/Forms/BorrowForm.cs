using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace App.WindowsApp.Forms
{
    public partial class BorrowForm : Form
    {
        private readonly string _connectionString;
        private readonly int? _borrowId;
        private readonly bool _isReturn;
        private readonly bool _isView;

        public BorrowForm(string connectionString, int? borrowId, bool isReturn = false, bool isView = false)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _borrowId = borrowId;
            _isReturn = isReturn;
            _isView = isView;
        }

        private void BorrowForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadMembers();

            if (_borrowId.HasValue)
            {
                LoadBorrow(_borrowId.Value);
                if (_isReturn)
                {
                    Text = "Return Book";
                    cmbBook.Enabled = true;
                    cmbMember.Enabled = true;
                    dtpBorrowDate.Enabled = true;
                    dtpDueDate.Enabled = true;
                    btnSave.Text = "Return";
                }
                else if (_isView)
                {
                    Text = "View Borrow Record";
                    cmbBook.Enabled = true;
                    cmbMember.Enabled = true;
                    dtpBorrowDate.Enabled = true;
                    dtpDueDate.Enabled = true;
                    btnSave.Visible = false;
                    btnCancel.Text = "Close";
                }
                else
                {
                    Text = "Edit Borrow Record";
                }
            }
            else
            {
                Text = "Borrow Book";
                dtpBorrowDate.Value = DateTime.Now;
                dtpDueDate.Value = DateTime.Now.AddDays(14);
            }
        }

        private void LoadBooks()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT BookId, Title FROM Books WHERE AvailCopies > 0", con);
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                cmbBook.DataSource = table;
                cmbBook.DisplayMember = "Title";
                cmbBook.ValueMember = "BookId";
            }
        }

        private void LoadMembers()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT MemberId, FullName FROM Members WHERE MemberStatus = 'Active'", con);
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                cmbMember.DataSource = table;
                cmbMember.DisplayMember = "FullName";
                cmbMember.ValueMember = "MemberId";
            }
        }

        private void LoadBorrow(int borrowId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT br.*, b.Title, m.FullName FROM BorrowRecords br
                    JOIN Books b ON br.BookId = b.BookId
                    JOIN Members m ON br.MemberId = m.MemberId
                    WHERE br.BorrowId = @id", con);
                cmd.Parameters.AddWithValue("@id", borrowId);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cmbBook.SelectedValue = reader["BookId"];
                        cmbMember.SelectedValue = reader["MemberId"];
                        dtpBorrowDate.Value = Convert.ToDateTime(reader["BorrowDate"]);
                        dtpDueDate.Value = Convert.ToDateTime(reader["DueDate"]);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_isReturn)
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    var cmd = new SqlCommand(@"UPDATE BorrowRecords SET ReturnDate=@ret, Status='Returned'
                        WHERE BorrowId=@id", con);
                    cmd.Parameters.AddWithValue("@ret", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id", _borrowId.Value);
                    cmd.ExecuteNonQuery();

                    var cmdAvail = new SqlCommand(@"UPDATE Books SET AvailCopies = AvailCopies + 1
                        WHERE BookId = (SELECT BookId FROM BorrowRecords WHERE BorrowId = @id)", con);
                    cmdAvail.Parameters.AddWithValue("@id", _borrowId.Value);
                    cmdAvail.ExecuteNonQuery();
                }
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            if (cmbBook.SelectedValue == null || cmbMember.SelectedValue == null)
            {
                MessageBox.Show("Please select Book and Member.");
                return;
            }

            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var cmd = new SqlCommand(@"INSERT INTO BorrowRecords (BookId, MemberId, BorrowDate, DueDate, Status)
                    VALUES (@book, @member, @borrow, @due, 'Borrowed')", con);
                cmd.Parameters.AddWithValue("@book", cmbBook.SelectedValue);
                cmd.Parameters.AddWithValue("@member", cmbMember.SelectedValue);
                cmd.Parameters.AddWithValue("@borrow", dtpBorrowDate.Value);
                cmd.Parameters.AddWithValue("@due", dtpDueDate.Value);
                cmd.ExecuteNonQuery();

                var cmdAvail = new SqlCommand(@"UPDATE Books SET AvailCopies = AvailCopies - 1
                    WHERE BookId = @book", con);
                cmdAvail.Parameters.AddWithValue("@book", cmbBook.SelectedValue);
                cmdAvail.ExecuteNonQuery();
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