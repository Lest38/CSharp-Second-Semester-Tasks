using System;

namespace CSharpTask1._2
{
    internal class SportsmanManager(Sportsman[] sportsmen)
    {
        private readonly Sportsman[] _sportsmen = sportsmen;

        /// <summary>
        /// Sorts Sportsman objects by their names in alphabetic order (ascending)
        /// </summary>
        public void SortSportsmenByName()
        {
            Array.Sort(_sportsmen, (s1, s2) =>
                string.Compare(s1.SecondName, s2.SecondName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Sorts a Sportsman class by their names in alphabetic order (ascending). Prints their names and results
        /// </summary>
        public void PrintSortedSportsmen()
        {
            SortSportsmenByName();
            foreach (var sportsman in _sportsmen)
            {
                Console.WriteLine($"Результаты {sportsman.SecondName}: {string.Join(", ", sportsman.CompetitionResults)}");
            }
        }

        public Sportsman[] GetSportsmen()
        {
            return _sportsmen;
        }
    }
}
