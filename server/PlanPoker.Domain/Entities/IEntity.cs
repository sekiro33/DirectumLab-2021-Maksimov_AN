using System;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Сущность.
  /// </summary>
  public interface IEntity
  {
    /// <summary>
    /// Идентификатор сущности.
    /// </summary>
    Guid Id { get; }
  }
}
