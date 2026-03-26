namespace Task2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            MessagePublisher publisher = new MessagePublisher();
            FileLogger logger = new FileLogger(publisher);
            Console.Write("Enter a message to send:"); publisher.Send(Console.ReadLine());
            Console.Write("Enter a message to send:"); publisher.Send(Console.ReadLine());
            Console.Write("Enter a message to send:"); publisher.Send(Console.ReadLine());
            Console.Write("Enter a message to send:"); publisher.Send(Console.ReadLine());

        }
    }
}