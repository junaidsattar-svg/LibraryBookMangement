using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using App.WindowsApp.Forms;

namespace App.WindowsApp.Views
{
    public partial class MembersView : UserControl
    {
        private readonly string _connectionString;

        public MembersView(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void MembersView_Load(object sender, EventArgs e)
        {
            LoadMembers();
            dgvMembers.ClearSelection();
            dgvMembers.CurrentCell = null;
        }

        private void LoadMembers()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT MemberId, FullName, Email, Phone, MemberStatus, JoinDate, ExpiryDate FROM Members", con);
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                dgvMembers.DataSource = table;
                dgvMembers.ClearSelection();
                dgvMembers.CurrentCell = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new MemberForm(_connectionString, null);
            if (form.ShowDialog() == DialogResult.OK)
                LoadMembers();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0) return;
            int memberId = (int)dgvMembers.SelectedRows[0].Cells["MemberId"].Value;
            var form = new MemberForm(_connectionString, memberId, false, true);
            form.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0) return;
            int memberId = (int)dgvMembers.SelectedRows[0].Cells["MemberId"].Value;
            var form = new MemberForm(_connectionString, memberId);
            if (form.ShowDialog() == DialogResult.OK)
                LoadMembers();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count == 0) return;
            int memberId = (int)dgvMembers.SelectedRows[0].Cells["MemberId"].Value;
            var form = new MemberForm(_connectionString, memberId, true);
            if (form.ShowDialog() == DialogResult.OK)
                LoadMembers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadMembers();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT MemberId, FullName, Email, Phone, MemberStatus, JoinDate, ExpiryDate FROM Members WHERE FullName LIKE @search OR Email LIKE @search OR Phone LIKE @search", con);
                cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                dgvMembers.DataSource = table;
                dgvMembers.ClearSelection();
                dgvMembers.CurrentCell = null;
            }
        }
    }
}