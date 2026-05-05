using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace pr6
{
    public class TaskN
    {
        Thread mainThread;
        Thread backThread;
        int counter;

        object locker = new object();
        bool isPaused = false;
        bool isRunning = true;


        private ConsoleColor[] colors =
        {
            ConsoleColor.White,
            ConsoleColor.Green,
            ConsoleColor.Yellow,
            ConsoleColor.Cyan,
            ConsoleColor.Red
        };

        int currentColorIndex = 0;

        public void Run()
        {
            mainThread = new Thread(Counter);
            mainThread.Start();

            backThread = new Thread(ReadKey);
            backThread.IsBackground = true;
            backThread.Start();

            mainThread.Join();
        }

        public void Counter()
        {
            while (isRunning)
            {   
                lock(locker)
                {
                    if(!isPaused)
                    {
                        Console.ForegroundColor = colors[currentColorIndex];

                        counter++;
                        Console.WriteLine($"Counter: {counter}");
                    }
                }

                Thread.Sleep(1000);
            }
        }

        public void ReadKey()
        {
            while(isRunning)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                lock (locker)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.P:
                            isPaused = !isPaused;
                            Console.WriteLine(isPaused ? "Paused" : "Resumed");
                            break;
                        case ConsoleKey.R:
                            counter = 0;
                            Console.WriteLine("Counter Reset");
                            break;
                        case ConsoleKey.C:
                            currentColorIndex++;

                            if (currentColorIndex >= colors.Length)
                                currentColorIndex = 0;

                            Console.WriteLine("Color Changed");

                            break;
                        case ConsoleKey.Q:
                            isRunning = false;
                            Console.WriteLine("Program stopped");
                            break;
                    }
                }
            }
        }
    }
}
