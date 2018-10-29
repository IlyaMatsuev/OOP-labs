using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    class PortException : CustomException
    {
        public int CountException { get; set; }
        public int ExpectedCount { get; set; }

        public PortException(string message, int CountException, int ExpectedCount)
            : base(message, "Port")
        {
            this.CountException = CountException;
            this.ExpectedCount = ExpectedCount;
        }
    }
}
