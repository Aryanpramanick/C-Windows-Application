using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using ClassLibrary1;
using System.Data.OleDb;
using static CraneDashboard.Form1;
using ClipperLib;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using System.Web.UI;

namespace CraneDashboard
{
    using Paths = List<List<IntPoint>>;
    using Path = List<IntPoint>;


    public partial class frmSiteLayout : Form
    {
        Layout  cal = new Layout();
        #region Global Variables and Brushes/ Pens

        // Global Variables
        List<int> No_Solution = new List<int>();
        List<int> Module_selected = new List<int>();

        float[] dashValues = { 2, 2 };
        Pen dashPen = new Pen(Color.Red, 1);
        Pen dashPen1 = new Pen(Color.DarkBlue, 1);
        Label Label = new Label();

        int radius = 10;                                                    // superlift / tailswing radius
        int Rmax = 275;                                                     // Rmax of the crane (pixels)
        OleDbConnection con = new OleDbConnection();
        OleDbConnection conPickWalk = new OleDbConnection();
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
        Pen penYellow = new Pen(Color.Yellow, 3);
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
        OleDbConnection connectionCrane = new OleDbConnection();

        OleDbConnection connectionSShared = new OleDbConnection();
        OleDbConnection connectionSSepare = new OleDbConnection();

        Region boundary_offset = new Region();

        OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
        OleDbDataAdapter DataAdapterCrane = new OleDbDataAdapter();
        OleDbDataAdapter DataAdapterNCGS = new OleDbDataAdapter();
        DataTable LocalDataTable = new DataTable();
        DataTable DatatableResult = new DataTable();
        DataTable DataSetResult = new DataTable();

        List<double[]> Info_Modules = new List<double[]>();
        List<int> x_center_m = new List<int>();
        List<int> y_center_m = new List<int>();
        List<int> x_Topleft_m = new List<int>();
        #endregion
        List<Rectangle> recc = new List<Rectangle>();

        public frmSiteLayout()
        {

            string filename = "LocationShared";
            FileInfo f = new FileInfo(filename);
            string fullname = f.FullName;
            connectionSShared.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; " + @"Data Source =" + fullname + ".accdb";
            connectionSShared.Open();


            var query = "DELETE FROM Location";
            OleDbCommand cmdQ = new OleDbCommand(query, connectionSShared);
            cmdQ.ExecuteNonQuery();



            filename = "LocationSeparet";
            f = new FileInfo(filename);
            fullname = f.FullName;
            connectionSSepare.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; " + @"Data Source =" + fullname + ".accdb";
            connectionSSepare.Open();


            query = "DELETE FROM Location";
            cmdQ = new OleDbCommand(query, connectionSSepare);
            cmdQ.ExecuteNonQuery();



            


            InitializeComponent();

        }


        private void frmSiteLayout_Load(object sender, EventArgs e)
        {
            
            
        }

      
        
        List<int> Calculate_Boundry(List<int> Check_List) 
        {
            int MaxI = 0;
            int MaxJ = 0;

            int MinI = 150000;
            int MinJ = 150000;
            int X1 = 0, Y1 = 0, X2 = 0, Y2 = 0;

            for (int i = 0; i < Check_List.Count; i++) 
            {
                int m = Check_List.ElementAt(i);
                var tab = Info_Modules[m];
                int x = x_center_m[m];
                int y = y_center_m[m];
                int Maxs_Raduis = (int)tab[2];
                X1 = x + Maxs_Raduis;
                Y1 = y + Maxs_Raduis;
                X2 = x - Maxs_Raduis;
                Y2 = y - Maxs_Raduis;

                if (MaxI < X1) {MaxI = X1;}
                if (MaxJ < Y1) {MaxJ = Y1;}
                if (MaxI < X2) { MaxI = X2; }
                if (MaxJ < Y2) { MaxJ = Y2; }

                if (MinI > X1) { MinI = X1; }
                if (MaxJ > Y1) { MinJ = Y1; }

                if (MinI > X2) { MinI = X2; }
                if (MaxJ > Y2) { MinJ = Y2; }
            }
           List<int> list = new List<int>();
            list.Add(MaxI);
            list.Add(MinI); 
            list.Add(MaxJ);
            list.Add(MinJ);

            return list;
        }




        private void frmSiteLayout_MouseMove(object sender, MouseEventArgs e)
        {
        }


