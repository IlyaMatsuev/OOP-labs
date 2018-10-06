using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    interface IVehicle
    {
        string VehicleName { get; set; }
        double Carrying { get; set; }

        void GetVehicleInf();
    }
}
