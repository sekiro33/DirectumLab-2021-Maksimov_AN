using System;
using System.Collections.Generic;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Обсуждение.
  /// </summary>
  public class Discussion : IEntity
  {
    private Guid id;
    private Guid roomId;
    private Dictionary<Guid, Guid> grades;

    /// <summary>
    /// Идентификатор обсуждения.
    /// </summary>
    public Guid Id => this.id;

    /// <summary>
    /// Идентификатор комнаты, в которой происходит обсуждение.
    /// </summary>
    public Guid RoomId => this.roomId;

    /// <summary>
    /// Статус обсуждения.
    /// </summary>
    public bool IsOver { get; set; }

    /// <summary>
    /// Тема обсуждения.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Оценки по теме обсуждения.
    /// </summary>
    public IDictionary<Guid, Guid> Grades => this.grades;

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
      this.id = Guid.NewGuid();
      this.grades = new Dictionary<Guid, Guid>();
      this.roomId = roomId;
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
      if (!this.grades.ContainsKey(userId))
        this.grades.Add(userId, cardId);
      else
        this.grades[userId] = cardId;
    }

    /// <summary>
    /// Завершить обсуждение.
    /// </summary>
    public void EndDiscussion()
    {
      this.IsOver = true;
      this.EndDateTime = DateTime.Now;
    }
  }
}
