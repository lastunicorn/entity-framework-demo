using EntityFrameworkDemo.NetCore.DataAccess;
using EntityFrameworkDemo.NetCore.UseCases.DisplayAllData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EntityFrameworkDemo.NetCore;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Entity Framework Demo");

        IHost host = CreateHostBuilder(args)
            .Build();

        await ExecuteUseCase(host);
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);

        hostBuilder.ConfigureAppConfiguration((context, config) =>
        {
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        });

        hostBuilder.ConfigureServices((context, services) =>
        {
            string connectionString = context.Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DemoDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<DisplayAllDataUseCase>();
        });

        return hostBuilder;
    }

    private static async Task ExecuteUseCase(IHost host)
    {
        using IServiceScope scope = host.Services.CreateScope();
        DisplayAllDataUseCase useCase = scope.ServiceProvider.GetRequiredService<DisplayAllDataUseCase>();
        await useCase.Execute();
    }
}
