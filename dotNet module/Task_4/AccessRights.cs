using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
  /// <summary>
  /// Тип прав.
  /// </summary>
  [Flags, Serializable]
  public enum AccessRights : byte
  {
    /// <summary>
    /// Просмотр.
    /// </summary>
    View = 1,

    /// <summary>
    /// Выполнение.
    /// </summary>
    Run = 2,

    /// <summary>
    /// Добавление.
    /// </summary>
    Add = 4,

    /// <summary>
    /// Изменение.
    /// </summary>
    Edit = 8,

    /// <summary>
    /// Утверждение.
    /// </summary>
    Ratify = 16,

    /// <summary>
    /// Удаление.
    /// </summary>
    Delete = 32,

    /// <summary>
    /// Нет доступа.
    /// </summary>
    /// <remarks>
    /// Этот флаг имеет максимальный приоритет.
    /// Если он установлен, остальные флаги игнорируются. 
    /// </remarks>
    AccessDenied = 64
  }
}
