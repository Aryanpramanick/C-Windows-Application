using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using static CraneDashboard.Form1;

namespace CraneDashboard
{
    public partial class frmAnalytics : Form
    {
        // Global Variables
        OleDbConnection con = new OleDbConnection();                    // create new OleDbConnection
        OleDbDataAdapter DataAdapter = new OleDbDataAdapter();          // to access values from Access table (Fill or Update)
        DataTable LocalDataTable = new DataTable();                     // local data table as container for the values of Access Table
        DataTable LocalDataTable2 = new DataTable();
        int rowPosition = 0;                                            // index tracker used for STORING data to DB (at last/new location)
        int rowNumber = 0;                                              // index tracker used when READING data from DB

        public frmAnalytics()
        {
            InitializeComponent();
        }

        private void ConnectToDatabase()
        {
            try
            {
                con.ConnectionString = @Global.conn;       // save into "Debug" folder
                con.Open();
            }
            catch { }
        }
                
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PopulateCranes();
                PopulateModules();    //maybe it works to call it under Load event (as in youtube)
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed due to " + ex.Message);
            }
        }
        
        private void PopulateCranes()
        {
            DataAdapter = new OleDbDataAdapter("SELECT * FROM Crane", con);    // all the SQL queries: called 'OLEDB Command Builder'
            DataAdapter.Fill(LocalDataTable);                      // Load everything from Access into local data table. To push data in opposite direction: use .Update(LocalDataTable)
            
            // method 2 - DataGridView columns (First: "Edit Columns" in DataGridView - "Add Columns": give it the Column Name and a Header text) ; under "Edit Columns", we have to change the "DataPropertyName" to the Column Name (do this for all the added columns)
            dgv1.AutoGenerateColumns = false;
            dgv1.DataSource = LocalDataTable;                       // column name works to retrieve data

            // set: rowPosition to no. of rows in our data table, to add later new data at the end of our table
            if (LocalDataTable.Rows.Count > 0)
            {
                rowPosition = LocalDataTable.Rows.Count;
            }            
        }
        
        private void PopulateModules()
        {
            DataAdapter = new OleDbDataAdapter("SELECT * FROM [ModuleAnalytics]", con);
            DataAdapter.Fill(LocalDataTable2);      //System.Data.OleDb.OleDbException: 'IErrorInfo.GetDescription failed with E_FAIL(0x80004005).'

            dgv2.AutoGenerateColumns = false;
            dgv2.DataSource = LocalDataTable2;
        }

        private void frmAnalytics_Load(object sender, EventArgs e)
        {
            ConnectToDatabase();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmAnalytics_Leave(object sender, EventArgs e)
        {
            con.Close();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
