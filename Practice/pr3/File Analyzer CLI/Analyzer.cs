using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace File_Analyzer_CLI
{
    public class Analyzer
    {
        private int foldersCount = 0;
        private int filesCount = 0;
        private long filesSize = 0; // bytes

        private FileInfo DirectoryAnalyzer(string path) // звісно трохи порушено правило одна задача -- один метод, але.. але
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetFullPath(path));
            FileInfo fileInfo = null;
            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                FileInfo candidate = DirectoryAnalyzer(directory.FullName);
                if (candidate != null)
                {
                    if (fileInfo == null || candidate.Length > fileInfo.Length)
                        fileInfo = candidate;
                }
            }

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                filesSize += file.Length;
                filesCount++;
                if (fileInfo == null || file.Length > fileInfo.Length)
                {
                    fileInfo = file;
                }
            }

            foldersCount++;

            return fileInfo;
        }

        public void ShowReport(string path)
        {
            FileInfo largestFile = DirectoryAnalyzer(path);
            string largestFileName = largestFile != null ? largestFile.Name : "None";
            Console.WriteLine($"Folders: {foldersCount}\nFiles: {filesCount}\nTotal size: {filesSize}\nLargest file: {largestFileName}");
        }
    }
}
