using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
  /// <summary>
  /// Абстрактная фигура.
  /// </summary>
  public abstract class Shape
  {
    protected double x;
    protected double y;

    /// <summary>
    /// Координата расположения фигуры по оси абсцисс.
    /// </summary>
    public abstract double X { get; set; }

    /// <summary>
    /// Координата расположения фигуры по оси ординат.
    /// </summary>
    public abstract double Y { get; set; }

    /// <summary>
    /// Периметр фигуры.
    /// </summary>
    public abstract double Perimeter { get; }

    /// <summary>
    /// Площадь фигуры.
    /// </summary>
    public abstract double Area { get; }
  }
}
