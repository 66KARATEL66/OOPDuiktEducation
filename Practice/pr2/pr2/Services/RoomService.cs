using pr2.ClimateSettings;
using pr2.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Services
{
    public class RoomService : IDisposable
    {
        private Sensor _sensor;
        private RoomConfiguration _roomConfiguration;

        AirConditioner _airConditioner = new AirConditioner();
        SecuritySystem _securitySystem = new SecuritySystem();
        Display _display = new Display();

        public RoomService(Sensor sensor, RoomConfiguration roomConfiguration)
        {
            _sensor = sensor;
            _roomConfiguration = roomConfiguration;
            _sensor.TemperatureChanged += DisplayLogic;
            _sensor.TemperatureChanged += AirConditionerLogic;
            _sensor.TemperatureChanged += SecuritySystemLogic;
        }

        public void GetTemperature()
        {
            _sensor.GetTemperature();

        }

        private void AirConditionerLogic(object? sender, TemperatureEventArgs e)
        {
            if (e.Temperature < _roomConfiguration.comfortSettings._minTemperature && _roomConfiguration.isHeatingAllowed) _airConditioner.HeatingOn();
            else if (e.Temperature > _roomConfiguration.comfortSettings._maxTemperature) _airConditioner.CoolingOn();
            else _airConditioner.ConditionerOff();
        }

        private void SecuritySystemLogic(object? sender, TemperatureEventArgs e)
        {
            if (e.Temperature < _roomConfiguration.safetySettings._minTemperature) _securitySystem.FreezingWarning();
            else if (e.Temperature > _roomConfiguration.safetySettings._maxTemperature) _securitySystem.OverheatingWarning();
        }

        private void DisplayLogic(object? sender, TemperatureEventArgs e)
        {
            _display.ShowTemperature(e.Temperature);
        }

        public void Dispose()
        {
            _sensor.TemperatureChanged -= DisplayLogic;
            _sensor.TemperatureChanged -= AirConditionerLogic;
            _sensor.TemperatureChanged -= SecuritySystemLogic;
        }
    }
}
