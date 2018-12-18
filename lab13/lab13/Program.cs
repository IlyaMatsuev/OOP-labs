using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\university\2 curse\ооп\13\";
            Console.WriteLine(MIMDiskInfo.GetDiskInfo());
            MIMLog.Write(MIMDiskInfo.GetDiskInfo());

            Console.WriteLine(MIMFileInfo.GetFileInfo());
            MIMLog.Write(MIMFileInfo.GetFileInfo());
            Console.WriteLine(MIMFileInfo.GetPath());
            MIMLog.Write(MIMFileInfo.GetPath());
            Console.WriteLine(MIMFileInfo.GetTimeCreation());
            MIMLog.Write(MIMFileInfo.GetTimeCreation());

            Console.WriteLine(MIMDirInfo.GetCreationTime());
            MIMLog.Write(MIMDirInfo.GetCreationTime());
            Console.WriteLine(MIMDirInfo.GetDirCount());
            MIMLog.Write(MIMDirInfo.GetDirCount());
            Console.WriteLine(MIMDirInfo.GetFilesCount());
            MIMLog.Write(MIMDirInfo.GetFilesCount());
            Console.WriteLine(MIMDirInfo.GetDirList());
            MIMLog.Write(MIMDirInfo.GetDirList());
            MIMLog.Write("$Session - " + DateTime.Now.Date.ToString() + "$");
            
            MIMFileManager.MoveFiles(path);
            MIMFileManager.MoveDirectoriesByExtension(path, ".js");
            MIMFileManager.ToZip(path);

            Console.WriteLine("======================================");
            Console.WriteLine("============= FROM FILE ==============");
            Console.WriteLine($"============= COUNT: {MIMLog.GetRecordCount()}================");
            Console.WriteLine("======================================\n");
            Console.WriteLine(MIMLog.GetInfoByDay(DateTime.Now.Date));

            MIMLog.Close();

        }
    }
}
