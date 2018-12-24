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
        private static string oddNum = "";
        private static string evenNum = "";

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
                        oddNum += str;
                        Thread.Sleep(0);
                        //Thread.Sleep(100);
                    }
                    if (i % 2 == 0 && !n.Item2)
                    {
                        string str = "Even Thread: " + i + '\n';
                        Console.Write(str);
                        evenNum += str;
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
                sw.Write(oddNum);
                sw.Write(evenNum);
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



    }
}
