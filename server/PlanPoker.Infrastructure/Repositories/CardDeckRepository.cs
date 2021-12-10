using System;
using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Infrastructure.Repositories
{
  /// <summary>
  /// Репозиторий для колод карт.
  /// </summary>
  public class CardDeckRepository : IRepository<CardDeck>
  {
    private readonly List<CardDeck> cardDecks;

    /// <summary>
    /// Конструктор репозитория для карт.
    /// </summary>
    public CardDeckRepository()
    {
      this.cardDecks = new List<CardDeck>();
    }

    /// <summary>
    /// Удалить колоду карт.
    /// </summary>
    /// <param name="id">Id колоды.</param>
    /// <returns>Удаленная колода.</returns>
    public CardDeck Delete(Guid id)
    {
      var cardDeck = this.Get(id);
      if (cardDeck is not null)
        this.cardDecks.Remove(cardDeck);
      return cardDeck;
    }

    /// <summary>
    /// Получить колоду карт по Id.
    /// </summary>
    /// <param name="id">Id колоды.</param>
    /// <returns>Колода карт.</returns>
    public CardDeck Get(Guid id)
    {
      return this.cardDecks.Where(cardDeck => cardDeck.Id == id).FirstOrDefault();
    }

    /// <summary>
    /// Получить все колоды карт.
    /// </summary>
    /// <returns>Колоды карт.</returns>
    public IQueryable<CardDeck> GetAll()
    {
      return this.cardDecks.AsQueryable();
    }

    /// <summary>
    /// Добавить новую колоду карт.
    /// </summary>
    /// <param name="entity">Колода карт.</param>
    /// <returns>Новая колода.</returns>
    public CardDeck Save(CardDeck entity)
    {
      this.cardDecks.Add(entity);
      return entity;
    }
  }
}
