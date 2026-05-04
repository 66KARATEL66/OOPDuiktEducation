using AsyncDataLibrary.Services;
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

        ConsoleOutPut ui;

        public ConsoleApp(BookService bookService, OrderService orderService, UserService userService)
        {
            this.bookService = bookService;
            this.orderService = orderService;
            this.userService = userService;
        }

        public void Run()
        {
            ui = new ConsoleOutPut();

            ShowMenu();
        }

        public void ShowMenu()
        {
            while(true)
            {
                Console.Clear();

                var menu = new List<(string Title, Action Action)>
                {
                    ("Work with Books", ),
                    ("Work with Users", ),
                    ("Work with Orders", )
                }
            }
        }
    }
}
