class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Maple Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B1001", 10, 2));
        order1.AddProduct(new Product("Pen", "P2002", 1.5, 3));

        Address address2 = new Address("10 Downing Street", "London", "England", "UK");
        Customer customer2 = new Customer("Alice Smith", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Laptop", "L3003", 1200, 1));
        order2.AddProduct(new Product("Mouse", "M4004", 15, 2));

        Console.WriteLine("--- Order 1 ---");
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}\n");

        Console.WriteLine("--- Order 2 ---");
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}