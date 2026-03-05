using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Systems
{
    public class Display
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }

        public Display(string name)
        {
            Name = name;
        }

        public void ShowTemperature(double temperature)
        {
            Console.WriteLine($"Current temperature is {temperature}°C");
        }
    }
}
