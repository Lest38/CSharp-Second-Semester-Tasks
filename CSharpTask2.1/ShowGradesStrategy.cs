using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHandler
{
    public class ShowGradesStrategy : IStudentActionStrategy
    {
        public void Execute(Student student)
        {
            var grades = student.GetAllGrades();
            if (grades.Count == 0)
                Console.WriteLine("No grades to display.");
            else
                Console.WriteLine("Grades: " + string.Join(", ", grades));
        }
    }
}