        private void btnDrawLayout_Click(object sender, EventArgs e)
        {
        }
        
        private void frmSiteLayout_MouseClick(object sender, MouseEventArgs e)
        {
            List<int> previous = new List<int>();
            Graphics g = Graphics.FromHwnd(this.Handle);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int vX = e.X;
            int vY = e.Y;
            Point abcc = new Point(vX, vY);
            for (int i = 0; i < recc.Count; i++)
            {
                
                if (recc[i].Contains(abcc))
                {
                    
                    g.DrawRectangle(penYellow, recc[i]);
                    if (!Module_selected.Contains(i + 1))
                    {
                        Module_selected.Add(i + 1);
                    }
                }
            }

            String Text = "";
            int valY, valY1, valY2, valY3;
            int valX, valX1, valX2, valX3;

            valY = e.Y - 2;
            valY1 = e.Y - 1;
            valY2 = e.Y + 2;
            valY3 = e.Y + 1;

            valX = e.X - 2;
            valX1 = e.X - 1;
            valX2 = e.X + 2;
            valX3 = e.X + 1;
            
            Text = "";

            String CModel = "", CCapacity = "", CConf = "", place = "";
            String raduis = "", MBoom = "", Mod = "", MBAg = "";


            DataTable LocalSolution = new DataTable();
            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location  where [Xset]=" + valX + " and [Yset]=" + valY + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);


            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location  where [Xset]=" + valX + " and [Yset]=" + valY1 + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);


            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location  where [Xset]=" + valX + " and [Yset]=" + valY2 + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);

            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location  where [Xset]=" + valX + " and [Yset]=" + valY3 + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);


            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location  where [Xset]=" + valX1 + " and [Yset]=" + valY + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);


            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location where [Xset]=" + valX1 + " and [Yset]=" + valY1 + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);


            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location  where [Xset]=" + valX1 + " and [Yset]=" + valY2 + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);

            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location  where [Xset]=" + valX1 + " and [Yset]=" + valY3 + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);


            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location  where [Xset]=" + valX2 + " and [Yset]=" + valY + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);


            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location  where [Xset]=" + valX2 + " and [Yset]=" + valY1 + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);


            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location  where [Xset]=" + valX2 + " and [Yset]=" + valY2 + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);

            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location  where [Xset]=" + valX2 + " and [Yset]=" + valY3 + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);


            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location  where [Xset]=" + valX3 + " and [Yset]=" + valY + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);


            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location where [Xset]=" + valX3 + " and [Yset]=" + valY1 + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);


            DataAdapter = new OleDbDataAdapter("SELECT  [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location where [Xset]=" + valX3 + " and [Yset]=" + valY2 + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);

            DataAdapter = new OleDbDataAdapter("SELECT [Xset],[Yset],[IDModule],[Radius],[MainBoom],[CraneConfig],[CraneModel] FROM Location where [Xset]=" + valX3 + " and [Yset]=" + valY3 + " ORDER BY  [CraneConfig]", connectionSShared);
            DataAdapter.Fill(LocalSolution);

            TxtOutPut.Clear();
            /*
            int index = CraneListCBox.SelectedIndex;
            int ID    = Global.selected_cranes.ElementAt(index);
            Console.WriteLine(index+"  "+ID);
            DataTable DTCrane = new DataTable();
            DataAdapter = new OleDbDataAdapter("SELECT [Configuration], [Model] FROM NCSG_CranesList where [CraneID]=" + ID, con); 
            DataAdapter.Fill(DTCrane);     */                        


           // CConf = DTCrane.Rows[0][0].ToString();
            //CModel = DTCrane.Rows[0][0].ToString();


            String tModel = "Crane Model: ";
            TxtOutPut.SelectionStart = tModel.Length;
            TxtOutPut.SelectionLength = 0;
            TxtOutPut.SelectionColor = Color.DarkBlue;
            TxtOutPut.AppendText(CModel + "\n");

            TxtOutPut.SelectionColor = Color.DarkBlue;
            String tConfig = "Crane Configuration: ";
            TxtOutPut.SelectionColor = Color.Black;
            TxtOutPut.AppendText(CConf + "\n \n");

            for (int i = 0; i < LocalSolution.Rows.Count; i++)
            {


                int CX = Int32.Parse(LocalSolution.Rows[i][0].ToString());
                int CY = Int32.Parse(LocalSolution.Rows[i][1].ToString());
                double m = double.Parse(LocalSolution.Rows[i][2].ToString());
                double r = double.Parse(LocalSolution.Rows[i][3].ToString());
                double MB = double.Parse(LocalSolution.Rows[i][4].ToString());

                raduis += "\t" + r + " ft";
                MBoom += "\t" + MB + " ft";
                Mod += "\t" + "M " + (m + 1);

                place = " ( " + CX + " , " + CY + ") \n";

                TxtOutPut.SelectionColor = Color.DarkBlue;
                TxtOutPut.AppendText("Placement: ");
                TxtOutPut.SelectionColor = Color.Black;
                TxtOutPut.AppendText(place + "\n");



                TxtOutPut.SelectionColor = Color.DarkBlue;
                TxtOutPut.AppendText("Modules:  ");
                TxtOutPut.SelectionColor = Color.Black;
                TxtOutPut.AppendText(Mod + "\n");


                TxtOutPut.SelectionColor = Color.DarkBlue;
                TxtOutPut.AppendText("Radius:   ");
                TxtOutPut.SelectionColor = Color.Black;
                TxtOutPut.AppendText(raduis + "\n");


                TxtOutPut.SelectionColor = Color.DarkBlue;
                TxtOutPut.AppendText("MainBoom: ");
                TxtOutPut.SelectionColor = Color.Black;
                TxtOutPut.AppendText(MBoom + "\n");

                TxtOutPut.AppendText("\n\n");
            }
        }

