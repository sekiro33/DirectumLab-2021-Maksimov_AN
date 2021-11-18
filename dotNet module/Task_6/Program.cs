using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Task_6
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
      Console.WriteLine(GetRecordsCount("ClientConnectionLog.log", new DateTime(2007, 12, 4, 10, 00, 0), new DateTime(2007, 12, 4, 12, 0, 0)));
      Player player = new Player();
      /*
       * При вызове метода ToString() возвращается строковое представление объекта.
       * Если ToString() не переопределен в классе, то вызов метода по умолчанию возваращает полное имя типа объекта.
       * В случае, если класс должен преобразоваться в строку, нужно переопределить в этом классе метод ToString().
       */
      Console.WriteLine(player.ToString());
    }

    /// <summary>
    /// Подсчитать количество записей за указанный интервал.
    /// </summary>
    /// <param name="path">Путь к файлу.</param>
    /// <param name="startInterval">Начало интервала.</param>
    /// <param name="endInterval">Конец интервала.</param>
    /// <returns>Количество записей за указанный интервал.</returns>
    private static int GetRecordsCount(string path, DateTime startInterval, DateTime endInterval)
    {
      int count = 0;
      var formatInfo = new System.Globalization.DateTimeFormatInfo();
      var splitter = new Regex("[0-9]{2}.[0-9]{2}.[0-9]{4}\t[0-9]{2}:[0-9]{2}:[0-9]{2}");
      using (var stream = new StreamReader(path))
      {
        DateTime parseDateTime;
        while (!stream.EndOfStream)
        {
          var currentLine = stream.ReadLine();
          var match = splitter.Match(currentLine);
          if (match.Success)
          {
            var value = match.Value.Replace("\t", " ");
            if (DateTime.TryParseExact(value, "dd.MM.yyyy HH:mm:ss", formatInfo, System.Globalization.DateTimeStyles.None, out parseDateTime))
            {
              if (parseDateTime >= startInterval && parseDateTime <= endInterval)
                count++;
            }
          }
        }
      }

      return count;
    }
  }
}
