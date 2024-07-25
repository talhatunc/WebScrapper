namespace WebScrapper
{
    partial class FormNewTask
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
            dataGridViewTask = new DataGridView();
            FieldName = new DataGridViewTextBoxColumn();
            Action = new DataGridViewTextBoxColumn();
            ExtractedData = new DataGridViewTextBoxColumn();
            btnGo = new Button();
            tableLayoutPanelMain = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTask).BeginInit();
            tableLayoutPanelMain.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxUrl
            // 
            textBoxUrl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxUrl.Location = new Point(402, 3);
            textBoxUrl.Name = "textBoxUrl";
            textBoxUrl.Size = new Size(244, 23);
            textBoxUrl.TabIndex = 0;
            textBoxUrl.Text = "https://www.example.com";
            // 
            // dataGridViewTask
            // 
            dataGridViewTask.AllowUserToAddRows = false;
            dataGridViewTask.AllowUserToDeleteRows = false;
            dataGridViewTask.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewTask.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTask.Columns.AddRange(new DataGridViewColumn[] { FieldName, Action, ExtractedData });
            dataGridViewTask.Dock = DockStyle.Fill;
            dataGridViewTask.Location = new Point(3, 3);
            dataGridViewTask.Name = "dataGridViewTask";
            dataGridViewTask.ReadOnly = true;
            dataGridViewTask.Size = new Size(699, 142);
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
            // btnGo
            // 
            btnGo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGo.BackColor = Color.White;
            btnGo.FlatStyle = FlatStyle.Flat;
            btnGo.Font = new Font("Microsoft Sans Serif", 8F);
            btnGo.ForeColor = Color.FromArgb(30, 145, 214);
            btnGo.Location = new Point(652, 3);
            btnGo.Name = "btnGo";
            btnGo.Size = new Size(44, 23);
            btnGo.TabIndex = 1;
            btnGo.Text = "GO";
            btnGo.UseVisualStyleBackColor = false;
            btnGo.Click += btnGo_Click;
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 1;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanelMain.Controls.Add(btnSave, 0, 2);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 3;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 220F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanelMain.Size = new Size(1226, 539);
            tableLayoutPanelMain.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.6666679F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1220, 214);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 589F));
            tableLayoutPanel2.Controls.Add(dataGridViewTask, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel2.Size = new Size(705, 208);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
            tableLayoutPanel3.Controls.Add(btnGo, 2, 0);
            tableLayoutPanel3.Controls.Add(textBoxUrl, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 151);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(699, 54);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnSave.ForeColor = Color.FromArgb(30, 145, 214);
            btnSave.Location = new Point(1132, 489);
            btnSave.Margin = new Padding(3, 10, 10, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(84, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "SAVE";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // FormNewTask
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1226, 539);
            Controls.Add(tableLayoutPanelMain);
            Name = "FormNewTask";
            Text = "Task";
            ((System.ComponentModel.ISupportInitialize)dataGridViewTask).EndInit();
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxUrl;
        private DataGridView dataGridViewTask;
        private DataGridViewTextBoxColumn FieldName;
        private DataGridViewTextBoxColumn Action;
        private DataGridViewTextBoxColumn ExtractedData;
        private Button btnGo;
        private TableLayoutPanel tableLayoutPanelMain;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSave;
    }
}
