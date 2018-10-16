using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    static class PortController
    {
        public static double CalculateDisplacement(Port port)
        {
            double displacement = 0;
            double draft = 6.5F;
            double width = 14;
            double delta = 0.45F;
            double result = draft * width * delta;
            foreach(Ship ship in port.GetShips())
                if (ship.ToString() == "Sailboat")
                    displacement += result;
            return displacement;
        }

        public static uint SteamerSeats(Port port)
        {
            uint seats = 0;
            uint seatsOnSteamer = 10;
            foreach (Ship ship in port.GetShips())
                if (ship.ToString() == "Steamer")
                    seats += seatsOnSteamer;
            return seats;
        }

        public static List<Ship> AllCaptainsAgeLessThan35(Port port)
        {
            List<Ship> ships = new List<Ship>();
            uint age = 35;
            foreach (Ship ship in port.GetShips())
                if (ship.CaptainAge < age)
                    ships.Add(ship);
            return ships;
        }
    }
}
