using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr3
{
    public static class Task4
    {
        private static int filesDeleted = 0;
        private static long filesSize = 0; // bytes

        public static void Search(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetFullPath(path));
            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                if ((directory.Attributes & FileAttributes.ReparsePoint) != 0)
                {
                    continue;
                }
                Search(directory.FullName);
            }

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                filesSize += file.Length;
                file.Delete();
                filesDeleted++;
            }

            directoryInfo.Delete();
        }

        public static void Example(string path)
        {
            Console.WriteLine($"Are you sure you want to delete cache: {path}? (yes/no)");
            string input = Console.ReadLine();
            if (input.ToLower() == "yes")
            {
                Console.WriteLine($"Type DELETE to confirm:");
                input = Console.ReadLine();
                if (input == "DELETE")
                {
                    Search(path);
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
