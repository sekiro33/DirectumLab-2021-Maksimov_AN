using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task_12
{
  /// <summary>
  /// Program.
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// <param name="args">Параметры.</param>
    public static void Main(string[] args)
    {
      var person = new Person();
      PrintCollection(GetAllReadWritePropertiesWithIgnore(person));
    }

    /// <summary>
    /// Получить список всех read-write свойств объекта.
    /// </summary>
    /// <param name="obj">Объект в котором читаются свойства.</param>
    /// <returns>Список всех read-write свойств объекта</returns>
    private static Dictionary<string, string> GetAllReadWriteProperties(object obj)
    {
      return obj.GetType().GetProperties()
        .ToDictionary(p => p.Name, p => p.PropertyType.Name);
    }

    /// <summary>
    /// Получить список всех read-write свойств объекта, кроме свойств с аттрибутом Obsolete.
    /// </summary>
    /// <param name="obj">Объект в котором читаются свойства.</param>
    /// <returns>Список всех read-write свойств объекта, кроме свойств с аттрибутом Obsolete</returns>
    private static Dictionary<string, string> GetAllReadWritePropertiesWithIgnore(object obj)
    { 
      return obj.GetType().GetProperties()
        .Where(p => p.GetCustomAttributes(true).Any(attr => !(attr is ObsoleteAttribute)))
        .ToDictionary(p => p.Name, p => p.PropertyType.Name);
    }

    private static void PrintCollection(IEnumerable collection)
    {
      foreach (var item in collection)
        Console.WriteLine(item);
    }
  }
}
