using StorageHandler.Managers;
using StorageHandler.Services;
using StorageHandler.UI;

namespace StorageHandler
{
    /// <summary>
    /// Main application class for the Storage Handler.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point for the Storage Handler application.
        /// </summary>
        static void Main()
        {
            StorageApp app = new();
            app.Run();
        }
    }
}