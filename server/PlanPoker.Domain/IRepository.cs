using System;
using System.Linq;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Domain.Repositories
{
  /// <summary>
  /// Репозиторий.
  /// </summary>
  /// <typeparam name="T">Сущность, для которой создаётся репозиторий.</typeparam>
  public interface IRepository<T> where T : IEntity
  {
    /// <summary>
    /// Сохранить сущность в репозитории.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <returns>Сохраненённая сущность.</returns>
    T Save(T entity);

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id">Id сущности.</param>
    /// <returns>Сущность с указанным Id.</returns>
    T Get(Guid id);

    /// <summary>
    /// Получить список сущностей.
    /// </summary>
    /// <returns>Список сущностей.</returns>
    IQueryable<T> GetAll();

    /// <summary>
    /// Удалить сущность из репозитория.
    /// </summary>
    /// <param name="id">Id сущности.</param>
    /// <returns>Удаленная сущность.</returns>
    T Delete(Guid id);
  }
}
