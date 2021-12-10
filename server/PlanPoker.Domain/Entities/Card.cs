using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Карта.
  /// </summary>
  public class Card : IEntity
  {
    /// <summary>
    /// Идентификатор карты.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Значение карты.
    /// </summary>
    public double? Value { get; set; }

    /// <summary>
    /// Конструктор карты.
    /// </summary>
    /// <param name="value">Значение карты.</param>
    public Card(double? value)
    {
      this.Id = Guid.NewGuid();
      this.Value = value;
    }
  }
}
