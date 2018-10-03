using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB4
{
    class Lab4
    {
        static void Main(string[] args)
        {
            Vector a = new Vector(60, 6.86F, 18.22F);
            Vector b = new Vector(40, 3.14F, 9.1111F);
            Vector.showVector(a + b);
            Vector.showVector(b - a);
            Console.WriteLine(a > b);
            Console.WriteLine(a < b);
            Vector.showVector(a == b);
            Vector.showVector(a != b);
            if (new Vector(0, 0, 0))
                Console.WriteLine("Не пустой вектор");
            else
                Console.WriteLine("Пустой вектор");
            if (a)
                Console.WriteLine("Не пустой вектор");
            else
                Console.WriteLine("Пустой вектор");
            Vector.showVector(a.deletePos());
            string somestr = "не я тупой";
            Console.WriteLine(somestr.cutStr(3));
            Console.WriteLine(a.ShowDate());
            Console.WriteLine(a.owner.NAME);
            Console.WriteLine(a.owner.ID);
            Console.WriteLine(a.owner.ORG);
        }
    }
}
