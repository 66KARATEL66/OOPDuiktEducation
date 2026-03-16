using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class UIHealthBar
    {
        private Player _player;
        private int _health;

        public UIHealthBar (Player player)
        {
            _player = player;
            _health = _player.CurrentHP;
            _player.HPChanged += Update;
        }

        public void Update(object? sender, PlayerEventArgs e)
        {
            if (_player != null)
            {
                Console.WriteLine($"Health Bar: {_player.Name} has {e.CurrentHP} HP");
                _health = e.CurrentHP;
            }
        }
    }
}
