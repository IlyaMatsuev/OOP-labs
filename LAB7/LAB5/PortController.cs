using System;
using System.Diagnostics;
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
            foreach (Ship ship in port.GetShips())
                if (ship.ToString() == "Sailboat")
                    displacement += draft * width * ship.Delta;
            Debug.Assert(displacement != 0, "В порту нет парусников?((");
            return displacement;
        }

        public static uint SteamerSeats(Port port)
        {
            uint seats = 0;
            foreach (Ship ship in port.GetShips())
            {
                Steamer steamer = ship as Steamer;
                if (steamer != null)
                    seats += steamer.Seats;
            }
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
