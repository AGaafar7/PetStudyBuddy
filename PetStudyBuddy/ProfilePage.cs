// ProfilePage.cs - User profile display and management page
// Inherits from BasePageControl to demonstrate inheritance and get navigation functionality

using PetStudyBuddy.Classes;
using System;
using System.Windows.Forms;

namespace PetStudyBuddy
{
    public partial class ProfilePage : BasePageControl
    {
        // --- CONSTRUCTOR ---
        public ProfilePage(MainForm parent) : base(parent)
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        // --- EVENT HANDLERS SETUP ---
        private void SetupEventHandlers()
        {
            // Connect existing controls to navigation methods
            backButton.Click += BackButton_Click;
            shopButton.Click += ShopButton_Click;
            goToHistory.LinkClicked += HistoryLink_Clicked;
            signOutButton.Click += SignOutButton_Click;
            headerLabel.Click += HeaderLabel_Click;
        }

        // --- NAVIGATION EVENT HANDLERS ---

        // Navigate back to main page
        private void BackButton_Click(object? sender, EventArgs e)
        {
            GoToMainPage();
        }

        // Navigate to shop page
        private void ShopButton_Click(object? sender, EventArgs e)
        {
            GoToShopPage();
        }

        // Navigate to history page
        private void HistoryLink_Clicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            GoToHistoryPage();
        }

        // Navigate to login page (sign out)
        private void SignOutButton_Click(object? sender, EventArgs e)
        {
            GoToLoginPage();
        }

        // Header click handler (empty implementation)
        private void HeaderLabel_Click(object? sender, EventArgs e)
        {
            // Could be used for profile picture click functionality
        }

        // --- DATA REFRESH METHODS ---

        // Refresh user data display - called when page becomes visible
        private void RefreshUserData()
        {
            if (CurrentUser != null)
            {
                // Display username
                usernameLabel.Text = CurrentUser.Username;

                // Display current level
                levelLabel.Text = $"Level {CurrentUser.Level}";

                // Calculate and display XP progress in current level
                int xpForCurrentLevel = (CurrentUser.Level - 1) * 10;
                int xpForNextLevel = CurrentUser.Level * 10;
                int progressInCurrentLevel = CurrentUser.XP - xpForCurrentLevel;
                int xpNeededForCurrentLevel = xpForNextLevel - xpForCurrentLevel;

                tasksCompletedLabel.Text = $"{progressInCurrentLevel}/{xpNeededForCurrentLevel} XP";

                // Update progress bar (0-100%)
                double progressPercentage = (double)progressInCurrentLevel / xpNeededForCurrentLevel * 100;
                levelProgress.Value = Math.Min((int)progressPercentage, 100);

                // Display completed tasks count
                goToHistory.Text = $"Tasks Completed ({CurrentUser.CompletedTasks.Count})";
            }
        }

        // --- LIFECYCLE METHODS OVERRIDE ---

        // Called when page becomes visible - override from BasePageControl
        protected override void OnPageEnter()
        {
            base.OnPageEnter();
            RefreshUserData(); // Update display when page loads
        }

        // Called to refresh page data - override from BasePageControl
        protected override void RefreshPageData()
        {
            RefreshUserData();
        }

        // --- LEGACY EVENT HANDLERS ---
        // These are kept for compatibility with the designer

        private void button1_Click(object? sender, EventArgs e)
        {
            GoToMainPage(); // Navigate back using BasePageControl method
        }

        private void textBox1_TextChanged(object? sender, EventArgs e)
        {
            // Legacy event handler - empty implementation
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            // Legacy event handler - empty implementation
        }

        private void headerLabel_Click(object? sender, EventArgs e)
        {
            // Legacy event handler - empty implementation
        }
    }
}