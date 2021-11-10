using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public double Width { get => this.width; set => this.width = value; }

    /// <summary>
    /// Высота прямоугольника.
    /// </summary>
    public double Height { get => this.height; set => this.height = value; }

    /// <summary>
    /// Координата нижней левой вершины прямоугольника по оси абсцисс.
    /// </summary>
    public override double X { get => this.x; set => this.x = value; }

    /// <summary>
    /// Координата нижней левой вершины прямоугольника по оси ординат.
    /// </summary>
    public override double Y { get => this.y; set => this.y = value; }

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
    /// <param name="width">Ширина прямоугольника.</param>
    /// <param name="height">Высота прямоугольника.</param>
    public Rectangle(double width, double height)
    {
      this.width = width;
      this.height = height;
      this.x = 0;
      this.y = 0;
    }
  }
}
