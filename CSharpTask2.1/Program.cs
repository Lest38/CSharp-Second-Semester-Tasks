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
    /// <summary>
    /// Main program class that initializes the student and handles user input.
    /// </summary>
    public class Program
    {
        private Student student;
        private StudentActionHandler handler;

        /// <summary>
        /// Constructor for the Program class.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public Program()
        {
            Console.Write("Enter the student's name: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student's name can't be empty");
            student = new Student(name);
            handler = new StudentActionHandler();
        }

        /// <summary>
        /// Main loop of the program that displays options and uses user's input.
        /// </summary>
        public void RunMenuLoop()
        {
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
                        handler.AddGrade(student);
                        break;
                    case "2":
                        handler.ShowGrades(student);
                        break;
                    case "3":
                        handler.ShowAverage(student);
                        break;
                    case "4":
                        handler.RemoveLowestGrade(student);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        /// <summary>
        /// Main entry point of the program.
        /// </summary>
        static void Main()
        {
            try
            {
                var program = new Program();
                program.RunMenuLoop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

}


