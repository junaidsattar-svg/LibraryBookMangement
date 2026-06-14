using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace App.WindowsApp.Views
{
    public partial class ChartsView : UserControl
    {
        private readonly string _connectionString;

        public ChartsView(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void ChartsView_Load(object sender, EventArgs e)
        {
            this.Paint += ChartsView_Paint;
            this.Invalidate();
        }

        private void ChartsView_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            DrawBarChart(g);
            DrawPieChart(g);
        }

        private void DrawBarChart(Graphics g)
        {
            int borrowed = 0, returned = 0, overdue = 0;
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT Status, COUNT(*) FROM BorrowRecords GROUP BY Status", con);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string status = reader[0].ToString();
                        int count = (int)reader[1];
                        if (status == "Borrowed") borrowed = count;
                        if (status == "Returned") returned = count;
                        if (status == "Overdue") overdue = count;
                    }
                }
            }

            // Title
            g.DrawString("Borrowing Status (Bar Chart)", new Font("Segoe UI", 12f, FontStyle.Bold),
                new SolidBrush(Color.FromArgb(0, 102, 204)), 40, 20);

            int[] values = { borrowed, returned, overdue };
            string[] labels = { "Borrowed", "Returned", "Overdue" };
            Color[] colors = { Color.SteelBlue, Color.SeaGreen, Color.Tomato };

            int maxVal = Math.Max(Math.Max(borrowed, returned), Math.Max(overdue, 1));
            int chartX = 60, chartY = 60, chartH = 220, barW = 80, gap = 40;

            for (int i = 0; i < 3; i++)
            {
                int barH = (int)((float)values[i] / maxVal * chartH);
                int x = chartX + i * (barW + gap);
                int y = chartY + chartH - barH;

                g.FillRectangle(new SolidBrush(colors[i]), x, y, barW, barH);
                g.DrawRectangle(Pens.Gray, x, y, barW, barH);
                g.DrawString(values[i].ToString(), new Font("Segoe UI", 9f, FontStyle.Bold),
                    Brushes.Black, x + 30, y - 20);
                g.DrawString(labels[i], new Font("Segoe UI", 9f),
                    Brushes.Black, x + 5, chartY + chartH + 5);
            }

            // Y axis line
            g.DrawLine(Pens.Gray, chartX - 5, chartY, chartX - 5, chartY + chartH);
            g.DrawLine(Pens.Gray, chartX - 5, chartY + chartH, chartX + 3 * (barW + gap), chartY + chartH);
        }

        private void DrawPieChart(Graphics g)
        {
            int available = 0, unavailable = 0;
            using (var con = new SqlConnection(_connectionString))
            {
                con.Open();
                var cmd = new SqlCommand("SELECT SUM(AvailCopies), SUM(TotalCopies - AvailCopies) FROM Books", con);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        available = reader[0] == DBNull.Value ? 0 : (int)reader[0];
                        unavailable = reader[1] == DBNull.Value ? 0 : (int)reader[1];
                    }
                }
            }

            // Title
            g.DrawString("Book Availability (Pie Chart)", new Font("Segoe UI", 12f, FontStyle.Bold),
                new SolidBrush(Color.FromArgb(0, 102, 204)), 480, 20);

            int total = available + unavailable;
            if (total == 0) total = 1;

            float availAngle = (float)available / total * 360f;
            float unavailAngle = (float)unavailable / total * 360f;

            Rectangle pieRect = new Rectangle(500, 60, 250, 250);

            g.FillPie(new SolidBrush(Color.SeaGreen), pieRect, 0, availAngle);
            g.FillPie(new SolidBrush(Color.Tomato), pieRect, availAngle, unavailAngle);
            g.DrawPie(Pens.White, pieRect, 0, availAngle);
            g.DrawPie(Pens.White, pieRect, availAngle, unavailAngle);

            // Legend
            g.FillRectangle(new SolidBrush(Color.SeaGreen), 510, 330, 20, 20);
            g.DrawString($"Available ({available})", new Font("Segoe UI", 10f), Brushes.Black, 540, 330);

            g.FillRectangle(new SolidBrush(Color.Tomato), 510, 360, 20, 20);
            g.DrawString($"Borrowed Out ({unavailable})", new Font("Segoe UI", 10f), Brushes.Black, 540, 360);
        }
    }
}