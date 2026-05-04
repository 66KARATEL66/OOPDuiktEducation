using AsyncDataLibrary.Infrastructure;
using AsyncDataLibrary.Interfaces;
using AsyncDataLibrary.Models;
using AsyncDataLibrary.Repositories;
using AsyncDataLibrary.Services;

namespace pr5
{
    internal class Program
    {
        static void Main()
        {
            string userJsonPath = "C:\\Users\\push3\\Documents\\github\\OOPDuiktEducation\\Practice\\pr5\\pr5\\jsonFiles\\user.json";
            string orderJsonPath = "C:\\Users\\push3\\Documents\\github\\OOPDuiktEducation\\Practice\\pr5\\pr5\\jsonFiles\\order.json";
            string bookJsonPath = "C:\\Users\\push3\\Documents\\github\\OOPDuiktEducation\\Practice\\pr5\\pr5\\jsonFiles\\book.json";

            IDataSerializer dataSerializer = new JsonDataSerializer();

            BookService bookService = new BookService(dataSerializer, bookJsonPath);
            OrderService orderService = new OrderService(dataSerializer, orderJsonPath);
            UserService userService = new UserService(dataSerializer, userJsonPath);
        }
    }
}