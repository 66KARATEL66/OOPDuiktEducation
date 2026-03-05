using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace pr2.ClimateSettings
{
    public class RoomConfiguration
    {
        public string name { get; set;  }
        public bool isHeatingAllowed { get; set; } = true;
        public ComfortSettings comfortSettings { get; set; } = new();
        public SafetySettings safetySettings { get; set; } = new();
    }
}
