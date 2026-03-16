using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class GameLogger
    {
        public List<GameLoggerArgs> gameLoggerArgs = new List<GameLoggerArgs>();

        public void Update(object? sender, PlayerEventArgs e)
        {
            Player player = sender as Player;
            if (player != null)
            {
                gameLoggerArgs.Add(new(player, e.Damage, e.CurrentHP));
                Console.WriteLine($"Logs: {player.Name} take {e.Damage} damage, current HP {e.CurrentHP}");
            }
        }
    }
}
