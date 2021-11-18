using System;
using System.Drawing;

namespace Task_3
{
  /// <summary>
  /// Расширение для класса Point.
  /// </summary>
  public static class PointExtension
  {
    /// <summary>
    /// Вычисление расстояния между точками.
    /// </summary>
    /// <param name="point1">Первая точка.</param>
    /// <param name="point2">Вторая точка.</param>
    /// <returns>Расстояние между точками.</returns>
    public static double Distance(this Point point1, Point point2)
    {
      return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2));
    }
  }
}
