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
            loginBTN = new LinkLabel();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // firstNameField
            // 
            firstNameField.Location = new Point(308, 199);
            firstNameField.Name = "firstNameField";
            firstNameField.PlaceholderText = "Enter your first name";
            firstNameField.Size = new Size(166, 27);
            firstNameField.TabIndex = 0;
            // 
            // lastNameField
            // 
            lastNameField.Location = new Point(308, 252);
            lastNameField.Name = "lastNameField";
            lastNameField.PlaceholderText = "Enter your last name";
            lastNameField.Size = new Size(166, 27);
            lastNameField.TabIndex = 1;
            lastNameField.TextChanged += lastNameField_TextChanged;
            // 
            // userNameField
            // 
            userNameField.Location = new Point(308, 295);
            userNameField.Name = "userNameField";
            userNameField.PlaceholderText = "Enter your username";
            userNameField.Size = new Size(166, 27);
            userNameField.TabIndex = 2;
            // 
            // passwordField
            // 
            passwordField.Location = new Point(308, 341);
            passwordField.Name = "passwordField";
            passwordField.PlaceholderText = "Enter a password";
            passwordField.Size = new Size(166, 27);
            passwordField.TabIndex = 3;
            // 
            // registerBTN
            // 
            registerBTN.Location = new Point(299, 390);
            registerBTN.Name = "registerBTN";
            registerBTN.Size = new Size(94, 29);
            registerBTN.TabIndex = 4;
            registerBTN.Text = "Register";
            registerBTN.UseVisualStyleBackColor = true;
            registerBTN.Click += registerHandler;
            // 
            // loginBTN
            // 
            loginBTN.AutoSize = true;
            loginBTN.Location = new Point(412, 394);
            loginBTN.Name = "loginBTN";
            loginBTN.Size = new Size(46, 20);
            loginBTN.TabIndex = 5;
            loginBTN.TabStop = true;
            loginBTN.Text = "Login";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(101, 39);
            label1.Name = "label1";
            label1.Size = new Size(135, 20);
            label1.TabIndex = 6;
            label1.Text = "Choose from icons:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.golden;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(242, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(87, 114);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.sheperd;
            pictureBox2.BackgroundImageLayout = ImageLayout.Center;
            pictureBox2.Location = new Point(505, 39);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(69, 114);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.samoyed;
            pictureBox3.BackgroundImageLayout = ImageLayout.Center;
            pictureBox3.Location = new Point(416, 39);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(83, 114);
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = Properties.Resources.husky;
            pictureBox4.BackgroundImageLayout = ImageLayout.Center;
            pictureBox4.Location = new Point(335, 39);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(75, 114);
            pictureBox4.TabIndex = 10;
            pictureBox4.TabStop = false;
            // 
            // RegisterPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(loginBTN);
            Controls.Add(registerBTN);
            Controls.Add(passwordField);
            Controls.Add(userNameField);
            Controls.Add(lastNameField);
            Controls.Add(firstNameField);
            Name = "RegisterPage";
            Text = "RegisterPage";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox firstNameField;
        private TextBox lastNameField;
        private TextBox userNameField;
        private TextBox passwordField;
        private Button registerBTN;
        private LinkLabel loginBTN;
        private Label label1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
    }
}