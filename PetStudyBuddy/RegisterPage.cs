using Microsoft.Data.Sqlite;
using PetStudyBuddy.DataModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PetStudyBuddy
{
    public partial class RegisterPage : Form
    {
        private string imageSelected;
        private DatabaseManager dbManager;
        public RegisterPage()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
            registerBTN.Click -= registerHandler;
            registerBTN.Click += registerHandler;
            loginBTN.Click += navLoginHandler;
            pictureBox1.Click += imageOneClickHandler;
            pictureBox2.Click += imageTwoClickHandler;
            pictureBox3.Click += imageThreeClickHandler;
            pictureBox4.Click += imageFourClickHandler;
            if (pictureBox1.Image != null)
            {
                imageSelected = ImageToBase64(pictureBox1);
            
                imageOneClickHandler(null, null);
            }
            
        }

        private bool isRegistering = false;

        private void navLoginHandler(object sender, EventArgs e)
        {
            Form1 loginPage = new Form1();
            loginPage.Show();
            this.Hide();
        }

        private string ImageToBase64(PictureBox pb)
        {
            if (pb.Image == null)
                return null;

            using (var ms = new System.IO.MemoryStream())
            {

                pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                byte[] imageBytes = ms.ToArray();


                string base64String = Convert.ToBase64String(imageBytes);

                return base64String;
            }
        }

        private void imageOneClickHandler(object sender, EventArgs e)
        {
            imageSelected = ImageToBase64(pictureBox1);

            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.BackColor = Color.LightBlue;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BorderStyle = BorderStyle.None;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BorderStyle = BorderStyle.None;
            pictureBox4.BackColor = Color.Transparent;
        }
        private void imageTwoClickHandler(object sender, EventArgs e)
        {
            imageSelected = ImageToBase64(pictureBox2);
            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox2.BackColor = Color.LightBlue;
            pictureBox3.BorderStyle = BorderStyle.None;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BorderStyle = BorderStyle.None;
            pictureBox4.BackColor = Color.Transparent;
        }
        private void imageThreeClickHandler(object sender, EventArgs e)
        {
            imageSelected = ImageToBase64(pictureBox3);
            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.BackColor = Color.LightBlue;
            pictureBox4.BorderStyle = BorderStyle.None;
            pictureBox4.BackColor = Color.Transparent;
        }
        private void imageFourClickHandler(object sender, EventArgs e)
        {
            imageSelected = ImageToBase64(pictureBox4);
            pictureBox1.BorderStyle = BorderStyle.None;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BorderStyle = BorderStyle.None;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BorderStyle = BorderStyle.Fixed3D;
            pictureBox4.BackColor = Color.LightBlue;
            MessageBox.Show(imageSelected);
        }
        //TODO: Got the error so the error is that image selected does not have a value i will return the register to use the createuser in the database manager
        private void registerHandler(object sender, EventArgs e)
        {
            if (isRegistering) return;
            isRegistering = true;

            string firstName = firstNameField.Text.Trim();
            string lastName = lastNameField.Text.Trim();
            string userName = userNameField.Text.Trim();
            string password = passwordField.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.");
                isRegistering = false;
                return;
            }

            try
            {
                string dbPath = @"D:\Apps\VisualStudioSource\repos\PetStudyBuddy\PetStudyBuddy\petStudy.db";
                string con = $"Data Source={dbPath};";

                using (var connection = new SqliteConnection(con))
                {
                    connection.Open();
                    var checkCmd = connection.CreateCommand();
                    checkCmd.CommandText = "SELECT COUNT(*) FROM users WHERE username = @username";
                    checkCmd.Parameters.AddWithValue("@username", userName);
                    long count = (long)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Username already exists. Please try a different one.");
                        return;
                    }

                    string insertQuery = @"INSERT INTO users 
                (firstname, lastname, username, password, petid, petlevel, profilepic)
                VALUES (@firstName, @lastName, @username, @password, '101', 1, @profilepic)";

                    using (var insertCmd = new SqliteCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@firstName", firstName);
                        insertCmd.Parameters.AddWithValue("@lastName", lastName);
                        insertCmd.Parameters.AddWithValue("@username", userName);
                        insertCmd.Parameters.AddWithValue("@password", password);
                        insertCmd.Parameters.AddWithValue("@profilepic", "sss");

                        int affectedRows = insertCmd.ExecuteNonQuery();

                        if (affectedRows == 1)
                        {
                            //TODO: Get the current user from the databasemanager via his id as the create new user retrives null and i do not know why
                            MessageBox.Show("Registration successful!");
                            MainPage mainForm = new MainPage();
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Registration failed. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during registration: " + ex.Message);
            }
            finally
            {
                isRegistering = false;
            }
        }
        

        private void lastNameField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}