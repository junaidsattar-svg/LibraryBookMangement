using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace App.WindowsApp.Forms
{
    public partial class ReservationForm : Form
    {
        private readonly string _connectionString;
        private readonly int? _reservationId;
        private readonly bool _isCancel;
        private readonly bool _isView;

        public ReservationForm(string connectionString, int? reservationId, bool isCancel = false, bool isView = false)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _reservationId = reservationId;
            _isCancel = isCancel;
            _isView = isView;
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadMembers();

            if (_reservationId.HasValue)
            {
                LoadReservation(_reservationId.Value);
                if (_isCancel)
                {
                    Text = "Cancel Reservation";
                    cmbBook.Enabled = true;
                    cmbMember.Enabled = true;
                    dtpReservationDate.Enabled = true;
                    dtpExpiryDate.Enabled = true;
                    btnSave.Text = "Cancel Reservation";
                }
                else if (_isView)
                {
                    Text = "View Reservation";
                    cmbBook.Enabled = true;
                    cmbMember.Enabled = true;
                    dtpReservationDate.Enabled = true;
                    dtpExpiryDate.Enabled = true;
                    btnSave.Visible = false;
                    btnClose.Text = "Close";
                }
                else
                {
                    Text = "Edit Reservation";
                }
            }
            else
            {
                Text = "Add Reservation";
                dtpReservationDate.Value = DateTime.Now;
                dtpExpiryDate.Value = DateTime.Now.AddDays(7);
            }
        }

        private void LoadBooks()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT BookId, Title FROM Books", con);
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

        private void LoadReservation(int reservationId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT r.*, b.Title, m.FullName FROM Reservations r
                    JOIN Books b ON r.BookId = b.BookId
                    JOIN Members m ON r.MemberId = m.MemberId
                    WHERE r.ReservationId = @id", con);
                cmd.Parameters.AddWithValue("@id", reservationId);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cmbBook.SelectedValue = reader["BookId"];
                        cmbMember.SelectedValue = reader["MemberId"];
                        dtpReservationDate.Value = Convert.ToDateTime(reader["ReservationDate"]);
                        dtpExpiryDate.Value = Convert.ToDateTime(reader["ExpiryDate"]);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_isCancel)
            {
                using (var con = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("UPDATE Reservations SET Status='Cancelled' WHERE ReservationId=@id", con);
                    cmd.Parameters.AddWithValue("@id", _reservationId.Value);
                    con.Open();
                    cmd.ExecuteNonQuery();
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
                var cmd = new SqlCommand(@"INSERT INTO Reservations (BookId, MemberId, ReservationDate, ExpiryDate, Status)
                    VALUES (@book, @member, @resDate, @expiry, 'Pending')", con);
                cmd.Parameters.AddWithValue("@book", cmbBook.SelectedValue);
                cmd.Parameters.AddWithValue("@member", cmbMember.SelectedValue);
                cmd.Parameters.AddWithValue("@resDate", dtpReservationDate.Value);
                cmd.Parameters.AddWithValue("@expiry", dtpExpiryDate.Value);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}