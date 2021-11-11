using System;

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
      Console.WriteLine(new StringValue("A") != new StringValue("AA"));
      Console.ReadKey();
    }
  }
}
