using StorageHandler.Models;
using System.Diagnostics;

namespace StorageHandler.Services
{
    /// <summary>
    /// Service for handling file operations related to products.
    /// </summary>
    public class FileService : IFileService
    {
        private const int ExpectedPartsCount = 4;
        private const string Delimiter = "; ";

        /// <summary>
        /// Reads products from a file and returns a list of Product objects.
        /// </summary>
        public List<Product> ReadProducts(string filePath)
        {
            var products = new List<Product>();

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}");
                    return products;
                }

                var lines = File.ReadAllLines(filePath)
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .ToList();

                Console.WriteLine($"Found {lines.Count} lines in file");

                foreach (var line in lines)
                {
                    try
                    {
                        var parts = line.Split(Delimiter)
                                      .Select(p => p.Trim())
                                      .ToArray();

                        if (parts.Length == ExpectedPartsCount)
                        {
                            var product = new Product
                            {
                                Code = int.Parse(parts[0]),
                                Supplier = parts[1],
                                Price = decimal.Parse(parts[2]),
                                Quantity = int.Parse(parts[3])
                            };

                            products.Add(product);
                            Console.WriteLine($"Added product: {product.Code}, {product.Supplier}"); // Debug output
                        }
                        else
                        {
                            Console.WriteLine($"Skipping malformed line: {line}");
                        }
                    }
                    catch (FormatException fe)
                    {
                        Console.WriteLine($"Error parsing line '{line}': {fe.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return products;
        }

        /// <summary>
        /// Saves a list of products to a file.
        /// </summary>
        public void SaveProducts(List<Product> products, string filePath)
        {
            try
            {
                var lines = products.Select(p =>
                    $"{p.Code}{Delimiter} {p.Supplier}{Delimiter} {p.Price}{Delimiter} {p.Quantity}");

                File.WriteAllLines(filePath, lines);
                Console.WriteLine($"Saved {products.Count} products to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        public void SaveReport(string content, string filename)
        {
            try
            {
                File.WriteAllText(filename, content);
                Console.WriteLine($"Report saved to {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving report: {ex.Message}");
            }
        }
    }
}