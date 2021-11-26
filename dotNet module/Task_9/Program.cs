using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task_9
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
      foreach (var record in GetRecordsByDate("ClientConnectionLog.log", new DateTime(2007, 12, 04)))
      {
        Console.WriteLine(record);
      }
    }

    /// <summary>
    /// Отфильтровать строки из файла на указанную дату и отсортировать их по времени.
    /// </summary>
    /// <param name="file">Путь к файлу.</param>
    /// <param name="date">Дата, по которой делается выборка.</param>
    /// <returns>Отфильтрованные строки.</returns>
    public static IEnumerable<string> GetRecordsByDate(string file, DateTime date)
    {
      var records = new StreamReaderEnumerable(file);

      return records
        .Select(record => (record, dateTime : GetDateTimeFromRecord(record)))
        .Where(tuple => tuple.dateTime.HasValue && date.Date == tuple.dateTime.Value.Date)
        .OrderBy(tuple => tuple.dateTime.Value.TimeOfDay)
        .Select(tuple => tuple.record)
        .ToList();
    }

    /// <summary>
    /// Извлечь из строки дату и время.
    /// </summary>
    /// <param name="record">Строка из которой извлекается дата и время.</param>
    /// <returns>Дата и время.</returns>
    private static DateTime? GetDateTimeFromRecord(string record)
    {
      var formatInfo = new DateTimeFormatInfo();
      var splitter = new Regex("[0-9]{2}.[0-9]{2}.[0-9]{4}\t[0-9]{2}:[0-9]{2}:[0-9]{2}");
      var match = splitter.Match(record);
      if (match.Success)
      {
        if (DateTime.TryParseExact(match.Value, "dd.MM.yyyy\tHH:mm:ss", formatInfo, DateTimeStyles.None, out var parseDateTime))
        {
          return parseDateTime;
        }
      }

      return null;
    }
  }
}
