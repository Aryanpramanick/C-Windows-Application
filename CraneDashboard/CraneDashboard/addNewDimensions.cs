using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CraneDashboard.frmSettings;

namespace CraneDashboard
{
    public partial class addNewDimensions : Form
    {
        public addNewDimensions()
        {
            InitializeComponent();
        }

        private void addNewDimensions_Load(object sender, EventArgs e)
        {

        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            Global1.weight = int.Parse(textBox1.Text);
        }
    }
}
