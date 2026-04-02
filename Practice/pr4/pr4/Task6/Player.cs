using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task6
{
    public class Player
    {
        public string Name { get; set; }
        public Inventory Inventory { get; set; }

        public void InitilizeDefaults()
        {
            Name ??= "undefined";
            Inventory ??= new Inventory();
            Inventory.InitilizeDefaults();
        }
    }
}
