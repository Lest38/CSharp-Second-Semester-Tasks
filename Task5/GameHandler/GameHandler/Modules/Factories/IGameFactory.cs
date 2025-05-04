using GameHandler.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHandler.Modules.Factories
{
    /// <summary>
    /// Interface for game factory.
    /// </summary>
    public interface IGameFactory
    {
        /// <summary>
        /// Creates a game.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="playersCount"></param>
        /// <returns></returns>
        Game CreateGame(string name, int playersCount);
    }
}
