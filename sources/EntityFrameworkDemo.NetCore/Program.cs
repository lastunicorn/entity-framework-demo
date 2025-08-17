using EntityFrameworkDemo.NetCore.DataAccess;
using EntityFrameworkDemo.NetCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.NetCore;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Entity Framework Demo");
        await DisplayCustomers();
    }

    private static async Task DisplayCustomers()
    {
        using DemoDbContext context = new();

        List<Customer> customers = await context.Customers
            .ToListAsync();

        Display(customers);

        List<MyProduct> products = await context.Products
            .OrderBy(x => x.ProductName)
            .ToListAsync();

        Display(products);

        List<CustomerOrder> orders = await context.Orders
            .OrderByDescending(x => x.OrderDate)
            .ToListAsync();

        Display(orders);
    }

    private static void Display(IEnumerable<Customer> customers)
    {
        Console.WriteLine();
        Console.WriteLine("Customers:");

        int count = 0;

        foreach (Customer customer in customers)
        {
            Console.WriteLine($"- {customer.FirstName} {customer.LastName}, Age: {customer.Age}");
            count++;
        }

        Console.WriteLine($"Found {count} customers.");
    }

    private static void Display(IEnumerable<MyProduct> products)
    {
        Console.WriteLine();
        Console.WriteLine("Products:");

        int count = 0;

        foreach (MyProduct product in products)
        {
            Console.WriteLine($"- {product.ProductName}, Price: {product.Price:C}");
            count++;
        }

        Console.WriteLine($"Found {count} products.");
    }

    private static void Display(IEnumerable<CustomerOrder> orders)
    {
        Console.WriteLine();
        Console.WriteLine("Orders:");

        int count = 0;

        foreach (CustomerOrder order in orders)
        {
            Console.WriteLine($"- {order.OrderDate:d}, Product: {order.Product.ProductName}");
            count++;
        }

        Console.WriteLine($"Found {count} orders.");
    }
}
