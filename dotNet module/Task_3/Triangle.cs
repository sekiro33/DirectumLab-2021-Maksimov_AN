using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public double SideA { get => this.sideA; set => this.sideA = value > 0 ? value : this.sideA; }

    /// <summary>
    /// Вторая сторона треугольника.
    /// </summary>
    public double SideB { get => this.sideB; set => this.sideB = value > 0 ? value : this.sideB; }

    /// <summary>
    /// Третья сторона треугольника.
    /// </summary>
    public double SideC { get => this.sideC; set => this.sideC = value > 0 ? value : this.sideC; }

    /// <summary>
    /// Координата нижней левой вершины треугольника по оси абсцисс.
    /// </summary>
    public override double X { get => this.x; set => this.x = value; }

    /// <summary>
    /// Координата нижней левой вершины треугольника по оси ординат.
    /// </summary>
    public override double Y { get => this.y; set => this.y = value; }

    /// <summary>
    /// Периметр треугольника.
    /// </summary>
    public override double Perimeter => this.sideA + this.sideB + this.sideC;

    /// <summary>
    /// Площадь треугольника.
    /// </summary>
    public override double Area => Math.Sqrt(this.Perimeter / 2 * (this.Perimeter / 2 - this.sideA) * (this.Perimeter / 2 - this.sideB) * (this.Perimeter / 2 - this.sideC));

    /// <summary>
    /// Создать треугольник на основе длин его сторон.
    /// </summary>
    /// <param name="sideA">Первая сторона.</param>
    /// <param name="sideB">Вторая сторона.</param>
    /// <param name="sideC">Третья сторона.</param>
    public Triangle(double sideA, double sideB, double sideC)
    {
      this.sideA = sideA;
      this.sideB = sideB;
      this.sideC = sideC;
      this.x = 0;
      this.y = 0;
    }
  }
}
