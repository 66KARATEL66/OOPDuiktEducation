using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace Practice
{
    public class Task4
    {
        public Func<double, double, double>? mathOperation;
        public void Example()
        {
            mathOperation = Add;
            Console.WriteLine(mathOperation(5, 3));

            mathOperation = Subtract;
            Console.WriteLine(mathOperation(5, 3));

            mathOperation = Multiply;
            Console.WriteLine(mathOperation(5, 3));

            mathOperation = Divide;
            Console.WriteLine(mathOperation(5, 3));

            List<string> studentNames= new List<string>() { "Ivan", "Max", "David", "Violet", "Vladlena", "Daria", "Shin", "Bertold"};
            char beginLetter = 'M';
            List<string> studentNamesBeginAt = studentNames.FindAll((name) => name[0] == beginLetter);
            studentNamesBeginAt.ForEach((name) => Console.Write($"{name}, "));
            
        }

        private double Add(double a, double b)
        {
            return a + b;
        }

        private double Subtract(double a, double b)
        {
            return a - b;
        }

        private double Multiply(double a, double b)
        {
            return a * b;
        }

        private double Divide(double a, double b)
        {
            return a / b;
        }
    }
}
