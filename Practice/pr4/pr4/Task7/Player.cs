using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task7
{
    public class Player
    {
        public string Name {get; set; }
        public int Level { get; set; }

        public void InitilizeDefaults()
        {
            Name ??= "undefined";
            Level = (Level == 0) ? 0 : Level;
        }
    }
}
