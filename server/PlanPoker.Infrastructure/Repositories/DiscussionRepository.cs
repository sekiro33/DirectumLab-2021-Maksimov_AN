using System;
using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Infrastructure.Repositories
{
  /// <summary>
  /// Репозиторий обсуждений.
  /// </summary>
  public class DiscussionRepository : IRepository<Discussion>
  {
    private readonly List<Discussion> discussions;

    /// <summary>
    /// Конструктор репозитория.
    /// </summary>
    public DiscussionRepository()
    {
      this.discussions = new List<Discussion>();
    }

    /// <summary>
    /// Удалить обсуждение.
    /// </summary>
    /// <param name="id">Id обсуждения.</param>
    /// <returns>Удаленное обсуждение.</returns>
    public Discussion Delete(Guid id)
    {
      var discussion = this.Get(id);
      if (discussion is not null)
        this.discussions.Remove(discussion);
      return discussion;
    }

    /// <summary>
    /// Получить обсуждение по Id.
    /// </summary>
    /// <param name="id">Id обсуждения.</param>
    /// <returns>Обсуждение.</returns>
    public Discussion Get(Guid id)
    {
      return this.discussions.Where(discussion => discussion.Id == id).FirstOrDefault();
    }

    /// <summary>
    /// Получить все обсуждения.
    /// </summary>
    /// <returns>Список обсуждений.</returns>
    public IQueryable<Discussion> GetAll()
    {
      return this.discussions.AsQueryable();
    }

    /// <summary>
    /// Добавить обсуждение.
    /// </summary>
    /// <param name="entity">Обсуждение.</param>
    /// <returns>Добавленное обсуждение.</returns>
    public Discussion Save(Discussion entity)
    {
      this.discussions.Add(entity);
      return entity;
    }
  }
}
