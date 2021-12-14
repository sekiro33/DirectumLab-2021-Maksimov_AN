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
    private IRepository<Room> roomRepository;
    private RoomService roomService;
    private Discussion currentDiscussion;
    private User creator;

    /// <summary>
    /// Подготовка данных для тестов.
    /// </summary>
    [OneTimeSetUp]
    public void SetUpOnce()
    {
      var cardDeckRepositoryMock = new Mock<IRepository<CardDeck>>();
      var cardRepositoryMock = new Mock<IRepository<Card>>();
      var cardDeckService = new CardDeckService(cardDeckRepositoryMock.Object, cardRepositoryMock.Object);

      this.creator = new User("Creator");
      var userRepositoryMock = new Mock<IRepository<User>>();
      userRepositoryMock.Setup(repository => repository.Get(It.IsAny<Guid>())).Returns(this.creator);

      var roomRepositoryMock = new Mock<IRepository<Room>>();
      roomRepositoryMock.Setup(repository => repository.Get(Guid.Empty)).Returns(new Room("TestRoom", cardDeckService.GetCardDeck(), this.creator.Id));
      this.roomRepository = roomRepositoryMock.Object;

      var discussionRepositroyMock = new Mock<IRepository<Discussion>>();
      discussionRepositroyMock.Setup(repository => repository.GetAll()).Returns(this.GetTestDiscussions());
      discussionRepositroyMock.Setup(repository => repository.Get(It.IsAny<Guid>())).Returns(this.currentDiscussion);
      this.discussionRepository = discussionRepositroyMock.Object;

      this.discussionService = new DiscussionService(this.discussionRepository, this.roomRepository);

      this.roomService = new RoomService(this.roomRepository, userRepositoryMock.Object);
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
      var users = new List<UserDTO>()
      {
        new UserDTO
        {
          Id = this.creator.Id,
          Name = this.creator.Name
        }
      };
      var cardDeck = this.roomService.GetCardDeck(Guid.Empty);
      var expected = discussions.Select(discussion => ConverterDTO.ConvertDiscussion(discussion, users, cardDeck));

      var discussionController = new DiscussionController(this.discussionService, this.roomService);
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
      var users = new List<UserDTO>()
      {
        new UserDTO
        {
          Id = this.creator.Id,
          Name = this.creator.Name
        }
      };
      var cardDeck = this.roomService.GetCardDeck(Guid.Empty);
      var expected = this.discussionRepository
        .GetAll()
        .Where(discussion => discussion.RoomId == Guid.Empty)
        .Select(discussion => ConverterDTO.ConvertDiscussion(discussion, users, cardDeck));

      var discussionController = new DiscussionController(this.discussionService, this.roomService);
      var actual = discussionController.GetAllDiscussion(Guid.Empty);

      Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
    }
  }
}
