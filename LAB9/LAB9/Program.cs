using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB9
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            var class1 = new Class1();
            var class2 = new Class2();

            user.replaceEvent += class1.repl;
            user.replaceEvent += class2.repl;
            user.replaceEvent += (x) => Console.WriteLine("Лямбда-выражение " + x);

            user.compressionEvent += class1.compr;
            user.compressionEvent += class2.compr;
            user.compressionEvent += class2.compr;
            user.compressionEvent += class2.compr;
            user.compressionEvent -= class1.compr;

            user.replOrCompr(true, 20);
            Console.WriteLine("=================================");
            user.replOrCompr(false, 30);

            Console.WriteLine("=================================");

            
            string str = "Hello, my name is Ilya. I'd like to drink a cup of green tea and go to bed...                           )))))";
            Action<string> actionOnConsole = (s) => Console.WriteLine(s);
            actionOnConsole(str);
            Func<string, string> func = User.AddSymbols;
            actionOnConsole(str = func(str));
            func += User.ToUpperCase;
            actionOnConsole(str = func(str));
            func += User.AfterFirstWord;
            actionOnConsole(str = func(str));
            func += User.RemoveSpaces;
            actionOnConsole(str = func(str));
            func += User.RemoveCommasDotes;
            actionOnConsole(str = func(str));
            func += User.ToBinary;
            actionOnConsole("Binary:");
            actionOnConsole(str = func(str));
        }
    }





}
