using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LAB5
{
    partial class Port
    {
        public Port(int maxIndex)
        {
            this.maxIndex = maxIndex - 1;
            shipsArr = new Ship[maxIndex];
        }

        public Ship[] GetShips() => shipsArr;
        public static void Show()
        {
            foreach(Ship sh in shipsArr)
                sh.GetVehicleInf();
        }
    }
}
