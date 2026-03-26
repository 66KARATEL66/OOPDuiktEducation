namespace Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Ilya\\Documents\\GitHub\\OOPDuiktEducation\\Practice\\Module\\Module\\files\\textPD25.txt";

            ProcessFile.ProcessFileWithDelegate(filePath, TextOperation.ToUpperCase);
            ProcessFile.ProcessFileWithDelegate(filePath, TextOperation.CharCount);
            ProcessFile.ProcessFileWithDelegate(filePath, TextOperation.WordCount);
        }   
    }   
}