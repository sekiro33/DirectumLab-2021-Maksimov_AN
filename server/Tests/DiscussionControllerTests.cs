using Moq;
using NUnit.Framework;
using PlanPoker.Controllers;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using PlanPoker.Domain.Services;
using PlanPoker.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Tests
{
  /// <summary>
  /// Тестирование контроллера обсуждений.
  /// </summary>
  [TestFixture]
  public class DiscussionControllerTests
  {
    private DiscussionService discussionService;
    private IRepository<Discussion> discussionRepository;

    private Discussion currentDiscussion;

    /// <summary>
    /// Подготовка данных для тестов.
    /// </summary>
    [OneTimeSetUp]
    public void SetUpOnce()
    {
      var cardDeckRepositoryMock = new Mock<IRepository<CardDeck>>();
      var cardRepositoryMock = new Mock<IRepository<Card>>();
      var cardDeckService = new CardDeckService(cardDeckRepositoryMock.Object, cardRepositoryMock.Object);

      var creator = new User("Creator");

      var roomRepositoryMock = new Mock<IRepository<Room>>();
      roomRepositoryMock.Setup(repository => repository.Get(Guid.Empty)).Returns(new Room("TestRoom", cardDeckService.GetCardDeck(), creator.Id));

      var discussionRepositroyMock = new Mock<IRepository<Discussion>>();
      discussionRepositroyMock.Setup(repository => repository.GetAll()).Returns(this.GetTestDiscussions());
      discussionRepositroyMock.Setup(repository => repository.Get(It.IsAny<Guid>())).Returns(this.currentDiscussion);
      this.discussionRepository = discussionRepositroyMock.Object;

      this.discussionService = new DiscussionService(this.discussionRepository, roomRepositoryMock.Object);
    }

    private IQueryable<Discussion> GetTestDiscussions()
    {
      var discussions = new List<Discussion>();

      var endedDiscussion = new Discussion("Ended Discussion", Guid.Empty);
      endedDiscussion.EndDateTime = DateTime.Now;

      this.currentDiscussion = new Discussion("Current Discussion", Guid.Empty);

      var discussionInAnotherRoom = new Discussion("Discussion in another room", Guid.NewGuid());

      discussions.Add(endedDiscussion);
      discussions.Add(this.currentDiscussion);
      discussions.Add(discussionInAnotherRoom);

      return discussions.AsQueryable();
    }

    /// <summary>
    /// Тест для проверки корректности получаемой информации об обсуждениях.
    /// </summary>
    [Test]
    public void GetAllDiscussionTest()
    {
      var discussions = this.discussionRepository.GetAll().Where(discussion => discussion.RoomId == Guid.Empty).AsEnumerable();
      var expected = discussions.Select(discussion => ConverterDTO.ConvertDiscussion(discussion));

      var discussionController = new DiscussionController(this.discussionService);
      var actual = discussionController.GetAllDiscussion(Guid.Empty);

      Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
    }

    /// <summary>
    /// Тест для проверки корректности сохранения данных обсуждения.
    /// </summary>
    [Test]
    public void SaveDiscussionTest()
    {
      this.discussionService.EndDiscussion(this.currentDiscussion.Id);

      var expected = this.discussionRepository
        .GetAll()
        .Where(discussion => discussion.RoomId == Guid.Empty)
        .Select(discussion => ConverterDTO.ConvertDiscussion(discussion));

      var discussionController = new DiscussionController(this.discussionService);
      var actual = discussionController.GetAllDiscussion(Guid.Empty);

      Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
    }
  }
}
