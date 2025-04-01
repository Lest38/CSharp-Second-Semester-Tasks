using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentHandler
{
    class Student
    {
        public string Name { get; }
        private GradeManager gradeManager;

        public Student(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя студента не может быть пустым.");

            Name = name;
            gradeManager = new GradeManager();
        }

        public void AddGrade(int grade) => gradeManager.AddGrade(grade);
        public double GetAverageGrade() => gradeManager.GetAverageGrade();
        public List<int> GetAllGrades() => gradeManager.GetAllGrades();
        public void RemoveLowestGrade() => gradeManager.RemoveLowestGrade();
    }

}