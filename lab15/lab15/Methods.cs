using System;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab15
{
    public static class Methods
    {
        private static object locker = new object();
        private static string oddAbdEvenNum = "";

        public static void OddAndEvenNumbersToConsole(object num)
        {
            // true = odd numbers, false = even numbers
            //lock (locker)
            //{
                ValueTuple<int, bool> n = (ValueTuple<int, bool>)num;
                for (int i = 0; i < n.Item1; i++)
                {
                    if (i % 2 == 1 && n.Item2)
                    {
                        string str = "Odd Thread: " + i + '\n';
                        Console.Write(str);
                        oddAbdEvenNum += str;
                        Thread.Sleep(0);
                        //Thread.Sleep(100);
                    }
                    if (i % 2 == 0 && !n.Item2)
                    {
                        string str = "Even Thread: " + i + '\n';
                        Console.Write(str);
                        oddAbdEvenNum += str;
                        Thread.Sleep(0);
                        //Thread.Sleep(100);
                    }
                }
            //}
        }

        public static void OddAndEvenNumbersToFile()
        {
            using (StreamWriter sw = new StreamWriter(@"OddEvenNumbers.txt", false, Encoding.Default))
            {
                sw.Write(oddAbdEvenNum);
            }
        }


        public static void WriteProcessToFile(string path)
        {
            var process = Process.GetProcesses();
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                foreach (var p in process)
                {
                    sw.WriteLine("ProcName: " + p.ProcessName);
                    sw.WriteLine("ProcId: " + p.Id);
                    //sw.WriteLine("ProcPriority: " + p.BasePriority);
                    //sw.WriteLine("ProcStartTime: " + p.StartTime.ToString());
                    //sw.WriteLine("ProcWorkingTime: " + p.TotalProcessorTime);
                    sw.WriteLine("\n\n");
                }
            }
            Console.WriteLine("First task has complete\n\n");
        }


        public static void CurrentDomainInfo()
        {
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("Domain id: " + domain.Id);
            Console.WriteLine("Domain name: " + domain.FriendlyName);
            Console.WriteLine("Domain base directory: " + domain.BaseDirectory);
            Assembly[] assemblies = domain.GetAssemblies();
            Console.WriteLine("Assemblies:");
            foreach (var ass in assemblies)
                Console.WriteLine("Name: " + ass.GetName().Name);
        }

        public static void NewDomainActions()
        {
            AppDomain domain = AppDomain.CreateDomain("My custom domain");
            domain.AssemblyLoad += DomainAssLoadEvent;
            domain.DomainUnload += DomainUnloadEvent;

            // Need to copy it to lab15/bin/debug/
            domain.Load(new AssemblyName("System.Data"));   
            Assembly[] assemblies = domain.GetAssemblies();
            foreach(var ass in assemblies)
            {
                Console.WriteLine("Name: " + ass.GetName().Name);
                Thread.Sleep(50);
            }

            AppDomain.Unload(domain);
        }
        private static void DomainUnloadEvent(object sender, EventArgs e) => Console.WriteLine("Домен выгружен из процесса");
        private static void DomainAssLoadEvent(object sender, AssemblyLoadEventArgs args) => Console.WriteLine("Сборка загружена");



        public static void HardTask1()
        {
            Thread auto1 = new Thread(HardTaskHandler);
            Thread auto2 = new Thread(HardTaskHandler);
            Thread auto3 = new Thread(HardTaskHandler);
            auto1.Name = "auto1";
            auto1.Priority = ThreadPriority.Lowest;
            auto2.Name = "auto2";
            auto2.Priority = ThreadPriority.Highest;
            auto3.Name = "auto3";
            auto3.Priority = ThreadPriority.Highest;
            string file = "";
            using (StreamReader reader = new StreamReader(@"Warehouse.txt", Encoding.Default))
            {
                file = reader.ReadToEnd();
            }
            auto1.Start(file);
            auto2.Start(file);
            auto3.Start(file);

            Console.ReadLine();
            Console.WriteLine("====================================================");
        }

        public static void HardTaskHandler(object file)
        {
            lock (locker)
            {
                string reader = (string)file;
                string product = "";
                foreach (var ch in reader)
                    if (ch == '\n')
                    {
                        Console.WriteLine(Thread.CurrentThread.Name + " load a box of " + product);
                        product = "";
                        Thread.Sleep(0);
                    }
                    else
                        product += ch;
                Console.WriteLine("\n " + Thread.CurrentThread.Name + " HAS DONE\n");
            }
        }

        public static void HardTask2()
        {
            List<Client> clients = new List<Client>()
            {
                new Client("Ilya"),
                new Client("Anya"),
                new Client("Kolya"),
                new Client("Ivan"),
                new Client("Nastya")
            };
            foreach (var cl in clients)
                ResourcePull.ConnectClient(cl);

            Console.ReadLine();
            Console.WriteLine("====================================================");
        }

    }
}
