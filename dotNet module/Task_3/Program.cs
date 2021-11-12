using System;
using System.Drawing;

namespace Task_3
{
  /// <summary>
  /// Основной класс.
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// <param name="args">Аргументы.</param>
    private static void Main(string[] args)
    {
      Ring ring = new Ring(new Point(0, 0), 10, 20);
      Triangle triangle = new Triangle(new Point(10, 10), new Point(10, 20), new Point(20, 10));
      Circle circle = new Circle(new Point(0, 0), 10);
    }
  }
}
