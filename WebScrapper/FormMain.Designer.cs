namespace WebScrapper
{
    partial class FormMain
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
            panelMenu = new Panel();
            btnHome = new Button();
            panelLogo = new Panel();
            label1 = new Label();
            panelMainPanel = new Panel();
            panelTitle = new Panel();
            btnAppClose = new Button();
            btnMinApp = new Button();
            btnMaxApp = new Button();
            btnClose = new Button();
            lblTitle = new Label();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelMainPanel.SuspendLayout();
            panelTitle.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(30, 114, 187);
            panelMenu.Controls.Add(btnHome);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(220, 546);
            panelMenu.TabIndex = 0;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.Gainsboro;
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(0, 38);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(11, 0, 0, 0);
            btnHome.Size = new Size(220, 40);
            btnHome.TabIndex = 1;
            btnHome.Text = "  Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(0, 114, 187);
            panelLogo.Controls.Add(label1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(220, 38);
            panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(34, 9);
            label1.Name = "label1";
            label1.Size = new Size(144, 18);
            label1.TabIndex = 0;
            label1.Text = "github.com/talhatunc";
            // 
            // panelMainPanel
            // 
            panelMainPanel.Controls.Add(panelTitle);
            panelMainPanel.Dock = DockStyle.Fill;
            panelMainPanel.Location = new Point(220, 0);
            panelMainPanel.Name = "panelMainPanel";
            panelMainPanel.Size = new Size(849, 546);
            panelMainPanel.TabIndex = 2;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.FromArgb(0, 114, 187);
            panelTitle.Controls.Add(btnMinApp);
            panelTitle.Controls.Add(btnMaxApp);
            panelTitle.Controls.Add(btnAppClose);
            panelTitle.Controls.Add(btnClose);
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(849, 38);
            panelTitle.TabIndex = 0;
            panelTitle.MouseDown += panelTitle_MouseDown;
            // 
            // btnAppClose
            // 
            btnAppClose.Dock = DockStyle.Right;
            btnAppClose.FlatAppearance.BorderSize = 0;
            btnAppClose.FlatStyle = FlatStyle.Flat;
            btnAppClose.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            btnAppClose.ForeColor = Color.Transparent;
            btnAppClose.Location = new Point(816, 0);
            btnAppClose.Name = "btnAppClose";
            btnAppClose.Size = new Size(33, 38);
            btnAppClose.TabIndex = 5;
            btnAppClose.Text = "x";
            btnAppClose.UseVisualStyleBackColor = true;
            btnAppClose.Click += btnAppClose_Click;
            // 
            // btnMinApp
            // 
            btnMinApp.Dock = DockStyle.Right;
            btnMinApp.FlatAppearance.BorderSize = 0;
            btnMinApp.FlatStyle = FlatStyle.Flat;
            btnMinApp.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnMinApp.ForeColor = Color.Transparent;
            btnMinApp.Location = new Point(750, 0);
            btnMinApp.Name = "btnMinApp";
            btnMinApp.Size = new Size(33, 38);
            btnMinApp.TabIndex = 4;
            btnMinApp.Text = "-";
            btnMinApp.UseVisualStyleBackColor = true;
            btnMinApp.Click += btnMinApp_Click;
            // 
            // btnMaxApp
            // 
            btnMaxApp.Dock = DockStyle.Right;
            btnMaxApp.FlatAppearance.BorderSize = 0;
            btnMaxApp.FlatStyle = FlatStyle.Flat;
            btnMaxApp.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            btnMaxApp.ForeColor = Color.Transparent;
            btnMaxApp.Location = new Point(783, 0);
            btnMaxApp.Name = "btnMaxApp";
            btnMaxApp.Size = new Size(33, 38);
            btnMaxApp.TabIndex = 3;
            btnMaxApp.Text = "o";
            btnMaxApp.UseVisualStyleBackColor = true;
            btnMaxApp.Click += btnMaxApp_Click;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnClose.ForeColor = Color.Transparent;
            btnClose.Location = new Point(6, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(33, 38);
            btnClose.TabIndex = 2;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTitle.ForeColor = Color.LightGray;
            lblTitle.Location = new Point(387, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 18);
            lblTitle.TabIndex = 1;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1069, 546);
            Controls.Add(panelMainPanel);
            Controls.Add(panelMenu);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WebScrapper";
            WindowState = FormWindowState.Maximized;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelMainPanel.ResumeLayout(false);
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Button btnHome;
        private Panel panelLogo;
        private Label label1;
        private Panel panelMainPanel;
        private Panel panelTitle;
        private Label lblTitle;
        private Button btnClose;
        private Button btnAppClose;
        private Button btnMinApp;
        private Button btnMaxApp;
    }
}