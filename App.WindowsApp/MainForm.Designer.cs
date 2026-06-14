namespace App.WindowsApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnBooks;
        private System.Windows.Forms.Button btnMembers;
        private System.Windows.Forms.Button btnBorrowing;
        private System.Windows.Forms.Button btnReservations;
        private System.Windows.Forms.Button btnFines;
        private System.Windows.Forms.Button btnCharts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.btnBooks = new System.Windows.Forms.Button();
            this.btnMembers = new System.Windows.Forms.Button();
            this.btnBorrowing = new System.Windows.Forms.Button();
            this.btnReservations = new System.Windows.Forms.Button();
            this.btnFines = new System.Windows.Forms.Button();
            this.btnCharts = new System.Windows.Forms.Button();

            this.pnlSidebar.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();

            this.pnlSidebar.Controls.Add(this.btnCharts);
            this.pnlSidebar.Controls.Add(this.btnFines);
            this.pnlSidebar.Controls.Add(this.btnReservations);
            this.pnlSidebar.Controls.Add(this.btnBorrowing);
            this.pnlSidebar.Controls.Add(this.btnMembers);
            this.pnlSidebar.Controls.Add(this.btnBooks);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(190, 680);
            this.pnlSidebar.TabIndex = 1;

            this.pnlContent.Controls.Add(this.pnlHeader);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.pnlContent.Location = new System.Drawing.Point(190, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(910, 680);
            this.pnlContent.TabIndex = 0;

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(910, 62);
            this.pnlHeader.TabIndex = 0;

            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 80);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(190, 55);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "  Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);

            this.btnBooks.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.btnBooks.FlatAppearance.BorderSize = 0;
            this.btnBooks.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.btnBooks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBooks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBooks.Location = new System.Drawing.Point(0, 145);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnBooks.Size = new System.Drawing.Size(190, 55);
            this.btnBooks.TabIndex = 1;
            this.btnBooks.Text = "  Books";
            this.btnBooks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBooks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBooks.UseVisualStyleBackColor = false;
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);

            this.btnMembers.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.btnMembers.FlatAppearance.BorderSize = 0;
            this.btnMembers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.btnMembers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMembers.Location = new System.Drawing.Point(0, 210);
            this.btnMembers.Name = "btnMembers";
            this.btnMembers.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnMembers.Size = new System.Drawing.Size(190, 55);
            this.btnMembers.TabIndex = 2;
            this.btnMembers.Text = "  Members";
            this.btnMembers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMembers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMembers.UseVisualStyleBackColor = false;
            this.btnMembers.Click += new System.EventHandler(this.btnMembers_Click);

            this.btnBorrowing.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.btnBorrowing.FlatAppearance.BorderSize = 0;
            this.btnBorrowing.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.btnBorrowing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrowing.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrowing.Location = new System.Drawing.Point(0, 275);
            this.btnBorrowing.Name = "btnBorrowing";
            this.btnBorrowing.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnBorrowing.Size = new System.Drawing.Size(190, 55);
            this.btnBorrowing.TabIndex = 3;
            this.btnBorrowing.Text = "  Borrowing";
            this.btnBorrowing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrowing.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBorrowing.UseVisualStyleBackColor = false;
            this.btnBorrowing.Click += new System.EventHandler(this.btnBorrowing_Click);

            this.btnReservations.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.btnReservations.FlatAppearance.BorderSize = 0;
            this.btnReservations.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.btnReservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservations.Location = new System.Drawing.Point(0, 340);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnReservations.Size = new System.Drawing.Size(190, 55);
            this.btnReservations.TabIndex = 4;
            this.btnReservations.Text = "  Reservations";
            this.btnReservations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservations.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReservations.UseVisualStyleBackColor = false;
            this.btnReservations.Click += new System.EventHandler(this.btnReservations_Click);

            this.btnFines.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.btnFines.FlatAppearance.BorderSize = 0;
            this.btnFines.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.btnFines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFines.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFines.Location = new System.Drawing.Point(0, 405);
            this.btnFines.Name = "btnFines";
            this.btnFines.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnFines.Size = new System.Drawing.Size(190, 55);
            this.btnFines.TabIndex = 5;
            this.btnFines.Text = "  Fines";
            this.btnFines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFines.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFines.UseVisualStyleBackColor = false;
            this.btnFines.Click += new System.EventHandler(this.btnFines_Click);

            this.btnCharts.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.btnCharts.FlatAppearance.BorderSize = 0;
            this.btnCharts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(220, 220, 220);
            this.btnCharts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCharts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCharts.Location = new System.Drawing.Point(0, 470);
            this.btnCharts.Name = "btnCharts";
            this.btnCharts.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnCharts.Size = new System.Drawing.Size(190, 55);
            this.btnCharts.TabIndex = 6;
            this.btnCharts.Text = "  Charts";
            this.btnCharts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCharts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCharts.UseVisualStyleBackColor = false;
            this.btnCharts.Click += new System.EventHandler(this.btnCharts_Click);

            this.BackColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);

            this.pnlSidebar.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}