using pr2.Services;
using pr2.Systems;
using pr2.ClimateSettings;

namespace pr2
{
    class Program
    {
        static void Main(string[] args)
        {
            RoomConfiguration roomConfig = new RoomConfiguration
            {
                name = "Living Room",
                isHeatingAllowed = true,
                comfortSettings = new ComfortSettings(17, 25),
                safetySettings = new SafetySettings(5, 40)
            };

            RoomConfiguration serverConfig = new RoomConfiguration
            {
                name = "Server Room",
                isHeatingAllowed = false,
                comfortSettings = new ComfortSettings(15, 30),
                safetySettings = new SafetySettings(0, 50)
            };

            using RoomService livingRoomOne = new RoomService(new Sensor(), roomConfig);
            using RoomService serverRoomOne = new RoomService(new Sensor(), serverConfig);
            while (true)
            {
                Console.WriteLine("Living room 1:");
                livingRoomOne.GetTemperature();

                Console.WriteLine("\n");

                Console.WriteLine("Server room 2:");
                serverRoomOne.GetTemperature(); 


                Console.WriteLine("\n");
                Console.WriteLine(new string('=', 20));
                Console.WriteLine("\n");
                Task.Delay(3000).Wait();
            }
        }
    }
}