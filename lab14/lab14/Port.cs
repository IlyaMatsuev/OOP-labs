using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace lab14
{
    [Serializable]
    public class Port
    {
        [NonSerialized]
        public int maxIndex;
        public Ship[] shipsArr;

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

        private Port() { }
        public Port(int maxIndex)
        {
            this.maxIndex = maxIndex - 1;
            shipsArr = new Ship[maxIndex];
        }

        public Ship[] GetShips() => shipsArr;
        public void Show()
        {
            foreach(Ship sh in shipsArr)
                sh.GetVehicleInf();
        }
    }
}
