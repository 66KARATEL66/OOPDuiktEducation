using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Task3
    {
        public delegate bool FilterPredicate(int x);

        public void Example()
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Task3 task = new Task3();

            FilterArray(array, IsEven);
            FilterArray(array, IsOverFive);
            FilterArray(array, (x) => x % 2 != 0);
        }

        private void FilterArray(int[] numbers, FilterPredicate predicate)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if(predicate(numbers[i]))
                {
                    Console.Write($"{numbers[i]} ");
                }
            }
            Console.WriteLine();
        }

        private bool IsEven(int x)
        {
            return (x % 2 == 0);
        }

        private bool IsOverFive(int x)
        {
            return (x >= 5);
        }
    }
}
