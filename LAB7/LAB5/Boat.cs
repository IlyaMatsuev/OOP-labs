using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    sealed class Boat : Ship
    {
        public Boat(double Carrying, string CaptainName, uint CaptainAge)
            : base(Carrying, CaptainName, CaptainAge)
        {
            ToWater();
        }

        public override void Move() => Console.WriteLine("Anyway better than nothing");
        public override string ToString() => "Boat";
    }
}
