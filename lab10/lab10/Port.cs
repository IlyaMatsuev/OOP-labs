using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Port : IComparable
    {
        public Port(int maxIndex)
        {
            this.maxIndex = maxIndex;
            shipsArr = new Ship[this.maxIndex];
        }

        private Ship[] shipsArr;
        private int maxIndex;

        public Ship this[int index]
        {
            get
            {
                if (index > maxIndex)
                {
                    Console.WriteLine("Invalid index");
                    return null;
                }
                return shipsArr[index];
            }
            set
            {
                if (index > maxIndex)
                    Console.WriteLine("Invalid index");
                else
                    shipsArr[index] = value;
            }
        }

        public void Print()
        {
            foreach(Ship ship in shipsArr)
                Console.WriteLine($"Carring: {ship.Carrying}, Name: {ship.VehicleName}");
        }

        public Ship[] GetShips() => shipsArr;

        public int CompareTo(object port)
        {
            if (shipsArr.Length > ((Port)port).shipsArr.Length)
                return 1;
            if (shipsArr.Length < ((Port)port).shipsArr.Length)
                return -1;
            return 0;
        }
    }
}
