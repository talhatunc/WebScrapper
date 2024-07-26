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
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {
            Form formTask = new FormNewTask();
            formTask.Text = "New Task";
            FormMain.Instance.OpenChildForm(formTask, sender,false);
        }
    }
}
