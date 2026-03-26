using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public static class ProcessFile
    {
        private static string resultFilePath = "..\\..\\..\\files\\resultPD25.txt";
        public static void ProcessFileWithDelegate<T>(string filePath, TextOperation.TextOperationDelegate<T> operation)
        {
            try
            {
                string content = File.ReadAllText(Path.GetFullPath(filePath));
                T result = operation(content);
                File.AppendAllText(resultFilePath, result.ToString() + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing file: {ex.Message}");
            }
        }

    }
}
