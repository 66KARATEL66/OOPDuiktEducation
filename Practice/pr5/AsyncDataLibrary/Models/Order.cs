using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Models
{
    public class Order
    {
        Guid id { get; set; }
        List<Book> books { get; set; }
        User user { get; set; }
    }
}
