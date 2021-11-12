using System;
using System.Drawing;

namespace Task_3
{
  /// <summary>
  /// Круг. 
  /// </summary>
  public class Round : Circle
  {
    /// <summary>
    /// Площадь круга.
    /// </summary>
    public override double Area => Math.PI * Math.Pow(this.Radius, 2);

    /// <summary>
    /// Создать круг.
    /// </summary>
    /// <param name="location">Расположение центра круга.</param>
    /// <param name="radius">Радиус.</param>
    public Round(Point location, double radius) : base(location, radius)
    { 
    }
  }
}
