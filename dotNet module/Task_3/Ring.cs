using System;
using System.Drawing;

namespace Task_3
{
  /// <summary>
  /// Кольцо.
  /// </summary>
  public class Ring : Circle
  {
    private double innerRadius;

    /// <summary>
    /// Радиус внутренней окружности.
    /// </summary>
    public double InnerRadius => this.innerRadius;

    /// <summary>
    /// Радиус внешней окружности.
    /// </summary>
    public double OuterRadius => this.Radius;

    /// <summary>
    /// Периметр кольца.
    /// </summary>
    public override double Perimeter => 0;

    /// <summary>
    /// Площадь кольца.
    /// </summary>
    public override double Area => Math.PI * ((this.Radius * this.Radius) - (this.innerRadius * this.innerRadius));

    /// <summary>
    /// Создать кольцо.
    /// </summary>
    /// <param name="location">Расположение центра кольца.</param>
    /// <param name="innerRadius">Радиус внутренней окружности.</param>
    /// <param name="outerRaidus">Радиус внешней окружности.</param>
    public Ring(Point location, double innerRadius, double outerRaidus) : base(location, outerRaidus)
    {
      if (innerRadius > outerRaidus)
        throw new Exception("Радиус внутренней окружности больше радиуса внешней.");
      this.innerRadius = innerRadius;
    }
  }
}
