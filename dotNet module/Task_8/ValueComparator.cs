using System;

namespace Task_8
{
  /// <summary>
  /// Класс для выполнения сравнения.
  /// </summary>
  /// <typeparam name="T">Тип, который реализует интерфейс IComparable.</typeparam>
  public class ValueComparator<T> where T : IComparable<T>
  {
    /// <summary>
    /// Сравнивать значения и вернуть наибольшее из них.
    /// </summary>
    /// <param name="values">Сравниваемые значения.</param>
    /// <returns>Наибольшее значение.</returns>
    public static T CompareValues(params T[] values)
    {
      if (values != null)
      {
        if (values.Length != 0)
        {
          var maxValue = values[0];
          for (int i = 1; i < values.Length; i++)
          {
            if (maxValue.CompareTo(values[i]) < 0)
              maxValue = values[i];
          }

          return maxValue;
        }
        else
        {
          throw new Exception("Пустой массив.");
        }
      }
      else
      {
        throw new NullReferenceException();
      }
    }
  }
}
