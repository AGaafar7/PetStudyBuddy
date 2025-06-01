// ProfilePage.Designer.cs - Designer code for ProfilePage
// Modified to inherit from BasePageControl and remove Form-specific properties

using PetStudyBuddy.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetStudyBuddy
{
    partial class ProfilePage : BasePageControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backButton = new Button();
            changeIconCombo = new ComboBox();
            usernameLabel = new Label();
            levelProgress = new ProgressBar();
            levelLabel = new Label();
            tasksCompletedLabel = new Label();
            goToHistory = new LinkLabel();
            shopButton = new Button();
            signOutButton = new Button();
            deleteAccountButton = new Button();
            headerLabel = new Label();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Location = new Point(23, 12);
            backButton.Name = "backButton";
            backButton.Size = new Size(94, 29);
            backButton.TabIndex = 0;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += button1_Click;
            // 
            // changeIconCombo
            // 
            changeIconCombo.FormattingEnabled = true;
            changeIconCombo.Location = new Point(290, 140);
            changeIconCombo.Name = "changeIconCombo";
            changeIconCombo.Size = new Size(151, 28);
            changeIconCombo.TabIndex = 3;
            changeIconCombo.Text = "Change profile picture";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI", 12F);
            usernameLabel.Location = new Point(320, 171);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(99, 28);
            usernameLabel.TabIndex = 4;
            usernameLabel.Text = "Username";
            // 
            // levelProgress
            // 
            levelProgress.Location = new Point(274, 255);
            levelProgress.Name = "levelProgress";
            levelProgress.Size = new Size(199, 29);
            levelProgress.TabIndex = 5;
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.Location = new Point(274, 232);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new Size(55, 20);
            levelLabel.TabIndex = 6;
            levelLabel.Text = "Level 1";
            // 
            // tasksCompletedLabel
            // 
            tasksCompletedLabel.AutoSize = true;
            tasksCompletedLabel.Location = new Point(413, 232);
            tasksCompletedLabel.Name = "tasksCompletedLabel";
            tasksCompletedLabel.Size = new Size(60, 20);
            tasksCompletedLabel.TabIndex = 7;
            tasksCompletedLabel.Text = "0/10 XP";
            // 
            // goToHistory
            // 
            goToHistory.AutoSize = true;
            goToHistory.Location = new Point(274, 314);
            goToHistory.Name = "goToHistory";
            goToHistory.Size = new Size(120, 20);
            goToHistory.TabIndex = 8;
            goToHistory.TabStop = true;
            goToHistory.Text = "Tasks Completed";
            // 
            // shopButton
            // 
            shopButton.Font = new Font("Segoe UI", 11F);
            shopButton.Location = new Point(313, 349);
            shopButton.Name = "shopButton";
            shopButton.Size = new Size(128, 39);
            shopButton.TabIndex = 9;
            shopButton.Text = "View Shop";
            shopButton.UseVisualStyleBackColor = true;
            // 
            // signOutButton
            // 
            signOutButton.ForeColor = Color.Red;
            signOutButton.Location = new Point(274, 404);
            signOutButton.Name = "signOutButton";
            signOutButton.Size = new Size(94, 29);
            signOutButton.TabIndex = 10;
            signOutButton.Text = "Sign Out";
            signOutButton.UseVisualStyleBackColor = true;
            // 
            // deleteAccountButton
            // 
            deleteAccountButton.ForeColor = Color.Red;
            deleteAccountButton.Location = new Point(274, 439);
            deleteAccountButton.Name = "deleteAccountButton";
            deleteAccountButton.Size = new Size(136, 29);
            deleteAccountButton.TabIndex = 11;
            deleteAccountButton.Text = "Delete Account";
            deleteAccountButton.UseVisualStyleBackColor = true;
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 12F);
            headerLabel.Location = new Point(318, 13);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(101, 28);
            headerLabel.TabIndex = 12;
            headerLabel.Text = "My Profile";
            headerLabel.TextAlign = ContentAlignment.MiddleLeft;
            headerLabel.Click += headerLabel_Click;
            // 
            // ProfilePage
            // 
            // REMOVED Form-specific properties
            // AutoScaleDimensions = new SizeF(8F, 20F);
            // AutoScaleMode = AutoScaleMode.Font;
            // ClientSize = new Size(746, 553);

            // Added UserControl-specific property
            Size = new Size(746, 553);

            Controls.Add(headerLabel);
            Controls.Add(deleteAccountButton);
            Controls.Add(signOutButton);
            Controls.Add(shopButton);
            Controls.Add(goToHistory);
            Controls.Add(tasksCompletedLabel);
            Controls.Add(levelLabel);
            Controls.Add(levelProgress);
            Controls.Add(usernameLabel);
            Controls.Add(changeIconCombo);
            Controls.Add(backButton);
            Name = "ProfilePage";

            // REMOVED Form-specific property
            // Text = "ProfilePage";

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backButton;
        private ComboBox changeIconCombo;
        private Label usernameLabel;
        private ProgressBar levelProgress;
        private Label levelLabel;
        private Label tasksCompletedLabel;
        private LinkLabel goToHistory;
        private Button shopButton;
        private Button signOutButton;
        private Button deleteAccountButton;
        private Label headerLabel;
    }
}