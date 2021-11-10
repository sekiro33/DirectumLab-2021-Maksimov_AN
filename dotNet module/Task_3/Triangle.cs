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
  class Triangle : Shape
  {
    private double sideA;
    private double sideB;
    private double sideC;
    /// <summary>
    /// Первая сторона треугольника.
    /// </summary>
    public double SideA { get => sideA; set => sideA = value > 0 ? value : sideA; }
    /// <summary>
    /// Вторая сторона треугольника.
    /// </summary>
    public double SideB { get => sideA; set => sideA = value > 0 ? value : sideA; }
    /// <summary>
    /// Третья сторона треугольника.
    /// </summary>
    public double SideC { get => sideA; set => sideA = value > 0 ? value : sideA; }
    /// <summary>
    /// Координата нижней левой вершины треугольника по оси абцисс.
    /// </summary>
    public override double X { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    /// <summary>
    /// Координата нижней левой вершины треугольника по оси ординат.
    /// </summary>
    public override double Y { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    /// <summary>
    /// Периметр треугольника.
    /// </summary>
    public override double Perimeter => sideA + sideB + sideC;
    /// <summary>
    /// Площадь треугольника.
    /// </summary>
    public override double Area => Math.Sqrt(this.Perimeter / 2 * (this.Perimeter / 2 - this.sideA) * (this.Perimeter / 2 - this.sideB) * (this.Perimeter / 2 - this.sideC));
  }
}
