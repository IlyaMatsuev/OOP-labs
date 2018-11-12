using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB9
{
    class User
    {
        public delegate void Replace(int offset);
        public event Replace replaceEvent;

        public delegate void Сompression(int comprCoef);
        public event Сompression compressionEvent;

        public void replOrCompr(bool ques, int coef)
        {
            if(ques)
                replaceEvent(coef);
            else
                compressionEvent(coef);
        }


        public static string RemoveCommasDotes(string str)
        {
            string result = "";
            foreach(char ch in str)
            {
                if (ch == ',' || ch == '.')
                    continue;
                result += ch;
            }
            return result;
        }

        public static string AddSymbols(string str)
        {
            string result = "!";
            result = result + str + result;
            return result;
        }

        public static string ToUpperCase(string str) => str.ToUpper();
        public static string RemoveSpaces(string str)
        {
            string result = "";
            foreach(char ch in str)
            {
                if (ch == ' ')
                    continue;
                result += ch;
            }
            return result;
        }

        public static string AfterFirstWord(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
                if (str[i] == ' ')
                {
                    result = str.Substring(i);
                    break;
                }
            return result;
        }

        public static string ToBinary(string str)
        {
            string result = "";
            foreach(byte ch in str)
                result += Convert.ToString(ch, 2);
            return result;
        }
    }
}
