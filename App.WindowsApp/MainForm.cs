using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using App.WindowsApp.Views;

namespace App.WindowsApp
{
    public partial class MainForm : Form
    {
        private readonly string _connectionString;
        private Button _activeNavButton;
        private string _resourcesPath;

        public MainForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _resourcesPath = Path.GetFullPath(Path.Combine(basePath, "..", "..", "Resources"));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private Bitmap LoadIcon(string fileName, int size = 24)
        {
            try
            {
                string fullPath = Path.Combine(_resourcesPath, fileName);
                return new Bitmap(Image.FromFile(fullPath), new Size(size, size));
            }
            catch
            {
                return new Bitmap(size, size);
            }
        }

        private void ApplyTheme()
        {
            Color bgColor = Color.FromArgb(235, 235, 235);

            this.BackColor = bgColor;
            pnlSidebar.BackColor = bgColor;
            pnlContent.BackColor = bgColor;
            pnlHeader.BackColor = bgColor;

            foreach (Control c in pnlSidebar.Controls)
            {
                if (c is Button btn)
                {
                    btn.BackColor = bgColor;
                    btn.ForeColor = Color.Black;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 220, 220);
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.Padding = new Padding(15, 0, 0, 0);
                    btn.Cursor = Cursors.Hand;
                    btn.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
                }
            }

            btnDashboard.Image = LoadIcon("dashboard.png");
            btnBooks.Image = LoadIcon("books.png");
            btnMembers.Image = LoadIcon("members.png");
            btnBorrowing.Image = LoadIcon("borrowing.png");
            btnReservations.Image = LoadIcon("reservations.png");
            btnFines.Image = LoadIcon("fines.png");
            btnCharts.Image = LoadIcon("dashboard.png");
            PictureBox picLogo = new PictureBox();
            picLogo.Image = LoadIcon("books.png", 30);
            picLogo.Size = new Size(30, 30);
            picLogo.Location = new Point(15, 16);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.BackColor = bgColor;
            pnlHeader.Controls.Add(picLogo);
            Label lblAppTitle = new Label();
            lblAppTitle.Text = "Library Book Management";
            lblAppTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.FromArgb(0, 120, 215);
            lblAppTitle.Location = new Point(52, 18);
            lblAppTitle.Size = new Size(320, 28);
            lblAppTitle.BackColor = bgColor;
            pnlHeader.Controls.Add(lblAppTitle);

            try
            {
                PictureBox picAdmin = new PictureBox();
                picAdmin.Image = LoadIcon("admin.png", 32);
                picAdmin.Size = new Size(32, 32);
                picAdmin.Location = new Point(pnlHeader.Width - 130, 15);
                picAdmin.SizeMode = PictureBoxSizeMode.StretchImage;
                picAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                picAdmin.BackColor = bgColor;
                pnlHeader.Controls.Add(picAdmin);
            }
            catch { }

            // Admin label
            Label lblAdmin = new Label();
            lblAdmin.Text = "Admin";
            lblAdmin.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblAdmin.ForeColor = Color.Black;
            lblAdmin.Size = new Size(70, 30);
            lblAdmin.Location = new Point(pnlHeader.Width - 92, 18);
            lblAdmin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAdmin.BackColor = bgColor;
            pnlHeader.Controls.Add(lblAdmin);
        }

        private void SetActiveNavButton(Button btn)
        {
            if (btn == null) return;
            Color bgColor = Color.FromArgb(235, 235, 235);
            if (_activeNavButton != null)
            {
                _activeNavButton.BackColor = bgColor;
                _activeNavButton.ForeColor = Color.Black;
                _activeNavButton.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            }
            _activeNavButton = btn;
            _activeNavButton.BackColor = Color.FromArgb(210, 210, 210);
            _activeNavButton.ForeColor = Color.Black;
            _activeNavButton.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
        }

        private void ShowView<T>(Func<T> factory) where T : UserControl
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(pnlHeader);
            var view = factory();
            view.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(view);
            view.BringToFront();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnDashboard);
            ShowView(() => new DashboardView(_connectionString));
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnBooks);
            ShowView(() => new BooksView(_connectionString));
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnMembers);
            ShowView(() => new MembersView(_connectionString));
        }

        private void btnBorrowing_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnBorrowing);
            ShowView(() => new BorrowingView(_connectionString));
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnReservations);
            ShowView(() => new ReservationsView(_connectionString));
        }

        private void btnFines_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnFines);
            ShowView(() => new FinesView(_connectionString));
        }

        private void btnCharts_Click(object sender, EventArgs e)
        {
            SetActiveNavButton(btnCharts);
            ShowView(() => new ChartsView(_connectionString));
        }
    }
}