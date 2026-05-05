using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Models
{
    public class Order
    {
        public int id { get; set; }
        public List<Book> books { get; set; }
        public User user { get; set; }
    }
}
