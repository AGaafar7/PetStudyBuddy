// MainForm.cs - Main application container and navigation hub
// Handles user state, dictionary-based page management, and central UI

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Media;
using PetStudyBuddy.Classes;

namespace PetStudyBuddy
{
    public partial class MainForm : Form
    {
        // --- OOP PROPERTIES ---
        // Central user object that demonstrates composition
        public Classes.User CurrentUser { get; set; }

        // Dictionary for page management with O(1) lookup time
        private Dictionary<string, BasePageControl> pages = new Dictionary<string, BasePageControl>();

        // Panel to host different page controls
        private Panel? contentPanel;

        // Timer state - SINGLE DEFINITION ONLY to avoid ambiguity
        private TimeSpan timeLeft;

        // --- CONSTRUCTOR ---
        public MainForm()
        {
            InitializeComponent();

            // INITIALIZE USER AND NAVIGATION
            CurrentUser = new Classes.User("Demo", "User", "demo", "password");
            SetupNavigation();

            // EXISTING EVENT HANDLERS - Fixed nullable warnings
            startTimerBTN.Click += StartButton_Click;
            countDownTimer.Tick += CountdownTimer_Tick;
            stopTimerBTN.Click += PauseButton_Click;
            addBTN.Click += AddButtonHandler;
            timeLeft = TimeSpan.FromMinutes(25);
            minusTimer.Click += MinusHandler;
            plusTimer.Click += PlusHandler;

            // PROFILE NAVIGATION
            // Connect the profilePic button to navigation handler
            profilePic.Click += ProfilePic_Click;

            // SETUP TASK DISPLAY
            tasksList.FlowDirection = FlowDirection.TopDown;
            tasksList.WrapContents = false;
            tasksList.AutoScroll = true;
            tasksList.HorizontalScroll.Enabled = false;
            tasksList.HorizontalScroll.Visible = false;
        }

        // --- NAVIGATION SYSTEM ---

        // Setup the container panel for page controls
        private void SetupNavigation()
        {
            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(contentPanel);
            contentPanel.SendToBack();
        }

        // Show a specific page by name
        public void ShowPage(string pageName)
        {
            if (pages.ContainsKey(pageName) && contentPanel != null)
            {
                // Hide main UI elements
                foreach (Control c in this.Controls)
                {
                    if (c != contentPanel) c.Visible = false;
                }

                // Show page in content panel
                contentPanel.Visible = true;
                contentPanel.BringToFront();
                contentPanel.Controls.Clear();
                contentPanel.Controls.Add(pages[pageName]);

                // Call lifecycle method on the page
                if (pages[pageName] is BasePageControl page)
                {
                    // Call OnPageEnter via reflection since it's protected
                    var method = page.GetType().GetMethod("OnPageEnter",
                        System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.NonPublic);
                    method?.Invoke(page, null);
                }
            }
        }

        // Return to the main screen from a page
        public void ShowMainPage()
        {
            if (contentPanel != null)
            {
                contentPanel.Visible = false;

                // Show main UI elements
                foreach (Control c in this.Controls)
                {
                    if (c != contentPanel) c.Visible = true;
                }

                // Call lifecycle method on the current page
                if (contentPanel.Controls.Count > 0 &&
                    contentPanel.Controls[0] is BasePageControl page)
                {
                    // Call OnPageLeave via reflection since it's protected
                    var method = page.GetType().GetMethod("OnPageLeave",
                        System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.NonPublic);
                    method?.Invoke(page, null);
                }
            }
        }

        // Navigate to profile page
        private void ProfilePic_Click(object? sender, EventArgs e)
        {
            if (!pages.ContainsKey("ProfilePage"))
            {
                pages["ProfilePage"] = new ProfilePage(this);
            }

            ShowPage("ProfilePage");
        }

        // --- TIMER FUNCTIONALITY ---

        private void PlusHandler(object? sender, EventArgs e)
        {
            timeLeft = timeLeft.Add(TimeSpan.FromMinutes(5));
            countDownLabel.Text = timeLeft.ToString(@"mm\:ss");
        }

        private void MinusHandler(object? sender, EventArgs e)
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

        private void StartButton_Click(object? sender, EventArgs e)
        {
            countDownLabel.Text = timeLeft.ToString(@"mm\:ss");
            countDownTimer.Start();
        }

        private void PauseButton_Click(object? sender, EventArgs e)
        {
            countDownLabel.Text = timeLeft.ToString(@"mm\:ss");
            countDownTimer.Stop();
        }

        private void CountdownTimer_Tick(object? sender, EventArgs e)
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

        // --- TASK MANAGEMENT ---

