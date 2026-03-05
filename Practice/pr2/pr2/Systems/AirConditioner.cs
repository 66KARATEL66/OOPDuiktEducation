using pr2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Systems
{
    public class AirConditioner : IClimateDevice
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }

        public AirConditioner(string name) 
        {
            Name = name;
        }

        public void HeatingOn()
        {
            Console.WriteLine("Heating on");
        }

        public void Stop()
        {
            Console.WriteLine("Conditioner off");
        }

        public void CoolingOn()
        {
            Console.WriteLine("Cooling on");
        }
    }
}
