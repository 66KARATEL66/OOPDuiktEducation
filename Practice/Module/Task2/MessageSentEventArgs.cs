using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class MessageSentEventArgs
    {
        public string Message { get; }
        public MessageSentEventArgs(string message)
        {
            Message = message;
        }
    }
}
