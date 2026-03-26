namespace Task2
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            MessagePublisher publisher = new MessagePublisher();
            FileLogger logger = new FileLogger();
            Console.Write("Enter a message to send:"); 
            string somethign = Console.ReadLine();
            publisher.Send(somethign);
            Console.Write("Enter a message to send:"); publisher.Send(Console.ReadLine());
            Console.Write("Enter a message to send:"); publisher.Send(Console.ReadLine());
            Console.Write("Enter a message to send:"); publisher.Send(Console.ReadLine());

        }
    }
}