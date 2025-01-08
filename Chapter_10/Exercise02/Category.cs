using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.Shared;

public class Category
{
  // эти свойства сопоставляются со столбцами в базе данных
  public int CategoryId { get; set; }

  public string? CategoryName { get; set; }

  [Column(TypeName = "ntext")]
  public string? Description { get; set; }

  // определяет свойство навигации для связанных строк
  public virtual ICollection<Product> Products { get; set; }

  public Category()
  {
    // чтобы позволить разработчикам добавлять продукты в категорию, мы должны
    // инициализируем свойство навигации пустым списком
    Products = new HashSet<Product>();
  }
}
