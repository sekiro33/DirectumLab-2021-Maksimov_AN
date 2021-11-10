using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
  /// <summary>
  /// Окружность.
  /// </summary>
  public class Circle : Shape
  {
    protected double radius;
    /// <summary>
    /// Координата центр-окружности по оси абцисс.
    /// </summary>
    public override double X { get => x; set => x = value; }
    /// <summary>
    /// Координата центр-окружности по оси ординат.
    /// </summary>
    public override double Y { get => y; set => y = value; }
    /// <summary>
    /// Радиус окружности.
    /// </summary>
    public double Radius { get => radius; set => radius = value >= 0 ? value : radius; }
    /// <summary>
    /// Длина окружности.
    /// </summary>
    public override double Perimeter => 2 * Math.PI * radius;
    /// <summary>
    /// Площадь окружности.
    /// </summary>
    public override double Area { get => 0; }
    /// <summary>
    /// Создать окружность.
    /// </summary>
    /// <param name="radius">Радиус.</param>
    public Circle(double radius)
    {
      this.radius = radius;
      this.x = 0;
      this.y = 0;
    }
  }
}