        private void AddButtonHandler(object? sender, EventArgs e)
        {
            using (AddTaskForm form = new AddTaskForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // CREATE TASK OBJECT - Using fully qualified name to avoid ambiguity
                    var task = new Classes.Task(form.TaskName, form.Description, form.DueDate)
                    {
                        XPReward = 2
                    };

                    CurrentUser.AddTask(task);
                    AddTaskToPanel(task);
                    UpdateProgressDisplay();
                }
            }
        }

        private void UpdateProgressDisplay()
        {
            toShop.Text = $"XP: {CurrentUser.XP}";

            int totalTasks = CurrentUser.Tasks.Count + CurrentUser.CompletedTasks.Count;
            int completedTasks = CurrentUser.CompletedTasks.Count;

            int progress = totalTasks > 0 ? (int)((double)completedTasks / totalTasks * 100) : 0;
            progressBar1.Value = Math.Min(progress, 100);
            totalItemsChecker.Text = $"{completedTasks}/{totalTasks}";
        }

        private void AddTaskToPanel(Classes.Task task)
        {
            Panel taskRow = new Panel
            {
                Height = 90,
                Width = tasksList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth,
                Padding = new Padding(5),
                BackColor = System.Drawing.Color.LightGray,
                AutoScroll = false,
                Tag = task
            };

            // Adjust row width when tasksList resizes
            tasksList.SizeChanged += (s, e) =>
            {
                taskRow.Width = tasksList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            };

            // Task completion checkbox
            CheckBox checkBox = new CheckBox
            {
                Location = new System.Drawing.Point(5, 10),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            // Handle checkbox changes - complete or uncomplete task
            checkBox.CheckedChanged += (s, e) =>
            {
                var taskObj = (Classes.Task)taskRow.Tag;

                if (checkBox.Checked)
                {
                    CurrentUser.CompleteTask(taskObj);
                    CurrentUser.CurrentPet?.OnTaskCompleted();
                }
                else
                {
                    // PROPER WAY TO HANDLE XP REDUCTION
                    if (CurrentUser.CompletedTasks.Contains(taskObj))
                    {
                        CurrentUser.CompletedTasks.Remove(taskObj);
                        CurrentUser.Tasks.Add(taskObj);
                        CurrentUser.ReduceXP(taskObj.XPReward);
                    }
                }

                UpdateProgressDisplay();
            };

            // Task name label
            Label nameLabel = new Label
            {
                Text = task.Title,
                AutoSize = true,
                Location = new System.Drawing.Point(30, 5),
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            // Task description label
            Label descLabel = new Label
            {
                Text = task.Description,
                AutoSize = true,
                Location = new System.Drawing.Point(30, 30),
                Font = new System.Drawing.Font("Segoe UI", 9),
                ForeColor = System.Drawing.Color.DimGray,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            // Due date label
            Label selectedDateLabel = new Label
            {
                Text = "Deadline: " + task.DueDate.ToShortDateString(),
                AutoSize = true,
                Location = new System.Drawing.Point(30, 50),
                Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Italic),
                ForeColor = System.Drawing.Color.Gray,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            // Due date label (top right corner)
            Label dueLabel = new Label
            {
                Text = task.DueDate.ToShortDateString(),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 9),
                ForeColor = System.Drawing.Color.DarkRed,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            // Delete button instead of missing resource
            Button deleteButton = new Button
            {
                Text = "X",
                Size = new System.Drawing.Size(20, 20),
                BackColor = System.Drawing.Color.Red,
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            // Position the due date and delete button
            void AdjustPositions()
            {
                dueLabel.Location = new System.Drawing.Point(taskRow.Width - dueLabel.Width - 50, 10);
                deleteButton.Location = new System.Drawing.Point(
                    taskRow.Width - deleteButton.Width - 10,
                    (taskRow.Height - deleteButton.Height) / 2
                );
            }

            // Reposition controls when row resizes
            taskRow.Resize += (s, e) => AdjustPositions();
            AdjustPositions();

            // Handle delete button click
            deleteButton.Click += (s, e) =>
            {
                var taskObj = (Classes.Task)taskRow.Tag;

                if (checkBox.Checked)
                {
                    CurrentUser.CompletedTasks.Remove(taskObj);
                }
                else
                {
                    CurrentUser.Tasks.Remove(taskObj);
                }

                tasksList.Controls.Remove(taskRow);
                taskRow.Dispose();
                UpdateProgressDisplay();
            };

            // Add controls to task row
            taskRow.Controls.Add(checkBox);
            taskRow.Controls.Add(nameLabel);
            taskRow.Controls.Add(descLabel);
            taskRow.Controls.Add(selectedDateLabel);
            taskRow.Controls.Add(dueLabel);
            taskRow.Controls.Add(deleteButton);

            // Add row to task list and position at top
            tasksList.Controls.Add(taskRow);
            tasksList.Controls.SetChildIndex(taskRow, 0);
        }

        private void tasksList_Paint(object? sender, PaintEventArgs e)
        {
            // Empty event handler - can be used for custom drawing
        }
    }
}