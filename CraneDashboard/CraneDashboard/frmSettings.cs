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

    public partial class frmSettings : Form
    {
        public static class Global1
        {
            public static int len;
            public static int wid;
            public static int hei;
            public static int weight;
        }


        public frmSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Global1.len = int.Parse(textBox4.Text);
            Global1.wid = int.Parse(textBox5.Text);
            Global1.hei = int.Parse(textBox6.Text);
        }
    }
}