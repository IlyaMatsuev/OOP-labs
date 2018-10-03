using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4
{
    public static class MathOperation
    {
        public static Vector GetMax(Vector[] vectors)
        {
            Vector maxV = null;
            float max = float.MinValue;
            foreach(Vector vec in vectors)
                if(Vector.GetSum(vec) > max)
                {
                    max = Vector.GetSum(vec);
                    maxV = vec;
                }
            return maxV;
        }

        public static Vector GetMin(Vector[] vectors)
        {
            Vector minV = null;
            float min = float.MaxValue;
            foreach (Vector vec in vectors)
                if (Vector.GetSum(vec) < min)
                {
                    min = Vector.GetSum(vec);
                    minV = vec;
                }
            return minV;
        }

        public static uint GetCount(Vector[] vectors)
        {
            uint count = 0;
            foreach (Vector vec in vectors)
                count++;
            return count;
        }

        public static Vector deletePos(this Vector vec)
        {
            if (vec.X > 0)
                vec.X = 0;
            if (vec.Y > 0)
                vec.Y = 0;
            if (vec.Z > 0)
                vec.Z = 0;
            return vec;
        }

        public static string cutStr(this string str, uint ch) => str.Substring((int)ch);
    }
}
