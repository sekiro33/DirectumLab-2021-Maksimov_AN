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
    /// Создать экземпляр класса Complex.
    /// </summary>
    public Complex()
    {
    }

    /// <summary>
    /// Рассчитать модуль комплексного числа.
    /// </summary>
    /// <returns>Модуль комплексного числа.</returns>
    public double GetModule()
    {
      return Math.Sqrt((this.Re * this.Re) + (this.Im * this.Im));
    }

    /// <summary>
    /// Получить строковое значение комплексного числа.
    /// </summary>
    /// <returns>Значение комплексного числа в виде строки.</returns>
    public override string ToString()
    {
      return $"Re = {this.Re}, Im = {this.Im}";
    }

    /// <summary>
    /// Сравнивает по модулю данное комплексное число с заданным и возвращает значение, указывающее, как соотносятся их значения.
    /// </summary>
    /// <param name="obj">Комплексное число для сравнения.</param>
    /// <returns>Больше нуля - это комплексное число по модулю больше чем obj.
    /// Меньше нуля - это комплексное число меньше по модулю чем obj.
    /// Ноль - эти комплексные числа равны по модулю.
    /// </returns>
    public int CompareTo(object obj)
    {
      Complex castObj = (Complex)obj;

      double thisModule = this.GetModule();
      double compareObjModule = castObj.GetModule();

      if (thisModule > compareObjModule)
        return 1;
      else if (thisModule < compareObjModule)
        return -1;
      else
        return 0;
    }
  }
}
