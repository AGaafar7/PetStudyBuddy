using System.Media;

namespace PetStudyBuddy
{
    public partial class MainPage : Form
    {
        private int xp = 0;
        private int totalTasks = 0;
        private int completedTasks = 0;

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
            tasksList.FlowDirection = FlowDirection.TopDown;
            tasksList.WrapContents = false;
            tasksList.AutoScroll = true;
            tasksList.HorizontalScroll.Enabled = false;
            tasksList.HorizontalScroll.Visible = false;

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
