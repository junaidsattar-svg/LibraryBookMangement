using System;
using System.Configuration;
using System.Windows.Forms;

namespace App.WindowsApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionString = ConfigurationManager.ConnectionStrings["LibraryDB"].ConnectionString;

            Application.Run(new MainForm(connectionString));
        }
    }
}