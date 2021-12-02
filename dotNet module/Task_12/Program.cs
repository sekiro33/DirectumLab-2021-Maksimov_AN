using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Task_12
{
  /// <summary>
  /// Program.
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Точка входа в программу.
    /// </summary>
    /// <param name="args">Параметры.</param>
    public static void Main(string[] args)
    {
      var person = new Person();

      Console.WriteLine("Задание 1:");
      PrintCollection(GetAllReadWriteProperties(person));

      Console.WriteLine("Задание 2:");
      PrintCollection(GetAllReadWriteProperties(typeof(Program).Assembly.Location, typeof(Person).FullName));

      Console.WriteLine("Задание 3:");
      PrintCollection(GetAllReadWritePropertiesWithIgnoreObsolete(person));

      Console.WriteLine("Задание 4:");
      var settingSection = (ProgramSettingsSection)ConfigurationManager.GetSection("ProgramSettings");
      foreach (ProgramSettingsElement setting in settingSection.ProgramSettings)
        Console.WriteLine($"{setting.SubSetting}: {setting.SubSettingValue}");

      Console.WriteLine("Задание 5:");
      var firstDll = Assembly.LoadFile(Path.GetFullPath("PersonAssembly1.dll"));
      var secondDll = Assembly.LoadFile(Path.GetFullPath("PersonAssembly2.dll"));

      Console.WriteLine("Информация о свойствах из первой dll:");
      PrintCollection(GetAllReadWriteProperties(firstDll.Location, firstDll.GetType("Person.Person").FullName));

      Console.WriteLine("Информация о свойствах из второй dll:");
      PrintCollection(GetAllReadWriteProperties(secondDll.Location, secondDll.GetType("Person.Person").FullName));
    }

    /// <summary>
    /// Получить список всех read-write свойств объекта.
    /// </summary>
    /// <param name="obj">Объект в котором читаются свойства.</param>
    /// <returns>Список всех read-write свойств объекта.</returns>
    public static Dictionary<string, string> GetAllReadWriteProperties(object obj)
    {
      return obj.GetType().GetProperties().Where(p => p.CanWrite && p.CanRead)
        .ToDictionary(p => p.Name, p => p.PropertyType.Name);
    }

    /// <summary>
    /// Получить список всех read-write свойств объекта.
    /// </summary>
    /// <param name="assemblyName">Имя сборки.</param>
    /// <param name="className">Имя класса.</param>
    /// <returns>Список всех read-write свойств объекта класса.</returns>
    public static Dictionary<string, string> GetAllReadWriteProperties(string assemblyName, string className)
    {
      var assembly = Assembly.LoadFile(assemblyName);
      var obj = assembly.CreateInstance(className);
      return GetAllReadWriteProperties(obj);
    }

    /// <summary>
    /// Получить список всех read-write свойств объекта, кроме свойств с аттрибутом Obsolete.
    /// </summary>
    /// <param name="obj">Объект в котором читаются свойства.</param>
    /// <returns>Список всех read-write свойств объекта, кроме свойств с аттрибутом Obsolete.</returns>
    public static Dictionary<string, string> GetAllReadWritePropertiesWithIgnoreObsolete(object obj)
    {
      return obj.GetType().GetProperties()
         .Where(p => p.CanWrite && p.CanRead && p.GetCustomAttribute(typeof(ObsoleteAttribute)) is null)
         .ToDictionary(p => p.Name, p => p.PropertyType.Name);
    }

    private static void PrintCollection(IEnumerable collection)
    {
      foreach (var item in collection)
        Console.WriteLine(item);
    }
  }
}
