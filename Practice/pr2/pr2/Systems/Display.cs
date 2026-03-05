using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Systems
{
    public class Display
    {
        public int Id;

        public void ShowTemperature(double temperature)
        {
            Console.WriteLine($"Current temperature is {temperature}°C");
        }
    }
}
