using System.Drawing;

namespace Task_3
{
  /// <summary>
  /// Квадрат.
  /// </summary>
  public class Square : Rectangle
  {
    /// <summary>
    /// Высота квадрата.
    /// </summary>
    public override double Height => base.Height;

    /// <summary>
    /// Ширина квадрата.
    /// </summary>
    public override double Width => base.Width;

    /// <summary>
    /// Периметр квадрата.
    /// </summary>
    public override double Perimeter => base.Width * 4;

    /// <summary>
    /// Площадь квадрата.
    /// </summary>
    public override double Area => base.Width * base.Width;

    /// <summary>
    /// Создать квадрат на основе длины его стороны.
    /// </summary>
    /// <param name="location">Расположение левой нижней вершины квадрата.</param>
    /// <param name="side">Длина стороны квадрата.</param>
    public Square(Point location, double side) : base(location, side, side)
    {
    }
  }
}
