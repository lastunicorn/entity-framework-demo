using EntityFrameworkDemo.NetCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkDemo.NetCore.DataAccess
{
    public sealed class MyProductConfiguration : IEntityTypeConfiguration<MyProduct>
    {
        public void Configure(EntityTypeBuilder<MyProduct> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductName)
                .HasColumnName("Name")
                .IsRequired();
        }
    }
}