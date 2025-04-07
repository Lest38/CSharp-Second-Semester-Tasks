using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This code is a simple console application that allows the user to manage a student's grades.
 * The user can add grades, view all grades, calculate the average grade, and remove the lowest grade.
 * The program uses exception handling to catch any errors that may occur during execution.
 */

namespace StudentHandler
{
    class Program
    {
        /// <summary>
        /// Main method that serves as the entry point for the application.
        /// </summary>
        static void Main()
        {
            try
            {
                Console.Write("Enter the student's name: ");
                string? name = Console.ReadLine();
                Student student = new(name);

                while (true)
                {
                    Console.WriteLine("\nMenu:");
                    Console.WriteLine("1 - Add a grade");
                    Console.WriteLine("2 - Show all grades");
                    Console.WriteLine("3 - Show average grade");
                    Console.WriteLine("4 - Remove the lowest grade");
                    Console.WriteLine("5 - Exit");
                    Console.Write("Select an option: ");

                    string choice = Console.ReadLine() ?? "nullInput";
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter a grade (1-10): ");
                            if (int.TryParse(Console.ReadLine(), out int grade))
                            {
                                student.AddGrade(grade);
                                Console.WriteLine("Grade added.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Enter a number between 1 and 10.");
                            }
                            break;
                        case "2":
                            Console.WriteLine($"Grades: {string.Join(", ", student.GetAllGrades()) ?? "no grades found"}");
                            break;
                        case "3":
                            Console.WriteLine("Average grade: " + student.GetAverageGrade());
                            break;
                        case "4":
                            student.RemoveLowestGrade();
                            Console.WriteLine("Lowest grade removed.");
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}


