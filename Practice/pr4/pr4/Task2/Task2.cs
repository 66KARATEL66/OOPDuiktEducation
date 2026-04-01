using pr4.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task2
{
    internal class Task2
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
                   ("Add", AddStudent),
                   ("DeleteTask", DeleteTask),
                   ("ShowStudents", ShowStudentItem),
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

        public void AddStudent()
        {
            Console.Clear();
            Console.WriteLine("Enter 0 to return");

            string name = ui.ReadName();
            if (name == "0") return;

            int age = ui.ReadAge();

            double averageScore = ui.ReadAverageScore();

            service.Add(name, age, averageScore);

            Console.WriteLine("Task added. Enter to continue..."); Console.ReadKey(true);
        }

        public void DeleteTask()
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

            service.Delete(choice);
            Console.WriteLine("Student deleted. Enter to continue..."); Console.ReadKey(true);
        }

        public void ShowStudentItem()
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
