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
  [TestFixture]
  public class DiscussionControllerTests
  {
    // Получаемые результаты обсуждения - корректны.
    private DiscussionService discussionService;
    private IRepository<Discussion> discussionRepository;

    [OneTimeSetUp]
    public void SetUpOnce()
    {
      var cardDeckRepositoryMock = new Mock<IRepository<CardDeck>>();
      var cardRepositoryMock = new Mock<IRepository<Card>>();
      var cardDeckService = new CardDeckService(cardDeckRepositoryMock.Object, cardRepositoryMock.Object);

      var creator = this.GetTestCreator();

      var roomRepositoryMock = new Mock<IRepository<Room>>();
      roomRepositoryMock.Setup(repository => repository.Get(Guid.Empty)).Returns(this.GetTestRoom(cardDeckService.GetCardDeck(), creator));

      var discussionRepositroyMock = new Mock<IRepository<Discussion>>();
      discussionRepositroyMock.Setup(repository => repository.GetAll()).Returns(this.GetTestDiscussions());
      this.discussionRepository = discussionRepositroyMock.Object;

      this.discussionService = new DiscussionService(this.discussionRepository, roomRepositoryMock.Object);
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

    private Room GetTestRoom(CardDeck cardDeck, User creator)
    {
      return new Room("TestRoom", cardDeck, creator.Id);
    }

    [Test]
    public void GetAllDiscussionTest()
    {
      var discussions = this.discussionRepository.GetAll().Where(discussion => discussion.RoomId == Guid.Empty).AsEnumerable();
      var expected = discussions.Select(discussion => ConverterDTO.ConvertDiscussion(discussion));

      var discussionController = new DiscussionController(this.discussionService);
      var actual = discussionController.GetAllDiscussion(Guid.Empty);

      Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
    }
  }
}
