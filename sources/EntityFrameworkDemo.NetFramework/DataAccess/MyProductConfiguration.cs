using System.Data.Entity.ModelConfiguration;
using EntityFrameworkDemo.NetFramework.Entities;

namespace EntityFrameworkDemo.NetFramework.DataAccess
{
    public sealed class MyProductConfiguration : EntityTypeConfiguration<MyProduct>
    {
        public MyProductConfiguration()
        {
            ToTable("Products");
            HasKey(x => x.Id);

            Property(x => x.ProductName)
                .HasColumnName("Name")
                .IsRequired();
        }
    }
}