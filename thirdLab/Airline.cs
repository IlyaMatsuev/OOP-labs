using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public partial class  Airline
    {
        public uint makeHash(string dest, int flight, char type, weekDays day)
        {
            int intRes = dest.Length + flight * 9 - (int)type;
            if (day > weekDays.thir)
                intRes *= 54;
            uint res = (uint)intRes;
            return res;
        }
        
        
    }
}
