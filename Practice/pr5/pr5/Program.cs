using AsyncDataLibrary.Infrastructure;
using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Models;
using AsyncDataLibrary.Repositories;
using AsyncDataLibrary.Services;

namespace pr5
{
    internal class Program
    {
        static async Task Main()
        {
            string _basePath = Path.Combine(AppContext.BaseDirectory, "jsonFiles");
            Directory.CreateDirectory(_basePath);


            string userJsonPath = Path.Combine(_basePath, "user.json");
            string orderJsonPath = Path.Combine(_basePath, "order.json");
            string bookJsonPath = Path.Combine(_basePath, "book.json");

            IDataSerializer dataSerializer = new JsonDataSerializer();

            BookService bookService = new BookService(dataSerializer, bookJsonPath);
            OrderService orderService = new OrderService(dataSerializer, orderJsonPath);
            UserService userService = new UserService(dataSerializer, userJsonPath);

            ConsoleApp consoleApp = new ConsoleApp(bookService, orderService, userService);
            await consoleApp.Run();
        }
    }
}