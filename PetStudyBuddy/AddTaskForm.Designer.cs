namespace PetStudyBuddy
{
    partial class AddTaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            taskNameField = new TextBox();
            taskDescriptionField = new TextBox();
            dueDatePicker = new DateTimePicker();
            saveBTN = new Button();
            BTNcancel = new Button();
            SuspendLayout();
            // 
            // taskNameField
            // 
            taskNameField.Location = new Point(311, 92);
            taskNameField.Name = "taskNameField";
            taskNameField.Size = new Size(125, 27);
            taskNameField.TabIndex = 0;
            // 
            // taskDescriptionField
            // 
            taskDescriptionField.Location = new Point(311, 154);
            taskDescriptionField.Name = "taskDescriptionField";
            taskDescriptionField.Size = new Size(125, 27);
            taskDescriptionField.TabIndex = 1;
            // 
            // dueDatePicker
            // 
            dueDatePicker.Location = new Point(252, 207);
            dueDatePicker.Name = "dueDatePicker";
            dueDatePicker.Size = new Size(250, 27);
            dueDatePicker.TabIndex = 2;
            // 
            // saveBTN
            // 
            saveBTN.Location = new Point(252, 249);
            saveBTN.Name = "saveBTN";
            saveBTN.Size = new Size(94, 29);
            saveBTN.TabIndex = 3;
            saveBTN.Text = "Save";
            saveBTN.UseVisualStyleBackColor = true;
            // 
            // BTNcancel
            // 
            BTNcancel.Location = new Point(408, 249);
            BTNcancel.Name = "BTNcancel";
            BTNcancel.Size = new Size(94, 29);
            BTNcancel.TabIndex = 4;
            BTNcancel.Text = "Cancel";
            BTNcancel.UseVisualStyleBackColor = true;
            // 
            // AddTaskForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BTNcancel);
            Controls.Add(saveBTN);
            Controls.Add(dueDatePicker);
            Controls.Add(taskDescriptionField);
            Controls.Add(taskNameField);
            Name = "AddTaskForm";
            Text = "AddTask";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox taskNameField;
        private TextBox taskDescriptionField;
        private DateTimePicker dueDatePicker;
        private Button saveBTN;
        private Button BTNcancel;
    }
}