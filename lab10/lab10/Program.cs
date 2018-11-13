using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Внимание, в лабе очень много багов, в том плане, что никаких проверок на вводимые вами данные у меня нет,
            // поэтому смотрите по заданию, что вам требуется вводить в консоли, чтобы все работало


            var arraylist = new ArrayList();
            var rand = new Random();
            for (var i = 0; i < 5; i++)
                arraylist.Add(rand.Next());
            arraylist.Add("String");
            arraylist.Add(new Student<int>());
            Console.Write("Какой элемент удалить(индекс): ");
            int el = int.Parse(Console.ReadLine());
            if (el > arraylist.Count)
                Console.WriteLine("wrong");
            else
                arraylist.Remove(arraylist[el]);
            Console.WriteLine("Количество: " + arraylist.Count);
            foreach(object obj in arraylist)
                Console.WriteLine(obj);
            Console.WriteLine("=====================================");
            Console.Write("Введите индекс значения для поиска: ");
            el = int.Parse(Console.ReadLine());
            if (el > arraylist.Count)
                Console.WriteLine("wrong");
            else
                foreach(object obj in arraylist)
                    if (obj.Equals(arraylist[el]))
                        Console.WriteLine(obj);
            Console.WriteLine("=====================================");
            var genericlist = Student<long>.genericlist;
            for(var i = 0; i < 10; i++)
                genericlist.Add((long)(long.MaxValue / 10 * i));
            foreach (object obj in genericlist)
                Console.WriteLine(obj);
            Console.WriteLine("=====================================");
            Console.WriteLine("Полный размер коллекции: " + genericlist.Count);
            Console.Write("Сколько удалить: ");
            el = int.Parse(Console.ReadLine()) - 1;
            for (var i = 0; i < el; i++)
                genericlist.Remove(genericlist[genericlist.Count - 1]);
            foreach (object obj in genericlist)
                Console.WriteLine(obj);
            Console.WriteLine("=====================================");
            genericlist.Add(5678);
            genericlist.AddRange(new long[] { 12222, 12222 });
            Console.WriteLine("=====================================");
            var sortedlist = Student<long>.sortedset;
            foreach (long obj in genericlist)
                sortedlist.Add(obj);
            foreach (object obj in sortedlist)
                Console.WriteLine(obj);
            Console.WriteLine("=====================================");
            Console.Write("Введите элемент для поиска: ");
            long lon = long.Parse(Console.ReadLine());
            foreach (long ln in sortedlist)
                if (ln == lon)
                    Console.WriteLine("Нашел: " + ln);
            Console.WriteLine("=====================================");
            Console.WriteLine("With my class: ");
            var listOfMyType = Student<Port>.genericlist;
            var port1 = new Port(2);
            port1[0] = new Ship("ship1.1", 100);
            port1[1] = new Ship("ship1.2", 101);
            var port2 = new Port(2);
            port2[0] = new Ship("ship2.1", 200);
            port2[1] = new Ship("ship2.2", 201);
            //port2[2] = new Ship("ship2.3", 207);
            var port3 = new Port(1);
            port3[0] = new Ship("ship3.1", 300);
            listOfMyType.AddRange(new Port[] { port1, port2, port3 });

            foreach (Port obj in listOfMyType)
                obj.Print();
            Console.WriteLine("=====================================");

            Console.WriteLine("Полный размер коллекции: " + listOfMyType.Count);
            Console.Write("Сколько удалить: ");
            int ell = int.Parse(Console.ReadLine()) - 1;
            for (var i = ell; i >= 0; i--)
                listOfMyType.RemoveAt(i);
            foreach (Port obj in listOfMyType)
                obj.Print();
            Console.WriteLine("=====================================");
            var sortedsetOfMyType = Student<Port>.sortedset;
            foreach (Port obj in listOfMyType)
                sortedsetOfMyType.Add(obj);
            foreach (Port obj in sortedsetOfMyType)
                obj.Print();
            Console.WriteLine("=====================================");

            Console.Write("Введите имя корабля элемента для поиска: ");
            string eel = Console.ReadLine();
            int q = 0;
            foreach(Port port in sortedsetOfMyType)
            {
                q++;
                foreach (Ship ship in port.GetShips())
                    if (eel == ship.VehicleName)
                        Console.WriteLine($"Нашел: {q}-ый элемент, имя {eel}");
            }
            Console.WriteLine("=====================================");

            ObservableCollection<Student<int>> students = new ObservableCollection<Student<int>>()
            {
                new Student<int>("Vitya"),
                new Student<int>("Kolya"),
                new Student<int>("Grisha"),
            };
            students.CollectionChanged += Student<int>.WhenChange;
            students.Add(new Student<int>());
            students.RemoveAt(3);
            students[1] = new Student<int>("Andrey");

            foreach(Student<int> student in students)
                Console.WriteLine(student.Name);

        }
    }
}
