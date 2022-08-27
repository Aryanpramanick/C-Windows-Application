using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CraneDashboard.Form1;

namespace CraneDashboard
{
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
        }
        OleDbConnection con2 = new OleDbConnection();
        OleDbConnection connectionS = new OleDbConnection();
        OpenFileDialog ofd = new OpenFileDialog();
        // make form border round
        private void frmWelcome_Load(object sender, EventArgs e)
        {
                    OpenFileDialog ofd = new OpenFileDialog();
        // make form border round
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Global.conn = "Provider = Microsoft.ACE.OLEDB.12.0; " + @"Data Source = " + ofd.FileName;

                        textBox3.Text = ofd.FileName;
                        con2.ConnectionString = @Global.conn;
                        con2.Open();
                        Global.host = "true";
                        MessageBox.Show("Connection Successful. Site layout loaded.");

                        string filename = "LocationShared";
                        FileInfo f = new FileInfo(filename);
                        string fullname = f.FullName;
                        connectionS.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; " + @"Data Source =" + fullname + ".accdb";
                        connectionS.Open();


                        var query = "DELETE FROM Location";
                        OleDbCommand cmdQ = new OleDbCommand(query, connectionS);
                        cmdQ.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Connection Unsuccessful. Please select correct file type: .accdb");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblModule1_Click(object sender, EventArgs e)
        {

        }
    }
}
