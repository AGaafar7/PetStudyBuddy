
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace PetStudyBuddy
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Batteries_V2.Init();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            try
            {
                

                string con = @"Data Source=petStudyBuddy.db;";
                using (SqliteConnection MyConnection = new SqliteConnection(con))
                {
                    MyConnection.Open();
                    // Optional: show a success message for testing
                    // MessageBox.Show("Database connected: " + MyConnection.State);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection failed:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the app if DB connection fails
            }
            Application.Run(new Form1());
        }
    }
}