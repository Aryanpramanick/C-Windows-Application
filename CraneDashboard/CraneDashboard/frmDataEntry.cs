using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using System.Data.OleDb;
using static CraneDashboard.Form1;
using System.IO;
using static CraneDashboard.frmSettings;

namespace CraneDashboard
{
    public partial class frmDataEntry : Form
    {
        private int rowIndex = 0;
        List<String> dataa1 = new List<String>();
        List<String> dataa2 = new List<String>();
        // Global Variables
        OleDbConnection con = new OleDbConnection();                    // create new OleDbConnection
        OleDbDataAdapter DataAdapter = new OleDbDataAdapter();          // to access values from Access table (Fill or Update)
        DataTable LocalDataTable = new DataTable();
        OleDbDataAdapter DataAdapter1 = new OleDbDataAdapter(); // local data table as container for the values of Access Table
        DataTable LocalDataTable2 = new DataTable();
        OleDbDataAdapter DataAdapter2 = new OleDbDataAdapter();
        DataTable LocalDataTable3 = new DataTable();

        int NB_Modules = 0;

        public frmDataEntry()
        {
            InitializeComponent();
        }

        private void ConnectToDatabase()
        {
            con.ConnectionString = @Global.conn;   //in Debug folder: use "Source=filename.accdb"
            try
            {
                if (Global.conn == null)
                {
                    MessageBox.Show("Database not connected");
                }
                else
                {
                    con.Open();
                }
            }
            catch
            {
                MessageBox.Show("Database not connected");
            }

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            if (txtM1_X.Text.Equals("") || txtM1_Y.Text.Equals("") ||
                txtM1_Z.Text.Equals("") || txtM1_Angle.Text.Equals(""))
            {
                btnModSubmit.Enabled = false;
            }
            if (txtPA_TopLeftX.Text.Equals("") || txtPA_TopLeftY.Text.Equals("") ||
  txtPA_Width.Text.Equals("") || txtPA_Length.Text.Equals(""))
            {
                btnPASubmit.Enabled = false;
            }
            string[] data1 = { "20 ft * 20 ft * 20 ft", "40 ft * 20 ft * 20 ft", "60 ft * 20 ft * 20 ft", "New Dimensions" };
            string[] data2 = { "100,000 lbs", "200,000 lbs", "300,000 lbs", "New Weight" };

            dataa1.AddRange(data1);
            dataa2.AddRange(data2);
            comboBox1.DataSource = dataa1;
            comboBox2.DataSource = dataa2;
            try
            {
                ConnectToDatabase();

                DataAdapter = new OleDbDataAdapter("SELECT * FROM NCSG_CranesList", con);    // all the SQL queries: called 'OLEDB Command Builder'
                DataAdapter.Fill(LocalDataTable);                       // Load everything from Access into local data table. To push data in opposite direction: use .Update(LocalDataTable)

                List<Crane> craneList = new List<Crane>();
                craneList = (from DataRow dr in LocalDataTable.Rows     // Convert datatable to a list using LINQ
                             select new Crane()
                             {
                                 CraneID = dr["CraneID"].ToString(),
                                 Name = dr["Make"].ToString() + " " + dr["Model"].ToString() + ", " + dr["Configuration"].ToString() + " -- " + dr["ModelYear"].ToString(),
                                 Capacity = Convert.ToInt32(dr["Capacity"]),
                                 Rmax = Convert.ToInt32(dr["MaxRadius"]),
                                 LiftHeight = Convert.ToInt32(dr["LiftHeight"]),
                                 CraneWeight = Convert.ToInt32(dr["CraneWeight"]),
                                 ImageFile = dr["ImageFile"].ToString()
                             }).ToList();

                //cboCrane.DataSource = craneList;
                //  cboCrane.ValueMember = "CraneID";
                //  cboCrane.DisplayMember = "Name";
            }
            catch { }
            DataAdapter2 = new OleDbDataAdapter("SELECT * FROM PickAreas", con);    // all the SQL queries: called 'OLEDB Command Builder'
            DataAdapter2.Fill(LocalDataTable3);                      // Load everything from Access into local data table. To push data in opposite direction: use .Update(LocalDataTable)

            // method 2 - DataGridView columns (First: "Edit Columns" in DataGridView - "Add Columns": give it the Column Name and a Header text) ; under "Edit Columns", we have to change the "DataPropertyName" to the Column Name (do this for all the added columns)

            dgv2.DataSource = LocalDataTable3;
            DataAdapter1 = new OleDbDataAdapter("SELECT * FROM [Modules]", con);
            DataAdapter1.Fill(LocalDataTable2);      //System.Data.OleDb.OleDbException: 'IErrorInfo.GetDescription failed with E_FAIL(0x80004005).'
            dgv1.DataSource = LocalDataTable2;
            NB_Modules = LocalDataTable2.Rows.Count;

        }

