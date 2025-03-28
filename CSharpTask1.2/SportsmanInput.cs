using System;

namespace CSharpTask1._2
{
    internal class SportsmanInput(InputValidator validator)
    {
        private readonly InputValidator _inputValidator = validator;

        public Sportsman[] CreateSportsmenArray()
        {
            int arrayLength = _inputValidator.GetValidInput("Введите количество спортсменов: ");
            Sportsman[] sportsmen = new Sportsman[arrayLength];
            return FillSportsmenArray(sportsmen);
        }

        public Sportsman[] FillSportsmenArray(Sportsman[] sportsmen)
        {
            for (int i = 0; i < sportsmen.Length; i++)
            {
                Console.Write("Введите фамилию: ");
                string name = Console.ReadLine() ?? "Безымянный";

                int birthYear = _inputValidator.GetValidInput("Введите год рождения: ");
                int[] resultsArray = ReadResultsArray();

                sportsmen[i] = new Sportsman(name, birthYear, resultsArray);
            }
            return sportsmen;
        }

        public int[] ReadResultsArray()
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
