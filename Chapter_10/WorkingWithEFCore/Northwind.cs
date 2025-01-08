using Microsoft.EntityFrameworkCore; // DbContext, DbContextOptionsBuilder

using static System.Console;

namespace Packt.Shared;

// это управляет подключением к базе данных
public class Northwind : DbContext
{
  // эти свойства сопоставляются с таблицами в базе данных
  public DbSet<Category>? Categories { get; set; }
  public DbSet<Product>? Products { get; set; }

  protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseLazyLoadingProxies();

    if (ProjectConstants.DatabaseProvider == "SQLite")
    {
      string path = Path.Combine(
        Environment.CurrentDirectory, "Northwind.db");

      WriteLine($"Using {path} database file.");

      optionsBuilder.UseSqlite($"Filename={path}");
    }
    else
    {
      string connection = "Data Source=.;" +
        "Initial Catalog=Northwind;" +
        "Integrated Security=true;" +
        "MultipleActiveResultSets=true;";

      optionsBuilder.UseSqlServer(connection);
    }
  }

  protected override void OnModelCreating(
    ModelBuilder modelBuilder)
  {

    // пример использования Fluent API вместо атрибутов
    // чтобы ограничить длину имени категории до 15
    modelBuilder.Entity<Category>()
      .Property(category => category.CategoryName)
      .IsRequired() // NOT NULL
      .HasMaxLength(15);

    if (ProjectConstants.DatabaseProvider == "SQLite")
    {
    // добавлено, чтобы "исправить" отсутствие поддержки десятичных чисел в SQLite
      modelBuilder.Entity<Product>()
        .Property(product => product.Cost)
        .HasConversion<double>();
    }

    // глобальный фильтр для удаления продуктов, снятых с производства
    modelBuilder.Entity<Product>()
      .HasQueryFilter(p => !p.Discontinued);
  }
}
