using GameHandler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHandler.Modules.Games
{
    /// <summary>
    /// Mobile game class.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="playersCount"></param>
    public class MobileGame(string name, int playersCount) : Game(name, playersCount)
    {
        /// <summary>
        /// Starts the mobile game.
        /// </summary>
        public override void Start()
        {
            Console.WriteLine("Мобильная игра стартовала");
        }
    }
}
