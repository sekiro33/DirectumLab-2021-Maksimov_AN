using System;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Domain.Services
{
  /// <summary>
  /// Сервис для работы с колодами карт.
  /// </summary>
  public class CardDeckService
  {
    private readonly IRepository<CardDeck> cardDeckRepository;
    private readonly IRepository<Card> cardRepository;

    /// <summary>
    /// Конструктор сервиса.
    /// </summary>
    /// <param name="cardDeckRepository">Репозиторий колод с картами.</param>
    /// <param name="cardRepository">Репозиторий карт.</param>
    public CardDeckService(IRepository<CardDeck> cardDeckRepository, IRepository<Card> cardRepository)
    {
      this.cardDeckRepository = cardDeckRepository;
      this.cardRepository = cardRepository;
    }

    /// <summary>
    /// Получить стандартную колоду карт.
    /// </summary>
    /// <returns>Стандартная колода карт.</returns>
    public CardDeck GetCardDeck()
    {
      var cardDeck = new CardDeck("Стандартная колода карт");
      var standartCards = this.cardRepository.GetAll();
      standartCards.ToList().ForEach(card => cardDeck.AddCard(card));
      return cardDeck;
    }

    /// <summary>
    /// Получить колоду карт по Id.
    /// </summary>
    /// <param name="cardDeckId">Id колоды карт.</param>
    /// <returns>Колода с картами.</returns>
    public CardDeck GetCardDeck(Guid cardDeckId)
    {
      return this.cardDeckRepository.Get(cardDeckId);
    }
  }
}
