using System;

namespace Task_2
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
    public static void Main(string[] args)
    {
      var meeting = new Meeting("Встреча", new DateTime(2021, 11, 4, 10, 0, 0), new DateTime(2021, 11, 5, 11, 0, 0));
      Console.ReadKey();
    }
  }
}
