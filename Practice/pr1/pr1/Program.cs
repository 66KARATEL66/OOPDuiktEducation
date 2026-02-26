using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Practice
{
    class Program
    {
        static void Main()
        {
            PR1 pr1 = new PR1();
            pr1.Example();

            Console.WriteLine("\n");

            Task2 task2 = new Task2();
            task2.Example();

            Console.WriteLine("\n");
        }
    }
}