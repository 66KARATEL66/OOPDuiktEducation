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
using pr2.Systems.Args;
using static pr2.Services.DisplayService;

namespace ControllerTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Room livingRoomOne;
        Room serverRoomOne;

        private List<Room> Rooms = new();

        public MainWindow()
        {
            InitializeComponent();

            Rooms.Add(CreateRoom("Living Room 1", true, 17, 25, 5, 40));
            Rooms.Add(CreateRoom("Server Room 1", false, 5, 15, 0, 50));

            foreach (var room in Rooms)
            {
                var tab = new TabItem
                {
                    Header = room.Name,
                    Content = CreateRoomTabContent(room) // повертає Grid/StackPanel з логами та слайдером
                };
                RoomsTabControl.Items.Add(tab);
            }
        }

        private StackPanel CreateRoomTabContent(Room room)
        {
            var panel = new StackPanel();

            // TextBlock для температури
            var tempTextBlock = new TextBlock { Text = "Temperature:", FontSize = 26, Margin = new Thickness(5) };
            panel.Children.Add(tempTextBlock);

            // Slider для температури
            var slider = new Slider { Minimum = -30, Maximum = 50, Width = 348, Height = 24, Margin = new Thickness(5) };
            slider.ValueChanged += (s, e) =>
            {
                double temp = e.NewValue;
                tempTextBlock.Text = $"Temperature: {temp:F1}°C";
                room.Sensor.SetTemperature(temp);
            };
            panel.Children.Add(slider);

            // Кнопки
            var buttonPanel = new StackPanel { Orientation = Orientation.Horizontal };
            var brokeButtonAC = new Button { Content = "Broke AC", FontSize = 24, Margin = new Thickness(20, 5, 20, 5) };
            var brokeButtonSecurity = new Button { Content = "Broke Security", FontSize = 24, Margin = new Thickness(20, 5, 20, 5) };
            brokeButtonAC.Click += (s, e) => room.ACDevice.Broke();
            brokeButtonSecurity.Click += (s, e) => room.SecurityDevice.Broke();
            buttonPanel.Children.Add(brokeButtonAC);
            buttonPanel.Children.Add(brokeButtonSecurity);
            panel.Children.Add(buttonPanel);

            // Логи
            var logListBox = new ListBox {Margin = new Thickness(5) };
            panel.Children.Add(logListBox);

            // Підписка на DisplayChanged
            room.Display.DisplayChanged += (s, e) =>
            {
                Dispatcher.Invoke(() =>
                {
                    logListBox.Items.Add($"[{e.State.RoomName}] Temp: {e.State.Temperature:F1}°C | AC: {e.State.AirConditionerMode} | AC Fail: {e.State.AirConditionerFailure} | Security: {e.State.SecuritySystemWarning} | Sec Fail: {e.State.SecuritySystemFailure}");
                    if (logListBox.Items.Count > 10) logListBox.Items.RemoveAt(0);
                });
            };

            return panel;
        }

        private Room CreateRoom(string name, bool isHeatingAllowed, double comfortMin, double comfortMax, double safetyMin, double safetyMax)
        {
            var config = new RoomConfiguration
            {
                name = name,
                isHeatingAllowed = isHeatingAllowed,
                comfortSettings = new ComfortSettings(comfortMin, comfortMax),
                safetySettings = new SafetySettings(safetyMin, safetyMax)
            };

            return new Room(name, config);
        }
    }
}