using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CSharpTask1._2
{
    internal static class Program
    {
        static void Main()
        {
            Sportsman[] sportsmen = Sportsman.MakeArray();
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
                        Sportsman.PrintSortedSportsmen(sportsmen);
                        break;

                    case "2":
                        int minYear = InputValidator.GetValidInput("\nВведите минимальный год рождения: ");
                        int maxYear = InputValidator.GetValidInput("Введите максимальный год рождения: ");
                        Sportsman.PrintAverageCompetitionResult(minYear, maxYear, sportsmen);
                        break;

                    case "3":
                        int minResult = InputValidator.GetValidInput("\nВведите минимальный удовлетворительный результат: ");
                        Sportsman.PrintLowResults(sportsmen, minResult);
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
