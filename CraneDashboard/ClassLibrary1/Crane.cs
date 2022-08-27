using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Crane
    {
        public string CraneID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Rmax { get; set; }
        public int LiftHeight { get; set; }
        public int CraneWeight { get; set; }
        public string ImageFile { get; set; }
    }
}
