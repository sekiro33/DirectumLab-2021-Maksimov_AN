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

    public abstract double X { get; set; }
    public abstract double Y { get; set; }
    public abstract double Perimeter { get; }
    public abstract double Area { get; }

  }
}
