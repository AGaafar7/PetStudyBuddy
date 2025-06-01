using Microsoft.Data.Sqlite;
using System.Data;
using System.Diagnostics;


namespace PetStudyBuddy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loginButton.Click += loginHandler;
            register.Click += registerHandler;
            

        }

        private void loginHandler(object sender, EventArgs e) {
           
            string username = emailField.Text.Trim();
            string password = passwordField.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            try
            {


                string dbPath = @"D:\Apps\VisualStudioSource\repos\PetStudyBuddy\PetStudyBuddy\petStudy.db";
                string con = $"Data Source={dbPath};";

                using (var connection = new SqliteConnection(con))
                {
                    connection.Open();
                  
                    string query = "SELECT COUNT(1) FROM users WHERE username = @username AND password = @password";

                    using (var cmdd = new SqliteCommand(query, connection))
                    {
                        cmdd.Parameters.AddWithValue("@username", username);
                        cmdd.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(cmdd.ExecuteScalar());

                        if (count == 1)
                        {
                            MessageBox.Show("Login successful!");

                            // TODO: Navigate to the main screen here
                            // Example:
                            // MainForm mainForm = new MainForm();
                            // mainForm.Show();
                            // this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message);
            }
        }

        private void registerHandler(object sender, EventArgs e)
        {
            RegisterPage registerPage = new RegisterPage();
            registerPage.Show();
            this.Hide();
        }

    }
}
