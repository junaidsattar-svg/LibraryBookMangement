using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace App.WindowsApp.Views
{
    public partial class DashboardView : UserControl
    {
        private readonly string _connectionString;

        public DashboardView(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void DashboardView_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            this.Controls.Clear();
            this.BackColor = Color.FromArgb(235, 235, 235);
            this.Padding = new Padding(40, 0, 0, 0);

            Label lblTitle = new Label();
            lblTitle.Text = "Dashboard Overview";
            lblTitle.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 102, 204);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(400, 32);
            lblTitle.BackColor = Color.Transparent;
            this.Controls.Add(lblTitle);

            string totalBooks = GetCount("SELECT COUNT(*) FROM Books").ToString();
            string totalMembers = GetCount("SELECT COUNT(*) FROM Members WHERE MemberStatus='Active'").ToString();
            string activeBorrows = GetCount("SELECT COUNT(*) FROM BorrowRecords WHERE Status='Borrowed'").ToString();
            string pendingReservations = GetCount("SELECT COUNT(*) FROM Reservations WHERE Status='Pending'").ToString();
            string pendingFines = "Rs " + GetSum("SELECT ISNULL(SUM(Amount),0) FROM Fines WHERE FineStatus='Pending'").ToString();

            int cardY = 58;
            AddStatCard("Total Books", totalBooks, "📚", Color.FromArgb(0, 102, 204), 20, cardY);
            AddStatCard("Total Members", totalMembers, "👥", Color.FromArgb(0, 153, 76), 205, cardY);
            AddStatCard("Active Borrowings", activeBorrows, "📖", Color.FromArgb(230, 126, 34), 390, cardY);
            AddStatCard("Reservations", pendingReservations, "📌", Color.FromArgb(192, 57, 43), 575, cardY);
            AddStatCard("Pending Fines", pendingFines, "💰", Color.FromArgb(130, 50, 190), 760, cardY);

            Panel pnlSectionHeader = new Panel();
            pnlSectionHeader.Size = new Size(960, 36);
            pnlSectionHeader.Location = new Point(20, 200);
            pnlSectionHeader.BackColor = Color.White;
            this.Controls.Add(pnlSectionHeader);

            Label lblRecent = new Label();
            lblRecent.Text = "  📋  Recent Borrowing Activity";
            lblRecent.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblRecent.ForeColor = Color.FromArgb(0, 102, 204);
            lblRecent.Dock = DockStyle.Fill;
            lblRecent.TextAlign = ContentAlignment.MiddleLeft;
            lblRecent.BackColor = Color.Transparent;
            pnlSectionHeader.Controls.Add(lblRecent);

            DataGridView dgv = new DataGridView();
            dgv.Location = new Point(20, 236);
            dgv.Size = new Size(960, 200);
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.Font = new Font("Segoe UI", 9);
            dgv.GridColor = Color.FromArgb(220, 220, 220);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgv.ScrollBars = ScrollBars.None;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(0, 102, 204);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 102, 204);
            dgv.ColumnHeadersHeight = 34;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgv.DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 230, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 60, 120);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 255);
            dgv.RowTemplate.Height = 32;

            dgv.Columns.Add("MemberName", "Member Name");
            dgv.Columns.Add("BookTitle", "Book Title");
            dgv.Columns.Add("IssueDate", "Issue Date");
            dgv.Columns.Add("DueDate", "Due Date");
            dgv.Columns.Add("Status", "Status");

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.Resizable = DataGridViewTriState.False;
            }

            dgv.Columns[0].Width = 190;
            dgv.Columns[1].Width = 260;
            dgv.Columns[2].Width = 130;
            dgv.Columns[3].Width = 130;
            dgv.Columns[4].Width = 120;

            LoadRecentBorrows(dgv);

            this.Controls.Add(dgv);
            dgv.ClearSelection();
            dgv.CurrentCell = null;
        }

        private void LoadRecentBorrows(DataGridView dgv)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(@"SELECT TOP 10
                    m.FullName AS MemberName,
                    b.Title AS BookTitle,
                    CONVERT(VARCHAR, br.BorrowDate, 106) AS IssueDate,
                    CONVERT(VARCHAR, br.DueDate, 106) AS DueDate,
                    br.Status
                    FROM BorrowRecords br
                    JOIN Books b ON br.BookId = b.BookId
                    JOIN Members m ON br.MemberId = m.MemberId
                    ORDER BY br.BorrowDate DESC", con);
                con.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgv.Rows.Add(
                            reader["MemberName"].ToString(),
                            reader["BookTitle"].ToString(),
                            reader["IssueDate"].ToString(),
                            reader["DueDate"].ToString(),
                            " " + reader["Status"].ToString()
                        );
                    }
                }
            }
        }

        private int GetCount(string query)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(query, con);
                con.Open();
                var result = cmd.ExecuteScalar();
                return result == DBNull.Value || result == null ? 0 : Convert.ToInt32(result);
            }
        }

        private decimal GetSum(string query)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand(query, con);
                con.Open();
                var result = cmd.ExecuteScalar();
                return result == DBNull.Value || result == null ? 0 : Convert.ToDecimal(result);
            }
        }

        private void AddStatCard(string title, string value, string icon, Color color, int x, int y)
        {
            Panel card = new Panel();
            card.Size = new Size(172, 110);
            card.Location = new Point(x, y);
            card.BackColor = Color.White;
            card.Cursor = Cursors.Hand;

            card.Paint += (s, e) =>
            {
                e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, 5, card.Height);
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(220, 220, 220), 1), 0, 0, card.Width - 1, card.Height - 1);
            };

            Label lblIcon = new Label();
            lblIcon.Text = icon;
            lblIcon.Font = new Font("Segoe UI", 16);
            lblIcon.Location = new Point(118, 10);
            lblIcon.Size = new Size(45, 38);
            lblIcon.BackColor = Color.Transparent;
            card.Controls.Add(lblIcon);

            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblValue.ForeColor = color;
            lblValue.Location = new Point(12, 15);
            lblValue.Size = new Size(150, 30);
            lblValue.BackColor = Color.Transparent;
            card.Controls.Add(lblValue);

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 8);
            lblTitle.ForeColor = Color.FromArgb(120, 120, 120);
            lblTitle.Location = new Point(12, 50);
            lblTitle.Size = new Size(150, 18);
            lblTitle.BackColor = Color.Transparent;
            card.Controls.Add(lblTitle);

            Panel divider = new Panel();
            divider.Size = new Size(card.Width - 6, 2);
            divider.Location = new Point(5, card.Height - 15);
            divider.BackColor = color;
            card.Controls.Add(divider);

            this.Controls.Add(card);
        }
    }
}