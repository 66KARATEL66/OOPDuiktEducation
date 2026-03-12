using pr2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Systems.Args
{
    public class SecuritySystemEventArgs
    {
        public SecuritySystemWarning Warning;
        public SecuritySystemEventArgs(SecuritySystemWarning warning)
        { 
            Warning = warning;
        }
    }
}
