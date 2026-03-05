using pr2.ClimateSettings;
using pr2.Interfaces;
using pr2.Services;
using pr2.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Entities
{
    public class Room : IDisposable
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }

        public RoomConfiguration RoomConfiguration { get; set; }
        public IClimateDevice ACDevice;
        public ISecurityDevice SecurityDevice;
        public Sensor Sensor;
        public Display Display;

        private readonly ACService ACService;
        private readonly SecuritySystemService SecuritySystemService;
        private readonly DisplayService DisplayService;

        public Room(string name, RoomConfiguration config)
        {
            Name = name;
            RoomConfiguration = config;
            ACDevice = new AirConditioner($"{Name} AC");
            SecurityDevice = new SecuritySystem($"{Name} Alert");
            Sensor = new Sensor($"{Name} Sensor");
            Display = new Display($"{Name} Alert");

            ACService = new ACService(Sensor, ACDevice, RoomConfiguration);
            SecuritySystemService = new SecuritySystemService(Sensor, SecurityDevice, RoomConfiguration);

            DisplayService = new DisplayService(Name, Sensor, ACDevice, SecuritySystemService, Display);
        }

        public void Dispose()
        {
            ACService.Dispose();
            SecuritySystemService.Dispose();
        }
    }
}
