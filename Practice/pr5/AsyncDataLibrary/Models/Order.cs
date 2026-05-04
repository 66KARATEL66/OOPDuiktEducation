using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Models
{
    public class Order
    {
        public public int id { get; set; }
        public public List<Book> books { get; set; }
        public public User user { get; set; }
    }
}
