using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr3
{
    public class Task1
    {
        string storyPath = "C:\\Users\\push3\\Documents\\github\\OOPDuiktEducation\\Practice\\pr3\\pr3\\story.txt";
        string reportPath = "C:\\Users\\push3\\Documents\\github\\OOPDuiktEducation\\Practice\\pr3\\pr3\\report.txt";

        List<string> strings = new List<string>();
        List<char> chars = new List<char>();
        string text;

        public int stringCount;
        public int charCount;
        public int wordsCount;

        public void ReadStoryFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(storyPath))
                {
                    text = sr.ReadToEnd();

                    sr.DiscardBufferedData();
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);

                    while(true)
                    {
                        string str = sr.ReadLine();
                        if(str != null)
                        {
                            strings.Add(str);
                        }
                        else break;
                    }

                    sr.DiscardBufferedData();
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);

                    while (true)
                    {
                        int _char = sr.Read();

                        if (_char != -1)
                        {
                            chars.Add((char)_char);
                        }
                        else break;
                    }
                }
            }

            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void WriteReportFile()
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(reportPath))
                {
                    sr.WriteLine("Number of lines: " +  stringCount);
                    sr.WriteLine("Number of chars: " + charCount);
                    sr.WriteLine("Number of words: " + wordsCount);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void ShowReport()
        {
            try
            {
                using (StreamReader sr = new StreamReader(reportPath))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An I/O error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void Example()
        {
            ReadStoryFile();

            stringCount = strings.Count;
            charCount = chars.Count;
            wordsCount = text.Split(' ').Length;

            WriteReportFile();
            ShowReport();
        }
    }
}
