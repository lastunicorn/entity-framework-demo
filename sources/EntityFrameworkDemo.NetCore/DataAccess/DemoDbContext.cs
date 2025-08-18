using EntityFrameworkDemo.NetCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.NetCore.DataAccess;

internal class DemoDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    public DbSet<MyProduct> Products { get; set; }

    public DbSet<CustomerOrder> Orders { get; set; }

    public DemoDbContext(DbContextOptions<DemoDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        new MyProductConfiguration().Configure(modelBuilder.Entity<MyProduct>());
    }
}
