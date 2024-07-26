using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace WebScrapper
{
    public partial class FormMain : Form
    {
        private static FormMain _instance;
        private Form activeForm = null;
        public static FormMain Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FormMain();
                }
                return _instance;
            }
        }
        private IconButton currentButton;
        private Random random;
        private int tempIndex;
        private Panel leftBorderBtn;
        public FormMain()
        {
            InitializeComponent();
            _instance = this;
            random = new Random();
            //btnClose.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 40);
            leftBorderBtn.BackColor = System.Drawing.Color.FromArgb(62, 104, 182);
            panelMenu.Controls.Add(leftBorderBtn);

            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ActivateButton(object btnSender)
        {

            if (currentButton != (Button)btnSender)
            {
                DisableButton();
                currentButton = (IconButton)btnSender;
                System.Drawing.Color color = ThemeColor.Active;
                currentButton.BackColor = System.Drawing.Color.FromArgb(37, 36, 81);
                currentButton.ForeColor = color;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.IconColor = color;
                currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentButton.ImageAlign = ContentAlignment.MiddleRight;

                

                leftBorderBtn.Location = new Point(0, currentButton.Location.Y);
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                iconCurrentChildForm.IconChar = currentButton.IconChar;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;

            }
        }

        private void DisableButton()
        {
            if (currentButton != null)
            {
                leftBorderBtn.Visible = false;
                System.Drawing.Color color = ThemeColor.Passive;
                currentButton.BackColor = color;
                currentButton.ForeColor = System.Drawing.Color.Gainsboro;
                currentButton.TextAlign = ContentAlignment.MiddleLeft;
                currentButton.IconColor = System.Drawing.Color.Gainsboro;
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        public void OpenChildForm(Form childForm, object btnSender,bool? active)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            if (childForm.TopLevel)
            {
                childForm.TopLevel = false;
            }
            if(active!=false)
                ActivateButton(btnSender);
            activeForm = childForm;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelMainPanel.Controls.Add(childForm);
            this.panelMainPanel.Tag = childForm;
            childForm.BringToFront();
            lblTitle.Text = childForm.Text;
            childForm.Show();
        }


        private void Reset()
        {
            DisableButton();
            iconCurrentChildForm.IconChar = IconChar.None;
            lblTitle.Text = "";
            currentButton = null;
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMaxApp_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnMinApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAppClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormHome(), sender,true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                Reset();
            }
        }
    }
}
