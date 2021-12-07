using System;
using System.Collections.Generic;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Колода карт.
  /// </summary>
  public class CardDeck : IEntity
  {
    private Guid id;
    private ICollection<Card> cards;

    /// <summary>
    /// Идентификатор колоды.
    /// </summary>
    public Guid Id => this.id;

    /// <summary>
    /// Название колоды.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Карты в колоде.
    /// </summary>
    public IEnumerable<Card> Cards => this.cards;

    /// <summary>
    /// Конструктор колоды карт.
    /// </summary>
    /// <param name="name">Название колоды.</param>
    public CardDeck(string name)
    {
      this.id = Guid.NewGuid();
      this.Name = name;
      this.cards = new List<Card>();
    }

    /// <summary>
    /// Добавить карту в колоду.
    /// </summary>
    /// <param name="card">Карта.</param>
    public void AddCard(Card card)
    {
      this.cards.Add(card);
    }
  }
}
