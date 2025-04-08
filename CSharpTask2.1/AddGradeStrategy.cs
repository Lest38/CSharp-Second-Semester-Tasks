using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHandler
{
    public class AddGradeStrategy : IStudentActionStrategy
    {
        public void Execute(Student student)
        {
            Console.Write("Enter a grade (1-10): ");
            if (int.TryParse(Console.ReadLine(), out int grade))
            {
                student.AddGrade(grade);
                Console.WriteLine("Grade added.");
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a number between 1 and 10.");
            }
        }
    }
}
