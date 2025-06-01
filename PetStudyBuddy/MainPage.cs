namespace PetStudyBuddy
{
    public partial class MainPage : Form
    {
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
                    //Add Them to Databaase also
                }
            }
        }

        private void AddTaskToPanel(string taskName, string description, DateTime dueDate)
        {
            Panel taskRow = new Panel
            {
                Height = 80,
                Padding = new Padding(5),
                BackColor = Color.LightGray,
                Dock = DockStyle.Top
            };

            CheckBox checkBox = new CheckBox
            {
                Location = new Point(5, 10),
                AutoSize = true
            };

            Label nameLabel = new Label
            {
                Text = taskName,
                AutoSize = true,
                Location = new Point(30, 5),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            Label descLabel = new Label
            {
                Text = description,
                AutoSize = true,
                Location = new Point(30, 30),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DimGray
            };

            Label selectedDateLabel = new Label
            {
                Text = "Deadline: " + dueDate.ToShortDateString(),
                AutoSize = true,
                Location = new Point(30, 50),
                Font = new Font("Segoe UI", 8, FontStyle.Italic),
                ForeColor = Color.Gray
            };

            Label dueLabel = new Label
            {
                Text = dueDate.ToShortDateString(),
                AutoSize = true,
                Location = new Point(300, 10),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DarkRed
            };

            PictureBox deleteIcon = new PictureBox
            {
                Image = Properties.Resources.deleteIcon,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(20, 20),
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(taskRow.Width - 20 - 10, (taskRow.Height - 20) / 2)
            };


            taskRow.Resize += (s, e) =>
            {
                deleteIcon.Location = new Point(taskRow.Width - 30, (taskRow.Height - 20) / 2);
            };

            deleteIcon.Click += (s, e) =>
            {
                tasksList.Controls.Remove(taskRow);
                taskRow.Dispose();
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
                MessageBox.Show("Time's up!");
                // TODO: Add custom behavior here (e.g., play sound, show a form, etc.)
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
