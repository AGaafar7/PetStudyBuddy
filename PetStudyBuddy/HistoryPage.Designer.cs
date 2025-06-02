namespace PetStudyBuddy
{
    partial class HistoryPage
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.BackButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelCompleted = new System.Windows.Forms.Label();
            this.taskListView = new System.Windows.Forms.ListView();
            this.columnTask = new System.Windows.Forms.ColumnHeader();
            this.columnDate = new System.Windows.Forms.ColumnHeader();
            this.columnStatus = new System.Windows.Forms.ColumnHeader();
            this.dashboardButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // BackButton
            this.BackButton.Location = new System.Drawing.Point(20, 20);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(94, 29);
            this.BackButton.Text = "← Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);

            // ExportButton
            this.ExportButton.Location = new System.Drawing.Point(130, 20);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(94, 29);
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);

            // labelHeader
            this.labelHeader.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.labelHeader.Location = new System.Drawing.Point(0, 60);
            this.labelHeader.Size = new System.Drawing.Size(800, 40);
            this.labelHeader.Text = "Task History";
            this.labelHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // labelCompleted
            this.labelCompleted.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelCompleted.Location = new System.Drawing.Point(20, 110);
            this.labelCompleted.Size = new System.Drawing.Size(300, 30);
            this.labelCompleted.Text = "✔ Tasks Completed: 0";

            // taskListView
            this.taskListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        this.columnTask,
        this.columnDate,
        this.columnStatus});
            this.taskListView.FullRowSelect = true;
            this.taskListView.GridLines = true;
            this.taskListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.taskListView.Location = new System.Drawing.Point(20, 160);
            this.taskListView.Size = new System.Drawing.Size(760, 200);
            this.taskListView.View = System.Windows.Forms.View.Details;

            // columnTask
            this.columnTask.Text = "Task";
            this.columnTask.Width = 300;

            // columnDate
            this.columnDate.Text = "Date";
            this.columnDate.Width = 200;

            // columnStatus
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 200;

            // dashboardButton
            this.dashboardButton.Location = new System.Drawing.Point(320, 380);
            this.dashboardButton.Size = new System.Drawing.Size(160, 40);
            this.dashboardButton.Text = "Return to Home";
            this.dashboardButton.UseVisualStyleBackColor = true;
            this.dashboardButton.Click += new System.EventHandler(this.DashboardButton_Click);

            // HistoryPage
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.dashboardButton);
            this.Controls.Add(this.taskListView);
            this.Controls.Add(this.labelCompleted);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.BackButton);
            this.Name = "HistoryPage";
            this.Text = "Task History";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelCompleted;
        private System.Windows.Forms.ListView taskListView;
        private System.Windows.Forms.ColumnHeader columnTask;
        private System.Windows.Forms.ColumnHeader columnDate;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.Button dashboardButton;



        #endregion
    }
}
