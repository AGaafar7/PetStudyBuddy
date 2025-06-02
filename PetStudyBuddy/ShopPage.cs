using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetStudyBuddy
{
    public partial class ShopPage : Form
    {
        public ShopPage()
        {
            InitializeComponent();
            BackButton.Click += handleBackButton;
        }

        private void handleBackButton(object sender, EventArgs e)
        {
            MainPage mainPage = new MainPage();
            mainPage.Show();
            this.Close();
        }

        private int xp = 0;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int xp = 0;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
