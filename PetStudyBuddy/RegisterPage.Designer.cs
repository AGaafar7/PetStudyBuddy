namespace PetStudyBuddy
{
    partial class RegisterPage
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
            firstNameField = new TextBox();
            lastNameField = new TextBox();
            userNameField = new TextBox();
            passwordField = new TextBox();
            registerBTN = new Button();
            SuspendLayout();
            // 
            // firstNameField
            // 
            firstNameField.Location = new Point(308, 87);
            firstNameField.Name = "firstNameField";
            firstNameField.PlaceholderText = "Enter your first name";
            firstNameField.Size = new Size(166, 27);
            firstNameField.TabIndex = 0;
            // 
            // lastNameField
            // 
            lastNameField.Location = new Point(308, 140);
            lastNameField.Name = "lastNameField";
            lastNameField.PlaceholderText = "Enter your last name";
            lastNameField.Size = new Size(166, 27);
            lastNameField.TabIndex = 1;
            lastNameField.TextChanged += lastNameField_TextChanged;
            // 
            // userNameField
            // 
            userNameField.Location = new Point(308, 183);
            userNameField.Name = "userNameField";
            userNameField.PlaceholderText = "Enter your username";
            userNameField.Size = new Size(166, 27);
            userNameField.TabIndex = 2;
            // 
            // passwordField
            // 
            passwordField.Location = new Point(308, 229);
            passwordField.Name = "passwordField";
            passwordField.PlaceholderText = "Enter a password";
            passwordField.Size = new Size(166, 27);
            passwordField.TabIndex = 3;
            // 
            // registerBTN
            // 
            registerBTN.Location = new Point(341, 278);
            registerBTN.Name = "registerBTN";
            registerBTN.Size = new Size(94, 29);
            registerBTN.TabIndex = 4;
            registerBTN.Text = "Register";
            registerBTN.UseVisualStyleBackColor = true;
            registerBTN.Click += registerHandler;
            // 
            // RegisterPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(registerBTN);
            Controls.Add(passwordField);
            Controls.Add(userNameField);
            Controls.Add(lastNameField);
            Controls.Add(firstNameField);
            Name = "RegisterPage";
            Text = "RegisterPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox firstNameField;
        private TextBox lastNameField;
        private TextBox userNameField;
        private TextBox passwordField;
        private Button registerBTN;
    }
}