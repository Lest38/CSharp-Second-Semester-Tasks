using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    /// <summary>
    /// Class representing a printed book, inheriting from the Book class.
    /// </summary>
    internal class PrintedBook : Book
    {
        /// <summary>
        /// Displays information about the printed book.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }
}
