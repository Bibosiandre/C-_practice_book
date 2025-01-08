namespace Packt;

public abstract class Shape
{
  // поля
  protected double height;
  protected double width;

  // характеристики
  public virtual double Height
  {
    get
    {
      return height;
    }
    set
    {
      height = value;
    }
  }

  public virtual double Width
  {
    get
    {
      return width;
    }
    set
    {
      width = value;
    }
  }

  // Область должна быть реализована производными классами
  // как свойство, доступное только для чтения
  public abstract double Area { get; }
}