﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClipperLib;
using static CraneDashboard.Form1;

namespace CraneDashboard
{
    using Paths = List<List<IntPoint>>;
    using Path = List<IntPoint>;

    public partial class frmCalender : Form
    {
       


        float[] dashValues = { 2, 2 };
        Pen dashPen = new Pen(Color.Red, 1);
        Pen dashPen1 = new Pen(Color.DarkBlue, 1);
        Label Label = new Label();

        int radius = 10;                                                    // superlift / tailswing radius
        int Rmax = 275;                                                     // Rmax of the crane (pixels)
        OleDbConnection con = new OleDbConnection();
        GraphicsPath boundary_path = new GraphicsPath();
        GraphicsPath boundary_offset_path = new GraphicsPath();
        GraphicsPath obstruction_offset_path = new GraphicsPath();
        GraphicsPath obs_offset_path = new GraphicsPath();
        GraphicsPath obstruction_path = new GraphicsPath();
        GraphicsPath Rg_1 = new GraphicsPath();
        GraphicsPath Rg_2 = new GraphicsPath();
        GraphicsPath Rg_3 = new GraphicsPath();
        GraphicsPath Rg_4 = new GraphicsPath();
        private Point p = new Point(10, 10);
        private new const int Width = 1240;
        private new const int Height = 780;
        private int[,] grid = new int[Width, Height];
        Pen Spen = new Pen(Color.PaleTurquoise, 10);
        Pen pen = new Pen(Color.BlueViolet, 10);

        Pen penPurple = new Pen(Color.Purple, 2);
        Pen penYellow = new Pen(Color.Yellow, 9);
        Pen pen1 = new Pen(Color.DarkBlue, 5);
        Pen pen2 = new Pen(Color.Black, 3);
        Pen pen3 = new Pen(Color.FromArgb(46, 51, 73), 10);
        HatchBrush myHatchBrush = new HatchBrush(HatchStyle.Cross, Color.Blue, Color.Green);
        HatchBrush PAHatchBrush = new HatchBrush(HatchStyle.Vertical, Color.LightGray, Color.Yellow);
        SolidBrush SPSolidBrush = new SolidBrush(Color.DarkGray);
        Rectangle obj0;
        Rectangle pa_0;
        Rectangle sp_0;
        private int spacing = 15;
        Region myRegion;

        ClipperOffset co = new ClipperOffset();
        OleDbConnection connection = new OleDbConnection();
        OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
        OleDbDataAdapter DataAdapterCheck3 = new OleDbDataAdapter();
        DataTable LocalDataTable = new DataTable();
        DataTable DatatableResult = new DataTable();
        DataTable DataSetResult = new DataTable();

        List<double[]> Info_Modules = new List<double[]>();
        List<int> x_center_m = new List<int>();
        List<int> y_center_m = new List<int>();
         // to access values from Access table (Fill or Update)
        
        DataTable LocalDataCrane = new DataTable();
        DataTable DataResultCrane  = new DataTable();
        DataTable DataResultModule = new DataTable();

        List<GraphicsPath> RegionList_m = new List<GraphicsPath>();
        List<GraphicsPath> RegionExcludedList_m = new List<GraphicsPath>();

