using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    partial class Port
    {
        private static Ship[] shipsArr;
        private int maxIndex;

        public Ship this[int index]
        {
            get
            {
                if (index > maxIndex)
                {
                    throw new PortException("Превышен максимальный индекс массива кораблей", index, maxIndex);
                }
                return shipsArr[index];
            }
            set
            {
                if (index > maxIndex)
                    throw new PortException("Элемента с таким индексом не существует", index, maxIndex);
                else
                    shipsArr[index] = value;
            }
        }
    }
}
