using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SoundSystem
    {
        private Player _player;

        public SoundSystem(Player player)
        {
            _player = player;
            _player.HPChanged += Sound;
        }

        public void Sound(object sender, PlayerEventArgs e)
        {
            if (e.CurrentHP <= 20)
                Console.WriteLine($"SoundSystem: {_player.Name} - critical condition sound");
            else

                Console.WriteLine($"SoundSystem: {_player.Name} - sound of taking damage");
        }
    }
}
