using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    struct SomeStruct
    {
        public string name;
        public int age;

        public void DisplayNameAndAge() => Console.WriteLine($"Name: {name}, age: {age}");

        public SomeStruct(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }

    enum Dig
    {
        ONE = 1, TWO, THREE
    }

    class Lab5
    {
        static void Main(string[] args)
        {
            Dig dig = Dig.ONE;
            Console.WriteLine(dig);
            dig++;
            Console.WriteLine(dig);
            SomeStruct someStruct = new SomeStruct("Ilya", 18 );
            someStruct.DisplayNameAndAge();
            string name = someStruct.name;


            Port port = new Port(3);
            port[0] = new Boat(44, "Ilya", 18);
            port[1] = new Sailboat(777, "Ilya", 28);
            port[2] = new Corvette(7878787, "Petr Poroshenko", 999, 3232);
            port[5] = new Boat(444, "qd", 4);
            foreach(Ship ship in PortController.AllCaptainsAgeLessThan35(port))
                ship.GetVehicleInf();
            Console.WriteLine("Displacement of all sailboats: " + PortController.CalculateDisplacement(port));
            Console.WriteLine("Seats of all steamers: " + PortController.SteamerSeats(port));
        }
    }
}
