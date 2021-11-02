using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
  public class Meeting
  {
    private DateTime startDate;
    private DateTime endDate;

    public string MeetingName { get; set; }

    public DateTime StartDate
    {
      get
      {
        return this.startDate;
      }

      set
      {
        if (this.endDate != DateTime.MinValue)
        {
          if (DateTime.Compare(value, this.endDate) <= 0)
            this.startDate = value;
        }
        else
          this.startDate = value;
      }
    }

    public DateTime EndDate
    {
      get
      {
        return this.endDate;
      }
      set
      {
        if (this.startDate != DateTime.MinValue)
        {
          if (DateTime.Compare(value, this.startDate) >= 0)
            this.endDate = value;
        }
        else
          this.endDate = value;
      }
    }

    public TimeSpan Duration
    {
      get
      {
        return this.endDate.Date - this.startDate.Date;
      }
    }

    public Meeting() {}
    public Meeting(string name, DateTime startDate, DateTime endDate)
    {
      this.StartDate = startDate;
      this.EndDate = endDate;
    }

    public override string ToString()
    {
      return String.Format(
        "Встреча - {0}. Начало: {1}; Конец: {2}; Продолжительность: {3}.",
        this.MeetingName,
        this.startDate.ToString(),
        this.endDate.ToString(),
        this.Duration.ToString()
        );
    }
  }
}
