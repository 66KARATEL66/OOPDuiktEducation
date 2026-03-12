using pr2.Enums;
using pr2.Interfaces;
using pr2.Systems.Args;
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

        public AirConditionerMode AirConditionerMode { get; set; } = AirConditionerMode.Off;

        public event EventHandler<AirConditionerEventArgs>? ModeChanged;
        public event EventHandler<AirConditionerFailureEventArgs>? Broken;

        public AirConditioner(string name) 
        {
            Name = name;
        }

        public void HeatingOn()
        {
            AirConditionerMode = AirConditionerMode.Heating;
            ModeChanged?.Invoke(this, new AirConditionerEventArgs(AirConditionerMode));
        }

        public void Stop()
        {
            AirConditionerMode = AirConditionerMode.Off;
            ModeChanged?.Invoke(this, new AirConditionerEventArgs(AirConditionerMode));
        }

        public void CoolingOn()
        {
            AirConditionerMode = AirConditionerMode.Cooling;
            ModeChanged?.Invoke(this, new AirConditionerEventArgs(AirConditionerMode));
        }

        public void Broke()
        {
            Broken?.Invoke(this, new AirConditionerFailureEventArgs("Broken"));
        }

        public void SetMode(AirConditionerMode mode)
        {
            if (AirConditionerMode == mode) return; // is active in mode
            
            switch(mode)
            {
                case AirConditionerMode.Off:
                    Stop();
                    break;
                case AirConditionerMode.Heating:
                    HeatingOn();
                    break;
                case AirConditionerMode.Cooling:
                    CoolingOn();
                    break;
            }
        }
    }
}
