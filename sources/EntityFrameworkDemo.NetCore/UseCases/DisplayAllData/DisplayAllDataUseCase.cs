using EntityFrameworkDemo.NetCore.DataAccess;
using EntityFrameworkDemo.NetCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.NetCore.UseCases.DisplayAllData;

internal class DisplayAllDataUseCase
{
    private readonly DemoDbContext demoDbContext;

    public DisplayAllDataUseCase(DemoDbContext demoDbContext)
    {
        this.demoDbContext = demoDbContext ?? throw new ArgumentNullException(nameof(demoDbContext));
    }

    public async Task Execute()
    {
        List<Customer> customers = await demoDbContext.Customers
            .ToListAsync();

        Display(customers);

        List<MyProduct> products = await demoDbContext.Products
            .OrderBy(x => x.ProductName)
            .ToListAsync();

        Display(products);

        List<CustomerOrder> orders = await demoDbContext.Orders
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
