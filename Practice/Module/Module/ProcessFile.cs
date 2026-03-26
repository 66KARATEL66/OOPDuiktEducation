using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public static class ProcessFile
    {
        private static string resultFilePath = "C:\\Users\\Ilya\\Documents\\GitHub\\OOPDuiktEducation\\Practice\\Module\\Module\\files\\resultPD25.txt";
        public static void ProcessFileWithDelegate(string filePath, TextOperation.TextOperationDelegate operation)
        {
            try
            {
                string content = File.ReadAllText(Path.GetFullPath(filePath));
                string result = operation(content);
                File.AppendAllText(resultFilePath, result.ToString() + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file: {ex.Message}");
            }
        }

    }
}
