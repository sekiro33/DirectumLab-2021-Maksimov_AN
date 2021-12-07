using System;
using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Infrastructure.Repositories
{
  /// <summary>
  /// Репозиторий комнат.
  /// </summary>
  public class RoomRepository : IRepository<Room>
  {
    private List<Room> rooms;

    /// <summary>
    /// Конструктор.
    /// </summary>
    public RoomRepository()
    {
      this.rooms = new List<Room>();
    }

    /// <summary>
    /// Удалить комнату.
    /// </summary>
    /// <param name="id">Id комнаты.</param>
    /// <returns>Удаленная комната.</returns>
    public Room Delete(Guid id)
    {
      var room = this.Get(id);
      if (room is not null)
        this.rooms.Remove(room);
      return null;
    }

    /// <summary>
    /// Получить комнату по Id.
    /// </summary>
    /// <param name="id">Id комнаты.</param>
    /// <returns>Комната с указанным Id.</returns>
    public Room Get(Guid id)
    {
      return this.rooms.Where(room => room.Id == id).FirstOrDefault();
    }

    /// <summary>
    /// Получить список всех комнат.
    /// </summary>
    /// <returns>Список всех комнат.</returns>
    public IQueryable<Room> GetAll()
    {
      return this.rooms.AsQueryable();
    }

    /// <summary>
    /// Добавить новую комнату.
    /// </summary>
    /// <param name="entity">Комната.</param>
    /// <returns>Новая комната.</returns>
    public Room Save(Room entity)
    {
      this.rooms.Add(entity);
      return null;
    }
  }
}
