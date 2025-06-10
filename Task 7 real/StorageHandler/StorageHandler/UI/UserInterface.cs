using StorageHandler.Managers;

namespace StorageHandler.UI
{
    /// <summary>
    /// User interface for the Warehouse Management System
    /// </summary>
    public class UserInterface
    {
        private readonly DisplayManager _displayManager;
        private readonly ProductManager _productManager;

        /// <summary>
        /// Initializes a new instance of the UserInterface class.
        /// </summary>
        /// <param name="displayManager"></param>
        /// <param name="productManager"></param>
        public UserInterface(DisplayManager displayManager, ProductManager productManager)
        {
            _displayManager = displayManager;
            _productManager = productManager;
        }

        /// <summary>
        /// Runs the user interface, displaying options and handling user input.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Warehouse Management System ===");
                Console.WriteLine("1. View product information");
                Console.WriteLine("2. Generate supplier report");
                Console.WriteLine("3. View products by supplier");
                Console.WriteLine("4. Exit");
                Console.Write("Select option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowProductInfo();
                        break;
                    case "2":
                        GenerateReport();
                        break;
                    case "3":
                        ShowProductsBySupplier();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Displays product information based on user input.
        /// </summary>
        private void ShowProductInfo()
        {
            Console.Clear();
            _displayManager.DisplayAvailableProducts();

            Console.Write("\nEnter product code or 0 to return: ");
            if (int.TryParse(Console.ReadLine(), out int code) && code != 0)
            {
                _displayManager.DisplayProductInfo(code);

                Console.WriteLine("Press Home to save to file or any other key to continue...");
                if (Console.ReadKey().Key == ConsoleKey.Home)
                {
                    var selectedProducts = _productManager.GetProductsByCode(code);
                    _productManager.SaveProducts(selectedProducts, $"product_{code}_info.txt");
                    Console.WriteLine("\nInformation saved to file.");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Generates and saves a supplier report to a file.
        /// </summary>
        private void GenerateReport()
        {
            Console.Clear();
            Console.WriteLine("Generating supplier report...");
            _displayManager.GenerateAndSaveSupplierReport("supplier_report.txt");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// Displays products grouped by supplier.
        /// </summary>
        private void ShowProductsBySupplier()
        {
            Console.Clear();
            _displayManager.DisplayProductsBySupplier();
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}