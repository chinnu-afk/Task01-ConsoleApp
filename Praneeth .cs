using System;
using System.Collections.Generic;

namespace Task01ConsoleApp
{
    // Models one product. Properties are used instead of public fields.
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }

        public Product(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Product name cannot be empty.", nameof(name));
            }

            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be greater than zero.");
            }

            Name = name.Trim();
            Price = price;
        }

        public string GetDescription()
        {
            return $"{Name} - ₹{Price:F2}";
        }
    }

    // Manages a small collection of products.
    public class Inventory
    {
        private readonly List<Product> _products = new();

        public void AddProduct(Product product)
        {
            if (product is null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            _products.Add(product);
        }

        public void PrintProducts()
        {
            Console.WriteLine("Inventory");
            Console.WriteLine("---------");

            if (_products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }

            foreach (Product product in _products)
            {
                Console.WriteLine(product.GetDescription());
            }

            Console.WriteLine($"Total products: {_products.Count}");
        }
    }

    internal class Program
    {
        private static void Main()
        {
            try
            {
                Inventory inventory = new Inventory();

                inventory.AddProduct(new Product("Notebook", 55.00m));
                inventory.AddProduct(new Product("Pen", 12.50m));
                inventory.AddProduct(new Product("Backpack", 799.00m));

                inventory.PrintProducts();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input error: {ex.Message}");
            }
        }
    }
}
