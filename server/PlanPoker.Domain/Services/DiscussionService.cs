using System;
using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Domain.Services
{
  /// <summary>
  /// Сервис для работы с обсуждениями.
  /// </summary>
  public class DiscussionService
  {
    private readonly IRepository<Discussion> discussionRepository;

    /// <summary>
    /// Конструктор сервиса.
    /// </summary>
    /// <param name="discussionRepository">Репозиторий обсуждений.</param>
    public DiscussionService(IRepository<Discussion> discussionRepository)
    {
      this.discussionRepository = discussionRepository;
    }

    /// <summary>
    /// Выставить оценку по обсуждению.
    /// </summary>
    /// <param name="discussionId">Id обсуждения.</param>
    /// <param name="userId">Id пользователя, который выставляет оценку.</param>
    /// <param name="cardId">Id карты с оценкой.</param>
    public void AddGrade(Guid discussionId, Guid userId, Guid cardId)
    {
      var discussion = this.discussionRepository.Get(discussionId);
      discussion.AddGrade(userId, cardId);
    }

    /// <summary>
    /// Завершить обсуждение.
    /// </summary>
    /// <param name="discussionId">Id обсуждения.</param>
    public void EndDiscussion(Guid discussionId)
    {
      this.discussionRepository.Get(discussionId).EndDiscussion();
    }

    /// <summary>
    /// Создать обсуждение.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <param name="name">Название обсуждения.</param>
    /// <returns>Обсуждение.</returns>
    public Discussion CreateDiscussion(Guid roomId, string name)
    {
      var discussion = new Discussion(name, roomId);
      this.discussionRepository.Save(discussion);
      return discussion;
    }

    /// <summary>
    /// Получить все обсуждения в комнате.
    /// </summary>
    /// <param name="roomId">Id комнаты.</param>
    /// <returns>Список обсуждений.</returns>
    public IEnumerable<Discussion> GetAllDiscussion(Guid roomId)
    {
      return this.discussionRepository.GetAll().Where(discussion => discussion.RoomId == roomId).AsEnumerable();
    }

    /// <summary>
    /// Получить обсуждение по Id.
    /// </summary>
    /// <param name="discussionId">Id обсуждения.</param>
    /// <returns>Обсуждение.</returns>
    public Discussion GetDiscussion(Guid discussionId)
    {
      return this.discussionRepository.Get(discussionId);
    }
  }
}