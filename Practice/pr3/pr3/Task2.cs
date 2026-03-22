using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr3
{
    public class Task2
    {
        public void Inspector(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetFullPath(path));
            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                Inspector(directory.FullName);
            }

            Console.WriteLine(directoryInfo.FullName + ": ");

            foreach (DirectoryInfo directories in directoryInfo.GetDirectories())
            {
                Console.WriteLine($"\t{directories.Name} folder");
            }

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                Console.WriteLine($"\t{file.Name}: {file.Length} bytes, created at {file.CreationTime}");
            }

            Console.WriteLine();
        }
    }
}
