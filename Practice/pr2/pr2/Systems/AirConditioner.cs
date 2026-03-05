using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Systems
{
    public class AirConditioner
    {
        public int Id;

        public void HeatingOn()
        {
            Console.WriteLine("Heating on");
        }

        public void ConditionerOff()
        {
            Console.WriteLine("Conditioner off");
        }

        public void CoolingOn()
        {
            Console.WriteLine("Cooling on");
        }
    }
}
