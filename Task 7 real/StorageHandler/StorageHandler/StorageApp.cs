using StorageHandler.Managers;
using StorageHandler.Services;
using StorageHandler.UI;

namespace StorageHandler
{
    /// <summary>
    /// Main application class for the Storage Handler.
    /// </summary>
    internal class StorageApp
    {
        private readonly string _filePath;

        public StorageApp()
        {
            _filePath = Path.Combine(AppContext.BaseDirectory, "products.txt");
            EnsureFileExists();
        }

        /// <summary>
        /// Ensures the data file exists and is properly formatted
        /// </summary>
        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath))
            {
                Console.WriteLine($"Creating new data file at {_filePath}");
                File.WriteAllText(_filePath, """
                    134; OOO "Progress"; 25000; 385
                    134; IP.Petrov V.V.; 23000; 200
                    012; IP.Petrov V.V.; 120000; 15
                    """);
            }
        }

        /// <summary>
        /// Entry point for the Storage Handler application.
        /// </summary>
        public void Run()
        {
            Console.WriteLine($"Using data file: {_filePath}");

            var fileService = new FileService();
            var reportGenerator = new ReportGenerator();
            var productManager = new ProductManager(fileService);
            var displayManager = new DisplayManager(productManager, reportGenerator, fileService);

            productManager.LoadProducts(_filePath);
            var ui = new UserInterface(displayManager, productManager);

            ui.Run();
        }
    }
}