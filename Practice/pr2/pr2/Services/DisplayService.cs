using pr2.Interfaces;
using pr2.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pr2.Enums;
using pr2.Systems.Args;

namespace pr2.Services
{
    public class DisplayService : IDisposable
    {
        private string _roomName;
        private Sensor _sensor;
        private IClimateDevice _climateDevice;
        private ISecurityDevice _securityService;
        private DisplayState _state = new DisplayState();

        public event EventHandler<DisplayEventArgs>? DisplayUpdated;

        public DisplayService(string roomName, Sensor sensor, IClimateDevice climateDevice, ISecurityDevice SecuritySystem)
        {
            _roomName = roomName;
            _sensor = sensor;
            _climateDevice = climateDevice;
            _securityService = SecuritySystem;


            _state.RoomName = roomName;

            _sensor.TemperatureChanged += OnACTemperatureChanged;
            _climateDevice.ModeChanged += OnACModeChanged;
            _climateDevice.Broken += OnACBroken;
            _securityService.WarningChanged += OnSecuritySystemWarningChanged;
            _securityService.Broken += OnSecuritySystemBroken;
        }

        private void OnACTemperatureChanged(object? sender, TemperatureEventArgs e)
        {
            _state.Temperature = e.Temperature;
            NotifyDisplay();
        }

        private void OnACModeChanged(object? sender, AirConditionerEventArgs e)
        {
            _state.AirConditionerMode = e.Mode;
            NotifyDisplay();
        }

        private void OnACBroken(object? sender, AirConditionerFailureEventArgs e)
        {
            _state.AirConditionerFailure = e.Failure;
            NotifyDisplay();
            _state.AirConditionerFailure = null;
        }

        private void OnSecuritySystemWarningChanged(object? sender, SecuritySystemEventArgs e)
        {
            _state.SecuritySystemWarning = e.Warning;
            NotifyDisplay();
        }

        private void OnSecuritySystemBroken(object? sender, SecuritySystemFailureEventArgs e)
        {
            _state.SecuritySystemFailure = e.Failure;
            NotifyDisplay();
            _state.SecuritySystemFailure = null;
        }

        private void NotifyDisplay()
        {
            DisplayUpdated?.Invoke(this, new DisplayEventArgs(_state));
        }

        public void Dispose()
        {
            _sensor.TemperatureChanged -= OnACTemperatureChanged;
            _climateDevice.ModeChanged -= OnACModeChanged;
            _climateDevice.Broken -= OnACBroken;
            _securityService.WarningChanged -= OnSecuritySystemWarningChanged;
            _securityService.Broken -= OnSecuritySystemBroken;
        }
    }
}
