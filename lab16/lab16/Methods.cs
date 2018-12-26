using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace lab16
{
    public static class Methods
    {
        // Я, если честно, так и не дождался выполнения проги с таким числом
        // Несколько минут ждал
        //private const long maxNum = 1000000000;
        private const long maxNum = 100000;

        private static CancellationTokenSource source = new CancellationTokenSource();
        private static CancellationToken token = source.Token;

        public static void SimpleNumberSearch()
        {
            for (long i = 2; i <= maxNum; i++)
            {
                if (AreSimple(i)) ;
                // Some actions
                //Console.Write(i + ", ");
                if(token.IsCancellationRequested)
                {
                    Console.WriteLine("See you soon\n");
                    return;
                }
            }
        }

        private static bool AreSimple(long num)
        {
            // Чтоб убедится простое число или нет достаточно проверить не делитсья ли 
            // Число на числа до его половины
            for (long i = 2; i <= (num / 2); i++)
                if (num % i == 0)
                    return false;
            return true;
        }


        public static void Task1()
        {
            int itaration = 3;
            Stopwatch stopwatch = new Stopwatch();
            while (itaration > 0)
            {
                stopwatch.Start();
                Task task = Task.Factory.StartNew(SimpleNumberSearch);
                Console.WriteLine($"Task{itaration} id: {task.Id.ToString()}");
                Console.WriteLine($"Task{itaration} status: {task.Status.ToString()}");
                task.Wait();
                stopwatch.Stop();
                Console.WriteLine($"Time for task{itaration}: {stopwatch.Elapsed.TotalMilliseconds.ToString()}\n");
                stopwatch.Reset();
                itaration--;
                Console.WriteLine("--------------------");
            }
            Console.WriteLine("=================================================");
        }

        public static void Task2()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Task task = Task.Factory.StartNew(SimpleNumberSearch);
            Console.WriteLine($"Task id: {task.Id.ToString()}");
            Console.WriteLine($"Task status: {task.Status.ToString()}");

            Console.WriteLine("Press q - to exit from task");
            if (Console.ReadKey().KeyChar == 'q')
                source.Cancel();

            task.Wait();
            stopwatch.Stop();
            Console.WriteLine($"Time for task: {stopwatch.Elapsed.TotalMilliseconds.ToString()}\n");
            Console.WriteLine("=================================================");
        }

        public static async void Task3_4Asinc()
        {
            Task<int> task1 = Task.Factory.StartNew(GetWeight);
            Task<int> task2 = Task.Factory.StartNew(GetDensity);
            Task<int> task3 = Task.Factory.StartNew(GetCapacity);

            await task1.ContinueWith((firstTask) => Console.WriteLine($"First task result: {firstTask.Result}"));
            await task2.ContinueWith((secondTask) => Console.WriteLine($"Second task result: {secondTask.Result}"));
            await task3.ContinueWith((thirdTask) => Console.WriteLine($"Third task result: {thirdTask.Result}"));

            task3.ContinueWith((thirdTask) => Console.WriteLine($"Third task result with GetAwaiter(): {thirdTask.Result}")).GetAwaiter();
            task2.ContinueWith((secondTask) => Console.WriteLine($"Second task result with GetAwaiter().GetResult(): {secondTask.Result}")).GetAwaiter().GetResult();
            Console.WriteLine("================================================\n");
        }

        // Methods by formula: m = Vq, where q - density, V - capacity
        const int capacity = 100;
        const int density = 1000;
        const int weight = 6000;

        public static int GetWeight() => capacity * density;
        public static int GetDensity() => weight / capacity;
        public static int GetCapacity() => weight / density;


        public static void Task5()
        {
            const int arrSize = 1000000;
            const int arrCount = 10;
            Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.For(0, arrCount, (Count) =>
            {
                int[] arr = new int[arrSize];
                Parallel.ForEach(arr, (el) =>
                {
                    el = arrCount * arrCount;
                });
            });
            stopwatch.Stop();
            Console.WriteLine("Time with Parallel.For, Parallel.ForEach: " + stopwatch.Elapsed.Milliseconds.ToString());
            stopwatch.Restart();
            for(int i = 0; i < arrCount; i++)
            {
                int[] arr = new int[arrSize];
                for (int j = 0; j < arr.Length; j++)
                    arr[j] = arrCount * arrCount;
            }
            stopwatch.Stop();
            Console.WriteLine("Time with two for operators: " + stopwatch.Elapsed.Milliseconds.ToString());
            Console.WriteLine("===============================================\n");
        }

        public static void Task6()
        {
            Parallel.Invoke(Task6Handler, Task6Handler, Task6Handler);
            Console.WriteLine("===============================================\n");
        }
        private static void Task6Handler()
        {
            int[] arr = new int[100000];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = i * i;
            Console.WriteLine("Task complete with Parallel.Invoke\n");
        }


        public class Task7
        {
            private static int productCount;
            private static BlockingCollection<string> products;

            private static void PutProuct()
            {
                // If you want to add more products per producer change this value
                int productsToPutCount = 1;

                for(int i = 0; i < productsToPutCount; i++, productCount++)
                    products.Add("product" + productCount);
                Console.WriteLine($"Producer put product{productCount} to warehouse");
                //ShowWarehouse();
                products.CompleteAdding();
            }

            private static void TakeProduct()
            {
                string productToTake;
                while (!products.IsCompleted)
                {
                    if (products.TryTake(out productToTake))
                        Console.WriteLine($"Consumer takes a {productToTake} from warehouse");
                        //ShowWarehouse();
                }
            }

            // Doesnt work, with it to Console prints chaotic strings
            private static void ShowWarehouse()
            {
                Console.WriteLine("------------Products------------");
                foreach (var product in products)
                    Console.WriteLine(product);
                Console.WriteLine("--------------------------------\n\n");
            }

            public static void TaskMain()
            {
                productCount = 0;
                products = new BlockingCollection<string>();

                Task[] producers = new Task[]
                {
                    Task.Factory.StartNew(PutProuct),
                    Task.Factory.StartNew(PutProuct),
                    Task.Factory.StartNew(PutProuct),
                    Task.Factory.StartNew(PutProuct),
                    Task.Factory.StartNew(PutProuct)
                };
                Task[] consumers = new Task[]
                {
                    Task.Factory.StartNew(TakeProduct),
                    Task.Factory.StartNew(TakeProduct),
                    Task.Factory.StartNew(TakeProduct),
                    Task.Factory.StartNew(TakeProduct),
                    Task.Factory.StartNew(TakeProduct),
                    Task.Factory.StartNew(TakeProduct),
                    Task.Factory.StartNew(TakeProduct),
                    Task.Factory.StartNew(TakeProduct),
                    Task.Factory.StartNew(TakeProduct),
                    Task.Factory.StartNew(TakeProduct)
                };

                Task.WaitAll(producers.Concat(consumers).ToArray());
                foreach (var pr in producers)
                    pr.Dispose();
                foreach (var con in consumers)
                    con.Dispose();
                Console.WriteLine("\n==============================================\n");
            }
        }
    }
}
