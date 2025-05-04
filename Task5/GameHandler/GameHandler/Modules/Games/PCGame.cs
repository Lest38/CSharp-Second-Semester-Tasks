using GameHandler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHandler.Modules.Games
{
    /// <summary>
    /// Computer game class.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="playersCount"></param>
    public class PCGame(string name, int playersCount) : Game(name, playersCount)
    {
        /// <summary>
        /// Starts the computer game.
        /// </summary>
        public override void Start()
        {
            Console.WriteLine("Компьютерная игра стартовала");
        }
    }
}
