using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.ClimateSettings
{
    public class ComfortSettings
    {
        public double _minTemperature;
        public double _maxTemperature;

        public ComfortSettings(double minTemperature = 18, double maxTemperature = 25)
        {
            _minTemperature = minTemperature;
            _maxTemperature = maxTemperature;
        }
    }
}