        private void frmSiteLayout_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int valX = e.X;
            int valY = e.Y;
            Point abcc = new Point(valX, valY);
            for(int i = 0; i < recc.Count; i++)
            {
                if (recc[i].Contains(abcc))
                {
                    
                    g.DrawRectangle(pen2, recc[i]);
                    Module_selected.Remove(i + 1);
                }
            }
            
        }

        private void lblLegend_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblObjects_Click(object sender, EventArgs e)
        {

        }
        private static Bitmap DrawControlToBitmap(System.Windows.Forms.Control control)
        {
            Bitmap bitmap = new Bitmap(control.Width, control.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            Rectangle rect = control.RectangleToScreen(control.ClientRectangle);
            graphics.CopyFromScreen(rect.Location, Point.Empty, control.Size);
            return bitmap;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = DrawControlToBitmap(frmSiteLayout.ActiveForm);
            bitmap.Save("button.png");
            System.Diagnostics.Process.Start("button.png");
        }

        private void TxtOutPut_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CraneList_Click(object sender, EventArgs e)
        {
          
        }

        private void CraneListCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int nb_crane = Global.selected_cranes.Count;
            int index = CraneListCBox.SelectedIndex;
            if (index == nb_crane)
            {

            }
            else 
            {
                int ID = Global.selected_cranes.ElementAt(index);
                g.SetClip(boundary_offset, CombineMode.Replace);

                DataTable LocalSolution1 = new DataTable();
                DataAdapter = new OleDbDataAdapter("SELECT * FROM Location where [IDCrane]="+ID, connectionSShared);
                DataAdapter.Fill(LocalSolution1);

                int NB = LocalSolution1.Rows.Count;
                for (int i = 0; i < NB; i++)
                {
                    // extract the points
                    int CX = Int32.Parse(LocalSolution1.Rows[i][1].ToString());
                    int CY = Int32.Parse(LocalSolution1.Rows[i][2].ToString());
            
                    g.DrawEllipse(penPurple, CX - 2, CY - 2, 4, 4);
                }
            }



        }

        private void BtSolution_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            label1.Show();
            CraneListCBox.Show();
            LBCrane.Show();
            TxtOutPut.Show();
            int j = 0;

            #region Defining the region for each Module

            List<GraphicsPath> RegionList_m = new List<GraphicsPath>();
            List<GraphicsPath> RegionExcludedList_m = new List<GraphicsPath>();

            double weight_m, GLweight, GLheight;
            int Min_Radius, Max_Radius, width_m, lenght_m, height_m, setX, setY, Dist;


            DataTable DataModule = new DataTable();
            DataAdapter = new OleDbDataAdapter("SELECT [weight], [SetX], [SetY], [width], [length], [SetZ] FROM [Modules]", con);
            DataAdapter.Fill(DataModule);
            int NB_Modules = DataModule.Rows.Count;



            Region Intersec_region = new Region();

