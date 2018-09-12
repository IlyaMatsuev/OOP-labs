using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class lab1
    {
        static void Main(string[] args)
        {
            bool a = true;                              //1 байт
            Console.WriteLine("bool " + a);
            int b = 2;                                  //4 байта, или uint
            Console.WriteLine("int " + b);
            byte c = byte.MaxValue;                     //1 байт, unsigned
            Console.WriteLine("byte " + c);
            sbyte d = sbyte.MinValue;                   //1 байт, signed
            Console.WriteLine("sbyte " + d);
            float e = 123.33f;                          //4, еще есть double, decimal
            Console.WriteLine("float " + e);
            char aa = 'A';
            Console.WriteLine("char " + aa);
            string bb = "Hello";
            Console.WriteLine("str " + bb);
            object n = 12.4;                            //любой тип
            object nn = 1;
            object nnn = "wwww";
            Console.WriteLine("object: " + n + nn + nnn);
            Console.WriteLine("_______________________________________________\n\n");
            for (int i = 0; i < 50; i += 10)
            {
                int num = 50 + i;
                long bigNum = num;
                Console.WriteLine("неявное преобразование " + bigNum);
                char ch = (char)num;
                Console.WriteLine("явное преобразование " + ch);
            }
            Console.WriteLine("_______________________________________________\n\n");
            int q = 123;
            object o = q;     // упаковали
            int j = (int)o;   // распаковали

            short small = 20;
            long big = small;
            big += 10 * short.MaxValue;
            Console.WriteLine("big value " + big);
            Console.WriteLine("_______________________________________________\n\n");
            bool? wat = null;
            Console.WriteLine("null? " + wat);
            Nullable<bool> waaat = false;
            if(waaat.HasValue)
                Console.WriteLine("или так " + waaat.Value);
            Console.WriteLine("_______________________________________________\n\n");
            string who = "ya";
            string iam = "debil";
            string howmuch = "somuch";
            int res = String.Compare(who, iam);
            if(res > 0)
                Console.WriteLine("Вторая строка стоит выше по алфавиту");
            else Console.WriteLine("Первая стрка выше по алфавиту (если бы были одинаковые, было бы 0) ");
            Console.WriteLine("_______________________________________________\n\n");
            string conc = who + iam + howmuch;
            Console.WriteLine(conc);
            string copy = String.Copy(who);
            Console.WriteLine(copy);
            string substr = howmuch;
            string substrres = substr.Substring(2);
            Console.WriteLine(substrres);

            string text = "Вторая строка стоит выше по алфавиту";
            string[] words = text.Split(new char[] { ' ' });
            foreach (string s in words)
                Console.WriteLine(s);

            string text1 = "\n\ngood day";
            string subString = "today ";
            text1 = text1.Insert(5, subString);
            Console.WriteLine(text1);

            text1 = text.Remove(0, 20);
            Console.WriteLine(text1);

            string hidden = null;
            string empty = "";
            string ques = "wat a u say? -";
            if (hidden != empty)
            {
                ques += hidden;
                Console.WriteLine("good");
            }
            else
                Console.WriteLine("bad");
            Console.WriteLine(ques);

            StringBuilder obj = new StringBuilder();
            obj.Append("some new sentense");
            obj.Replace('e', '\a');
            Console.WriteLine(obj);
            obj.Insert(0, '(');
            obj.Insert(obj.Length, ')');
            Console.WriteLine(obj);

            Console.WriteLine("_______________________________________________\n\n");
            int[,] myArr = new int[5, 5];
            Random ran = new Random();
            for (int k = 0; k < 4; k++)
            {
                for (int m = 0; m < 5; m++)
                {
                    myArr[k, m] = ran.Next(0, 10);
                    Console.Write(myArr[k, m] + "\t");
                }
                Console.WriteLine();
            }

            string[] strs = { "wertyui ", "asdfghj ", "zxcvbnm "};
            Console.WriteLine("length: " + strs.Length);
            strs[1] = "hi";
            foreach (string l in strs)
                Console.WriteLine(l);

            float[][] myArr1 = new float[3][];
            Console.WriteLine("Заполните матрицу");
            for (int k = 0; k < 3; k++)
            {
                int l = k + 2;
                myArr1[k] = new float[l];
                for (int z = 0; z < l; z++)
                    myArr1[k][z] = float.Parse((Console.ReadLine()));
            }
            for (int k = 0; k < 3; k++)
            {
                int l = k + 2;
                for (int z = 0; z < l; z++)
                    Console.Write(myArr1[k][z] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");

            var array = new object[0];
            var str = "";
            Console.WriteLine("_______________________________________________\n\n");

            var kortege = (count:1, str1:"hello", ch:'Q', str2:"world", toolong:78998);
            Console.WriteLine(kortege.count);
            Console.WriteLine(kortege.ch);
            Console.WriteLine(kortege.str2);
            int k1 = kortege.count;
            string k2 = kortege.str1;
            string k3 = kortege.str2;
            Console.WriteLine(k1);
            Console.WriteLine(k2);
            Console.WriteLine(k3);

            var newkortege = (4, "olleh", 'M', "dlrow", 89987);
            if (kortege.toolong > newkortege.Item5)
                Console.WriteLine("в первом число больше((");

            var resultOfFunc = localfunc(new int[] { 1, 2, 3, 4 }, "test");
            Console.WriteLine(resultOfFunc.Item1[0]);
            Console.WriteLine(resultOfFunc.Item1[1]);
            Console.WriteLine(resultOfFunc.Item1[2]);
            Console.WriteLine(resultOfFunc.Item2);



        }

        static System.ValueTuple<int[], char> localfunc(int[] numbers, string testStr)
        {
            int max = int.MinValue, min = int.MaxValue, sum = 0;
            foreach(int el in numbers)
            {
                sum += el;
                if (el > max)
                    max = el;
                if (el < min)
                    min = el;
            }
            (int[], char) result = (new int[]{min, max, sum}, testStr[0]);
            return result;
        }
    }
}
