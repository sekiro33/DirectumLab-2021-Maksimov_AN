using System;
using System.Collections.Generic;
using System.Linq;
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
      var innerList = GetStandartList();
      Console.WriteLine(innerList.FindAll((x) => x % 2 == 0).Count);
      var searcher = new FastSearcher<int>();
      var task = searcher.SearchValue(innerList, (x) => x % 2 == 0);
      task.Wait();
      Console.WriteLine(task.Result.Where((x) => x % 2 == 0).Count());
    }

    private static List<int> GetStandartList()
    {
      return Enumerable.Range(-1000, 3000).OrderBy((item) => Guid.NewGuid()).ToList();
    }
  }
}
