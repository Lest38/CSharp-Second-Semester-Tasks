using GameHandler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHandler.Modules.Games
{
    /// <summary>
    /// Console game class.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="playersCount"></param>
    public class ConsoleGame(string name, int playersCount) : Game(name, playersCount)
    {
        /// <summary>
        /// Starts the console game.
        /// </summary>
        public override void Start()
        {
            Console.WriteLine("Консольная игра стартовала");
        }
    }
}
