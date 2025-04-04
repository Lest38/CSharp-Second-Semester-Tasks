﻿using System;
using System.Linq;

namespace CSharpTask1._2
{
    internal class SportsmanStatistics(Sportsman[] sportsmen)
    {
        private readonly Sportsman[] _sportsmen = sportsmen;

        /// <summary>
        /// Finds sportsmen between min and max birthyear and prints their average competition results
        /// </summary>
        /// <param name="minBirthYear"></param>
        /// <param name="maxBirthYear"></param>
        public void PrintAverageCompetitionResult(int minBirthYear, int maxBirthYear)
        {
            int totalSum = 0, count = 0;

            foreach (var sportsman in _sportsmen)
            {
                if (sportsman.BirthYear >= minBirthYear && sportsman.BirthYear <= maxBirthYear)
                {
                    totalSum += sportsman.CompetitionResults.Sum();
                    count += sportsman.CompetitionResults.Length;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Нет спортсменов в указанной возрастной группе.");
                return;
            }

            Console.WriteLine($"Средний результат: {totalSum / (double)count:F2}");
        }

        /// <summary>
        /// Prints sportsmen's names whose results are lower than given number
        /// </summary>
        /// <param name="minResult"></param>
        public void PrintLowResults(int minResult)
        {
            var filteredSportsmen = _sportsmen
                .Where(sportsman => sportsman.CompetitionResults.Any(result => result < minResult));

            if (!filteredSportsmen.Any())
            {
                Console.WriteLine("Все результаты удовлетворительны.");
            }
            else
            {
                foreach (var sportsman in filteredSportsmen)
                {
                    Console.WriteLine(sportsman);
                }
            }
        }
    }
}
