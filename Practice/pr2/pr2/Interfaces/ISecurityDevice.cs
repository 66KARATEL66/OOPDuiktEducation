using pr2.Enums;
using pr2.Systems.Args;
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
        public SecuritySystemWarning Warning { get; set; }
        void FreezingWarning();
        void OverHeatingWarning();
        void Stop();
        void Broke();
        void SetMode(SecuritySystemWarning warning);

        public event EventHandler<SecuritySystemEventArgs>? WarningChanged;
        public event EventHandler<SecuritySystemFailureEventArgs>? Broken;
    }
}
