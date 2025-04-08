using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHandler
{
    /// <summary>
    /// Handles actions related to a student, such as adding grades, showing grades, and calculating averages.
    /// </summary>
    public class StudentActionHandler
    {
        public void AddGrade(Student student, int minGrade = 1, int maxGrade = 10)
        {
            Console.Write($"Enter a grade ({minGrade}-{maxGrade}): ");
            if (int.TryParse(Console.ReadLine(), out int grade))
            {
                try
                {
                    student.AddGrade(grade, minGrade, maxGrade);
                    Console.WriteLine("Grade added.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Invalid input. Enter a number between {minGrade} and {maxGrade}.");
            }
        }

        /// <summary>
        /// Displays all grades of the student.
        /// </summary>
        /// <param name="student"></param>
        public void ShowGrades(Student student)
        {
            var grades = student.GetAllGrades();
            if (grades.Count == 0)
                Console.WriteLine("No grades to display.");
            else
                Console.WriteLine("Grades: " + string.Join(", ", grades));
        }

        /// <summary>
        /// Calculates and displays the average grade of the student.
        /// </summary>
        /// <param name="student"></param>
        public void ShowAverage(Student student)
        {
            double avg = student.GetAverageGrade();
            Console.WriteLine($"Average grade: {avg:F2}");
        }

        /// <summary>
        /// Removes the lowest grade from the student's list of grades.
        /// </summary>
        /// <param name="student"></param>
        public void RemoveLowestGrade(Student student)
        {
            try
            {
                student.RemoveLowestGrade();
                Console.WriteLine("Lowest grade removed.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
