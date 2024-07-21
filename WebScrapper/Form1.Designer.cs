namespace WebScrapper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxUrl = new TextBox();
            btnGo = new Button();
            dataGridViewTask = new DataGridView();
            FieldName = new DataGridViewTextBoxColumn();
            Action = new DataGridViewTextBoxColumn();
            ExtractedData = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTask).BeginInit();
            SuspendLayout();
            // 
            // textBoxUrl
            // 
            textBoxUrl.Location = new Point(12, 12);
            textBoxUrl.Name = "textBoxUrl";
            textBoxUrl.Size = new Size(160, 23);
            textBoxUrl.TabIndex = 0;
            textBoxUrl.Text = "https://www.example.com";
            // 
            // btnGo
            // 
            btnGo.Location = new Point(178, 12);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(34, 23);
            btnGo.TabIndex = 1;
            btnGo.Text = "GO";
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += btnGo_Click;
            // 
            // dataGridViewTask
            // 
            dataGridViewTask.AllowUserToAddRows = false;
            dataGridViewTask.AllowUserToDeleteRows = false;
            dataGridViewTask.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTask.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTask.Columns.AddRange(new DataGridViewColumn[] { FieldName, Action, ExtractedData });
            dataGridViewTask.Location = new Point(218, 12);
            dataGridViewTask.Name = "dataGridViewTask";
            dataGridViewTask.ReadOnly = true;
            dataGridViewTask.Size = new Size(711, 103);
            dataGridViewTask.TabIndex = 2;
            // 
            // FieldName
            // 
            FieldName.HeaderText = "Field Name";
            FieldName.Name = "FieldName";
            FieldName.ReadOnly = true;
            // 
            // Action
            // 
            Action.HeaderText = "Action";
            Action.Name = "Action";
            Action.ReadOnly = true;
            // 
            // ExtractedData
            // 
            ExtractedData.HeaderText = "Data Extracted";
            ExtractedData.Name = "ExtractedData";
            ExtractedData.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 514);
            Controls.Add(dataGridViewTask);
            Controls.Add(btnGo);
            Controls.Add(textBoxUrl);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTask).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUrl;
        private Button btnGo;
        private DataGridView dataGridViewTask;
        private DataGridViewTextBoxColumn FieldName;
        private DataGridViewTextBoxColumn Action;
        private DataGridViewTextBoxColumn ExtractedData;
    }
}
