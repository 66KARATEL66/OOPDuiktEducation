using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr3
{
    public class Task3
    {
        public FileInfo Search(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetFullPath(path));
            FileInfo fileInfo = null;
            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                FileInfo candidate = Search(directory.FullName);
                if (candidate != null)
                {
                    if (fileInfo == null || candidate.Length > fileInfo.Length)
                        fileInfo = candidate;
                }
            }

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                if (fileInfo == null || file.Length > fileInfo.Length)
                {
                    fileInfo = file;
                }
            }

            return fileInfo;
        }

        public void Example(string path)
        {
            FileInfo largestFile = Search(path);
            Console.WriteLine($"The largest file is {largestFile.Name} {largestFile.Length} bytes, {largestFile.FullName}");
        }
    }
}
