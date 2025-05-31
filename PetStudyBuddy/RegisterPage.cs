using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PetStudyBuddy
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();
            registerBTN.Click += registerHandler;
        }

        private void registerHandler(object sender, EventArgs e)
        {
            // TODO: Implement registration logic here


        }


        private void registerBTN_Click(object sender, EventArgs e)
        {
            string firstName = firstNameField.Text.Trim();
            string lastName = lastNameField.Text.Trim();
            string userName = userNameField.Text.Trim();
            string password = passwordField.Text.Trim();

            //got inputs in the above variables
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            else
            {
                try
                {

                    string dbPath = @"D:\Apps\VisualStudioSource\repos\PetStudyBuddy\PetStudyBuddy\petStudy.db";
                    string con = $"Data Source={dbPath};";

                    using (var connection = new SqliteConnection(con))
                    {
                        connection.Open();

                        string query = "INSERT INTO users (firstname, lastname, username, password, petid, petlevel) VALUES (@firstName, @lastName, @username, @password, '101', 1)";

                        using (var cmdd = new SqliteCommand(query, connection))
                        {
                            cmdd.Parameters.AddWithValue("@firstName", firstName);
                            cmdd.Parameters.AddWithValue("@lastName", lastName);
                            cmdd.Parameters.AddWithValue("@username", userName);
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
                                MessageBox.Show("Invalid email or password.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error during login: " + ex.Message);
                }
               
            }

        }
    }
}
