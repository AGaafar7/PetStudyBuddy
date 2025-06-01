// Program.cs - Entry point for the Pet Study Buddy application
// Modified to start with MainForm instead of Form1

using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Windows.Forms;

namespace PetStudyBuddy
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize SQLite batteries for database support
            Batteries_V2.Init();

            // Initialize application configuration
            ApplicationConfiguration.Initialize();

            try
            {
                // Test database connection
                string dbPath = @"D:\Apps\VisualStudioSource\repos\PetStudyBuddy\PetStudyBuddy\petStudy.db";
                string connectionString = $"Data Source={dbPath};";

                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database connection failed:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // Start the application with MainForm
            Application.Run(new MainForm());
        }
    }
}