using System;
using System.Timers;

namespace Task_2
{
  /// <summary>
  /// Класс "Встреча с напоминанием".
  /// </summary>
  public class MeetingWithRemind : Meeting, IRemind
  {
    private Timer timer;
    private DateTime? remindDateTime;
    private const double CHECKINTERVAL = 60000;

    /// <summary>
    /// Дата-время напоминания о встрече.
    /// </summary>
    public DateTime? DateTimeRemind
    {
      get
      {
        return this.remindDateTime;
      }

      set
      {
        if (this.StartDate != null && value < this.StartDate)
        {
          this.remindDateTime = value;
          this.InitializeTimer();
        }
        else
          Console.WriteLine("Неправильная дата напоминания о встрече. Дата напоминания о встрече не может быть позже даты начала встречи.");
      }
    }

    /// <summary>
    /// Создать экземляр класса "Встреча с напоминанием" на основе переданных значений дат и времени начала встречи, окончания встречи, и напоминания о встрече.
    /// </summary>
    /// <param name="name">Название встречи.</param>
    /// <param name="startDate">Дата-время начала встречи.</param>
    /// <param name="endDate">Дата-время окончания встречи.</param>
    /// <param name="remindDateTime">Дата-время напоминания о встрече.</param>
    public MeetingWithRemind(string name, DateTime startDate, DateTime endDate, DateTime remindDateTime) : base(name, startDate, endDate)
    {
      this.DateTimeRemind = remindDateTime;
    }

    private void InitializeTimer()
    {
      this.timer = new Timer(CHECKINTERVAL);
      this.timer.Elapsed += this.CheckRemindDate;
      this.timer.Enabled = true;
    }

    private void CheckRemindDate(object source, ElapsedEventArgs e)
    {
      if (DateTime.Now > this.remindDateTime)
      { 
        this.timer.Enabled = false;
        this.Remind();
      }
    }

    private void Remind()
    {
      Console.WriteLine($"Напоминание о встрече \"{this.MeetingName}\". Встреча начнётся в {this.StartDate}.");
    }
  }
}
