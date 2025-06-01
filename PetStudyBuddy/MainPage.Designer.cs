namespace PetStudyBuddy
{
    partial class MainPage
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            label1 = new Label();
            progressBar1 = new ProgressBar();
            totalItemsChecker = new Label();
            addBTN = new Button();
            profilePic = new Button();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            countDownLabel = new Label();
            startTimerBTN = new Button();
            countDownTimer = new System.Windows.Forms.Timer(components);
            stopTimerBTN = new Button();
            tasksList = new FlowLayoutPanel();
            toShop = new LinkLabel();
            plusTimer = new Button();
            minusTimer = new Button();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(315, 9);
            label1.Name = "label1";
            label1.Size = new Size(168, 28);
            label1.TabIndex = 0;
            label1.Text = "Pet Study Buddy";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(321, 214);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(125, 18);
            progressBar1.TabIndex = 1;
            // 
            // totalItemsChecker
            // 
            totalItemsChecker.AutoSize = true;
            totalItemsChecker.Location = new Point(452, 212);
            totalItemsChecker.Name = "totalItemsChecker";
            totalItemsChecker.Size = new Size(31, 20);
            totalItemsChecker.TabIndex = 2;
            totalItemsChecker.Text = "0/0";
            // 
            // addBTN
            // 
            addBTN.BackColor = Color.Transparent;
            addBTN.FlatAppearance.BorderSize = 0;
            addBTN.FlatStyle = FlatStyle.Flat;
            addBTN.Image = (Image)resources.GetObject("addBTN.Image");
            addBTN.Location = new Point(29, 441);
            addBTN.Name = "addBTN";
            addBTN.Size = new Size(42, 45);
            addBTN.TabIndex = 4;
            addBTN.UseVisualStyleBackColor = false;
            // 
            // profilePic
            // 
            profilePic.BackColor = Color.White;
            profilePic.FlatAppearance.BorderSize = 0;
            profilePic.FlatStyle = FlatStyle.Flat;
            profilePic.Image = (Image)resources.GetObject("profilePic.Image");
            profilePic.Location = new Point(12, 12);
            profilePic.Name = "profilePic";
            profilePic.Size = new Size(42, 45);
            profilePic.TabIndex = 5;
            profilePic.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(673, 22);
            label3.Name = "label3";
            label3.Size = new Size(17, 20);
            label3.TabIndex = 6;
            label3.Text = "1";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(632, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 37);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // countDownLabel
            // 
            countDownLabel.AutoSize = true;
            countDownLabel.Font = new Font("Segoe UI", 18F);
            countDownLabel.Location = new Point(466, 301);
            countDownLabel.Name = "countDownLabel";
            countDownLabel.Size = new Size(89, 41);
            countDownLabel.TabIndex = 8;
            countDownLabel.Text = "25:00";
            // 
            // startTimerBTN
            // 
            startTimerBTN.Location = new Point(406, 361);
            startTimerBTN.Name = "startTimerBTN";
            startTimerBTN.Size = new Size(94, 29);
            startTimerBTN.TabIndex = 9;
            startTimerBTN.Text = "Play";
            startTimerBTN.UseVisualStyleBackColor = true;
            // 
            // countDownTimer
            // 
            countDownTimer.Interval = 25;
            // 
            // stopTimerBTN
            // 
            stopTimerBTN.Location = new Point(515, 361);
            stopTimerBTN.Name = "stopTimerBTN";
            stopTimerBTN.Size = new Size(94, 29);
            stopTimerBTN.TabIndex = 10;
            stopTimerBTN.Text = "Stop";
            stopTimerBTN.UseVisualStyleBackColor = true;
            // 
            // tasksList
            // 
            tasksList.Location = new Point(29, 275);
            tasksList.Name = "tasksList";
            tasksList.Size = new Size(250, 125);
            tasksList.TabIndex = 14;
            // 
            // toShop
            // 
            toShop.AutoSize = true;
            toShop.Location = new Point(710, 22);
            toShop.Name = "toShop";
            toShop.Size = new Size(45, 20);
            toShop.TabIndex = 15;
            toShop.TabStop = true;
            toShop.Text = "XP : 0";
            // 
            // plusTimer
            // 
            plusTimer.Location = new Point(561, 313);
            plusTimer.Name = "plusTimer";
            plusTimer.Size = new Size(31, 29);
            plusTimer.TabIndex = 16;
            plusTimer.Text = "+";
            plusTimer.UseVisualStyleBackColor = true;
            // 
            // minusTimer
            // 
            minusTimer.Location = new Point(429, 314);
            minusTimer.Name = "minusTimer";
            minusTimer.Size = new Size(31, 29);
            minusTimer.TabIndex = 17;
            minusTimer.Text = "-";
            minusTimer.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(274, 45);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(226, 149);
            pictureBox2.TabIndex = 18;
            pictureBox2.TabStop = false;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 511);
            Controls.Add(pictureBox2);
            Controls.Add(minusTimer);
            Controls.Add(plusTimer);
            Controls.Add(toShop);
            Controls.Add(addBTN);
            Controls.Add(tasksList);
            Controls.Add(stopTimerBTN);
            Controls.Add(startTimerBTN);
            Controls.Add(countDownLabel);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(profilePic);
            Controls.Add(totalItemsChecker);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Name = "MainPage";
            Text = "Main";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ProgressBar progressBar1;
        private Label totalItemsChecker;
        private Button addBTN;
        private Button profilePic;
        private Label label3;
        private PictureBox pictureBox1;
        private Label countDownLabel;
        private Button startTimerBTN;
        private System.Windows.Forms.Timer countDownTimer;
        private TimeSpan timeLeft;
        private Button stopTimerBTN;
        private FlowLayoutPanel tasksList;
        private LinkLabel toShop;
        private Button plusTimer;
        private Button minusTimer;
        private PictureBox pictureBox2;
    }
}