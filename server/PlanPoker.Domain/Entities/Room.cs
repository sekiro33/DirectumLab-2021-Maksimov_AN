using System;
using System.Collections.Generic;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Комната.
  /// </summary>
  public class Room : IEntity
  {
    private Guid id;
    private CardDeck cardDeck;
    private ICollection<Guid> users;
    private Guid creator;

    /// <summary>
    /// Идентификатор комнаты.
    /// </summary>
    public Guid Id => this.id;

    /// <summary>
    /// Колода карт используемая для обсуждений.
    /// </summary>
    public CardDeck CardDeck => this.cardDeck;

    /// <summary>
    /// Имя комнаты.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Список участников в комнате.
    /// </summary>
    public ICollection<Guid> Users => this.users;

    /// <summary>
    /// Создатель комнаты.
    /// </summary>
    public Guid Creator => this.creator;

    /// <summary>
    /// Конструктор комнаты.
    /// </summary>
    /// <param name="name">Имя комнаты.</param>
    /// <param name="cardDeck">Колода карт.</param>
    /// <param name="creator">Создатель комнаты.</param>
    public Room(string name, CardDeck cardDeck, Guid creator)
    {
      this.users = new List<Guid>();
      this.users.Add(creator);
      this.id = Guid.NewGuid();
      this.Name = name;
      this.cardDeck = cardDeck;
      this.creator = creator;
    }
  }
}
