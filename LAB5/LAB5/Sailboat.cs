using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    sealed class Sailboat : Ship
    {
        public Sailboat(double Carrying, string CaptainName, string ShipType)
            : base(Carrying, CaptainName, ShipType)
        {
            ToWater();
        }

        public override void Move() => Console.WriteLine("Hold your nose to the wind");
        public override string ToString() => "Sailboat";
    }
}
