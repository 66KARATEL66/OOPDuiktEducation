using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Models
{
    public class Book
    {
        Guid id { get; set; }
        string name { get; set; }
        Author author { get; set; }
    }
}
