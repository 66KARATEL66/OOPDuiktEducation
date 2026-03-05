using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Systems
{
    public class SecuritySystem
    {
        public int Id;

        public void OverheatingWarning()
        {
            Console.WriteLine("WARNING: Risk of overheating!!!");
        }

        public void FreezingWarning()
        {
            Console.WriteLine("WARNING: Risk of systems freezing!!");
        }
    }
}
