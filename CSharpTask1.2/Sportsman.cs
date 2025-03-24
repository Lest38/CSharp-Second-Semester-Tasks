using System;

namespace CSharpTask1._2
{
    internal class Sportsman(string secondName, int birthYear, int[] competitionResults)
    {
        private readonly string _secondName = secondName;
        private readonly int _birthYear = birthYear;
        private readonly int[] _competitionResults = competitionResults;

        public int this[int index] => _competitionResults[index];

        public static void SortSportsmenByName(Sportsman[] sportsmen)
        {
            Array.Sort(sportsmen, (s1, s2) =>
                string.Compare(s1._secondName, s2._secondName, StringComparison.OrdinalIgnoreCase));
        }

        public override string ToString()
        {
            return $"{_secondName} ({_birthYear})";
        }

        public static void PrintSortedSportsmen(Sportsman[] sportsmen)
        {
            SortSportsmenByName(sportsmen);
            foreach (var sportsman in sportsmen)
            {
                Console.WriteLine($"Результаты {sportsman._secondName}: {string.Join(", ", sportsman._competitionResults)}");
            }
        }

        public static Sportsman[] MakeArray()
        {
            int arrayLength = InputValidator.GetValidInput("Введите количество спортсменов: ");
            Sportsman[] sportsmen = new Sportsman[arrayLength];
            return WriteArray(sportsmen);
        }

        public static Sportsman[] WriteArray(Sportsman[] sportsmen)
        {
            for (int i = 0; i < sportsmen.Length; i++)
            {
                Console.Write("Введите фамилию: ");
                string name = Console.ReadLine() ?? "Безымянный";

                int birthYear = InputValidator.GetValidInput("Введите год рождения: ");
                int[] resultsArray = ReadResultsArray();

                sportsmen[i] = new Sportsman(name, birthYear, resultsArray);
            }
            return sportsmen;
        }

        public static int[] ReadResultsArray()
        {
            int resultsArrayLength = InputValidator.GetValidInput("Введите количество результатов: ");
            int[] results = new int[resultsArrayLength];

            for (int i = 0; i < resultsArrayLength; i++)
            {
                results[i] = InputValidator.GetValidInput($"Введите результат {i + 1}: ");
            }
            return results;
        }

        public static void PrintAverageCompetitionResult(int minBirthYear, int maxBirthYear, Sportsman[] sportsmen)
        {
            int totalSum = 0, count = 0;

            foreach (var sportsman in sportsmen)
            {
                if (sportsman._birthYear >= minBirthYear && sportsman._birthYear <= maxBirthYear)
                {
                    totalSum += sportsman._competitionResults.Sum();
                    count += sportsman._competitionResults.Length;
                }
            }

            if (count == 0)
            {
                Console.WriteLine("Нет спортсменов в указанной возрастной группе.");
                return;
            }

            Console.WriteLine($"Средний результат: {totalSum / (double)count:F2}");
        }

        public static void PrintLowResults(Sportsman[] sportsmen, int minResult)
        {
            var filteredSportsmen = sportsmen
    .Where(sportsman => sportsman._competitionResults.Any(result => result < minResult));

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
