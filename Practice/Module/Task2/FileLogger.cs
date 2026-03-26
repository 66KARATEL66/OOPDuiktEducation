using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class FileLogger
    {
        public MessagePublisher _messagePublisher = new MessagePublisher();
        private readonly string _filePath = "C:\\Users\\Ilya\\Documents\\GitHub\\OOPDuiktEducation\\Practice\\Module\\Module\\files\\logPD25.txt";

        public FileLogger()
        {
            _messagePublisher.MessageSentEvent += OnMessageSent;
        }

        public void OnMessageSent(object sender, MessageSentEventArgs e)
        {
            File.AppendAllText(_filePath, e.Message + "\n");
        }
    }
}
