using StorageHandler.Models;
using System.Text;

namespace StorageHandler.Services
{
    /// <summary>
    /// Service for generating reports based on product data.
    /// </summary>
    public class ReportGenerator : IReportGenerator
    {
        /// <summary>
        /// Generates a supplier report based on a list of products.
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public string GenerateSupplierReport(List<Product> products)
        {
            var report = new StringBuilder();
            var suppliers = products.GroupBy(p => p.Supplier).OrderBy(g => g.Key);

            foreach (var supplier in suppliers)
            {
                report.AppendLine(supplier.Key);

                if (supplier.Any())
                {
                    report.AppendLine("| # | Product Name | Quantity | Total Value |");
                    report.AppendLine("| :- | :- | :- | :- |");

                    int counter = 1;
                    foreach (var product in supplier)
                    {
                        report.AppendLine($"| {counter} | {product.Name} | {product.Quantity} | {product.TotalValue:C} |");
                        counter++;
                    }
                }
                else
                {
                    report.AppendLine("No products delivered");
                }

                report.AppendLine();
            }

            return report.ToString();
        }
    }
}
