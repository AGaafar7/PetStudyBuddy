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
    public partial class AddTaskForm : Form
    {

        public string TaskName => taskNameField.Text;
        public string Description => taskDescriptionField.Text;
        public DateTime DueDate => dueDatePicker.Value;


        public AddTaskForm()
        {
            InitializeComponent();
            saveBTN.Click += btnSave_Click;
            BTNcancel.Click += btnCancel_Click;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(taskNameField.Text))
            {
                MessageBox.Show("Task name is required.");
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
