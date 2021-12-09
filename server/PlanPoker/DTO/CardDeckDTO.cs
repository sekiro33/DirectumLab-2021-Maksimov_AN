using System;
using System.Collections.Generic;

namespace PlanPoker.DTO
{
  /// <summary>
  /// DTO колоды с картами.
  /// </summary>
  public class CardDeckDTO
  {
    /// <summary>
    /// Идентификатор колоды.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название колоды.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Карты в колоде.
    /// </summary>
    public IEnumerable<CardDTO> Cards { get; set; }
  }
}
