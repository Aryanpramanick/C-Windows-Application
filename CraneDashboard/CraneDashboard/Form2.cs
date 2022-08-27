using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CraneDashboard
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("LR1300 Charts.pdf");
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("LR1300 luffing charts 1s.pdf");
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("LR1300 luffing charts 2s.pdf");
        }

        private void pictureBox5_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("LR1300 luffing charts 3s.pdf");
        }

        private void pictureBox4_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("LR1300 luffing charts 4s.pdf");
        }

        private void pictureBox6_DoubleClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("LR1300 luffing charts 5s.pdf");
        }
    }
}
