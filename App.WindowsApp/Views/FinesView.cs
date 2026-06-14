using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using App.WindowsApp.Forms;

namespace App.WindowsApp.Views
{
    public partial class FinesView : UserControl
    {
        private readonly string _connectionString;

        public FinesView(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void FinesView_Load(object sender, EventArgs e)
        {
            LoadFines();
            dgvFines.ClearSelection();
            dgvFines.CurrentCell = null;
        }

        private void LoadFines()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT f.FineId, m.FullName AS MemberName,
                    f.Amount, f.FineStatus, f.IssuedDate, f.PaidDate
                    FROM Fines f
                    JOIN Members m ON f.MemberId = m.MemberId", con);
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                dgvFines.DataSource = table;
                dgvFines.ClearSelection();
                dgvFines.CurrentCell = null;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvFines.SelectedRows.Count == 0) return;
            int fineId = (int)dgvFines.SelectedRows[0].Cells["FineId"].Value;
            var form = new FineForm(_connectionString, fineId, false, true);
            form.ShowDialog();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (dgvFines.SelectedRows.Count == 0) return;
            string status = dgvFines.SelectedRows[0].Cells["FineStatus"].Value.ToString();
            if (status == "Paid")
            {
                MessageBox.Show("This fine is already paid.");
                return;
            }
            int fineId = (int)dgvFines.SelectedRows[0].Cells["FineId"].Value;
            var form = new FineForm(_connectionString, fineId, true);
            if (form.ShowDialog() == DialogResult.OK)
                LoadFines();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadFines();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT f.FineId, m.FullName AS MemberName,
                    f.Amount, f.FineStatus, f.IssuedDate, f.PaidDate
                    FROM Fines f
                    JOIN Members m ON f.MemberId = m.MemberId
                    WHERE m.FullName LIKE @search", con);
                cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                dgvFines.DataSource = table;
                dgvFines.ClearSelection();
                dgvFines.CurrentCell = null;
            }
        }
    }
}