using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public static class MIMFileManager
    {
        public static void MoveFiles(string path)
        {
            if (!Directory.Exists(path))
                return;
            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            string generalPath = path;
            path += @"MIMInspect\";
            Directory.CreateDirectory(path);
            path += @"mimdirinfo.txt";
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
            {
                sw.WriteLine("Directories: ");
                foreach (var s in dirs)
                    sw.WriteLine(s);
                sw.WriteLine("Files: ");
                foreach (var s in files)
                    sw.WriteLine(s);
            }
            generalPath += @"newName.txt";
            if(File.Exists(generalPath))
                File.Delete(generalPath);

            File.Copy(path, generalPath);
            File.Delete(path);
        }

        public static void MoveDirectoriesByExtension(string path, string extension)
        {
            if (!Directory.Exists(path))
                return;

            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles().Where(s => s.Extension == extension).ToArray();
            string generalPath = path;
            path += @"MIMFiles\";
            Directory.CreateDirectory(path);
            foreach (var f in files)
            {
                if (File.Exists(path))
                    File.Delete(path);
                File.Move(f.FullName, path + f.Name);
            }
            generalPath += @"MIMInspect\MIMFiles\";
            if (Directory.Exists(generalPath))
                Directory.Delete(generalPath, true);
            Directory.Move(path, generalPath);
        }

        public static void ToZip(string path)
        {
            string generalPath = path + @"MIMInspect\MIMFiles\";
            DirectoryInfo directory = new DirectoryInfo(generalPath);
            var files = directory.GetFiles();
            path += @"MIMFiles.zip";
            using (System.IO.FileStream zipToOpen = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    foreach(var f in files)
                        archive.CreateEntryFromFile(f.FullName, f.Name);
                }
            }
        }
    }
}
