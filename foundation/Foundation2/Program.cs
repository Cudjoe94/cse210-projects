class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        List<Product> products1 = new List<Product>
        {
            new Product("Widget", "W123", 10.00m, 2),
            new Product("Gadget", "G456", 15.00m, 1)
        };
        Order order1 = new Order(products1, customer1);

        Address address2 = new Address("456 Elm St", "Othertown", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        List<Product> products2 = new List<Product>
        {
            new Product("Thingamajig", "T789", 20.00m, 3),
            new Product("Doohickey", "D012", 25.00m, 2)
        };
        Order order2 = new Order(products2, customer2);

        Console.WriteLine("Order 1:");
        Console.WriteLine($"Total Cost: {order1.GetTotalCost()}");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine("\nOrder 2:");
        Console.WriteLine($"Total Cost: {order2.GetTotalCost()}");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
    }
}

