using System.Configuration;


namespace Task_12
{
  /// <summary>
  /// Коллекция ProgramSettings.
  /// </summary>
  [ConfigurationCollection(typeof(ProgramSettingsElement), CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
  public class ProgramSettingsCollection : ConfigurationElementCollection
  {
    /// <summary>
    /// Создание нового элемента ProgramSettingElement.
    /// </summary>
    /// <returns>ProgramSettingsElement.</returns>
    protected override ConfigurationElement CreateNewElement()
    {
      return new ProgramSettingsElement();
    }

    /// <summary>
    /// Получение ключа ProgramSettingsElement.
    /// </summary>
    /// <param name="element">Элемент ProgramSettingsElement.</param>
    /// <returns>SubSetting.</returns>
    protected override object GetElementKey(ConfigurationElement element)
    {
      return ((ProgramSettingsElement)element).SubSettingValue;
    }
  }
}
