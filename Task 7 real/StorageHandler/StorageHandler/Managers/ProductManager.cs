using StorageHandler.Models;
using StorageHandler.Services;
using System.Diagnostics;

namespace StorageHandler.Managers
{
    /// <summary>
    /// Handles all product-related operations including loading, saving, and querying products.
    /// </summary>
    public class ProductManager
    {
        private readonly IFileService _fileService;
        private List<Product> _products = [];

        public ProductManager(IFileService fileService)
        {
            _fileService = fileService;
        }

        /// <summary>
        /// Loads products from a specified file
        /// </summary>
        public void LoadProducts(string filename)
        {
            _products = _fileService.ReadProducts(filename);
            Console.WriteLine($"Loaded {_products.Count} products from {filename}");
        }

        /// <summary>
        /// Gets all products matching a specific product code
        /// </summary>
        public List<Product> GetProductsByCode(int productCode)
        {
            return [.. _products.Where(p => p.Code == productCode)];
        }

        /// <summary>
        /// Gets all products in the warehouse
        /// </summary>
        public List<Product> GetAllProducts()
        {
            return [.. _products];
        }

        /// <summary>
        /// Saves products to a specified file
        /// </summary>
        public void SaveProducts(List<Product> products, string filename)
        {
            _fileService.SaveProducts(products, filename);
        }

        /// <summary>
        /// Groups products by supplier
        /// </summary>
        public IEnumerable<IGrouping<string, Product>> GetProductsGroupedBySupplier()
        {
            return _products.GroupBy(p => p.Supplier).OrderBy(g => g.Key);
        }
    }
}