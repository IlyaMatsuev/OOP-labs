using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Vector vector = new Vector(1, 2, 3);
                Vector vector2 = new Vector(4, 5, 6);

                CollectionType<Vector> collectionType = new CollectionType<Vector>();
                collectionType.Add(vector);
                collectionType.Add(vector2);
                foreach(Vector vec in collectionType.View())
                    Vector.showVector(vec);
                collectionType.Remove(vector);
                collectionType.Remove(vector2);
                collectionType.ShowElementsType();
                CollectionType<Vector>.WriteInFile(vector);
                CollectionType<Vector>.WriteInFile(vector2);
            }
            catch(Exception exception)
            {
                Console.WriteLine("=========================");
                Console.WriteLine(exception.Message);
                Console.WriteLine("=========================");
            }
            finally
            {
                Vector vector = new Vector(4, 5, 6);
                CollectionType<Vector> collectionType = new CollectionType<Vector>();
                collectionType.Add(vector);
                collectionType.ShowElementsType();
                CollectionType<Vector>.ResetFile();
                CollectionType<Vector>.WriteInFile(vector);
                CollectionType<Vector>.OpenFileInf();
            }

            try
            {
                CollectionType<int> collectionType = new CollectionType<int>();
                collectionType.Add(5);
                collectionType.Add(33);
                collectionType.Add(8);
                collectionType.ShowElementsType();
            }
            finally
            {
                CollectionType<Vector>.OpenFileInf();
            }
        }
    }
}
