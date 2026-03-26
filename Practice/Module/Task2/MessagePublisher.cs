using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class MessagePublisher
    {
        public event EventHandler<MessageSentEventArgs> MessageSentEvent;

        public void Send(string message)
        {
            MessageSentEvent?.Invoke(this, new MessageSentEventArgs(message));
        }
    }
}
