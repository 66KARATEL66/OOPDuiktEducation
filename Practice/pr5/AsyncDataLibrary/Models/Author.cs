using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Models
{
    public class Author
    {
        Guid id { get; set; }
        string name { get; set; }
        List<Book> books { get; set; }
    }
}
