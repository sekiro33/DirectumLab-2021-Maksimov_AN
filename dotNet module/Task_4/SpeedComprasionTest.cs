using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
  /// <summary>
  /// Измерение скорости работы классов.
  /// </summary>
  public class SpeedComprasionTest
  {
    /// <summary>
    /// Количество итераций.
    /// </summary>
    public static long СycleCount = 0;
    
    /// <summary>
    /// Замер времени конкатенации строк без применения StringBuilder.
    /// </summary>
    /// <returns>Время конкатенации.</returns>
    public static string TestConcatStringSpeed()
    {
      Stopwatch stopWatch = new Stopwatch();
      string str = string.Empty;
      stopWatch.Start();
      for (int i = 0; i < СycleCount; i++)
        str += i;
      stopWatch.Stop();
      TimeSpan ts = stopWatch.Elapsed;
      return ts.TotalMilliseconds.ToString() + " ms";
    }

    /// <summary>
    /// Замер времени конкатенации строк с применением StrinBuilder.
    /// </summary>
    /// <returns>Время конкатенации.</returns>
    public static string TestConcatStringBuilderSpeed()
    {
      Stopwatch stopWatch = new Stopwatch();
      StringBuilder str = new StringBuilder();
      stopWatch.Start();
      for (int i = 0; i < СycleCount; i++)
        str.Append(i);
      stopWatch.Stop();
      TimeSpan ts = stopWatch.Elapsed;
      return ts.TotalMilliseconds.ToString() + " ms";
    }
  }
}
