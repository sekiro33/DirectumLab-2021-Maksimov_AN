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
    /// Вычисление расстояния между точками.
    /// </summary>
    /// <param name="point1">Первая точка.</param>
    /// <param name="point2">Вторая точка.</param>
    /// <returns>Расстояние между точками.</returns>
    public double Distance(Point point1, Point point2)
    {
      return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
    }

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
