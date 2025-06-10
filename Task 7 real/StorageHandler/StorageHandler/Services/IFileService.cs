using StorageHandler.Models;

namespace StorageHandler.Services
{
    /// <summary>
    /// Service for handling file operations related to products.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Reads products from a file and returns a list of Product objects.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        List<Product> ReadProducts(string filePath);
        /// <summary>
        /// Saves a list of products to a file.
        /// </summary>
        /// <param name="products"></param>
        /// <param name="filePath"></param>
        void SaveProducts(List<Product> products, string filePath);
        /// <summary>
        /// Saves a report to a file with the specified content and filename.
        /// </summary>
        /// <param name="content"></param>
        /// <param name="filename"></param>
        void SaveReport(string content, string filename);
    }
}
