using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHandler
{
    public interface IStudentActionStrategy
    {
        void Execute(Student student);
    }
}
