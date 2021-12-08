using System;
using System.Collections.Generic;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Комната.
  /// </summary>
  public class Room : IEntity
  {
    /// <summary>
    /// Идентификатор комнаты.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Колода карт используемая для обсуждений.
    /// </summary>
    public CardDeck CardDeck { get; }

    /// <summary>
    /// Имя комнаты.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Список участников в комнате.
    /// </summary>
    public ICollection<Guid> Users { get; }

    /// <summary>
    /// Создатель комнаты.
    /// </summary>
    public Guid Creator { get; }

    /// <summary>
    /// Конструктор комнаты.
    /// </summary>
    /// <param name="name">Имя комнаты.</param>
    /// <param name="cardDeck">Колода карт.</param>
    /// <param name="creator">Создатель комнаты.</param>
    public Room(string name, CardDeck cardDeck, Guid creator)
    {
      this.Users = new List<Guid>();
      this.Users.Add(creator);
      this.Id = Guid.NewGuid();
      this.Name = name;
      this.CardDeck = cardDeck;
      this.Creator = creator;
    }
  }
}
