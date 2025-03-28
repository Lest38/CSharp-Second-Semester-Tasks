using System;

namespace CSharpTask1._2
{
    internal class SportsmanInput(InputValidator validator)
    {
        private readonly InputValidator _inputValidator = validator;

        /// <summary>
        /// Creates an array of Sportsman object from user input
        /// </summary>
        /// <returns></returns>
        public Sportsman[] CreateSportsmenArray()
        {
            int arrayLength = _inputValidator.GetValidInput("Введите количество спортсменов: ");
            Sportsman[] sportsmen = new Sportsman[arrayLength];
            return FillSportsmenArray(sportsmen);
        }
        /// <summary>
        /// Fills a Sportsman array with user input 
        /// </summary>
        /// <param name="sportsmen"></param>
        /// <returns></returns>
        public Sportsman[] FillSportsmenArray(Sportsman[] sportsmen)
        {
            for (int i = 0; i < sportsmen.Length; i++)
            {
                Console.Write("Введите фамилию: ");
                string name = Console.ReadLine() ?? "Безымянный";

                int birthYear = _inputValidator.GetValidInput("Введите год рождения: ");
                int[] resultsArray = FillResultsArray();

                sportsmen[i] = new Sportsman(name, birthYear, resultsArray);
            }
            return sportsmen;
        }

        /// <summary>
        /// Fills a Results array with user input
        /// </summary>
        /// <returns></returns>
        public int[] FillResultsArray()
        {
            int resultsArrayLength = _inputValidator.GetValidInput("Введите количество результатов: ");
            int[] results = new int[resultsArrayLength];

            for (int i = 0; i < resultsArrayLength; i++)
            {
                results[i] = _inputValidator.GetValidInput($"Введите результат {i + 1}: ");
            }
            return results;
        }
    }
}
