using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8
{
    class CollectionType<T> : IActions<T>// where T : class
    {
        private List<T> collection;

        public CollectionType()
        {
            collection = new List<T>();
        }
        
        public void ShowElementsType()
        {
            if (collection.Count == 0)
                throw new Exception("No elements");
            foreach(T elem in collection)
                Console.WriteLine(elem);
        }
        public void Add(T element) => collection.Add(element);
        public void Remove(T element) => collection.Remove(element);
        public List<T> View() => collection;



        private static string path = @"\file.txt";              // Will be saved on D:\
        public static void OpenFileInf()
        {
            StreamReader streamReader = new StreamReader(path);
            Console.WriteLine(streamReader.ReadToEnd());
            streamReader.Close();
        }

        public static void WriteInFile(T element)
        {
            StreamWriter streamWriter = new StreamWriter(path, true, System.Text.Encoding.Default);
            object obj = element as Vector;
            if (obj != null)
            {
                Vector vector = (Vector)obj;
                streamWriter.WriteLine($"{vector.X}, {vector.Y}, {vector.Z};");
            }
            else
                streamWriter.WriteLine(element);
            streamWriter.Close();
        }
        
        public static void ResetFile()
        {
            StreamWriter streamWriter = new StreamWriter(path, false, System.Text.Encoding.Default);
            streamWriter.WriteLine();
            streamWriter.Close();
        }
    }
}
