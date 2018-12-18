using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public static class MIMDirInfo
    {
        private const string path = @"D:\university\2 curse\ооп\13\";
        private static DirectoryInfo di;

        static MIMDirInfo() => di = new DirectoryInfo(path);

        public static string GetFilesCount() => "Files " + Directory.GetFiles(path).Count().ToString() + "\n";
        public static string GetCreationTime() => "Dir creation time " + di.CreationTime.ToString() + "\n";
        public static string GetDirCount() => "Dir " + Directory.GetDirectories(path).Count().ToString() + "\n";
        public static string GetDirList()
        {
            DirectoryInfo directory = di.Parent;
            string res = "Parent dir ";
            while(directory.Name != di.Root.ToString())
            {
                res += directory.Name + '\n';
                directory = directory.Parent;
            }
            res += directory.Name + '\n';
            return res + '\n';
        }
    }
}
