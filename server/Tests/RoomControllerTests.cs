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
  /// Тестирование контроллера комнат.
  /// </summary>
  [TestFixture]
  public class RoomControllerTests
  {
    private RoomService roomService;
    private CardDeckService cardDeckService;
    private DiscussionService discussionService;

    private IRepository<Room> roomRepository;
    private IRepository<Discussion> discussionRepository;

    private User creator;
    private User newUser;
    private Room room;

    /// <summary>
    /// Тест для проверки корректности получения информации о комнате.
    /// </summary>
    [Test]
    public void GetRoomInfoTest()
    {
      var expected = new RoomDTO
      {
        Id = this.roomRepository.Get(Guid.Empty).Id,
        Name = "TestRoom",
        CardDeck = ConverterDTO.ConvertCardDeck(this.room.CardDeck),
        Creator = this.creator.Id,
        Users = new List<UserDTO>
        {
          new UserDTO()
          {
            Id = this.creator.Id,
            Name = this.creator.Name
          },
          new UserDTO()
          {
            Id = this.newUser.Id,
            Name = this.newUser.Name
          }
        },
        Discussion = this.discussionRepository
        .GetAll()
        .Where(discussion => discussion.RoomId == this.room.Id)
        .Select(discussion => ConverterDTO.ConvertDiscussion(discussion))
      };

      var roomController = new RoomController(this.roomService, this.cardDeckService, this.discussionService);
      var actual = roomController.GetRoomInfo(this.room.Id);

      Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
    }

    /// <summary>
    /// Тест для проверки корректности получаемых данных о комнате пользователем, когда тот входит в комнату.
    /// </summary>
    [Test]
    public void ConnectToRoomTest()
    {
      var room = this.roomRepository.Get(Guid.Empty);

      var expected = new RoomDTO
      {
        Id = this.roomRepository.Get(Guid.Empty).Id,
        Name = "TestRoom",
        CardDeck = ConverterDTO.ConvertCardDeck(room.CardDeck),
        Creator = this.creator.Id,
        Users = new List<UserDTO>
        {
          new UserDTO()
          {
            Id = this.creator.Id,
            Name = this.creator.Name
          },
          new UserDTO()
          {
            Id = this.newUser.Id,
            Name = this.newUser.Name
          }
        },
        Discussion = this.discussionRepository
        .GetAll()
        .Where(discussion => discussion.RoomId == room.Id)
        .Select(discussion => ConverterDTO.ConvertDiscussion(discussion))
      };

      var roomController = new RoomController(this.roomService, this.cardDeckService, this.discussionService);
      var actual = roomController.Connect(room.Id, this.newUser.Id);

      Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
    }

    /// <summary>
    /// Подготовка данных для тестов.
    /// </summary>
    [OneTimeSetUp]
    public void SetUpOnce()
    {
      var cardDeckMock = new Mock<IRepository<CardDeck>>();
      var cardMock = new Mock<IRepository<Card>>();
      this.cardDeckService = new CardDeckService(cardDeckMock.Object, cardMock.Object);

      this.creator = new User("Creator");
      this.newUser = new User("NewUser");

      var userRepositoryMock = new Mock<IRepository<User>>();
      userRepositoryMock.Setup(repository => repository.Get(this.creator.Id)).Returns(this.creator);
      userRepositoryMock.Setup(repository => repository.Get(this.newUser.Id)).Returns(this.newUser);

      this.room = new Room("TestRoom", this.cardDeckService.GetCardDeck(), this.creator.Id);

      var roomMock = new Mock<IRepository<Room>>();
      roomMock.Setup(repo => repo.Get(It.IsAny<Guid>())).Returns(this.room);
      this.roomRepository = roomMock.Object;

      this.roomService = new RoomService(this.roomRepository, userRepositoryMock.Object);

      var discussionRepositoryMock = new Mock<IRepository<Discussion>>();
      discussionRepositoryMock.Setup(repository => repository.GetAll()).Returns(this.GetTestDiscussions(this.roomService.GetRoom(Guid.Empty).Id));
      this.discussionRepository = discussionRepositoryMock.Object;
      this.discussionService = new DiscussionService(this.discussionRepository, this.roomRepository);
    }

    private IQueryable<Discussion> GetTestDiscussions(Guid roomId)
    {
      var discussions = new List<Discussion>();

      var endedDiscussion = new Discussion("Ended Discussion", roomId);
      endedDiscussion.EndDateTime = DateTime.Now;

      var currentDiscussion = new Discussion("Current Discussion", roomId);

      var discussionInAnotherRoom = new Discussion("Discussion in another room", Guid.NewGuid());

      discussions.Add(endedDiscussion);
      discussions.Add(currentDiscussion);
      discussions.Add(discussionInAnotherRoom);

      return discussions.AsQueryable();
    }
  }
}
