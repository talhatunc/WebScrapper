using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebScrapper.Forms
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
            GetTasks();
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {
            Form formTask = new FormNewTask();
            formTask.Text = "New Task";
            FormMain.Instance.OpenChildForm(formTask, sender, false);
        }

        private void GetTasks()
        {
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tasks");
            List<string> fileNames = new List<string>();

            if (Directory.Exists(directory))
            {
                var files = Directory.GetFiles(directory, "*.json");
                foreach (var file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    listBoxTasks.Items.Add(fileName);
                }
            }
        }

        private void listBoxTasks_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxTasks.SelectedItem != null)
            {
                string selectedTaskName = listBoxTasks.SelectedItem.ToString();
                Form formTask = new FormNewTask(selectedTaskName);
                formTask.Text = selectedTaskName;
                FormMain.Instance.OpenChildForm(formTask, sender, false);
            }
        }
    }
}
