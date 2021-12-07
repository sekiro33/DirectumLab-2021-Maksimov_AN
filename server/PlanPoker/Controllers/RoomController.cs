using System;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Domain.Services;
using PlanPoker.DTO;

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
    private readonly DiscussionService discussionService;

    /// <summary>
    /// Конструктор контроллера комнат.
    /// </summary>
    /// <param name="roomService">Сервис комнат.</param>
    /// <param name="cardDeckService">Сервис для работы с колодами карт.</param>
    /// <param name="discussionService">Сервис для работы обсуждениями.</param>
    public RoomController(RoomService roomService, CardDeckService cardDeckService, DiscussionService discussionService)
    {
      this.roomService = roomService;
      this.cardDeckService = cardDeckService;
      this.discussionService = discussionService;
    }

    /// <summary>
    /// Создать новую комнату.
    /// </summary>
    /// <param name="roomName">Имя комнаты.</param>
    /// <param name="userId">Пользователь, который создаёт комнату.</param>
    /// <returns>Созданная комната.</returns>
    [HttpPost]
    public RoomDTO CreateRoom(string roomName, Guid userId)
    {
      var cardDeck = this.cardDeckService.GetCardDeck();
      var room = this.roomService.CreateRoom(roomName, cardDeck, userId);
      return ConverterDTO.ConvertRoom(room);
    }

    /// <summary>
    /// Получить список пользоватлей в комнате.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <returns>Список пользователей.</returns>
    [HttpGet]
    public string GetAllUsersInRoom(Guid roomId)
    {
      return JsonSerializer.Serialize(this.roomService.GetAllUser(roomId));
    }

    /// <summary>
    /// Войти в комнату.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <returns>Информация о комнате.</returns>
    [HttpPost]
    public RoomDTO Connect(Guid roomId, Guid userId)
    {
      this.roomService.AddUser(roomId, userId);
      return ConverterDTO.ConvertRoom(this.roomService.GetRoom(roomId));
    }

    /// <summary>
    /// Исключить пользователя из комнаты.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="userId">Id пользователя.</param>
    [HttpPost]
    public void KickUser(Guid roomId, Guid userId)
    {
      this.roomService.KickUser(roomId, userId);
    }

    /// <summary>
    /// Создать обсуждение.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="name">Название обсуждения.</param>
    /// <returns>Обсуждение.</returns>
    /// Объединить с началом
    [HttpPost]
    public DiscussionDTO CreateDiscussion(Guid roomId, string name)
    {
      var discussion = this.discussionService.CreateDiscussion(roomId, name);
      return ConverterDTO.ConvertDiscussion(discussion);
    }

    /// <summary>
    /// Закончить обсуждение.
    /// </summary>
    /// <param name="discussionId">Id обсуждения.</param>
    [HttpPost]
    public void EndDiscussion(Guid discussionId)
    {
      this.discussionService.EndDiscussion(discussionId);
    }

    /// <summary>
    /// Получить список всех обсуждений в комнате.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <returns>Список обсуждений.</returns>
    [HttpGet]
    public string GetAllDiscussion(Guid roomId)
    {
      return JsonSerializer.Serialize(this.discussionService.GetAllDiscussion(roomId));
    }

    /// <summary>
    /// Проголосовать.
    /// </summary>
    /// <param name="discussionId">Id обсуждения.</param>
    /// <param name="userId">Id пользователя.</param>
    /// <param name="cardId">Id карты.</param>
    [HttpPost]
    public void Vote(Guid discussionId, Guid userId, Guid cardId)
    {
      this.discussionService.AddGrade(discussionId, userId, cardId);
    }
  }
}
