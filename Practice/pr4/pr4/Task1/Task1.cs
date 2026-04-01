using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task1
{
    internal class Task1
    {
        List<TaskItem> taskItem;

        public void Example()
        {
            Start();
            ShowMenu();
        }

        public void AddTask()
        {
            Console.Clear();
            Console.Write("Enter a Title: ");
            string title = Console.ReadLine();
            bool status = GetStatus();

            taskItem.Add(new TaskItem(title, status));

            Console.WriteLine("Task added. Enter to continue..."); Console.ReadKey(true);
        }

        public void DeleteTask()
        {
            Console.Clear();
            ShowTaskItem();
            if(GetChoice(taskItem.Count) == -1) 
            Console.WriteLine("Task deleted. Enter to continue..."); Console.ReadKey(true);
        }

        public void UpdateStatus()
        {
            Console.Clear();
            ShowTaskItem();
            Console.WriteLine("To back enter 0");
            int choice = GetChoice(taskItem.Count, 0);

            if (choice == -1) return;

            taskItem[choice].Update(GetStatus());
            Console.WriteLine("Task updated. Tap to continue..."); Console.ReadKey(true);
        }

        public void ShowMenu()
        {
            while(true)
            {
                Console.Clear();

                var menu = new List<(string Title, Action Action)>
                {
                   ("Add", AddTask),
                   ("DeleteTask", DeleteTask),
                   ("ShowTasks", ShowTaskItem),
                   ("UpdateStatus", UpdateStatus),
                   ("Exit", Exit)
                };

                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i].Title}");
                }

                int choice = GetChoice(menu.Count);
                if (taskItem.Any())
                {
                    menu[choice].Action();
                }
                else
                {

                    if (menu[choice].Action == DeleteTask || menu[choice].Action == UpdateStatus || menu[choice].Action == ShowTaskItem)
                    {
                        Console.Clear();
                        Console.Write("List of Tasks is empty. Tap to continue..."); Console.ReadKey(true);
                    }
                    else
                    {

                        menu[choice].Action();
                    }
                }
            }
        }

        public void ShowTaskItem()
        {
            for (int i = 0; i < taskItem.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {taskItem[i].Title} {(taskItem[i].IsCompleted ? "Completed" : "Uncompleted")}");
                Console.Write("Enter to continue..."); Console.ReadKey(true);
            }
        }

        public int GetChoice(int max, int min = 1)
        {
            while (true)
            {
                Console.Write("Write choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                {
                    return choice - 1;
                }
            }
        }

        public bool GetStatus()
        {
            while(true)
            {
                Console.Write("Write Status (Completed/Uncompleted): ");
                string status = Console.ReadLine();
                if (status == "Completed") return true;
                else if (status == "Uncompleted") return false;
            }
        }

        public void Start()
        {
            taskItem = JsonHandler.DeserializeJson();
        }

        public void Exit()
        {
            JsonHandler.SerializeJson(taskItem);
            Environment.Exit(0);
        }
    }
}
