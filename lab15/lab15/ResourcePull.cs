using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab15
{
    public class ResourcePull
    {
        private static Thread[] thread;
        private static Semaphore sem;
        private const int maxClientCount = 5;
        private static int clientCount;
        private const int TimeOut_ms = 2000;

        static ResourcePull()
        {
            clientCount = -1;
            thread = new Thread[maxClientCount];
            sem = new Semaphore(0, maxClientCount);
        }

        public static void ConnectClient(Client client)
        {
            clientCount++;
            thread[clientCount] = new Thread(GetService);
            thread[clientCount].Name = client.Name;
            thread[clientCount].Start();
        }

        public static void GetService()
        {
            while (true)
            {
                if (clientCount < maxClientCount)
                {
                    sem.WaitOne();
                    Console.WriteLine(Thread.CurrentThread.Name + " gets the service");
                    Thread.Sleep(1000);
                    Console.WriteLine(Thread.CurrentThread.Name + " finishes");
                    sem.Release();
                    clientCount--;
                    Thread.Sleep(1000);
                }
                else
                {
                    Thread.Sleep(TimeOut_ms);
                    continue;
                }
            }
        }


    }
}
