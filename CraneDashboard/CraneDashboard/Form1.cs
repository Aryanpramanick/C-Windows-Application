using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ClassLibrary1;

namespace CraneDashboard
{
    public partial class Form1 : Form
    {
        public static class Global
        {
            public static string conn;
            public static string host="false";
            public static List<int> selected_cranes = new List<int>();
        }

        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            

           
            //btnWelcome.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Welcome";
            pnlNav.Height = btnWelcome.Height;
            pnlNav.Top = btnWelcome.Top;
            pnlNav.Left = btnWelcome.Left;
            this.pnlFormLoader.Controls.Clear();
            frmWelcome FrmDashboard_Vrb = new frmWelcome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
            //btnWelcome.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnDataEntry.Enabled = false;
            btnCalender.Enabled = false;
            btnSiteLayout.Enabled = false;
            btnSettings.Enabled = false;
        }

        private void btnDataEntry_Click(object sender, EventArgs e)
        {
         

            lblTitle.Text = "Data Entry";
            pnlNav.Height = btnDataEntry.Height;
            pnlNav.Top = btnDataEntry.Top;
            pnlNav.Left = btnDataEntry.Left;
            this.pnlFormLoader.Controls.Clear();
            frmDataEntry FrmDashboard_Vrb = new frmDataEntry() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
            myBtnSetting(btnDataEntry, null);
            //btnDataEntry.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
           // pnlNav.Height = btnAnalytics.Height;
           // pnlNav.Top = btnAnalytics.Top;
            

            lblTitle.Text = "Analytics";
            this.pnlFormLoader.Controls.Clear();
            frmAnalytics FrmDashboard_Vrb = new frmAnalytics() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
           // myBtnSetting(btnAnalytics, null);
            //btnAnalytics.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnCalender_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCalender.Height;
            pnlNav.Top = btnCalender.Top;
            
            lblTitle.Text = "Crane Selection";
            this.pnlFormLoader.Controls.Clear();
            frmCalender FrmDashboard_Vrb = new frmCalender() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
            myBtnSetting(btnCalender, null);
            //btnCalender.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnSiteLayout_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSiteLayout.Height;
            pnlNav.Top = btnSiteLayout.Top;
            
            lblTitle.Text = "Site Layout";
            this.pnlFormLoader.Controls.Clear();
            frmSiteLayout FrmDashboard_Vrb = new frmSiteLayout() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
            myBtnSetting(btnSiteLayout, null);
            //btnSiteLayout.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnTestTest_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDataEntry.Height;
            pnlNav.Top = btnDataEntry.Top;            

            lblTitle.Text = "Data Entry";
            this.pnlFormLoader.Controls.Clear();
            frmDataEntry FrmDashboard_Vrb = new frmDataEntry() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
            myBtnSetting(btnDataEntry, null);
            //btnDataEntry.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSettings.Height;
            pnlNav.Top = btnSettings.Top;
            
            lblTitle.Text = "View";
            this.pnlFormLoader.Controls.Clear();
            Form2 FrmDashboard_Vrb = new Form2() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
            myBtnSetting(btnSettings, null);
            //btnSettings.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnWelcome_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnWelcome.Height;
            pnlNav.Top = btnWelcome.Top;

            lblTitle.Text = "Welcome";
            this.pnlFormLoader.Controls.Clear();
            frmWelcome FrmDashboard_Vrb = new frmWelcome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
            myBtnSetting(btnWelcome, null);
            btnWelcome.BackColor = Color.FromArgb(255, 155, 0);
        }

        private void btnWelcome_Leave_1(object sender, EventArgs e)
        {
            //btnWelcome.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pnlFormLoader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void myBtnSetting ( object sender, EventArgs e)
        { 
            foreach(Control c in panel1.Controls)
            {
                c.BackColor = Color.FromArgb(255, 208, 0);
                c.ForeColor = Color.FromArgb(0, 0, 0);
                pnlNav.BackColor = Color.Silver;
                
            }
            
            Control click = (Control)sender;
            click.BackColor = Color.FromArgb(255, 180, 0);
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Global.host == "false")
            {
                btnDataEntry.Enabled = false;
                btnCalender.Enabled = false;
                btnSiteLayout.Enabled = false;
            }
            else if (Global.host == "true")
            {
                btnDataEntry.Enabled = true;
                btnCalender.Enabled = true;
                btnSiteLayout.Enabled = true;
                btnSettings.Enabled = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Global.host == "false")
            {
                btnDataEntry.Enabled = false;
                btnCalender.Enabled = false;
                btnSiteLayout.Enabled = false;
                btnSettings.Enabled= false;
            }
            else if (Global.host == "true")
            {
                btnDataEntry.Enabled = true;
                btnCalender.Enabled = true;
                btnSiteLayout.Enabled = true;
                btnSettings.Enabled = true;
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
    
}
