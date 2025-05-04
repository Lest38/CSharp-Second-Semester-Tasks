using System;

namespace GameHandler.Utilities
{
    /// <summary>
    /// Helper class for validating game parameters.
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Validates the game parameters.
        /// </summary>
        /// <param name="name">The name of the game.</param>
        /// <param name="playersCount">The number of players.</param>
        public static void ValidateGameParameters(string name, int playersCount)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Game name cannot be null or empty.", nameof(name));
            }
            if (playersCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(playersCount), "Players count must be greater than zero.");
            }
        }
    }
}