using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;

namespace PlanPoker.DTO
{
  /// <summary>
  /// Конвертер сущностей в DTO.
  /// </summary>
  public static class ConverterDTO
  {
    /// <summary>
    /// Конвертировать сущность пользователя в DTO.
    /// </summary>
    /// <param name="user">Пользователь.</param>
    /// <returns>Представление пользователя в DTO.</returns>
    public static UserDTO ConvertUser(User user)
    {
      return new UserDTO
      {
        Id = user.Id,
        Name = user.Name
      };
    }

    /// <summary>
    /// Конвертировать сущность карты в DTO.
    /// </summary>
    /// <param name="card">Карта.</param>
    /// <returns>Представление карты в DTO.</returns>
    public static CardDTO ConvertCard(Card card)
    {
      return new CardDTO
      {
        Id = card.Id,
        Value = card.Value
      };
    }

    /// <summary>
    /// Конвертировать сущность колоды карт в DTO.
    /// </summary>
    /// <param name="cardDeck">Колода карт.</param>
    /// <returns>Представление колоды карт в DTO.</returns>
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

    /// <summary>
    /// Конвертировать сущность комнаты в DTO.
    /// </summary>
    /// <param name="room">Комната.</param>
    /// <param name="users">Пользователи комнаты.</param>
    /// <param name="discussions">Обсуждения в комнате.</param>
    /// <returns>Представление пользователя в DTO.</returns>
    public static RoomDTO ConvertRoom(Room room, IEnumerable<UserDTO> users, IEnumerable<DiscussionDTO> discussions)
    {
      return new RoomDTO
      {
        Id = room.Id,
        Name = room.Name,
        Creator = room.Creator,
        CardDeck = ConvertCardDeck(room.CardDeck),
        Users = users,
        Discussion = discussions
      };
    }

    /// <summary>
    /// Конвертировать сущность обсуждения в DTO.
    /// </summary>
    /// <param name="discussion">Обсуждение.</param>
    /// <returns>Представление обсуждения в DTO.</returns>
    public static DiscussionDTO ConvertDiscussion(Discussion discussion)
    {
      return new DiscussionDTO
      {
        Id = discussion.Id,
        Name = discussion.Name,
        StartDateTime = discussion.StarDateTime,
        EndDateTime = discussion.EndDateTime,
        Grades = null
      };
    }
  }
}
