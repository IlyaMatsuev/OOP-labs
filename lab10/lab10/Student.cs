using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class Student<T> : INotifyPropertyChanged
    {
        public Student(string Name) { name = Name; OnPropertyChanged(name); }
        public Student() { name = "Ilya"; OnPropertyChanged(name); }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(name); }
        }
        public static List<T> genericlist = new List<T>();
        public static SortedSet<T> sortedset = new SortedSet<T>();

        public static void WhenChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    List<Student<int>> newStudents = e.NewItems[0] as List<Student<int>>;
                    Console.WriteLine("Добавлен новый лист: ");
                    foreach (var stud in newStudents)
                        Console.WriteLine(stud.Name);
                    break;
                /*case NotifyCollectionChangedAction.Remove:
                    Student<T> oldStudent = e.OldItems[0] as Student<T>;
                    Console.WriteLine("Удален объект: {0}", oldStudent.Name);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Student<T> replacedStudent = e.OldItems[0] as Student<T>;
                    Student<T> replacingStudent = e.NewItems[0] as Student<T>;
                    Console.WriteLine("Объект {0} заменен объектом {1}", replacedStudent.Name, replacingStudent.Name);
                    break;*/
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            Console.WriteLine("New element: " + propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
