using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr4.Task6
{
    public class Inventory
    {
        public List<string> Items { get; set; } = new();

        public void InitilizeDefaults()
        {
            Items ??= new();
        }
    }
}
