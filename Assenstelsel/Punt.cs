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
        public int rasterX { get; set; }
        public int rasterY { get; set; }
        public int Kleur { get; set; }
        public int breedteRand { get; set; }
        public int randKleur { get; set; }


        public string rasterCords => rasterX.ToString() + rasterY.ToString();

    }
}
