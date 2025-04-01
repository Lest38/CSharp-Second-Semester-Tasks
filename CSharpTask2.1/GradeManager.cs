using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHandler
{
    class GradeManager
    {
        private List<int> grades = [];

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
