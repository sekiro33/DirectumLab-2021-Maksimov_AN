using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task_10
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
      var innerList = new List<int>();
      innerList.Add(1);
      innerList.Add(2);
      innerList.Add(3);
      innerList.Add(4);
      innerList.Add(5);
      innerList.Add(6);
      innerList.Add(7);
      innerList.Add(8);
      innerList.Add(9);
      innerList.Add(10);
      innerList.Add(11);
      innerList.Add(12);
      innerList.Add(13);
      innerList.Add(14);
      innerList.Add(15);
      innerList.Add(16);
      innerList.Add(17);
      innerList.Add(18);
      innerList.Add(19);
      innerList.Add(20);
      innerList.Add(21);
      innerList.Add(22);
      innerList.Add(23);
      innerList.Add(24);
      Console.WriteLine(innerList.FindAll((x) => x == 3).Count);
      var searcher = new FastSearcher<int>();
      var task = Task.Factory.StartNew(() => searcher.SearchValue(innerList, (x) => x == 3));
      task.Wait();
      Console.WriteLine(task.Result.FindAll((x) => x == 3).Count);
    }
  }
}
