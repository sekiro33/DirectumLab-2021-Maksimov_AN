using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanPoker.Domain.Entities;

namespace PlanPoker.DTO
{
  public class ConverterDTO
  {
    public static UserDTO ConvertUser(User user)
    {
      return new UserDTO
      {
        Id = user.Id,
        Name = user.Name
      };
    }

    public static CardDTO ConvertCard(Card card)
    {
      return new CardDTO
      {
        Id = card.Id,
        Value = card.Value
      };
    }

    public static CardDeckDTO ConvertCardDeck(CardDeck cardDeck)
    {
      var cards = cardDeck.Cards.Select(card => ConvertCard(card));
      return new CardDeckDTO
      {
        Id = cardDeck.Id,
        Name = cardDeck.Name,
        Cards = cards
      };
    }

    public static RoomDTO ConvertRoom(Room room, IEnumerable<UserDTO> users)
    {
      return new RoomDTO
      {
        Id = room.Id,
        Name = room.Name,
        Creator = room.Creator,
        Users = users,
        CardDeck = ConvertCardDeck(room.CardDeck)
      };
    }

    public static DiscussionDTO ConvertDiscussion(Discussion discussion)
    {
      return new DiscussionDTO
      {
        Id = discussion.Id,
        Name = discussion.Name,
        StartDateTime = discussion.StarDateTime,
        EndDateTime = discussion.EndDateTime,
        Grades = discussion.Grades,
      };
    }
  }
}
