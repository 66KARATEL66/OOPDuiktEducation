using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Player
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; private set; }

        public event EventHandler<PlayerEventArgs>? HPChanged;
    
        public Player(string name, int maxHP) { Name = name; MaxHP = maxHP; CurrentHP = MaxHP; }

        public void GetDamaged(int damage)
        {
            if (damage < 0 ) return;

            CurrentHP -= damage;

            if(CurrentHP <= 0)
                CurrentHP = 0;

            HPChanged?.Invoke(this, new PlayerEventArgs(damage, CurrentHP));
        }
    }
}
