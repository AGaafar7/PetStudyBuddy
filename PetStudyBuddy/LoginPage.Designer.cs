namespace PetStudyBuddy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            emailField = new TextBox();
            passwordField = new TextBox();
            loginButton = new Button();
            register = new LinkLabel();
            SuspendLayout();
            // 
            // emailField
            // 
            emailField.Location = new Point(359, 174);
            emailField.Name = "emailField";
            emailField.Size = new Size(125, 27);
            emailField.TabIndex = 0;
            // 
            // passwordField
            // 
            passwordField.Location = new Point(359, 224);
            passwordField.Name = "passwordField";
            passwordField.Size = new Size(125, 27);
            passwordField.TabIndex = 1;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(375, 278);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(94, 29);
            loginButton.TabIndex = 2;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            // 
            // register
            // 
            register.AutoSize = true;
            register.Location = new Point(285, 310);
            register.Name = "register";
            register.Size = new Size(271, 20);
            register.TabIndex = 3;
            register.TabStop = true;
            register.Text = "click here if you do not have an account";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(register);
            Controls.Add(loginButton);
            Controls.Add(passwordField);
            Controls.Add(emailField);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox emailField;
        private TextBox passwordField;
        private Button loginButton;
        private LinkLabel register;
        
        
    }
}
