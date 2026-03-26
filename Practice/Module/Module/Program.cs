namespace Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "..\\..\\..\\files\\textPD25.txt";

            ProcessFile.ProcessFileWithDelegate(filePath, TextOperation.ToUpperCase);
            ProcessFile.ProcessFileWithDelegate(filePath, TextOperation.CharCount);
            ProcessFile.ProcessFileWithDelegate(filePath, TextOperation.WordCount);
        }   
    }   
}