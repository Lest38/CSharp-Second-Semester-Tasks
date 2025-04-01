using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHandler
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Введите имя студента: ");
                string? name = Console.ReadLine();
                Student student = new(name);

                while (true)
                {
                    Console.WriteLine("\nМеню:");
                    Console.WriteLine("1 - Добавить оценку");
                    Console.WriteLine("2 - Показать все оценки");
                    Console.WriteLine("3 - Показать средний балл");
                    Console.WriteLine("4 - Удалить самую низкую оценку");
                    Console.WriteLine("5 - Выход");
                    Console.Write("Выберите действие: ");

                    string choice = Console.ReadLine() ?? "nullInput";
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Введите оценку (1-10): ");
                            if (int.TryParse(Console.ReadLine(), out int grade))
                            {
                                student.AddGrade(grade);
                                Console.WriteLine("Оценка добавлена.");
                            }
                            else
                            {
                                Console.WriteLine("Некорректный ввод. Введите число от 1 до 10.");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Оценки: " + string.Join(", ", student.GetAllGrades()));
                            break;
                        case "3":
                            Console.WriteLine("Средний балл: " + student.GetAverageGrade());
                            break;
                        case "4":
                            student.RemoveLowestGrade();
                            Console.WriteLine("Самая низкая оценка удалена.");
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Попробуйте снова.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}