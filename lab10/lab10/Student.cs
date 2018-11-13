using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class Student<T>
    {
        public Student(string Name)
        {
            this.Name = Name;
        }
        public Student() { Name = "Ilya"; }

        public string Name { get; set; }
        public static List<T> genericlist = new List<T>();
        public static SortedSet<T> sortedset = new SortedSet<T>();

        public static void WhenChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Student<T> newStudent = e.NewItems[0] as Student<T>;
                    Console.WriteLine("Добавлен новый объект: {0}", newStudent.Name);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Student<T> oldStudent = e.OldItems[0] as Student<T>;
                    Console.WriteLine("Удален объект: {0}", oldStudent.Name);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Student<T> replacedStudent = e.OldItems[0] as Student<T>;
                    Student<T> replacingStudent = e.NewItems[0] as Student<T>;
                    Console.WriteLine("Объект {0} заменен объектом {1}", replacedStudent.Name, replacingStudent.Name);
                    break;
            }
        }
    }
}
