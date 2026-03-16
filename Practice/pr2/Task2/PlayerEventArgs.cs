using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class PlayerEventArgs : EventArgs
    {
        public int Damage;
        public int CurrentHP;
        public PlayerEventArgs(int damage, int currentHP) 
        { 
            Damage = damage;
            CurrentHP = currentHP;
        }
    }
}
