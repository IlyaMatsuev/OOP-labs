using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    interface ICaptain
    {
        string CaptainName { get; set; }
        uint CaptainAge { get; set; }
        void OneNameMethod();
    }
}
