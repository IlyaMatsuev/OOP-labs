using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    class Program
    {
        public void TestMethod(int num, string str)
        {
            Console.WriteLine($"num: {num}, str: {str}");
            Console.WriteLine("Господи боже наконец-то оно заработало");
        }
        
        static void Main(string[] args)
        {
            Reflector reflector = new Reflector();
            Reflector.WriteClassToFile(reflector.ToString());

            Console.WriteLine("Methods: ");
            foreach (var q in Reflector.GetMethods(reflector.ToString()))
                Console.WriteLine("\t" + q.Name);


            Console.WriteLine("Fields and properties: ");
            foreach (var q in Reflector.GetFieldsAndProp(reflector.ToString()))
                foreach (var qq in q)
                    Console.WriteLine("\t" + qq.Name);


            Console.WriteLine("Interfaces: ");
            foreach (var q in Reflector.GetInterface(reflector.ToString()))
                Console.WriteLine("\t" + q.Name);


            Console.WriteLine();
            Program main = new Program();
            Reflector.PrintMethodByName(main.ToString(), typeof(int));

            Reflector.WriteClassToFile(main.ToString());
            Reflector.ExecuteMethod(main.ToString(), "TestMethod");
        }
    }
}
