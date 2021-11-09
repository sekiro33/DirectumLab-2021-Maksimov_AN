using System;

namespace Task_2
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var meeting = new Meeting("Встреча", new DateTime(2021, 11, 4, 10, 0, 0), new DateTime(2021, 11, 5, 11, 0, 0));
      var meetingWithRemind = new MeetingWithRemind(
        "Тестовая встреча с напоминанием",
        DateTime.Now.AddMinutes(2),
        DateTime.Now.AddMinutes(3),
        DateTime.Now.AddMinutes(1)
        );
      Console.ReadKey();
    }
  }
}
