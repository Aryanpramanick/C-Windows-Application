using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Layout
    {
        public double Distance(double x1, double y1, double x2, double y2)
        {
            var temp1 = Math.Pow(x2 - x1, 2);
            var temp2 = Math.Pow(y2 - y1, 2);
            var result = Math.Sqrt(temp1 + temp2);
            return result;
        }

        public Boolean Compare(List<int> list1, List<List<int>> SharedRegion)
        {
            bool check = false;
            foreach (List<int> el in SharedRegion)
            {
                el.Sort();
                bool valid = true;
                if (el.Count == list1.Count)
                {
                    for (int i = 0; i < el.Count; i++)
                    {
                        if (el.ElementAt(i) != list1.ElementAt(i))
                        { valid = false; }
                    }
                    if (valid==true) { check = true; }
                }
            }

            return check;
        }


        public Boolean Belong(List<int> list1, List<List<int>> SharedRegion)
        {
            bool valid = false;
                     

            foreach (List<int> el in SharedRegion)
            {
                el.Sort();
                int  count = 0;
               foreach(var l in list1)
               {    
                    foreach (var m in el) 
                    {
                        if (l == m) { count++; }
                    }
               }
               if (count == list1.Count) { valid = true; }  
            }
            return valid;
        }

        public Boolean IsVisible(int i, int j, List<int> Check_List, List<double[]> Info_Modules, List<int> x_center_m, List<int> y_center_m)
        {
            bool result = true;
            for (int s = 0; s < Check_List.Count; s++)
            {
                int m = Check_List.ElementAt(s);
                double[] tab = Info_Modules.ElementAt(m);
                double Rmax = tab[2];
                double Rmin = tab[1];

                int x = x_center_m.ElementAt(m);
                int y = y_center_m.ElementAt(m);
                Rmax = Math.Pow(Rmax,2);
                Rmin = Math.Pow(Rmin, 2);
                double D = (Math.Pow(x - i, 2) + Math.Pow(y - j, 2));
                if (D > Rmax || D < Rmin) { result = false; }
            }
            return result;
        }


        public Boolean Crane_Location_Parameter(int spacing, List<int> Check_List, List<int> listB, int cr, String CraneConfig, String CraneModel, List<double[]> Info_Modules, List<int> x_center_m, List<int> y_center_m, OleDbConnection connection, OleDbConnection connectionSolution)
        {

            OleDbDataAdapter DataAdapter = new OleDbDataAdapter();
            OleDbDataAdapter DataAdapterCrane = new OleDbDataAdapter();


            
            int X = listB.ElementAt(0);
            int Y = listB.ElementAt(2);
            int X0 = listB.ElementAt(1);
            int Y0 = listB.ElementAt(3);
            bool Validate = false;

            int lowest_MainBoom = 15000000, lowest_Radius = 15000000;

            for (int i = spacing + X0; i < X; i += spacing)
            {
                for (int j = spacing + Y0; j < Y; j += spacing)
                {
                    if (IsVisible(i, j, Check_List, Info_Modules, x_center_m, y_center_m))
                    {
                        int Check = 0;
                        int sum = 0;
                        int indexD = -1;
                        int indexB = -1;
                        List<int> Dist = new List<int>();
                        List<int> MBoom = new List<int>();
                        List<int> IDList = new List<int>();
                        Dist.Clear();
                        MBoom.Clear();
                        IDList.Clear();
                        for (int k = 0; k < Check_List.Count; k++)
                        {
                            int m = Check_List.ElementAt(k);
                            var tab = Info_Modules[m];
                            int x = x_center_m[m];
                            int y = y_center_m[m];
                            int Min_Raduis = (int)tab[1];

                            int D = (int)Math.Sqrt((Math.Pow(x - i, 2) + Math.Pow(y - j, 2)));

                            DataTable DataSetResult = new DataTable();
                            DataAdapter = new OleDbDataAdapter("SELECT * FROM Sheet1 where [load capacity]>" + tab[0] + " and [Radius] >= " + tab[1] + " and [Height] > " + (tab[3]), connection);
                            DataAdapter.Fill(DataSetResult);


                            var rows = DataSetResult.AsEnumerable().Where(r => r.Field<double>("Radius") == D);

                            if (rows.Count() != 0)
                            {
                                Check++;


                                sum += D;
                                DataSetResult = new DataTable();
                                DataAdapter = new OleDbDataAdapter("SELECT MIN([Main boom]) FROM Sheet1 where [load capacity]>" + tab[0] + " and [Radius] = " + D + " and [Radius]>= " + tab[1] + " and [Height] > " + (tab[3]), connection);
                                DataAdapter.Fill(DataSetResult);

                                int value_Main_Boom = Int32.Parse(DataSetResult.Rows[0][0].ToString());

                                Dist.Add(D);

                                MBoom.Add(value_Main_Boom);

                                if (value_Main_Boom <= lowest_MainBoom)
                                {
                                    lowest_MainBoom = value_Main_Boom;
                                    indexB = m;
                                }
                                if (D <= lowest_Radius)
                                {
                                    lowest_Radius = D;
                                    indexD = m;
                                }
                            }
                        }
                        if (Check == Check_List.Count) // Possible Solution
                        {
                            int NB = 0;
                            DataTable Localdata = new DataTable();
                            DataAdapter = new OleDbDataAdapter("SELECT * FROM Location", connectionSolution);
                            DataAdapter.Fill(Localdata);
                            NB = Localdata.Rows.Count;
                            for (int p = 0; p < MBoom.Count; p++)
                            {

                                NB++;
                                var querytext = "INSERT INTO Location(ID,Xset,Yset, IDCrane,CraneConfig,CraneModel, IDModule,Radius,MainBoom) VALUES('" + NB + "', '" + i + "', '" + j + "', '" + cr + "', '" + CraneConfig + "', '" + CraneModel + "', '" + Check_List.ElementAt(p) + "', '" + Dist.ElementAt(p) + "', '" + MBoom.ElementAt(p) + "')";
                                OleDbCommand cmd = new OleDbCommand(querytext, connectionSolution);
                                cmd.ExecuteNonQuery();
                            }
                            Validate = true;
                        }
                    }
                }
            }
            return Validate;
        }



    }
}
