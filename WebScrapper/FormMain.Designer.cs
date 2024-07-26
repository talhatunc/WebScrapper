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
            btnHome = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            label1 = new Label();
            panelMainPanel = new Panel();
            panelTitle = new Panel();
            iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            btnMinApp = new Button();
            btnMaxApp = new Button();
            btnAppClose = new Button();
            lblTitle = new Label();
            label2 = new Label();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelMainPanel.SuspendLayout();
            panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(31, 30, 68);
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
            btnHome.Font = new Font("Microsoft Sans Serif", 12F);
            btnHome.ForeColor = Color.Gainsboro;
            btnHome.IconChar = FontAwesome.Sharp.IconChar.HomeLgAlt;
            btnHome.IconColor = Color.Gainsboro;
            btnHome.IconFont = FontAwesome.Sharp.IconFont.Solid;
            btnHome.IconSize = 35;
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(0, 38);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(10, 0, 20, 0);
            btnHome.Size = new Size(220, 40);
            btnHome.TabIndex = 2;
            btnHome.Text = "Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnHome.UseVisualStyleBackColor = true;
            btnHome.Click += btnHome_Click_1;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(31, 30, 68);
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
            panelMainPanel.BackColor = Color.FromArgb(34, 33, 74);
            panelMainPanel.Controls.Add(label2);
            panelMainPanel.Controls.Add(panelTitle);
            panelMainPanel.Dock = DockStyle.Fill;
            panelMainPanel.Location = new Point(220, 0);
            panelMainPanel.Name = "panelMainPanel";
            panelMainPanel.Size = new Size(849, 546);
            panelMainPanel.TabIndex = 2;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.FromArgb(26, 25, 62);
            panelTitle.Controls.Add(iconCurrentChildForm);
            panelTitle.Controls.Add(btnMinApp);
            panelTitle.Controls.Add(btnMaxApp);
            panelTitle.Controls.Add(btnAppClose);
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(849, 38);
            panelTitle.TabIndex = 0;
            panelTitle.MouseDown += panelTitle_MouseDown;
            // 
            // iconCurrentChildForm
            // 
            iconCurrentChildForm.BackColor = Color.Transparent;
            iconCurrentChildForm.ForeColor = Color.Gainsboro;
            iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.None;
            iconCurrentChildForm.IconColor = Color.Gainsboro;
            iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCurrentChildForm.Location = new Point(3, 3);
            iconCurrentChildForm.Name = "iconCurrentChildForm";
            iconCurrentChildForm.Size = new Size(32, 32);
            iconCurrentChildForm.TabIndex = 6;
            iconCurrentChildForm.TabStop = false;
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
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblTitle.ForeColor = Color.LightGray;
            lblTitle.Location = new Point(41, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 18);
            lblTitle.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(209, 266);
            label2.Name = "label2";
            label2.Size = new Size(467, 55);
            label2.TabIndex = 1;
            label2.Text = "github.com/talhatunc";
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
            panelMainPanel.PerformLayout();
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel panelLogo;
        private Label label1;
        private Panel panelMainPanel;
        private Panel panelTitle;
        private Label lblTitle;
        private Button btnAppClose;
        private Button btnMinApp;
        private Button btnMaxApp;
        private FontAwesome.Sharp.IconButton btnHome;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private Label label2;
    }
}