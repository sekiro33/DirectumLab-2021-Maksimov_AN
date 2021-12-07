using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Обсуждение.
  /// </summary>
  public class Discussion : IEntity
  {
    private Guid id;
    private string name;
    private Dictionary<Guid, Card> grades;
    private DateTime startDateTime;
    private DateTime endDateTime;

    /// <summary>
    /// Идентификатор обсуждения.
    /// </summary>
    public Guid Id => this.id;

    /// <summary>
    /// Статус обсуждения.
    /// </summary>
    public bool IsOver { get; set; }

    /// <summary>
    /// Тема обсуждения.
    /// </summary>
    public string Name
    {
      get => this.name;

      set => this.name = value;
    }

    /// <summary>
    /// Оценки по теме обсуждения.
    /// </summary>
    public Dictionary<Guid, Card> Grades => this.grades;

    /// <summary>
    /// Дата-время начала обсуждения.
    /// </summary>
    public DateTime StarDateTime => this.startDateTime;

    /// <summary>
    /// Дата-время окончания обсуждения.
    /// </summary>
    public DateTime EndDateTime => this.endDateTime;

    /// <summary>
    /// Конструктор обсуждения.
    /// </summary>
    /// <param name="name">Тема обсуждения.</param>
    public Discussion(string name)
    {
      this.id = Guid.NewGuid();
      this.name = name;
    }

    /// <summary>
    /// Добавить оценку.
    /// </summary>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="card">Оценка.</param>
    public void AddGrade(Guid userId, Card card)
    {
      if (!this.grades.ContainsKey(userId))
        this.grades.Add(userId, card);
      else
        this.grades[userId] = card;
    }

    /// <summary>
    /// Начать обсуждение.
    /// </summary>
    public void StartDiscussion()
    {
      if (this.IsOver != true)
        this.startDateTime = DateTime.Now;
    }

    /// <summary>
    /// Завершить обсуждение.
    /// </summary>
    public void EndDiscussion()
    {
      this.IsOver = true;
      this.endDateTime = DateTime.Now;
    }
  }
}
