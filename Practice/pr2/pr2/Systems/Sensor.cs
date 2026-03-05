using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Systems
{
    public class Sensor
    {
        public event EventHandler<TemperatureEventArgs> TemperatureChanged;

        public double _temperature { get; set; }
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }

        public Sensor(string name)
        {
            Name = name;
        }

        public void GetTemperature()
        {
            Random random = new Random();
            _temperature = random.Next(-10, 50);
            TemperatureChanged?.Invoke(this, new TemperatureEventArgs(_temperature));
        }
    }

    public class TemperatureEventArgs : EventArgs
    {
        public double Temperature { get; }
        public TemperatureEventArgs(double temperature)
        {
            Temperature = temperature;
        }
    }
}
