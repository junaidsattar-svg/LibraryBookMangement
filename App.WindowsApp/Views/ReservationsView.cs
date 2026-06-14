using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using App.WindowsApp.Forms;

namespace App.WindowsApp.Views
{
    public partial class ReservationsView : UserControl
    {
        private readonly string _connectionString;

        public ReservationsView(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void ReservationsView_Load(object sender, EventArgs e)
        {
            LoadReservations();
            dgvReservations.ClearSelection();
            dgvReservations.CurrentCell = null;
        }

        private void LoadReservations()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT r.ReservationId, b.Title AS BookTitle, m.FullName AS MemberName,
                    r.ReservationDate, r.ExpiryDate, r.Status
                    FROM Reservations r
                    JOIN Books b ON r.BookId = b.BookId
                    JOIN Members m ON r.MemberId = m.MemberId", con);
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                dgvReservations.DataSource = table;
                dgvReservations.ClearSelection();
                dgvReservations.CurrentCell = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new ReservationForm(_connectionString, null);
            if (form.ShowDialog() == DialogResult.OK)
                LoadReservations();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0) return;
            int id = (int)dgvReservations.SelectedRows[0].Cells["ReservationId"].Value;
            var form = new ReservationForm(_connectionString, id, false, true);
            form.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0) return;
            string status = dgvReservations.SelectedRows[0].Cells["Status"].Value.ToString();
            if (status == "Cancelled")
            {
                MessageBox.Show("This reservation is already cancelled.");
                return;
            }
            int id = (int)dgvReservations.SelectedRows[0].Cells["ReservationId"].Value;
            var form = new ReservationForm(_connectionString, id, true);
            if (form.ShowDialog() == DialogResult.OK)
                LoadReservations();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadReservations();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT r.ReservationId, b.Title AS BookTitle, m.FullName AS MemberName,
                    r.ReservationDate, r.ExpiryDate, r.Status
                    FROM Reservations r
                    JOIN Books b ON r.BookId = b.BookId
                    JOIN Members m ON r.MemberId = m.MemberId
                    WHERE b.Title LIKE @search OR m.FullName LIKE @search", con);
                cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                dgvReservations.DataSource = table;
                dgvReservations.ClearSelection();
                dgvReservations.CurrentCell = null;
            }
        }
    }
}