using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Ship
    {
        public string VehicleName { get; set; }
        public double Carrying { get; set; }
        

        public Ship(string VehicleName, double Carrying)
        {
            this.VehicleName = VehicleName;
            this.Carrying = Carrying;
        }
    }
}
