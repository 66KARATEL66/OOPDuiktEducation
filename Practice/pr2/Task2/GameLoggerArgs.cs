using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class GameLoggerArgs
    {
        public Player Player;
        public int GetDamaged;
        public int CurrentHP;

        public GameLoggerArgs(Player player, int damage, int hp) 
        {
            Player = player;
            GetDamaged = damage;
            CurrentHP = hp;
        }
    }
}
