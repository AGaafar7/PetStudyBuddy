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
            label2 = new Label();
            addBTN = new Button();
            profilePic = new Button();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            countDownLabel = new Label();
            startTimerBTN = new Button();
            countDownTimer = new System.Windows.Forms.Timer(components);
            stopTimerBTN = new Button();
            shopBTN = new Button();
            label4 = new Label();
            pointLabel = new Label();
            tasksList = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(321, 22);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 0;
            label1.Text = "Pet Study Buddy";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(284, 216);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(125, 18);
            progressBar1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(415, 214);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 2;
            label2.Text = "0/0";
            // 
            // addBTN
            // 
            addBTN.BackColor = Color.Transparent;
            addBTN.FlatAppearance.BorderSize = 0;
            addBTN.FlatStyle = FlatStyle.Flat;
            addBTN.Image = (Image)resources.GetObject("addBTN.Image");
            addBTN.Location = new Point(723, 439);
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
            label3.Location = new Point(541, 22);
            label3.Name = "label3";
            label3.Size = new Size(17, 20);
            label3.TabIndex = 6;
            label3.Text = "0";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(500, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(35, 37);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // countDownLabel
            // 
            countDownLabel.AutoSize = true;
            countDownLabel.Location = new Point(474, 303);
            countDownLabel.Name = "countDownLabel";
            countDownLabel.Size = new Size(44, 20);
            countDownLabel.TabIndex = 8;
            countDownLabel.Text = "25:00";
            // 
            // startTimerBTN
            // 
            startTimerBTN.Location = new Point(406, 361);
            startTimerBTN.Name = "startTimerBTN";
            startTimerBTN.Size = new Size(94, 29);
            startTimerBTN.TabIndex = 9;
            startTimerBTN.Text = "Start";
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
            // shopBTN
            // 
            shopBTN.Location = new Point(660, 21);
            shopBTN.Name = "shopBTN";
            shopBTN.Size = new Size(94, 29);
            shopBTN.TabIndex = 11;
            shopBTN.Text = "Shop";
            shopBTN.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(588, 25);
            label4.Name = "label4";
            label4.Size = new Size(37, 20);
            label4.TabIndex = 12;
            label4.Text = "XP : ";
            // 
            // pointLabel
            // 
            pointLabel.AutoSize = true;
            pointLabel.Location = new Point(616, 26);
            pointLabel.Name = "pointLabel";
            pointLabel.Size = new Size(17, 20);
            pointLabel.TabIndex = 13;
            pointLabel.Text = "0";
            // 
            // tasksList
            // 
            tasksList.Location = new Point(29, 275);
            tasksList.Name = "tasksList";
            tasksList.Size = new Size(250, 125);
            tasksList.TabIndex = 14;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 549);
            Controls.Add(tasksList);
            Controls.Add(pointLabel);
            Controls.Add(label4);
            Controls.Add(shopBTN);
            Controls.Add(stopTimerBTN);
            Controls.Add(startTimerBTN);
            Controls.Add(countDownLabel);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(profilePic);
            Controls.Add(addBTN);
            Controls.Add(label2);
            Controls.Add(progressBar1);
            Controls.Add(label1);
            Name = "MainPage";
            Text = "Main";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ProgressBar progressBar1;
        private Label label2;
        private Button addBTN;
        private Button profilePic;
        private Label label3;
        private PictureBox pictureBox1;
        private Label countDownLabel;
        private Button startTimerBTN;
        private System.Windows.Forms.Timer countDownTimer;
        private TimeSpan timeLeft;
        private Button stopTimerBTN;
        private Button shopBTN;
        private Label label4;
        private Label pointLabel;
        private FlowLayoutPanel tasksList;
    }
}