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
            // 
            BackButton.Location = new Point(17, 20);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(94, 29);
            BackButton.TabIndex = 0;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(329, 29);
            label1.Name = "label1";
            label1.Size = new Size(87, 20);
            label1.TabIndex = 1;
            label1.Text = "Task History";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(347, 68);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(313, 114);
            label3.Name = "label3";
            label3.Size = new Size(120, 20);
            label3.TabIndex = 3;
            label3.Text = "Tasks Completed";
            // 
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
