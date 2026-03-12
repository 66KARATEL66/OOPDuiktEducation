using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Enums
{
    public class DisplayState
    {
        public double Temperature { get; set; }
        public AirConditionerMode AirConditionerMode { get; set; }
        public string AirConditionerFailure {  get; set; }
        public SecuritySystemWarning SecuritySystemWarning { get; set; }
        public string SecuritySystemFailure { get; set; }
        public string RoomName { get; set; }
    }
}
