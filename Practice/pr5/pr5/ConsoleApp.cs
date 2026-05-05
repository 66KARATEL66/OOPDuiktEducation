using AsyncDataLibrary.Services;
using pr5.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5
{
    public class ConsoleApp
    {
        BookService bookService;
        OrderService orderService;
        UserService userService;

        BookMenu bookMenu;
        OrderMenu orderMenu;
        UserMenu userMenu;

        ConsoleOutPut ui;

        bool isExit = false;

        public ConsoleApp(BookService bookService, OrderService orderService, UserService userService)
        {
            ui = new ConsoleOutPut();

            this.bookService = bookService;
            this.orderService = orderService;
            this.userService = userService;

            bookMenu = new BookMenu(ui, this.bookService);
            orderMenu = new OrderMenu(ui, this.userService, this.bookService, this.orderService);
            userMenu = new UserMenu(ui, this.userService);
        }

        public async Task Run()
        {
            await ShowMenu();
        }

        public async Task ShowMenu()
        {
            while(!isExit)
            {
                Console.Clear();

                var menu = new List<(string Title, Func<Task> Action)>
                {
                    ("Work with Books", ShowBookMenu),
                    ("Work with Users", ShowUsersMenu),
                    ("Work with Orders", ShowOrderMenu),
                    ("Exit", () => {Exit(); return Task.CompletedTask; })
                };

                for(int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {menu[i].Title}");
                }

                int choice = ui.GetChoice(menu.Count, 1);
                await menu[choice].Action();
            }
        }

        public async Task ShowBookMenu()
        {
            await bookMenu.Show();
        }

        public async Task ShowUsersMenu()
        {
            await userMenu.Show();
        }

        public async Task ShowOrderMenu()
        {
            await orderMenu.Show();
        }

        public Task Exit()
        {
            isExit = true;
            return Task.CompletedTask;
        }
    }
}
