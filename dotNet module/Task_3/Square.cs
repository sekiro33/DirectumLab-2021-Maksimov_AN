using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
  /// <summary>
  /// Квадрат.
  /// </summary>
  public class Square : Shape
  {
    private double side;
    /// <summary>
    /// Сторона квадрата.
    /// </summary>
    public double Side { get => side; set => side = value; }
    /// <summary>
    /// Координата нижней левой вершины квадрата по оси абцисс.
    /// </summary>
    public override double X { get => this.x; set => this.x = value; }
    /// <summary>
    /// Координата нижней левой вершины квадрата по оси ординат.
    /// </summary>
    public override double Y { get => this.y; set => this.y = value; }
    /// <summary>
    /// Периметр квадрата.
    /// </summary>
    public override double Perimeter => this.side * 4;
    /// <summary>
    /// Площадь квадрата.
    /// </summary>
    public override double Area => this.side * this.side;
    /// <summary>
    /// Создать квадрат на основе длины его стороны.
    /// </summary>
    /// <param name="side">Длина стороны квадрата.</param>
    public Square(double side)
    {
      this.side = side;
      this.x = 0;
      this.y = 0;
    }
  }
}
