using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    /// <summary>
    /// Конструктор сервиса.
    /// </summary>
    /// <param name="cardDeckRepository">Репозиторий колод с картами.</param>
    public CardDeckService(IRepository<CardDeck> cardDeckRepository)
    {
      this.cardDeckRepository = cardDeckRepository;
      this.cardDeckRepository.Save(this.GetStandarCardDeck());
    }

    /// <summary>
    /// Получить стандартную колоду карт.
    /// </summary>
    /// <returns>Стандартная колода карт.</returns>
    public CardDeck GetCardDeck()
    {
      return this.GetStandarCardDeck();
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

    /// <summary>
    /// Создать стандартную колоду с картами.
    /// </summary>
    /// <returns>Колода с картами.</returns>
    private CardDeck GetStandarCardDeck()
    {
      var cardDeck = new CardDeck("Стандартная колода");
      cardDeck.AddCard(new Card(0));
      cardDeck.AddCard(new Card(1));
      cardDeck.AddCard(new Card(2));
      cardDeck.AddCard(new Card(3));
      cardDeck.AddCard(new Card(5));
      cardDeck.AddCard(new Card(8));
      cardDeck.AddCard(new Card(13));
      cardDeck.AddCard(new Card(21));
      cardDeck.AddCard(new Card(34));
      return cardDeck;
    }
  }
}
