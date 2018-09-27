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

    public class NewClass : System.Object
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return base.Equals(obj);
        }

        public override int GetHashCode() => base.GetHashCode();
        public override string ToString() => base.ToString();
    }


}
