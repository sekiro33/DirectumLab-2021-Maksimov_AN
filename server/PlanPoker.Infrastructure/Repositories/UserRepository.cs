using System;
using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Infrastructure.Repositories
{
  /// <summary>
  /// Репозиторий пользователей.
  /// </summary>
  public class UserRepository : IRepository<User>
  {
    private readonly Dictionary<Guid, User> users;

    /// <summary>
    /// Конструктор репозитория.
    /// </summary>
    public UserRepository()
    {
      this.users = new Dictionary<Guid, User>();
    }

    /// <summary>
    /// Удалить пользователя.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <returns>Удаленный пользователь.</returns>
    public User Delete(Guid id)
    {
      this.users.Remove(id);
      return null;
    }

    /// <summary>
    /// Получить пользователя по Id.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <returns>Пользователь.</returns>
    public User Get(Guid id)
    {
      if (this.users.ContainsKey(id))
        return this.users[id];
      return null;
    }

    /// <summary>
    /// Получить список всех пользователей.
    /// </summary>
    /// <returns>Список пользователей.</returns>
    public IQueryable<User> GetAll()
    {
      return this.users.Values.AsQueryable();
    }

    /// <summary>
    /// Добавить пользователя.
    /// </summary>
    /// <param name="entity">Пользователь.</param>
    /// <returns>Добавленный пользователь.</returns>
    public User Save(User entity)
    {
      if (!this.users.ContainsKey(entity.Id))
        this.users.Add(entity.Id, entity);
      return null;
    }
  }
}
