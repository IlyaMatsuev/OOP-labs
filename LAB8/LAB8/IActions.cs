using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8
{
    interface IActions<T>
    {
        void Add(T element);
        void Remove(T element);
        List<T> View();
    }
}
