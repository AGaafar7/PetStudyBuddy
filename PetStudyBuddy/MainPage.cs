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
                Height = 40,
                Dock = DockStyle.Top,
                Padding = new Padding(5),
                BackColor = Color.LightGray
            };

            // Checkbox
            CheckBox checkBox = new CheckBox
            {
                Location = new Point(5, 10),
                AutoSize = true
            };

            // Task Name Label
            Label nameLabel = new Label
            {
                Text = taskName,
                AutoSize = true,
                Location = new Point(30, 10),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // Description Label
            Label descLabel = new Label
            {
                Text = description,
                AutoSize = true,
                Location = new Point(150, 10),
                Font = new Font("Segoe UI", 9)
            };

            // Due Date Label
            Label dueLabel = new Label
            {
                Text = dueDate.ToShortDateString(),
                AutoSize = true,
                Location = new Point(300, 10),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DarkRed
            };

            // Add everything to the task row
            taskRow.Controls.Add(checkBox);
            taskRow.Controls.Add(nameLabel);
            taskRow.Controls.Add(descLabel);
            taskRow.Controls.Add(dueLabel);

            // Add to the main panel
            tasksList.Controls.Add(taskRow);
            tasksList.Controls.SetChildIndex(taskRow, 0); // Show latest on top
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
    }
}
