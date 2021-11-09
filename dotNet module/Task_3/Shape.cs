using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
  public abstract class Shape
  {
    private double x;
    private double y;

    public double X { get { return x; } set { x = value; } }
    public double Y { get { return y; } set { y = value; } }

    public abstract double GetArea();
    public abstract double GetPerimeter();
  }
}
