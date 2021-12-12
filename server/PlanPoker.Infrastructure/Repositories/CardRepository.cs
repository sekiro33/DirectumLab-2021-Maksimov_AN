using System;
using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Infrastructure.Repositories
{
  /// <summary>
  /// Репозиторий карт.
  /// </summary>
  public class CardRepository : IRepository<Card>
  {
    private readonly List<Card> cards;

    /// <summary>
    /// Конструктор репозитория.
    /// </summary>
    public CardRepository()
    {
      this.cards = new List<Card>();
      this.CreateStandartCard();
    }

    /// <summary>
    /// Удалить карту.
    /// </summary>
    /// <param name="id">Id карты.</param>
    /// <returns>Удаленная карта.</returns>
    public Card Delete(Guid id)
    {
      var card = this.Get(id);
      if (card != null)
        this.cards.Remove(card);
      return card;
    }

    /// <summary>
    /// Получить карту по Id.
    /// </summary>
    /// <param name="id">Id карты.</param>
    /// <returns>Карта.</returns>
    public Card Get(Guid id)
    {
      return this.cards.Where(card => card.Id == id).FirstOrDefault();
    }

    /// <summary>
    /// Получить список всех карт.
    /// </summary>
    /// <returns>Список карт.</returns>
    public IQueryable<Card> GetAll()
    {
      return this.cards.AsQueryable();
    }

    /// <summary>
    /// Добавить карту в список.
    /// </summary>
    /// <param name="entity">Карта.</param>
    /// <returns>Добавленная карта.</returns>
    public Card Save(Card entity)
    {
      this.cards.Add(entity);
      return entity;
    }

    /// <summary>
    /// Создать набор стандартных карт.
    /// </summary>
    public void CreateStandartCard()
    {
      this.Save(new Card(null, "Coffe Break"));
      this.Save(new Card(0, "0"));
      this.Save(new Card(0.5, "0.5"));
      this.Save(new Card(1, "1"));
      this.Save(new Card(2, "2"));
      this.Save(new Card(3, "3"));
      this.Save(new Card(5, "5"));
      this.Save(new Card(8, "8"));
      this.Save(new Card(13, "13"));
      this.Save(new Card(21, "21"));
      this.Save(new Card(34, "34"));
    }
  }
}
