using System;
using System.Collections.Generic;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Обсуждение.
  /// </summary>
  public class Discussion : IEntity
  {
    /// <summary>
    /// Идентификатор обсуждения.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Идентификатор комнаты, в которой происходит обсуждение.
    /// </summary>
    public Guid RoomId { get; }

    /// <summary>
    /// Тема обсуждения.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Оценки по теме обсуждения.
    /// </summary>
    public IDictionary<Guid, Guid> Grades { get; }

    /// <summary>
    /// Дата-время начала обсуждения.
    /// </summary>
    public DateTime? StarDateTime { get; set; }

    /// <summary>
    /// Дата-время окончания обсуждения.
    /// </summary>
    public DateTime? EndDateTime { get; set; }

    /// <summary>
    /// Конструктор обсуждения.
    /// </summary>
    /// <param name="name">Тема обсуждения.</param>
    /// <param name="roomId">Идентификатор комнаты в которой происходит обсуждение.</param>
    public Discussion(string name, Guid roomId)
    {
      this.Id = Guid.NewGuid();
      this.Grades = new Dictionary<Guid, Guid>();
      this.RoomId = roomId;
      this.Name = name;
      this.StarDateTime = DateTime.Now;
    }

    /// <summary>
    /// Добавить оценку.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="cardId">Id карты с оценкой.</param>
    public void AddGrade(Guid userId, Guid cardId)
    {
      if (!this.Grades.ContainsKey(userId))
        this.Grades.Add(userId, cardId);
      else
        this.Grades[userId] = cardId;
    }
  }
}
