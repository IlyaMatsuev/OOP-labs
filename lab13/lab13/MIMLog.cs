using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public static class MIMLog
    {
        private const string path = @"D:\university\2 curse\ооп\13\mimlogfile.txt";
        private static StreamWriter fw;

        static MIMLog()
        {
            fw = new StreamWriter(path, true, Encoding.Default);
        }

        public static void Write(string str) => fw.WriteLine(str);
        public static string GetInfoByDay(DateTime date)
        {
            fw.Close();
            string res = "";
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                const string sessionKeyWord = "Session - ";
                string[] infos = sr.ReadToEnd().Split('$');
                if (infos.Count() == 0)
                    return null;
                int strCount = -1;
                int prevStrIndex = -1;
                foreach (var s in infos)
                {
                    strCount++;
                    int isExist = s.IndexOf(sessionKeyWord);
                    if (isExist == -1)
                    {
                        prevStrIndex = strCount;
                        continue;
                    }
                    string sessionTime = "";
                    for(int i = isExist + sessionKeyWord.Length; i < s.Length;i++)
                        sessionTime += s[i];

                    DateTime sessTime = Convert.ToDateTime(sessionTime);
                    if(sessTime == date)
                        res += infos[prevStrIndex] + "\n\n";
                }
            }
            fw = new StreamWriter(path, true, Encoding.Default);
            return res;
        }

        public static int GetRecordCount()
        {
            fw.Close();
            int res = 0;
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                 res = sr.ReadToEnd().Split('$').Where(s => s.StartsWith("Session") == false).Count();
            }
            fw = new StreamWriter(path, true, Encoding.Default);
            return res;
        }


        public static void Close()
        {
            fw.Close();
        }
    }
}
