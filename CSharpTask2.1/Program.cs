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
    public class Program
    {
        private Student student;
        private Dictionary<string, IStudentActionStrategy> actions;

        /// <summary>
        /// Constructor that initializes the student object and the strategies.
        /// </summary>
        public Program()
        {
            Console.Write("Enter the student's name: ");
            string? name = Console.ReadLine();
            student = new Student(name);

            actions = new Dictionary<string, IStudentActionStrategy>
        {
            { "1", new AddGradeStrategy() },
            { "2", new ShowGradesStrategy() },
            { "3", new ShowAverageStrategy() },
            { "4", new RemoveLowestGradeStrategy() }
        };
        }

        /// <summary>
        /// Runs the menu loop with the user being able to select actions.
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
                if (actions.ContainsKey(choice))
                {
                    actions[choice].Execute(student);
                }
                else if (choice == "5")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }


        /// <summary>
        /// Main method that serves as the entry point for the program.
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


