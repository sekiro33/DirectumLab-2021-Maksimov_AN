using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
  /// <summary>
  /// Значение строки.
  /// </summary>
  public class StringValue
  {
    /// <summary>
    /// Строка.
    /// </summary>
    public string Value { get; private set; }

    /// <summary>
    /// Создать экземпляр класса.
    /// </summary>
    /// <param name="value">Строка.</param>
    public StringValue(string value)
    {
      this.Value = value;
    }

    /// <summary>
    /// Определяет, имеют ли два экземпляра класса StringValue одинаковые значение строк.
    /// </summary>
    /// <param name="obj">Объект для сравнения с текущим StringValue.</param>
    /// <returns>true если obj представленный как StringValue и если его значение совпадает с этим экземпляром; иначе - false.</returns>
    public override bool Equals(object obj)
    {
      StringValue castObj = (StringValue)obj;
      return this.Value.Equals(castObj.Value);
    }

    /// <summary>
    /// Определяет, имеют ли два экземпляра класса StringValue одинаковые значения строк. 
    /// </summary>
    /// <param name="sv1">Первый сравниваемый экземпляр класса StringValue</param>
    /// <param name="sv2">Второй сравниваемый экземпляр класса StringValue</param>
    /// <returns>true если значение sv1 совпадает со значением sv2; иначе - false</returns>
    public static bool operator ==(StringValue sv1, StringValue sv2)
    {
      return sv1.Value.Equals(sv2.Value);
    }

    /// <summary>
    /// Определяет, имеют ли два экземпляра класса StringValue разные значения строк. 
    /// </summary>
    /// <param name="sv1">Первый сравниваемый экземпляр класса StringValue</param>
    /// <param name="sv2">Второй сравниваемый экземпляр класса StringValue</param>
    /// <returns>true если значение sv1 не совпадает со значением sv2; иначе - true</returns>
    public static bool operator !=(StringValue sv1, StringValue sv2)
    {
      return !sv1.Value.Equals(sv2.Value);
    }
  }
}
