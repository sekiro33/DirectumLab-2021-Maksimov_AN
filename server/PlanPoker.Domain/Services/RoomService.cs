using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    private readonly IRepository<Discussion> discussionRepository;

    /// <summary>
    /// Конструктор сервиса.
    /// </summary>
    /// <param name="roomRepository">Репозиторий комнат.</param>
    /// <param name="discussionRepository">Репозиторий обсуждений.</param>
    public RoomService(IRepository<Room> roomRepository, IRepository<Discussion> discussionRepository)
    {
      this.roomRepository = roomRepository;
      this.discussionRepository = discussionRepository;
    }

    /// <summary>
    /// Добавить пользователя в комнату.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="userId">Id пользователя.</param>
    public void AddUser(Guid roomId, Guid userId)
    {
      this.roomRepository.Get(roomId).AddUser(userId);
    }

    /// <summary>
    /// Исключить пользователя из комнаты.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="userId">Id пользователя.</param>
    public void KickUser(Guid roomId, Guid userId)
    {
      this.roomRepository.Get(roomId).KickUser(userId);
    }

    /// <summary>
    /// Получить список пользователей в комнате.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <returns>Список пользователей.</returns>
    public IQueryable GetAllUser(Guid roomId)
    {
      return this.roomRepository.Get(roomId).Users.AsQueryable();
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
    /// Создать обсуждение.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="name">Название обсуждения.</param>
    /// <returns>Обсуждение.</returns>
    public Discussion CreateDiscussion(Guid roomId, string name)
    {
      var discussion = new Discussion(name);
      this.discussionRepository.Save(discussion);
      this.roomRepository.Get(roomId).AddDiscussion(discussion);
      return discussion;
    }

    /// <summary>
    /// Начать обсуждение.
    /// </summary>
    /// <param name="discussionId">Id обсуждения.</param>
    public void StartDiscussion(Guid discussionId)
    {
      this.discussionRepository.Get(discussionId).StartDiscussion();
    }

    /// <summary>
    /// Закончить обсуждение.
    /// </summary>
    /// <param name="discussionId">Id обсуждения.</param>
    public void EndDiscussion(Guid discussionId)
    {
      this.discussionRepository.Get(discussionId).EndDiscussion();
    }

    /// <summary>
    /// Получить все обсуждения в комнате.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <returns>Список обсуждений.</returns>
    public IQueryable GetAllDiscussion(Guid roomId)
    {
      return this.roomRepository.Get(roomId).GetAllDiscussion();
    }
  }
}
