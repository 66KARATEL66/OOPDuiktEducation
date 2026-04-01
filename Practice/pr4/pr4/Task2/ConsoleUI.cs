using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pr4.Task2
{
    public class ConsoleUI
    {
        
        public string ReadName()
        {
            Console.Write("Enter a student name: ");
            return Console.ReadLine();
        }

        public int ReadAge()
        {
            while(true)
            {
                Console.Write("Enter age: ");
                if (int.TryParse(Console.ReadLine(), out int age)) return age;
            }
        }

        public double ReadAverageScore()
        {
            while (true)
            {
                Console.Write("Enter average score: ");
                if (double.TryParse(Console.ReadLine(), out double averageScore)) return averageScore;
            }
        }

        public void ShowTasks(List<StudentItem> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Student {list[i].Name} is {list[i].Age} years old and has average score - {list[i].AverageScore}");
            }
        }

        public int GetChoice(int max, int min = 1)
        {
            while(true)
            {
                Console.Write("Enter choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice >= max) ;
                {
                    return choice - 1;
                }

            }
        }
    }
}
