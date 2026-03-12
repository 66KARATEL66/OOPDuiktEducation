using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr2.Systems.Args
{
    public class AirConditionerFailureEventArgs : EventArgs
    {
        public string Failure { get; }

        public AirConditionerFailureEventArgs(string failure)
        {
            Failure = failure;
        }
    }
}
