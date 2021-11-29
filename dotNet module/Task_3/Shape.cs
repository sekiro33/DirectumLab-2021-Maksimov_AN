using System;
using System.Drawing;

namespace Task_3
{
  /// <summary>
  /// Абстрактная фигура.
  /// </summary>
  public abstract class Shape
  {
    /// <summary>
    /// Положение фигруы.
    /// </summary>
    public Point Location { get; set; }

    /// <summary>
    /// Периметр фигуры.
    /// </summary>
    public abstract double Perimeter { get; }

    /// <summary>
    /// Площадь фигуры.
    /// </summary>
    public abstract double Area { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="location">Расположение фигуры.</param>
    protected Shape(Point location)
    {
      this.Location = location;
    }
  }
}
