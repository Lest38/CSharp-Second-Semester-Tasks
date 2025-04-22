using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UI
{
    using global::Library.Models;

    namespace Library
    {
        /// <summary>
        /// Class representing the library application.
        /// </summary>
        public class LibraryApp
        {
            /// <summary>
            /// Main method to start the library application.
            /// </summary>
            public void AppLoop()
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Add a printed book");
                Console.WriteLine("2. Add an ebook");
                Console.WriteLine("3. Exit");
                while (true)
                {
                    string choice = Console.ReadLine() ?? "nullinput";
                    switch (choice)
                    {
                        case "1":
                            PrintedBook printedBook = new PrintedBook();
                            printedBook.DisplayInfo();
                            break;
                        case "2":
                            EBook eBook = new EBook();
                            eBook.DisplayInfo();
                            break;
                        case "3":
                            Console.WriteLine("Exiting the app.");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }
    }

}
