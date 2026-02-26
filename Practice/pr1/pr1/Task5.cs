using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Task5
    {
        public void Example()
        {
            Logger logger = new Logger();
            logger.LogHandler = (message) => { Console.WriteLine(message); };
            logger.Log("Message First");
            logger.LogHandler = (message) => { Console.WriteLine(message.ToUpper()); };
            logger.Log("Message Second");
        }
    }

    public class Logger
    {
        public Action<string>? LogHandler;

        public void Log(string message)
        {
            LogHandler?.Invoke(message);
        }

        
    }
}