            List<String> RList = new List<String>();
            List<int> List = new List<int>();

            Info_Modules.Clear();
            RegionList_m.Clear();
            RegionExcludedList_m.Clear();
            String CraneConfig = "";
            String CraneModel = "";

            List<List<double[]>> Info_Modules_Crane = new List<List<double[]>>();
            //List<List<GraphicsPath>> RegionExcludedListMax_Crane = new List<List<GraphicsPath>>();

            // RegionListMax_Crane  RegionExcludedListMax_Crane
            for (int cr = 1; cr < 3; cr++) // for each crane do  
            {

                string filename = "Crane" + cr;
                FileInfo f = new FileInfo(filename);
                string fullname = f.FullName;


                Console.WriteLine("Crane :" + "Crane" + cr);
                connection.Close();
                connection.ConnectionString = "Provider = Microsoft.ACE.OLEDB.12.0; " + @"Data Source =" + fullname + ".accdb";

                DataTable LocalDataTableC = new DataTable();
                DataAdapterCrane = new OleDbDataAdapter("SELECT * FROM Sheet1", connection);
                DataAdapterCrane.Fill(LocalDataTableC);
                connection.Open();

                CraneConfig = LocalDataTableC.Rows[0][1].ToString();
                CraneModel = LocalDataTableC.Rows[0][2].ToString();

                Console.WriteLine("Step 1");
                Info_Modules.Clear();
                //g.SetClip(boundary_offset, CombineMode.Replace);
                for (int i = 0; i < NB_Modules; i++)
                {
                    setX = Int32.Parse(DataModule.Rows[i][1].ToString());  //Extract the width of Module i 
                    setY = Int32.Parse(DataModule.Rows[i][2].ToString());  //Extract the width of Module i 
                    weight_m = double.Parse(DataModule.Rows[i][0].ToString()); //Extract the weight of Module i 
                    width_m = Int32.Parse(DataModule.Rows[i][3].ToString());  //Extract the width of Module i 
                    lenght_m = Int32.Parse(DataModule.Rows[i][4].ToString());  //Extract the width of Module i 
                    height_m = Int32.Parse(DataModule.Rows[i][5].ToString());  //Extract the width of Module i 
                    setX = setX - (width_m / 2);
                    setY = setY - (lenght_m / 2);
                    Dist = (int)Math.Sqrt((Math.Pow(x_center_m[i] - setX, 2) + Math.Pow(y_center_m[i] - setY, 2)));


                    /*module weight + hook weight + rigging weigh*/
                    //GLweight = weight_m;
                    //GLheight = height_m+
                    weight_m = weight_m + weight_m * (0.15);
                    //Extract the lowest value of the Boom Main lenght.
                    DatatableResult = new DataTable();
                    DataAdapter = new OleDbDataAdapter("SELECT MIN([Radius]) FROM Sheet1 where [Load capacity]>" + weight_m + "and [Height] >" + height_m, connection);
                    DataAdapter.Fill(DatatableResult);
                    Min_Radius = Int32.Parse(DatatableResult.Rows[0][0].ToString());

                    //Extract the higher value of the Boom Main lenght.

                    DatatableResult = new DataTable();
                    DataAdapter = new OleDbDataAdapter("SELECT Max([Radius]) FROM Sheet1 where [Load capacity]>" + weight_m + "and [Height] >" + height_m, connection);
                    DataAdapter.Fill(DatatableResult);
                    Max_Radius = Int32.Parse(DatatableResult.Rows[0][0].ToString());


                    //Create two circles around the module: the min and the max radius.
                    Label.Text = "M" + (i + 1);
                    Label.ForeColor = Color.Black;
                    Label.Font = new Font("Arial", 6, FontStyle.Bold);
                    g.DrawString(Label.Text, Label.Font, new SolidBrush(Label.ForeColor), (x_center_m[i] - 7), (y_center_m[i] - 4));
                    
                    

                    dashPen.DashPattern = dashValues;
                    dashPen1.DashPattern = dashValues;

                    g.DrawEllipse(dashPen1, (x_center_m[i]) - (Max_Radius), (y_center_m[i]) - (Max_Radius), (Max_Radius) * 2, (Max_Radius) * 2);

                    if (Dist > Min_Radius)
                    {
                        // g.DrawEllipse(dashPen, (x_center_m[i]) - (Dist), (y_center_m[i]) - (Dist), (Dist) * 2, (Dist) * 2);
                        Min_Radius = Dist;
                    }/*
                       else
                        {
                            
                        }*/
                    g.DrawEllipse(dashPen, (x_center_m[i]) - (Min_Radius), (y_center_m[i]) - (Min_Radius), (Min_Radius) * 2, (Min_Radius) * 2);
                    //Create the max boundry of the region
                    GraphicsPath Region_max = new GraphicsPath();
                    Region_max.AddEllipse((x_center_m[i]) - (Max_Radius), (y_center_m[i]) - (Max_Radius), (Max_Radius) * 2, (Max_Radius) * 2);
                    RegionList_m.Add(Region_max);

                    //create the excluded region
                    GraphicsPath Region_min = new GraphicsPath();
                    Region_min.AddEllipse((x_center_m[i]) - (Min_Radius), (y_center_m[i]) - (Min_Radius), (Min_Radius) * 2, (Min_Radius) * 2);
                    RegionExcludedList_m.Add(Region_min);

                    double[] tab = new double[4];
                    tab[0] = weight_m;
                    tab[1] = Min_Radius;
                    tab[2] = Max_Radius;
                    tab[3] = height_m;
                    Info_Modules.Add(tab);
                }
                Info_Modules_Crane.Add(Info_Modules);


                Console.WriteLine("Step 2");

                for (int i = 0; i < NB_Modules; i++)
                {
                    GraphicsPath Rg1 = new GraphicsPath();
                    Rg1 = RegionList_m.ElementAt(i);
                    Intersec_region = new Region(Rg1);
                    GraphicsPath Rg2 = new GraphicsPath();
                    Rg_2 = RegionExcludedList_m.ElementAt(i);
                    Intersec_region.Exclude(Rg2);
                    String text = "" + i;
                    List.Clear();
                    List.Add(i);
                    j = 0;
                    while (j < NB_Modules)
                    {
                        if (i != j)
                        {
                            GraphicsPath Rg3 = new GraphicsPath();
                            Rg3 = RegionList_m.ElementAt(j);

                            GraphicsPath Rg4 = new GraphicsPath();
                            Rg4 = RegionExcludedList_m.ElementAt(j);

                            Intersec_region.Exclude(Rg4);
                            Intersec_region.Intersect(Rg3);

                            if (!Intersec_region.IsEmpty(g))
                            {
                                text += "." + j;
                                RList.Add(text);
                            }
                            else
                            {
                                Rg1 = new GraphicsPath();
                                Rg1 = RegionList_m.ElementAt(List.ElementAt(0));
                                Intersec_region = new Region(Rg1);
                                Rg2 = new GraphicsPath();
                                Rg_2 = RegionExcludedList_m.ElementAt(List.ElementAt(0));
                                Intersec_region.Exclude(Rg2);
                                for (int p = 1; p < List.Count; p++)
                                {
                                    Rg3 = new GraphicsPath();
                                    Rg3 = RegionList_m.ElementAt(List.ElementAt(p));
                                    Rg4 = new GraphicsPath();
                                    Rg4 = RegionExcludedList_m.ElementAt(List.ElementAt(p));
                                    Intersec_region.Exclude(Rg4);
                                    Intersec_region.Intersect(Rg3);
                                }
                            }
                        }
                        j++;
                    }
                    if (List.Count == 1)
                    {
                        bool check = false;
                        foreach (string el in RList)
                        { if (el.Contains("." + i) || (el.Contains(i + "."))) { check = true; } }

                        if (check == false) { RList.Add("" + i); }
                    }
                }


                List<List<int>> SharedRg = new List<List<int>>();

                List<String> sorted = RList.OrderByDescending(x => x.Length).ToList();

                List<int> Separete_Regions = new List<int>();
                List<List<int>> SharedRegion = new List<List<int>>();
                SharedRegion.Clear();
                Separete_Regions.Clear();
                foreach (String text in sorted)
                {

                    List<int> Check_List = new List<int>();
                    if (!text.Contains("."))
                    {
                        //Separete_Regions.Add(Int32.Parse(text));
                    }
                    else
                    {
                        string[] words = text.Split('.');

                        foreach (string word in words)
                        { Check_List.Add(Int32.Parse(word)); }

                        Check_List.Sort();
                        bool check = cal.Compare(Check_List, SharedRegion);
                        if (check == false)
                        {

                            if (cal.Belong(Check_List, SharedRegion) == false) { SharedRegion.Add(Check_List); }
                            else { SharedRg.Add(Check_List); }
                        }
                    }
                }

                Console.WriteLine("Step 3.1");
                List<List<int>> Shared_Regions = SharedRegion.Distinct().ToList();

                List<Point> duplicate_points_list = new List<Point>();
                IEnumerable<Point> duplicate_points;
                List<Point> possible_crane_locations = new List<Point>();
                duplicate_points = possible_crane_locations.GroupBy(n => n).Where(po => po.Count() == x_Topleft_m.Count()).Select(n => n.Key);
                duplicate_points_list = duplicate_points.ToList();

                List<List<int>> Checked_Regions = new List<List<int>>();
                List<int> None_Checked_Regions = new List<int>();
                List<int> removedList = new List<int>();
                List<List<int>> None_Checked = new List<List<int>>();


                for (int m = 0; m < Shared_Regions.Count; m++)
                {
                    List<int> Check_List = Shared_Regions.ElementAt(m);
                    int module = Check_List.ElementAt(0);
                    Console.WriteLine("call function (Shared Region)");
                    List<int> listB = Calculate_Boundry(Check_List);
                    bool Validate = cal.Crane_Location_Parameter(spacing, Check_List, listB, cr, CraneConfig, CraneModel, Info_Modules, x_center_m, y_center_m, connection, connectionSShared);


                    /*

                    Region Shared_Region = new Region();
                    String text = " ";
                    foreach (var ch in Check_List)
                    { text += ch; }

                    var tab = Info_Modules[module];
                    Rg_1 = new GraphicsPath();
                    Rg_1 = RegionList_m.ElementAt(module);
                    Shared_Region = new Region(Rg_1);
                    Rg_2 = new GraphicsPath();
                    Rg_2 = RegionExcludedList_m.ElementAt(module);
                    Shared_Region.Exclude(Rg_2);

                    for (int s = 1; s < Check_List.Count; s++)
                    {
                        module = Check_List.ElementAt(s);
                        tab = Info_Modules[module];

                        GraphicsPath Rg_3 = new GraphicsPath();
                        GraphicsPath Rg_4 = new GraphicsPath();

                        Rg_3 = RegionList_m.ElementAt(module);
                        Shared_Region.Intersect(Rg_3);

                        Rg_4 = RegionExcludedList_m.ElementAt(module);
                        Shared_Region.Exclude(Rg_4);
                    }

                    g.SetClip(Shared_Region, CombineMode.Replace);
                    g.SetClip(boundary_offset, CombineMode.Replace);
                    g.SetClip(boundary_offset, CombineMode.Replace);
                    */

                    if (Validate == false) // no solution
                    {
                        None_Checked.Add(Check_List);

                        for (int s = 0; s < Check_List.Count; s++)
                        {
                            module = Check_List.ElementAt(s);
                            None_Checked_Regions.Add(module);
                        }
                    }
                    else
                    {
                        Checked_Regions.Add(Check_List);
                    }
                }

                /*
                foreach (int m in None_Checked_Regions)
                {
                    bool check = false;
                    foreach (var L in Checked_Regions)
                    {
                        foreach (int l in L)
                        { if (m == l) { check = true; } }
                    }
                    if (check == false) { Separete_Regions.Add(m); }
                }
                */
                for (int i = 0; i < NB_Modules; i++)
                {
                    List<int> list = new List<int>();
                    list.Clear();
                    list.Add(i);
                    bool check = cal.Belong(list, Checked_Regions);
                    if (check == false) { Separete_Regions.Add(i); }

                }
                Console.WriteLine("Step 3.2 : Separete_Regions");
                if (Separete_Regions.Count != 0)
                {
                    for (int m = 0; m < Separete_Regions.Count; m++)
                    {
                        int module = Separete_Regions.ElementAt(m);
                        List<int> Check_List = new List<int>();
                        Check_List.Clear();
                        Check_List.Add(module);
                        Console.WriteLine("call function (Separate Region) m:" + (module + 1));

                        List<int> listB = Calculate_Boundry(Check_List);
                        bool Validate = cal.Crane_Location_Parameter(spacing, Check_List, listB, cr, CraneConfig, CraneModel, Info_Modules, x_center_m, y_center_m, connection, connectionSSepare);

                        Console.WriteLine("Validate" + Validate);

                        if (Validate == true) { No_Solution.Add(module); }
                    }
                }
            }

