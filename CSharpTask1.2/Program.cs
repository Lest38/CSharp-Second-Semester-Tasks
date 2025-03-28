using CSharpTask1._2;

namespace CSharpTask1._2
{
    internal class Program
    {
        static void Main()
        {
            InputValidator validator = new();
            SportsmanInput inputHandler = new(validator);
            Sportsman[] sportsmen = inputHandler.CreateSportsmenArray();

            SportsmanManager manager = new(sportsmen);
            SportsmanStatistics statistics = new(sportsmen);

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Вывести список спортсменов (в алфавитном порядке)");
                Console.WriteLine("2 - Вычислить средний результат соревнований для возрастной группы");
                Console.WriteLine("3 - Вывести список спортсменов с низкими результатами");
                Console.WriteLine("4 - Выйти");

                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nСписок спортсменов:");
                        manager.PrintSortedSportsmen();
                        break;

                    case "2":
                        int minYear = validator.GetValidInput("\nВведите минимальный год рождения: ");
                        int maxYear = validator.GetValidInput("Введите максимальный год рождения: ");
                        statistics.PrintAverageCompetitionResult(minYear, maxYear);
                        break;

                    case "3":
                        int minResult = validator.GetValidInput("\nВведите минимальный удовлетворительный результат: ");
                        statistics.PrintLowResults(minResult);
                        break;

                    case "4":
                        Console.WriteLine("Выход из программы.");
                        return;

                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }
            }
        }

    }
}