using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetStudyBuddy
{
    public partial class HistoryPage : Form
    {
        public HistoryPage()
        {
            InitializeComponent();
            LoadTaskHistory();
        }

        private void BackButton_Click(object sender, EventArgs e)
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
