using System;
using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Infrastructure.Repositories
{
  // Подумать над этим
  /// <summary>
  /// Репозиторий для авторизованных пользователей.
  /// </summary>
  public class AuthorizedUserRepository : IRepository<User>
  {
    private readonly Dictionary<Guid, User> users;

    /// <summary>
    /// Конструктор репозитория.
    /// </summary>
    public AuthorizedUserRepository()
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
    /// Получить авторизованного пользователя по Id.
    /// </summary>
    /// <param name="id">Id пользователя.</param>
    /// <returns>Авторизованный пользователь.</returns>
    public User Get(Guid id)
    {
      if (this.users.ContainsKey(id))
        return this.users[id];
      return null;
    }

    /// <summary>
    /// Получить список всех авторизованных пользователей.
    /// </summary>
    /// <returns>Список авторзиованных пользователей.</returns>
    public IQueryable<User> GetAll()
    {
      return (IQueryable<User>)this.users.AsQueryable();
    }

    /// <summary>
    /// Добавить пользователя в список авторизованных.
    /// </summary>
    /// <param name="entity">Пользователь.</param>
    /// <returns>Пользователь.</returns>
    public User Save(User entity)
    {
      if (!this.users.ContainsKey(entity.Id))
        this.users.Add(entity.Id, entity);
      return null;
    }
  }
}
