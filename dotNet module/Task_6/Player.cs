using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
  /// <summary>
  /// Игрок.
  /// </summary>
  public class Player
  {
    private int health;
    private int strength;
    private int dexterity;

    /// <summary>
    /// Здоровье.
    /// </summary>
    public int Health => this.health;

    /// <summary>
    /// Сила.
    /// </summary>
    public int Strength => this.strength;

    /// <summary>
    /// Ловкость.
    /// </summary>
    public int Dexterity => this.dexterity;

    /// <summary>
    /// Создать игрока с базовыми характеристиками.
    /// </summary>
    public Player()
    {
      this.health = 10;
      this.strength = 10;
      this.dexterity = 10;
    }
  }
}
