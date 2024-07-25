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
        private Button currentButton;
        private Random random;
        private int tempIndex;
        public FormMain()
        {
            InitializeComponent();
            _instance = this;
            random = new Random();
            btnClose.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
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
                Color color = ThemeColor.Active;
                currentButton = (Button)btnSender;
                currentButton.BackColor = color;
                currentButton.ForeColor = Color.White;
                currentButton.Font = new Font("Microsoft Sans Serif", 13.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
                btnClose.Visible = true;
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = ThemeColor.Passive;
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
                }
            }
        }
        public void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            if (childForm.TopLevel)
            {
                childForm.TopLevel = false;
            }
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
        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormHome(), sender);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                Reset();
            }
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "";
            currentButton = null;
            btnClose.Visible = false;
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
    }
}
