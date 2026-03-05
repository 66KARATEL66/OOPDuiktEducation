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
    public class ACService : IDisposable
    {
        private Sensor _sensor;
        private RoomConfiguration _roomConfiguration;
        private IClimateDevice _airConditioner;

        public ACService(Sensor sensor, IClimateDevice climateDevice, RoomConfiguration roomConfiguration)
        {
            _sensor = sensor;
            _roomConfiguration = roomConfiguration;
            _airConditioner = climateDevice;

            _sensor.TemperatureChanged += AirConditionerLogic;
        }

        private void AirConditionerLogic(object? sender, TemperatureEventArgs e)
        {
            if (e.Temperature < _roomConfiguration.comfortSettings._minTemperature && _roomConfiguration.isHeatingAllowed) _airConditioner.HeatingOn();
            else if (e.Temperature > _roomConfiguration.comfortSettings._maxTemperature) _airConditioner.CoolingOn();
            else _airConditioner.Stop();
        }

        public void Dispose()
        {
            _sensor.TemperatureChanged -= AirConditionerLogic;
        }
    }
}
