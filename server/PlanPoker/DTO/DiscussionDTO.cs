using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanPoker.DTO
{
  /// <summary>
  /// DTO обсуждения.
  /// </summary>
  public class DiscussionDTO
  {
    /// <summary>
    /// Идентификатор обсуждения.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название обсуждения.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Оценки по обсуждению.
    /// </summary>
    public IEnumerable<double> Grades { get; set; }

    /// <summary>
    /// Время начала обсуждения.
    /// </summary>
    public DateTime? StartDateTime { get; set; }

    /// <summary>
    /// Время окончания обсуждения.
    /// </summary>
    public DateTime? EndDateTime { get; set; }
  }
}