            #endregion

            // rectifier the solutions separate region pick and walk 

            //sfor()


            Console.WriteLine("draw solutions");

            var query = "DELETE FROM Location WHERE  ID NOT IN(SELECT MIN(ID) AS 'ID' FROM Location GROUP BY Xset, Yset, IDCrane,CraneConfig,CraneModel,IDModule,Radius,MainBoom)";

            OleDbCommand cmdQ = new OleDbCommand(query, connectionSShared);
            cmdQ.ExecuteNonQuery();


            //g.ResetClip();
            g.SetClip(boundary_offset, CombineMode.Replace);

            DataTable LocalSolution1 = new DataTable();
            DataAdapter = new OleDbDataAdapter("SELECT * FROM Location", connectionSShared);
            DataAdapter.Fill(LocalSolution1);

            int NB = LocalSolution1.Rows.Count;
            for (int i = 0; i < NB; i++)
            {
                // extract the points
                PointF point1 = PointF.Empty;
                PointF point2 = PointF.Empty;

                int CX = Int32.Parse(LocalSolution1.Rows[i][1].ToString());
                int CY = Int32.Parse(LocalSolution1.Rows[i][2].ToString());
                int m = Int32.Parse(LocalSolution1.Rows[i][5].ToString());

                g.DrawEllipse(penPurple, CX - 2, CY - 2, 4, 4);
                point1.X = CX; point1.Y = CY;

                point2.X = x_center_m[m];
                point2.Y = y_center_m[m];
                dashPen.DashPattern = dashValues;
                g.DrawLine(dashPen, point1, point2);
            }



