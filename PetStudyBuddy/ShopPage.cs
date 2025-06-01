// ShopPage.cs - Shop page for purchasing items with XP
// Converted from Form to BasePageControl for proper navigation

using PetStudyBuddy.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PetStudyBuddy
{
    public partial class ShopPage : BasePageControl
    {
        // List of available shop items
        private List<Classes.ShopItem> shopItems;

        // --- CONSTRUCTOR ---
        public ShopPage(MainForm parent) : base(parent)
        {
            InitializeComponent();
            SetupShopItems();
            SetupEventHandlers();
        }

        // --- SETUP METHODS ---

        private void SetupShopItems()
        {
            // Initialize shop items using factory methods
            shopItems = new List<Classes.ShopItem>
            {
                Classes.ShopItem.CreatePetFood("Premium Kibble", 5),
                Classes.ShopItem.CreatePetToy("Squeaky Ball", 3),
                Classes.ShopItem.CreateStudyTool("Focus Timer", 8),
                Classes.ShopItem.CreatePetFood("Healthy Treats", 2)
            };

            UpdateShopDisplay();
        }

        private void SetupEventHandlers()
        {
            // Connect navigation buttons
            linkLabel1.LinkClicked += BackLink_Clicked;

            // Connect buy buttons
            button1.Click += BuyButton1_Click;
            button2.Click += BuyButton2_Click;
            button3.Click += BuyButton3_Click;
            button4.Click += BuyButton4_Click;
        }

        // --- NAVIGATION HANDLERS ---

        private void BackLink_Clicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            GoToMainPage();
        }

        // --- SHOP FUNCTIONALITY ---

        private void UpdateShopDisplay()
        {
            if (CurrentUser != null)
            {
                // Update XP display
                label1.Text = "XP: ";
                label10.Text = CurrentUser.XP.ToString();

                // Update shop items display
                if (shopItems.Count >= 4)
                {
                    // Update item 1
                    label3.Text = shopItems[0].Name;
                    label2.Text = $"{shopItems[0].Price} XP";

                    // Update item 2
                    label4.Text = shopItems[1].Name;
                    label5.Text = $"{shopItems[1].Price} XP";

                    // Update item 3
                    label6.Text = shopItems[2].Name;
                    label7.Text = $"{shopItems[2].Price} XP";

                    // Update item 4
                    label8.Text = shopItems[3].Name;
                    label9.Text = $"{shopItems[3].Price} XP";
                }
            }
        }

        // --- BUY BUTTON HANDLERS ---

        private void BuyButton1_Click(object? sender, EventArgs e)
        {
            PurchaseItem(0);
        }

        private void BuyButton2_Click(object? sender, EventArgs e)
        {
            PurchaseItem(1);
        }

        private void BuyButton3_Click(object? sender, EventArgs e)
        {
            PurchaseItem(2);
        }

        private void BuyButton4_Click(object? sender, EventArgs e)
        {
            PurchaseItem(3);
        }

        private void PurchaseItem(int itemIndex)
        {
            if (CurrentUser == null || itemIndex >= shopItems.Count) return;

            var item = shopItems[itemIndex];

            if (CurrentUser.PurchaseItem(item))
            {
                MessageBox.Show($"Successfully purchased {item.Name}!");
                UpdateShopDisplay();
            }
            else
            {
                MessageBox.Show($"Not enough XP! You need {item.Price} XP to buy {item.Name}.");
            }
        }

        // --- LIFECYCLE METHODS OVERRIDE ---

        protected override void OnPageEnter()
        {
            base.OnPageEnter();
            UpdateShopDisplay();
        }

        protected override void RefreshPageData()
        {
            UpdateShopDisplay();
        }

        // --- LEGACY EVENT HANDLERS ---
        // These are kept for compatibility with the designer

        private void linkLabel1_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            GoToMainPage();
        }

        private void label2_Click(object? sender, EventArgs e)
        {
            // Legacy event handler - empty implementation
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            PurchaseItem(0);
        }

        private void label10_Click(object? sender, EventArgs e)
        {
            // Legacy event handler - empty implementation
        }
    }
}