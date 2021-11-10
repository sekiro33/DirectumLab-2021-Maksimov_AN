using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
  /// <summary>
  /// Круг. 
  /// </summary>
  public class Round : Circle
  {
    /// <summary>
    /// Координата центр-круга по оси абсцисс.
    /// </summary>
    public override double X { get => this.x; set => this.x = value; }

    /// <summary>
    /// Координата центр-круга по оси ординат.
    /// </summary>
    public override double Y { get => this.y; set => this.y = value; }

    /// <summary>
    /// Площадь круга.
    /// </summary>
    public override double Area => Math.PI * Math.Pow(this.Radius, 2);

    /// <summary>
    /// Создать круг.
    /// </summary>
    /// <param name="radius">Радиус.</param>
    public Round(double radius) : base(radius)
    { 
    }
  }
}
