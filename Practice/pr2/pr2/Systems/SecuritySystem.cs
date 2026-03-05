using pr2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Systems
{
    public class SecuritySystem : ISecurityDevice
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }

        public SecuritySystem(string name)
        {
            Name = name;
        }

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
