using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
  /// <summary>
  /// Кольцо.
  /// </summary>
  public class Ring : Shape
  {
    private double outerRaidus;
    private double innerRadius;
    /// <summary>
    /// Радиус внутренней окружности.
    /// </summary>
    public double InnerRadius { get => innerRadius; set => this.innerRadius = value; }
    /// <summary>
    /// Радиус внешней окружности.
    /// </summary>
    public double OuterRadius { get => outerRaidus; set => this.outerRaidus = value; }
    /// <summary>
    /// Координата центр-кольца по оси абцисс.
    /// </summary>
    public override double X { get => this.x; set => this.x = value; }
    /// <summary>
    /// Координата центр-кольца по оси ординат.
    /// </summary>
    public override double Y { get => this.y; set => this.y = value; }
    public override double Perimeter => throw new NotImplementedException();
    /// <summary>
    /// Площадь кольца.
    /// </summary>
    public override double Area => Math.PI * (outerRaidus * outerRaidus - innerRadius * innerRadius);
    /// <summary>
    /// Создать кольцо.
    /// </summary>
    /// <param name="innerRadius">Радиус внутренней окружности.</param>
    /// <param name="outerRaidus">Радиус внешней окружности.</param>
    public Ring(double innerRadius, double outerRaidus)
    {
      this.innerRadius = innerRadius;
      this.outerRaidus = outerRaidus;
      this.x = 0;
      this.y = 0;
    }
  }
}
