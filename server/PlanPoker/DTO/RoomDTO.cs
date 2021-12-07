using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanPoker.DTO
{
  /// <summary>
  /// DTO комнаты.
  /// </summary>
  public class RoomDTO
  {
    /// <summary>
    /// Идентификатор комнаты.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название комнаты.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Создатель комнаты.
    /// </summary>
    public Guid Creator { get; set; }

    /// <summary>
    /// Колода карт.
    /// </summary>
    public CardDeckDTO CardDeck { get; set; }
  }
}
