using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LAB5
{
    class Port
    {
        private static Ship[] shipsArr;
        private int maxIndex;

        public Ship this[int index]
        {
            get
            {
                if (index > maxIndex)
                {
                    Console.WriteLine("Превышен максимальный индекс массива кораблей");
                    return null;
                }
                return shipsArr[index];
            }
            set
            {
                if (index > maxIndex)
                    Console.WriteLine("Элемента с таким индексом не существует");
                else
                    shipsArr[index] = value;
            }
        }

        public Port(int maxIndex)
        {
            this.maxIndex = maxIndex - 1;
            shipsArr = new Ship[maxIndex];
        }

        public Ship[] GetShips() => shipsArr;
        public static void Show()
        {
            foreach(Ship sh in shipsArr)
                sh.GetVehicleInf();
        }
    }
}
