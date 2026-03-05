using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Interfaces
{
    public interface IClimateDevice
    {
        Guid Id { get; }
        string Name { get; }
        void HeatingOn();
        void CoolingOn();
        void Stop();
    }
}
