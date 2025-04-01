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
                throw new ArgumentException("Имя студента не может быть пустым.");

            Name = name;
        }

        public void AddGrade(int grade)
        {
            if (grade < 1 || grade > 10)
                throw new ArgumentException("Оценка должна быть в диапазоне от 1 до 10.");

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