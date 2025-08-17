# Step 2 - `DbContext`

## Overview

|      | Name                           | EF6                | EF Core                              |
| ---- | ------------------------------ | ------------------ | ------------------------------------ |
| 1)   | Base Class                     | `DbContext`        | `DbContext`                          |
| 2)   | Entity Collections             | `IDbSet<T>`        | `DbSet<T>`                           |
| 3)   | Database Context Configuration | `DbContext.ctor()` | override `DbContext.OnConfiguring()` |

## 1) Base Class

- The same: `DbContext`

## 2) Entity Collections

**EF6**:

- `IDbSet<T>`

**EF Core**:

- `DbSet<T>`

## 3) Database Context Configuration

**EF6**:

```csharp
public DemoDbContext(string connectionString)
    : base(connectionString)
{
}
```

**EF Core**:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    if (!optionsBuilder.IsConfigured)
        optionsBuilder.UseSqlServer("...");
}
```

## 