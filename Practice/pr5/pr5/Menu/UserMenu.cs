using AsyncDataLibrary.Models;
using AsyncDataLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5.Menu
{
    public class UserMenu
    {
        ConsoleOutPut ui;
        UserService service;
        bool isExit = false;

        public UserMenu(ConsoleOutPut ui, UserService service)
        {
            this.ui = ui;
            this.service = service;
        }

        public async Task Show()
        {
            while (true)
            {
                Console.Clear();

                var menu = new List<(string Title, Func<Task> Action)>
                {
                    ("Get All", ShowList),
                    ("Add User", AddAsync),
                    ("Delete User", DeleteAsync),
                    ("Exit", () => {ExitAsync(); return Task.CompletedTask; })
                };

                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i].Title}");
                }

                int choice = ui.GetChoice(menu.Count, 1);
                await menu[choice].Action();

                if (isExit)
                {
                    isExit = false;
                    return;
                }
            }
        }

        public async Task ShowList()
        {
            await GetAllAsync();
            Console.Write("Enter to continue..."); Console.ReadKey();
        }

        public async Task GetAllAsync()
        {
            Console.Clear();
            var data = (await service.GetAll()).ToList();

            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine($"{i + 1}. User name: {data[i].username}; Email: {data[i].email}");

            }
        }

        public async Task AddAsync()
        {
            string username;
            string email;
            string password;

            while(true)
            {
                Console.Clear();
                Console.Write("Enter a username name: "); username = Console.ReadLine() ?? "";
                Console.Write("Enter a email name: "); email = Console.ReadLine() ?? "";
                Console.Write("Enter a password name: "); password = Console.ReadLine() ?? "";

                var result = await service.Add(username, password, email);
                if(isSuccess(result))
                {
                    return;
                }
            }
        }

        public async Task DeleteAsync()
        {
            Console.Clear();
            await GetAllAsync();

            var data = (await service.GetAll()).ToList();

            int choice = ui.GetChoice(data.Count, 1);
            var result = await service.Delete(data[choice].id);
            isSuccess(result);
        }

        public Task ExitAsync()
        {
            isExit = true;
            return Task.CompletedTask;
        }

        public bool isSuccess(Result result)
        {
            if (result.IsSuccess)
            {
                Console.WriteLine("Operation Success");
                Console.Write("Enter to continue..."); Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("Failure: " + result.Error);
                Console.Write("Enter to continue..."); Console.ReadKey();
                return false;
            }
        }
    }
}
