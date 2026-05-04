using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Models
{
    public class User
    {
        Guid id { get; set; }
        string name { get; set; }
        string password { get; set; }
        string email { get; set; }
        DateTime createdAt { get; set; }
    }
}
