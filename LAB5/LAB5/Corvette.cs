using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    class Corvette : Ship
    {
        public int Weapon { get; set; }

        public Corvette(double Carrying, string CaptainName, string ShipType, int Weapon)
            : base(Carrying, CaptainName, ShipType)
        {
            this.Weapon = Weapon;
            ToWater();
        }

        public override void Move() => Console.WriteLine("I have never had so much power");
        public override void GetVehicleInf()
        {
            base.GetVehicleInf();
            Console.Write($"Weapons: {Weapon}, ");
        }
    }
}
