using File_Analyzer_CLI;

namespace FileAnalyzerCLI
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Analyzer analyzer = new Analyzer();
            analyzer.ShowReport(args[0]);
        }
    }
}