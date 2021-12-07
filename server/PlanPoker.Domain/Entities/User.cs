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

    private string name;

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name
    {
      get => this.name;

      set => this.name = value;
    }

    /// <summary>
    /// Создать нового пользователя.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    public User(string name)
    {
      this.name = name;
      this.id = Guid.NewGuid();
    }
  }
}
