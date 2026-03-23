using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr3
{
    public static class Task4WithoutRecurtion
    {
        private static int filesDeleted = 0;
        private static long filesSize = 0; // bytes

        public static void DeleteCache(string path) // post-order (знизу-вгору)
        {
            Stack<DirectoryInfo> directoryList = new Stack<DirectoryInfo>();
            directoryList.Push(new DirectoryInfo(Path.GetFullPath(path)));


            while (directoryList.Count > 0)
            {
                DirectoryInfo currentDir = directoryList.Pop();

                DirectoryInfo[] subdirs = currentDir.GetDirectories().Where(d => (d.Attributes & FileAttributes.ReparsePoint) == 0).ToArray();

                if(subdirs.Length > 0) // якщо папок в кінцевій папці не знайдено, поточна папка в стек вже не добавляється, після виконання ітерації в стеку її більше не існує, більше з нею не працюємо
                {
                    directoryList.Push(currentDir);

                    foreach (DirectoryInfo subdir in subdirs.Reverse())
                    {
                        directoryList.Push(subdir);
                    }

                    continue;
                }
                
                foreach(FileInfo file in currentDir.GetFiles())
                {
                    filesSize += file.Length;
                    file.Delete();
                    filesDeleted++;
                }

                currentDir.Delete();
            }
        }

        public static void DeleteCacheWithSaveStructure(string path) // pre-order (зверху-вниз)
        {
            Stack<DirectoryInfo> directoryList = new Stack<DirectoryInfo>();
            directoryList.Push(new DirectoryInfo(Path.GetFullPath(path)));

            while (directoryList.Count > 0)
            {
                DirectoryInfo currentDir = directoryList.Pop();

                foreach(DirectoryInfo subdir in currentDir.GetDirectories().Where(d => (d.Attributes & FileAttributes.ReparsePoint) == 0).ToArray())
                {
                    directoryList.Push(subdir);
                }

                foreach (FileInfo file in currentDir.GetFiles())
                {
                    filesSize += file.Length;
                    file.Delete();
                    filesDeleted++;
                }
            }
        }

        public static void ExampleWithoutStructure(string path)
        {
            Console.WriteLine($"Are you sure you want to delete cache: {path}? (yes/no)");
            string input = Console.ReadLine();
            if (input.ToLower() == "yes")
            {
                Console.WriteLine($"Type DELETE to confirm:");
                input = Console.ReadLine();
                if (input == "DELETE")
                {
                    DeleteCache(path);
                }
                else
                    { Console.WriteLine("Operation cancelled."); return; }
            }
            else
                { Console.WriteLine("Operation cancelled."); return; }
            Console.WriteLine($"Cache is cleaned; Files deleted = {filesDeleted}, Deleted files size is {filesSize} bytes");
        }

        public static void ExampleWithStructure(string path)
        {
            Console.WriteLine($"Are you sure you want to delete cache: {path}? (yes/no)");
            string input = Console.ReadLine();
            if (input.ToLower() == "yes")
            {
                Console.WriteLine($"Type DELETE to confirm:");
                input = Console.ReadLine();
                if (input == "DELETE")
                {
                    DeleteCacheWithSaveStructure(path);
                }
                else
                { Console.WriteLine("Operation cancelled."); return; }
            }
            else
            { Console.WriteLine("Operation cancelled."); return; }
            Console.WriteLine($"Cache is cleaned; Files deleted = {filesDeleted}, Deleted files size is {filesSize} bytes");
        }
    }
}
