using System.Data.Entity;
using EntityFrameworkDemo.NetFramework.Entities;

namespace EntityFrameworkDemo.NetFramework.DataAccess
{
    internal class DemoDbContext : DbContext
    {
        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<MyProduct> Products { get; set; }

        public IDbSet<CustomerOrder> Orders { get; set; }

        public DemoDbContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new MyProductConfiguration());
        }
    }
}