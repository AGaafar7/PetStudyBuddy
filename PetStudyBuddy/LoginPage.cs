using Microsoft.Data.Sqlite;
using PetStudyBuddy.DataModels;
using System.Data;
using System.Diagnostics;


namespace PetStudyBuddy
{
    public partial class Form1 : Form
    {
        private DatabaseManager dbManager;
        public Form1()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
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
                User user = dbManager.GetCurrentUser(username, password);

                if (user != null)
                {
                    MessageBox.Show("Login successful!");
                    MainPage mainForm = new MainPage();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
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
