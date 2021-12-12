using System;

namespace PlanPoker.DTO
{
  /// <summary>
  /// DTO карты.
  /// </summary>
  public class CardDTO
  {
    /// <summary>
    /// Идентификатор карты.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Значение карты.
    /// </summary>
    public double? Value { get; set; }

    /// <summary>
    /// Строковое представление карты.
    /// </summary>
    public string Text { get; set; }
  }
}
