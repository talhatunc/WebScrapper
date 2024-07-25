namespace WebScrapper.Forms
{
    partial class FormHome
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
            btnNewTask = new Button();
            listBoxTasks = new ListBox();
            SuspendLayout();
            // 
            // btnNewTask
            // 
            btnNewTask.Anchor = AnchorStyles.None;
            btnNewTask.BackColor = Color.White;
            btnNewTask.FlatAppearance.BorderColor = Color.FromArgb(30, 145, 214);
            btnNewTask.FlatStyle = FlatStyle.Flat;
            btnNewTask.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnNewTask.ForeColor = Color.FromArgb(30, 145, 214);
            btnNewTask.Location = new Point(12, 25);
            btnNewTask.Name = "btnNewTask";
            btnNewTask.Size = new Size(109, 33);
            btnNewTask.TabIndex = 0;
            btnNewTask.Text = "+ Task";
            btnNewTask.UseVisualStyleBackColor = false;
            btnNewTask.Click += btnNewTask_Click;
            // 
            // listBoxTasks
            // 
            listBoxTasks.Anchor = AnchorStyles.None;
            listBoxTasks.FormattingEnabled = true;
            listBoxTasks.ItemHeight = 15;
            listBoxTasks.Location = new Point(12, 64);
            listBoxTasks.Name = "listBoxTasks";
            listBoxTasks.Size = new Size(109, 304);
            listBoxTasks.TabIndex = 1;
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(143, 380);
            Controls.Add(listBoxTasks);
            Controls.Add(btnNewTask);
            Name = "FormHome";
            Text = "Home";
            ResumeLayout(false);
        }

        #endregion

        private Button btnNewTask;
        private ListBox listBoxTasks;
    }
}