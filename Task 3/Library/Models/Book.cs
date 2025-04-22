using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    /// <summary>
    /// Abstract class representing a book.
    /// </summary>
    public abstract class Book
    {
        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public abstract void DisplayInfo();
    }
}
