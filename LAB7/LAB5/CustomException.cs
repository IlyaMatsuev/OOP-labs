using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    abstract class CustomException : Exception
    {
        public string ErrorClass { get; set; }

        public CustomException(string message, string ErrorClass)
            : base(message)
        {
            this.ErrorClass = ErrorClass;
        }
    }
}