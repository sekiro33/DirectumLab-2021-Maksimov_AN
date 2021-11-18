using System;
using System.Data;
using System.Text;

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
      var meeting = new MeetingWithType("Тестовая встреча", TypeMeeting.CONFERENCE, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(4));
      var meeting1 = new MeetingWithType("Тестовая встреча 2", TypeMeeting.CALL, DateTime.Now);
      Console.WriteLine(meeting1.Duration);
      Console.WriteLine(meeting1.EndDate);
      Console.ReadKey();
    }
  }
}
