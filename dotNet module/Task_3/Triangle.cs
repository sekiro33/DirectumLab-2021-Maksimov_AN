using System;
using System.Drawing;

namespace Task_3
{
  /// <summary>
  /// Треугольник.
  /// </summary>
  public class Triangle : Shape
  {
    private double sideA;
    private double sideB;
    private double sideC;

    /// <summary>
    /// Первая сторона треугольника.
    /// </summary>
    public double SideA => this.sideA;

    /// <summary>
    /// Вторая сторона треугольника.
    /// </summary>
    public double SideB => this.sideB;

    /// <summary>
    /// Третья сторона треугольника.
    /// </summary>
    public double SideC => this.sideC;

    /// <summary>
    /// Периметр треугольника.
    /// </summary>
    public override double Perimeter => this.sideA + this.sideB + this.sideC;

    /// <summary>
    /// Площадь треугольника.
    /// </summary>
    public override double Area => Math.Sqrt(this.Perimeter / 2 * (this.Perimeter / 2 - this.sideA) * (this.Perimeter / 2 - this.sideB) * (this.Perimeter / 2 - this.sideC));

    /// <summary>
    /// Создать треугольник на основе его вершин. Первая вершина так же задёт расположение треугольника.
    /// </summary>
    /// <param name="apex1">Первая вершина.</param>
    /// <param name="apex2">Вторая вершина.</param>
    /// <param name="apex3">Третья вершина.</param>
    public Triangle(Point apex1, Point apex2, Point apex3) : base(apex1)
    {
      this.sideA = this.Distance(apex1, apex2);
      this.sideB = this.Distance(apex2, apex3);
      this.sideC = this.Distance(apex1, apex2);
    }
  }
}
