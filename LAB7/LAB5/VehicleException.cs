using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    class VehicleException : CustomException
    {
        public double CarringException { get; set; }

        public VehicleException(string message, double CarringException)
            :base(message, "Vehicle")
        {
            this.CarringException = CarringException;
        }
    }
}
