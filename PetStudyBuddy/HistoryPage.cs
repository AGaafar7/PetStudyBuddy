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
            LoadTaskHistory();
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
            this.Close(); // or NavigateBack();
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var dashboard = new MainPage();
            dashboard.Show();
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv",
                Title = "Export Task History"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (ListViewItem item in taskListView.Items)
                    {
                        string line = string.Join(",", item.SubItems
                            .Cast<ListViewItem.ListViewSubItem>()
                            .Select(i => i.Text));
                        writer.WriteLine(line);
                    }
                }
                MessageBox.Show("Export successful!");
            }
        }

        private void LoadTaskHistory()
        {
            // Dummy data for now
            string[,] tasks = {
                { "Finish Homework", "2025-06-01", "Completed" },
                { "Feed Pet", "2025-06-02", "Completed" },
                { "Clean Room", "2025-06-02", "Pending" }
            };

            taskListView.Items.Clear();
            int completedCount = 0;

            for (int i = 0; i < tasks.GetLength(0); i++)
            {
                var item = new ListViewItem(tasks[i, 0]);
                item.SubItems.Add(tasks[i, 1]);
                item.SubItems.Add(tasks[i, 2]);
                taskListView.Items.Add(item);

                if (tasks[i, 2] == "Completed")
                    completedCount++;
            }

            labelCompleted.Text = $"✔ Tasks Completed: {completedCount}";
        }
}
}
