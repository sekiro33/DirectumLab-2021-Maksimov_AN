using System;

namespace Task_2
{
  /// <summary>
  /// Класс "Встреча".
  /// </summary>
  public class Meeting
  {
    private DateTime? startDate;
    private DateTime? endDate;

    /// <summary>
    /// Название встречи.
    /// </summary>
    public string MeetingName { get; set; }

    /// <summary>
    /// Дата-время начала встречи.
    /// </summary>
    public DateTime? StartDate
    {
      get
      {
        return this.startDate;
      }

      set
      {
        if (this.endDate != null)
        {
          if (value <= this.endDate)
            this.startDate = value;
          else
            Console.WriteLine("Неправильная дата начала встречи. Дата начала встречи не может быть позже даты окончания встречи.");
        }
        else
          this.startDate = value;
      }
    }

    /// <summary>
    /// Дата-время окончания встречи.
    /// </summary>
    public DateTime? EndDate
    {
      get
      {
        return this.endDate;
      }

      set
      {
        if (this.startDate != null)
          if (value >= this.startDate)
            this.endDate = value;
          else
            Console.WriteLine("Неправильная дата окончания встречи. Дата окончания встречи не может быть раньше даты начала встречи.");
      }
    }

    /// <summary>
    /// Продолжительность встречи.
    /// </summary>
    public TimeSpan? Duration
    {
      get
      {
        return this.endDate - this.startDate;
      }
    }

    /// <summary>
    /// Создать экземляр класса "Встреча" на основе переданных значений дат и времени.
    /// </summary>
    /// <param name="name">Название встречи.</param>
    /// <param name="startDate">Дата-время начала встречи.</param>
    /// <param name="endDate">Дата-время окончания встречи.</param>
    public Meeting(string name, DateTime startDate, DateTime endDate)
    {
      this.MeetingName = name;
      this.StartDate = startDate;
      this.EndDate = endDate;
    }

    /// <summary>
    /// Информация о встрече.
    /// </summary>
    /// <returns>Строка с информацией о встрече.</returns>
    public override string ToString()
    {
      return $"Встреча - {this.MeetingName}. Начало: {this.startDate}; Конец: {this.endDate}; Продолжительность: {this.Duration}.";
    }
  }
}
