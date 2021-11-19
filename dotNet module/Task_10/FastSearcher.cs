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
    
    public FastSearcher()
    {
      this.maxParallelTasks = 6;
      this.minProcessedValues = 3;
    }

    /// <summary>
    /// Поиск значения в колллекции.
    /// </summary>
    /// <param name="collection">Коллекция.</param>
    /// <param name="value">Искомое значение.</param>
    public List<T> SearchValue(IEnumerable<T> collection, Predicate<T> comparator)
    {
      this.InitializeThreads(collection.Count());

      int stepSize = collection.Count() / tasks.Length;

      //int startIndex = 0;

      var results = new List<T>();

      int offset = 0;

      for (int i = 0; i < tasks.Length; i++)
      {
        tasks[i] = Task.Factory.StartNew(() => this.Search(collection.Skip(offset).Take(stepSize), comparator, results));
        offset += stepSize;
      }

      Task.WaitAll(tasks);

      return results;
    }

    private void InitializeThreads(int collectionSize)
    {
      int tasksSize = Math.Max(collectionSize / this.minProcessedValues, this.maxParallelTasks);
      this.tasks = new Task[tasksSize];
    }

    private void Search(IEnumerable<T> collection,  Predicate<T> comparator, List<T> results)
    {
      foreach (var elem in collection)
      {
        if (comparator(elem))
          results.Add(elem);
      }
    }
  }
}
