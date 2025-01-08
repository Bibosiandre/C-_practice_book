using Microsoft.EntityFrameworkCore;

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
    string path = Path.Combine(
      Environment.CurrentDirectory, "Northwind.db");

    optionsBuilder.UseSqlite($"Filename={path}");
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

    // добавлено для «исправления» поддержки десятичных чисел в SQLite
    modelBuilder.Entity<Product>()
      .Property(product => product.Cost)
      .HasConversion<double>();
  }
}
