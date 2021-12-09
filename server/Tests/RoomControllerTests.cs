using Moq;
using NUnit.Framework;
using PlanPoker.Controllers;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using PlanPoker.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Tests
{
  [TestFixture]
  public class RoomControllerTests
  {
    private RoomService roomService;
    private CardDeckService cardDeckService;
    private DiscussionService discussionService;

    private IRepository<Room> roomRepository;

    [OneTimeSetUp]
    public void SetUpOnce()
    {
      var cardDeckMock = new Mock<IRepository<CardDeck>>();
      var cardMock = new Mock<IRepository<Card>>();
      this.cardDeckService = new CardDeckService(cardDeckMock.Object, cardMock.Object);

      var creator = this.GetTestCreator();

      var userRepositoryMock = new Mock<IRepository<User>>();
      userRepositoryMock.Setup(repository => repository.Get(It.IsAny<Guid>())).Returns(creator);

      var roomMock = new Mock<IRepository<Room>>();
      roomMock.Setup(repo => repo.Get(It.IsAny<Guid>())).Returns(this.GetTestRoom(creator, this.cardDeckService.GetCardDeck()));
      this.roomRepository = roomMock.Object;

      this.roomService = new RoomService(this.roomRepository, userRepositoryMock.Object);

      var discussionRepositoryMock = new Mock<IRepository<Discussion>>();
      discussionRepositoryMock.Setup(repository => repository.GetAll()).Returns(this.GetTestDiscussions());
      this.discussionService = new DiscussionService(discussionRepositoryMock.Object, this.roomRepository);
    }

    private IQueryable<Discussion> GetTestDiscussions()
    {
      var discussions = new List<Discussion>();

      var endedDiscussion = new Discussion("Ended Discussion", Guid.Empty);
      endedDiscussion.EndDateTime = DateTime.Now;

      var currentDiscussion = new Discussion("Current Discussion", Guid.Empty);

      var discussionInAnotherRoom = new Discussion("Discussion in another room", Guid.NewGuid());

      discussions.Add(endedDiscussion);
      discussions.Add(currentDiscussion);
      discussions.Add(discussionInAnotherRoom);

      return discussions.AsQueryable();
    }

    private User GetTestCreator()
    {
      return new User("Creator");
    }

    private User GetTestUser()
    {
      return new User("TestUser");
    }

    private Room GetTestRoom(User user, CardDeck cardDeck)
    {
      return new Room("TestRoom", cardDeck, user.Id);
    }

    [Test]
    public void GetRoomInfoTest()
    {
      var expected = "";
      //самому написать Json конвертированного Room
      //добавить обсуждение в комнате

      var roomController = new RoomController(this.roomService, this.cardDeckService, this.discussionService);
      var actual = roomController.GetRoomInfo(Guid.Empty);

      Console.WriteLine(JsonSerializer.Serialize(actual));

      Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
    }

    [Test]
    public void ConnectToRoomTest()
    {
      var expected = "";

      var roomController = new RoomController(this.roomService, this.cardDeckService, this.discussionService);
      var actual = roomController.Connect(Guid.Empty, this.GetTestUser().Id);

      Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
    }
  }
}
