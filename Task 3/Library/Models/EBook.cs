using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    /// <summary>
    /// Class representing an eBook, inheriting from the Book class.
    /// </summary>
    internal class EBook : Book
    {
        /// <summary>
        /// Displays information about the eBook.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }
}
