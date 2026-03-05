using pr2.ClimateSettings;
using pr2.Interfaces;
using pr2.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Services
{
    public class SecuritySystemService : IDisposable
    {
        private Sensor _sensor;
        private RoomConfiguration _roomConfiguration;
        private ISecurityDevice _securityDevice;

        public SecuritySystemService(Sensor sensor, ISecurityDevice securityDevice, RoomConfiguration roomConfiguration)
        {
            _sensor = sensor;
            _roomConfiguration = roomConfiguration;
            _securityDevice = securityDevice;

            _sensor.TemperatureChanged += SecuritySystemLogic;
        }

        private void SecuritySystemLogic(object? sender, TemperatureEventArgs e)
        {
            if (e.Temperature < _roomConfiguration.safetySettings._minTemperature) _securityDevice.FreezingWarning();
            else if (e.Temperature > _roomConfiguration.safetySettings._maxTemperature) _securityDevice.OverheatingWarning();
        }

        public void Dispose()
        {
            _sensor.TemperatureChanged -= SecuritySystemLogic;
        }
    }
}
