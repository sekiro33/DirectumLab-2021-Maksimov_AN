using System;

namespace Task_2
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Meeting meeting = new Meeting();
      meeting.MeetingName = "Тестовая встреча";
      meeting.StartDate = DateTime.Now;
      meeting.EndDate = DateTime.Now;
      Console.WriteLine(meeting.ToString());
      Console.ReadKey();
    }
  }
}
