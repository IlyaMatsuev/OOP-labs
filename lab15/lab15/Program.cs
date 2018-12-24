using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab15
{
    class Program
    {
        private static EventWaitHandle waitHandle = new ManualResetEvent(initialState: true);

        static void Main(string[] args)
        {
            int n;
            while (true)
            {
                Console.Write("Write some number: ");
                if (int.TryParse(Console.ReadLine(), out n))
                    break;
                else
                    Console.WriteLine("Try again");
            }
            Thread secondThread = new Thread(WriteNumbersEverywhere);
            secondThread.Name = "SecondThread";

            Methods.WriteProcessToFile(@"processInfo.txt");
            Methods.CurrentDomainInfo();

            secondThread.Start(n);
            Methods.NewDomainActions();
            // Stoped thread
            waitHandle.Reset();
            
            Console.WriteLine("Thread status: " + secondThread.ThreadState.ToString());
            Console.WriteLine("Thread Name: " + secondThread.Name.ToString());
            Console.WriteLine("Thread id: " + secondThread.ManagedThreadId.ToString());

            for (int i = 0; i < 100; i++)
                Console.WriteLine("Thread paused " + i);
            // Resume thread
            waitHandle.Set();

            if (secondThread.IsAlive)
            {
                Console.WriteLine("\n\nThread status: " + secondThread.ThreadState.ToString());
                Console.WriteLine("Thread Name: " + secondThread.Name.ToString());
                Console.WriteLine("Thread id: " + secondThread.ManagedThreadId.ToString());
            }
            else
                Console.WriteLine("Thread is dead\n\n");
            Console.WriteLine("====================================================");

            Thread oddThread = new Thread(Methods.OddAndEvenNumbersToConsole);
            oddThread.Name = "oddThread";
            oddThread.Priority = ThreadPriority.Lowest;
            Thread evenThread = new Thread(Methods.OddAndEvenNumbersToConsole);
            evenThread.Name = "evenThread";
            evenThread.Priority = ThreadPriority.Lowest;

            // true = odd numbers, false = even numbers
            ValueTuple<int, bool> oddnum = (n, true);
            ValueTuple<int, bool> evennum = (n, false);

            oddThread.Start(oddnum);
            evenThread.Start(evennum);
            
            // Waiting for end of processes
            Thread.Sleep(2000);
            Methods.OddAndEvenNumbersToFile();
            Console.WriteLine("====================================================");

            TimerCallback tm = new TimerCallback(RandomTimerMethod);
            Timer timer = new Timer(tm, 10, 0, 500);

            Console.ReadLine();
            Console.WriteLine("====================================================");


            // Coming soon
        }

        static void WriteNumbersEverywhere(object num)
        {
            int n = (int)num;
            using (StreamWriter sw = new StreamWriter(@"Numbers.txt", false, Encoding.Default))
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Second thread: " + i);
                    sw.WriteLine("Second thread: " + i);
                    Thread.Sleep(0);
                    waitHandle.WaitOne();
                }
            }
        }

        static void RandomTimerMethod(object count)
        {
            int n = (int)count;
            for (int i = 1; i < 9; i++, n++)
                Console.WriteLine("Timer " + (n * i).ToString());
        }
    }
}
