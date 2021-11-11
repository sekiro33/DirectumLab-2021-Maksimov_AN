using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
  /// <summary>
  /// Комплексное число.
  /// </summary>
  public class Complex : IComparable
  {
    /// <summary>
    /// Действительная часть числа.
    /// </summary>
    public double Re { get; set; }

    /// <summary>
    /// Мнимая часть числа.
    /// </summary>
    public double Im { get; set; }

    /// <summary>
    /// Модуль комплексного числа.
    /// </summary>
    public double Module => Math.Sqrt((this.Re * this.Re) + (this.Im * this.Im));

    /// <summary>
    /// Создать экземпляр класса Complex.
    /// </summary>
    public Complex()
    {
    }

    /// <summary>
    /// Получить строковое значение комплексного числа.
    /// </summary>
    /// <returns>Значение комплексного числа в виде строки.</returns>
    public override string ToString()
    {
      return $"Re = {this.Re}, Im = {this.Im}";
    }

    /// <inheritdoc/>
    public int CompareTo(object obj)
    {
      Complex comparedComplex = (Complex)obj;

      double thisModule = this.Module;
      double comparedModule = comparedComplex.Module;

      return (int)(thisModule - comparedModule);
    }
  }
}
