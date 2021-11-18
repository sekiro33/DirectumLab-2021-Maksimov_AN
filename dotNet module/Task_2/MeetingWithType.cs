using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
  /// <summary>
  /// Встреча с типом.
  /// </summary>
  public class MeetingWithType : Meeting
  {
    private TypeMeeting type;

    /// <summary>
    /// Тип встречи.
    /// </summary>
    public TypeMeeting MeetingType { get => this.type; set => this.type = value; }

    /// <summary>
    /// Создать встречу с типом.
    /// </summary>
    /// <param name="name">Имя встречи.</param>
    /// <param name="meetingType">Тип встречи.</param>
    /// <param name="startDate">Дата-время начала встречи.</param>
    /// <param name="endDate">Дата-время конца встречи.</param>
    public MeetingWithType(string name, TypeMeeting meetingType,  DateTime? startDate, DateTime? endDate = null) : base(name, startDate, endDate)
    {
      this.type = meetingType;
    }
  }
}
