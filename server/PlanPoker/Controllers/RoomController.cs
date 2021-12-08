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

    /// <summary>
    /// Конструктор контроллера комнат.
    /// </summary>
    /// <param name="roomService">Сервис комнат.</param>
    /// <param name="cardDeckService">Сервис для работы с колодами карт.</param>
    /// <param name="discussionService">Сервис для работы обсуждениями.</param>
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
    /// Получить информацию о комнате.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <returns>Комната.</returns>
    [HttpGet]
    public RoomDTO GetRoomInfo(Guid roomId)
    {
      return ConverterDTO.ConvertRoom(this.roomService.GetRoom(roomId));
    }
  }
}
