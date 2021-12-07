using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanPoker.Domain.Entities
{
  /// <summary>
  /// Колода карт.
  /// </summary>
  public class CardDeck : IEntity
  {
    private Guid id;

    /// <summary>
    /// Идентификатор колоды.
    /// </summary>
    public Guid Id => this.id;

    private string name;

    /// <summary>
    /// Название колоды.
    /// </summary>
    public string Name
    {
      get => this.name;

      set => this.name = value;
    }

    private List<Card> cards;

    /// <summary>
    /// Карты в колоде.
    /// </summary>
    public List<Card> Cards => this.cards;

    /// <summary>
    /// Конструктор колоды карт.
    /// </summary>
    /// <param name="name">Название колоды.</param>
    public CardDeck(string name)
    {
      this.id = Guid.NewGuid();
      this.name = name;
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
