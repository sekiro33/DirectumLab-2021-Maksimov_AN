using System;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Services;

namespace PlanPoker.Controllers
{
  /// <summary>
  /// Контроллер комнат.
  /// </summary>
  [ApiController]
  [Authorize]
  [Route("api/[controller]/[action]")]
  public class RoomController : ControllerBase
  {
    private readonly RoomService roomService;
    private readonly CardDeckService cardDeckService;

    /// <summary>
    /// Конструктор контроллера комнат.
    /// </summary>
    /// <param name="roomService">Сервис комнат.</param>
    /// <param name="cardDeckService">Сервис для работы с колодами карт.</param>
    public RoomController(RoomService roomService, CardDeckService cardDeckService)
    {
      this.roomService = roomService;
      this.cardDeckService = cardDeckService;
    }

    /// <summary>
    /// Создать новую комнату.
    /// </summary>
    /// <param name="roomName">Имя комнаты.</param>
    /// <param name="userId">Пользователь, который создаёт комнату.</param>
    /// <returns>Созданная комната.</returns>
    [HttpPost]
    public Room CreateRoom(string roomName, Guid userId)
    {
      var cardDeck = this.cardDeckService.GetCardDeck();
      return this.roomService.CreateRoom(roomName, cardDeck, userId);
    }

    /// <summary>
    /// Получить список пользоватлей в комнате.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <returns>Список пользователей.</returns>
    [HttpGet]
    public string GetAllUsersInRoom(string roomId)
    {
      return JsonSerializer.Serialize(this.roomService.GetAllUser(Guid.Parse(roomId)));
    }

    /// <summary>
    /// Добавить пользователя в комнату.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="userId">Id пользователя.</param>
    [HttpPost]
    public void AddUser(string roomId, string userId)
    {
      this.roomService.AddUser(Guid.Parse(roomId), Guid.Parse(userId));
    }

    /// <summary>
    /// Исключить пользователя из комнаты.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="userId">Id пользователя.</param>
    [HttpPost]
    public void KickUser(string roomId, string userId)
    {
      this.roomService.KickUser(Guid.Parse(roomId), Guid.Parse(userId));
    }

    /// <summary>
    /// Создать обсуждение.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="name">Название обсуждения.</param>
    /// <returns>Обсуждение.</returns>
    /// Объединить с началом
    [HttpPost]
    public string CreateDiscussion(string roomId, string name)
    {
      return JsonSerializer.Serialize(this.roomService.CreateDiscussion(Guid.Parse(roomId), name));
    }

    /// <summary>
    /// Начать обсуждение.
    /// </summary>
    /// <param name="discussionId">Id обсуждения.</param>
    [HttpPost]
    public void StartDiscussion(string discussionId)
    {
      this.roomService.StartDiscussion(Guid.Parse(discussionId));
    }

    /// <summary>
    /// Закончить обсуждение.
    /// </summary>
    /// <param name="discussionId">Id обсуждения.</param>
    [HttpPost]
    public void EndDiscussion(string discussionId)
    {
      this.roomService.EndDiscussion(Guid.Parse(discussionId));
    }

    /// <summary>
    /// Получить список всех обсуждений в комнате.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <returns>Список обсуждений.</returns>
    [HttpGet]
    public string GetAllDiscussion(string roomId)
    {
      return JsonSerializer.Serialize(this.roomService.GetAllDiscussion(Guid.Parse(roomId)));
    }
  }
}
