using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10
{
  /// <summary>
  /// Класс для реализации параллельного поиска.
  /// </summary>
  public class FastSearcher
  {
    private int maxParallelTasks;

    private int minProcessedValues;

    /// <summary>
    /// Максимальное количество параллельных задач.
    /// </summary>
    public int MaxParrallelTasks
    {
      get => this.maxParallelTasks;

      set
      {
        if (value >= 1)
          this.maxParallelTasks = value;
        else
          throw new ArgumentException(value.ToString());
      }
    }

    /// <summary>
    /// Минимальное количество значений обрабатываемых в одном потоке.
    /// </summary>
    public int MinProcessedValues
    {
      get => this.minProcessedValues;

      set
      {
        if (value >= 1)
          this.minProcessedValues = value;
        else
          throw new ArgumentException(value.ToString());
      }
    }
  }
}
