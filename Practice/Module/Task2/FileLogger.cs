using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class FileLogger
    {
        public MessagePublisher _messagePublisher;
        private readonly string _filePath = "C:\\Users\\Ilya\\Documents\\GitHub\\OOPDuiktEducation\\Practice\\Module\\Module\\files\\logPD25.txt";

        public FileLogger(MessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
            _messagePublisher.MessageSentEvent += OnMessageSent;
        }

        public void OnMessageSent(object sender, MessageSentEventArgs e)
        {
            File.AppendAllText(_filePath, "Time: " + DateTime.Now + ": " + e.Message + "\n");
        }
    }
}
