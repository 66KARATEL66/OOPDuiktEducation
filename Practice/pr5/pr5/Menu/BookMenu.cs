using AsyncDataLibrary.Models;
using AsyncDataLibrary.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5.Menu
{
    public class BookMenu
    {
        ConsoleOutPut ui;
        BookService service;
        bool isExit = false;

        public BookMenu(ConsoleOutPut ui, BookService service)
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
                    ("Add book", AddAsync),
                    ("Delete book", DeleteAsync),
                    ("Exit", () => {ExitAsync(); return Task.CompletedTask; })
                };

                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i].Title}");
                }

                int choice = ui.GetChoice(menu.Count, 1);
                await menu[choice].Action();

                if(isExit)
                {
                    isExit = false;
                    return;
                }
            }
        }

        public async Task GetAllAsync()
        {
            Console.Clear();
            var data = (await service.GetAll()).ToList();

            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Book name {data[i].name} by Author {data[i].author}");
            }

        }

        public async Task ShowList()
        {
            Console.Clear();
            await GetAllAsync();

            Console.Write("Enter to continue..."); Console.ReadKey();
        }

        public async Task AddAsync()
        {
            Console.Clear();
            string bookName;
            string authorName;


            Console.Write("Enter a Book name: "); bookName = Console.ReadLine() ?? "";
            Console.Write("Enter a Author name: "); authorName = Console.ReadLine() ?? "";

            var result = await service.Add(bookName, authorName);
            isSuccess(result);
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

        public void isSuccess(Result result)
        {
            if (result.IsSuccess)
            {
                Console.WriteLine("Operation Success");
                Console.Write("Enter to continue..."); Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Failure: " + result.Error);
                Console.Write("Enter to continue..."); Console.ReadKey();
                return;
            }
        }
    }
}
