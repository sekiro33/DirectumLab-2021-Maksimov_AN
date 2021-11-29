using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_8
{
  /// <summary>
  /// Program.
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// <param name="args">Аргументы.</param>
    public static void Main(string[] args)
    {
      foreach (var line in new StreamReaderEnumerable("ClientConnectionLog.log"))
      {
        Console.WriteLine(line);
      }
  
      #region
      var names = new List<string>();
      names.Add("Сергей");
      names.Add("Игорь");
      names.Add("Николай");
      names.Add("Иван");
      names.Add("Пётр");
      names.Add("Аркадий");
      Console.WriteLine("Перебор элементов списка:");
      PrintCollection(names);
      #endregion

      #region
      var phonebook = new Dictionary<string, string>();
      phonebook.Add("Сергей", "+7 (950) 213 42 43");
      phonebook.Add("Игорь", "+7 (922) 278 46 23");
      phonebook.Add("Николай", "+7 (950) 984 21 79");
      phonebook.Add("Иван", "+7 (912) 655 45 43");
      phonebook.Add("Пётр", "+7 (980) 678 01 03");
      phonebook.Add("Аркадий", "+7 (922) 128 12 78");
      Console.WriteLine("Перебор элементов словаря:");
      PrintCollection(phonebook);
      #endregion
    }

    /// <summary>
    /// Перебор коллекции.
    /// </summary>
    /// <param name="collection">Перебираемая коллекция.</param>
    public static void PrintCollection(IEnumerable collection)
    {
      foreach (var element in collection)
      {
        Console.WriteLine(element);
      }
    }
  }
}
