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
    /// Координата центр-круга по оси абцисс.
    /// </summary>
    public override double X { get => x; set => x = value; }
    /// <summary>
    /// Координата центр-круга по оси ординат.
    /// </summary>
    public override double Y { get => y; set => y = value; }
    /// <summary>
    /// Площадь круга.
    /// </summary>
    public override double Area => Math.PI * Math.Pow(radius, 2);
    /// <summary>
    /// Создать круг.
    /// </summary>
    /// <param name="radius">Радиус.</param>
    public Round(double radius) : base(radius)
    { 
    }
  }
}
