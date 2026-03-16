using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class AchievementSystem
    {
        private Player _player;

        public AchievementSystem(Player player)
        {
            _player = player;
            _player.HPChanged += GetAchievement;
        }

        public void GetAchievement(object sender, PlayerEventArgs e)
        {
            if (e.CurrentHP <= 50) Console.WriteLine($"AchievmentSystem: {_player.Name} get Achievement - Half Health");
            else if (e.CurrentHP <= 0) Console.WriteLine($"AchievmentSystem: {_player.Name} get Achievement - First Death");
        }
    }
}
