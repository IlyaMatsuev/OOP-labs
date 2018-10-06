using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    class Lab5
    {
        static void Main(string[] args)
        {
            Ship boat = new Boat(500, "Ilya", "boat");
            Ship corvette = new Corvette(double.MaxValue, "Petr Poroshenko", "Corvette", 666);
            Ship sailboat = new Sailboat(10000, "Aleksey Navalny", "Sailboat");
            Ship steamer = new Steamer(double.MaxValue / 100, "Vita Neptun", "Steamer");
            Console.WriteLine("===============================================");
            Console.WriteLine("===============================================");

            boat.Move();
            boat.GetVehicleInf();
            Console.WriteLine("===============================================");

            corvette.Move();
            corvette.GetVehicleInf();
            Console.WriteLine("===============================================");

            sailboat.Move();
            sailboat.GetVehicleInf();
            Console.WriteLine("===============================================");

            steamer.Move();
            steamer.GetVehicleInf();
            Console.WriteLine("===============================================");
        }
    }
}
