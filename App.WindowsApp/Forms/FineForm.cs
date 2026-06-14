using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace App.WindowsApp.Forms
{
    public partial class FineForm : Form
    {
        private readonly string _connectionString;
        private readonly int _fineId;
        private readonly bool _isPay;
        private readonly bool _isView;

        public FineForm(string connectionString, int fineId, bool isPay = false, bool isView = false)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _fineId = fineId;
            _isPay = isPay;
            _isView = isView;
        }

        private void FineForm_Load(object sender, EventArgs e)
        {
            LoadFine();
            if (_isPay)
            {
                Text = "Pay Fine";
                btnSave.Text = "Mark as Paid";
            }
            else if (_isView)
            {
                Text = "View Fine";
                btnSave.Visible = false;
                btnCancel.Text = "Close";
            }
        }

        private void LoadFine()
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT f.*, m.FullName FROM Fines f
                    JOIN Members m ON f.MemberId = m.MemberId
                    WHERE f.FineId = @id", con);
                cmd.Parameters.AddWithValue("@id", _fineId);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtMember.Text = reader["FullName"].ToString();
                        txtAmount.Text = reader["Amount"].ToString();
                        txtStatus.Text = reader["FineStatus"].ToString();
                        txtIssued.Text = Convert.ToDateTime(reader["IssuedDate"]).ToShortDateString();
                        txtPaid.Text = reader["PaidDate"] == DBNull.Value ? "" :
                                          Convert.ToDateTime(reader["PaidDate"]).ToShortDateString();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"UPDATE Fines SET FineStatus='Paid', PaidDate=@paid
                    WHERE FineId=@id", con);
                cmd.Parameters.AddWithValue("@paid", DateTime.Now);
                cmd.Parameters.AddWithValue("@id", _fineId);
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