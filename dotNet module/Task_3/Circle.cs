using System;
using System.Drawing;

namespace Task_3
{
  /// <summary>
  /// Окружность.
  /// </summary>
  public class Circle : Shape
  {
    private double radius;

    /// <summary>
    /// Радиус окружности.
    /// </summary>
    protected double Radius => this.radius;

    /// <summary>
    /// Длина окружности.
    /// </summary>
    public override double Perimeter => 2 * Math.PI * this.radius;

    /// <summary>
    /// Площадь окружности.
    /// </summary>
    public override double Area => 0;

    /// <summary>
    /// Создать окружность.
    /// </summary>
    /// <param name="location">Расположение центра окружности.</param>
    /// <param name="radius">Радиус.</param>
    public Circle(Point location, double radius) : base(location)
    {
      this.radius = radius;
    }
  }
}
