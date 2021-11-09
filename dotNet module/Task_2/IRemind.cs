using System;

namespace Task_2
{
  /// <summary>
  /// Представляет свойство дата-время напоминания.
  /// </summary>
  public interface IRemind
  {
    /// <summary>
    /// Дата-время напоминания о событии.
    /// </summary>
    DateTime? Remind { get; set; }
  }
}
