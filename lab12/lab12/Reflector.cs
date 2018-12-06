using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public class Reflector
    {
        public const string FilePath = @"D:\university\2 curse\ооп\ClassInfo.txt";

        public static void WriteClassToFile(string className)
        {
            Type type = Type.GetType(className, false, true);
            if(type == null)
            {
                Console.WriteLine("Такого типа не найдено");
                return;
            }
            using (StreamWriter sw = new StreamWriter(FilePath, false, Encoding.Default))
            {
                sw.WriteLine("Namespace.ClassName: " + className);
                sw.WriteLine("Its constructors: ");
                foreach (var constr in type.GetConstructors())
                    sw.WriteLine("\t" + constr.Name);
                sw.WriteLine("Its fields: ");
                foreach(var filds in type.GetFields())
                    sw.WriteLine("\t" + filds.Name);
                sw.WriteLine("Its properties: ");
                foreach (var prop in type.GetProperties())
                    sw.WriteLine("\t" + prop.Name);
                sw.WriteLine("Methods which it uses: ");
                foreach (var methods in type.GetMethods())
                    sw.WriteLine("\t" + methods.Name);

                sw.Write("parameters\t");
                sw.WriteLine("890 somestring");
            }
        }

        public static MethodInfo[] GetMethods(string className)
        {
            Type type = Type.GetType(className, false, true);
            if(type == null)
            {
                Console.WriteLine("Такого типа не найдено");
                return null;
            }
            return type.GetMethods();
        }

        public static List<MemberInfo[]> GetFieldsAndProp(string className)
        {
            Type type = Type.GetType(className, false, true);
            if (type == null)
            {
                Console.WriteLine("Такого типа не найдено");
                return null;
            }
            var properties = type.GetProperties();
            var fields = type.GetFields();
            List<MemberInfo[]> members = new List<MemberInfo[]> { properties, fields};
            return members;
        }

        public static Type[] GetInterface(string className)
        {
            Type type = Type.GetType(className, false, true);
            if (type == null)
            {
                Console.WriteLine("Такого типа не найдено");
                return null;
            }
            return type.GetInterfaces();
        }

        public static void PrintMethodByName(string className, Type parameterType)
        {
            Type type = Type.GetType(className, false, true);
            if (type == null)
            {
                Console.WriteLine("Такого типа не найдено");
                return;
            }
            var methods = type.GetMethods();
            var result = methods.Where(a => a.GetParameters().Where(t => t.ParameterType == parameterType).Count() != 0);
            Console.WriteLine($"Все методы, содержащие заданный параметр {parameterType.Name}: ");
            foreach (var el in result)
                Console.WriteLine(el.Name);
        }

        public static void ExecuteMethod(string className, string methodName)
        {
            Type type = Type.GetType(className, false, true);
            if (type == null)
            {
                Console.WriteLine("Такого типа не найдено");
                return;
            }
            string fileinf = "";
            string parameters = "parameters";
            using (StreamReader sr = new StreamReader(FilePath, Encoding.Default))
            {
                fileinf = sr.ReadToEnd();
            }
            if(fileinf.IndexOf(methodName) == -1)
            {
                Console.WriteLine("Такого метода нет в файле");
                return;
            }
            int param = fileinf.IndexOf(parameters);
            List<string> paramlist = new List<string>();
            if (param == -1)
                Console.WriteLine("Параметров для вызова функции нет");
            else
            {
                string currentParam = "";
                for (int i = param + parameters.Length + 1; i < fileinf.Length; i++)
                {
                    if(fileinf[i] == ' ' || fileinf[i] == '\n')
                    {
                        paramlist.Add(currentParam);
                        currentParam = "";
                    }
                    else
                        currentParam += fileinf[i];
                }
            }
            var method = type.GetMethod(methodName);
            var methodParams = method.GetParameters();
            int intParam;
            int.TryParse(paramlist.First(), out intParam);
            string strParam = paramlist.Last();
            object obj = Activator.CreateInstance(type);
            if(paramlist.Count() != 0)
                method.Invoke(obj, new object[] { intParam, strParam });
            else
                method.Invoke(obj, new object[] { });
        }
    }
}
