using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentHandler
{
    class Student
    {
        public string Name { get; }
        private List<int> grades = [];

        public Student(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student's name can't be empty");

            Name = name;
        }

        public void AddGrade(int grade)
        {
            if (grade < 1 || grade > 10)
                throw new ArgumentException("Grade should be from 1 to 10.");

            grades.Add(grade);
        }

        public double GetAverageGrade()
        {
            return grades.Count > 0 ? grades.Average() : 0.0;
        }

        public List<int> GetAllGrades()
        {
            return new List<int>(grades);
        }

        public void RemoveLowestGrade()
        {
            if (grades.Count > 0)
            {
                int minGrade = grades.Min();
                grades.Remove(minGrade);
            }
        }
    }

}
