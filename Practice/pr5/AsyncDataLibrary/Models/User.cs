using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDataLibrary.Models
{
    public class User
    {
        public int id { get; set; } = 0;
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public DateTime createdAt { get; set; }
    }
}
