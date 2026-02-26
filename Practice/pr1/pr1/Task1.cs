using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Practice
{
    public class Task1
    {
        public delegate double MathOperation(double a, double b);
        public void Example()
        {
            MathOperation mathOperation = Add;
            Console.WriteLine(mathOperation(5, 3));

            mathOperation = Subtract;
            Console.WriteLine(mathOperation(5, 3));

            mathOperation = Multiply;
            Console.WriteLine(mathOperation(5, 3));

            mathOperation = Divide;
            Console.WriteLine(mathOperation(5, 3));
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
