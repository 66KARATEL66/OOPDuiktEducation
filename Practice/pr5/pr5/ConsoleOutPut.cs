using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr5
{
    public class ConsoleOutPut
    {
        public int GetChoice(int max, int min = 1)
        {
            while (true)
            {
                Console.Write("Enter choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice)
                    && choice >= min
                    && choice <= max)
                {
                    return choice - 1;
                }
            }
        }
    }
}
