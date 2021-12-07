using System;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Пользователь.
  /// </summary>
  public class User : IEntity
  {
    private Guid id;

    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public Guid Id => this.id;

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Создать нового пользователя.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    public User(string name)
    {
      this.Name = name;
      this.id = Guid.NewGuid();
    }
  }
}
