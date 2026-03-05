using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.ClimateSettings
{
    public class SafetySettings
    {
        public double _minTemperature;
        public double _maxTemperature;

        public SafetySettings(double minTemperature = 5, double maxTemperature = 40)
        {
            _minTemperature = minTemperature;
            _maxTemperature = maxTemperature;
        }
    }
}