            Console.WriteLine("End");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Graphics g = Graphics.FromHwnd(this.Handle);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                double a;
                string b = "";
                int c, d;


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
                List<int> y_Topleft_m = new List<int>();
                #endregion


                #region Establishing_connection
                con.ConnectionString = @Global.conn;
                con.Open();
                #endregion

                List<String> dataa = new List<String>();


                int nb_crane = Global.selected_cranes.Count;
                string[] data1 = new string[nb_crane + 1];
                Console.WriteLine("nb_crane " + nb_crane);

                for (int i = 0; i < nb_crane; i++)
                {
                    int ID = Global.selected_cranes.ElementAt(i);
                    DataTable LocalDataNCSG = new DataTable();
                    DataAdapterNCGS = new OleDbDataAdapter("SELECT [Model],[Configuration] FROM NCSG_CranesList where [CraneID]=" + ID, con);    // all the SQL queries: called 'OLEDB Command Builder'
                    DataAdapterNCGS.Fill(LocalDataNCSG);
                    data1[i] = LocalDataNCSG.Rows[0][0].ToString() + " , " + LocalDataNCSG.Rows[0][1].ToString();
                }
                data1[nb_crane] = "All";
                dataa.AddRange(data1);
                CraneListCBox.DataSource = dataa;

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
                        c = Convert.ToInt32(b) / 2;
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
                        c = Convert.ToInt32(b) / 2;
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
                boundary_offset = new Region(boundary_offset_path);
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
                        g.DrawPath(pen1, obstruction_path);
                        g.FillPath(myHatchBrush, obstruction_path);
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
                    g.DrawPath(pen1, obs);
                    g.FillPath(myHatchBrush, obs);
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
                    g.FillRectangle(SPSolidBrush, set_pos);
                    g.DrawRectangle(pen2, set_pos);

                    boundary_region.Exclude(set_pos);
                    recc.Add(set_pos);
                    boundary_offset.Exclude(set_pos);
                }
                #endregion

                #region Creating and removing pick areas boundary and displaying them
                for (int i = 0; i < x_Topleft_pa.Count; i++)
                {
                    Rectangle pick_area = new Rectangle(x_Topleft_pa[i], y_Topleft_pa[i], pick_width_pa[i], pick_length_pa[i]);
                    g.DrawRectangle(pen1, pick_area);
                    g.FillRectangle(PAHatchBrush, pick_area);
                    boundary_region.Exclude(pick_area);
                    boundary_offset.Exclude(pick_area);
                }
                #endregion




                //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//


                // rectifier the solutions separate region pick and walk 

                //sfor()










            }
            catch { }
        }
    }
}