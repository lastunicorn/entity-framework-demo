using EntityFrameworkDemo.NetCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.NetCore.DataAccess;

internal class DemoDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public DbSet<MyProduct> Products { get; set; }

    public DbSet<CustomerOrder> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //const string connectionStringName = @"Server=(localdb)\mssqllocaldb;Database=EntityFrameworkDemo;Trusted_Connection=true;MultipleActiveResultSets=true";
            const string connectionString = @"Server=localhost;Database=EntityFrameworkDemo;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True";

            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new MyProductConfiguration().Configure(modelBuilder.Entity<MyProduct>());
    }
}
