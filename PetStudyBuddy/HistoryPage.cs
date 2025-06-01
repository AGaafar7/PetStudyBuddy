// HistoryPage.cs - Shows completed tasks history
// Converted from Form to BasePageControl for OOP architecture

using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using PetStudyBuddy.Classes;

namespace PetStudyBuddy
{
    public partial class HistoryPage : BasePageControl
    {
        // --- CONSTRUCTOR ---
        public HistoryPage(MainForm parent) : base(parent)
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        // --- SETUP METHODS ---

        private void SetupEventHandlers()
        {
            BackButton.Click += BackButton_Click;
            exportButton.Click += ExportButton_Click;
        }

        // --- EVENT HANDLERS ---

        private void BackButton_Click(object? sender, EventArgs e)
        {
            GoToMainPage();
        }

        // Export completed tasks to CSV file - demonstrates bonus functionality
        private void ExportButton_Click(object? sender, EventArgs e)
        {
            if (CurrentUser != null && CurrentUser.CompletedTasks.Count > 0)
            {
                try
                {
                    // Create file with timestamp
                    string fileName = $"TaskHistory_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                    // Build CSV content
                    StringBuilder csv = new StringBuilder();
                    csv.AppendLine("Title,Description,Due Date,Completed Date,XP Reward");

                    foreach (var task in CurrentUser.CompletedTasks)
                    {
                        csv.AppendLine($"\"{task.Title}\",\"{task.Description}\",\"{task.DueDate:yyyy-MM-dd}\",\"{task.CompletedDate:yyyy-MM-dd HH:mm}\",{task.XPReward}");
                    }

                    // Save file
                    File.WriteAllText(fileName, csv.ToString());

                    MessageBox.Show($"Task history exported to {fileName} successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting tasks: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No completed tasks to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // --- DATA DISPLAY METHODS ---

        private void RefreshTaskHistory()
        {
            if (CurrentUser != null)
            {
                // Set task count label
                label2.Text = $"{CurrentUser.CompletedTasks.Count} tasks completed";

                // Clear and reload task list
                taskListPanel.Controls.Clear();

                // Add header if there are tasks
                if (CurrentUser.CompletedTasks.Count > 0)
                {
                    // Create headers
                    AddTaskHeader();

                    // Add each task
                    foreach (var task in CurrentUser.CompletedTasks)
                    {
                        AddTaskToPanel(task);
                    }
                }
                else
                {
                    Label noTasksLabel = new Label
                    {
                        Text = "No completed tasks yet. Complete tasks to see them here!",
                        AutoSize = true,
                        Location = new System.Drawing.Point(10, 10),
                        Font = new System.Drawing.Font("Segoe UI", 10)
                    };
                    taskListPanel.Controls.Add(noTasksLabel);
                }
            }
        }

        private void AddTaskHeader()
        {
            Panel headerRow = new Panel
            {
                Height = 30,
                Width = taskListPanel.Width - 20,
                BackColor = System.Drawing.Color.LightGray
            };

            Label titleHeader = new Label
            {
                Text = "Task",
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(10, 5),
                Width = 150
            };

            Label dateCompletedHeader = new Label
            {
                Text = "Completed",
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(170, 5),
                Width = 150
            };

            Label xpHeader = new Label
            {
                Text = "XP",
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(330, 5),
                Width = 50
            };

            headerRow.Controls.Add(titleHeader);
            headerRow.Controls.Add(dateCompletedHeader);
            headerRow.Controls.Add(xpHeader);

            taskListPanel.Controls.Add(headerRow);
        }

        private void AddTaskToPanel(Classes.Task task)
        {
            Panel taskRow = new Panel
            {
                Height = 35,
                Width = taskListPanel.Width - 20,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 5)
            };

            Label titleLabel = new Label
            {
                Text = task.Title,
                Font = new System.Drawing.Font("Segoe UI", 9),
                Location = new System.Drawing.Point(10, 7),
                Width = 150
            };

            Label dateCompletedLabel = new Label
            {
                Text = task.CompletedDate?.ToString("yyyy-MM-dd HH:mm") ?? "Unknown",
                Font = new System.Drawing.Font("Segoe UI", 9),
                Location = new System.Drawing.Point(170, 7),
                Width = 150
            };

            Label xpLabel = new Label
            {
                Text = task.XPReward.ToString(),
                Font = new System.Drawing.Font("Segoe UI", 9),
                Location = new System.Drawing.Point(330, 7),
                Width = 50
            };

            taskRow.Controls.Add(titleLabel);
            taskRow.Controls.Add(dateCompletedLabel);
            taskRow.Controls.Add(xpLabel);

            taskListPanel.Controls.Add(taskRow);
        }

        // --- LIFECYCLE METHODS OVERRIDE ---

        protected override void OnPageEnter()
        {
            base.OnPageEnter();
            RefreshTaskHistory();
        }

        protected override void RefreshPageData()
        {
            RefreshTaskHistory();
        }
    }
}