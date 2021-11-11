using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
  /// <summary>
  /// Обертка класса строки.
  /// </summary>
  public class StringValue
  {
    /// <summary>
    /// Строка.
    /// </summary>
    public string Value { get; private set; }

    /// <summary>
    /// Создать обертку класса строки.
    /// </summary>
    /// <param name="value">Строка.</param>
    public StringValue(string value)
    {
      this.Value = value;
    }

    /// <summary>
    /// Определяет, имеют ли два объекта StringValue одинаковое значение.
    /// </summary>
    /// <param name="obj">Объект для сравнения с текущим StringValue.</param>
    /// <returns>true если obj представленный как StringValue и если его значение совпадает с этим экземпляром; иначе - false.</returns>
    public override bool Equals(object obj)
    {
      StringValue castObj = (StringValue)obj;
      return this.Value.Equals(castObj.Value);
    }
  }
}
