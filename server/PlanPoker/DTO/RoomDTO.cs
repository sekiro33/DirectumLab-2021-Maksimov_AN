using System;
using System.Collections.Generic;

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
    /// Список обсуждений в комнате.
    /// </summary>
    public IEnumerable<DiscussionDTO> Discussion { get; set; }

    /// <summary>
    /// Список пользователей в комнате.
    /// </summary>
    public IEnumerable<UserDTO> Users { get; set; }

    /// <summary>
    /// Колода карт.
    /// </summary>
    public CardDeckDTO CardDeck { get; set; }
  }
}
