using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameHandler.Core;
using GameHandler.Modules.Games;
using GameHandler.Utilities;

namespace GameHandler.Modules.Factories
{
    /// <summary>
    /// Mobile game factory class.
    /// </summary>
    public class MobileGameFactory : IGameFactory
    {
        /// <summary>
        /// Creates a game.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="playersCount"></param>
        /// <returns></returns>
        public Game CreateGame(string name, int playersCount)
        {
            ValidationHelper.ValidateGameParameters(name, playersCount);
            return new MobileGame(name, playersCount);
        }
    }
}
