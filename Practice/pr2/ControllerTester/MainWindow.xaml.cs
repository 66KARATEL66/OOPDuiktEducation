using pr2.ClimateSettings;
using pr2.Entities;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControllerTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Room livingRoomOne;
        Room serverRoomOne;

        public MainWindow()
        {
            InitializeComponent();

            // Створюємо кімнати із конфігураціями
            var livingRoomConfig = new RoomConfiguration
            {
                name = "Living Room",
                isHeatingAllowed = true,
                comfortSettings = new ComfortSettings(17, 25),
                safetySettings = new SafetySettings(5, 40)
            };

            var serverRoomConfig = new RoomConfiguration
            {
                name = "Server Room",
                isHeatingAllowed = false,
                comfortSettings = new ComfortSettings(15, 30),
                safetySettings = new SafetySettings(0, 50)
            };

            livingRoomOne = new Room("Living Room 1", livingRoomConfig);
            serverRoomOne = new Room("Server Room 1", serverRoomConfig);

        }


        private void TemperatureSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double temp = e.NewValue;
            TemperatureText.Text = $"Temperature: {temp:F1}°C";
            livingRoomOne.Sensor.SetTemperature(temp);
        }
    }
}