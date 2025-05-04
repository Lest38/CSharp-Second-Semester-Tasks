using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHandler.Core
{
    /// <summary>
    /// Base class for all games.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="playersCount"></param>
    public abstract class Game(string name, int playersCount)
    {
        public string Name { get; set; } = name;

        private int _playersCount = playersCount;
        private const int MAX_PLAYERS_COUNT = 999;
        private readonly int MIN_PLAYERS_COUNT = 0;

        public int PlayersCount
        {
            get => _playersCount;
        }

        /// <summary>
        /// Updates the number of players.
        /// </summary>
        /// <param name="newPlayersCount">The new number of players.</param>
        public void UpdatePlayersCount(int newPlayersCount)
        {
            if (newPlayersCount < MIN_PLAYERS_COUNT || newPlayersCount > MAX_PLAYERS_COUNT)
            {
                throw new ArgumentException($"Players count must be at least {MIN_PLAYERS_COUNT} and less than {MAX_PLAYERS_COUNT}");
            }

            _playersCount = newPlayersCount;
            Console.WriteLine($"Players count updated to {newPlayersCount}");
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public abstract void Start();
    }
}
