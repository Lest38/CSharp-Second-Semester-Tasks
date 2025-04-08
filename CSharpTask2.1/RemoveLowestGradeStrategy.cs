using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHandler
{
    public class RemoveLowestGradeStrategy : IStudentActionStrategy
    {
        public void Execute(Student student)
        {
            student.RemoveLowestGrade();
            Console.WriteLine("Lowest grade removed.");
        }
    }
}
