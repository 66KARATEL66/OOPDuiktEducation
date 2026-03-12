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
    public class SecuritySystem : ISecurityDevice
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public SecuritySystemWarning Warning { get; set; }

        public event EventHandler<SecuritySystemEventArgs>? WarningChanged;
        public event EventHandler<SecuritySystemFailureEventArgs>? Broken;

        public SecuritySystem(string name)
        {
            Name = name;
        }

        public void Broke()
        {
            Broken?.Invoke(this, new SecuritySystemFailureEventArgs("Broken"));
        }

        public void OverHeatingWarning()
        {
            Warning = SecuritySystemWarning.OverHeatingWarning;
            WarningChanged?.Invoke(this, new SecuritySystemEventArgs(Warning));
        }

        public void FreezingWarning()
        {
            Warning = SecuritySystemWarning.FreezingWarning;
            WarningChanged?.Invoke(this, new SecuritySystemEventArgs(Warning));
        }

        public void Stop()
        {
            Warning = SecuritySystemWarning.None;
            WarningChanged?.Invoke(this, new SecuritySystemEventArgs(Warning));
        }

        public void SetMode(SecuritySystemWarning warning)
        {
            if (Warning == warning) return;

            switch (warning)
            {
                case SecuritySystemWarning.None: Stop(); break;
                case SecuritySystemWarning.FreezingWarning: FreezingWarning(); break;
                case SecuritySystemWarning.OverHeatingWarning: OverHeatingWarning(); break;
            }
        }
    }
}
