namespace PetStudyBuddy
{
    partial class HistoryPage
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
            BackButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // BackButton
            // 
            BackButton.Location = new Point(17, 20);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(94, 29);
            BackButton.TabIndex = 0;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(329, 29);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 1;
            label1.Text = "Task History";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(347, 68);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(313, 114);
            label3.Name = "label3";
            label3.Size = new Size(120, 20);
            label3.TabIndex = 3;
            label3.Text = "Tasks Completed";
            // 
            // HistoryPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BackButton);
            Name = "HistoryPage";
            Text = "HistoryPage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BackButton;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}