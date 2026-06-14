using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace App.WindowsApp.Forms
{
    public partial class MemberForm : Form
    {
        private readonly string _connectionString;
        private readonly int? _memberId;
        private readonly bool _isDelete;
        private readonly bool _isView;

        public MemberForm(string connectionString, int? memberId, bool isDelete = false, bool isView = false)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _memberId = memberId;
            _isDelete = isDelete;
            _isView = isView;
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            if (_memberId.HasValue)
            {
                LoadMember(_memberId.Value);
                if (_isDelete)
                {
                    if (_isDelete)
                    {
                        Text = "Delete Member";
                        txtFullName.ReadOnly = true;
                        txtEmail.ReadOnly = true;
                        txtPhone.ReadOnly = true;
                        txtAddress.ReadOnly = true;
                        cmbStatus.Enabled = true;
                        dtpJoinDate.Enabled = true;
                        dtpExpiryDate.Enabled = true;
                        btnSave.Text = "Delete";
                        btnSave.BackColor = System.Drawing.Color.White;
                        btnSave.ForeColor = System.Drawing.Color.Black;
                        btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                        btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(200, 200, 200);
                    }
                    if (_isDelete)
                    {
                        
                    }
                }
                else if (_isView)
                {
                    Text = "View Member";
                    txtFullName.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtPhone.ReadOnly = true;
                    txtAddress.ReadOnly = true;
                    cmbStatus.Enabled = true;
                    dtpJoinDate.Enabled = true;
                    dtpExpiryDate.Enabled = true;
                    btnSave.Visible = false;
                    btnCancel.Text = "Close";
                }
                else
                {
                    Text = "Edit Member";
                }
            }
            else
            {
                Text = "Add Member";
                dtpJoinDate.Value = DateTime.Now;
                dtpExpiryDate.Value = DateTime.Now.AddYears(1);
            }
        }

        private void LoadMember(int memberId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("SELECT * FROM Members WHERE MemberId = @id", con);
                cmd.Parameters.AddWithValue("@id", memberId);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtFullName.Text = reader["FullName"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        txtPhone.Text = reader["Phone"].ToString();
                        txtAddress.Text = reader["Address"].ToString();
                        cmbStatus.Text = reader["MemberStatus"].ToString();
                        dtpJoinDate.Value = Convert.ToDateTime(reader["JoinDate"]);
                        dtpExpiryDate.Value = Convert.ToDateTime(reader["ExpiryDate"]);
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
                    var cmd = new SqlCommand("DELETE FROM Members WHERE MemberId = @id", con);
                    cmd.Parameters.AddWithValue("@id", _memberId.Value);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Full Name is required.");
                return;
            }

            using (var con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd;
                if (_memberId.HasValue)
                {
                    cmd = new SqlCommand(@"UPDATE Members SET FullName=@name, Email=@email,
                        Phone=@phone, Address=@address, MemberStatus=@status,
                        JoinDate=@join, ExpiryDate=@expiry WHERE MemberId=@id", con);
                    cmd.Parameters.AddWithValue("@id", _memberId.Value);
                }
                else
                {
                    cmd = new SqlCommand(@"INSERT INTO Members (FullName, Email, Phone, Address, MemberStatus, JoinDate, ExpiryDate)
                        VALUES (@name, @email, @phone, @address, @status, @join, @expiry)", con);
                }

                cmd.Parameters.AddWithValue("@name", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@join", dtpJoinDate.Value);
                cmd.Parameters.AddWithValue("@expiry", dtpExpiryDate.Value);

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