using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Task2
    {
        public delegate void NotificationHandler(string message);

        public void Example()
        {
            NotificationHandler handler = SendEmail;
            handler += SendSMS;

            handler("Two notifications sent!");
        }

        private void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }

        private void SendSMS(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }
}