        double weight_m, GLweight, GLheight;
        int Min_Radius, Max_Radius, width_m, lenght_m, height_m, setX, setY, Dist;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int abc = e.ColumnIndex;
            int b = e.RowIndex;
            if (abc == 0 && b == -1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[abc].Value = true;

                }
                dataGridView1.Update();
                dataGridView1.Refresh();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int abc = e.ColumnIndex;
            Console.WriteLine(abc);
            int b = e.RowIndex;
            if (abc == 0 && b == -1)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[abc].Value = false;
                }
                dataGridView1.Update();
                dataGridView1.Refresh();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text.Equals(""))
            {
                button1.Enabled = false;
            }
            else
            {
                if (Convert.ToInt64(textBox1.Text) > 100 || Convert.ToInt64(textBox1.Text) < 50)
                {
                    textBox1.ForeColor = Color.Red;
                    button1.Enabled = false;
                }
                else
                {
                    textBox1.ForeColor = Color.Black;
                    button1.Enabled = true;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView1.Visible = true;
            label1.Visible = false;
            button2.Visible = false;
            button2.Enabled = false;
            button1.Visible = true;
            button1.Enabled = true;
            textBox1.ReadOnly = false;
        }

        double a;
        string b = "";
        int c, d;
        public frmCalender()
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
        private void PopulateCranes()
        {
            LocalDataTable = new DataTable();
            DataAdapter = new OleDbDataAdapter("SELECT * FROM NCSG_CranesList", con);    // all the SQL queries: called 'OLEDB Command Builder'
            DataAdapter.Fill(LocalDataTable);                      // Load everything from Access into local data table. To push data in opposite direction: use .Update(LocalDataTable)
            dataGridView1.DataSource = LocalDataTable;                       // column name works to retrieve data





            OleDbCommand cmd14 = new OleDbCommand("Select SetX from [Modules]", con);
            OleDbDataReader reader14 = cmd14.ExecuteReader();

            while (reader14.Read())
            {
                for (int i = 0; i < reader14.FieldCount; i++)
                {
                    c = reader14.GetInt32(i);
                    x_center_m.Add(c);
                }
            }
            reader14.Close();

            OleDbCommand cmd15 = new OleDbCommand("Select SetY from [Modules]", con);
            OleDbDataReader reader15 = cmd15.ExecuteReader();

            while (reader15.Read())
            {
                for (int i = 0; i < reader15.FieldCount; i++)
                {
                    c = reader15.GetInt32(i);
                    y_center_m.Add(c);
                }
            }
            reader15.Close();
            con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* Loading lod = new Loading();
            this.Hide();
            lod.ShowDialog();*/
           
            
            textBox1.ReadOnly = true;
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {

                bool abc = (bool)dataGridView1.Rows[i].Cells[0].Value;
                if(abc==true)
                {
                    
                    int bcd = (int)dataGridView1.Rows[i].Cells[1].Value;
                    Global.selected_cranes.Add(bcd); 
                }
            }
            button2.Visible = true;
            button2.Enabled = true;
            label1.Visible = true;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.Location = new Point(2, 48);
            button1.Visible = false;
            button1.Enabled = false;
            Console.WriteLine("HHH");
        }

        private void frmCalender_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            button2.Visible = false;
            button2.Enabled = false;
            dataGridView2.Visible = false;
            try
            {


                ConnectToDatabase();
                PopulateCranes();


                Graphics g = Graphics.FromHwnd(this.Handle);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                // variables for boundary
                #region variables_for_Boundary
                List<double> x_Start_b = new List<double>();
                List<double> y_Start_b = new List<double>();
                List<double> x_End_b = new List<double>();
                List<double> y_End_b = new List<double>();
                List<double> distance = new List<double>();
                List<int> x_Start1_b = new List<int>();
                List<int> y_Start1_b = new List<int>();
                List<int> x_End1_b = new List<int>();
                List<int> y_End1_b = new List<int>();
                List<Point> all_points = new List<Point>();
                List<Point> all_duplicate_points = new List<Point>();
                #endregion

                // variables for obstructions
                #region variables_for_obstructions
                List<double> x_Start_o = new List<double>();
                List<double> y_Start_o = new List<double>();
                List<double> x_End_o = new List<double>();
                List<double> y_End_o = new List<double>();
                List<int> x_Start1_o = new List<int>();
                List<int> y_Start1_o = new List<int>();
                List<int> x_End1_o = new List<int>();
                List<int> y_End1_o = new List<int>();
                List<double> x_o = new List<double>();
                List<double> y_o = new List<double>();
                List<int> x1_o = new List<int>();
                List<int> y1_o = new List<int>();
                List<int> ID_o = new List<int>();

                #endregion

                #region Variables for pick area
                List<int> x_Topleft_pa = new List<int>();
                List<int> y_Topleft_pa = new List<int>();
                List<int> pick_length_pa = new List<int>();
                List<int> pick_width_pa = new List<int>();
                List<int> x_pa = new List<int>();
                List<int> y_pa = new List<int>();
                #endregion

                #region Variables for set positions


                List<int> module_length = new List<int>();
                List<int> module_width = new List<int>();
                List<int> x_Topleft_m = new List<int>();
                List<int> y_Topleft_m = new List<int>();
                #endregion


                #region Establishing_connection
                con.ConnectionString = @Global.conn;
                con.Open();
                #endregion



                // Getting boundary points from the boundary database
                #region Getting boundary points from the boundary database
                OleDbCommand cmd = new OleDbCommand("Select Start_X from Boundaries", con);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        a = reader.GetDouble(i);
                        x_Start_b.Add(a);
                    }
                }
                reader.Close();

                OleDbCommand cmd1 = new OleDbCommand("Select Start_Y from Boundaries", con);
                OleDbDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())

                {
                    for (int i = 0; i < reader1.FieldCount; i++)
                    {
                        a = reader1.GetDouble(i);
                        y_Start_b.Add(a);

                    }
                }
                reader1.Close();

                OleDbCommand cmd2 = new OleDbCommand("Select End_X from Boundaries", con);
                OleDbDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    for (int i = 0; i < reader2.FieldCount; i++)
                    {
                        a = reader2.GetDouble(i);
                        x_End_b.Add(a);

                    }
                }
                reader2.Close();

                OleDbCommand cmd3 = new OleDbCommand("Select End_Y from Boundaries", con);
                OleDbDataReader reader3 = cmd3.ExecuteReader();

                while (reader3.Read())
                {
                    for (int i = 0; i < reader3.FieldCount; i++)
                    {
                        a = reader3.GetDouble(i);
                        y_End_b.Add(a);
                    }
                }
                reader3.Close();
                #endregion

                // Getting obstruction points from obstruction database
                #region Getting obstruction points from obstruction database
                OleDbCommand cmd4 = new OleDbCommand("Select Start_X from Obstructions", con);
                OleDbDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())

                {
                    for (int i = 0; i < reader4.FieldCount; i++)
                    {
                        a = reader4.GetDouble(i);
                        x_Start_o.Add(a);
                    }
                }
                reader4.Close();

                OleDbCommand cmd5 = new OleDbCommand("Select Start_Y from Obstructions", con);
                OleDbDataReader reader5 = cmd5.ExecuteReader();
                while (reader5.Read())
                {
                    for (int i = 0; i < reader5.FieldCount; i++)
                    {
                        a = reader5.GetDouble(i);
                        y_Start_o.Add(a);
                    }
                }
                reader5.Close();

                OleDbCommand cmd6 = new OleDbCommand("Select End_X from Obstructions", con);
                OleDbDataReader reader6 = cmd6.ExecuteReader();
                while (reader6.Read())
                {
                    for (int i = 0; i < reader6.FieldCount; i++)
                    {
                        a = reader6.GetDouble(i);
                        x_End_o.Add(a);
                    }
                }
                reader6.Close();

                OleDbCommand cmd7 = new OleDbCommand("Select End_Y from Obstructions", con);
                OleDbDataReader reader7 = cmd7.ExecuteReader();

                while (reader7.Read())
                {
                    for (int i = 0; i < reader7.FieldCount; i++)
                    {
                        a = reader7.GetDouble(i);
                        y_End_o.Add(a);
                    }
                }
                reader7.Close();
                #endregion

                #region Getting obstruction polyline points
                OleDbCommand cmd16 = new OleDbCommand("Select Y_S from Obs_poly", con);
                OleDbDataReader reader16 = cmd16.ExecuteReader();
                while (reader16.Read())

                {
                    for (int i = 0; i < reader16.FieldCount; i++)
                    {
                        a = reader16.GetDouble(i);
                        y_o.Add(a);

                    }
                }
                reader16.Close();
                OleDbCommand cmd17 = new OleDbCommand("Select X_S from Obs_poly", con);
                OleDbDataReader reader17 = cmd17.ExecuteReader();
                while (reader17.Read())

                {
                    for (int i = 0; i < reader17.FieldCount; i++)
                    {
                        a = reader17.GetDouble(i);
                        x_o.Add(a);

                    }
                }
                reader17.Close();

                OleDbCommand cmd18 = new OleDbCommand("Select ID1 from Obs_poly", con);
                OleDbDataReader reader18 = cmd18.ExecuteReader();
                while (reader18.Read())

                {
                    for (int i = 0; i < reader18.FieldCount; i++)
                    {
                        int ra;
                        ra = reader18.GetInt32(i);
                        ID_o.Add(ra);

                    }
                }
                reader18.Close();
                #endregion



                #region getting pick area points pick_area table
                OleDbCommand cmd8 = new OleDbCommand("Select TopLeftX from PickAreas", con);
                OleDbDataReader reader8 = cmd8.ExecuteReader();

                while (reader8.Read())
                {
                    for (int i = 0; i < reader8.FieldCount; i++)
                    {
                        b = reader8.GetString(i);
                        c = Convert.ToInt32(b);
                        x_Topleft_pa.Add(c);
                    }
                }
                reader8.Close();

                OleDbCommand cmd9 = new OleDbCommand("Select TopLeftY from PickAreas", con);
                OleDbDataReader reader9 = cmd9.ExecuteReader();

                while (reader9.Read())
                {
                    for (int i = 0; i < reader9.FieldCount; i++)
                    {
                        b = reader9.GetString(i);
                        c = Convert.ToInt32(b);
                        y_Topleft_pa.Add(c);
                    }
                }
                reader9.Close();

                OleDbCommand cmd10 = new OleDbCommand("Select Width from PickAreas", con);
                OleDbDataReader reader10 = cmd10.ExecuteReader();

                while (reader10.Read())
                {
                    for (int i = 0; i < reader10.FieldCount; i++)
                    {
                        b = reader10.GetString(i);
                        c = Convert.ToInt32(b);
                        pick_width_pa.Add(c);
                    }
                }
                reader10.Close();

                OleDbCommand cmd11 = new OleDbCommand("Select Length from PickAreas", con);
                OleDbDataReader reader11 = cmd11.ExecuteReader();

                while (reader11.Read())
                {
                    for (int i = 0; i < reader11.FieldCount; i++)
                    {
                        b = reader11.GetString(i);
                        c = Convert.ToInt32(b);
                        pick_length_pa.Add(c);
                    }
                }
                reader11.Close();

                for (int i = 0; i < x_Topleft_pa.Count; i++)
                {
                    d = x_Topleft_pa[i] + ((int)pick_width_pa[i] / 2);
                    x_pa.Add(d);
                    d = y_Topleft_pa[i] + ((int)pick_length_pa[i] / 2);

                    y_pa.Add(d);
                }
                #endregion

                #region Getting module points from module table
                OleDbCommand cmd12 = new OleDbCommand("Select length from [Modules]", con);
                OleDbDataReader reader12 = cmd12.ExecuteReader();

                while (reader12.Read())
                {
                    for (int i = 0; i < reader12.FieldCount; i++)
                    {
                        b = reader12.GetString(i);
                        c = Convert.ToInt32(b);
                        module_length.Add(c);
                    }
                }
                reader12.Close();

                OleDbCommand cmd13 = new OleDbCommand("Select width from [Modules]", con);
                OleDbDataReader reader13 = cmd13.ExecuteReader();

                while (reader13.Read())
                {
                    for (int i = 0; i < reader13.FieldCount; i++)
                    {
                        b = reader13.GetString(i);
                        c = Convert.ToInt32(b);
                        module_width.Add(c);
                    }
                }
                reader13.Close();

                OleDbCommand cmd14 = new OleDbCommand("Select SetX from [Modules]", con);
                OleDbDataReader reader14 = cmd14.ExecuteReader();

                while (reader14.Read())
                {
                    for (int i = 0; i < reader14.FieldCount; i++)
                    {
                        c = reader14.GetInt32(i);
                        x_center_m.Add(c);
                    }
                }
                reader14.Close();

                OleDbCommand cmd15 = new OleDbCommand("Select SetY from [Modules]", con);
                OleDbDataReader reader15 = cmd15.ExecuteReader();

                while (reader15.Read())
                {
                    for (int i = 0; i < reader15.FieldCount; i++)
                    {
                        c = reader15.GetInt32(i);
                        y_center_m.Add(c);
                    }
                }
                reader15.Close();
                con.Close();

                for (int i = 0; i < x_center_m.Count; i++)
                {
                    d = x_center_m[i] - ((int)module_width[i] / 2);
                    x_Topleft_m.Add(d);
                    d = y_center_m[i] - ((int)module_length[i] / 2);
                    y_Topleft_m.Add(d);
                }


                #endregion

                // Conversion of data from both databases to new (10,10) and new scale
                #region Conversion of data from both databases to new (10,10) and new scale
                double x_Start_min = x_Start_b.Min();
                double y_Start_min = y_Start_b.Min();
                double y_Start_max = y_Start_b.Max();
                double x_End_min = x_End_b.Min();
                double x_End_max = x_End_b.Max();
                double y_End_max = y_End_b.Max();
                double scale = 0;
                double x_scale = (Math.Abs(x_End_max - x_Start_min)) / Width;
                double y_scale = (Math.Abs(y_End_max - y_Start_min)) / Height;
                int asa = 0;
                if (x_scale > y_scale)
                {
                    scale = x_scale;
                }
                else
                {
                    scale = y_scale;
                }

                // AutoCAD/Access coordinates start on BottomLeft. GDI+ starts on TopLeft. --> Conversion necessary

                for (int i = 0; i < x_Start_o.Count; i++)
                {
                    x_Start1_o.Add((int)((x_Start_o[i] - x_Start_min) / scale) + 10);
                    x_End1_o.Add((int)((x_End_o[i] - x_End_min) / scale) + 10);
                    y_Start1_o.Add((int)((y_Start_max - y_Start_o[i]) / scale) + 10);
                    y_End1_o.Add((int)((y_End_max - y_End_o[i]) / scale) + 10);
                }
                for (int i = 0; i < x_o.Count; i++)
                {
                    x1_o.Add((int)((x_o[i] - x_Start_min) / scale) + 10);
                    y1_o.Add((int)((y_Start_max - y_o[i]) / scale) + 10);
                }
                for (int i = 0; i < x_Start_b.Count; i++)
                {
                    x_Start1_b.Add((int)((x_Start_b[i] - x_Start_min) / scale) + 10);
                    x_End1_b.Add((int)((x_End_b[i] - x_End_min) / scale) + 10);
                    y_Start1_b.Add((int)((y_Start_max - y_Start_b[i]) / scale) + 10);
                    y_End1_b.Add((int)((y_End_max - y_End_b[i]) / scale) + 10);
                }
                for (int i = 0; i < x_Start_b.Count; i++)
                {
                    Point ab = new Point(x_Start1_b[i], y_Start1_b[i]);
                    Point cd = new Point(x_End1_b[i], y_End1_b[i]);
                    all_points.Add(ab);
                    all_points.Add(cd);
                }
                for (int i = 0; i < all_points.Count; i++)
                {
                    for (int p = 0; p < all_points.Count; p++)
                    {
                        if (all_points[i] == all_points[p])
                        {
                            asa++;
                        }
                    }
                    if (asa == 1)
                    {
                        all_duplicate_points.Add(all_points[i]);
                    }
                    asa = 0;
                }
                #endregion

                // Creating Lines in the Boundary if there are any open spaces
                #region Creating Lines in the Boundary if there are any open spaces
                Point reference_point = new Point(-1, -1);
                for (int i = 0; i < all_duplicate_points.Count; i++)
                {
                    if (all_duplicate_points[i] != reference_point)
                    {
                        for (int p = i + 1; p < all_duplicate_points.Count; p++)
                        {
                            distance.Add(Math.Sqrt(Math.Pow(all_duplicate_points[i].X - all_duplicate_points[p].X, 2) + Math.Pow(all_duplicate_points[i].Y - all_duplicate_points[p].Y, 2)));
                        }


                        double low_distance = distance.Min();
                        distance.Clear();
                        for (int y = i + 1; y < all_duplicate_points.Count; y++)
                        {
                            double h_distance = Math.Sqrt(Math.Pow(all_duplicate_points[i].X - all_duplicate_points[y].X, 2) + Math.Pow(all_duplicate_points[i].Y - all_duplicate_points[y].Y, 2));
                            if (low_distance == h_distance)
                            {
                                x_Start1_b.Add(all_duplicate_points[i].X);
                                y_End1_b.Add(all_duplicate_points[y].Y);
                                y_Start1_b.Add(all_duplicate_points[i].Y);
                                x_End1_b.Add(all_duplicate_points[y].X);
                                all_points.Add(new Point(all_duplicate_points[i].X, all_duplicate_points[i].Y));
                                all_points.Add(new Point(all_duplicate_points[y].X, all_duplicate_points[y].Y));
                                all_duplicate_points[y] = reference_point;

                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                #endregion

                // Reording points
                #region
                List<Point> arranged_points = new List<Point>();
                arranged_points.Add(all_points[0]);
                arranged_points.Add(all_points[1]);
                Point last_point = all_points[1];
                for (int i = 2; i < all_points.Count; i++)
                {

                    if (all_points[i] != reference_point)
                    {
                        if (all_points[i] == last_point)
                        {
                            if (i % 2 == 0)
                            {
                                arranged_points.Add(all_points[i]);
                                arranged_points.Add(all_points[i + 1]);
                                last_point = all_points[i + 1];
                                all_points[i] = reference_point;
                                all_points[i + 1] = reference_point;
                                i = 1;
                            }
                            else
                            {
                                arranged_points.Add(all_points[i]);
                                arranged_points.Add(all_points[i - 1]);
                                last_point = all_points[i - 1];
                                all_points[i] = reference_point;
                                all_points[i - 1] = reference_point;
                                i = 1;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                #endregion
                // creating and displaying points for boundary points
                #region creating, reordering and displaying points for boundary points
                int aa = arranged_points.Count;
                Point[] boundary_Points = new Point[aa];            // every line:start & end point
                Path boundary_point_list = new Path();
                for (int i = 0; i < arranged_points.Count; i++)
                {

                    boundary_Points[i] = arranged_points[i];
                    boundary_point_list.Add(new IntPoint(arranged_points[i].X, arranged_points[i].Y));
                }
                int boundary_offset_x;
                int boundary_offset_y;
                List<IntPoint> boundary_offset_list = new List<IntPoint>();
                boundary_path.AddLines(boundary_Points);
                Region boundary_region = new Region(boundary_path);
                //g.DrawPath(pen1, boundary_path);
                co.AddPath(boundary_point_list, JoinType.jtRound, EndType.etClosedPolygon);
                Paths solution_offset = new Paths();
                co.Execute(ref solution_offset, -radius);
                for (int p = 0; p < solution_offset[0].Count; p++)
                {
                    boundary_offset_list.Add(new IntPoint(solution_offset[0][p]));
                }
                Point[] boundary_offset_points = new Point[boundary_offset_list.Count];
                for (int zxp = 0; zxp < boundary_offset_list.Count; zxp++)
                {
                    boundary_offset_x = (int)boundary_offset_list[zxp].X;
                    boundary_offset_y = (int)boundary_offset_list[zxp].Y;
                    boundary_offset_points[zxp] = new Point(boundary_offset_x, boundary_offset_y);
                }
                boundary_offset_path.AddLines(boundary_offset_points);
                Region boundary_offset = new Region(boundary_offset_path);
                g.DrawPath(pen1, boundary_path);
                #endregion

                // creating, reordering, removing region from boundary and displaying the obstruction points
                #region creating, reordering, removing region from boundary and displaying the obstruction points
                int k = 2;              // index after first line is entered
                int j;
                if (x_Start_o.Count != 0)
                {
                    Point[] obstruction_Points = new Point[2 * x_Start_o.Count];
                    Path obstruction_point_list = new Path();                   // list type is needed for use clipper library

                    int l = x_End1_o[0];    // x coordinate of end point of first obstruction line
                    int m = y_End1_o[0];    // y coordinate of end point of first obstruction line
                                            //j = 0;

                    int new_index = 0;      // index of vertices (to identify end of any obstruction)
                    if (x_Start1_o.Count != 0)
                    {
                        obstruction_point_list.Add(new IntPoint(x_Start1_o[0], y_Start1_o[0]));                 // List
                        obstruction_point_list.Add(new IntPoint(x_End1_o[0], y_End1_o[0]));                     // List 
                        obstruction_Points[0] = new Point(x_Start1_o[0], y_Start1_o[0]);                        // Point array
                        obstruction_Points[1] = new Point(x_End1_o[0], y_End1_o[0]);                            // Point array
                    }
                    x_Start1_o[0] = -1;     // once added to the point array, we set value to -1 (to not repeatedly add it again)
                    while (x_Start_o.Count != 0)
                    {
                        int counter = 0;
                        for (j = 1; j < x_Start_o.Count; j++)               // this adds all other points greater then index 0
                        {
                            if (x_Start1_o[j] == l && y_Start1_o[j] == m)   // if end point of last line == to start point of new line
                            {
                                obstruction_point_list.Add(new IntPoint(x_Start1_o[j], y_Start1_o[j]));
                                obstruction_point_list.Add(new IntPoint(x_End1_o[j], y_End1_o[j]));
                                obstruction_Points[k] = new Point(x_Start1_o[j], y_Start1_o[j]);
                                obstruction_Points[k + 1] = new Point(x_End1_o[j], y_End1_o[j]);
                                k += 2;                                     // index of point array (obstructions)
                                l = x_End1_o[j];                            // x - end point of new line
                                m = y_End1_o[j];                            // y - end point of new line
                                x_Start1_o[j] = -1;                         // for all added points, set to -1 (so they don't get regarded further)
                                j = 0;
                                new_index++;

                            }
                            else                                            // starting point and end point don't match
                            {
                                continue;                                   // try another/next point until we find strting point that matches
                            }
                        }
                        for (j = (new_index + 1) * 2; j < obstruction_Points.Length; j++)
                        {
                            obstruction_Points[j] = obstruction_Points[0];      // fill the rest of obstruction array with last/first point
                        }

                        int obstruction_offset_x;
                        int obstruction_offset_y;
                        List<IntPoint> obstruction_offset_list = new List<IntPoint>();
                        ClipperOffset co1 = new ClipperOffset();
                        co1.AddPath(obstruction_point_list, JoinType.jtRound, EndType.etClosedPolygon);
                        Paths obstruction_offset = new Paths();
                        co1.Execute(ref obstruction_offset, radius);            // actual offsetting method
                        for (int p = 0; p < obstruction_offset[0].Count; p++)   // loops through all offset points
                        {
                            obstruction_offset_list.Add(new IntPoint(obstruction_offset[0][p]));
                        }
                        int increase;
                        increase = obstruction_offset_list.Count;               // Nr. of points of each offset-obstruction
                        Point[] obstruction_offset_points = new Point[increase];
                        Array.Resize(ref obstruction_offset_points, increase);
                        for (int qwe = 0; qwe < increase; qwe++)
                        {
                            obstruction_offset_x = (int)obstruction_offset_list[qwe].X;         // convert IntPoint-x to integers
                            obstruction_offset_y = (int)obstruction_offset_list[qwe].Y;         // convert IntPoint-y to integers
                            obstruction_offset_points[qwe] = new Point(obstruction_offset_x, obstruction_offset_y);
                        }
                        obstruction_path.AddLines(obstruction_Points);                          // for an obstruction: add lines between points to a path
                        obstruction_offset_path.AddClosedCurve(obstruction_offset_points);
                        Region obstruction_offset_region = new Region(obstruction_offset_path);
                        Region obstruction_region = new Region(obstruction_path);
                        boundary_offset.Exclude(obstruction_offset_region);
                   
                        boundary_region.Exclude(obstruction_region);            // END of first any obstruction

                        obstruction_path = new GraphicsPath();                  // START of any new obstruction  -- Reset / Clear everything
                        obstruction_offset_path = new GraphicsPath();
                        obstruction_offset_list.Clear();
                        obstruction_point_list.Clear();
                        Array.Clear(obstruction_offset_points, 0, obstruction_offset_points.Length);
                        Array.Clear(obstruction_Points, 0, obstruction_Points.Length);                  // reset obstructions array
                        k = 0;                                                                          // reset index of obstruction array

                        for (j = 0; j < x_Start1_o.Count; j++)
                        {
                            if (x_Start1_o[j] == -1)                        // count the already added points
                            {
                                ++counter;                                  // counter stores number of added points
                            }
                        }
                        if (counter == x_Start1_o.Count - 1 || counter == x_Start1_o.Count)         // if nr of added points == total nr of points
                        {
                            break;                                                                  // we are done with adding points - BREAK the loop
                        }

                        for (j = 0; j < x_Start1_o.Count; j++)
                        {
                            if (x_Start1_o[j] != -1)                        // if start point is not -1 --> new obstruction, do same thing again.
                            {
                                obstruction_point_list.Add(new IntPoint(x_Start1_o[j], y_Start1_o[j]));         // "new constructor" for new obstruction
                                obstruction_point_list.Add(new IntPoint(x_End1_o[j], y_End1_o[j]));
                                obstruction_Points[0] = new Point(x_Start1_o[j], y_Start1_o[j]);
                                x_Start1_o[j] = -1;
                                obstruction_Points[1] = new Point(x_End1_o[j], y_End1_o[j]);
                                l = x_End1_o[j];
                                m = y_End1_o[j];
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        new_index = -1;                         // for new obstruction: new_index has to start again with 0
                    }
                }

                #endregion

                #region Polyline obstruction

                var uniqueItemsList = ID_o.Distinct().ToList();
                Path obs_point_list = new Path();
                List<Point> abcc = new List<Point>();
                Point[] obss = new Point[ID_o.Count];
                GraphicsPath obs = new GraphicsPath();

                List<IntPoint> obs_offset_list = new List<IntPoint>();
                int yu = 0;
                for (int hg = 0; hg < uniqueItemsList.Count; hg++)
                {
                    for (int jk = 0; jk < ID_o.Count; jk++)
                    {
                        if (ID_o[jk] == hg)
                        {
                            Point p = new Point(x1_o[jk], y1_o[jk]);
                            abcc.Add(p);

                            yu++;
                        }
                    }
                    Array.Resize(ref obss, abcc.Count);
                    for (int jk = 0; jk < abcc.Count; jk++)
                    {
                        obss[jk] = abcc[jk];
                        obs_point_list.Add(new IntPoint(abcc[jk].X, abcc[jk].Y));
                    }
                    obs.AddLines(obss);
                    Array.Clear(obss, 0, obss.Length);
                    abcc.Clear();
                    ClipperOffset co2 = new ClipperOffset();
                    co2.AddPath(obs_point_list, JoinType.jtRound, EndType.etClosedPolygon);
                    obs_point_list.Clear();
                    Paths obs_offset = new Paths();
                    int obs_offset_x;
                    int obs_offset_y;
                    co2.Execute(ref obs_offset, radius);
                    for (int p = 0; p < obs_offset[0].Count; p++)   // loops through all offset points
                    {
                        obs_offset_list.Add(new IntPoint(obs_offset[0][p]));
                    }
                    int inc;
                    inc = obs_offset_list.Count;               // No. of points of each offset-obstruction
                    Point[] obs_offset_points = new Point[inc];
                    Array.Resize(ref obs_offset_points, inc);
                    for (int qwe = 0; qwe < inc; qwe++)
                    {
                        obs_offset_x = (int)obs_offset_list[qwe].X;         // convert IntPoint-x to integers
                        obs_offset_y = (int)obs_offset_list[qwe].Y;         // convert IntPoint-y to integers
                        obs_offset_points[qwe] = new Point(obs_offset_x, obs_offset_y);
                    }
                    obs_offset_path.AddClosedCurve(obs_offset_points);
                    Array.Clear(obs_offset_points, 0, obs_offset_points.Length);
                    Region obs_offset_region = new Region(obs_offset_path);
                    boundary_offset.Exclude(obs_offset_region);
                    Region obs_region = new Region(obs);
                    boundary_region.Exclude(obs_region);
                    obs_offset_list.Clear();
                    obs = new GraphicsPath();

                    obs_offset_path = new GraphicsPath();
                }



                #endregion

                #region Creating and removing setpositions from boundary and displaying them
                for (int i = 0; i < x_Topleft_m.Count; i++)
                {
                    Rectangle set_pos = new Rectangle(x_Topleft_m[i], y_Topleft_m[i], module_width[i], module_length[i]);
                    boundary_region.Exclude(set_pos);
                    boundary_offset.Exclude(set_pos);
                }
                #endregion

                #region Creating and removing pick areas boundary and displaying them
                for (int i = 0; i < x_Topleft_pa.Count; i++)
                {
                    Rectangle pick_area = new Rectangle(x_Topleft_pa[i], y_Topleft_pa[i], pick_width_pa[i], pick_length_pa[i]);
                    boundary_region.Exclude(pick_area);
                    boundary_offset.Exclude(pick_area);
                }
                #endregion




            }
            catch { }

        }
    }
}
