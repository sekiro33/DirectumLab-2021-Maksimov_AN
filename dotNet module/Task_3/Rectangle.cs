using System.Drawing;

namespace Task_3
{
  /// <summary>
  /// Прямоугольник.
  /// </summary>
  public class Rectangle : Shape
  {
    private double width;
    private double height;

    /// <summary>
    /// Ширина прямоугольника.
    /// </summary>
    public virtual double Width => this.width;

    /// <summary>
    /// Высота прямоугольника.
    /// </summary>
    public virtual double Height => this.height;

    /// <summary>
    /// Периметр прямоугольника.
    /// </summary>
    public override double Perimeter => (this.width + this.height) * 2;

    /// <summary>
    /// Площадь прямоугольника.
    /// </summary>
    public override double Area => this.width * this.height;

    /// <summary>
    /// Создать прямоугольник на основе высоты и ширины его сторон.
    /// </summary>
    /// <param name="location">Расположение левой нижней вершины прямоугольника.</param>
    /// <param name="width">Ширина прямоугольника.</param>
    /// <param name="height">Высота прямоугольника.</param>
    public Rectangle(Point location, double width, double height) : base(location)
    {
      this.width = width;
      this.height = height;
    }
  }
}
