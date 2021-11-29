using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_12
{
  /// <summary>
  /// Человек.
  /// </summary>
  public class Person
  {
    private string name;
    private int age;
    private DateTime birthDate;
    
    /// <summary>
    /// Имя.
    /// </summary>
    [Obsolete]
    public string Name
    {
      get => this.name;
      set => this.name = value;
    }

    /// <summary>
    /// Возраст.
    /// </summary>
    public int Age
    {
      get => this.age; 
      
      set
      {
        if (this.age >= 0)
          this.age = value;
      }
    }

    /// <summary>
    /// Дата рождения.
    /// </summary>
    public DateTime BirthDate => this.birthDate;

    /// <summary>
    /// Создаёт экземпляр класса Человек со стандартными значениями полей.
    /// </summary>
    public Person()
    {
      this.name = "Noname";
      this.age = 0;
      this.birthDate = new DateTime();
    }
  }
}
