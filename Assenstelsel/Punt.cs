using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assenstelsel
{
    public class Punt
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int X_Beeldscherm { get; set; }
        public int Y_Beelscherm { get; set; }
        public int RasterX { get; set; }
        public int RasterY { get; set; }
        public int Kleur { get; set; }
        public int BreedteRand { get; set; }
        public int RandKleur { get; set; }


        public string RasterCords => RasterX.ToString() + RasterY.ToString();

    }
}
