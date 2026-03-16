using System;
using System.Numerics;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Player1", 100);
            Player player2 = new Player("Player2", 100);
            UIHealthBar uIHealthBar1 = new UIHealthBar(player1);
            UIHealthBar uIHealthBar2 = new UIHealthBar(player2);
            SoundSystem soundSystem = new SoundSystem(player1);
            SoundSystem soundSystem2 = new SoundSystem(player2);
            AchievementSystem achievementSystem = new AchievementSystem(player1);
            AchievementSystem achievementSystem2 = new AchievementSystem(player2);
            GameLogger gameLogger = new GameLogger();

            player1.HPChanged += gameLogger.Update;
            player2.HPChanged += gameLogger.Update;

            player1.GetDamaged(10);
            player2.GetDamaged(15);
            Console.WriteLine();
            player1.GetDamaged(20);
            player2.GetDamaged(15);
            Console.WriteLine();
            player1.GetDamaged(30);
            player2.GetDamaged(40);
            Console.WriteLine();
            player1.GetDamaged(40);
            player2.GetDamaged(10);
            Console.WriteLine();

            foreach (var element in gameLogger.gameLoggerArgs)
            {
                Console.Write($"Logs: {element.Player.Name} take {element.GetDamaged} damage, current HP {element.CurrentHP} || ");
            }
        }
    }
}