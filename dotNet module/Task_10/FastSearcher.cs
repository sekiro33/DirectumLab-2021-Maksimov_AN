using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_10
{
  /// <summary>
  /// Класс для реализации параллельного поиска.
  /// </summary>
  public class FastSearcher<T>
  {
    private int maxParallelTasks;

    private int minProcessedValues;

    private Task[] tasks;

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

    /// <summary>
    /// Поиск значения в колллекции.
    /// </summary>
    /// <param name="collection">Коллекция.</param>
    /// <param name="value">Искомое значение.</param>
    public void SearchValue(IEnumerable<T> collection, Predicate<T> comparator)
    {
      this.InitializeThreads(collection.Count() > this.maxParallelTasks ? this.maxParallelTasks : collection.Count());

      int sizeProcessedValues = collection.Count() / this.tasks.Length;
    }

    private void InitializeThreads(int collectionSize)
    {
      int taskSize = collectionSize > this.minProcessedValues
        ? (collectionSize % this.maxParallelTasks == 0 ? this.maxParallelTasks : this.maxParallelTasks + 1)
        : 1;
      this.tasks = new Task[taskSize];
    }

    private int CalcCountOfTasks(int collectionSize)
    {
      return this.minProcessedValues < collectionSize / this.MaxParrallelTasks ? collectionSize / this.MaxParrallelTasks : 
    }

    private List<T> Search(IEnumerable<T> collection,  int startIndex, int endIndex, Predicate<T> comparator)
    {
      var results = new List<T>();
      for (int i = startIndex; i < endIndex; i++)
      {
        if (comparator(collection.ElementAt(i)))
          results.Add(collection.ElementAt(i));
      }

      return results;
    }
  }
}
