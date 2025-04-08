using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHandler
{
    public class ShowAverageStrategy : IStudentActionStrategy
    {
        public void Execute(Student student)
        {
            double avg = student.GetAverageGrade();
            Console.WriteLine($"Average grade: {avg:F2}");
        }
    }
}
