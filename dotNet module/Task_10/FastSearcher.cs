using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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

    private Task<IEnumerable<T>>[] tasks;

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
          throw new ArgumentException("Количество параллельных задач не может быть меньше 1. Устанавливаемое значение: " + value.ToString());
      }
    }

    /// <summary>
    /// Минимальное количество значений обрабатываемых в одной задаче.
    /// </summary>
    public int MinProcessedValues
    {
      get => this.minProcessedValues;

      set
      {
        if (value >= 1)
          this.minProcessedValues = value;
        else
          throw new ArgumentException("Количество значений обрабатываемых в одном потоке не может быть меньше 1. Устанавливаемое значение: " + value.ToString());
      }
    }
    
    /// <summary>
    /// Создаёт экземпляр класса со стандартными значениями минимального количества обрабатываемых значений в одном потоке и максимального количества паралелльных задач.
    /// </summary>
    public FastSearcher()
    {
      this.maxParallelTasks = 6;
      this.minProcessedValues = 3;
    }

    /// <summary>
    /// Создаёт экземпляр класса с переданными значениями минимального количества обрабатываемых значений в одном потоке и максимальным количеством паралелльных задач.
    /// </summary>
    /// <param name="maxParallelTasks">Максимальное количество параллельных задач.</param>
    /// <param name="minProcessedValues">Минимальное количество обрабатываемых значений в одном потоке.</param>
    public FastSearcher(int maxParallelTasks, int minProcessedValues)
    {
      this.MaxParrallelTasks = maxParallelTasks;
      this.MinProcessedValues = minProcessedValues;
    }

    /// <summary>
    /// Поиск значения в колллекции.
    /// </summary>
    /// <param name="collection">Коллекция.</param>
    /// <param name="comparator">Условие сравнения.</param>
    public async Task<IEnumerable<T>> SearchValue(IEnumerable<T> collection, Predicate<T> comparator)
    {
      this.InitializeTasks(collection.Count());

      int stepSize = collection.Count() / this.tasks.Length;
      int offset = 0;

      for (int i = 0; i < this.tasks.Length; i++)
      {
        var currentCollection = collection.Skip(offset).Take(stepSize);
        this.tasks[i] = this.Search(currentCollection, comparator);
        offset += stepSize;
      }

      return await Task.WhenAll(this.tasks).ContinueWith((task) => task.Result.SelectMany(part => part).ToArray());
    }

    private void InitializeTasks(int collectionSize)
    {
      int tasksSize = collectionSize / this.minProcessedValues > 1 ? Math.Max(collectionSize / this.minProcessedValues, this.maxParallelTasks) : 1;
      this.tasks = new Task<IEnumerable<T>>[tasksSize];
    }

    private async Task<IEnumerable<T>> Search(IEnumerable<T> collection,  Predicate<T> comparator)
    {
      return await Task.Run(() => collection.Where((item) => comparator(item)).ToArray());
    }
  }
}
