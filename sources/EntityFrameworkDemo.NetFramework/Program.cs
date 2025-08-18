using EntityFrameworkDemo.NetFramework.DataAccess;
using EntityFrameworkDemo.NetFramework.UseCases.DisplayAllData;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.NetFramework
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Entity Framework Demo");

            await ExecuteUseCase();
        }

        private static async Task ExecuteUseCase()
        {
            using (DemoDbContext dbContext = CreateDbContext())
            {
                DisplayAllDataUseCase useCase = new DisplayAllDataUseCase(dbContext);
                await useCase.Execute();
            }
        }

        private static DemoDbContext CreateDbContext()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return new DemoDbContext(connectionString);
        }
    }
}