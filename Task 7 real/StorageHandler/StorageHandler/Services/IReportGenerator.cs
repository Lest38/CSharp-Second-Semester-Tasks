using StorageHandler.Models;

namespace StorageHandler.Services
{
    /// <summary>
    /// Interface for generating reports based on product data.
    /// </summary>
    public interface IReportGenerator
    {
        /// <summary>
        /// Generates a supplier report based on a list of products.
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        string GenerateSupplierReport(List<Product> products);
    }
}
