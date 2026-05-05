using AsyncDataLibrary.Models;
using AsyncDataLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5.Menu
{
    public class OrderMenu
    {
        ConsoleOutPut ui;
        UserService userService;
        BookService bookService;
        OrderService orderService;
        bool isExit = false;

        public OrderMenu(ConsoleOutPut ui, UserService userService, BookService bookService, OrderService orderService)
        {
            this.ui = ui;
            this.userService = userService;
            this.bookService = bookService;
            this.orderService = orderService;
        }

        public async Task Show()
        {
            while (true)
            {
                Console.Clear();

                var menu = new List<(string Title, Func<Task> Action)>
                {
                    ("Make Order", MakeOrderAsync),
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

        public async Task GetAllBookAsync()
        {
            Console.Clear();
            var data = (await bookService.GetAll()).ToList();

            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Book name {data[i].name} by Author {data[i].author}");
            }
        }

        public async Task MakeOrderAsync()
        {
            Console.Clear();
            await GetAllBookAsync();
            var bookData = (await bookService.GetAll()).ToList();
            var userData = (await userService.GetAll()).ToList();

            Console.Write("Choose Book to order.");
            int choice = ui.GetChoice(bookData.Count, 1);
            var result = await orderService.Add(bookData[choice], userData[Random.Shared.Next(0, userData.Count)]);
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
