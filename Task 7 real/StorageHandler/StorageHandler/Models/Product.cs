using System;
using System.Collections.Generic;
namespace StorageHandler.Models
{
    /// <summary>
    /// Represents a product with properties such as code, supplier, price, quantity, and total value.
    /// </summary>
    public class Product
    {
        public int Code { get; set; }
        public string Supplier { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal TotalValue => Price * Quantity;

        public string Name => Enum.IsDefined(typeof(ProductName), Code)
            ? ((ProductName)Code).ToString()
            : "Unknown product";

        /// <summary>
        /// Returns a string representation of the product, including its code, name, supplier, price, quantity, and total value.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Code: {Code}\nName: {Name}\nSupplier: {Supplier}\n" +
                   $"Price: {Price}\nQuantity: {Quantity}\nTotal value: {TotalValue}\n";
        }
    }
}
