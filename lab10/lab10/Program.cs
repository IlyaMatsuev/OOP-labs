using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var arraylist = new ArrayList();
            var rand = new Random();
            for (var i = 0; i < 5; i++)
                arraylist.Add(rand.Next());
            arraylist.Add("String");
            arraylist.Add(new Student<int>());

            int el = 0;
            if (el > arraylist.Count)
                Console.WriteLine("wrong");
            else
                arraylist.Remove(arraylist[el]);

            Console.WriteLine("Количество: " + arraylist.Count);
            foreach (object obj in arraylist)
            {
                object newobj = obj as Student<int>;
                if (newobj == null)
                    Console.WriteLine(obj);
                else
                    Console.WriteLine($"Student name: {((Student<int>)newobj).Name}");
            }

            Console.WriteLine("=====================================");
            el = 0;
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

            el = 2;
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
            
            long lon = 12222;
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
            var port4 = new Port(5);
            port4[0] = new Ship("ship4.1", 400);
            port4[1] = new Ship("ship4.2", 401);
            port4[2] = new Ship("ship4.3", 402);
            port4[3] = new Ship("ship4.4", 403);
            port4[4] = new Ship("ship4.5", 404);
            listOfMyType.AddRange(new Port[] { port1, port2, port3, port4 });

            foreach (Port obj in listOfMyType)
                obj.Print();
            Console.WriteLine("=====================================");

            Console.WriteLine("Полный размер коллекции: " + listOfMyType.Count);
            
            int ell = 2;
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

            
            string eel = "ship2.1";
            int q = 0;
            foreach(Port port in sortedsetOfMyType)
            {
                q++;
                foreach (Ship ship in port.GetShips())
                    if (eel == ship.VehicleName)
                        Console.WriteLine($"Нашел: {q}-ый элемент, имя {eel}");
            }
            Console.WriteLine("=====================================");

            /*ObservableCollection<List<int>> students = new ObservableCollection<Student<int>>()
            {
                new Student<int>("Pasha"),
                new Student<int>("Kolya"),
                new Student<int>("Vitya")
            };
            students.CollectionChanged += Student<int>.WhenChange;
            students.Add(new Student<int>("Ilya"));
            
            students[1] = new Student<int>("Andrey");
            students.RemoveAt(1);

            Console.WriteLine("Observable collection of students: ");
            foreach(var student in students)
                Console.WriteLine(student.Name);*/


            Console.WriteLine("\n\n");
            ObservableCollection<List<Student<int>>> list = new ObservableCollection<List<Student<int>>>()
            {
                new List<Student<int>>(){ new Student<int>(), new Student<int>()},
                new List<Student<int>>()
            };
            list.CollectionChanged += Student<long>.WhenChange;
            
            list.Add(new List<Student<int>>() { new Student<int>("Masha"), new Student<int>("Olya") });
            list[1].Add(new Student<int>("Ilya"));

            Console.WriteLine("Observable collection of students lists: ");
            foreach (var students in list)
                foreach(Student<int> student in students)
                    Console.WriteLine(student.Name);
        }
    }
}
