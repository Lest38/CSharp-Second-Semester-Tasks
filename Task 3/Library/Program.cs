using Library.UI;
using Library.UI.Library;
namespace Library
{
    /// <summary>
    /// Main class for the library application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method to start the library application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            LibraryApp libraryApp = new LibraryApp();
            libraryApp.AppLoop();
        }
    }
}