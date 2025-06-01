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
            loginBTN.Click += navLoginHandler;
           pictureBox1.Click += imageOneClickHandler;
           pictureBox2.Click += imageTwoClickHandler;
              pictureBox3.Click += imageThreeClickHandler;
              pictureBox4.Click += imageFourClickHandler;
        }
        private int imageSelected = 0; 

        private void navLoginHandler(object sender, EventArgs e)
        {
            Form1 loginPage = new Form1();
            loginPage.Show();
            this.Hide();
        }
        private void imageOneClickHandler(object sender, EventArgs e)
        {
            imageSelected = 0;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.BackColor = Color.LightBlue;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox3.BorderStyle = BorderStyle.None;
            pictureBox4.BorderStyle = BorderStyle.None;
        }
        private void imageTwoClickHandler(object sender, EventArgs e)
        {
            imageSelected = 1;
            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.BackColor = Color.LightBlue;
            pictureBox3.BorderStyle = BorderStyle.None;
            pictureBox4.BorderStyle = BorderStyle.None;
        }
        private void imageThreeClickHandler(object sender, EventArgs e)
        {
            imageSelected = 2;
            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.BackColor = Color.LightBlue;
            pictureBox4.BorderStyle = BorderStyle.None;
        }
        private void imageFourClickHandler(object sender, EventArgs e)
        {
            imageSelected = 3;
            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox3.BorderStyle = BorderStyle.None;
            pictureBox4.BorderStyle = BorderStyle.Fixed3D;
            pictureBox4.BackColor = Color.LightBlue;
        }

        private void registerHandler(object sender, EventArgs e)
        {
            string firstName = firstNameField.Text.Trim();
            string lastName = lastNameField.Text.Trim();
            string userName = userNameField.Text.Trim();
            string password = passwordField.Text.Trim();

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
