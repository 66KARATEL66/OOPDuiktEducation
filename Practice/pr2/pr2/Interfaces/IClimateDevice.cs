using pr2.Enums;
using pr2.Systems.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Interfaces
{
    public interface IClimateDevice
    {
        AirConditionerMode AirConditionerMode { get; set; }
        Guid Id { get; }
        string Name { get; set; }
        void HeatingOn();
        void CoolingOn();
        void Stop();
        void Broke();
        void SetMode(AirConditionerMode mode);

        event EventHandler<AirConditionerEventArgs> ModeChanged;
        event EventHandler<AirConditionerFailureEventArgs> Broken;
    }
}
