using System;

class Program
{
    static void Main(string[] args)
    {
    
        Address address1 = new Address("Aso Street 3431", "Jinja", "Bugembe", "Uganda");
        Customer customer1 = new Customer("Nassali Aisha", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Smart TV", "ST-101", 29.90, 2));
        order1.AddProduct(new Product("USB-C Hub", "UC-204", 45.00, 1));
        order1.AddProduct(new Product("Laptop Stand", "LS-309", 19.99, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Order Total: ${order1.GetTotalCost():F2}");
        Console.WriteLine();

        // Order 2
        Address address2 = new Address("Main Street 4001", "Iganga", "Nabidogha", "Uganda");
        Customer customer2 = new Customer("Mengi Mariam", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mechanical Keyboard", "MK-512", 89.99, 1));
        order2.AddProduct(new Product("Monitor Light Bar", "ML-088", 34.99, 2));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Order Total: ${order2.GetTotalCost():F2}");
    }
}