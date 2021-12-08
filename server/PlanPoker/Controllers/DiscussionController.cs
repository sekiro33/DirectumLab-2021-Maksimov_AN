using System;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Domain.Services;
using PlanPoker.DTO;

namespace PlanPoker.Controllers
{
  /// <summary>
  /// Контроллер обсуждений.
  /// </summary>
  [ApiController]
  [Authorize]
  [Route("api/[controller]/[action]")]
  public class DiscussionController : ControllerBase
  {
    private readonly DiscussionService discussionService;

    /// <summary>
    /// Конструктор контроллера.
    /// </summary>
    /// <param name="discussionService">Сервис для работы с обсуждениями.</param>
    public DiscussionController(DiscussionService discussionService)
    {
      this.discussionService = discussionService;
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
