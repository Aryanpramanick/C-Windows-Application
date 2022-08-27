using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class InputData
    {
        public string CraneModel { get; set; }
        public int Capacity { get; set; }
        public int Rmax { get; set; }
        public int LiftHeight { get; set; }
        public int SLradius { get; set; }
        public bool Selection { get; set; }
        public int Boundary_X { get; set; }
        public int Boundary_Y { get; set; }
        public int Boundary_Width { get; set; }
        public int Boundary_Length { get; set; }
        public int Obstructions_X { get; set; }
        public int Obstructions_Y { get; set; }
        public int Obstructions_Width { get; set; }
        public int Obstructions_Length { get; set; }
        public int PickAreas_X { get; set; }
        public int PickAreas_Y { get; set; }
        public int PickAreas_Width { get; set; }
        public int PickAreas_Length { get; set; }
        public string Modules_Type { get; set; }
        public int Modules_SetX { get; set; }
        public int Modules_SetY { get; set; }
        public int Modules_SetZ { get; set; }
        public int Modules_Angle { get; set; }

    }
}
