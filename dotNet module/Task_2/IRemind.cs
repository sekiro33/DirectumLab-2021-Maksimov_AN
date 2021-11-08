using System;

namespace Task_2
{
  /// <summary>
  /// Интерфейс "Напоминание".
  /// </summary>
  public interface IRemind
  {
    /// <summary>
    /// Дата-время напоминания о событии.
    /// </summary>
    DateTime? DateTimeRemind { get; set; }
  }
}
