using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace pr4.Task1
{
    public class ConsoleUI
    {
        
        public string ReadTitle()
        {
            Console.Write("Enter a title: ");
            return Console.ReadLine();
        }

        public bool ReadStatus()
        {
            while(true)
            {
                Console.Write("Enter a status(Completed/Uncompleted: ");
                string status = Console.ReadLine();

                if (status == "Completed") return true;
                if (status == "Uncompleted") return false;
            }
        }

        public void ShowTasks(List<TaskItem> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {list[i].Title} {(list[i].IsCompleted ? "Completed" : "Uncompleted")}");
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
