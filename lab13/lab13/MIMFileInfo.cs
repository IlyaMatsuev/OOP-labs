using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public static class MIMFileInfo
    {
        private const string path = @"D:\university\2 curse\ооп\13\mimlogfile.txt";
        private static FileInfo fi;

        static MIMFileInfo() => fi = new FileInfo(path);

        public static string GetPath() => "Dir name " + fi.DirectoryName + '\n';

        public static string GetFileInfo()
        {
            string res = "";
            res += "Space " + fi.Length + '\n';
            res += "Extension " + fi.Extension + '\n';
            res += "Name " + fi.Name + "\n\n";
            return res;
        }

        public static string GetTimeCreation() => "Time creation " + fi.CreationTime.ToString() + "\n\n";
    }
}
