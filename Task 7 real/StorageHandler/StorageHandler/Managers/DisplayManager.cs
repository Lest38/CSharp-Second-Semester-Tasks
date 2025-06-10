using StorageHandler.Models;
using StorageHandler.Services;

namespace StorageHandler.Managers
{
    /// <summary>
    /// Handles all display-related operations for products and reports
    /// </summary>
    public class DisplayManager
    {
        private readonly ProductManager _productManager;
        private readonly IReportGenerator _reportGenerator;
        private readonly IFileService _fileService;

        public DisplayManager(ProductManager productManager,
                           IReportGenerator reportGenerator,
                           IFileService fileService)
        {
            _productManager = productManager;
            _reportGenerator = reportGenerator;
            _fileService = fileService;
        }

        /// <summary>
        /// Displays product information for a specific product code
        /// </summary>
        public void DisplayProductInfo(int productCode)
        {
            var selectedProducts = _productManager.GetProductsByCode(productCode);

            if (selectedProducts.Any())
            {
                Console.WriteLine("\n=== Found Products ===");
                selectedProducts.ForEach(p => Console.WriteLine(p));
            }
            else
            {
                Console.WriteLine("\nNo products with this code found in warehouse.");
            }
        }

        /// <summary>
        /// Displays available product names and codes
        /// </summary>
        public void DisplayAvailableProducts()
        {
            Console.WriteLine("=== Available Products ===");
            foreach (ProductName name in Enum.GetValues(typeof(ProductName)))
            {
                Console.WriteLine($"{(int)name} - {name}");
            }
        }

        /// <summary>
        /// Generates and saves a supplier report
        /// </summary>
        public void GenerateAndSaveSupplierReport(string filename)
        {
            var products = _productManager.GetAllProducts();
            var report = _reportGenerator.GenerateSupplierReport(products);
            _fileService.SaveReport(report, filename);
            Console.WriteLine("Report successfully generated");
        }

        /// <summary>
        /// Displays products grouped by supplier
        /// </summary>
        public void DisplayProductsBySupplier()
        {
            var supplierGroups = _productManager.GetProductsGroupedBySupplier();

            foreach (var group in supplierGroups)
            {
                Console.WriteLine($"\nSupplier: {group.Key}");
                Console.WriteLine("---------------------");
                foreach (var product in group)
                {
                    Console.WriteLine($"{product.Name} - {product.Quantity} units");
                }
            }
        }
    }
}