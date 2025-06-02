using Microsoft.Data.Sqlite;
using PetStudyBuddy.DataModels;
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
            imageSelected = ImageToBase64(pictureBox1);
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

        }

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

            //got inputs in the above variables
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))

            {
                MessageBox.Show("Please fill in all fields.");
                isRegistering = false;
                return;
            }

            var newUser = dbManager.CreateNewUser(
                firstName,
                lastName,
                userName,
                password,
                imageSelected,
                petId: "101",
                petLevel: 1
            );
            //The user is null needs fixing
            MessageBox.Show(newUser.ToString());
            if (newUser != null)
            {
                MessageBox.Show("Registration successful!");
                MainPage mainForm = new MainPage();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Registration failed. Please try again or try logging in if you already have an account.");
            }

            isRegistering = false;
        }

        private void lastNameField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}