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
    /// <summary>
    /// Радиус окружности.
    /// </summary>
    private double radius;

    /// <summary>
    /// Координата центр-окружности по оси абсцисс.
    /// </summary>
    public override double X { get => this.x; set => this.x = value; }

    /// <summary>
    /// Координата центр-окружности по оси ординат.
    /// </summary>
    public override double Y { get => this.y; set => this.y = value; }

    /// <summary>
    /// Радиус окружности.
    /// </summary>
    protected double Radius { get => this.radius; set => this.radius = value >= 0 ? value : this.radius; }

    /// <summary>
    /// Длина окружности.
    /// </summary>
    public override double Perimeter => 2 * Math.PI * this.radius;

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
