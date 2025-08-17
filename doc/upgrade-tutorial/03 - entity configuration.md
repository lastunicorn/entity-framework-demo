# Step 3 - Entity Configuration

The mapping between the entity and the database table can be done in three ways. All three work in both Entity Framework versions:

1. Name Matching
2. Attributes
3. Entity Configuration Classes

## 1) Name Matching

Nothing explicitly to do, the tables and columns are mapped correctly if the entity class and its properties have matching names.

## 2) Attributes

Attributes like `Table`, `Column`, `ForeignKey`, etc. are used on the entity class and properties to specify the matching table names and columns.

```csharp
[Table("Orders")]
internal class CustomerOrder
{
    public Guid Id { get; set; }

    [Column("Date")]
    public DateTime OrderDate { get; set; }

    [Column("Product")]
    public Guid ProductId { get; set; }

    [ForeignKey("ProductId")]
    public MyProduct Product { get; set; }
}
```

They work in both Entity Framework versions without any change.

## 3) Entity Configuration Classes

Separate classes are used to configure the mapping between entities and database tables.

The mechanism works in both Entity Framework versions, but there are a few differences:

### a) Create Entity Configuration Class

**EF6**:

- Inherit from `EntityTypeConfiguration<T>` class.
- Configuration done in constructor.

```csharp
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
```

**EF Core**:

- Implement `IEntityTypeConfiguration<T>` interface.
- Configuration done in `Configure` method.

```csharp
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
```

### b) Use Entity Configuration Class

**EF6**:

- Use configuration class in `DbContext.OnModelCreating(DbModelBuilder)`

```csharp
protected override void OnModelCreating(DbModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Configurations.Add(new MyProductConfiguration());
}
```

**EF Core**:

- Use configuration class in `DbContext.OnModelCreating(ModelBuilder)`

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    new MyProductConfiguration().Configure(modelBuilder.Entity<MyProduct>());
}
```

#### 