using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentHandler
{
    class Student
    {
        public string Name { get; }
        private List<int> grades = [];

        /// <summary>
        /// Constructor for the Student class.
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException"></exception>
        public Student(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student's name can't be empty");

            Name = name;
        }

        /// <summary>
        /// Adds a grade to the student's list of grades.
        /// </summary>
        /// <param name="grade"></param>
        /// <exception cref="ArgumentException"></exception>
        public void AddGrade(int grade)
        {
            if (grade < 1 || grade > 10)
                throw new ArgumentException("Grade should be from 1 to 10.");

            grades.Add(grade);
        }

        /// <summary>
        /// Calculates the average grade of the student.
        /// </summary>
        /// <returns></returns>
        public double GetAverageGrade()
        {
            return grades.Count > 0 ? grades.Average() : 0.0;
        }

        /// <summary>
        /// Returns a list of all grades of the student.
        /// </summary>
        /// <returns></returns>
        public List<int> GetAllGrades()
        {
            return new List<int>(grades);
        }

        /// <summary>
        /// Removes the lowest grade from the student's list of grades.
        /// </summary>
        public void RemoveLowestGrade()
        {
            if (grades.Count == 0)
                throw new InvalidOperationException("No grades to remove.");
            using (var enumerator = grades.GetEnumerator())
            if (grades.Count > 0)
            {
                int minGrade = grades.Min();
                grades.Remove(minGrade);
            }
        }
    }

}
