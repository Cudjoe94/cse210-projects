// Class Diagram Description:
//
// 1. Class: Order
//    - Attributes: Products (List<Product>), Customer (Customer)
//    - Methods: CalculateTotalCost(), GetPackingLabel(), GetShippingLabel()
//
// 2. Class: Product
//    - Attributes: Name (string), ProductId (string), Price (decimal), Quantity (int)
//    - Methods: GetTotalCost()
//
// 3. Class: Customer
//    - Attributes: Name (string), Address (Address)
//    - Methods: IsInUSA()
//
// 4. Class: Address
//    - Attributes: Street (string), City (string), State (string), Country (string)
//    - Methods: IsInUSA(), ToString()

using System;
using System.Collections.Generic;

namespace OnlineOrderingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create sample addresses
            Address address1 = new Address("123 Main St", "New York", "NY", "USA");
            Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

            // Create sample customers
            Customer customer1 = new Customer("John Doe", address1);
            Customer customer2 = new Customer("Jane Smith", address2);

            // Create sample products
            Product product1 = new Product("Laptop", "P001", 1000.00m, 1);
            Product product2 = new Product("Mouse", "P002", 25.00m, 2);
            Product product3 = new Product("Keyboard", "P003", 50.00m, 1);
            Product product4 = new Product("Monitor", "P004", 200.00m, 1);

            // Create sample orders
            Order order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            Order order2 = new Order(customer2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);

            // Display order details
            Console.WriteLine("Order 1 Details:");
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}");

            Console.WriteLine();

            Console.WriteLine("Order 2 Details:");
            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}");
        }
    }

    public class Order
    {
        private List<Product> Products;
        private Customer Customer;

        public Order(Customer customer)
        {
            Customer = customer;
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal total = 0;
            foreach (var product in Products)
            {
                total += product.GetTotalCost();
            }

            // Add shipping cost
            total += Customer.IsInUSA() ? 5.00m : 35.00m;
            return total;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (var product in Products)
            {
                label += $"- {product.Name} (ID: {product.ProductId})\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{Customer.Name}\n{Customer.Address}";
        }
    }

    public class Product
    {
        public string Name { get; private set; }
        public string ProductId { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public Product(string name, string productId, decimal price, int quantity)
        {
            Name = name;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public decimal GetTotalCost()
        {
            return Price * Quantity;
        }
    }

    public class Customer
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }

        public Customer(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public bool IsInUSA()
        {
            return Address.IsInUSA();
        }
    }

    public class Address
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }

        public Address(string street, string city, string state, string country)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
        }

        public bool IsInUSA()
        {
            return Country.ToLower() == "usa";
        }

        public override string ToString()
        {
            return $"{Street}\n{City}, {State}\n{Country}";
        }
    }
}