        private void cboCrane_SelectionChangeCommitted(object sender, EventArgs e)
        {/*
            Crane obj = cboCrane.SelectedItem as Crane;
            if (obj != null)
            {
                lblCapacity.Text = obj.Capacity.ToString();
                lblMaxRadius.Text = obj.Rmax.ToString();
                lblLiftHeight.Text = obj.LiftHeight.ToString();
                lblCraneWeight.Text = obj.CraneWeight.ToString();
                string filename = "CraneImage";
                FileInfo f = new FileInfo(filename);
                string fullname = f.FullName;
                pbxCrane.Image = Image.FromFile(fullname + @"\" + obj.ImageFile);                
            }            
        */
        }


        private void frmDashboard_Leave(object sender, EventArgs e)
        {
            con.Close();
        }


        private void btnM1_SetPos_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                ConnectToDatabase();
            }

            string dataEntry;


            dataEntry = "SetPos. X:   " + txtM1_X.Text + "\r\n" + "SetPos. Y:   " + txtM1_Y.Text + "\r\n" + "SetPos. Z:   " + txtM1_Z.Text + "\r\n" + "Angle:         " + txtM1_Angle.Text;
            DialogResult dialogResult = MessageBox.Show(dataEntry, "Data Entry", MessageBoxButtons.OKCancel);
            // Here: load data into a database
            if (dialogResult == DialogResult.OK)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module " + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + 20 + "', '" + 20 + "', '" + 100000 + "', '" + 20 + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + 20 + "', '" + 20 + "', '" + 200000 + "', '" + 20 + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + 20 + "', '" + 20 + "', '" + 300000 + "', '" + 20 + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + 20 + "', '" + 20 + "', '" + Global1.weight + "', '" + 20 + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + 40 + "', '" + 20 + "', '" + 100000 + "', '" + 20 + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + 40 + "', '" + 20 + "', '" + 200000 + "', '" + 20 + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + 40 + "', '" + 20 + "', '" + 300000 + "', '" + 20 + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + 40 + "', '" + 20 + "', '" + Global1.weight + "', '" + 20 + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + 60 + "', '" + 20 + "', '" + 100000 + "', '" + 20 + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + 60 + "', '" + 20 + "', '" + 200000 + "', '" + 20 + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + 60 + "', '" + 20 + "', '" + 300000 + "', '" + 20 + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + 60 + "', '" + 20 + "', '" + Global1.weight + "', '" + 20 + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + Global1.len + "', '" + Global1.wid + "', '" + 100000 + "', '" + Global1.hei + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (comboBox2.SelectedIndex == 1)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + Global1.len + "', '" + Global1.wid + "', '" + 200000 + "', '" + Global1.hei + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (comboBox2.SelectedIndex == 2)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + Global1.len + "', '" + Global1.wid + "', '" + 300000 + "', '" + Global1.hei + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }
                    else if (comboBox2.SelectedIndex == 3)
                    {
                        var querytext = "INSERT INTO Modules(Type, SetX, SetY, SetZ, Angle, width, length, weight, height) VALUES('" + "Module" + (NB_Modules + 1) + "', '" + txtM1_X.Text + "', '" + txtM1_Y.Text + "', '" + txtM1_Z.Text + "', '" + txtM1_Angle.Text + "', '" + Global1.len + "', '" + Global1.wid + "', '" + Global1.weight + "', '" + Global1.hei + "')";
                        OleDbCommand cmd = new OleDbCommand(querytext, con);
                        cmd.ExecuteNonQuery();
                    }


                }

            }
            txtM1_X.Clear();
            txtM1_Y.Clear();
            txtM1_Z.Clear();
            txtM1_Angle.Clear();


            LocalDataTable2 = new DataTable();
            DataAdapter1 = new OleDbDataAdapter("SELECT * FROM [Modules]", con);
            DataAdapter1.Fill(LocalDataTable2);      //System.Data.OleDb.OleDbException: 'IErrorInfo.GetDescription failed with E_FAIL(0x80004005).'
            dgv1.DataSource = LocalDataTable2;
            NB_Modules = LocalDataTable2.Rows.Count;
        }




        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string textBoxSender = ((TextBox)sender).Name;             //we cast sender object into a TextBox object and encapsulates it (with parenthesis). We want to identify which textbox was active when key was pressed

            if (e.KeyChar == 13)                                       //"Enter" key is: 13
            {
                switch (textBoxSender)
                {
                    case "txtM1_X":
                        txtM1_Y.Focus();
                        break;
                    case "txtM1_Y":
                        txtM1_Z.Focus();
                        break;
                    case "txtM1_Z":
                        txtM1_Angle.Focus();
                        break;
                    case "txtM1_Angle":
                        btnModSubmit.Focus();
                        break;


                        /*
                        case "txtM2_X":
                            txtM2_Y.Focus();
                            break;
                        case "txtM2_Y":
                            txtM2_Z.Focus();
                            break;
                        case "txtM2_Z":
                            txtM2_Angle.Focus();
                            break;
                        case "txtM2_Angle":
                            btnM2_SetPos.Focus();
                            break;
                        case "txtM3_X":
                            txtM3_Y.Focus();
                            break;
                        case "txtM3_Y":
                            txtM3_Z.Focus();
                            break;
                        case "txtM3_Z":
                            txtM3_Angle.Focus();
                            break;
                        case "txtM3_Angle":
                            btnM3_SetPos.Focus();*/

                }

            }
            //Console.WriteLine(txtM1_X.Text);


            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8)       //"Backspace" key is: 8
            {
                e.Handled = false;                                              // we do nothing
            }
            else
            {
                e.Handled = true;                                               // means: user gets blocked from entering anything else
            }
        }


        private void btnButtons_Hover(object sender, EventArgs e)                            // we renamed this event with right-click "Rename"
        {

        }

        private void btnButtons_Leave(object sender, EventArgs e)
        {

        }


        private void btnPASubmit_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                ConnectToDatabase();
            }

            string dataEntry;


            dataEntry = "TopLeft X:   " + txtPA_TopLeftX.Text + "\r\n" + "TopLeft Y:   " + txtPA_TopLeftY.Text + "\r\n" + "Width:        " + txtPA_Width.Text + "\r\n" + "Length:       " + txtPA_Length.Text;
            DialogResult dialogResult = MessageBox.Show(dataEntry, "Data Entry", MessageBoxButtons.OKCancel);
            // Here: load data into a database
            if (dialogResult == DialogResult.OK)
            {
                var querytext = "INSERT INTO PickAreas(TopLeftX,TopLeftY, Width, Length) VALUES('" + txtPA_TopLeftX.Text + "', '" + txtPA_TopLeftY.Text + "', '" + txtPA_Width.Text + "', '" + txtPA_Length.Text + "')";
                OleDbCommand cmd = new OleDbCommand(querytext, con);
                cmd.ExecuteNonQuery();
            }
            btnPAClear.PerformClick();
        }

        private void btnPAClear_Click(object sender, EventArgs e)
        {
            txtPA_TopLeftX.Clear();
            txtPA_TopLeftY.Clear();
            txtPA_Width.Clear();
            txtPA_Length.Clear();
            txtPA_TopLeftX.Focus();            // cursor back to first textbox
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboCrane_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbxCrane_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblModule1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtM1_X_TextChanged(object sender, EventArgs e)
        {

            if (txtM1_X.Text.Equals(""))
            {
                btnModSubmit.Enabled = false;
            }
            else
            {
                if (Convert.ToInt64(txtM1_X.Text) > 1240)
                {
                    txtM1_X.ForeColor = Color.Red;
                    label4.ForeColor = Color.Red;
                    label4.Text = "< 1240";
                    btnModSubmit.Enabled = false;
                }
                else
                {
                    label4.BackColor = Color.Transparent;
                    label4.Text = "";
                    txtM1_X.ForeColor = Color.Black;
                    if (txtM1_X.Text.Equals("") || txtM1_Y.Text.Equals("") ||
                txtM1_Z.Text.Equals("") || txtM1_Angle.Text.Equals(""))
                    {
                        btnModSubmit.Enabled = false;
                    }
                    else if (Convert.ToInt64(txtM1_Angle.Text) < 180 && Convert.ToInt64(txtM1_Y.Text) < 810 && Convert.ToInt64(txtM1_X.Text) < 1240)
                    {
                        btnModSubmit.Enabled = true;
                    }
                }

            }

        }

        private void txtM1_Y_TextChanged(object sender, EventArgs e)
        {
            if (txtM1_Y.Text.Equals(""))
            {
                btnModSubmit.Enabled = false;
            }
            else
            {
                if (Convert.ToInt64(txtM1_Y.Text) > 810)
                {
                    txtM1_Y.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label5.Text = "< 810";
                    btnModSubmit.Enabled = false;
                }
                else
                {
                    label5.BackColor = Color.Transparent;
                    label5.Text = "";
                    txtM1_Y.ForeColor = Color.Black;
                    if (txtM1_X.Text.Equals("") || txtM1_Y.Text.Equals("") ||
                txtM1_Z.Text.Equals("") || txtM1_Angle.Text.Equals(""))
                    {
                        btnModSubmit.Enabled = false;
                    }
                    else if (Convert.ToInt64(txtM1_Angle.Text) < 180 && Convert.ToInt64(txtM1_Y.Text) < 810 && Convert.ToInt64(txtM1_X.Text) < 1240)
                    {
                        btnModSubmit.Enabled = true;
                    }
                }
            }
        }

        private void txtM1_Z_TextChanged(object sender, EventArgs e)
        {
            if (txtM1_X.Text.Equals("") || txtM1_Y.Text.Equals("") ||
                txtM1_Z.Text.Equals("") || txtM1_Angle.Text.Equals(""))
            {
                btnModSubmit.Enabled = false;
            }
            else
            {
                if (Convert.ToInt64(txtM1_Angle.Text) < 180 && Convert.ToInt64(txtM1_Y.Text) < 810 && Convert.ToInt64(txtM1_X.Text) < 1240)
                {
                    btnModSubmit.Enabled = true;
                }
            }
        }

        private void txtM1_Angle_TextChanged(object sender, EventArgs e)
        {
            if (txtM1_Angle.Text.Equals(""))
            {
                btnModSubmit.Enabled = false;
            }
            else
            {
                if (Convert.ToInt64(txtM1_Angle.Text) > 180)
                {
                    label6.ForeColor = Color.Red;
                    label6.Text = "< 180";
                    txtM1_Angle.ForeColor = Color.Red;
                    btnModSubmit.Enabled = false;

                }
                else
                {
                    label6.BackColor = Color.Transparent;
                    label6.Text = "";
                    txtM1_Angle.ForeColor = Color.Black;
                    if (txtM1_X.Text.Equals("") || txtM1_Y.Text.Equals("") ||
                txtM1_Z.Text.Equals("") || txtM1_Angle.Text.Equals(""))
                    {
                        btnModSubmit.Enabled = false;
                    }
                    else if (Convert.ToInt64(txtM1_Angle.Text) < 180 && Convert.ToInt64(txtM1_Y.Text) < 810 && Convert.ToInt64(txtM1_X.Text) < 1240)
                    {
                        btnModSubmit.Enabled = true;
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "New Dimensions")
            {
                frmSettings frmSettings1 = new frmSettings();
                DialogResult dialogresult = frmSettings1.ShowDialog();

                string a = Global1.len.ToString() + " ft *" + Global1.wid.ToString() + " ft *" + Global1.hei.ToString() + " ft";

                textBox1.BackColor = Color.White;
                textBox1.BorderStyle = BorderStyle.Fixed3D;
                textBox1.Text = a;
                //comboBox1.Items.Add(a);
            }
            else
            {
                textBox1.BackColor = Color.WhiteSmoke;
                textBox1.BorderStyle = BorderStyle.None;
                textBox1.Text = "";
            }

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "New Weight")
            {
                addNewDimensions addNewDimensions1 = new addNewDimensions();
                DialogResult dialogresult = addNewDimensions1.ShowDialog();
                string b = Global1.weight.ToString() + " lbs";
                textBox2.BackColor = Color.White;
                textBox2.BorderStyle = BorderStyle.Fixed3D;
                textBox2.Text = b;


            }
            else
            {
                textBox2.BackColor = Color.WhiteSmoke;
                textBox2.BorderStyle = BorderStyle.None;
                textBox2.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dgv1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //

        }

        private void dgv2_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (!this.dgv1.Rows[this.rowIndex].IsNewRow)
            {
                this.dgv1.Rows.RemoveAt(this.rowIndex);
            }
        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            this.dgv1.Rows[e.RowIndex].Selected = true;
            this.rowIndex = e.RowIndex;
            this.dgv1.CurrentCell = this.dgv1.Rows[e.RowIndex].Cells[1];
            this.contextMenuStrip1.Show(this.dgv1, e.Location);
            contextMenuStrip1.Show(Cursor.Position);

        }

        private void btnModClear_Click(object sender, EventArgs e)
        {
            txtM1_Angle.Text = "";
            txtM1_X.Text = "";
            txtM1_Y.Text = "";
            txtM1_Z.Text = "";
        }

        private void grbModules_Enter(object sender, EventArgs e)
        {

        }

        private void txtPA_TopLeftX_TextChanged(object sender, EventArgs e)
        {
            if (txtPA_TopLeftX.Text.Equals("") || txtPA_TopLeftY.Text.Equals("") ||
                txtPA_Width.Text.Equals("") || txtPA_Length.Text.Equals(""))
            {
                btnPASubmit.Enabled = false;
            }
            else
            {
                btnPASubmit.Enabled = true;
            }
        }

        private void txtPA_TopLeftY_TextChanged(object sender, EventArgs e)
        {
            if (txtPA_TopLeftX.Text.Equals("") || txtPA_TopLeftY.Text.Equals("") ||
    txtPA_Width.Text.Equals("") || txtPA_Length.Text.Equals(""))
            {
                btnPASubmit.Enabled = false;
            }
            else
            {
                btnPASubmit.Enabled = true;
            }
        }

        private void txtPA_Width_TextChanged(object sender, EventArgs e)
        {
            if (txtPA_TopLeftX.Text.Equals("") || txtPA_TopLeftY.Text.Equals("") ||
    txtPA_Width.Text.Equals("") || txtPA_Length.Text.Equals(""))
            {
                btnPASubmit.Enabled = false;
            }
            else
            {
                btnPASubmit.Enabled = true;
            }
        }

        private void txtPA_Length_TextChanged(object sender, EventArgs e)
        {
            if (txtPA_TopLeftX.Text.Equals("") || txtPA_TopLeftY.Text.Equals("") ||
    txtPA_Width.Text.Equals("") || txtPA_Length.Text.Equals(""))
            {
                btnPASubmit.Enabled = false;
            }
            else
            {
                btnPASubmit.Enabled = true;
            }
        }

        private void btnModClear_Click_1(object sender, EventArgs e)
        {
            txtM1_Angle.Text = "";
            txtM1_X.Text = "";
            txtM1_Y.Text = "";
            txtM1_Z.Text = "";
        }
    }
}