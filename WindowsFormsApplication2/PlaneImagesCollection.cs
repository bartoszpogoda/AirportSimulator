using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorLotniska
{
    public static class PlaneImagesCollection
    {
        public static List<string> passengerPlaneNames;
        public static List<string> transportPlaneNames;
        public static List<string> militaryPlaneNames;

        public static void init()
        {
            passengerPlaneNames = new List<string>();
            transportPlaneNames = new List<string>();
            militaryPlaneNames = new List<string>();

            passengerPlaneNames.Add("P1");
            passengerPlaneNames.Add("P2");

            transportPlaneNames.Add("T1");
            transportPlaneNames.Add("T2");
            transportPlaneNames.Add("T3");
            transportPlaneNames.Add("T4");
        }
    }
}
