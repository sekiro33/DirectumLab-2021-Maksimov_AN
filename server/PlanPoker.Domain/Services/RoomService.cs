using System;
using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Domain.Services
{
  /// <summary>
  /// Сервис комнат.
  /// </summary>
  public class RoomService
  {
    private readonly IRepository<Room> roomRepository;
    private readonly IRepository<User> userRepository;

    /// <summary>
    /// Конструктор сервиса.
    /// </summary>
    /// <param name="roomRepository">Репозиторий комнат.</param>
    /// <param name="userRepository">Репозиторий пользователей.</param>
    public RoomService(IRepository<Room> roomRepository, IRepository<User> userRepository)
    {
      this.roomRepository = roomRepository;
      this.userRepository = userRepository;
    }

    /// <summary>
    /// Добавить пользователя в комнату.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="userId">Id пользователя.</param>
    public void AddUser(Guid roomId, Guid userId)
    {
      var users = this.roomRepository.Get(roomId).Users;
      if (!users.Contains(userId))
        users.Add(userId);
      else
        throw new Exception("Пользователь уже есть в комнате.");
    }

    /// <summary>
    /// Исключить пользователя из комнаты.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="userId">Id пользователя.</param>
    public void KickUser(Guid roomId, Guid userId)
    {
      var users = this.roomRepository.Get(roomId).Users;
      if (users.Contains(userId))
        users.Remove(userId);
      else
        throw new Exception("Такого пользователя нет в комнате.");
    }

    /// <summary>
    /// Получить список пользователей в комнате.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <returns>Список пользователей.</returns>
    public IEnumerable<User> GetAllUser(Guid roomId)
    {
      var userId = this.roomRepository.Get(roomId).Users;
      return userId.Select(userId => this.userRepository.Get(userId));
    }

    /// <summary>
    /// Получить информацию о комнате.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <returns>Комната.</returns>
    public Room GetRoom(Guid roomId)
    {
      return this.roomRepository.Get(roomId);
    }

    /// <summary>
    /// Создать новую комнату.
    /// </summary>
    /// <param name="name">Имя комнаты.</param>
    /// <param name="cardDeck">Колода карт.</param>
    /// <param name="userId">Пользователь, который создаёт комнату.</param>
    /// <returns>Созданная комната.</returns>
    public Room CreateRoom(string name, CardDeck cardDeck, Guid userId)
    {
      var room = new Room(name, cardDeck, userId);
      this.roomRepository.Save(room);
      return room;
    }

    /// <summary>
    /// Получить колоду карт, используемую в комнате.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <returns>Колода карт.</returns>
    public CardDeck GetCardDeck(Guid roomId)
    {
      return this.roomRepository.Get(roomId).CardDeck;
    }
  }
}
