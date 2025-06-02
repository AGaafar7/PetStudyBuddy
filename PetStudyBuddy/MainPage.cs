using System.Media;

namespace PetStudyBuddy
{
    public partial class MainPage : Form
    {
        private int xp = 0;
        private int totalTasks = 0;
        private int completedTasks = 0;
        private Panel sidebar;
        private bool sidebarVisible = false;
        private int sidebarWidth = 200;
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

        public MainPage()
        {
            InitializeComponent();
            startTimerBTN.Click += StartButton_Click;
            countDownTimer.Tick += CountdownTimer_Tick;
            stopTimerBTN.Click += PauseButton_Click;
            addBTN.Click += addButtonHandler;
            timeLeft = TimeSpan.FromMinutes(25);
            minusTimer.Click += minusHandler;
            plusTimer.Click += plusHandler;
            toShop.Click += toShopHandler;
            tasksList.FlowDirection = FlowDirection.TopDown;
            tasksList.WrapContents = false;
            tasksList.AutoScroll = true;
            tasksList.HorizontalScroll.Enabled = false;
            tasksList.HorizontalScroll.Visible = false;


            sidebar = new Panel
            {
                BackColor = Color.LightSlateGray,
                Size = new Size(sidebarWidth, this.ClientSize.Height),
                Location = new Point(0, 0),
                Visible = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom
            };
            this.Controls.Add(sidebar);

            // Wire up profilePic click to toggle sidebar
            profilePic.Click += ProfilePic_Click;

            // Handle clicks on the form for outside-click detection
            this.Click += MainPage_Click;

            // Also handle clicks on other controls to detect outside sidebar clicks
            // so sidebar closes even if you click on other controls
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != sidebar && ctrl != profilePic)
                {
                    ctrl.Click += MainPage_Click;
                }
            }
            InitializeSidebarProfile();
            this.Resize += (s, e) =>
            {
                sidebar.Height = this.ClientSize.Height;
            };
        }

        private void InitializeSidebarProfile()
        {
            // Clear existing sidebar controls if any
            sidebar.Controls.Clear();

            // Circular Avatar PictureBox
            PictureBox avatarPictureBox = new PictureBox
            {
                Size = new Size(80, 80),  // Adjust size as needed
                Location = new Point(20, 10),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Properties.Resources.shiba,  // Put your resource image name here
                Cursor = Cursors.Hand
            };

            // Make PictureBox circular by using Region with a circle
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, avatarPictureBox.Width, avatarPictureBox.Height);
            avatarPictureBox.Region = new Region(path);

            sidebar.Controls.Add(avatarPictureBox);


            // Username Label
            usernameLabel = new Label
            {
                Text = "agaafar",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, avatarPictureBox.Bottom + 15),
                AutoSize = true
            };
            sidebar.Controls.Add(usernameLabel);

            // Level Label
            levelLabel = new Label
            {
                Text = "Level 1",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, usernameLabel.Bottom + 20),
                AutoSize = true
            };
            sidebar.Controls.Add(levelLabel);



            // Link to Tasks History
            goToHistory = new LinkLabel
            {
                Text = "Tasks Completed",
                LinkColor = Color.LightBlue,
                Location = new Point(20, levelLabel.Bottom + 15),
                AutoSize = true
            };
            goToHistory.Click += (s, e) =>
            {
                HistoryPage historyPage = new HistoryPage();
                historyPage.Show();
                this.Close();
            };
            sidebar.Controls.Add(goToHistory);

            // View Shop Button
            shopButton = new Button
            {
                Text = "View Shop",
                Font = new Font("Segoe UI", 11),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(20, goToHistory.Bottom + 15),
                Width = sidebarWidth - 40,
                Height = 40,
                Cursor = Cursors.Hand
            };
            shopButton.Click += (s, e) =>
            {
                ShopPage shopPage = new ShopPage();
                shopPage.Show();
                this.Close();

            };
            sidebar.Controls.Add(shopButton);

            // Sign Out Button
            signOutButton = new Button
            {
                Text = "Sign Out",
                BackColor = Color.DarkRed,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(20, shopButton.Bottom + 15),
                Width = sidebarWidth - 40,
                Height = 35,
                Cursor = Cursors.Hand
            };
            signOutButton.Click += (s, e) =>
            {

                Form1 loginPage = new Form1();
                loginPage.Show();
                this.Close();

            };
            sidebar.Controls.Add(signOutButton);

            // Delete Account Button
            deleteAccountButton = new Button
            {
                Text = "Delete Account",
                BackColor = Color.Maroon,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(20, signOutButton.Bottom + 10),
                Width = sidebarWidth - 40,
                Height = 35,
                Cursor = Cursors.Hand
            };
            deleteAccountButton.Click += (s, e) =>
            {
                var confirm = MessageBox.Show("Are you sure you want to delete your account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    MessageBox.Show("Account deleted!");
                    RegisterPage roginPage = new RegisterPage();
                    roginPage.Show();
                    //TODO: Delete him from the database
                    this.Close();
                }
            };
            sidebar.Controls.Add(deleteAccountButton);
        }
        private void ProfilePic_Click(object sender, EventArgs e)
        {
            if (!sidebarVisible)
            {
                // Show sidebar
                sidebar.Visible = true;
                sidebar.BringToFront();
                sidebarVisible = true;
            }
            else
            {
                // Hide sidebar
                sidebar.Visible = false;
                sidebarVisible = false;
            }
        }
        private void toShopHandler(object sender, EventArgs e)
        {
            ShopPage shopPage = new ShopPage();
            shopPage.Show();
            this.Close();
        }
        private void MainPage_Click(object sender, EventArgs e)
        {
            // Make sure sidebar and profilePic are not null or disposed
            if (sidebar == null || sidebar.IsDisposed ||
                profilePic == null || profilePic.IsDisposed)
                return;

            if (sidebarVisible)
            {
                // Get mouse position relative to sidebar
                Point mousePos = sidebar.PointToClient(Cursor.Position);

                // Check if click is outside sidebar bounds
                if (mousePos.X < 0 || mousePos.X > sidebar.Width ||
                    mousePos.Y < 0 || mousePos.Y > sidebar.Height)
                {
                    // Check if click was NOT on profilePic
                    if (!profilePic.Bounds.Contains(this.PointToClient(Cursor.Position)))
                    {
                        sidebar.Visible = false;
                        sidebarVisible = false;
                    }
                }
            }
        }



        private void plusHandler(object sender, EventArgs e)
        {
            timeLeft = timeLeft.Add(TimeSpan.FromMinutes(5));
            countDownLabel.Text = timeLeft.ToString(@"mm\:ss");
        }

        private void minusHandler(object sender, EventArgs e)
        {
            if (timeLeft.TotalMinutes > 5)
            {
                timeLeft = timeLeft.Add(TimeSpan.FromMinutes(-5));
                countDownLabel.Text = timeLeft.ToString(@"mm\:ss");
            }
            else
            {
                MessageBox.Show("Cannot reduce time below 5 minutes.");
            }
        }

        private void addButtonHandler(object sender, EventArgs e)
        {
            using (AddTaskForm form = new AddTaskForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    AddTaskToPanel(form.TaskName, form.Description, form.DueDate);


                    totalTasks++;
                    UpdateProgressDisplay();
                }
            }
        }

        private void UpdateProgressDisplay()
        {
            toShop.Text = $"XP: {xp}";

            int progress = totalTasks > 0 ? (int)((double)completedTasks / totalTasks * 100) : 0;
            progressBar1.Value = Math.Min(progress, 100);
            totalItemsChecker.Text = $"{completedTasks}/{totalTasks}";
        }

        private void AddTaskToPanel(string taskName, string description, DateTime dueDate)
        {
            Panel taskRow = new Panel
            {
                Height = 90,
                Width = tasksList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth,
                Padding = new Padding(5),
                BackColor = Color.LightGray,
                AutoScroll = false
            };

            // Adjust taskRow width on tasksList resize
            tasksList.SizeChanged += (s, e) =>
            {
                taskRow.Width = tasksList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            };

            CheckBox checkBox = new CheckBox
            {
                Location = new Point(5, 10),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            checkBox.CheckedChanged += (s, e) =>
            {
                if (checkBox.Checked)
                {
                    completedTasks++;
                    xp += 1;
                }
                else
                {
                    completedTasks--;
                    xp--;
                }
                UpdateProgressDisplay();
            };

            Label nameLabel = new Label
            {
                Text = taskName,
                AutoSize = true,
                Location = new Point(30, 5),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            Label descLabel = new Label
            {
                Text = description,
                AutoSize = true,
                Location = new Point(30, 30),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DimGray,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            Label selectedDateLabel = new Label
            {
                Text = "Deadline: " + dueDate.ToShortDateString(),
                AutoSize = true,
                Location = new Point(30, 50),
                Font = new Font("Segoe UI", 8, FontStyle.Italic),
                ForeColor = Color.Gray,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            Label dueLabel = new Label
            {
                Text = dueDate.ToShortDateString(),
                AutoSize = true,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DarkRed,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            PictureBox deleteIcon = new PictureBox
            {
                Image = Properties.Resources.deleteIcon,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(20, 20),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            void AdjustPositions()
            {
                dueLabel.Location = new Point(taskRow.Width - dueLabel.Width - 50, 10);
                deleteIcon.Location = new Point(taskRow.Width - deleteIcon.Width - 10, (taskRow.Height - deleteIcon.Height) / 2);
            }

            taskRow.Resize += (s, e) => AdjustPositions();
            AdjustPositions();

            deleteIcon.Click += (s, e) =>
            {
                if (checkBox.Checked)
                    completedTasks--;
                totalTasks--;
                tasksList.Controls.Remove(taskRow);
                taskRow.Dispose();
                UpdateProgressDisplay();
            };

            taskRow.Controls.Add(checkBox);
            taskRow.Controls.Add(nameLabel);
            taskRow.Controls.Add(descLabel);
            taskRow.Controls.Add(selectedDateLabel);
            taskRow.Controls.Add(dueLabel);
            taskRow.Controls.Add(deleteIcon);

            tasksList.Controls.Add(taskRow);
            tasksList.Controls.SetChildIndex(taskRow, 0);
        }



        private void StartButton_Click(object sender, EventArgs e)
        {
            countDownLabel.Text = timeLeft.ToString(@"mm\:ss");
            countDownTimer.Start();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            countDownLabel.Text = timeLeft.ToString(@"mm\:ss");
            countDownTimer.Stop();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft.TotalSeconds > 0)
            {
                timeLeft = timeLeft.Add(TimeSpan.FromSeconds(-1));
                countDownLabel.Text = timeLeft.ToString(@"mm\:ss");
            }
            else
            {
                countDownTimer.Stop();
                SystemSounds.Beep.Play();
                MessageBox.Show("Time's up!");
            }
        }

        private void tasksList_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}