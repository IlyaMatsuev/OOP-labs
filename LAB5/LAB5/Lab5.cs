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
            Ship steamer = new Steamer(double.MaxValue / 100, "Vitya Neptun", "Steamer");
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

            Ship secondBoat = new Boat(200, "Privet Andrey", "boat");
            Console.WriteLine($"Equals?\t{boat.Equals(secondBoat)}");
            Console.WriteLine($"Type?\t{boat.ToString()}");
            Console.WriteLine($"My own hash: {boat.GetHashCode()}");
            Console.WriteLine("===============================================");

            Console.WriteLine("One-name methods: ");
            IVehicle icorvette = new Corvette(90000, "Borodina Elizaveta", "Corvette", 222);
            icorvette.OneNameMethod();
            ICaptain isteamer = new Steamer(5677, "Pushkin Aleksandr", "steamer");
            isteamer.OneNameMethod();
            Console.WriteLine("===============================================");

            Console.WriteLine(icorvette.GetType());
            if (icorvette is IVehicle)
                Console.WriteLine("Its have a IVehicle type");
            else
                Console.WriteLine("Wrong");
            if (icorvette is ICaptain)
                Console.WriteLine("Its have a ICaptain type");
            else
                Console.WriteLine("Wrong");
            if (icorvette is Corvette)
                Console.WriteLine("Its have a Corvette type");
            else
                Console.WriteLine("Wrong");
            Object someObj = corvette;
            icorvette = someObj as Corvette;
            if (icorvette != null)
                Console.WriteLine("Good");
            else
                Console.WriteLine("Bad");
            Console.WriteLine("===============================================");

            object[] ListOfObjescts = new object[] { boat, corvette, sailboat, steamer};
            foreach(ICaptain cap in ListOfObjescts)
                Printer.iAmPrinting(cap);


        }
    }
}
