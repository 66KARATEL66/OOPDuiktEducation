using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task1
{
    internal class Task1
    {
        private TaskService service;
        private ConsoleUI ui;

        public void Run()
        {
            Start();
            ui = new ConsoleUI();

            ShowMenu();
        }

        public void ShowMenu()
        {
            while (true)
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

                int choice = ui.GetChoice(menu.Count, 1);
                menu[choice].Action();
            }
        }

        public void AddTask()
        {
            Console.Clear();
            Console.WriteLine("Enter 0 to return");
            string title = ui.ReadTitle();
            if (title == "0") return;

            bool status = ui.ReadStatus();

            service.Add(title, status);

            Console.WriteLine("Task added. Enter to continue..."); Console.ReadKey(true);
        }

        public void DeleteTask()
        {
            Console.Clear();

            if(service.IsEmpty())
            {
                Console.WriteLine("List is empty. Enter to continue ..."); Console.ReadKey(true);
                return;
            }

            ui.ShowTasks(service.GetAll());
            Console.WriteLine("Enter 0 to return");
            int choice = ui.GetChoice(service.GetAll().Count, 0);

            if (choice == -1) return;

            service.Delete(choice);
            Console.WriteLine("Task deleted. Enter to continue..."); Console.ReadKey(true);
        }

        public void ShowTaskItem()
        {
            Console.Clear();

            if (service.IsEmpty())
            {
                Console.WriteLine("List is empty. Enter to continue ..."); Console.ReadKey(true);
                return;
            }

            ui.ShowTasks(service.GetAll());

            Console.Write("Enter to continue..."); Console.ReadKey(true);
        }

        public void UpdateStatus()
        {
            Console.Clear();

            if (service.IsEmpty())
            {
                Console.WriteLine("List is empty. Enter to continue ..."); Console.ReadKey(true);
                return;
            }

            ui.ShowTasks(service.GetAll());

            Console.WriteLine("Enter 0 to return");
            int choice = ui.GetChoice(service.GetAll().Count, 0);
            if (choice == -1) return;

            bool status = ui.ReadStatus();

            service.UpdateStatus(choice, status);
            Console.WriteLine("Task updated. Tap to continue..."); Console.ReadKey(true);
        }

        public void Start()
        {
            service = new TaskService(JsonHandler.DeserializeJson());
        }

        public void Exit()
        {
            JsonHandler.SerializeJson(service.GetAll());
            Environment.Exit(0);
        }
    }
}
