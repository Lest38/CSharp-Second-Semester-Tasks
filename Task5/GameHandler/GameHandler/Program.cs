using GameHandler.Modules.Games;
using GameHandler.Core;
using System;

namespace GameHandler
{
    /// <summary>
    /// Main program class.
    /// </summary>
    public class Program
    {
        private static Program program = new();
        private static PCGame pcGame = new("PC Game", 1);
        private static MobileGame mobileGame = new("Mobile Game", 2);
        private static ConsoleGame consoleGame = new("Console Game", 3);

        /// <summary>
        /// Main method.
        /// </summary>
        public static void Main(string[] args)
        {
            program.ShowMenu();
        }

        /// <summary>
        /// Displays the main menu.
        /// </summary>
        private void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("1. Start PC Game");
                Console.WriteLine("2. Start Mobile Game");
                Console.WriteLine("3. Start Console Game");
                Console.WriteLine("4. Update Players Count");
                Console.WriteLine("5. Exit");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        pcGame.Start();
                        break;
                    case "2":
                        mobileGame.Start();
                        break;
                    case "3":
                        consoleGame.Start();
                        break;
                    case "4":
                        program.UpdatePlayersCountMenu();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        /// <summary>
        /// Displays the menu for updating the players count.
        /// </summary>
        private void UpdatePlayersCountMenu()
        {
            Console.WriteLine("1. PC Game");
            Console.WriteLine("2. Mobile Game");
            Console.WriteLine("3. Console Game");

            var input = Console.ReadLine();
            Game? selectedGame = input switch
            {
                "1" => pcGame,
                "2" => mobileGame,
                "3" => consoleGame,
                _ => null
            };

            if (selectedGame == null)
            {
                Console.WriteLine("Invalid option.");
                return;
            }

            Console.Write($"Enter new players count for {selectedGame.Name}: ");
            if (int.TryParse(Console.ReadLine(), out int newCount))
            {
                selectedGame.UpdatePlayersCount(newCount);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
