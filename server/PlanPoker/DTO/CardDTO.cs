using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanPoker.DTO
{
  /// <summary>
  /// DTO карты.
  /// </summary>
  public class CardDTO
  {
    /// <summary>
    /// Идентификатор карты.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Значение карты.
    /// </summary>
    public double? Value { get; set; }
  }
}
