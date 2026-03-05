using pr2.Interfaces;
using pr2.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Services
{
    public class DisplayService
    {
        private string _roomName;
        private Sensor _sensor;
        private IClimateDevice _climateDevice;
        private SecuritySystemService _securityService;
        private Display _display;

        public DisplayService(string roomName, Sensor sensor, IClimateDevice climateDevice, SecuritySystemService securityService, Display display)
        {
            _roomName = roomName;
            _sensor = sensor;
            _climateDevice = climateDevice;
            _securityService = securityService;
            _display = display;

            _sensor.TemperatureChanged += Show;
        }

        public void Show(object? sender, TemperatureEventArgs e)
        {
            /*Console.WriteLine($"{_roomName}:\nTemperature: {e.Temperature}\n");*/
        }
    }
}
