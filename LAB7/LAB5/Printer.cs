using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    class Printer
    {
        public static void iAmPrinting(ICaptain cap) => Console.WriteLine(cap.ToString());
    }
}
