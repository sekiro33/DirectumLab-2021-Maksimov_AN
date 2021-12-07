using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Комната.
  /// </summary>
  public class Room : IEntity
  {
    private Guid id;
    private CardDeck cardDeck;
    private string name;
    private List<Guid> users;
    private List<Discussion> discussions;
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
    public string Name
    {
      get => this.name;

      set => this.name = value;
    }

    /// <summary>
    /// Список участников в комнате.
    /// </summary>
    public List<Guid> Users => this.users;

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
      this.discussions = new List<Discussion>();
      this.id = Guid.NewGuid();
      this.name = name;
      this.cardDeck = cardDeck;
      this.creator = creator;
    }

    /// <summary>
    /// Добавить пользователя в комнату.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    public void AddUser(Guid userId)
    {
      this.users.Add(userId);
    }

    /// <summary>
    /// Исключить пользователя из комнаты.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    public void KickUser(Guid userId)
    {
      var user = this.users.Where(id => id == userId).FirstOrDefault();
      this.users.Remove(user);
    }

    /// <summary>
    /// Добавить обсуждение.
    /// </summary>
    /// <param name="discussion">Обсуждение.</param>
    public void AddDiscussion(Discussion discussion)
    {
      this.discussions.Add(discussion);
    }

    /// <summary>
    /// Получить обсуждение.
    /// </summary>
    /// <param name="discussionId">Id обсуждения.</param>
    /// <returns>Обсуждение.</returns>
    public Discussion GetDiscussion(Guid discussionId)
    {
      return this.discussions.Where(discussion => discussion.Id == discussionId).FirstOrDefault();
    }

    /// <summary>
    /// Получить все обсуждения комнаты.
    /// </summary>
    /// <returns>Список обсуждений.</returns>
    public IQueryable GetAllDiscussion()
    {
      return this.discussions.AsQueryable();
    }
  }
}
