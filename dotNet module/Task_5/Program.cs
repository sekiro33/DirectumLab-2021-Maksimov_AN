using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_5
{
  /// <summary>
  /// Program.
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// <param name="args">Аргументы.</param>
    private static void Main(string[] args)
    {
      var twoComplexes = new ArrayList() { new Complex() { Re = 3, Im = 5 }, new Complex { Re = 2, Im = 2 } };
      Console.WriteLine("До сортировки:");
      PrintValues(twoComplexes);
      twoComplexes.Sort();
      Console.WriteLine("После сортировки:");
      PrintValues(twoComplexes);
    }

    /// <summary>
    /// Вывод элементов списка на экран.
    /// </summary>
    /// <param name="list">Список.</param>
    private static void PrintValues(ArrayList list)
    {
      foreach (var value in list)
      {
        Console.WriteLine(value);
      }
    }
  }
}
