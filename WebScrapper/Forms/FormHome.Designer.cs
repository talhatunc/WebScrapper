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
            listBoxTasks = new ListBox();
            btnNewTask = new FontAwesome.Sharp.IconButton();
            SuspendLayout();
            // 
            // listBoxTasks
            // 
            listBoxTasks.Anchor = AnchorStyles.None;
            listBoxTasks.FormattingEnabled = true;
            listBoxTasks.ItemHeight = 15;
            listBoxTasks.Location = new Point(13, 64);
            listBoxTasks.Name = "listBoxTasks";
            listBoxTasks.Size = new Size(109, 304);
            listBoxTasks.TabIndex = 1;
            listBoxTasks.DoubleClick += listBoxTasks_DoubleClick;
            // 
            // btnNewTask
            // 
            btnNewTask.Anchor = AnchorStyles.None;
            btnNewTask.FlatAppearance.BorderColor = Color.FromArgb(172, 126, 241);
            btnNewTask.FlatStyle = FlatStyle.Flat;
            btnNewTask.ForeColor = Color.FromArgb(172, 126, 241);
            btnNewTask.IconChar = FontAwesome.Sharp.IconChar.Plus;
            btnNewTask.IconColor = Color.FromArgb(172, 126, 241);
            btnNewTask.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnNewTask.IconSize = 20;
            btnNewTask.Location = new Point(13, 26);
            btnNewTask.Name = "btnNewTask";
            btnNewTask.Size = new Size(109, 32);
            btnNewTask.TabIndex = 2;
            btnNewTask.Text = "New Task";
            btnNewTask.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnNewTask.UseVisualStyleBackColor = true;
            btnNewTask.Click += btnNewTask_Click;
            // 
            // FormHome
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(134, 380);
            Controls.Add(btnNewTask);
            Controls.Add(listBoxTasks);
            Name = "FormHome";
            Text = "Home";
            ResumeLayout(false);
        }

        #endregion
        private ListBox listBoxTasks;
        private FontAwesome.Sharp.IconButton btnNewTask;
    }
}