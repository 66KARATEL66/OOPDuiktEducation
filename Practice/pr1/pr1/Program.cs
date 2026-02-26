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

            Task3 task3 = new Task3();
            task3.Example();

            Console.WriteLine("\n");

            Task4 task4 = new Task4();
            task4.Example();

            Console.WriteLine("\n");

            Task5 task5 = new Task5();
            task5.Example();

            Console.WriteLine("\n");

            Task6 task6 = new Task6();
            task6.Example();
        }
    }
}