using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    sealed class Steamer : Ship
    {
        public uint Seats { get; set; }

        public Steamer(double Carrying, string CaptainName, uint CaptainAge, double Delta, uint Seats)
            :base(Carrying, CaptainName, CaptainAge, Delta)
        {
            this.Seats = Seats;
            ToWater();
        }

        public override void Move() => Console.WriteLine("So much stream and so low");
        public override string ToString() => "Steamer";
    }
}
