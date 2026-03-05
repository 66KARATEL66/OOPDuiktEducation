using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Interfaces
{
    public interface ISecurityDevice
    {
        public string Name { get; set; }
        public Guid Id { get; }
        void FreezingWarning();
        void OverheatingWarning();
    }
}
